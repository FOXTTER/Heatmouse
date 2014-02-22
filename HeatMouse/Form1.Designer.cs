namespace HeatMouse
{
    partial class Form1
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
            this.mouseKeyEventProvider1 = new MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider();
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.draw = new System.Windows.Forms.Button();
            this.imageDrawer = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.reset = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.rad = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.offset = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.debug = new System.Windows.Forms.Button();
            this.debugValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debugValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // mouseKeyEventProvider1
            // 
            this.mouseKeyEventProvider1.Enabled = false;
            this.mouseKeyEventProvider1.HookType = MouseKeyboardActivityMonitor.Controls.HookType.Global;
            this.mouseKeyEventProvider1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseKeyEventProvider1_MouseClick);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(25, 36);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(112, 42);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(25, 84);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(112, 33);
            this.Stop.TabIndex = 1;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(286, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(702, 447);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // draw
            // 
            this.draw.Location = new System.Drawing.Point(25, 152);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(232, 110);
            this.draw.TabIndex = 3;
            this.draw.Text = "Draw";
            this.draw.UseVisualStyleBackColor = true;
            this.draw.Click += new System.EventHandler(this.draw_Click);
            // 
            // imageDrawer
            // 
            this.imageDrawer.WorkerReportsProgress = true;
            this.imageDrawer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.imageDrawer_DoWork);
            this.imageDrawer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.imageDrawer_ProgressChanged);
            this.imageDrawer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.imageDrawer_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(13, 489);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(975, 45);
            this.progressBar1.TabIndex = 4;
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(25, 123);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(112, 23);
            this.reset.TabIndex = 5;
            this.reset.Text = "Reset Data";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(25, 320);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(232, 31);
            this.save.TabIndex = 8;
            this.save.Text = "Save heatmap";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // rad
            // 
            this.rad.Location = new System.Drawing.Point(25, 292);
            this.rad.Name = "rad";
            this.rad.Size = new System.Drawing.Size(89, 22);
            this.rad.TabIndex = 10;
            this.rad.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Radius";
            // 
            // offset
            // 
            this.offset.Location = new System.Drawing.Point(120, 292);
            this.offset.Name = "offset";
            this.offset.Size = new System.Drawing.Size(137, 22);
            this.offset.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Color (Higher = redder)";
            // 
            // debug
            // 
            this.debug.Enabled = false;
            this.debug.Location = new System.Drawing.Point(169, 36);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(88, 81);
            this.debug.TabIndex = 13;
            this.debug.Text = "test data";
            this.debug.UseVisualStyleBackColor = true;
            this.debug.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // debugValue
            // 
            this.debugValue.Enabled = false;
            this.debugValue.Location = new System.Drawing.Point(169, 123);
            this.debugValue.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.debugValue.Name = "debugValue";
            this.debugValue.Size = new System.Drawing.Size(88, 22);
            this.debugValue.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Status: Tracker kører ikke";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(13, 453);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(244, 30);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(169, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 21);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Debug";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 546);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.debugValue);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.offset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.save);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.draw);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debugValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider mouseKeyEventProvider1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button draw;
        private System.ComponentModel.BackgroundWorker imageDrawer;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.NumericUpDown rad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown offset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button debug;
        private System.Windows.Forms.NumericUpDown debugValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

