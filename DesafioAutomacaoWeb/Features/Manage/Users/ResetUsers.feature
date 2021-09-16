Funcionalidade: ResetUsers 

Contexto: 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como administrador
	 Então será direcionado a página inicial

Cenário: Resetar senha de usuário com sucesso
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Users
	Quando selecionar um usuário existente na lista
	E clicar no botão de Reset Password
	Então deverá retornar "A confirmation request has been sent to the selected user's e-mail address. Using this, the user will be able to change their password."

Cenário: Restringir botão de resetar senha para usuário administrador
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Users
	Quando selecionar ele próprio na lista
	Então o botão de Reset User não deverá ser exibido 