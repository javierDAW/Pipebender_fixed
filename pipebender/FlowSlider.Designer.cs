namespace pipebender
{
    partial class FlowSlider
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sliderAcceptBtn = new System.Windows.Forms.Button();
            this.sliderCancelBtn = new System.Windows.Forms.Button();
            this.flowTrack = new System.Windows.Forms.TrackBar();
            this.flowLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.flowTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // sliderAcceptBtn
            // 
            this.sliderAcceptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sliderAcceptBtn.Location = new System.Drawing.Point(141, 124);
            this.sliderAcceptBtn.Name = "sliderAcceptBtn";
            this.sliderAcceptBtn.Size = new System.Drawing.Size(75, 23);
            this.sliderAcceptBtn.TabIndex = 3;
            this.sliderAcceptBtn.Text = "Accept";
            this.sliderAcceptBtn.UseVisualStyleBackColor = true;
            // 
            // sliderCancelBtn
            // 
            this.sliderCancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sliderCancelBtn.Location = new System.Drawing.Point(30, 124);
            this.sliderCancelBtn.Name = "sliderCancelBtn";
            this.sliderCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.sliderCancelBtn.TabIndex = 2;
            this.sliderCancelBtn.Text = "Cancel";
            this.sliderCancelBtn.UseVisualStyleBackColor = true;
            // 
            // flowTrack
            // 
            this.flowTrack.Location = new System.Drawing.Point(30, 57);
            this.flowTrack.Maximum = 100;
            this.flowTrack.Name = "flowTrack";
            this.flowTrack.Size = new System.Drawing.Size(186, 45);
            this.flowTrack.TabIndex = 4;
            this.flowTrack.ValueChanged += new System.EventHandler(this.ChangeFlowLabel);
            // 
            // flowLabel
            // 
            this.flowLabel.AutoSize = true;
            this.flowLabel.Location = new System.Drawing.Point(114, 41);
            this.flowLabel.Name = "flowLabel";
            this.flowLabel.Size = new System.Drawing.Size(40, 13);
            this.flowLabel.TabIndex = 5;
            this.flowLabel.Text = "Flow %";
            // 
            // FlowSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 159);
            this.Controls.Add(this.flowLabel);
            this.Controls.Add(this.flowTrack);
            this.Controls.Add(this.sliderAcceptBtn);
            this.Controls.Add(this.sliderCancelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FlowSlider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FlowSlider";
            ((System.ComponentModel.ISupportInitialize)(this.flowTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sliderAcceptBtn;
        private System.Windows.Forms.Button sliderCancelBtn;
        private System.Windows.Forms.TrackBar flowTrack;
        private System.Windows.Forms.Label flowLabel;
    }
}