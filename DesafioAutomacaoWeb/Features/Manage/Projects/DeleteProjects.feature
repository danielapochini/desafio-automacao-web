Funcionalidade: DeleteProjects 

Contexto: 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como administrador
	 Então será direcionado a página inicial

Cenário: Deletar projeto com sucesso
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Projects
	Quando selecionar um projeto existente na lista
	E clicar no botão de Delete Project
	Então a operação de remoção de projeto deverá ser confirmada 
	E os dados do projeto deverão ser removidos do banco de dados com sucesso