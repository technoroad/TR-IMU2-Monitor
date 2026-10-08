using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

public static class Stm32ProgCliRunner
{
    public const string TargetExeName = "STM32_Programmer_CLI.exe";
    private static CancellationTokenSource _cts;

    /// <summary>
    /// STM32_Programmer_CLI.exe のフルパスを探して返します（Windows向け）。
    /// 見つからなければ null を返します。
    ///
    /// 探索順:
    /// 1) 環境変数 STM32_PRG_PATH（STがインストール時に作ることがある）
    /// 2) PATH（where相当の探索）
    /// 3) 典型インストール先（Program Files / (x86)）
    /// </summary>
    public static string FindStm32ProgrammerCli()
    {
        // 1) STM32_PRG_PATH を最優先
        var fromEnv = FindFromStm32PrgPath();
        if (!string.IsNullOrEmpty(fromEnv))
            return fromEnv;

        // 2) PATH から探索
        var fromPath = FindFromPath();
        if (!string.IsNullOrEmpty(fromPath))
            return fromPath;

        // 3) 典型パスをチェック
        var fromDefault = FindFromDefaultLocations();
        if (!string.IsNullOrEmpty(fromDefault))
            return fromDefault;

        return null;
    }

    /// <summary>
    /// PATH要素や環境変数の値を軽く正規化（両端空白/クォート除去）
    /// </summary>
    private static string NormalizeDir(string dir)
    {
        dir = dir.Trim();

        // "C:\Program Files\..." のようなクォート付きに対応
        if (dir.Length >= 2 && dir[0] == '"' && dir[dir.Length - 1] == '"')
            dir = dir.Substring(1, dir.Length - 2);

        return dir;
    }

    /// <summary>
    /// STインストーラが設定することがある STM32_PRG_PATH から探す
    /// </summary>
    private static string FindFromStm32PrgPath()
    {
        try
        {
            var baseDir = Environment.GetEnvironmentVariable("STM32_PRG_PATH");
            if (string.IsNullOrWhiteSpace(baseDir))
                return null;

            baseDir = NormalizeDir(baseDir);

            // STM32_PRG_PATH が ...\bin を指すことが多い
            var candidate = Path.Combine(baseDir, TargetExeName);
            if (File.Exists(candidate))
                return candidate;

            // もし ...\STM32CubeProgrammer を指していた場合に備えて bin も試す
            candidate = Path.Combine(baseDir, "bin", TargetExeName);
            if (File.Exists(candidate))
                return candidate;
        }
        catch
        {
            // ignore
        }

        return null;
    }

    /// <summary>
    /// PATH 環境変数を走査して探す（where相当）
    /// </summary>
    private static string FindFromPath()
    {
        string pathEnv = null;
        try
        {
            pathEnv = Environment.GetEnvironmentVariable("PATH");
        }
        catch
        {
            return null;
        }

        if (string.IsNullOrEmpty(pathEnv))
            return null;

        var paths = pathEnv.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < paths.Length; i++)
        {
            var dir = paths[i];
            if (string.IsNullOrWhiteSpace(dir))
                continue;

            dir = NormalizeDir(dir);

            try
            {
                var candidate = Path.Combine(dir, TargetExeName);
                if (File.Exists(candidate))
                    return candidate;
            }
            catch
            {
                // ignore invalid path element
            }
        }

        return null;
    }

    /// <summary>
    /// 典型インストール先をチェック
    /// </summary>
    private static string FindFromDefaultLocations()
    {
        // 64bit OSでは通常 Program Files 側に入るが、環境によっては (x86) のこともある
        var cand1 = @"C:\Program Files\STMicroelectronics\STM32Cube\STM32CubeProgrammer\bin\STM32_Programmer_CLI.exe";
        if (File.Exists(cand1)) return cand1;

        var cand2 = @"C:\Program Files (x86)\STMicroelectronics\STM32Cube\STM32CubeProgrammer\bin\STM32_Programmer_CLI.exe";
        if (File.Exists(cand2)) return cand2;

        return null;
    }

    static string ToAsciiVisible(string s)
    {
        var sb = new StringBuilder();
        foreach (char c in s)
        {
            if (c <= 0x7F)
            {
                if (char.IsControl(c))
                    sb.Append(@"\x").Append(((int)c).ToString("X2"));
                else
                    sb.Append(c);
            }
            // ASCII外は無視 or ? にしたければここで制御
        }
        byte[] bytes = Encoding.ASCII.GetBytes(s);
        return sb.ToString();
    }


    public static async Task<bool> FlashDfuAsync(string cliPath, string fwPath, string port, IProgress<string> progress)
    {
        _cts = new CancellationTokenSource();

        //Action<string> log = line => progress?.Report(line);
        Action<string> log = line => progress?.Report(ToAsciiVisible(line));

        // 1) Mass erase
        var r1 = await ProcessRunner.RunAsync(
            cliPath,
            $"--connect port={port} --erase all",
            log, log,
            timeoutMs: 60_000,
            ct: _cts.Token);

        if (r1.ExitCode != 0)
            return false;

        // 2) Write + Verify
        var r2 = await ProcessRunner.RunAsync(
            cliPath,
            $"--connect port={port} --write \"{fwPath}\" -v",
            log, log,
            timeoutMs: 180_000,
            ct: _cts.Token);

        return r2.ExitCode == 0;
    }

    public static async Task<bool> RunProgDfuAsync(string cliPath, string port, IProgress<string> progress)
    {
        _cts = new CancellationTokenSource();

        //Action<string> log = line => progress?.Report(line);

        // プログラム実行
        var r1 = await ProcessRunner.RunAsync(
            cliPath,
            $"--connect port={port} -g 0x08000000",
            null, null,
            timeoutMs: 60_000,
            ct: _cts.Token);

        return r1.ExitCode == 0;
    }


    public static async Task<bool> CheckUsbConnectAsync(string cliPath, string port, IProgress<string> progress)
    {
        _cts = new CancellationTokenSource();

        Action<string> log = line => progress?.Report(ToAsciiVisible(line));

        // USB DFUの存在確認
        var r1 = await ProcessRunner.RunAsync(
            cliPath,
            $"--connect port={port}",
            log, log,
            timeoutMs: 1000,
            ct: _cts.Token);

        return r1.ExitCode == 0;
    }
}

