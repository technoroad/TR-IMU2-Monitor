using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


public sealed class ProcessResult
{
    public int ExitCode { get; set; }
    public string StdOut { get; set; }
    public string StdErr { get; set; }
    public bool TimedOut { get; set; }
}

public static class ProcessRunner
{
    public static async Task<ProcessResult> RunAsync(
        string exePath,
        string arguments,
        Action<string> onStdoutLine,
        Action<string> onStderrLine,
        int timeoutMs,
        CancellationToken ct)
    {
        var psi = new ProcessStartInfo
        {
            FileName = exePath,
            Arguments = arguments,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        var stdout = new StringBuilder();
        var stderr = new StringBuilder();

        using (var p = new Process { StartInfo = psi, EnableRaisingEvents = true })
        {
            var tcsExit = new TaskCompletionSource<int>();

            p.OutputDataReceived += (s, e) =>
            {
                if (e.Data == null) return;
                stdout.AppendLine(e.Data);
                if (onStdoutLine != null) onStdoutLine(e.Data);
            };

            p.ErrorDataReceived += (s, e) =>
            {
                if (e.Data == null) return;
                stderr.AppendLine(e.Data);
                if (onStderrLine != null) onStderrLine(e.Data);
            };

            p.Exited += (s, e) =>
            {
                try
                {
                    p.WaitForExit();
                    tcsExit.TrySetResult(p.ExitCode);
                }
                catch
                {
                    tcsExit.TrySetResult(-1);
                }
            };

            if (!p.Start())
            {
                return new ProcessResult { ExitCode = -1, StdOut = "", StdErr = "Failed to start process." };
            }

            p.BeginOutputReadLine();
            p.BeginErrorReadLine();

            // キャンセル/タイムアウト管理
            var delayTask = Task.Delay(timeoutMs, ct);
            var finished = await Task.WhenAny(tcsExit.Task, delayTask).ConfigureAwait(false);

            if (finished == delayTask)
            {
                // タイムアウト or キャンセル
                try { if (!p.HasExited) p.Kill(); } catch { }
                return new ProcessResult
                {
                    ExitCode = -1,
                    StdOut = stdout.ToString(),
                    StdErr = stderr.ToString(),
                    TimedOut = !ct.IsCancellationRequested
                };
            }

            // 正常終了
            var code = await tcsExit.Task.ConfigureAwait(false);
            return new ProcessResult
            {
                ExitCode = code,
                StdOut = stdout.ToString(),
                StdErr = stderr.ToString(),
                TimedOut = false
            };
        }
    }
}