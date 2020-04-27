
using System;
using System.IO;

namespace AutoBuild.Controller
{
    public class CriadorArquivosBat
    {
        private bool DeveCriarArquivo(string path)
        {
            if (File.Exists(path))
            {
                var file = new FileInfo(path);
                var dataUltimaAlteracaoComandoBuild = new DateTime(2019, 7, 22);
                if (file.LastWriteTime > dataUltimaAlteracaoComandoBuild)
                {
                    return false;
                }
            }

            return true;
        }

        public void RenomeiaBats()
        {
            if (File.Exists(@"C:\AutoBuild\ColarNaPastaWeb_LimpaCacheBaixaCoreBuildSistema.bat"))
                File.Move(@"C:\AutoBuild\ColarNaPastaWeb_LimpaCacheBaixaCoreBuildSistema.bat", @"C:\AutoBuild\SyncCore_BatBaluda.bat");

            if (File.Exists(@"C:\AutoBuild\CompilarTemaFontes.bat"))
                File.Move(@"C:\AutoBuild\CompilarTemaFontes.bat", @"C:\AutoBuild\CompilarTema_Fontes.bat");

            if (File.Exists(@"C:\AutoBuild\CompilarTemaCompleto.bat"))
                File.Move(@"C:\AutoBuild\CompilarTemaCompleto.bat", @"C:\AutoBuild\CompilarTema_Completo.bat");
        }

        public void CriaBatCompilarFront()
        {
            try
            {
                const string filePath = @"C:\AutoBuild\CompilarFront.bat";

                if (!this.DeveCriarArquivo(filePath))
                    return;

                string[] lines =
                {
                    @"sencha compile --classpath=app.js exclude -namespace Ext,Use,Docs,Msg and include -namespace Ext.theme,Ext.locale and concat build/testing/App/app.js"
                };
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao criar CompilarTema_Fontes.bat. Erro: " + e.Message);
            }
        }


        public void CriaBatTemaFontes()
        {
            try
            {
                const string filePath = @"C:\AutoBuild\CompilarTema_Fontes.bat";

                if (!this.DeveCriarArquivo(filePath))
                    return;

                string[] lines =
                {
                    @"cd .\packages\local\app-theme",
                    @"sencha ant sass"
                };
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao criar CompilarTema_Fontes.bat. Erro: " + e.Message);
            }
        }

        public void CriaBatTemaCompleto()
        {
            try
            {
                const string filePath = @"C:\AutoBuild\CompilarTema_Completo.bat";

                if (!this.DeveCriarArquivo(filePath))
                    return;

                string[] lines =
                {
                    @"rd packages\remote\uxtheme /s/q",
                    @"rd packages\remote\uxtheme /s/q",
                    @"cd .\packages\local\app-theme",
                    @"sencha package build"
                };
                File.WriteAllLines(filePath, lines);

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao criar CompilarTema_Completo.bat. Erro: " + e.Message);
            }
        }

        public void CriaBatBaluda()
        {
            try
            {
                const string filePath = @"C:\AutoBuild\SyncCore_BatBaluda.bat";

                if (!this.DeveCriarArquivo(filePath))
                    return;

                string[] lines =
                {
                    @"rd packages\remote /s/q",
                    @"rd packages\remote /s/q",
                    @"sencha repo add Useall http://servertfs:8181/extpkgs",
                    @"sencha repo init -name Useall -email useall@useall.com.br",
                    @"sencha repo sync",
                    @"sencha app clean",
                    @"sencha app refresh -packages",
                    @"cd .\packages\local\app-theme",
                    @"sencha package build",
                    @"cd ../../../",
                    @"sencha app build testing",
                    @"sencha compile --classpath=app.js exclude -namespace Ext,Use,Docs,Msg and include -namespace Ext.theme,Ext.locale and concat build/testing/App/app.js"
                };
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao criar SyncCore_BatBaluda.bat. Erro: " + e.Message);
            }
        }
    }
}
