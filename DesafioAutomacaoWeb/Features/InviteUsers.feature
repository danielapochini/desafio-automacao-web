Funcionalidade: InviteUsers
 
Contexto: 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como administrador
	 Então será direcionado a página inicial

Cenário: Criar um novo usuário com sucesso
	Dado que o usuário acesse a página de criar novos usuários
	Quando preencher os dados da nova conta 
	Então o usuário será criado com sucesso

Esquema do Cenário: Criar novos usuários com sucesso
	Dado que o usuário acesse a página de criar novos usuários
	Quando preencher os dados de <username>, <realname>, <email>, <acesso> da nova conta  
	Então será exibida a mensagem de sucesso "Created user <username> with an access level of <acesso>"

Exemplos:
	| username      | realname        | email             | acesso    |
	| user.selenium | Pessoa Teste    | valid01@email.com | viewer    |
	| user.auto     | Segunda Pessoa  | valid02@email.com | developer |
	| user.novo     | Terceira Pessoa | valid03@email.com | manager   |

Cenário: Criar um novo usuário - Username já existente
	Dado que o usuário acesse a página de criar novos usuários
	Quando preencher os dados utilizando um username que já exista
    Então deverá retornar o código de erro "APPLICATION ERROR #800" 
	E a mensagem "That username is already being used. Please go back and select another one." 

Cenário: Criar um novo usuário - Username Obrigatório
	Dado que o usuário acesse a página de criar novos usuários
	Quando não preencher o campo de username
    Então deverá retornar o código de erro "APPLICATION ERROR #805" 
	E a mensagem "The username is invalid. Usernames may only contain Latin letters, numbers, spaces, hyphens, dots, plus signs and underscores." 

Cenário: Criar um novo usuário - Username Inválido
	Dado que o usuário acesse a página de criar novos usuários
	Quando preencher o campo de username com caracteres inválidos
    Então deverá retornar o código de erro "APPLICATION ERROR #805" 
	E a mensagem "The username is invalid. Usernames may only contain Latin letters, numbers, spaces, hyphens, dots, plus signs and underscores." 
