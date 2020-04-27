using AutoBuild.Controller;
using AutoBuild.Model;
using AutoBuild.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AutoBuild
{
    public partial class FormPrincipal : Form
    {
        static List<ComandoExecutar> buildsPendentes = new List<ComandoExecutar>();
        static List<SistemaBuild> listaBuilds = new List<SistemaBuild>();
        static List<ComandoBat> listaBats = new List<ComandoBat>();
        static SistemaBuildController sistemaBuildController = new SistemaBuildController();
        NotifyIcon notifyIconSistema = new NotifyIcon();
        static bool atualizarSistema = true;
        static bool minimizarBandeja = true;


        static System.Windows.Forms.Timer timerBuild = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer timerAtualizacao = new System.Windows.Forms.Timer();


        Thread threadBuild;

        public FormPrincipal()
        {
            InitializeComponent();

            this.ConfiguraTimerBuild();
            this.ConfiguraTimerAtualizacao();
            this.LerConfigs();

            try
            {
                var criadorArquivos = new CriadorArquivosBat();
                criadorArquivos.RenomeiaBats();
                criadorArquivos.CriaBatBaluda();
                criadorArquivos.CriaBatTemaFontes();
                criadorArquivos.CriaBatTemaCompleto();
                criadorArquivos.CriaBatCompilarFront();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            try
            {
                MataOutrosAutoBuilds();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void MataOutrosAutoBuilds()
        {
            var proc = Process.GetProcessesByName("autobuild");
            if (!proc.Any())
                return;

            if (proc.Length > 1)
                MessageBox.Show("Já tem um aberto. Orelha seca!");

            for (var i = 1; i < proc.Length; i++)
            {
                proc[i].Kill();
            }
        }

        private void ConfiguraTimerBuild()
        {
            try
            {
                timerBuild.Stop();
                timerBuild.Tick += new EventHandler(ExecutaBuildsPendentes);
                timerBuild.Interval = 400;
                if (File.Exists(@"C:\AutoBuild\Tempo.build"))
                {
                    var lines = File.ReadAllLines(@"C:\AutoBuild\Tempo.build");
                    try
                    {
                        if (lines.Any() && lines[0] != "")
                        {
                            var tempo = Convert.ToInt32(lines[0]);
                            timerBuild.Interval = tempo;
                        }
                    }
                    catch (Exception)
                    {

                        throw new Exception("Erro ao converter tempo do build para inteiro");
                    }
                }
                timerBuild.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ConfiguraTimerBuild " + ex.Message + " - " + ex.InnerException);
            }

        }

        private void ConfiguraTimerAtualizacao()
        {
            try
            {
                timerAtualizacao.Stop();
                timerAtualizacao.Tick += timerAtualizacao_Tick;
                timerAtualizacao.Interval = 300000;

                if (File.Exists(@"C:\AutoBuild\Tempo.build"))
                {
                    string[] lines = File.ReadAllLines(@"C:\AutoBuild\Tempo.build");
                    try
                    {
                        if (lines.Length > 1 && lines[1] != "")
                        {
                            int tempo = Convert.ToInt32(lines[1]);
                            timerAtualizacao.Interval = tempo;
                        }
                    }
                    catch (Exception)
                    {

                        throw new Exception("Erro ao converter tempo do build para inteiro");
                    }
                }

                timerAtualizacao.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ConfiguraTimerAtualizacao " + ex.Message + " - " + ex.InnerException);
            }

        }

        private void timerAtualizacao_Tick(object sender, EventArgs e)
        {
            if (this.ExisteAtualizacao())
            {
                NotifyIcon notifyIcon = NotificationManager.NotifyIcon;
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipTitle = string.Format("Atualização disponível {0}", this.GetVersaoExeServidor());
                notifyIcon.BalloonTipText = string.Format("Atualização disponível {0}", this.GetVersaoExeServidor());
                notifyIcon.Icon = SystemIcons.Information;
                notifyIcon.ShowBalloonTip(1000);
                notifyIcon.BalloonTipClicked += notifyAtualizacao_click;
                notifyIcon.Click += notifyAtualizacao_click;
                notifyIcon.MouseClick += notifyAtualizacao_click;
                var t = new Thread(() =>
                {
                    Thread.Sleep(7000);
                    notifyIcon.Visible = false;
                });
                t.Start();
            }
        }

        private void notifyAtualizacao_click(object sender, EventArgs e)
        {
            if (atualizarSistema)
            {
                this.PerguntaAtualizarSistema();
                atualizarSistema = false;
            }

        }

        private void ExecutaBuildsPendentes(Object myObject, EventArgs myEventArgs)
        {
            try
            {
                timerBuild.Stop();
                if (buildsPendentes.Any())
                {

                    if (threadBuild != null)
                    {
                        threadBuild.Abort();
                    }
                    threadBuild = new Thread(() =>
                    {


                        Process[] proc = Process.GetProcessesByName("sencha");
                        if (proc.Any())
                        {
                            foreach (var item in proc)
                            {
                                try
                                {
                                    item.Kill();
                                }
                                catch (Exception)
                                {
                                    //erro
                                }

                            }
                        }


                        var comandoExecutar = buildsPendentes.First();
                        buildsPendentes.RemoveAt(0);

                        sistemaBuildController.ShowNotification("Iniciando build " + comandoExecutar.Tipo + " do " + comandoExecutar.Nome, comandoExecutar.Diretorio, SystemIcons.Information);
                        this.AddTextoLog("Iniciando build " + comandoExecutar.Tipo + " do " + comandoExecutar.Nome + "... ");

                        sistemaBuildController.ExecutaBuild(comandoExecutar);

                        var ultimoErro = sistemaBuildController.GetUltimoErro();
                        var textoPrefixo = "[Ok] - ";
                        if (ultimoErro.IndexOf("ERR") > 0)
                            textoPrefixo = "[Error] - ";
                        else if (ultimoErro.IndexOf("WRN") > 0)
                            textoPrefixo = "[Warning] - ";

                        AddTextoLog(textoPrefixo + "Build " + comandoExecutar.Tipo + " do " + comandoExecutar.Nome + " finalizada " + "!" + ultimoErro);

                    });
                    threadBuild.Start();
                }
                timerBuild.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ExecutaBuildsPendentes " + ex.Message + " - " + ex.InnerException);
            }

        }

        private void iniciarMonitoramento_Click(object sender, EventArgs e)
        {
            IniciarMonitoramento();
            buttonIniciarMonitoramento.Enabled = false;
        }

        private void IniciarMonitoramento()
        {
            bool monitorarJs = true;
            bool monitorarCss = true;
            if (File.Exists(@"C:\AutoBuild\Tempo.build"))
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\AutoBuild\Tempo.build");

                try
                {
                    monitorarJs = Convert.ToBoolean(lines[2]);
                }
                catch (Exception)
                {
                    monitorarJs = true;
                }

                try
                {
                    monitorarCss = Convert.ToBoolean(lines[3]);
                }
                catch (Exception)
                {
                    monitorarCss = true;
                }
            }

            if (monitorarJs)
                IniciarMonitoramentoJs();

            /*if (monitorarCss)
                IniciarMonitoramentoCss();*/
        }

        private void IniciarMonitoramentoJs()
        {
            foreach (SistemaBuild Sistema in listaBuilds)
            {
                System.IO.FileSystemWatcher Watcher = new System.IO.FileSystemWatcher();
                Watcher.Changed += Watcher_ModifyM2;
                Watcher.Created += Watcher_ModifyM2;
                Watcher.Deleted += Watcher_ModifyM2;
                if (Directory.Exists(Sistema.Diretorio + "\\app"))
                {
                    Watcher.Path = Sistema.Diretorio + "\\app";
                }
                else if (Directory.Exists(Sistema.Diretorio + "\\per"))
                {
                    Watcher.Path = Sistema.Diretorio + "\\per";
                }
                else
                {
                    Watcher.Path = Sistema.Diretorio;
                }

                Watcher.IncludeSubdirectories = true;
                Watcher.EnableRaisingEvents = true;
            }
        }

        private void IniciarMonitoramentoCss()
        {
            foreach (SistemaBuild Sistema in listaBuilds)
            {
                if (Directory.Exists(Sistema.Diretorio + "\\packages\\local\\app-theme\\sass"))
                {
                    System.IO.FileSystemWatcher Watcher = new System.IO.FileSystemWatcher();
                    Watcher.Changed += Watcher_ModifyCss;
                    Watcher.Created += Watcher_ModifyCss;
                    Watcher.Deleted += Watcher_ModifyCss;

                    Watcher.Path = Sistema.Diretorio + "\\packages\\local\\app-theme\\sass";

                    Watcher.IncludeSubdirectories = true;
                    Watcher.EnableRaisingEvents = true;
                }
            }
        }

        void Watcher_ModifyM2(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                if (!e.Name.EndsWith("all-classes.js")
                && !e.Name.Contains(@"\build\")
                 && !e.Name.EndsWith(@"build\app.js")
                 && !e.Name.EndsWith(@"build\testing\App\app.js")
                 && !e.Name.Contains(@"packages\local\app-theme")
                 && e.Name.EndsWith(".js"))
                {
                    Console.WriteLine("Arquivo modificado : " + e.FullPath);
                    //this.AddTextoLog("Arquivo modificado : " + e.Name);
                    var path = ((FileSystemWatcher)sender).Path.Replace("\\app", "");
                    var sistemaBuild = FindSistemaByPath(path);

                    if (sistemaBuild == null)
                        throw new Exception(string.Format("Build não encontrada para a pasta {0}", path));

                    this.addFilaBuild(new ComandoExecutar()
                    {
                        Diretorio = sistemaBuild.Diretorio,
                        Nome = sistemaBuild.Nome,
                        Comando = sistemaBuild.Comando,
                        Tipo = "JS"
                    });
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro Watcher_ModifyM2 " + ex.Message + " - " + ex.InnerException);
            }
        }

        void Watcher_ModifyCss(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                if (e.Name.EndsWith(".scss"))
                {
                    Console.WriteLine("Arquivo TEMA modificado : " + e.FullPath);
                    //this.AddTextoLog("Arquivo modificado : " + e.Name);
                    String path = ((System.IO.FileSystemWatcher)sender).Path.Replace("\\app", "").Replace("\\per", "").Replace("\\packages", "").Replace("\\local-theme", "").Replace("\\sass", "");
                    SistemaBuild sistemaBuild = FindSistemaByPath(path);
                    this.addFilaBuild(new ComandoExecutar()
                    {
                        Diretorio = sistemaBuild.Diretorio + @"\packages\local\app-theme",
                        Nome = sistemaBuild.Nome,
                        Comando = "sencha ant sass",
                        Tipo = "CSS"
                    });
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro Watcher_ModifyCss " + ex.Message + " - " + ex.InnerException);
            }
        }

        private void addFilaBuild(ComandoExecutar comandoExecutar)
        {
            try
            {
                if (FindBuildByPath(comandoExecutar.Diretorio) == null)
                {
                    buildsPendentes.Add(comandoExecutar);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro addFilaBuild " + ex.Message + " - " + ex.InnerException);
            }
        }

        static SistemaBuild FindSistemaByPath(String caminho)
        {
            return listaBuilds.FirstOrDefault(s => s.Diretorio == caminho);
        }

        static SistemaBuild FindSistemaByName(String nome)
        {
            return listaBuilds.FirstOrDefault(s => s.Nome == nome);
        }

        static ComandoBat FindBatByName(string nome)
        {
            return listaBats.FirstOrDefault(s => s.Nome == nome);
        }

        static ComandoExecutar FindBuildByPath(String caminho)
        {
            return buildsPendentes.FirstOrDefault(s => s.Diretorio == caminho);
        }

        private void buttonConfigurarBuilds_Click(object sender, EventArgs e)
        {
            FormConfigurarBuilds formConfigurarBuilds = new FormConfigurarBuilds();
            formConfigurarBuilds.Show();
        }

        private void FormPrincipal_Shown(object sender, EventArgs e)
        {
            sistemaBuildController.IniciarComWindows();
            sistemaBuildController.CriaPastaMenuIniciar();
            this.CriarBotoesBuilds();
            listaBuilds = sistemaBuildController.LoadAllSistems();
            listaBats = sistemaBuildController.LoadAllBats();


            buttonIniciarMonitoramento.PerformClick();
        }

        private void configurarBuildsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfigurarBuilds formConfigurarBuilds = new FormConfigurarBuilds();
            formConfigurarBuilds.ShowDialog();
            this.RemoveBotoesBuilds();
            this.CriarBotoesBuilds();
        }

        private void CriarBotoesBuilds()
        {
            int left = 10;
            int top = 60;
            int width = 110;
            int height = 30;
            int contParcial = 0;
            listaBuilds = sistemaBuildController.LoadAllSistems();
            foreach (var sistema in listaBuilds)
            {
                contParcial++;
                if (contParcial > 6)
                {
                    top += 40;
                    left = 10;
                    contParcial = 1;
                }
                else if (contParcial > 1)
                {
                    left += 120;
                }
                var button = new Button
                {
                    Left = left,
                    Top = top,
                    Width = width,
                    Height = height,
                    Text = sistema.Nome,
                    Tag = 99,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 }
                };
                button.Click += ExecBluid_Click;

                if (string.IsNullOrEmpty(sistema.Cor))
                    button.BackColor = Color.LightGray;
                else
                    button.BackColor = ColorTranslator.FromHtml(sistema.Cor);

                var cm = new ContextMenu();

                listaBats = sistemaBuildController.LoadAllBats();

                foreach (var comandoBat in listaBats)
                {
                    var miBat = new MenuItem
                    {
                        Text = comandoBat.Nome
                    };
                    miBat.Click += MiExecutaBatOnClick;
                    cm.MenuItems.Add(miBat);
                }

                button.ContextMenu = cm;

                this.Controls.Add(button);
            }
        }

        private void MiExecutaBatOnClick(object sender, EventArgs eventArgs)
        {
            MenuItem menuItem = ((MenuItem)sender);
            ContextMenu contextMenu = (ContextMenu)menuItem.Parent;
            Button button = (Button)contextMenu.SourceControl;
            SistemaBuild sistemaBuild = FindSistemaByName(button.Text);
            ComandoBat comandoBat = FindBatByName(menuItem.Text);
            var comando = string.Format("start " + comandoBat.CaminhoArquivo + " ");
            //var comando = "start C:\\AutoBuild\\CT.bat";

            this.ExecComando(sistemaBuild.Diretorio, comando);
        }

        private void RemoveBotoesBuilds()
        {
            var controlesRemover = new List<Control>();
            foreach (var control in this.Controls)
            {
                if (!(control is Control))
                    continue;

                var tag = ((Control)control).Tag;

                if (!(tag is int))
                    continue;

                if ((int)tag != 99)
                    continue;

                controlesRemover.Add(control as Control);
            }


            foreach (var control in controlesRemover)
            {
                this.Controls.Remove(control);
            }
        }

        private void ExecBluid_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            try
            {
                SistemaBuild sistemaBuild = FindSistemaByName(((Button)sender).Text);
                //sistemaBuildController.ShowNotification("Iniciando build " + sistemaBuild.Nome, sistemaBuild.Diretorio, SystemIcons.Information);
                //this.AddTextoLog("Iniciando build " + sistemaBuild.Nome + "... ");
                //sistemaBuildController.ExecutaBuild(sistemaBuild);
                //this.AddTextoLog("Build finalizada " + sistemaBuild.Nome + "!" + sistemaBuildController.GetUltimoErro());

                this.addFilaBuild(new ComandoExecutar()
                {
                    Diretorio = sistemaBuild.Diretorio,
                    Nome = sistemaBuild.Nome,
                    Comando = sistemaBuild.Comando,
                    Tipo = "JS"
                });
                this.ExecutaBuildsPendentes(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar build " + ex.Message);
            }
            ((Button)sender).Enabled = true;
        }

        private void AddTextoLog(string texto)
        {

            listBoxLog.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - " + texto);

            listBoxLog.SelectedItem = listBoxLog.Items[listBoxLog.Items.Count - 1];

            listView1.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - " + texto);
            listView1.Items[listView1.Items.Count - 1].BackColor = Color.Green;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].BackColor = Color.Red;
            }
        }

        private void listBoxLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxLog_DoubleClick(object sender, EventArgs e)
        {
            FormMostraOutput formMostraOutput = new FormMostraOutput();
            formMostraOutput.richTextBoxOutput.Text = listBoxLog.SelectedItem.ToString();
            formMostraOutput.Show();
        }

        private void FormPrincipal_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState && minimizarBandeja)
            {
                notifyIconSistema.Visible = true;
                notifyIconSistema.BalloonTipTitle = "Auto build está executando!";
                notifyIconSistema.BalloonTipText = "Auto build está executando!";
                notifyIconSistema.ShowBalloonTip(1000);
                notifyIconSistema.Icon = AutoBuild.Properties.Resources.sencha;
                notifyIconSistema.BalloonTipClicked += notifyIcon_Click;
                notifyIconSistema.Click += notifyIcon_Click;
                notifyIconSistema.MouseClick += notifyIcon_Click;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIconSistema.Visible = false;
            }

        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AtualizarSistema();
        }

        private void AtualizarSistema()
        {
            if (!File.Exists(@"P:\Victor\AutoBuild.exe"))
            {
                MessageBox.Show("Não existem atualizações disponiveis.");
                return;
            }
            System.Diagnostics.Process.Start(@"C:\AutoBuild\AtualizadorAutoBuild.exe");
            Application.Exit();
        }

        private string GetVersaoExeServidor()
        {
            if (!File.Exists(@"P:\Victor\AutoBuild.exe"))
                return string.Empty;

            var fileServidor = System.Diagnostics.FileVersionInfo.GetVersionInfo(@"P:\Victor\AutoBuild.exe");
            return fileServidor.FileVersion;
        }

        private string GetVersaoExeLocal()
        {
            if (!File.Exists(@"C:\AutoBuild\AutoBuild.exe"))
                return string.Empty;

            var fileLocal = System.Diagnostics.FileVersionInfo.GetVersionInfo(@"C:\AutoBuild\AutoBuild.exe");
            return fileLocal.FileVersion;
        }

        private bool ExisteAtualizacao()
        {
            if (!File.Exists(@"P:\Victor\AutoBuild.exe"))
                return false;

            return this.GetVersaoExeLocal() != this.GetVersaoExeServidor();
        }

        private void PerguntaAtualizarSistema()
        {
            DialogResult dialogResult = MessageBox.Show(String.Format("Versão atual {0}, versão servidor {1}. Deseja atualizar?", this.GetVersaoExeLocal(), this.GetVersaoExeServidor()), "Atualização", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.AtualizarSistema();
            }
        }

        private void verificarAtualizaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ExisteAtualizacao())
            {
                this.PerguntaAtualizarSistema();
            }
            else
            {
                MessageBox.Show(String.Format("Seu sistema está na versão {0}. Não existem atualizações disponíveis.", this.GetVersaoExeLocal()));
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void FormPrincipal_Click(object sender, EventArgs e)
        {

        }

        private void tempoBuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTempoBuild formTempoBuild = new FormTempoBuild();
            formTempoBuild.ShowDialog();
            this.ConfiguraTimerBuild();
            this.ConfiguraTimerAtualizacao();
            this.LerConfigs();
        }

        private void novidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNovidades formNovidades = new FormNovidades();
            formNovidades.ShowDialog();
        }

        private void ExecComando(string pasta, string comando)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + comando);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            processInfo.WorkingDirectory = pasta;

            var process = Process.Start(processInfo);
            process.WaitForExit();

            String output = process.StandardOutput.ReadToEnd();
            String erro = process.StandardError.ReadToEnd();

            Console.WriteLine("output>>" + output);
            Console.WriteLine("error>>" + erro);

            Icon icone = AutoBuild.Properties.Resources.success;
            Console.WriteLine("ExitCode: {0}", process.ExitCode);
            process.Close();
        }

        private void LerConfigs()
        {
            if (File.Exists(@"C:\AutoBuild\Tempo.build"))
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\AutoBuild\Tempo.build");

                try
                {
                    minimizarBandeja = Convert.ToBoolean(lines[4]);
                }
                catch (Exception)
                {
                    minimizarBandeja = true;
                }
            }
        }
    }
}
