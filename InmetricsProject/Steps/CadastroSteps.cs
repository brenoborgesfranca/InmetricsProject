using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using NUnit.Framework;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace TesteInmetrics
{

    [Binding]
    public class CadastroSteps
    {
        //HOOKS
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        IWebDriver Browser;
        private StringBuilder verificationErrors;
       

        [BeforeScenario]
        public void Init()
        {


           //Para escolhero navegador é só setar o driver de sua escolha
           this.Browser = new ChromeDriver ();
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }
        [AfterScenario]
        public void Close()
        {
            this.Browser.Close();
            this.Browser.Dispose();
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\breno\source\repos\InmetricsProject\InmetricsProject\ExtentReport.html");
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }
        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);

        }
        [AfterStep]
        public static void InsertReportingSteps()
        {
            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
        }

        //FINAL HOOKS

        
        //Cenário: 1)  Quando o usuário acessar a página de cadastro, o formulário deverá ser exibido

        [Given(@"um visitante não cadastrado que acessou a tela inicial")]
        public void DadoUmVisitanteNaoCadastradoQueAcessouATelaInicial()
        {
            Browser.Navigate().GoToUrl("https://homologacao.imprensa.globo.com/");
        }

        [When(@"Clicar no botão Novo Cadastro")]
        public void QuandoClicarNoBotaoNovoCadastro()
        {
            Browser.FindElement(By.LinkText("Novo Cadastro")).Click();
        }
        
        [Then(@"deverá ser redirecionado para pagina de cadastro")]
        public void EntaoDeveraSerRedirecionadoParaPaginaDeCadastro()
        {
            try
            {
                Assert.AreEqual("SEUS DADOS", Browser.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Solicitação de cadastro'])[1]/following::h1[1]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

       //# Cenário: 2) Campos Obrigatórios disponibilizados no formulário de cadastro

        [Then(@"deverá ser demonstrado os campos obrigatórios do formulário")]
        public void EntaoDeveraSerDemonstradoOsCamposObrigatoriosDoFormulario()
        {
           
            try
            {
               
                var id_first_name = this.Browser.FindElement(By.Id("id_first_name")).GetAttribute("required");
                var id_last_name = Browser.FindElement(By.Id("id_last_name")).GetAttribute("required");
                var id_como_gostaria_de_ser_chamado = Browser.FindElement(By.Id("id_como_gostaria_de_ser_chamado")).GetAttribute("required");
                var id_sexo = Browser.FindElement(By.Id("id_sexo")).GetAttribute("required");
                var id_username = Browser.FindElement(By.Id("id_username")).GetAttribute("required");
                var id_cargo = Browser.FindElement(By.Id("id_cargo")).GetAttribute("required");
                var id_editoria = Browser.FindElement(By.Id("id_editoria")).GetAttribute("required");
                var id_veiculo = Browser.FindElement(By.Id("id_veiculo")).GetAttribute("required");
                var id_pais = Browser.FindElement(By.Id("id_pais")).GetAttribute("required");
                var id_cidade = Browser.FindElement(By.Id("id_cidade")).GetAttribute("required");
                var id_telefone_ddd = Browser.FindElement(By.Id("id_telefone_ddd")).GetAttribute("required");
                var id_telefone_numero = Browser.FindElement(By.Id("id_telefone_numero")).GetAttribute("required");
                var id_celular_ddd = Browser.FindElement(By.Id("id_celular_ddd")).GetAttribute("required");
                var id_celular_numero = Browser.FindElement(By.Id("id_celular_numero")).GetAttribute("required");
                var id_password1 = Browser.FindElement(By.Id("id_password1")).GetAttribute("required");
                var id_password2 = Browser.FindElement(By.Id("id_password2")).GetAttribute("required");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        //# Cenário: 3) Realizar Cadastro
        [When(@"preencher todos os campos do formulário de cadastro corretamente")]
        public void QuandoPreencherTodosOsCamposDoFormularioDeCadastroCorretamente(Table table)
        {
          
            var nome = this.Browser.FindElement(By.Id("id_first_name")); 
            nome.SendKeys(table.Rows[0][0].ToString()); 

            var sobrenome = Browser.FindElement(By.Id("id_last_name")); 
            sobrenome.SendKeys(table.Rows[0][1].ToString()); 
                
            var apelido = Browser.FindElement(By.Id("id_como_gostaria_de_ser_chamado")); 
            apelido.SendKeys(table.Rows[0][2].ToString());

            var sexo = Browser.FindElement(By.Id("id_sexo"));
            sexo.Click();
            new SelectElement(Browser.FindElement(By.Id("id_sexo"))).SelectByText("Masculino");
            sexo.Click();

            var email = Browser.FindElement(By.Id("id_username")); 
            email.SendKeys(table.Rows[0][3].ToString());

            var cargo = Browser.FindElement(By.Id("id_cargo"));
            cargo.Click();
            new SelectElement(Browser.FindElement(By.Id("id_cargo"))).SelectByText("Articulista");
            cargo.Click();

            var editora = Browser.FindElement(By.Id("id_editoria"));
            editora.Click();
            new SelectElement(Browser.FindElement(By.Id("id_editoria"))).SelectByText("Cadernos Especiais");
            editora.Click();

            var veiculo = Browser.FindElement(By.Id("id_veiculo")); 
            veiculo.SendKeys(table.Rows[0][4].ToString()); 

            var pais = Browser.FindElement(By.Id("id_pais")); 
            pais.SendKeys(table.Rows[0][5].ToString());

            var estado = Browser.FindElement(By.Id("id_estado"));
            editora.Click();
            new SelectElement(Browser.FindElement(By.Id("id_estado"))).SelectByText("GO - Goiás");
            estado.Click();

            var cidade = Browser.FindElement(By.Id("id_cidade")); 
            cidade.SendKeys(table.Rows[0][6].ToString()); 

            var telefone_ddd = Browser.FindElement(By.Id("id_telefone_ddd")); 
            telefone_ddd.SendKeys(table.Rows[0][7].ToString()); 

            var Telefone_numero = Browser.FindElement(By.Id("id_telefone_numero")); 
            Telefone_numero.SendKeys(table.Rows[0][8].ToString());
            
            var celular_ddd = Browser.FindElement(By.Id("id_celular_ddd")); 
            celular_ddd.SendKeys(table.Rows[0][9].ToString()); 

            var celular_numero = Browser.FindElement(By.Id("id_celular_numero")); 
            celular_numero.SendKeys(table.Rows[0][10].ToString());
            
            var twitter = Browser.FindElement(By.Id("id_twitter")); 
            twitter.SendKeys(table.Rows[0][11].ToString()); 

            var instagran = Browser.FindElement(By.Id("id_instagram")); 
            instagran.SendKeys(table.Rows[0][12].ToString()); 

            var password1 = Browser.FindElement(By.Id("id_password1"));
            password1.SendKeys(table.Rows[0][13].ToString());

            var password2 = Browser.FindElement(By.Id("id_password2"));
            password2.SendKeys(table.Rows[0][14].ToString());

            Browser.FindElement(By.Id("id_termos")).Click();
          
            Thread.Sleep(3000);

        }

        [When(@"clicar no botão SOLICITAR CADASTRO")]
        public void QuandoClicarNoBotaoSOLICITARCADASTRO()
        {
            Browser.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sim, desejo receber releases e informações relativas à TV Globo'])[1]/following::button[1]")).Click();
        }

       

        [Then(@"a mensaggem de cadastro com sucesso deverá ser exibida")]
        public void EntaoAMensaggemDeCadastroComSucessoDeveraSerExibida()
        {

            try
            {
                
                Browser.FindElement(By.ClassName("messages"));
                Browser.FindElement(By.ClassName("messages")).GetAttribute("Sucess");

            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
   
        }

        //# Cenário: 4) Email já cadastrado

        [Then(@"o sistema ira retornar mensagem de erro pois o e-mail ja existe")]
        public void EntaoOSistemaIraRetornarMensagemDeErroPoisOE_MailJaExiste()
        {

            try
            {

                Assert.AreEqual("Já existe um cadastro com este e-mail.", Browser.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Email *'])[1]/following::li[1]")).Text);

            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        //# Cenário: 5) Verificar exceções referentes a uma Senha Franca

        [Then(@"o sistema irá retornar as mensagens de erros informando que a senha é fraca")]
        public void EntaoOSistemaIraRetornarAsMensagensDeErrosInformandoQueASenhaEFraca()
        {

            try
            {

               Assert.AreEqual("Esta senha é muito curta. Ela precisa conter pelo menos 10 caracteres.", Browser.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Confirmação de Senha *'])[1]/following::li[1]")).Text);

            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {

                Assert.AreEqual("Esta senha é muito comum.", Browser.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Esta senha é muito curta. Ela precisa conter pelo menos 10 caracteres.'])[1]/following::li[1]")).Text);

            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {

                Assert.AreEqual("Esta senha é inteiramente numérica.", Browser.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Esta senha é muito comum.'])[1]/following::li[1]")).Text);

            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {

                Assert.AreEqual("A senha deve conter pelo menos uma letra maiúscula.", Browser.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Esta senha é inteiramente numérica.'])[1]/following::li[1]")).Text);

            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }


        }

        //	Cenário: 6) Verificar se o usuário deseja receber releases e informações relativas à TV Globo
        [Then(@"o sistema deverá Verificar se o usuário deseja receber releases e informações relativas à TV Globo")]
        public void EntaoOSistemaDeveraVerificarSeOUsuarioDesejaReceberReleasesEInformacoesRelativasATVGlobo()
        {

            try
            {
                Thread.Sleep(3000);
                Assert.AreEqual("Sim, desejo receber releases e informações relativas à TV Globo", Browser.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Li e concordo com os Termos de Uso acima'])[1]/following::label[1]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }


        }

        //# Cenário: 7)  Senha sem caracter especial
        [Then(@"o sistema irá informar que a senha precisa de um caracter especial")]
        public void EntaoOSistemaIraInformarQueASenhaPrecisaDeUmCaracterEspecial()
        {

            try
            {
                Thread.Sleep(3000);
                Assert.AreEqual("A senha deve conter pelo menos um caracter especial.", Browser.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Confirmação de Senha *'])[1]/following::li[1]")).Text);

            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }
        //Cenário: 8)  Senhas diferentes
        [Then(@"o sistema irá informar que as senhas estão diferentes")]
        public void EntaoOSistemaIraInformarQueAsSenhasEstaoDiferentes()
        {
            try
            {
                Thread.Sleep(3000);
                Assert.AreEqual("Os dois campos de senha devem apresentar as mesmas informações.", Browser.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Confirmação de Senha *'])[1]/following::li[1]")).Text);

            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        //Cenário: 9)  Senhas com pelo menos uma letra minúscula

        [Then(@"o sistema irá informar que é necessário pelo menos uma letra minuscula")]
        public void EntaoOSistemaIraInformarQueENecessarioPeloMenosUmaLetraMinuscula()
        {
            try
            {
                Thread.Sleep(3000);
                Assert.AreEqual("A senha deve conter pelo menos uma letra minúscula.", Browser.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Confirmação de Senha *'])[1]/following::li[1]")).Text);

            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        //Cenário: 10)  Senhas com pelo menos uma letra maiúscula
        [Then(@"o sistema irá informar que é necessário pelo menos uma letra maiscula")]
        public void EntaoOSistemaIraInformarQueENecessarioPeloMenosUmaLetraMaiscula()
        {
            try
            {
                Thread.Sleep(3000);
                Assert.AreEqual("A senha deve conter pelo menos uma letra maiúscula.", Browser.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Confirmação de Senha *'])[1]/following::li[1]")).Text);

            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
    }

}

