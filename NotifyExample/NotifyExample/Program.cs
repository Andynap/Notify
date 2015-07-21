using Notify;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NotifyExample {

    static class Program {

        private static Random rand = new Random();
        private static List<int> loadingPhrasesShowed = new List<int>();
        private static string[] loadingPhrases = new string[] {
            "Searching for marbles",
            "Tightening loose screws",
            "Engaging warp drive",
            "Paying parking tickets",
            "Pixelating the pixels",
            "Locating hamsters",
            "Engaging holographics",
            "Igniting rocket boosters",
            "Lassoing unicorns",
            "Polishing the servers",
            "Deflecting solar flares",
            "Checking the cable",
            "Adjusting data for your IQ",
            "Generating next funny line",
            "Dividing eternity by zero",
            "Searching for the Any key"
        };

        private static string getRandomPhrase() {
            int index;
            do {
                index = rand.Next(0, loadingPhrases.Length - 1);
            } while(loadingPhrasesShowed.Contains(index));
            loadingPhrasesShowed.Add(index);
            return loadingPhrases[index];
        }

        [STAThread]
        static void Main() {
            FormNoticifationProgressBar notifyBar;

            FormNotificationText notifyText = new FormNotificationText(
                Environment.MachineName,
                "Kliknutím zahajte výbuch tohoto zařízení."
            );

            notifyText.onClick += (sender, args) => {
                notifyBar = new FormNoticifationProgressBar("Loading ...", "0%");
                notifyBar.showProcentageAtTextLabel = true;
                notifyBar.Show();
                notifyBar.Location = notifyText.Location;
                notifyText.Hide();

                notifyBar.onProgressBarValueDrawingComplete += (obj, e) => {
                    if(notifyBar.progressBarProcentage >= 100) {
                        notifyBar.setLabelTitle("Fail!");
                        ElementAnimator.animateHide(notifyBar);
                        ElementAnimator.onAnimationComplete += (o, a) => {
                            if(o != notifyBar) return;
                            notifyBar.Close();
                            notifyText.Close();
                        };
                        return;
                    }
                    notifyBar.setLabelTitle(getRandomPhrase());
                    notifyBar.setProgresBarAnimationSpeed(rand.Next(80, 150));
                    notifyBar.progressBarProcentage += rand.Next(5, 15);
                };
                notifyBar.progressBarProcentage = 1;
                
            };

            Application.EnableVisualStyles();
            Application.Run(notifyText);

        }

    }

}
