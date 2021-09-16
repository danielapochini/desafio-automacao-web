Funcionalidade: CreateProject
 
Contexto: 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como administrador
	 Então será direcionado a página inicial

Esquema do Cenário: Criar novos projetos com sucesso
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Projects
	Quando clicar no botão de criar novo projeto
	E preencher os dados dos campos <name>, <status>, <globalCategory>, <viewstatus>, <description> do novo projeto  
	Então deverá retornar a mensagem "Operation successful."
	E o projeto deverá ser criado com sucesso no banco de dados

Exemplos:
	| name                         | status      | globalCategory | viewstatus | description                       |
	| Projeto Automação Web        | stable      | true           | private    | Teste criação novo projeto        |
	| Projeto Automação Web Dois   | release     | false          | public     | Teste criação novo projeto dois   |
	| Projeto Automação Web Três   | obsolete    | true           | private    | Teste criação novo projeto três   |
	| Projeto Automação Web Quatro | development | false          | public     | Teste criação novo projeto quatro |