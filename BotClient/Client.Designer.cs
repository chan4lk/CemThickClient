namespace BotClient
{
    partial class Client
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
            this.chatHistoryText = new System.Windows.Forms.TextBox();
            this.metaText = new System.Windows.Forms.TextBox();
            this.sendText = new System.Windows.Forms.TextBox();
            this.listenButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chatHistoryText
            // 
            this.chatHistoryText.Location = new System.Drawing.Point(12, 12);
            this.chatHistoryText.Multiline = true;
            this.chatHistoryText.Name = "chatHistoryText";
            this.chatHistoryText.Size = new System.Drawing.Size(533, 337);
            this.chatHistoryText.TabIndex = 0;
            // 
            // metaText
            // 
            this.metaText.Location = new System.Drawing.Point(578, 12);
            this.metaText.Multiline = true;
            this.metaText.Name = "metaText";
            this.metaText.Size = new System.Drawing.Size(242, 337);
            this.metaText.TabIndex = 1;
            // 
            // sendText
            // 
            this.sendText.Location = new System.Drawing.Point(13, 398);
            this.sendText.Name = "sendText";
            this.sendText.Size = new System.Drawing.Size(532, 20);
            this.sendText.TabIndex = 2;
            // 
            // listenButton
            // 
            this.listenButton.Location = new System.Drawing.Point(578, 398);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(75, 23);
            this.listenButton.TabIndex = 3;
            this.listenButton.Text = "Listen";
            this.listenButton.UseVisualStyleBackColor = true;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(672, 379);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(139, 62);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 453);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.listenButton);
            this.Controls.Add(this.sendText);
            this.Controls.Add(this.metaText);
            this.Controls.Add(this.chatHistoryText);
            this.Name = "Client";
            this.Text = "Connect with bot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox chatHistoryText;
        private System.Windows.Forms.TextBox metaText;
        private System.Windows.Forms.TextBox sendText;
        private System.Windows.Forms.Button listenButton;
        private System.Windows.Forms.Button sendButton;
    }
}

