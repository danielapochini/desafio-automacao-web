Funcionalidade: EditProjects 

Contexto: 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como administrador
	 Então será direcionado a página inicial

Cenário: Editar projeto com sucesso
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Projects
	Quando selecionar um projeto existente na lista
	E alterar todos os campos com novos dados 
	Então os dados do projeto serão atualizados com sucesso no banco de dados

Cenário: Editar projeto - Nome do projeto Obrigatório
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Projects
	Quando selecionar um projeto existente na lista
	E não preencher o campo de nome do projeto
	E clicar no botão de Update Project
    Então deverá retornar a mensagem de campo obrigatório "Please fill out this field."