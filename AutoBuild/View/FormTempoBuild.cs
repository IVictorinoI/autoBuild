using System;
using System.IO;
using System.Windows.Forms;

namespace AutoBuild.View
{
    public partial class FormTempoBuild : Form
    {
        public FormTempoBuild()
        {
            InitializeComponent();
            CarregaConfiguracoes();
        }

        private void CarregaConfiguracoes()
        {
            string filePath = @"C:\AutoBuild\Tempo.build";
            string[] lines = System.IO.File.ReadAllLines(filePath);


            try
            {
                textBoxTimeoutBuild.Text = lines[0];
            }
            catch (Exception)
            {
                textBoxTimeoutBuild.Text = "400";
            }

            try
            {
                textBoxTempoAtualizacao.Text = lines[1];
            }
            catch (Exception)
            {

                textBoxTempoAtualizacao.Text = "300000";
            }


            try
            {
                checkBoxBuildOnSave.Checked = Convert.ToBoolean(lines[2]);
            }
            catch (Exception)
            {
                checkBoxBuildOnSave.Checked = true;
            }

            try
            {
                checkBoxBuildCSSonSave.Checked = Convert.ToBoolean(lines[3]);
            }
            catch (Exception)
            {
                checkBoxBuildCSSonSave.Checked = true;
            }

            try
            {
                checkBoxMinimizarBandeja.Checked = Convert.ToBoolean(lines[4]);
            }
            catch (Exception)
            {
                checkBoxMinimizarBandeja.Checked = true;
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\AutoBuild\Tempo.build";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Arquivo Tempo.build não encontrado.");
            }

            try
            {
                var timeOut = Convert.ToInt32(textBoxTimeoutBuild.Text);
                var tempoAtt = Convert.ToInt32(textBoxTempoAtualizacao.Text);

                if (timeOut < 400)
                {
                    MessageBox.Show("Tempo minimo para timeout é 400");
                    return;
                }

                if (tempoAtt < 300000)
                {
                    MessageBox.Show("Tempo minimo para atualização é 300000");
                    return;
                }

                if (timeOut > 300000)
                {
                    MessageBox.Show("Tempo máximo para timeout é 300000");
                    return;
                }

                if (tempoAtt > 1800000)
                {
                    MessageBox.Show("Tempo máximo para atualização é 1800000");
                    return;
                }

                string[] lines = { textBoxTimeoutBuild.Text, textBoxTempoAtualizacao.Text, Convert.ToString(checkBoxBuildOnSave.Checked), Convert.ToString(checkBoxBuildCSSonSave.Checked), Convert.ToString(checkBoxMinimizarBandeja.Checked) };
                System.IO.File.WriteAllLines(filePath, lines);
                MessageBox.Show("Configurações salvas. Reinicie o AutoBuild para aplicar!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao converter valores para inteiro. " + ex.Message);
            }
            this.Close();
        }
    }
}
