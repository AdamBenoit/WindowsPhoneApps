using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.IsolatedStorage;

namespace PunchClock.WP7.Business
{
    public class AppSettings
    {
        // Our isolated storage settings
        IsolatedStorageSettings isolatedStore;

        // The isolated storage key names of our settings

        private const string ToEmailSettingKeyName = "ToEmail";
        private const string ToNameSettingKeyName = "ToName";
        private const string CcToSelfSettingKeyName = "CcToSelf";
        private const string DayStartSettingKeyName = "DayStartSubject";
        private const string LunchStartSettingKeyName = "LunchStartSubject";
        private const string LunchEndSettingKeyName = "LunchEndSubject";
        private const string DayEndSettingKeyName = "DayEndSubject";

        // The default value of our settings
        private const string ToEmailSettingDefault = "email@example.com";
        private const string ToNameSettingDefault = "Default User";
        private const bool CcToSelfSettingDefault = true;
        private const string DayStartSettingDefault = "Arrival Time";
        private const string LunchStartSettingDefault = "Off to lunch";
        private const string LunchEndSettingDefault = "Back From Lunch";
        private const string DayEndSettingDefault = "Home Time";

        /// <summary>
        /// Constructor that gets the application settings.
        /// </summary>
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

        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            try
            {
                // if new value is different, set the new value.
                if (isolatedStore[Key] != value)
                {
                    isolatedStore[Key] = value;
                    valueChanged = true;
                }
            }
            catch (KeyNotFoundException)
            {
                isolatedStore.Add(Key, value);
                valueChanged = true;
            }
            catch (ArgumentException)
            {
                isolatedStore.Add(Key, value);
                valueChanged = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception while using IsolatedStorageSettings: " + e.ToString());
            }

            return valueChanged;
        }


        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="valueType"></typeparam>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public valueType GetValueOrDefault<valueType>(string Key, valueType defaultValue)
        {
            valueType value;

            try
            {
                value = (valueType)isolatedStore[Key];
            }
            catch (KeyNotFoundException)
            {
                value = defaultValue;
            }
            catch (ArgumentException)
            {
                value = defaultValue;
            }

            return value;
        }


        /// <summary>
        /// Save the settings.
        /// </summary>
        public void Save()
        {
            isolatedStore.Save();
        }

        /// <summary>
        /// Property to get and set a Username Setting Key.
        /// </summary>
        public string ToEmailSetting
        {
            get
            {
                return GetValueOrDefault<string>(ToEmailSettingKeyName, ToEmailSettingDefault);
            }
            set
            {
                AddOrUpdateValue(ToEmailSettingKeyName, value);
                Save();
            }
        }
        /// <summary>
        /// Property to get and set a Username Setting Key.
        /// </summary>
        public string ToNameSetting
        {
            get
            {
                return GetValueOrDefault<string>(ToNameSettingKeyName, ToNameSettingDefault);
            }
            set
            {
                AddOrUpdateValue(ToNameSettingKeyName, value);
                Save();
            }
        }
        /// <summary>
        /// Property to get and set a ListBox Setting Key.
        /// </summary>
        public string DayStartSetting
        {
            get
            {
                return GetValueOrDefault<string>(DayStartSettingKeyName, DayStartSettingDefault);
            }
            set
            {
                AddOrUpdateValue(DayStartSettingKeyName, value);
                Save();
            }
        }
        /// <summary>
        /// Property to get and set a ListBox Setting Key.
        /// </summary>
        public string LunchStartSetting
        {
            get
            {
                return GetValueOrDefault<string>(LunchStartSettingKeyName, LunchStartSettingDefault);
            }
            set
            {
                AddOrUpdateValue(LunchStartSettingKeyName, value);
                Save();
            }
        }
        /// <summary>
        /// Property to get and set a ListBox Setting Key.
        /// </summary>
        public string LunchEndSetting
        {
            get
            {
                return GetValueOrDefault<string>(LunchEndSettingKeyName, LunchEndSettingDefault);
            }
            set
            {
                AddOrUpdateValue(LunchEndSettingKeyName, value);
                Save();
            }
        }
        /// <summary>
        /// Property to get and set a ListBox Setting Key.
        /// </summary>
        public string DayEndSetting
        {
            get
            {
                return GetValueOrDefault<string>(DayEndSettingKeyName, DayEndSettingDefault);
            }
            set
            {
                AddOrUpdateValue(DayEndSettingKeyName, value);
                Save();
            }
        }

        /// <summary>
        /// Property to get and set a ListBox Setting Key.
        /// </summary>
        public bool CcToSelfSetting
        {
            get
            {
                return GetValueOrDefault<bool>(CcToSelfSettingKeyName, CcToSelfSettingDefault);
            }
            set
            {
                AddOrUpdateValue(CcToSelfSettingKeyName, value);
                Save();
            }
        }


    }
}