namespace Challenge02
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
            lbResult = new ListBox();
            rtbSQLCode = new RichTextBox();
            btnRPL = new Button();
            lbConnect = new Label();
            SuspendLayout();
            // 
            // lbResult
            // 
            lbResult.FormattingEnabled = true;
            lbResult.Location = new Point(172, 214);
            lbResult.Name = "lbResult";
            lbResult.Size = new Size(616, 224);
            lbResult.TabIndex = 0;
            // 
            // rtbSQLCode
            // 
            rtbSQLCode.Location = new Point(172, 39);
            rtbSQLCode.Name = "rtbSQLCode";
            rtbSQLCode.Size = new Size(601, 157);
            rtbSQLCode.TabIndex = 1;
            rtbSQLCode.Text = "";
            // 
            // btnRPL
            // 
            btnRPL.Location = new Point(35, 38);
            btnRPL.Name = "btnRPL";
            btnRPL.Size = new Size(94, 29);
            btnRPL.TabIndex = 2;
            btnRPL.Text = "REPL";
            btnRPL.UseVisualStyleBackColor = true;
            btnRPL.Click += btnRPL_Click;
            // 
            // lbConnect
            // 
            lbConnect.AutoSize = true;
            lbConnect.Location = new Point(35, 94);
            lbConnect.Name = "lbConnect";
            lbConnect.Size = new Size(113, 20);
            lbConnect.TabIndex = 3;
            lbConnect.Text = "(no connection)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbConnect);
            Controls.Add(btnRPL);
            Controls.Add(rtbSQLCode);
            Controls.Add(lbResult);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbResult;
        private RichTextBox rtbSQLCode;
        private Button btnRPL;
        private Label lbConnect;
    }
}
