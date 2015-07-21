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
            FormNotification notify = new Notify.FormNotification(
                Environment.MachineName,
                "Kliknutím zahajte výbuch tohoto zařízení."
            );

            notify.onClick += (sender, args) => {
                shutdownMachine();
                notify.Close();
            };

            Application.EnableVisualStyles();
            Application.Run(notify);
        }

        private static void shutdownMachine() {
            var psi = new ProcessStartInfo("shutdown","/s /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }

    }

}
