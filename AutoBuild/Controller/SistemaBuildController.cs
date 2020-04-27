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

namespace AutoBuild.Controller
{
    public class SistemaBuildController
    {

        private static List<String> ListaErrosPendentes;
        private static FormMostraOutput FormMostraOutput;

        public SistemaBuildController()
        {
            if (ListaErrosPendentes == null)
            {
                ListaErrosPendentes = new List<string>();
            }
        }

        public string GetUltimoErro()
        {
            string ultimoErro = "";
            if (ListaErrosPendentes.Count() > 0)
            {
                ultimoErro = ListaErrosPendentes[0];
                ListaErrosPendentes.RemoveAt(0);
            }
            return ultimoErro;
        }

        public List<SistemaBuild> LoadAllSistems()
        {
            List<SistemaBuild> listaBuilds = new List<SistemaBuild>();
            DirectoryInfo Dir = new DirectoryInfo(@"C:\AutoBuild");
            FileInfo[] Files = Dir.GetFiles("*.txt", SearchOption.AllDirectories);
            foreach (FileInfo File in Files)
            {
                string[] lines = System.IO.File.ReadAllLines(File.FullName);
                if (Directory.Exists(lines[0]))
                {
                    SistemaBuild sistemaBuild = new SistemaBuild();
                    sistemaBuild.Nome = File.Name.Replace(".txt", ""); ;
                    sistemaBuild.CaminhoArquivo = File.FullName;
                    sistemaBuild.Diretorio = lines[0];
                    sistemaBuild.Comando = lines[1];
                    if (lines.Length > 2)
                        sistemaBuild.Cor = lines[2];

                    listaBuilds.Add(sistemaBuild);
                }
            }
            return listaBuilds;
        }

        public List<ComandoBat> LoadAllBats()
        {
            List<ComandoBat> listaBatas = new List<ComandoBat>();
            DirectoryInfo Dir = new DirectoryInfo(@"C:\AutoBuild");
            FileInfo[] Files = Dir.GetFiles("*.bat", SearchOption.AllDirectories);
            foreach (FileInfo File in Files)
            {
                if (File.Name.Contains(" "))
                {
                    MessageBox.Show("Aviso: A bat " + File.Name + " não será carregada porque possui ESPAÇO no nome.");
                    continue;
                }

                ComandoBat comandoBat = new ComandoBat();
                comandoBat.Nome = File.Name.Replace(".bat", ""); ;
                comandoBat.CaminhoArquivo = File.FullName;
                listaBatas.Add(comandoBat);
            }
            return listaBatas;
        }

        public void ExecutaBuild(ComandoExecutar comando)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + comando.Comando);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            processInfo.WorkingDirectory = comando.Diretorio;

            var process = Process.Start(processInfo);
            //process.WaitForExit();

            process.PriorityClass = ProcessPriorityClass.RealTime;

            var output = string.Empty;
            var erro = string.Empty;
            while (!process.StandardOutput.EndOfStream)
            {
                output += process.StandardOutput.ReadLine() + "\n";
                //ListaErrosPendentes.Add(linha);
                // do something with line
            }

            //String output = process.StandardOutput.ReadToEnd();
            //String erro = process.StandardError.ReadToEnd();

            Console.WriteLine("output>>" + output);
            Console.WriteLine("error>>" + erro);

            Icon icone = AutoBuild.Properties.Resources.success;

            if (!erro.Equals("") || output.IndexOf("ERR") > 0)
            {
                icone = SystemIcons.Error;
                ListaErrosPendentes.Add(erro + output);
            }
            else if (output.IndexOf("WRN") > 0)
            {
                icone = SystemIcons.Exclamation;
                ListaErrosPendentes.Add(erro + output);
            }

            if (!erro.Equals("") || !output.Equals(""))
            {
                ShowNotification("Resultado build " + comando.Nome, erro + output, icone);
            }

            Console.WriteLine("ExitCode: {0}", process.ExitCode);
            process.Close();
        }

        public void ShowNotification(String title, String ballonText, Icon icone)
        {
            //NotifyIcon notifyIcon = new NotifyIcon();
            NotifyIcon notifyIcon = NotificationManager.NotifyIcon;
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = ballonText;
            notifyIcon.Icon = icone;
            notifyIcon.ShowBalloonTip(1000);
            notifyIcon.BalloonTipClicked += notifyIcon_Click;
            notifyIcon.Click += notifyIcon_Click;
            notifyIcon.MouseClick += notifyIcon_Click;
            if (FormMostraOutput == null)
            {
                FormMostraOutput = new FormMostraOutput();
            }

            Thread t = new Thread(() =>
            {
                Thread.Sleep(3500);
                //notifyIcon.Dispose();
                notifyIcon.Visible = false;
            });
            t.Start();

        }

        static void notifyIcon_Click(object sender, EventArgs e)
        {
            if (FormMostraOutput != null)
            {
                FormMostraOutput.richTextBoxOutput.Text = ((NotifyIcon)sender).BalloonTipText;
                FormMostraOutput.ShowDialog();
                FormMostraOutput = null;
            }
        }

        public void IniciarComWindows()
        {
            string caminhoAtalho = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\AutoBuild.exe.lnk";
            if (!File.Exists(caminhoAtalho))
                File.Copy(@"C:\AutoBuild\AutoBuild.exe.lnk", caminhoAtalho);
        }

        public void CriaPastaMenuIniciar()
        {
            var pastaCriar = Environment.GetFolderPath(Environment.SpecialFolder.Programs) + "\\AutoBuild";

            if (!Directory.Exists(pastaCriar))
                Directory.CreateDirectory(pastaCriar);

            var caminhoAtalho = pastaCriar + "\\AutoBuild.exe.lnk";

            if (!File.Exists(caminhoAtalho))
                File.Copy(@"C:\AutoBuild\AutoBuild.exe.lnk", caminhoAtalho);
        }
    }
}
