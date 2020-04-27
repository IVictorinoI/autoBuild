namespace AutoBuild.View
{
    partial class FormTempoBuild
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
            this.textBoxTimeoutBuild = new System.Windows.Forms.TextBox();
            this.textBoxTempoAtualizacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.checkBoxBuildOnSave = new System.Windows.Forms.CheckBox();
            this.checkBoxBuildCSSonSave = new System.Windows.Forms.CheckBox();
            this.checkBoxMinimizarBandeja = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxTimeoutBuild
            // 
            this.textBoxTimeoutBuild.Location = new System.Drawing.Point(169, 50);
            this.textBoxTimeoutBuild.Name = "textBoxTimeoutBuild";
            this.textBoxTimeoutBuild.Size = new System.Drawing.Size(100, 20);
            this.textBoxTimeoutBuild.TabIndex = 0;
            this.textBoxTimeoutBuild.Text = "400";
            // 
            // textBoxTempoAtualizacao
            // 
            this.textBoxTempoAtualizacao.Location = new System.Drawing.Point(169, 82);
            this.textBoxTempoAtualizacao.Name = "textBoxTempoAtualizacao";
            this.textBoxTempoAtualizacao.Size = new System.Drawing.Size(100, 20);
            this.textBoxTempoAtualizacao.TabIndex = 1;
            this.textBoxTempoAtualizacao.Text = "300000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Timeout para build (ms)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Verificação de atualização (ms)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Padrão: 300000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Padrão: 400";
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Location = new System.Drawing.Point(169, 189);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(75, 23);
            this.buttonSalvar.TabIndex = 6;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // checkBoxBuildOnSave
            // 
            this.checkBoxBuildOnSave.AutoSize = true;
            this.checkBoxBuildOnSave.Checked = true;
            this.checkBoxBuildOnSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBuildOnSave.Location = new System.Drawing.Point(169, 120);
            this.checkBoxBuildOnSave.Name = "checkBoxBuildOnSave";
            this.checkBoxBuildOnSave.Size = new System.Drawing.Size(107, 17);
            this.checkBoxBuildOnSave.TabIndex = 7;
            this.checkBoxBuildOnSave.Text = "Build JS on Save";
            this.checkBoxBuildOnSave.UseVisualStyleBackColor = true;
            // 
            // checkBoxBuildCSSonSave
            // 
            this.checkBoxBuildCSSonSave.AutoSize = true;
            this.checkBoxBuildCSSonSave.Checked = true;
            this.checkBoxBuildCSSonSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBuildCSSonSave.Location = new System.Drawing.Point(169, 143);
            this.checkBoxBuildCSSonSave.Name = "checkBoxBuildCSSonSave";
            this.checkBoxBuildCSSonSave.Size = new System.Drawing.Size(116, 17);
            this.checkBoxBuildCSSonSave.TabIndex = 8;
            this.checkBoxBuildCSSonSave.Text = "Build CSS on Save";
            this.checkBoxBuildCSSonSave.UseVisualStyleBackColor = true;
            // 
            // checkBoxMinimizarBandeja
            // 
            this.checkBoxMinimizarBandeja.AutoSize = true;
            this.checkBoxMinimizarBandeja.Checked = true;
            this.checkBoxMinimizarBandeja.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMinimizarBandeja.Location = new System.Drawing.Point(169, 165);
            this.checkBoxMinimizarBandeja.Name = "checkBoxMinimizarBandeja";
            this.checkBoxMinimizarBandeja.Size = new System.Drawing.Size(134, 17);
            this.checkBoxMinimizarBandeja.TabIndex = 9;
            this.checkBoxMinimizarBandeja.Text = "Minimizar para bandeja";
            this.checkBoxMinimizarBandeja.UseVisualStyleBackColor = true;
            // 
            // FormTempoBuild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 236);
            this.Controls.Add(this.checkBoxMinimizarBandeja);
            this.Controls.Add(this.checkBoxBuildCSSonSave);
            this.Controls.Add(this.checkBoxBuildOnSave);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTempoAtualizacao);
            this.Controls.Add(this.textBoxTimeoutBuild);
            this.Name = "FormTempoBuild";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações gerais";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTimeoutBuild;
        private System.Windows.Forms.TextBox textBoxTempoAtualizacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.CheckBox checkBoxBuildOnSave;
        private System.Windows.Forms.CheckBox checkBoxBuildCSSonSave;
        private System.Windows.Forms.CheckBox checkBoxMinimizarBandeja;
    }
}