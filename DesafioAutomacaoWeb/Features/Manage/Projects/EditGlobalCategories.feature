Funcionalidade: EditGlobalCategories
 
Contexto: 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como administrador
	 Então será direcionado a página inicial

Cenário: Editar categoria com sucesso
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Projects 
	Quando selecionar uma categoria
	E editar os campos
	Então deverá retornar a mensagem "Operation successful."
    E a categoria deverá ser atualizada com sucesso

Cenário: Editar categoria - Nome Obrigatório
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Projects 
	Quando selecionar uma categoria
	E não preencher o campo de nome
	Então deverá retornar o código de erro "APPLICATION ERROR #11" 
	E a mensagem "A necessary field "name" was empty. Please recheck your inputs." 
	  	  