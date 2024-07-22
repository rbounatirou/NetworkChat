namespace ClientWinform
{
    partial class FormChat
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
            buttonEnvoi = new Button();
            textBoxMessage = new TextBox();
            listBoxMessage = new ListBox();
            SuspendLayout();
            // 
            // buttonEnvoi
            // 
            buttonEnvoi.Location = new Point(1032, 551);
            buttonEnvoi.Name = "buttonEnvoi";
            buttonEnvoi.Size = new Size(145, 91);
            buttonEnvoi.TabIndex = 0;
            buttonEnvoi.Text = "SEND";
            buttonEnvoi.UseVisualStyleBackColor = true;
            buttonEnvoi.Click += buttonEnvoi_Click;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(56, 551);
            textBoxMessage.Multiline = true;
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(952, 91);
            textBoxMessage.TabIndex = 1;
            // 
            // listBoxMessage
            // 
            listBoxMessage.FormattingEnabled = true;
            listBoxMessage.ItemHeight = 25;
            listBoxMessage.Location = new Point(56, 27);
            listBoxMessage.Name = "listBoxMessage";
            listBoxMessage.Size = new Size(1121, 504);
            listBoxMessage.TabIndex = 2;
            // 
            // FormChat
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 664);
            Controls.Add(listBoxMessage);
            Controls.Add(textBoxMessage);
            Controls.Add(buttonEnvoi);
            Name = "FormChat";
            Text = "ChatSimple";
            FormClosed += FormChat_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonEnvoi;
        private TextBox textBoxMessage;
        private ListBox listBoxMessage;
    }
}
