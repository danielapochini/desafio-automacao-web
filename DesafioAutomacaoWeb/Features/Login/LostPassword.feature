Funcionalidade: LostPassword

Cenário: Recuperar a senha com sucesso
	Dado que o usuário acesse a página de login
	Quando preencher com os dados corretos de login
	E clicar no botão de Esqueci minha Senha
	E preencher os dados de e-mail corretamente
	Então deverá retornar para a página de login

	Cenário: Recuperar a senha - Informações Incorretas
	Dado que o usuário acesse a página de login
	Quando preencher com os dados corretos de login
	E clicar no botão de Esqueci minha Senha
	E preencher os dados com um e-mail que não esteja atribuido ao usuário
	Então deverá retornar o código de erro "APPLICATION ERROR #1903" 
	E a mensagem "The provided information does not match any registered account!" 

Cenário: Recuperar a senha - Campo Username Obrigatório
	Dado que o usuário acesse a página de login
	Quando preencher com os dados corretos de login 
	E clicar no botão de Esqueci minha Senha
	E apagar os dados do campo de username
	E preencher os dados de e-mail corretamente
    Então deverá retornar o código de erro "APPLICATION ERROR #1903" 
	E a mensagem "The provided information does not match any registered account!" 

Cenário: Recuperar a senha - Campo E-mail Obrigatório
	Dado que o usuário acesse a página de login
	Quando preencher com os dados corretos de login
	E clicar no botão de Esqueci minha Senha
	E não preencher os dados de e-mail  
	Então deverá retornar o código de erro "APPLICATION ERROR #1200" 
	E a mensagem "Invalid e-mail address." 
	
Cenário: Recuperar a senha - Campo E-mail Inválido
	Dado que o usuário acesse a página de login
	Quando preencher com os dados corretos de login
	E clicar no botão de Esqueci minha Senha
	E preencher os dados de e-mail no formato inválido
	Então deverá retornar o código de erro "APPLICATION ERROR #1200" 
	E a mensagem "Invalid e-mail address." 