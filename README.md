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
- [x] 2) Alguns scripts devem ler dados de uma planilha Excel para implementar Data-Driven.
 + Quem utilizar Cucumber, SpecFlow ou outra ferramenta de BDD não precisa implementar lendo de uma planilha Excel. Pode ser a implementação de um Scenario Outline.
- [x] 3) Notem que 50 scripts podem cobrir mais de 50 casos de testes se usarmos Data-Driven. Em outras palavras, implementar 50 CTs usando data-driven não é a mesma coisa que implementar 50 scripts
> As features `InviteUsers` e `CreateProjects` implementam Scenario Outlines do Specflow para testes Data-Driven. 
 - [x]  4) Os casos de testes precisam ser executados em no mínimo três navegadores. Utilizando o Selenium Grid.
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
 > O relatório de testes é gerado tanto para a execução local quanto remota no formato BDD através do plugin `SpecFlow.Plus.LivingDocPlugin` e os screenshots são embutidos neste arquivo através do método `TakeScreenShotAfterEveryStep()` na classe `LogHooks`.
 - [x] 7) A massa de testes deve ser preparada neste projeto, seja com scripts carregando massa nova no BD ou com restore de banco de dados.
 > A massa de dados está sendo tratada através do método `DatabaseHelper.ResetMantisDatabase()` que realiza o restore do BD antes da execução dos testes.
 - [x] 8) Um dos scripts deve injetar Javascript para executar alguma operação na tela. O objetivo
aqui é exercitar a injeção de Javascript dentro do código do Selenium.
> O método `CheckCheckBoxJavascript()` criado na classe `CheckBoxHelper` realiza o click de um botão por ação de JavaScript, pois neste caso em específico o Selenium não estava conseguindo realizar o click e estava estourando a expection `ElementClickInterceptedException`, desta forma, utilizando o JavaScript o problema foi sanado.
 - [x] 9) Testes deverão ser agendados pelo Gitlab-CI, Azure DevOps, Jenkins, CircleCI, TFS,
TeamCity ou outra ferramenta de CI que preferir
> Os testes estão implementados na pipeline do Jenkins, após a execução o Relatório LivingDoc é anexado na última execução através do plugin `PublishHTML` no Jenkins. O script de configuração da pipeline está disponível na raiz do projeto. O projeto possui um `webhook` que a cada push realizado no repositório do GitHub é disparado automaticamente um novo build no Jenkins.


## Referências
- [Getting Started with WebDriver C# in 10 Minutes](https://www.automatetheplanet.com/getting-started-webdriver/)
- [UITest with C# and Selenium Grid](https://www.puresourcecode.com/dotnet/uitest-with-c-and-selenium-grid/)
- [Selenium Grid Tutorial: Hub & Node](https://www.guru99.com/introduction-to-selenium-grid.html)
- [BDD with Selenium Webdriver and Specflow using C#](https://www.udemy.com/share/101rvK3@VWk73qt6IfuQLtDS7SexlXDcp36_PJzqLGQ3EhEop5DsS9PgjFRaKbzrHCBhOLXX/)
- [Step-by-step guide for LivingDoc Generator](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/sbsguides/sbscli.html)
- [LivingDoc - Store it in your Continuous Integration Server](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/sharing-and-publishing.html#jenkins)
- [Jenkins - Publish HTML Report](https://www.youtube.com/watch?v=snlxU386wjo)
- [Jenkins - Build Job Automatically on Git Commit - Webhook](https://youtu.be/YkabAT213h0)
- [Backing up Database in MySQL using C#](https://stackoverflow.com/a/12311685)
- [Configuration Files XUnit](https://xunit.net/docs/configuration-files)
- [Configuration Files Specflow](https://docs.specflow.org/projects/specflow/en/latest/Installation/Configuration.html)
