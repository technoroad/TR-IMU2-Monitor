using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace IMU_PlatformTool2.Services
{
    public static class ResourceExtractor
    {
        public static void ExtractResourceOBJ(string resourcePath, string outputPath, string filename)
        {
            ExtractResourceIfChanged(resourcePath, outputPath, filename + ".obj");
            ExtractResourceIfChanged(resourcePath, outputPath, filename + ".mtl");
        }
        public static void ExtractResourceIfChanged(string resourcePath, string outputPath, string filename)
        {
            string resourceName = resourcePath + "." + filename;
            outputPath = Path.Combine(outputPath, filename);

            var asm = Assembly.GetExecutingAssembly();

            // 1) リソースを開く
            using (var s = asm.GetManifestResourceStream(resourceName))
            {
                if (s == null)
                    throw new FileNotFoundException("Resource not found: " + resourceName);

                // 2) リソースのハッシュを計算（ストリームを読み切るので後で再オープンする）
                var newHash = ComputeSha256Hex(s);

                var hashPath = outputPath + ".sha256";
                var oldHash = File.Exists(hashPath) ? File.ReadAllText(hashPath) : null;

                // 3) 変更がなければスキップ
                if (File.Exists(outputPath) && string.Equals(oldHash, newHash, StringComparison.OrdinalIgnoreCase))
                    return;
            }

            // 4) 変更があるので再度開いて安全に上書き展開
            using (var s2 = asm.GetManifestResourceStream(resourceName))
            {
                if (s2 == null)
                    throw new FileNotFoundException("Resource not found: " + resourceName);

                SafeOverwriteFromStream(s2, outputPath);

                // ハッシュを保存
                s2.Position = 0; // 念のため（GetManifestResourceStream は Position 0 のはず）
                var hash = ComputeSha256Hex(s2);
                File.WriteAllText(outputPath + ".sha256", hash);
            }
        }

        private static string ComputeSha256Hex(Stream stream)
        {
            stream.Position = 0;
            using (var sha = SHA256.Create())
            {
                var hash = sha.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        private static void SafeOverwriteFromStream(Stream input, string outputPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // いきなり outputPath を上書きすると途中失敗で壊れるので、
            // temp -> replace で安全に更新する
            var tempPath = outputPath + ".tmp";

            using (var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                input.Position = 0;
                input.CopyTo(fs);
                fs.Flush(true);
            }

            // 置換（同一ボリューム内でアトミックに近い）
            if (File.Exists(outputPath))
            {
                // 既存退避が不要なら backup を null にしてOK
                File.Replace(tempPath, outputPath, null);
            }
            else
            {
                File.Move(tempPath, outputPath);
            }
        }
    }
}