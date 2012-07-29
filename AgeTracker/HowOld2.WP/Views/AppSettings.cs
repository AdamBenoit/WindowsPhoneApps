using System;
using System.IO.IsolatedStorage;
using System.Diagnostics;

namespace HowOld2.WP
{
    public class AppSettings
    {

        // Our isolated storage settings
        IsolatedStorageSettings isolatedStore;

#region General Settings 
        const string ShowTotalTimeSettingKeyName = "ShowTotalTimeSetting";

        const bool ShowTotalTimeSettingDefault = true;

        public bool ShowTotalTimeSetting
        {
            get
            {
                return GetValueOrDefault<bool>(ShowTotalTimeSettingKeyName, ShowTotalTimeSettingDefault);
            }
            set
            {
                AddOrUpdateValue(ShowTotalTimeSettingKeyName, value);
                Save();
            }
        }
        
#endregion
        
#region Person 1 Settings
        const string Birthday1DateSettingKeyName = "Birthday1DateSetting";
        const string Birthday1NameSettingKeyName = "Birthday1NameSetting";
        const string UseTime1CheckBoxSettingKeyName = "UseTime1CheckBoxSetting";
        const string Birthday1TimeSettingKeyName = "Birthday1TimeSetting";

        DateTime Birthday1DateSettingDefault = new DateTime(1970, 1, 1, 0, 0, 0);
        const string Birthday1NameSettingDefault = "Person 1";
        const bool UseTime1CheckBoxSettingDefault = true;
        DateTime Birthday1TimeSettingDefault = new DateTime(1970, 1, 1, 0, 0, 0);

        public string Birthday1NameSetting
        {
            get
            {
                return GetValueOrDefault<string>(Birthday1NameSettingKeyName, Birthday1NameSettingDefault);
            }
            set
            {
                AddOrUpdateValue(Birthday1NameSettingKeyName, value);
                Save();
            }
        }
        public DateTime Birthday1DateSetting
        {
            get
            {
                return GetValueOrDefault<DateTime>(Birthday1DateSettingKeyName, Birthday1DateSettingDefault);
            }
            set
            {
                AddOrUpdateValue(Birthday1DateSettingKeyName, value);
                Save();
            }
        }
        public bool UseTime1CheckBoxSetting
        {
            get
            {
                return GetValueOrDefault<bool>(UseTime1CheckBoxSettingKeyName, UseTime1CheckBoxSettingDefault);
            }
            set
            {
                AddOrUpdateValue(UseTime1CheckBoxSettingKeyName, value);
                Save();
            }
        }
        public DateTime Birthday1TimeSetting
        {
            get
            {
                return GetValueOrDefault<DateTime>(Birthday1TimeSettingKeyName, Birthday1TimeSettingDefault);
            }
            set
            {
                AddOrUpdateValue(Birthday1TimeSettingKeyName, value);
                Save();
            }
        }

#endregion 

#region Person 2 Settings
        // Person 2 Settings
        const string UsePerson2CheckBoxSettingKeyName = "UsePerson2CheckBoxSetting";
        const string Birthday2DateSettingKeyName = "Birthday2DateSetting";
        const string Birthday2NameSettingKeyName = "Birthday2NameSetting";
        const string UseTime2CheckBoxSettingKeyName = "UseTime2CheckBoxSetting";
        const string Birthday2TimeSettingKeyName = "Birthday2TimeSetting";

        const bool UsePerson2CheckBoxSettingDefault = false;
        DateTime Birthday2DateSettingDefault = new DateTime(1970, 1, 1, 0, 0, 0);
        const string Birthday2NameSettingDefault = "Person 2";
        const bool UseTime2CheckBoxSettingDefault = true;
        DateTime Birthday2TimeSettingDefault = new DateTime(1970, 1, 1, 0, 0, 0);

