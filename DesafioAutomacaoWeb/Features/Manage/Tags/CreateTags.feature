Funcionalidade: CreateTags
 

Contexto: 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como administrador
	 Então será direcionado a página inicial
	 
Cenário: Criar nova categoria com sucesso
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Tags
	Quando preencher os campos
	E clicar no botão de Create Tag
    Então a tag deverá ser criada com sucesso
	  
Cenário: Criar nova categoria - Nome Obrigatório
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Tags
	Quando não preencher o campo de nome obrigatório
	E clicar no botão de Create Tag
    Então deverá retornar a mensagem obrigatória "Please fill out this field."