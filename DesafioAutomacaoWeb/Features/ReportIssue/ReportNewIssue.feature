Funcionalidade: ReportNewIssue 
 
Contexto: 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como reporter
	 Então será direcionado a página inicial

Cenário: Criar novo bug com sucesso
	Dado que o usuário acesse a página de Reportar Issue 
	Quando preencher todos os campos 
	E clicar no botão de Submit Issue 
	Então deverá retornar a mensagem "Operation successful."
    E o bug deverá ser criado com sucesso no banco de dados
	 
Cenário: Criar novo projeto - Summary Obrigatório
	Dado que o usuário acesse a página de Reportar Issue   
	Quando não preencher o campo de Summary
	E clicar no botão de Submit Issue 
    Então deverá retornar a mensagem de validação de campo obrigatório "Please fill out this field."

	Cenário: Criar novo projeto - Category Obrigatório
	Dado que o usuário acesse a página de Reportar Issue   
	Quando não selecionar o campo de Category
	E clicar no botão de Submit Issue 
    Então deverá retornar o código de erro "APPLICATION ERROR #11" 
	E a mensagem "A necessary field "category" was empty. Please recheck your inputs."
