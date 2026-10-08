using IMU_PlatformTool2.Models;
using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace IMU_PlatformTool2.Helper
{
    public static class FormUiValueUtil
    {
        public static uint GetCsvRecordSeconds(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    return 1 * 60;
                case 1:
                    return 5 * 60;
                case 2:
                    return 10 * 60;
                case 3:
                    return 30 * 60;
                case 4:
                    return 1 * 3600;
                case 5:
                    return 24 * 3600;
                default:
                    return 24 * 3600;
            }
        }

        public static uint GetCsvRecordStep(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    return 1;
                case 1:
                    return 2;
                case 2:
                    return 5;
                case 3:
                    return 10;
                case 4:
                    return 20;
                case 5:
                    return 1000;
                default:
                    return 1;
            }
        }

        public static uint GetTargetRecordSample(uint recordSeconds, uint csvRecordStep, uint baseHz)
        {
            if (csvRecordStep == 0)
                return 0;

            return recordSeconds * (baseHz / csvRecordStep);
        }

        public static string MakeCsvFilePath(string baseDir, DateTime now)
        {
            string dateDir = Path.Combine(baseDir, now.ToString("yyyyMMdd"));
            string fileName = now.ToString("yyyyMMdd_HHmmss") + ".csv";

            Directory.CreateDirectory(dateDir);

            return Path.Combine(dateDir, fileName);
        }

        public static string MakeModelPathFromBoardInfo(string board, int productId)
        {
            string basePath = Path.Combine(Path.GetTempPath(), "TR-IMU2-Monitor");

            if (board == "TR-IMU16607")
            {
                return Path.Combine(basePath, "TR_IMU16607.obj");
            }

            if (board == "TR-IMU-Platform2")
            {
                string sensor = "IMU_Platform";

                if (productId == 16607)
                {
                    sensor += "_1660X";
                }
                else if (productId == 16500 || productId == 16505)
                {
                    sensor += "_1650X";
                }
                else if (productId == 16470 || productId == 16475 || productId == 16477)
                {
                    sensor += "_1647X";
                }
                else if (productId == 16575)
                {
                    sensor += "_14P";
                }

                return Path.Combine(basePath, sensor + ".obj");
            }

            return "";
        }

        public static int GetZoomValueFromBoard(string board, bool browseCube)
        {
            if (browseCube)
                return 8;

            if (board == "TR-IMU16607")
                return 8;

            if (board == "TR-IMU-Platform2")
                return 14;

            return 14;
        }

        public static int GetCameraAngleFromSelectedIndex(int selectedIndex)
        {
            return selectedIndex * 90;
        }

        public static string MakeProductName(int imuMaker, int productId, int model)
        {
            if (imuMaker == 1)
            {
                string name = "ADIS" + productId;

                if (model == 3)
                    name += "-1";
                else if (model == 7)
                    name += "-2";
                else if (model == 15)
                    name += "-3";

                return name;
            }

            if (imuMaker == 2)
                return "Other-" + productId;

            return "";
        }

        public static int CountNewLines(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            return text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None).Length;
        }

        public static string MakeCsvHeader(bool quat_flag)
        {
            if (quat_flag)
            {
                return string.Join(",",
                    "SendCount",
                    "QuatW",
                    "QuatX",
                    "QuatY",
                    "QuatZ",
                    "TempC",
                    "ImuCount",
                    "GyroX[deg/s]",
                    "GyroY[deg/s]",
                    "GyroZ[deg/s]",
                    "AcclX[g]",
                    "AcclY[g]",
                    "AcclZ[g]",
                    "Timestamp[us]");
            }
            else
            {
                return string.Join(",",
                    "SendCount",
                    "X_Roll[deg]",
                    "Y_Pitch[deg]",
                    "Z_Yaw[deg]",
                    "TempC",
                    "ImuCount",
                    "GyroX[deg/s]",
                    "GyroY[deg/s]",
                    "GyroZ[deg/s]",
                    "AcclX[g]",
                    "AcclY[g]",
                    "AcclZ[g]",
                    "Timestamp[us]");
            }

        }

        public static string ToCsvString(TelemetryData telemetry, double gyro_sens, double accl_sens,bool quat_flag)
        {
            var sb = new StringBuilder();

            string gyro_x, gyro_y, gyro_z;
            string accl_x, accl_y, accl_z;

            var parsed = telemetry.Raws;
            var calc = telemetry.Decords;

            gyro_x = ((int)parsed.Gyro_x / gyro_sens).ToString("0.000000", CultureInfo.InvariantCulture);
            gyro_y = ((int)parsed.Gyro_y / gyro_sens).ToString("0.000000", CultureInfo.InvariantCulture);
            gyro_z = ((int)parsed.Gyro_z / gyro_sens).ToString("0.000000", CultureInfo.InvariantCulture);

            accl_x = ((int)parsed.Accl_x / accl_sens).ToString("0.000000", CultureInfo.InvariantCulture);
            accl_y = ((int)parsed.Accl_y / accl_sens).ToString("0.000000", CultureInfo.InvariantCulture);
            accl_z = ((int)parsed.Accl_z / accl_sens).ToString("0.000000", CultureInfo.InvariantCulture);

            string str = "";
            str += parsed.SendCount + ",";

            if (quat_flag)
            {
                str += string.Join(",", 
                    calc.QuatNorm.W.ToString("0.000000", CultureInfo.InvariantCulture), 
                    calc.QuatNorm.X.ToString("0.000000", CultureInfo.InvariantCulture),
                    calc.QuatNorm.Y.ToString("0.000000", CultureInfo.InvariantCulture),
                    calc.QuatNorm.Z.ToString("0.000000", CultureInfo.InvariantCulture)
                    );

                str += ",";
            }
            else
            {
                str += string.Join(",",
                    calc.EulerDeg.X.ToString("0.000000", CultureInfo.InvariantCulture),
                    calc.EulerDeg.Y.ToString("0.000000", CultureInfo.InvariantCulture),
                    calc.EulerDeg.Z.ToString("0.000000", CultureInfo.InvariantCulture)
                    );
                str += ",";
            }

            str += string.Join(",",
                calc.TempC.ToString("0.0", CultureInfo.InvariantCulture),
                parsed.ImuCount,
                gyro_x,
                gyro_y,
                gyro_z,
                accl_x,
                accl_y,
                accl_z,
                parsed.Timestamp);

            sb.AppendLine(str);

            return sb.ToString();
        }
    }
}
