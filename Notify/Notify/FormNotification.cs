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

    public partial class FormNotification : Form {

        public event EventHandler onClick = delegate { };

        public FormNotification(string name, string text) {
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

            ElementAnimator.doShowAnimation(this);
        }

        public void setLabelName(string name) {
            this.labelName.Text = name;
        }

        public void setLabelText(string text) {
            this.labelText.Text = text;
        }

        private void boxExit_Click(object sender, EventArgs e) {
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
