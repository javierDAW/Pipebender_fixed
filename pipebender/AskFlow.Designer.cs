namespace pipebender
{
    partial class AskFlow
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
            this.pipeCancelBtn = new System.Windows.Forms.Button();
            this.pipeAcceptBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maxFlowNum = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.maxFlowNum)).BeginInit();
            this.SuspendLayout();
            // 
            // pipeCancelBtn
            // 
            this.pipeCancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.pipeCancelBtn.Location = new System.Drawing.Point(28, 124);
            this.pipeCancelBtn.Name = "pipeCancelBtn";
            this.pipeCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.pipeCancelBtn.TabIndex = 0;
            this.pipeCancelBtn.Text = "Cancel";
            this.pipeCancelBtn.UseVisualStyleBackColor = true;
            // 
            // pipeAcceptBtn
            // 
            this.pipeAcceptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.pipeAcceptBtn.Location = new System.Drawing.Point(139, 124);
            this.pipeAcceptBtn.Name = "pipeAcceptBtn";
            this.pipeAcceptBtn.Size = new System.Drawing.Size(75, 23);
            this.pipeAcceptBtn.TabIndex = 1;
            this.pipeAcceptBtn.Text = "Accept";
            this.pipeAcceptBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max Flow";
            // 
            // maxFlowNum
            // 
            this.maxFlowNum.Location = new System.Drawing.Point(28, 56);
            this.maxFlowNum.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.maxFlowNum.Name = "maxFlowNum";
            this.maxFlowNum.Size = new System.Drawing.Size(120, 20);
            this.maxFlowNum.TabIndex = 3;
            // 
            // AskFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 159);
            this.Controls.Add(this.maxFlowNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pipeAcceptBtn);
            this.Controls.Add(this.pipeCancelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AskFlow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PipeFlow";
            ((System.ComponentModel.ISupportInitialize)(this.maxFlowNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pipeCancelBtn;
        private System.Windows.Forms.Button pipeAcceptBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown maxFlowNum;
    }
}