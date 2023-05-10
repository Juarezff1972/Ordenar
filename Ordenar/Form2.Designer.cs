namespace Ordenar
{
    partial class Form2
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
            algoTxt = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // algoTxt
            // 
            algoTxt.AcceptsReturn = true;
            algoTxt.AcceptsTab = true;
            algoTxt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            algoTxt.Location = new System.Drawing.Point(13, 13);
            algoTxt.Multiline = true;
            algoTxt.Name = "algoTxt";
            algoTxt.ReadOnly = true;
            algoTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            algoTxt.Size = new System.Drawing.Size(426, 355);
            algoTxt.TabIndex = 43;
            algoTxt.WordWrap = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Gray;
            ClientSize = new System.Drawing.Size(451, 380);
            Controls.Add(algoTxt);
            Name = "Form2";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Algoritmo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox algoTxt;
    }
}