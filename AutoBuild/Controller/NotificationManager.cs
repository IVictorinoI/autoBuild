using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBuild.Controller
{
    public class NotificationManager
    {
        private static NotifyIcon notifyIcon;

        private NotificationManager() { }

        public static NotifyIcon NotifyIcon
        {
            get
            {
                if (notifyIcon == null)
                {
                    notifyIcon = new NotifyIcon();
                }

                return notifyIcon;
            }
        }
    }
}
