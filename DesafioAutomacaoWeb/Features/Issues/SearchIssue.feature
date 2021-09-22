Funcionalidade: SearchIssue
 
Contexto: 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como manager
	 Então será direcionado a página inicial

Cenário: Buscar issue com sucesso 
	Quando preencher o campo de busca com um id existente no banco de dados
	Então deverá retornar a página com a issue desejada

Cenário: Buscar issue - Valor não existente
	Quando preencher o campo de busca com um id que não exista no banco de dados
	Então deverá retornar o código de erro "APPLICATION ERROR #1100" 
	E a mensagem "Issue 6 not found."
	 
Cenário: Buscar issue - Campo inválido
	Quando preencher o campo de busca com um valor não numérico
	Então deverá retornar o código de erro "APPLICATION ERROR #203" 
	E a mensagem "A number was expected for bug_id."
	 