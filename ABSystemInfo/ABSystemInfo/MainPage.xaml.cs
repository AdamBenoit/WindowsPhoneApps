using System;
using System.Globalization;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Phone.Info;

namespace ABSystemInfo
{
    public partial class MainPage
    {
        readonly DispatcherTimer _timer;
        
        private long _applicationCurrentMemoryUsage;
        private long _applicationMemoryUsageLimit;
        private long _applicationPeakMemoryUsage;
        private long _deviceTotalMemory;

        private const int AnidLength = 32;
        private const int AnidOffset = 2;

        public MainPage()
        {
            InitializeComponent();
            LoadStaticInfo();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += TimerTick;
            _timer.Start();

        }
        
        void TimerTick(object sender, EventArgs e)
        {
            try
            {
                _applicationCurrentMemoryUsage = DeviceStatus.ApplicationCurrentMemoryUsage;
                _applicationMemoryUsageLimit = DeviceStatus.ApplicationMemoryUsageLimit;
                _applicationPeakMemoryUsage = DeviceStatus.ApplicationPeakMemoryUsage;

                _deviceTotalMemory = DeviceStatus.DeviceTotalMemory;

                ApplicationCurrentMemoryUsageTextBlock.Text = String.Format("{0} MB ({1} KB)", ((_applicationCurrentMemoryUsage / 1024) / 1024), (_applicationCurrentMemoryUsage / 1024));
                ApplicationMemoryUsageLimitTextBlock.Text = String.Format("{0} MB ({1} KB)", ((_applicationMemoryUsageLimit / 1024) / 1024), (_applicationMemoryUsageLimit / 1024));
                ApplicationPeakMemoryUsageTextBlock.Text = String.Format("{0} MB ({1} KB)", ((_applicationPeakMemoryUsage / 1024) / 1024), (_applicationPeakMemoryUsage / 1024));
                DeviceTotalMemoryTextBlock.Text = String.Format("{0} MB ({1} KB)", ((_deviceTotalMemory / 1024) / 1024), (_deviceTotalMemory / 1024));

                IsKeyboardDeployedTextBlock.Text = DeviceStatus.IsKeyboardDeployed.ToString(CultureInfo.InvariantCulture);
                IsKeyboardPresentTextBlock.Text = DeviceStatus.IsKeyboardPresent.ToString(CultureInfo.InvariantCulture);
                PowerSourceTextBlock.Text = DeviceStatus.PowerSource.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadStaticInfo()
        {
            DeviceFirmwareVersionTextBlock.Text = DeviceStatus.DeviceFirmwareVersion;
            DeviceHardwareVersionTextBlock.Text = DeviceStatus.DeviceHardwareVersion;
            DeviceManufacturerTextBlock.Text = DeviceStatus.DeviceManufacturer;
            DeviceNameTextBlock.Text = DeviceStatus.DeviceName;

            OperatingSystemPlatformTextBlock.Text = Environment.OSVersion.Platform.ToString();
            OperatingSystemVersionTextBlock.Text = Environment.OSVersion.Version.ToString();

            ClrBuildTextBlock.Text = Environment.Version.Build.ToString(CultureInfo.InvariantCulture);
            ClrMajorTextBlock.Text = Environment.Version.Major.ToString(CultureInfo.InvariantCulture);
            ClrMinorTextBlock.Text = Environment.Version.Minor.ToString(CultureInfo.InvariantCulture);
            ClrRevisionTextBlock.Text = Environment.Version.Revision.ToString(CultureInfo.InvariantCulture);
            
            string deviceUniqueId = String.Empty;
            for (int i = 0; i < GetDeviceUniqueId().GetLength(0); i++)
            {
                deviceUniqueId += GetDeviceUniqueId().GetValue(i);
            }

            DeviceUniqueIDTextBlock.Text = deviceUniqueId;
            WindowsLiveAnonymousIDTextBlock.Text =
                GetWindowsLiveAnonymousId().ToString(CultureInfo.InvariantCulture);
        }

        //Note: to get a result requires ID_CAP_IDENTITY_DEVICE
        // to be added to the capabilities of the WMAppManifest
        // this will then warn users in marketplace

        public static byte[] GetDeviceUniqueId()
        {
            byte[] result = null;
            object uniqueId;
            if (DeviceExtendedProperties.TryGetValue("DeviceUniqueId", out uniqueId))
                result = (byte[])uniqueId;

            return result;
        }

        // NOTE: to get a result requires ID_CAP_IDENTITY_USER
        //  to be added to the capabilities of the WMAppManifest
        // this will then warn users in marketplace

        public static string GetWindowsLiveAnonymousId()
        {
            string result = String.Empty;
            object anid;
            if (UserExtendedProperties.TryGetValue("ANID", out anid))
            {
                if (anid != null && anid.ToString().Length >= (AnidLength + AnidOffset))
                {
                    result = anid.ToString().Substring(AnidOffset, AnidLength);
                }
            }

            return result;
        }
    }
}