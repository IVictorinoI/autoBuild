namespace AutoBuild
{
    partial class FormPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonIniciarMonitoramento = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarBuildsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tempoBuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verificarAtualizaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonIniciarMonitoramento
            // 
            this.buttonIniciarMonitoramento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonIniciarMonitoramento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIniciarMonitoramento.Location = new System.Drawing.Point(12, 31);
            this.buttonIniciarMonitoramento.Name = "buttonIniciarMonitoramento";
            this.buttonIniciarMonitoramento.Size = new System.Drawing.Size(742, 23);
            this.buttonIniciarMonitoramento.TabIndex = 1;
            this.buttonIniciarMonitoramento.Text = "Iniciar monitoramento";
            this.buttonIniciarMonitoramento.UseVisualStyleBackColor = true;
            this.buttonIniciarMonitoramento.Click += new System.EventHandler(this.iniciarMonitoramento_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(766, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurarBuildsToolStripMenuItem,
            this.tempoBuildToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // configurarBuildsToolStripMenuItem
            // 
            this.configurarBuildsToolStripMenuItem.Name = "configurarBuildsToolStripMenuItem";
            this.configurarBuildsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.configurarBuildsToolStripMenuItem.Text = "Configurar builds";
            this.configurarBuildsToolStripMenuItem.Click += new System.EventHandler(this.configurarBuildsToolStripMenuItem_Click);
            // 
            // tempoBuildToolStripMenuItem
            // 
            this.tempoBuildToolStripMenuItem.Name = "tempoBuildToolStripMenuItem";
            this.tempoBuildToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.tempoBuildToolStripMenuItem.Text = "Configurações gerais";
            this.tempoBuildToolStripMenuItem.Click += new System.EventHandler(this.tempoBuildToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atualizarToolStripMenuItem,
            this.verificarAtualizaçõesToolStripMenuItem,
            this.novidadesToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // atualizarToolStripMenuItem
            // 
            this.atualizarToolStripMenuItem.Name = "atualizarToolStripMenuItem";
            this.atualizarToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.atualizarToolStripMenuItem.Text = "Atualizar";
            this.atualizarToolStripMenuItem.Click += new System.EventHandler(this.atualizarToolStripMenuItem_Click);
            // 
            // verificarAtualizaçõesToolStripMenuItem
            // 
            this.verificarAtualizaçõesToolStripMenuItem.Name = "verificarAtualizaçõesToolStripMenuItem";
            this.verificarAtualizaçõesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.verificarAtualizaçõesToolStripMenuItem.Text = "Verificar atualizações";
            this.verificarAtualizaçõesToolStripMenuItem.Click += new System.EventHandler(this.verificarAtualizaçõesToolStripMenuItem_Click);
            // 
            // novidadesToolStripMenuItem
            // 
            this.novidadesToolStripMenuItem.Name = "novidadesToolStripMenuItem";
            this.novidadesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.novidadesToolStripMenuItem.Text = "Novidades";
            this.novidadesToolStripMenuItem.Click += new System.EventHandler(this.novidadesToolStripMenuItem_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(12, 464);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(742, 95);
            this.listBoxLog.TabIndex = 2;
            this.listBoxLog.SelectedIndexChanged += new System.EventHandler(this.listBoxLog_SelectedIndexChanged);
            this.listBoxLog.DoubleClick += new System.EventHandler(this.listBoxLog_DoubleClick);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 368);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(742, 90);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Visible = false;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 571);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonIniciarMonitoramento);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "AutoBuild";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.Shown += new System.EventHandler(this.FormPrincipal_Shown);
            this.Click += new System.EventHandler(this.FormPrincipal_Click);
            this.Resize += new System.EventHandler(this.FormPrincipal_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonIniciarMonitoramento;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarBuildsToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verificarAtualizaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tempoBuildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novidadesToolStripMenuItem;
    }
}

