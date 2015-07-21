using Notify.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notify {

    public partial class FormNotificationText : Form {

        public event EventHandler onClick = delegate { };

        public FormNotificationText(string title, string text) {
            InitializeComponent();
            setLabelTitle(title);
            setLabelText(text);
        }

        // Events

        private void FormNotification_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(60, 60, 60), 2), this.DisplayRectangle);
        }

        private void FormNotification_Load(object sender, EventArgs e) {
            labelText.Click += (obj, args) => {
                onClick(this, new EventArgs());
            };

            labelTitle.Click += (obj, args) => {
                onClick(this, new EventArgs());
            };

            this.Click += (obj, args) => {
                onClick(this, new EventArgs());
            };

            ElementAnimator.animateShow(this);
        }

        private void boxExit_Click(object sender, EventArgs e) {
            boxExit.Enabled = false;
            closeWithAnimation();
        }

        private void boxExit_MouseEnter(object sender, EventArgs e) {
            boxExit.BackgroundImage = (Image)Resources.buttonExitHighlight;
        }

        private void boxExit_MouseLeave(object sender, EventArgs e) {
            boxExit.BackgroundImage = (Image)Resources.buttonExit;
        }

        // Setters

        public void setLabelTitle(string title) {
            this.labelTitle.Text = title;
        }

        public void setLabelText(string text) {
            this.labelText.Text = text;
        }

        // Animation

        public void closeWithAnimation() {
            ElementAnimator.animateHide(this);
            ElementAnimator.onAnimationComplete += ElementAnimator_onAnimationComplete;
        }


        private void ElementAnimator_onAnimationComplete(object sender, EventArgs e) {
            if(sender != this) return;
            ElementAnimator.onAnimationComplete -= ElementAnimator_onAnimationComplete;
            this.Close();
        }

    }

}
