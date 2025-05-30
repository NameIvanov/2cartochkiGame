namespace _2cartochkiGame
{
    partial class FormUser
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
            this.textBoxEnterName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonEnterName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxEnterName
            // 
            this.textBoxEnterName.BackColor = System.Drawing.Color.PeachPuff;
            this.textBoxEnterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEnterName.Location = new System.Drawing.Point(96, 102);
            this.textBoxEnterName.Name = "textBoxEnterName";
            this.textBoxEnterName.Size = new System.Drawing.Size(295, 26);
            this.textBoxEnterName.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Bisque;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(143, 83);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(203, 16);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Введите свое имя и фамилию:";
            // 
            // buttonEnterName
            // 
            this.buttonEnterName.BackColor = System.Drawing.Color.Tomato;
            this.buttonEnterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEnterName.Location = new System.Drawing.Point(146, 134);
            this.buttonEnterName.Name = "buttonEnterName";
            this.buttonEnterName.Size = new System.Drawing.Size(191, 51);
            this.buttonEnterName.TabIndex = 2;
            this.buttonEnterName.Text = "Подтвердить";
            this.buttonEnterName.UseVisualStyleBackColor = false;
            this.buttonEnterName.Click += new System.EventHandler(this.buttonEnterName_Click);
            // 
            // FormUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(490, 274);
            this.Controls.Add(this.buttonEnterName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxEnterName);
            this.Name = "FormUser";
            this.Text = "FormUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEnterName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonEnterName;
    }
}