using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notify {

    public partial class FormNoticifationProgressBar : Form {

        public FormNoticifationProgressBar(string title, string text) {
            InitializeComponent();
            setLabelTitle(title);
            setLabelText(text);
        }

        // Setters

        public bool showProcentageAtTextLabel = false;

        public void setLabelTitle(string title) {
            this.labelTitle.Text = title;
        }

        public void setLabelText(string text) {
            this.labelText.Text = text;
        }

        public void setProgresBarAnimationSpeed(int speed) {
            timerProgressBar.Interval = speed;
        }

        // Progress bar

        public event EventHandler onProgressBarValueDrawingComplete = delegate { };
        private float progressBarCurrentValue = 0F;
        private float progressBarDrawnValue = 0F;

        public float progressBarProcentage {
            set {
                timerProgressBar.Enabled = true;
                if(value < 0) { progressBarCurrentValue = 0; return; }
                if(value > 100) { progressBarCurrentValue = 100; return; }
                progressBarCurrentValue = value;
            }
            get {
                return progressBarCurrentValue;
            }
        }

        private void FormNoticifationProgressBar_Paint(object sender, PaintEventArgs e) {
            //Outline
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(60, 60, 60), 2), this.DisplayRectangle);
            
            //ProgressBar
            //Background
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), new Rectangle(12, 38, 258, 18));
            //Foreground
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 224, 51)), new Rectangle(12, 38, (int)(((float)258 / 100) * progressBarDrawnValue), 18));
            //Outline
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(60, 60, 60), 1), new Rectangle(12, 38, 258, 18));
        }

        private void timerProgressBar_Tick(object sender, EventArgs e) {
            timerProgressBar.Enabled = progressBarCurrentValue != progressBarDrawnValue ? true : false;
            if(!timerProgressBar.Enabled) onProgressBarValueDrawingComplete(this, new EventArgs());

            if(progressBarCurrentValue > progressBarDrawnValue) {
                progressBarDrawnValue++;
            } else if(progressBarCurrentValue < progressBarDrawnValue) {
                progressBarDrawnValue--;
            }
            
            this.Refresh();
            if(showProcentageAtTextLabel) setLabelText(progressBarDrawnValue.ToString() + "%");
        }

    }
}
