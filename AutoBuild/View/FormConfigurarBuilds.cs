using AutoBuild.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AutoBuild.View
{
    public partial class FormConfigurarBuilds : Form
    {

        SistemaBuildController sistemaBuildController = new SistemaBuildController();
        static List<SistemaBuild> listaBuilds = new List<SistemaBuild>();

        public FormConfigurarBuilds()
        {
            InitializeComponent();
            CarregarBuilds();


        }

        private void CarregarBuilds()
        {
            listaBuilds = sistemaBuildController.LoadAllSistems();
            foreach (SistemaBuild sistemaBuild in listaBuilds)
            {
                listBoxBuilds.Items.Add(sistemaBuild.CaminhoArquivo);
            }
        }

        private DirectoryInfo RetornaUltimoModificado(DirectoryInfo diretorioVerificar, int nivel)
        {
            //DirectoryInfo[] diretoriosSistemas = diretorioVerificar.GetDirectories("*.Web", SearchOption.AllDirectories);
            DirectoryInfo[] diretoriosSistemas = diretorioVerificar.GetDirectories();
            var maiorDataModificacao = new DateTime(1900, 01, 01);

            if (!diretoriosSistemas.Any())
                return null;

            nivel++;

            if (nivel > 4)
                return null;

            DirectoryInfo ultimoModificado = null;
            foreach (var dir in diretoriosSistemas)
            {
                var ultimaPastaModificada = dir;
                var ehWeb = (ultimaPastaModificada.FullName.ToUpper().EndsWith("WEB"));

                if (!ehWeb)
                    ultimaPastaModificada = RetornaUltimoModificado(dir, nivel);

                if (ultimaPastaModificada != null && ultimaPastaModificada.LastWriteTime > maiorDataModificacao)
                {
                    ultimoModificado = ultimaPastaModificada;
                    maiorDataModificacao = ultimaPastaModificada.LastWriteTime;
                }
            }

            return ultimoModificado;
        }

        private void listBoxBuilds_Click(object sender, EventArgs e)
        {

            this.CarregarSistema(listBoxBuilds.GetItemText(listBoxBuilds.SelectedItem));
        }

        private void CarregarSistema(string caminho)
        {
            SistemaBuild sistemaBuild = listaBuilds.FirstOrDefault(p => p.CaminhoArquivo == caminho);
            textBoxNome.Text = sistemaBuild.Nome;
            textBoxPasta.Text = sistemaBuild.Diretorio;
            textBoxComando.Text = sistemaBuild.Comando;
            textBoxCor.Text = sistemaBuild.Cor;

            if (!string.IsNullOrEmpty(sistemaBuild.Cor))
                textBoxCor.BackColor = ColorTranslator.FromHtml(sistemaBuild.Cor);
            else
                textBoxCor.BackColor = Color.Empty;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {

            if (textBoxNome.Text.Trim() == "")
            {
                MessageBox.Show("Informe um nome para a build");
                return;
            }

            var filePath = @"C:\AutoBuild\" + textBoxNome.Text + ".txt";

            if (!File.Exists(filePath))
            {
                //Verificar aqui se a build já está configurada.
            }

            string[] lines = { textBoxPasta.Text, textBoxComando.Text, textBoxCor.Text };
            File.WriteAllLines(filePath, lines);
            LimparCmps();
        }

        private void buttonNovo_Click(object sender, EventArgs e)
        {
            LimparCmps();
            textBoxNome.ReadOnly = false;
            textBoxComando.Text = "sencha compile --classpath=app.js exclude -namespace Ext,Use,Docs,Msg and include -namespace Ext.theme,Ext.locale and concat build/testing/App/app.js";
            textBoxNome.Focus();
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            var dirDesenv = textBoxDirDesenv.Text;
            if (Directory.Exists(dirDesenv))
            {
                folderBrowserDialog1.SelectedPath = dirDesenv;
            }


            folderBrowserDialog1.ShowDialog();
            textBoxPasta.Text = folderBrowserDialog1.SelectedPath;
        }

        private void LimparCmps()
        {
            textBoxNome.Clear();
            textBoxComando.Clear();
            textBoxPasta.Clear();
        }

        private void buttonCarregUlt_Click(object sender, EventArgs e)
        {
            buttonCarregUlt.Enabled = false;
            DirectoryInfo dirDesenv = new DirectoryInfo(textBoxDirDesenv.Text);
            var ultimoDiretorioModificado = RetornaUltimoModificado(dirDesenv, 0);
            textBoxPasta.Text = ultimoDiretorioModificado.FullName;
            buttonCarregUlt.Enabled = true;
        }

        private void buttonBatBaluda_Click(object sender, EventArgs e)
        {
            this.ExecComando(textBoxPasta.Text, @"start C:\AutoBuild\ColarNaPastaWeb_LimpaCacheBaixaCoreBuildSistema.bat");
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

        private void textBoxDirDesenv_Click(object sender, EventArgs e)
        {
            if (textBoxDirDesenv.Text == @"C:\Desenvolvimento")
                textBoxDirDesenv.Text = @"E:\Desenvolvimento";
            else
                textBoxDirDesenv.Text = @"C:\Desenvolvimento";
        }

        private void buttonCor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxCor.Text = ColorTranslator.ToHtml(MyDialog.Color);
                textBoxCor.BackColor = MyDialog.Color;
            }
        }
    }
}
