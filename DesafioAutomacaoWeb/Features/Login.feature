#language:pt-br
#encoding:utf-8

Funcionalidade: Login
  
Cenário: Realizar o login com sucesso
	Dado que o usuário acesse a página de login
	Quando preencher com os dados corretos de login e senha
	Então o login deverá ser realizado com sucesso

Cenário: Realizar o login sem sucesso
	Dado que o usuário acesse a página de login
	Quando preencher com os dados incorretos de login e senha
	Então deverá exibir a mensagem "Your account may be disabled or blocked or the username/password you entered is incorrect."

Cenário: Realizar o login com usuário inativo
	Dado que o usuário acesse a página de login
	Quando preencher com os dados
	| username                        | password  |
	| murilo_albuquerque24@bol.com.br | teste1234 |
	Então deverá exibir a mensagem "Your account may be disabled or blocked or the username/password you entered is incorrect."

Cenário: Validação de campo login obrigatório
	Dado que o usuário acesse a página de login
	Quando não preencher com os dados de login
	Então deverá exibir a mensagem "Your account may be disabled or blocked or the username/password you entered is incorrect."

Cenário: Validação de campo senha obrigatório
	Dado que o usuário acesse a página de login
	Quando não preencher com os dados de senha
	Então deverá exibir a mensagem "Your account may be disabled or blocked or the username/password you entered is incorrect."