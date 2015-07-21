namespace Notify {
    partial class FormNotification {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.labelName = new System.Windows.Forms.Label();
            this.labelText = new System.Windows.Forms.Label();
            this.boxExit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.boxExit)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelName.Location = new System.Drawing.Point(12, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(236, 25);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "name";
            // 
            // labelText
            // 
            this.labelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelText.Location = new System.Drawing.Point(12, 34);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(258, 37);
            this.labelText.TabIndex = 1;
            this.labelText.Text = "text";
            // 
            // boxExit
            // 
            this.boxExit.BackgroundImage = global::Notify.Properties.Resources.buttonExit;
            this.boxExit.Location = new System.Drawing.Point(254, 9);
            this.boxExit.Name = "boxExit";
            this.boxExit.Size = new System.Drawing.Size(16, 16);
            this.boxExit.TabIndex = 2;
            this.boxExit.TabStop = false;
            this.boxExit.Click += new System.EventHandler(this.boxExit_Click);
            this.boxExit.MouseEnter += new System.EventHandler(this.boxExit_MouseEnter);
            this.boxExit.MouseLeave += new System.EventHandler(this.boxExit_MouseLeave);
            // 
            // FormNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(282, 80);
            this.ControlBox = false;
            this.Controls.Add(this.boxExit);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.labelName);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNotification";
            this.Load += new System.EventHandler(this.FormNotification_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormNotification_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.boxExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.PictureBox boxExit;
    }
}