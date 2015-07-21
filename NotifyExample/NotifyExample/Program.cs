using Notify;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace NotifyExample {

    static class Program {

        [STAThread]
        static void Main() {
            FormNotificationText notify = new FormNotificationText(
                Environment.MachineName,
                "Kliknutím zahajte výbuch tohoto zařízení."
            );

            notify.onClick += (sender, args) => {
                notify.closeWithAnimation();
            };

            Application.EnableVisualStyles();
            Application.Run(notify);
        }

    }

}
