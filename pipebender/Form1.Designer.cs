namespace pipebender
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuImages = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.buttonPipe = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.mapBox = new System.Windows.Forms.PictureBox();
            this.regSplitterBtn = new System.Windows.Forms.Button();
            this.normalSplitterBtn = new System.Windows.Forms.Button();
            this.mergerBtn = new System.Windows.Forms.Button();
            this.sinkBtn = new System.Windows.Forms.Button();
            this.pumpBtn = new System.Windows.Forms.Button();
            this.buttonClean = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuImages
            // 
            this.menuImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("menuImages.ImageStream")));
            this.menuImages.TransparentColor = System.Drawing.Color.Transparent;
            this.menuImages.Images.SetKeyName(0, "Pump.png");
            this.menuImages.Images.SetKeyName(1, "Sink.png");
            this.menuImages.Images.SetKeyName(2, "NormalSplitter.png");
            this.menuImages.Images.SetKeyName(3, "RegulableSplitter.png");
            this.menuImages.Images.SetKeyName(4, "Merger.png");
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = " (*.txt)|";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpen.Location = new System.Drawing.Point(787, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 9;
            this.buttonOpen.Text = "Open ";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveAs.Location = new System.Drawing.Point(868, 12);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAs.TabIndex = 10;
            this.buttonSaveAs.Text = "Save As";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // buttonPipe
            // 
            this.buttonPipe.BackgroundImage = global::pipebender.Properties.Resources.pipe;
            this.buttonPipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonPipe.Location = new System.Drawing.Point(339, 12);
            this.buttonPipe.Name = "buttonPipe";
            this.buttonPipe.Size = new System.Drawing.Size(60, 57);
            this.buttonPipe.TabIndex = 8;
            this.buttonPipe.UseVisualStyleBackColor = true;
            this.buttonPipe.Click += new System.EventHandler(this.buttonPipe_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.BackgroundImage = global::pipebender.Properties.Resources.remove;
            this.buttonRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonRemove.Location = new System.Drawing.Point(405, 12);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(61, 57);
            this.buttonRemove.TabIndex = 7;
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.removeBtn);
            // 
            // mapBox
            // 
            this.mapBox.Location = new System.Drawing.Point(12, 75);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(931, 496);
            this.mapBox.TabIndex = 5;
            this.mapBox.TabStop = false;
            this.mapBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mapBox_Paint);
            this.mapBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseClick);
            // 
            // regSplitterBtn
            // 
            this.regSplitterBtn.BackgroundImage = global::pipebender.Properties.Resources.RegulableSplitter;
            this.regSplitterBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.regSplitterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regSplitterBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.regSplitterBtn.Location = new System.Drawing.Point(207, 12);
            this.regSplitterBtn.Name = "regSplitterBtn";
            this.regSplitterBtn.Size = new System.Drawing.Size(62, 57);
            this.regSplitterBtn.TabIndex = 4;
            this.regSplitterBtn.UseVisualStyleBackColor = true;
            this.regSplitterBtn.Click += new System.EventHandler(this.regSplitterBtn_Click);
            // 
            // normalSplitterBtn
            // 
            this.normalSplitterBtn.BackgroundImage = global::pipebender.Properties.Resources.NormalSplitter;
            this.normalSplitterBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.normalSplitterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.normalSplitterBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.normalSplitterBtn.Location = new System.Drawing.Point(78, 12);
            this.normalSplitterBtn.Name = "normalSplitterBtn";
            this.normalSplitterBtn.Size = new System.Drawing.Size(58, 57);
            this.normalSplitterBtn.TabIndex = 3;
            this.normalSplitterBtn.UseVisualStyleBackColor = true;
            this.normalSplitterBtn.Click += new System.EventHandler(this.normalSplitterBtn_Click);
            // 
            // mergerBtn
            // 
            this.mergerBtn.BackgroundImage = global::pipebender.Properties.Resources.Merger;
            this.mergerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mergerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mergerBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.mergerBtn.Location = new System.Drawing.Point(142, 12);
            this.mergerBtn.Name = "mergerBtn";
            this.mergerBtn.Size = new System.Drawing.Size(59, 57);
            this.mergerBtn.TabIndex = 2;
            this.mergerBtn.UseVisualStyleBackColor = true;
            this.mergerBtn.Click += new System.EventHandler(this.mergerBtn_Click);
            // 
            // sinkBtn
            // 
            this.sinkBtn.BackgroundImage = global::pipebender.Properties.Resources.Sink;
            this.sinkBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.sinkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sinkBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.sinkBtn.Location = new System.Drawing.Point(275, 12);
            this.sinkBtn.Name = "sinkBtn";
            this.sinkBtn.Size = new System.Drawing.Size(59, 57);
            this.sinkBtn.TabIndex = 1;
            this.sinkBtn.UseVisualStyleBackColor = true;
            this.sinkBtn.Click += new System.EventHandler(this.sinkBtn_Click);
            // 
            // pumpBtn
            // 
            this.pumpBtn.BackgroundImage = global::pipebender.Properties.Resources.Pump;
            this.pumpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pumpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pumpBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.pumpBtn.Location = new System.Drawing.Point(13, 12);
            this.pumpBtn.Name = "pumpBtn";
            this.pumpBtn.Size = new System.Drawing.Size(58, 57);
            this.pumpBtn.TabIndex = 0;
            this.pumpBtn.UseVisualStyleBackColor = true;
            this.pumpBtn.Click += new System.EventHandler(this.pumpBtn_Click);
            // 
            // buttonClean
            // 
            this.buttonClean.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClean.Location = new System.Drawing.Point(787, 46);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(75, 23);
            this.buttonClean.TabIndex = 11;
            this.buttonClean.Text = "Clean";
            this.buttonClean.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(868, 46);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 583);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClean);
            this.Controls.Add(this.buttonSaveAs);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonPipe);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.mapBox);
            this.Controls.Add(this.regSplitterBtn);
            this.Controls.Add(this.normalSplitterBtn);
            this.Controls.Add(this.mergerBtn);
            this.Controls.Add(this.sinkBtn);
            this.Controls.Add(this.pumpBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pipebender";
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pumpBtn;
        private System.Windows.Forms.Button sinkBtn;
        private System.Windows.Forms.Button mergerBtn;
        private System.Windows.Forms.Button normalSplitterBtn;
        private System.Windows.Forms.Button regSplitterBtn;
        private System.Windows.Forms.ImageList menuImages;
        private System.Windows.Forms.PictureBox mapBox;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonPipe;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Button buttonClean;
        private System.Windows.Forms.Button buttonSave;
    }
}

