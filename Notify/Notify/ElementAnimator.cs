using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notify {

    public static class ElementAnimator {

        public static void doShowAnimation(Form element) {
            element.Visible = true;
            int defaultHeight = element.Height;
            element.Height = 0;
            int taskBarHeight = Screen.PrimaryScreen.Bounds.Bottom - Screen.PrimaryScreen.WorkingArea.Bottom;

            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (sender, args) => {
                if(element.Height < defaultHeight) {
                    element.Height += 2;
                    element.Location = new Point(
                        Screen.PrimaryScreen.Bounds.Width - element.Width - 8,
                        Screen.PrimaryScreen.Bounds.Height - element.Height - taskBarHeight
                    );
                    element.Refresh();
                } else {
                    timer.Dispose();
                }
            };
            timer.Start();
        }

    }

}
