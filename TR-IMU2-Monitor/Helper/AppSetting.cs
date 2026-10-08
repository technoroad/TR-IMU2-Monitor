using System;
using System.IO;
using System.Xml.Serialization;

namespace IMU_PlatformTool2.Helper
{
    [Serializable]
    public class AppSettingsData
    {
        public string firmware_path { get; set; } = "";
        public string target_ip { get; set; } = "190.160.0.1";
        public int target_port { get; set; } = 5000;
        public string csv_save_path { get; set; } = "";
    }

    public static class AppSetting
    {
        private static readonly object SyncRoot = new object();
        private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(AppSettingsData));
        private static AppSettingsData _cache;

        private static string SettingFilePath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.xml");
            }
        }

        public static void Initialize()
        {
            LoadSettings();
        }

        public static void Reset()
        {
            SaveSettings(CreateDefault());
        }

        public static void SaveFirmwarePathToSettings(string firmware_path)
        {
            AppSettingsData s = LoadSettings();
            s.firmware_path = firmware_path ?? "";
            SaveSettings(s);
        }

        public static bool LoadFirmwarePathFromSettings(out string firmware_path)
        {
            AppSettingsData s = LoadSettings();
            firmware_path = s.firmware_path ?? "";
            return !string.IsNullOrWhiteSpace(firmware_path);
        }

        public static void SaveTargetIPAddressToSettings(string out_ip, int out_port)
        {
            AppSettingsData s = LoadSettings();
            s.target_ip = out_ip;
            s.target_port = out_port;
            SaveSettings(s);
        }

        public static bool LoadTargetIPAddressFromSettings(out string out_ip, out int out_port)
        {
            AppSettingsData s = LoadSettings();

            out_ip = "";
            out_port = 0;

            if (string.IsNullOrWhiteSpace(s.target_ip))
                return false;

            if (!TcpUtil.IsUsableIPv4(s.target_ip))
                return false;

            if (s.target_port <= 0)
                return false;

            out_ip = s.target_ip;
            out_port = s.target_port;
            return true;
        }

        public static bool SaveCsvSavePathToSettings(string csv_path)
        {
            if (string.IsNullOrWhiteSpace(csv_path))
                return false;

            AppSettingsData s = LoadSettings();
            s.csv_save_path = csv_path;
            SaveSettings(s);
            return true;
        }

        public static bool LoadCsvSavePathFromSetting(out string csv_path)
        {
            AppSettingsData s = LoadSettings();

            csv_path = "";

            if (string.IsNullOrWhiteSpace(s.csv_save_path))
                return false;

            csv_path = s.csv_save_path;

            if (!Directory.Exists(csv_path))
                return false;

            return true;
        }

        private static AppSettingsData CreateDefault()
        {
            return new AppSettingsData();
        }

        private static AppSettingsData LoadSettings()
        {
            lock (SyncRoot)
            {
                if (_cache != null)
                    return _cache;

                if (!File.Exists(SettingFilePath))
                {
                    _cache = CreateDefault();
                    SaveSettingsCore(_cache);
                    return _cache;
                }

                try
                {
                    using (FileStream stream = File.OpenRead(SettingFilePath))
                    {
                        _cache = (AppSettingsData)Serializer.Deserialize(stream);
                    }
                }
                catch
                {
                    _cache = CreateDefault();
                    SaveSettingsCore(_cache);
                }

                if (_cache == null)
                {
                    _cache = CreateDefault();
                    SaveSettingsCore(_cache);
                }

                return _cache;
            }
        }

        private static void SaveSettings(AppSettingsData settings)
        {
            lock (SyncRoot)
            {
                _cache = settings ?? CreateDefault();
                SaveSettingsCore(_cache);
            }
        }

        private static void SaveSettingsCore(AppSettingsData settings)
        {
            string dir = Path.GetDirectoryName(SettingFilePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using (FileStream stream = File.Create(SettingFilePath))
            {
                Serializer.Serialize(stream, settings);
            }
        }
    }
}
