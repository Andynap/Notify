using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notify {

    public static class ElementAnimator {

        public static event EventHandler onAnimationComplete = delegate { };

        public static void animateShow(Form element, int speed = 10) {
            element.Visible = true;
            int defaultHeight = element.Height;
            element.Height = 0;
            int taskBarHeight = Screen.PrimaryScreen.Bounds.Bottom - Screen.PrimaryScreen.WorkingArea.Bottom;

            Timer timer = new Timer();
            timer.Interval = speed;
            timer.Tick += (sender, args) => {
                if(element.Height < defaultHeight) {
                    element.Height += 2;
                    element.Location = new Point(
                        Screen.PrimaryScreen.Bounds.Width - element.Width - 8,
                        Screen.PrimaryScreen.Bounds.Height - element.Height - taskBarHeight
                    );
                    element.Refresh();
                } else {
                    timer.Stop();
                    timer.Dispose();
                    onAnimationComplete(element, new EventArgs());
                }
            };
            timer.Start();
        }

        public static void animateHide(Form element, int speed = 10) {
            element.Visible = true;
            int taskBarHeight = Screen.PrimaryScreen.Bounds.Bottom - Screen.PrimaryScreen.WorkingArea.Bottom;

            Timer timer = new Timer();
            timer.Interval = speed;
            timer.Tick += (sender, args) => {
                if(element.Height > 2) {
                    element.Height -= 2;
                    element.Location = new Point(
                        Screen.PrimaryScreen.Bounds.Width - element.Width - 8,
                        Screen.PrimaryScreen.Bounds.Height - element.Height - taskBarHeight
                    );
                    element.Refresh();
                } else {
                    timer.Stop();
                    timer.Dispose();
                    element.Height = 0;
                    element.Visible = false;
                    onAnimationComplete(element, new EventArgs());
                }
            };
            timer.Start();
        }

    }

}
