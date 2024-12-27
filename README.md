<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>

<h1>FinanceTracker</h1>

<p>FinanceTracker é um aplicativo de finanças pessoais que permite aos usuários gerenciar suas despesas de forma simples e eficiente. Com ele, você pode criar categorias personalizadas para suas despesas e registrar cada lançamento, ajudando a ter uma visão clara das suas finanças.</p>

<p><strong>Nota:</strong> A versão original do FinanceTracker foi desenvolvida com Java e Spring, mas foi reescrita em C# e .NET para fins didáticos</p>

<h2>Funcionalidades</h2>
<ul>
    <li><strong>Criação de Categorias:</strong> Organize suas despesas criando categorias personalizadas.</li>
    <li><strong>Registro de Despesas:</strong> Lance suas despesas de forma rápida e fácil, associando-as a categorias específicas.</li>
    <li><strong>Autenticação:</strong> Acesse sua conta de forma segura e mantenha suas informações protegidas.</li>
    <li><strong>Envio de Email de Verificação:</strong> O aplicativo utiliza o Brevo para envio de emails de verificação.</li>
</ul>

<h2>Como Usar</h2>
<ol>
  <li>
    <strong>Clone o repositório:</strong><br>
    <code>git clone git@github.com:LeonardoAns/finance_tracker_cs.git</code>
  </li>
  <li>
    <strong>Navegue até o diretório do projeto:</strong><br>
    <code>cd finance-tracker</code>
  </li>
  <li>
    <strong>Compile e instale as dependências:</strong><br>
    <code>dotnet restore</code>
  </li>
  <li>
    <strong>Execute a aplicação:</strong><br>
    <code>dotnet run</code>
  </li>
</ol>

<h2>Estrutura do Projeto</h2>
<pre>
├── Core
│   └── Finance.Domain
├── Persistence
│   └── Finance.Persistence
├── Application
│   ├── Finance.Application
│   └── Finance.Exception
└── Presentation
    ├── Finance.Api
    └── Finance.Communication
</pre>

</body>
</html>
