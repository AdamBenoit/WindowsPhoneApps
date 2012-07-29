using System;
using System.Windows;
using Microsoft.Phone.Tasks;

namespace PunchClock.WP7.Business
{
    public class SendEmail
    {
        private readonly AppSettings _settings = new AppSettings();
        private readonly EmailComposeTask _emailComposeTask;
        public SendEmail(PunchTypes punchType)
        {
            try
            {
                _emailComposeTask = new EmailComposeTask();
                switch (punchType)
                {
                    case PunchTypes.DayStart:
                        _emailComposeTask.Subject = _settings.DayStartSetting;
                        break;
                    case PunchTypes.LunchStart:
                        _emailComposeTask.Subject = _settings.LunchStartSetting;
                        break;
                    case PunchTypes.LunchEnd:
                        _emailComposeTask.Subject = _settings.LunchEndSetting;
                        break;
                    case PunchTypes.DayEnd:
                        _emailComposeTask.Subject = _settings.DayEndSetting;
                        break;
                }
                _emailComposeTask.To = _settings.ToEmailSetting;
                _emailComposeTask.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Caught: " + ex.Message);
            }
        }
    }

    public enum PunchTypes
        {
            DayStart,
            LunchStart,
            LunchEnd,
            DayEnd
        }
}
