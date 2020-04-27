namespace AutoBuild.View
{
    partial class FormMostraOutput
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
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOutput.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(1188, 450);
            this.richTextBoxOutput.TabIndex = 0;
            this.richTextBoxOutput.Text = "";
            // 
            // FormMostraOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 474);
            this.Controls.Add(this.richTextBoxOutput);
            this.Name = "FormMostraOutput";
            this.Text = "Output - Resultado";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox richTextBoxOutput;

    }
}