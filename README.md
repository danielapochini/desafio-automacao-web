# Desafio de Automação Selenium WebDriver - Base2 
  
Projeto realizado para atingir as metas propostas no Desafio Web: Selenium WebDriver da Base2.
## SUT (Software Under Test)
Os testes serão realizados no sistema Mantis Bug Tracker.  
 
Foi necessário instalar as seguintes Docker Image:
 - [MantisBT bug tracker Docker image](https://github.com/okainov/mantisbt-docker)
 - [Selenium Grid Docker images](https://github.com/SeleniumHQ/docker-selenium)

## Tecnologias Utilizadas 
- [Docker](https://www.docker.com/) - Ferramenta para levantar containers através de imagens
- [Jenkins](https://www.jenkins.io/) - Ferramenta para realizar a integracão contínua do projeto na pipeline
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - Linguagem utilizada para o projeto
- [.NET 5](https://dotnet.microsoft.com/learn) - Plataforma de desenvolvimento
- [XUnit](https://xunit.net/) - Framework .NET que auxilia na construção de testes  
- [Selenium.WebDriver](https://www.nuget.org/packages/Selenium.WebDriver) - Framework do Selenium WebDriver para testes automatizados de interface web
- [Specflow](https://docs.specflow.org/projects/specflow/en/latest/) - Framework para realizar a integração com testes em BDD (Gherkin)
- [SpecFlow+LivingDoc](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/) - Plugin que realiza a geração automática de relatórios em formato BDD e que é adaptável
- [WebDriverManager.Net](https://github.com/rosolko/WebDriverManager.Net) - Gerenciador de binários (webdrivers) dos navegadores sem a necessidade de ser instalados na máquina local

## Metas
 - [x]  4) Os casos de testes precisam ser executados em no mínimo três navegadores. Utilizando o
Selenium Grid.
+ Não é necessário executar em paralelo. Pode ser demonstrada a execução dos
browsers separadamente.
+ Não é uma boa prática executar os testes em todos os browsers em uma única
execução. A melhor forma é controlar o browser através de um arquivo de configuração.
  + .NET: normalmente utiliza-se app.config
  + Java: normalmente utiliza-se a classe Properties e cria-se um arquivo chamado
environment.properties
 > As chaves `Browser` e `RemoteDriverExecution` presentes no arquivo `appSettings.json` controlam as configurações de navegador utilizado na execução dos testes e se é uma execução remota (Grid) ou WebDriver (local).
 A classe `BrowserType` possui as Enums dos 04 navegadores que estão aptos a serem executados.
   >  A classe `DriverFactory` controla se a execução será realizada a execução do navegador escolhido via Grid ou localmente, já as classes `LocalDriver` e `RemoteDriver` possuem as configurações dos drivers, a classe `DriverOptions` possui as configurações dos navegadores, a classe `DriverManagement` são configurações que são utilizadas tanto para a execução local quanto remota.
 - [x] 5) Gravar screenshots ou vídeo automaticamente dos casos de testes.
 > O método `TakeScreenShotAfterEveryStep()` na classe `LogHooks` realiza os screenshots durante a execução de cada step em um cenário de testes
 - [x] 6) O projeto deverá gerar um relatório de testes automaticamente com screenshots ou vídeos
embutidos. Sugestões: Allure Report ou ExtentReport.
 > O relatório de testes é gerado no formato BDD através do plugin `SpecFlow.Plus.LivingDocPlugin` e os screenshots são embutidos neste arquivo através da classe `TakeScreenShotAfterEveryStep()`
