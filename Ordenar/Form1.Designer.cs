namespace Ordenar
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            comboBox1 = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            qsPivotSel1 = new System.Windows.Forms.ComboBox();
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            label9 = new System.Windows.Forms.Label();
            pivot1 = new System.Windows.Forms.TrackBar();
            pivot2 = new System.Windows.Forms.TrackBar();
            label10 = new System.Windows.Forms.Label();
            tipoVisual = new System.Windows.Forms.ComboBox();
            area1 = new System.Windows.Forms.PictureBox();
            tipoVisual2 = new System.Windows.Forms.ComboBox();
            ordemInicial = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            AuxVetor1 = new System.Windows.Forms.PictureBox();
            label11 = new System.Windows.Forms.Label();
            button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pivot1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pivot2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)area1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AuxVetor1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            resources.ApplyResources(comboBox1, "comboBox1");
            comboBox1.BackColor = System.Drawing.Color.DarkGray;
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { resources.GetString("comboBox1.Items"), resources.GetString("comboBox1.Items1"), resources.GetString("comboBox1.Items2"), resources.GetString("comboBox1.Items3"), resources.GetString("comboBox1.Items4"), resources.GetString("comboBox1.Items5"), resources.GetString("comboBox1.Items6"), resources.GetString("comboBox1.Items7"), resources.GetString("comboBox1.Items8"), resources.GetString("comboBox1.Items9"), resources.GetString("comboBox1.Items10"), resources.GetString("comboBox1.Items11"), resources.GetString("comboBox1.Items12"), resources.GetString("comboBox1.Items13"), resources.GetString("comboBox1.Items14"), resources.GetString("comboBox1.Items15"), resources.GetString("comboBox1.Items16"), resources.GetString("comboBox1.Items17"), resources.GetString("comboBox1.Items18"), resources.GetString("comboBox1.Items19"), resources.GetString("comboBox1.Items20"), resources.GetString("comboBox1.Items21"), resources.GetString("comboBox1.Items22"), resources.GetString("comboBox1.Items23"), resources.GetString("comboBox1.Items24"), resources.GetString("comboBox1.Items25"), resources.GetString("comboBox1.Items26"), resources.GetString("comboBox1.Items27") });
            comboBox1.Name = "comboBox1";
            comboBox1.Sorted = true;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // qsPivotSel1
            // 
            resources.ApplyResources(qsPivotSel1, "qsPivotSel1");
            qsPivotSel1.BackColor = System.Drawing.Color.DarkGray;
            qsPivotSel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            qsPivotSel1.FormattingEnabled = true;
            qsPivotSel1.Items.AddRange(new object[] { resources.GetString("qsPivotSel1.Items"), resources.GetString("qsPivotSel1.Items1"), resources.GetString("qsPivotSel1.Items2"), resources.GetString("qsPivotSel1.Items3"), resources.GetString("qsPivotSel1.Items4") });
            qsPivotSel1.Name = "qsPivotSel1";
            qsPivotSel1.SelectedIndexChanged += qsPivotSel1_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(numericUpDown1, "numericUpDown1");
            numericUpDown1.BackColor = System.Drawing.Color.DarkGray;
            numericUpDown1.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Value = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            // 
            // numericUpDown2
            // 
            resources.ApplyResources(numericUpDown2, "numericUpDown2");
            numericUpDown2.BackColor = System.Drawing.Color.DarkGray;
            numericUpDown2.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // progressBar1
            // 
            resources.ApplyResources(progressBar1, "progressBar1");
            progressBar1.Name = "progressBar1";
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            // 
            // pivot1
            // 
            resources.ApplyResources(pivot1, "pivot1");
            pivot1.CausesValidation = false;
            pivot1.LargeChange = 1;
            pivot1.Minimum = 1;
            pivot1.Name = "pivot1";
            pivot1.TabStop = false;
            pivot1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            pivot1.Value = 1;
            // 
            // pivot2
            // 
            resources.ApplyResources(pivot2, "pivot2");
            pivot2.CausesValidation = false;
            pivot2.LargeChange = 1;
            pivot2.Minimum = 1;
            pivot2.Name = "pivot2";
            pivot2.TabStop = false;
            pivot2.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            pivot2.Value = 1;
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            // 
            // tipoVisual
            // 
            resources.ApplyResources(tipoVisual, "tipoVisual");
            tipoVisual.CausesValidation = false;
            tipoVisual.FormattingEnabled = true;
            tipoVisual.Items.AddRange(new object[] { resources.GetString("tipoVisual.Items"), resources.GetString("tipoVisual.Items1"), resources.GetString("tipoVisual.Items2"), resources.GetString("tipoVisual.Items3"), resources.GetString("tipoVisual.Items4") });
            tipoVisual.Name = "tipoVisual";
            // 
            // area1
            // 
            resources.ApplyResources(area1, "area1");
            area1.BackColor = System.Drawing.Color.Black;
            area1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            area1.Name = "area1";
            area1.TabStop = false;
            area1.Paint += area1_Paint;
            // 
            // tipoVisual2
            // 
            resources.ApplyResources(tipoVisual2, "tipoVisual2");
            tipoVisual2.FormattingEnabled = true;
            tipoVisual2.Items.AddRange(new object[] { resources.GetString("tipoVisual2.Items"), resources.GetString("tipoVisual2.Items1"), resources.GetString("tipoVisual2.Items2") });
            tipoVisual2.Name = "tipoVisual2";
            // 
            // ordemInicial
            // 
            resources.ApplyResources(ordemInicial, "ordemInicial");
            ordemInicial.FormattingEnabled = true;
            ordemInicial.Items.AddRange(new object[] { resources.GetString("ordemInicial.Items"), resources.GetString("ordemInicial.Items1"), resources.GetString("ordemInicial.Items2"), resources.GetString("ordemInicial.Items3"), resources.GetString("ordemInicial.Items4"), resources.GetString("ordemInicial.Items5") });
            ordemInicial.Name = "ordemInicial";
            ordemInicial.SelectedIndexChanged += ordemInicial_SelectedIndexChanged;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // AuxVetor1
            // 
            resources.ApplyResources(AuxVetor1, "AuxVetor1");
            AuxVetor1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            AuxVetor1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            AuxVetor1.Name = "AuxVetor1";
            AuxVetor1.TabStop = false;
            AuxVetor1.Paint += AuxVetor1_Paint;
            AuxVetor1.Resize += AuxVetor1_Resize;
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // button3
            // 
            resources.ApplyResources(button3, "button3");
            button3.Name = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Gray;
            Controls.Add(button3);
            Controls.Add(label11);
            Controls.Add(AuxVetor1);
            Controls.Add(label7);
            Controls.Add(ordemInicial);
            Controls.Add(tipoVisual2);
            Controls.Add(area1);
            Controls.Add(tipoVisual);
            Controls.Add(label10);
            Controls.Add(pivot2);
            Controls.Add(pivot1);
            Controls.Add(label9);
            Controls.Add(progressBar1);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numericUpDown2);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(qsPivotSel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            DoubleBuffered = true;
            Name = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            Resize += Form1_ResizeEnd;
            StyleChanged += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pivot1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pivot2).EndInit();
            ((System.ComponentModel.ISupportInitialize)area1).EndInit();
            ((System.ComponentModel.ISupportInitialize)AuxVetor1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox qsPivotSel1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar pivot1;
        private System.Windows.Forms.TrackBar pivot2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox tipoVisual;
        private System.Windows.Forms.PictureBox area1;
        private System.Windows.Forms.ComboBox tipoVisual2;
        private System.Windows.Forms.ComboBox ordemInicial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox AuxVetor1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button3;
    }
}

