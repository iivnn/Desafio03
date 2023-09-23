namespace Parte1
{
    partial class MainForm
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
            decomporButton = new Button();
            valorTextBox = new TextBox();
            divisoresLabel = new Label();
            decomporGroupBox = new GroupBox();
            divisoresPrimoLabel = new Label();
            executarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            divisoresRichTextBox = new RichTextBox();
            divisoresPrimosRichTextBox = new RichTextBox();
            decomporGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // decomporButton
            // 
            decomporButton.Location = new Point(290, 22);
            decomporButton.Name = "decomporButton";
            decomporButton.Size = new Size(75, 23);
            decomporButton.TabIndex = 0;
            decomporButton.Text = "Executar";
            decomporButton.UseVisualStyleBackColor = true;
            decomporButton.Click += decomporButton_Click;
            // 
            // valorTextBox
            // 
            valorTextBox.Location = new Point(6, 22);
            valorTextBox.Name = "valorTextBox";
            valorTextBox.Size = new Size(278, 23);
            valorTextBox.TabIndex = 1;
            valorTextBox.KeyPress += valorTextBox_KeyPress;
            // 
            // divisoresLabel
            // 
            divisoresLabel.AutoSize = true;
            divisoresLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            divisoresLabel.Location = new Point(6, 61);
            divisoresLabel.Name = "divisoresLabel";
            divisoresLabel.Size = new Size(61, 15);
            divisoresLabel.TabIndex = 2;
            divisoresLabel.Text = "Divisores:";
            // 
            // decomporGroupBox
            // 
            decomporGroupBox.Controls.Add(divisoresPrimosRichTextBox);
            decomporGroupBox.Controls.Add(divisoresRichTextBox);
            decomporGroupBox.Controls.Add(divisoresPrimoLabel);
            decomporGroupBox.Controls.Add(valorTextBox);
            decomporGroupBox.Controls.Add(divisoresLabel);
            decomporGroupBox.Controls.Add(decomporButton);
            decomporGroupBox.Location = new Point(12, 12);
            decomporGroupBox.Name = "decomporGroupBox";
            decomporGroupBox.Size = new Size(850, 197);
            decomporGroupBox.TabIndex = 3;
            decomporGroupBox.TabStop = false;
            decomporGroupBox.Text = "Decompondo";
            // 
            // divisoresPrimoLabel
            // 
            divisoresPrimoLabel.AutoSize = true;
            divisoresPrimoLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            divisoresPrimoLabel.Location = new Point(8, 119);
            divisoresPrimoLabel.Name = "divisoresPrimoLabel";
            divisoresPrimoLabel.Size = new Size(102, 15);
            divisoresPrimoLabel.TabIndex = 3;
            divisoresPrimoLabel.Text = "Divisores Primos:";
            // 
            // executarBackgroundWorker
            // 
            executarBackgroundWorker.DoWork += executarBackgroundWorker_DoWork;
            executarBackgroundWorker.RunWorkerCompleted += executarBackgroundWorker_RunWorkerCompleted;
            // 
            // divisoresRichTextBox
            // 
            divisoresRichTextBox.Location = new Point(8, 79);
            divisoresRichTextBox.Name = "divisoresRichTextBox";
            divisoresRichTextBox.Size = new Size(836, 37);
            divisoresRichTextBox.TabIndex = 6;
            divisoresRichTextBox.Text = "";
            // 
            // divisoresPrimosRichTextBox
            // 
            divisoresPrimosRichTextBox.Location = new Point(8, 137);
            divisoresPrimosRichTextBox.Name = "divisoresPrimosRichTextBox";
            divisoresPrimosRichTextBox.Size = new Size(836, 37);
            divisoresPrimosRichTextBox.TabIndex = 7;
            divisoresPrimosRichTextBox.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 227);
            Controls.Add(decomporGroupBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "Parte 1";
            decomporGroupBox.ResumeLayout(false);
            decomporGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button decomporButton;
        private TextBox valorTextBox;
        private Label divisoresLabel;
        private GroupBox decomporGroupBox;
        private Label divisoresPrimoLabel;
        private System.ComponentModel.BackgroundWorker executarBackgroundWorker;
        private RichTextBox divisoresPrimosRichTextBox;
        private RichTextBox divisoresRichTextBox;
    }
}