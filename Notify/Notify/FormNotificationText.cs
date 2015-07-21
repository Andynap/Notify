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

        public FormNotificationText(string name, string text) {
            InitializeComponent();
            setLabelName(name);
            setLabelText(text);
        }

        private void FormNotification_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(60, 60, 60), 2), this.DisplayRectangle);           
        }

        private void FormNotification_Load(object sender, EventArgs e) {
            labelText.Click += (obj, args) => {
                onClick(this, new EventArgs());
            };

            labelName.Click += (obj, args) => {
                onClick(this, new EventArgs());
            };

            this.Click += (obj, args) => {
                onClick(this, new EventArgs());
            };

            ElementAnimator.animateShow(this);
        }

        public void setLabelName(string name) {
            this.labelName.Text = name;
        }

        public void setLabelText(string text) {
            this.labelText.Text = text;
        }

        public void closeWithAnimation() {
            ElementAnimator.animateHide(this);
            ElementAnimator.onAnimationComplete += ElementAnimator_onAnimationComplete;
        }

        private void boxExit_Click(object sender, EventArgs e) {
            boxExit.Enabled = false;
            closeWithAnimation();
        }

        private void ElementAnimator_onAnimationComplete(object sender, EventArgs e) {
            if(sender != this) return;
            ElementAnimator.onAnimationComplete -= ElementAnimator_onAnimationComplete;
            this.Close();
        }

        private void boxExit_MouseEnter(object sender, EventArgs e) {
            boxExit.BackgroundImage = (Image)Resources.buttonExitHighlight;
        }

        private void boxExit_MouseLeave(object sender, EventArgs e) {
            boxExit.BackgroundImage = (Image)Resources.buttonExit;
        }

    }

}
