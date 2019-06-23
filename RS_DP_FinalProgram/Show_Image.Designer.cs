namespace RS_DP_FinalProgram
{
    partial class Show_Image
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enhanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equilibriumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearStretchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meanFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientInverseWeightedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpeningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.robortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prewittToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.laplacianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userDefinedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFileToolStripMenuItem,
            this.enhanceToolStripMenuItem,
            this.transformToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.sharpeningToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(857, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(70, 21);
            this.saveFileToolStripMenuItem.Text = "Save File";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // enhanceToolStripMenuItem
            // 
            this.enhanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.equilibriumToolStripMenuItem,
            this.stretchingToolStripMenuItem,
            this.linearStretchingToolStripMenuItem});
            this.enhanceToolStripMenuItem.Name = "enhanceToolStripMenuItem";
            this.enhanceToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.enhanceToolStripMenuItem.Text = "Enhance";
            // 
            // equilibriumToolStripMenuItem
            // 
            this.equilibriumToolStripMenuItem.Name = "equilibriumToolStripMenuItem";
            this.equilibriumToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.equilibriumToolStripMenuItem.Text = "Equilibrium";
            this.equilibriumToolStripMenuItem.Click += new System.EventHandler(this.equilibriumToolStripMenuItem_Click);
            // 
            // stretchingToolStripMenuItem
            // 
            this.stretchingToolStripMenuItem.Name = "stretchingToolStripMenuItem";
            this.stretchingToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.stretchingToolStripMenuItem.Text = "2% Stretching";
            this.stretchingToolStripMenuItem.Click += new System.EventHandler(this.stretchingToolStripMenuItem_Click);
            // 
            // linearStretchingToolStripMenuItem
            // 
            this.linearStretchingToolStripMenuItem.Name = "linearStretchingToolStripMenuItem";
            this.linearStretchingToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.linearStretchingToolStripMenuItem.Text = "Linear Stretching";
            this.linearStretchingToolStripMenuItem.Click += new System.EventHandler(this.linearStretchingToolStripMenuItem_Click);
            // 
            // transformToolStripMenuItem
            // 
            this.transformToolStripMenuItem.Name = "transformToolStripMenuItem";
            this.transformToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.transformToolStripMenuItem.Text = "Transform";
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meanFilterToolStripMenuItem,
            this.medianFilterToolStripMenuItem,
            this.gradientInverseWeightedToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(48, 21);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // meanFilterToolStripMenuItem
            // 
            this.meanFilterToolStripMenuItem.Name = "meanFilterToolStripMenuItem";
            this.meanFilterToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.meanFilterToolStripMenuItem.Text = "Mean Filter";
            this.meanFilterToolStripMenuItem.Click += new System.EventHandler(this.meanFilterToolStripMenuItem_Click);
            // 
            // medianFilterToolStripMenuItem
            // 
            this.medianFilterToolStripMenuItem.Name = "medianFilterToolStripMenuItem";
            this.medianFilterToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.medianFilterToolStripMenuItem.Text = "Median Filter";
            this.medianFilterToolStripMenuItem.Click += new System.EventHandler(this.medianFilterToolStripMenuItem_Click);
            // 
            // gradientInverseWeightedToolStripMenuItem
            // 
            this.gradientInverseWeightedToolStripMenuItem.Name = "gradientInverseWeightedToolStripMenuItem";
            this.gradientInverseWeightedToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.gradientInverseWeightedToolStripMenuItem.Text = "Gradient Inverse Weighted";
            this.gradientInverseWeightedToolStripMenuItem.Click += new System.EventHandler(this.gradientInverseWeightedToolStripMenuItem_Click);
            // 
            // sharpeningToolStripMenuItem
            // 
            this.sharpeningToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gradientToolStripMenuItem,
            this.robortToolStripMenuItem,
            this.prewittToolStripMenuItem,
            this.sobelToolStripMenuItem,
            this.laplacianToolStripMenuItem,
            this.userDefinedToolStripMenuItem});
            this.sharpeningToolStripMenuItem.Name = "sharpeningToolStripMenuItem";
            this.sharpeningToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
            this.sharpeningToolStripMenuItem.Text = "Sharpening";
            // 
            // gradientToolStripMenuItem
            // 
            this.gradientToolStripMenuItem.Name = "gradientToolStripMenuItem";
            this.gradientToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gradientToolStripMenuItem.Text = "Gradient";
            this.gradientToolStripMenuItem.Click += new System.EventHandler(this.gradientToolStripMenuItem_Click);
            // 
            // robortToolStripMenuItem
            // 
            this.robortToolStripMenuItem.Name = "robortToolStripMenuItem";
            this.robortToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.robortToolStripMenuItem.Text = "Robert";
            this.robortToolStripMenuItem.Click += new System.EventHandler(this.robortToolStripMenuItem_Click);
            // 
            // prewittToolStripMenuItem
            // 
            this.prewittToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.yToolStripMenuItem});
            this.prewittToolStripMenuItem.Name = "prewittToolStripMenuItem";
            this.prewittToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.prewittToolStripMenuItem.Text = "Prewitt";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(84, 22);
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(84, 22);
            this.yToolStripMenuItem.Text = "Y";
            this.yToolStripMenuItem.Click += new System.EventHandler(this.yToolStripMenuItem_Click);
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem1,
            this.yToolStripMenuItem1});
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sobelToolStripMenuItem.Text = "Sobel";
            // 
            // xToolStripMenuItem1
            // 
            this.xToolStripMenuItem1.Name = "xToolStripMenuItem1";
            this.xToolStripMenuItem1.Size = new System.Drawing.Size(84, 22);
            this.xToolStripMenuItem1.Text = "X";
            this.xToolStripMenuItem1.Click += new System.EventHandler(this.xToolStripMenuItem1_Click);
            // 
            // yToolStripMenuItem1
            // 
            this.yToolStripMenuItem1.Name = "yToolStripMenuItem1";
            this.yToolStripMenuItem1.Size = new System.Drawing.Size(84, 22);
            this.yToolStripMenuItem1.Text = "Y";
            this.yToolStripMenuItem1.Click += new System.EventHandler(this.yToolStripMenuItem1_Click);
            // 
            // laplacianToolStripMenuItem
            // 
            this.laplacianToolStripMenuItem.Name = "laplacianToolStripMenuItem";
            this.laplacianToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.laplacianToolStripMenuItem.Text = "Laplacian";
            this.laplacianToolStripMenuItem.Click += new System.EventHandler(this.laplacianToolStripMenuItem_Click);
            // 
            // userDefinedToolStripMenuItem
            // 
            this.userDefinedToolStripMenuItem.Name = "userDefinedToolStripMenuItem";
            this.userDefinedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.userDefinedToolStripMenuItem.Text = "User Defined";
            this.userDefinedToolStripMenuItem.Click += new System.EventHandler(this.userDefinedToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(554, 525);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Histogram";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(562, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(283, 256);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Band";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(710, 307);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(560, 373);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Statistical Feature";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(560, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mean";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(560, 447);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Variance";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(560, 495);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "Range";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(710, 398);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(710, 444);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(710, 492);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(735, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Show_Image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 556);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Show_Image";
            this.Text = "Image";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem enhanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equilibriumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stretchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearStretchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meanFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradientInverseWeightedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpeningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem robortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prewittToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplacianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem userDefinedToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}