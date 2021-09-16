Funcionalidade: DeleteUsers 

Contexto: 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como administrador
	 Então será direcionado a página inicial

Cenário: Deletar usuário com sucesso
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Users
	Quando selecionar um usuário existente na lista
	E clicar no botão de Delete User
	Então a operação deverá ser confirmada
	E deverá retornar a mensagem "Operation successful."

Cenário: Restringir botão de deletar para usuário administrador
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Users
	Quando selecionar ele próprio na lista
	Então o botão de Delete User não deverá ser exibido 