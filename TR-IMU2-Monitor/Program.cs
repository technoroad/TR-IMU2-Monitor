using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMU_PlatformTool2
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 1) exe.config のパスは CLR が使う「実際の構成ファイルパス」を参照するのが確実
            string configPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

            // 2) 念のため「exeと同じフォルダにあるか」も確認したい場合（通常は configPath で十分）
            // string exePath = Application.ExecutablePath;
            // string configPath = exePath + ".config";

            if (!File.Exists(configPath))
            {
                string exeName = Path.GetFileName(Application.ExecutablePath);
                string configName = exeName + ".config";

                MessageBox.Show(
                    $"必須ファイル '{configName}' が見つかりません。\n\n" +
                    "このアプリは高DPI設定などを構成ファイルから読み込みます。\n" +
                    "exe と同じフォルダに配置してから起動してください。",
                    "起動できません",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // 起動させない
                Environment.Exit(1);
                return;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
