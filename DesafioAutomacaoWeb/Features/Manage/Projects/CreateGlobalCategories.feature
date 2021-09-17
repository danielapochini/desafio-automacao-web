Funcionalidade: CreateGlobalCategories 

Contexto: 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como administrador
	 Então será direcionado a página inicial
	 
Cenário: Criar nova categoria com sucesso
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Projects 
	Quando preencher o campo de nome da categoria
	E clicar no botão de Add Category
    Então a categoria deverá ser criada com sucesso

Cenário: Criar nova categoria - Nome Obrigatório 
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Projects 
	Quando não preencher o campo de nome da categoria
	E clicar no botão de Add Category
    Então deverá retornar o código de erro "APPLICATION ERROR #11" 
	E a mensagem "A necessary field "Category" was empty. Please recheck your inputs."

Cenário: Criar nova categoria - Nome Já Existente
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Projects 
	Quando preencher o campo de nome da categoria com um valor já existente no banco de dados
	E clicar no botão de Add Category
    Então deverá retornar o código de erro "APPLICATION ERROR #1500" 
	E a mensagem "A category with that name already exists."
