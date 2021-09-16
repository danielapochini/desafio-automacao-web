Funcionalidade: EditUsers
	Simple calculator for adding two numbers

Contexto: 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como administrador
	 Então será direcionado a página inicial

Cenário: Editar informações de usuário com sucesso
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Users
	Quando selecionar um usuário existente na lista
	E alterar os campos com novos dados 
	Então deverá retornar a mensagem "Operation successful."

Cenário: Editar informações de usuário - Username Obrigatório
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Users
	Quando selecionar um usuário existente na lista
	E apagar os dados do campo username 
	Então deverá retornar o código de erro "APPLICATION ERROR #805" 
	E a mensagem "The username is invalid. Usernames may only contain Latin letters, numbers, spaces, hyphens, dots, plus signs and underscores." 
	  	  
Cenário: Editar informações de usuário - Username já existente
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Users
	Quando selecionar um usuário existente na lista
	E alterar o username para um valor que já exista no banco de dados
	Então deverá retornar o código de erro "APPLICATION ERROR #800" 
	E a mensagem "That username is already being used. Please go back and select another one." 