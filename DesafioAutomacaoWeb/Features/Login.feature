#language:pt-br
#encoding:utf-8

Funcionalidade: Login
  
Cenário: Realizar o login com sucesso
	Dado que o usuário acesse a página de login
	Quando preencher com os dados corretos de login e senha
	Então o login deverá ser realizado com sucesso