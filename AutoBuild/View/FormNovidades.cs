using System;
using System.Windows.Forms;

namespace AutoBuild.View
{
    public partial class FormNovidades : Form
    {
        public FormNovidades()
        {
            InitializeComponent();
        }

        private void FormNovidades_Shown(object sender, EventArgs e)
        {
            richTextBoxNovidades.AppendText("Versão 1.13\n");
            richTextBoxNovidades.AppendText(" - Configurar builds permite inserir novo.\n");
            richTextBoxNovidades.AppendText(" - Configuração para tempo de build.\n");
            richTextBoxNovidades.AppendText(" - Ao clicar no botão de build, é disparado uma thread e não trava mais o sistema.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.14\n");
            richTextBoxNovidades.AppendText(" - Inclusão do menu de novidades.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.15\n");
            richTextBoxNovidades.AppendText(" - Sugestão de pasta no cadastro de build.\n");
            richTextBoxNovidades.AppendText(" - Ao cadastrar nova build, atualizar os botões da tela inicial.\n");
            richTextBoxNovidades.AppendText(" - Botão direito opções de compilação.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.16\n");
            richTextBoxNovidades.AppendText(" - Correção na versão.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.17\n");
            richTextBoxNovidades.AppendText(" - Configuração -> Tempo Build -> Build JS on Save.\n");
            richTextBoxNovidades.AppendText(" - Configuração -> Tempo Build -> Build CSS on Save.\n");
            richTextBoxNovidades.AppendText(" - Todas as .Bat da pasta C:\\AutoBuild serão listadas no menu de contexto dos botões.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.18\n");
            richTextBoxNovidades.AppendText(" - Desabilitado build de CSS.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.19\n");
            richTextBoxNovidades.AppendText(" - Corrigido BUG quando o output tinha muitos Warnings.\n");
            richTextBoxNovidades.AppendText(" - Ao sugerir comando para nova build, retirado Msg (Ext 5.6).\n");
            richTextBoxNovidades.AppendText(" - Atualização nas bats (Botão direito no botão) (Ext 5.6).\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.20\n");
            richTextBoxNovidades.AppendText(" - Possibilidade de definir cor para os botões de builds.\n");
            richTextBoxNovidades.AppendText(" - Correção de espaço no build finalizada.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.21\n");
            richTextBoxNovidades.AppendText(" - Bug fix.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.22\n");
            richTextBoxNovidades.AppendText(" - Correção em replace da personalização.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.23\n");
            richTextBoxNovidades.AppendText(" - Melhoria no aproveitamento da tela.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.24\n");
            richTextBoxNovidades.AppendText(" - Botões Mais modernos.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.25\n");
            richTextBoxNovidades.AppendText(" - Informativo do resultado da build.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.26\n");
            richTextBoxNovidades.AppendText(" - Correção bat temas.\n");
            richTextBoxNovidades.AppendText(" - Abrir apenas um exe.\n");
            richTextBoxNovidades.AppendText(" - Config para minimizar para bandeja.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.27\n");
            richTextBoxNovidades.AppendText(" - Carregar parametros na inicialização.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.28\n");
            richTextBoxNovidades.AppendText(" - Nome correto para opção configurações gerais.\n");
            richTextBoxNovidades.AppendText("\n");
            richTextBoxNovidades.AppendText("Versão 1.29\n");
            richTextBoxNovidades.AppendText(" - Autobuild no menu iniciar do Windows.\n");
        }
    }
}
