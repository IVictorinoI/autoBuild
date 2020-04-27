namespace AutoBuild.View
{
    partial class FormConfigurarBuilds
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDirDesenv = new System.Windows.Forms.TextBox();
            this.buttonBatBaluda = new System.Windows.Forms.Button();
            this.buttonCarregUlt = new System.Windows.Forms.Button();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.buttonNovo = new System.Windows.Forms.Button();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxComando = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPasta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBoxBuilds = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxCor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCor = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonCor);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxCor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxDirDesenv);
            this.panel1.Controls.Add(this.buttonBatBaluda);
            this.panel1.Controls.Add(this.buttonCarregUlt);
            this.panel1.Controls.Add(this.buttonOpenFolder);
            this.panel1.Controls.Add(this.buttonSalvar);
            this.panel1.Controls.Add(this.buttonNovo);
            this.panel1.Controls.Add(this.textBoxNome);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxComando);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxPasta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 119);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(691, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Dir. Desenv";
            // 
            // textBoxDirDesenv
            // 
            this.textBoxDirDesenv.Location = new System.Drawing.Point(760, 14);
            this.textBoxDirDesenv.Name = "textBoxDirDesenv";
            this.textBoxDirDesenv.Size = new System.Drawing.Size(147, 20);
            this.textBoxDirDesenv.TabIndex = 11;
            this.textBoxDirDesenv.Text = "C:\\Desenvolvimento";
            this.textBoxDirDesenv.Click += new System.EventHandler(this.textBoxDirDesenv_Click);
            // 
            // buttonBatBaluda
            // 
            this.buttonBatBaluda.Location = new System.Drawing.Point(234, 94);
            this.buttonBatBaluda.Name = "buttonBatBaluda";
            this.buttonBatBaluda.Size = new System.Drawing.Size(75, 23);
            this.buttonBatBaluda.TabIndex = 10;
            this.buttonBatBaluda.Text = "Sync core";
            this.buttonBatBaluda.UseVisualStyleBackColor = true;
            this.buttonBatBaluda.Click += new System.EventHandler(this.buttonBatBaluda_Click);
            // 
            // buttonCarregUlt
            // 
            this.buttonCarregUlt.Location = new System.Drawing.Point(760, 38);
            this.buttonCarregUlt.Name = "buttonCarregUlt";
            this.buttonCarregUlt.Size = new System.Drawing.Size(116, 23);
            this.buttonCarregUlt.TabIndex = 9;
            this.buttonCarregUlt.Text = "Carreg. Ult.";
            this.buttonCarregUlt.UseVisualStyleBackColor = true;
            this.buttonCarregUlt.Click += new System.EventHandler(this.buttonCarregUlt_Click);
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(882, 39);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(25, 23);
            this.buttonOpenFolder.TabIndex = 8;
            this.buttonOpenFolder.Text = "...";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Location = new System.Drawing.Point(152, 94);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(75, 23);
            this.buttonSalvar.TabIndex = 7;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // buttonNovo
            // 
            this.buttonNovo.Location = new System.Drawing.Point(71, 94);
            this.buttonNovo.Name = "buttonNovo";
            this.buttonNovo.Size = new System.Drawing.Size(75, 23);
            this.buttonNovo.TabIndex = 6;
            this.buttonNovo.Text = "Novo";
            this.buttonNovo.UseVisualStyleBackColor = true;
            this.buttonNovo.Click += new System.EventHandler(this.buttonNovo_Click);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(71, 15);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(100, 20);
            this.textBoxNome.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nome";
            // 
            // textBoxComando
            // 
            this.textBoxComando.Location = new System.Drawing.Point(71, 67);
            this.textBoxComando.Name = "textBoxComando";
            this.textBoxComando.Size = new System.Drawing.Size(836, 20);
            this.textBoxComando.TabIndex = 3;
            this.textBoxComando.Text = "sencha compile --classpath=app.js exclude -namespace Ext,Use,Docs,Msg and include" +
    " -namespace Ext.theme,Ext.locale and concat build/testing/App/app.js";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Comando";
            // 
            // textBoxPasta
            // 
            this.textBoxPasta.Location = new System.Drawing.Point(71, 41);
            this.textBoxPasta.Name = "textBoxPasta";
            this.textBoxPasta.Size = new System.Drawing.Size(683, 20);
            this.textBoxPasta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pasta";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.listBoxBuilds);
            this.panel2.Location = new System.Drawing.Point(12, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(916, 297);
            this.panel2.TabIndex = 1;
            // 
            // listBoxBuilds
            // 
            this.listBoxBuilds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxBuilds.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxBuilds.FormattingEnabled = true;
            this.listBoxBuilds.ItemHeight = 21;
            this.listBoxBuilds.Location = new System.Drawing.Point(3, 3);
            this.listBoxBuilds.Name = "listBoxBuilds";
            this.listBoxBuilds.Size = new System.Drawing.Size(910, 277);
            this.listBoxBuilds.TabIndex = 0;
            this.listBoxBuilds.Click += new System.EventHandler(this.listBoxBuilds_Click);
            // 
            // textBoxCor
            // 
            this.textBoxCor.Location = new System.Drawing.Point(302, 14);
            this.textBoxCor.Name = "textBoxCor";
            this.textBoxCor.Size = new System.Drawing.Size(88, 20);
            this.textBoxCor.TabIndex = 13;
            this.textBoxCor.Text = "#fd00ff";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cor";
            // 
            // buttonCor
            // 
            this.buttonCor.Location = new System.Drawing.Point(396, 12);
            this.buttonCor.Name = "buttonCor";
            this.buttonCor.Size = new System.Drawing.Size(27, 23);
            this.buttonCor.TabIndex = 15;
            this.buttonCor.Text = "...";
            this.buttonCor.UseVisualStyleBackColor = true;
            this.buttonCor.Click += new System.EventHandler(this.buttonCor_Click);
            // 
            // FormConfigurarBuilds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 443);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormConfigurarBuilds";
            this.Text = "Configurar builds";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBoxBuilds;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxComando;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Button buttonNovo;
        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonCarregUlt;
        private System.Windows.Forms.Button buttonBatBaluda;
        private System.Windows.Forms.TextBox textBoxDirDesenv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCor;
    }
}