Funcionalidade: ManagePermissions 

Cenário: Permissão de Acesso - Administrator 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como administrador
	 E acessar a página de gerenciamento 
	 Então possuirá acesso completo ao gerenciamento do sistema

Cenário: Permissão de Acesso - Manager 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como manager
	 E acessar a página de gerenciamento
	 Então não possuirá acesso completo ao gerenciamento do sistema
	 Mas possuirá acesso a area de gerenciamento de projetos

Cenário: Permissão de Acesso - Developer
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como developer
	 Então será direcionado a página inicial 
	 E possuirá acesso para assignar tarefas

Cenário: Permissão de Acesso - Updater
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como updater
	 Então será direcionado a página inicial 
	 E possuirá acesso para atualizar as tarefas

Cenário: Permissão de Acesso - Reporter 
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como reporter
	 Então será direcionado a página inicial  
	 E possuirá acesso para reportar tarefas 
	  
Cenário: Permissão de Acesso - Viewer
	 Dado que o usuário acesse o Mantis
	 Quando efetuar o login como viewer
	 Então será direcionado a página inicial 
	 E possuirá acesso apenas para visualizar tarefas