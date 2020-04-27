namespace AutoBuild.View
{
    partial class FormNovidades
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
            this.richTextBoxNovidades = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxNovidades
            // 
            this.richTextBoxNovidades.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxNovidades.Name = "richTextBoxNovidades";
            this.richTextBoxNovidades.Size = new System.Drawing.Size(485, 446);
            this.richTextBoxNovidades.TabIndex = 0;
            this.richTextBoxNovidades.Text = "";
            // 
            // FormNovidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 470);
            this.Controls.Add(this.richTextBoxNovidades);
            this.Name = "FormNovidades";
            this.Text = "Novidades";
            this.Shown += new System.EventHandler(this.FormNovidades_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxNovidades;
    }
}