        public bool UsePerson2CheckBoxSetting
        {
            get
            {
                return GetValueOrDefault<bool>(UsePerson2CheckBoxSettingKeyName, UsePerson2CheckBoxSettingDefault);
            }
            set
            {
                AddOrUpdateValue(UsePerson2CheckBoxSettingKeyName, value);
                Save();
            }
        }
        public string Birthday2NameSetting
        {
            get
            {
                return GetValueOrDefault<string>(Birthday2NameSettingKeyName, Birthday2NameSettingDefault);
            }
            set
            {
                AddOrUpdateValue(Birthday2NameSettingKeyName, value);
                Save();
            }
        }
        public DateTime Birthday2DateSetting
        {
            get
            {
                return GetValueOrDefault<DateTime>(Birthday2DateSettingKeyName, Birthday2DateSettingDefault);
            }
            set
            {
                AddOrUpdateValue(Birthday2DateSettingKeyName, value);
                Save();
            }
        }
        public bool UseTime2CheckBoxSetting
        {
            get
            {
                return GetValueOrDefault<bool>(UseTime2CheckBoxSettingKeyName, UseTime2CheckBoxSettingDefault);
            }
            set
            {
                AddOrUpdateValue(UseTime2CheckBoxSettingKeyName, value);
                Save();
            }
        }
        public DateTime Birthday2TimeSetting
        {
            get
            {
                return GetValueOrDefault<DateTime>(Birthday2TimeSettingKeyName, Birthday2TimeSettingDefault);
            }
            set
            {
                AddOrUpdateValue(Birthday2TimeSettingKeyName, value);
                Save();
            }
        }
#endregion

#region Person 3 Settings
        // Person 3 Settings
        const string UsePerson3CheckBoxSettingKeyName = "UsePerson3CheckBoxSetting";
        const string Birthday3DateSettingKeyName = "Birthday3DateSetting";
        const string Birthday3NameSettingKeyName = "Birthday3NameSetting";
        const string UseTime3CheckBoxSettingKeyName = "UseTime3CheckBoxSetting";
        const string Birthday3TimeSettingKeyName = "Birthday3TimeSetting";

        const bool UsePerson3CheckBoxSettingDefault = false;
        DateTime Birthday3DateSettingDefault = new DateTime(1970, 1, 1, 0, 0, 0);
        const string Birthday3NameSettingDefault = "Person 3";
        const bool UseTime3CheckBoxSettingDefault = true;
        DateTime Birthday3TimeSettingDefault = new DateTime(1970, 1, 1, 0, 0, 0);

        public bool UsePerson3CheckBoxSetting
        {
            get
            {
                return GetValueOrDefault<bool>(UsePerson3CheckBoxSettingKeyName, UsePerson3CheckBoxSettingDefault);
            }
            set
            {
                AddOrUpdateValue(UsePerson3CheckBoxSettingKeyName, value);
                Save();
            }
        }
        public string Birthday3NameSetting
        {
            get
            {
                return GetValueOrDefault<string>(Birthday3NameSettingKeyName, Birthday3NameSettingDefault);
            }
            set
            {
                AddOrUpdateValue(Birthday3NameSettingKeyName, value);
                Save();
            }
        }
        public DateTime Birthday3DateSetting
        {
            get
            {
                return GetValueOrDefault<DateTime>(Birthday3DateSettingKeyName, Birthday3DateSettingDefault);
            }
            set
            {
                AddOrUpdateValue(Birthday3DateSettingKeyName, value);
                Save();
            }
        }
        public bool UseTime3CheckBoxSetting
        {
            get
            {
                return GetValueOrDefault<bool>(UseTime3CheckBoxSettingKeyName, UseTime3CheckBoxSettingDefault);
            }
            set
            {
                AddOrUpdateValue(UseTime3CheckBoxSettingKeyName, value);
                Save();
            }
        }
        public DateTime Birthday3TimeSetting
        {
            get
            {
                return GetValueOrDefault<DateTime>(Birthday3TimeSettingKeyName, Birthday3TimeSettingDefault);
            }
            set
            {
                AddOrUpdateValue(Birthday3TimeSettingKeyName, value);
                Save();
            }
        }
#endregion

        public AppSettings()
        {
            try
            {
                // Get the settings for this application.
                isolatedStore = IsolatedStorageSettings.ApplicationSettings;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception while using IsolatedStorageSettings: " + e.ToString());
            }
        }

        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            // If the key exists
            if (isolatedStore.Contains(Key))
            {
                // If the value has changed
                if (isolatedStore[Key] != value)
                {
                    // Store the new value
                    isolatedStore[Key] = value;
                    valueChanged = true;
                }
            }
            // Otherwise create the key.
            else
            {
                isolatedStore.Add(Key, value);
                valueChanged = true;
            }

            return valueChanged;
        }

        public valueType GetValueOrDefault<valueType>(string Key, valueType defaultValue)
        {
            valueType value;

            // If the key exists, retrieve the value.
            if (isolatedStore.Contains(Key))
            {
                value = (valueType)isolatedStore[Key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }

            return value;
        }

        public void Save()
        {
            isolatedStore.Save();
        }
    }
}
