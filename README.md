# Desafio Inmetrics

Este projeto de teste foi desenvolvido utilizando [Specflow](https://specflow.org/),[Nunit](https://nunit.org/), e C# para executar cenários de aceitação.


## 1. Pré Requisitos

[Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/vs/?rr=https%3A%2F%2Fwww.google.com%2F) e
[SpecFlow for Visual Studio 2019](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowForVisualStudio)

Certifique-se que  Visutal Studio e O Puglin do SpecFlow foram instalados corretamente e siga os próximos passos.

## 2. Como inicializar o projeto

1. Clone o repositório => `git clone https://github.com/brenoborgesfranca/InmetricsProject.git`
2. `Abra o Visual Studio`.
3. `Abra um Projeto ou uma Solução Exitente`.
4. `Abra o Projeto InmetricsProject.sln`.
5. `Aguarde até que todas dependecias sejam carregadas`.
5. `Clique na guia Teste em seguida executar todos os testes`.

## 3. Extent Reports - Relatório de Testes Automatizados

Este projeto utiliza o [Extent Reports](http://extentreports.com/) para gerar relatório dos testes automatizados.

Então para configurar o relatório de testes, é necessário configurar o ficheiro para salvar o relatório de testes automatizados.

Para isso acesse a pasta Steps no projeto, em seguida abra a classe CadadtroSteps.cs, e no método `public static void InitializeReport()`
adicione o caminho do ficheiro.

`var htmlReporter = new ExtentHtmlReporter(@"C:\Users\breno\source\repos\InmetricsProject\InmetricsProject\ExtentReport.html");`

![alt text](https://github.com/brenoborgesfranca/InmetricsProject/blob/master/ExtentHtml.PNG)


Para conferir o Relatório de Teste, vá até o ficheiro configurado e abra o Arquivo ExtentReport.html

## 4. Selecionando o Browser de sua escolha para rodar os testes

Para configurar o brownser para rodar os testes acesse a pasta Steps no projeto, em seguida abra a classe CadadtroSteps.cs, e no método `public void Init()`
adicione o driver do navegador desejado:

Lembrando que é necessário que os navegadores estejam instalados em sua máquina.

Exemplo: Chrome
`  this.Browser = new ChromeDriver ();`
Exemplo: Firefox
`  this.Browser = new FirefoxDriver ();`
Exemplo: Edge
`this.Browser = new EdgeDriver ();`

## 5. Algumas Observações
Como não utilizo o faker para geração de dados, No cenário 3, Caso o teste já tenha sido executado uma vez, é necessário que altere o e-mail do usuário para ser aprovado, pois o sistema não permite cadastrar mais de um usuário com o mesmo e-mail.
