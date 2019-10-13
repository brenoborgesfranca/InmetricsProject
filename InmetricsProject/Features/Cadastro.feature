#language: pt-br

Funcionalidade: Cadastro
	Como usuário
	Desejo me cadastrar na aplicação
	Assim posso usufruir das funcionalidades do mesmo

@mytag
Cenário: 1)  Quando o usuário acessar a página de cadastro, o formulário deverá ser exibido
	
	Dado um visitante não cadastrado que acessou a tela inicial
	Quando Clicar no botão Novo Cadastro
	Então  deverá ser redirecionado para pagina de cadastro
	
Cenário: 2) Campos Obrigatórios disponibilizados no formulário de cadastro
	Dado um visitante não cadastrado que acessou a tela inicial
	Quando Clicar no botão Novo Cadastro
	Então  deverá ser demonstrado os campos obrigatórios do formulário

##Observação: Como não estou utilizando o farker para geração de dados então se o teste rodar mais de uma vÊs, neste cenário é necessário que altere o e-mail.
Cenário: 3) Realizar Cadastro

	Dado um visitante não cadastrado que acessou a tela inicial
	Quando Clicar no botão Novo Cadastro
	E preencher todos os campos do formulário de cadastro corretamente
	| Nome  | Sobrenome | Como gostaria de ser chamado? | Email                      | Veículo | País   | Cidade   | DDD | Telefone | DDD | Celular   | Twitter | Instagram         | Senha           | Confirmação de Senha |
	| Breno | Borges    | Breno                         |novomailtestex@email.com    | Fiesta  | Brasil | Anápolis | 62  | 99259414 | 62  | 992153445 | bfranca | brenoborgesfranca  | @XDFXDFCDFdds# |@XDFXDFCDFdds#        |
	E clicar no botão SOLICITAR CADASTRO
	Então a mensaggem de cadastro com sucesso deverá ser exibida

Cenário: 4) Email já cadastrado

	Dado um visitante não cadastrado que acessou a tela inicial
	Quando Clicar no botão Novo Cadastro
	E preencher todos os campos do formulário de cadastro corretamente
	| Nome  | Sobrenome | Como gostaria de ser chamado? | Email         | Veículo | País   | Cidade   | DDD | Telefone | DDD | Celular   | Twitter | Instagram         | Senha          | Confirmação de Senha |
	| Breno | Borges    | Breno                         |xdd@email.com  | Fiesta  | Brasil | Anápolis | 62  | 99259414 | 62  | 992153445 | bfranca | brenoborgesfranca  | @XDFXDFCDFdds#|@XDFXDFCDFdds#        |
	E clicar no botão SOLICITAR CADASTRO
	Então o sistema ira retornar mensagem de erro pois o e-mail ja existe

Cenário: 5)  Verificar exceções referentes a uma Senha Franca

    Dado um visitante não cadastrado que acessou a tela inicial
	Quando Clicar no botão Novo Cadastro
	E preencher todos os campos do formulário de cadastro corretamente
	| Nome  | Sobrenome | Como gostaria de ser chamado? | Email             | Veículo | País   | Cidade   | DDD | Telefone | DDD | Celular   | Twitter | Instagram          | Senha          | Confirmação de Senha |
	| Breno | Borges    | Breno                         |juniorr@email.com  | Fiesta  | Brasil | Anápolis | 62  | 99259414 | 62  | 992153445 | bfranca | brenoborgesfranca  | 12345678       |12345678              |
	E clicar no botão SOLICITAR CADASTRO
	Então o sistema irá retornar as mensagens de erros informando que a senha é fraca

Cenário: 6) Verificar se o usuário deseja receber releases e informações relativas à TV Globo

	Dado um visitante não cadastrado que acessou a tela inicial
	Quando Clicar no botão Novo Cadastro
	Então o sistema deverá Verificar se o usuário deseja receber releases e informações relativas à TV Globo

Cenário: 7)  Senha sem caracter especial
    Dado um visitante não cadastrado que acessou a tela inicial
	Quando Clicar no botão Novo Cadastro
	E preencher todos os campos do formulário de cadastro corretamente
	| Nome  | Sobrenome | Como gostaria de ser chamado? | Email             | Veículo | País   | Cidade   | DDD | Telefone | DDD | Celular   | Twitter | Instagram          | Senha          | Confirmação de Senha |
	| Breno | Borges    | Breno                         |juniorr@email.com  | Fiesta  | Brasil | Anápolis | 62  | 99259414 | 62  | 992153445 | bfranca | brenoborgesfranca  | SENHAa12322      |SENHAa12322         |
	E clicar no botão SOLICITAR CADASTRO
	Então o sistema irá informar que a senha precisa de um caracter especial

Cenário: 8)  Senhas diferentes
    Dado um visitante não cadastrado que acessou a tela inicial
	Quando Clicar no botão Novo Cadastro
	E preencher todos os campos do formulário de cadastro corretamente
	| Nome  | Sobrenome | Como gostaria de ser chamado? | Email             | Veículo | País   | Cidade   | DDD | Telefone | DDD | Celular   | Twitter | Instagram          | Senha               | Confirmação de Senha |
	| Breno | Borges    | Breno                         |juniorr@email.com  | Fiesta  | Brasil | Anápolis | 62  | 99259414 | 62  | 992153445 | bfranca | brenoborgesfranca  | @SENHAa14322        |@SENHAa1442322        |
	E clicar no botão SOLICITAR CADASTRO
	Então o sistema irá informar que as senhas estão diferentes

Cenário: 9)  Senhas com pelo menos uma letra minúscula
    Dado um visitante não cadastrado que acessou a tela inicial
	Quando Clicar no botão Novo Cadastro
	E preencher todos os campos do formulário de cadastro corretamente
	| Nome  | Sobrenome | Como gostaria de ser chamado? | Email             | Veículo | País   | Cidade   | DDD | Telefone | DDD | Celular   | Twitter | Instagram          | Senha               | Confirmação de Senha |
	| Breno | Borges    | Breno                         |juniorr@email.com  | Fiesta  | Brasil | Anápolis | 62  | 99259414 | 62  | 992153445 | bfranca | brenoborgesfranca  | JOAOJOAO@JOAO       |JOAOJOAO@JOAO         |
	E clicar no botão SOLICITAR CADASTRO
	Então o sistema irá informar que é necessário pelo menos uma letra minuscula

Cenário: 9.1)  Senhas com pelo menos uma letra maiúscula
    Dado um visitante não cadastrado que acessou a tela inicial
	Quando Clicar no botão Novo Cadastro
	E preencher todos os campos do formulário de cadastro corretamente
	| Nome  | Sobrenome | Como gostaria de ser chamado? | Email             | Veículo | País   | Cidade   | DDD | Telefone | DDD | Celular   | Twitter | Instagram          | Senha               | Confirmação de Senha |
	| Breno | Borges    | Breno                         |juniorr@email.com  | Fiesta  | Brasil | Anápolis | 62  | 99259414 | 62  | 992153445 | bfranca | brenoborgesfranca  | joao@joao@joao      |joao@joao@joao        |
	E clicar no botão SOLICITAR CADASTRO
	Então o sistema irá informar que é necessário pelo menos uma letra maiscula



