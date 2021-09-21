Funcionalidade: DeleteGlobalCategories 


Contexto: 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como administrador
	 Então será direcionado a página inicial

Cenário: Deletar Categoria - Categoria Principal
	Dado que o usuário acesse a página de gerenciamento
	E selecione a aba Manage Projects 
	Quando selecionar a categoria  
	E clicar no botão de Delete Category
	Então deverá retornar o código de erro "APPLICATION ERROR #1504" 
	E a mensagem "This Category cannot be deleted, because it is defined as "Default Category For Moves"." 