using Microsoft.Win32;

namespace Root
{

    public class Util
    {

        private const string RUN_LOCATION = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";

        public Util()
        {
        }

        public static bool IsAutoStartEnabled(string keyName, string assemblyLocation)
        {
            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
            if (registryKey == null)
                return false;
            string s = (string)registryKey.GetValue(keyName);
            if (s == null)
                return false;
            return s == assemblyLocation;
        }

        public static void SetAutoStart(string keyName, string assemblyLocation)
        {
            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
            registryKey.SetValue(keyName, assemblyLocation);
        }

        public static void UnSetAutoStart(string keyName)
        {
            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
            registryKey.DeleteValue(keyName);
        }

    } // class Util

}

