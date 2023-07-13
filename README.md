![image](https://github.com/Jenifferfa/myfinance-web-dotnet/assets/32148606/6b7eb7a5-c9bd-415d-9ac4-3a28567bacd3)

# Descriação do Projeto
MyFinance - Projeto para controle financeiro do curso de Pós-Graduação em engenharia de Software da PUC-MG onde temos a possibilidade de realizar o Cadastro de categorias no plano de contas, Edição de categorias no plano de contas, Cadastro de transações vinculadas a uma categoria, Edição de transações vinculadas a uma categoria.

# Arquitetura utilizada
A arquitetura Onion (Cebola) é baseada em camadas concêntricas, com a camada central contendo as regras de negócio e sendo cercada por camadas que lidam com aspectos técnicos e de infraestrutura. As camadas mais internas são independentes das camadas externas, facilitando a manutenção e a substituição de componentes.

A arquitetura Hexagonal enfatiza a separação das regras de negócio do mundo externo. O núcleo central da aplicação, chamado de hexágono, contém as regras de negócio independentes de detalhes técnicos. Os adaptadores ao redor do hexágono lidam com interações externas, convertendo as solicitações e respostas para que o núcleo possa processá-las.

Ambas as arquiteturas promovem a modularidade, o desacoplamento e a escalabilidade do software, facilitando a manutenção e os testes. No entanto, é importante entender que existem variações nas implementações específicas dessas arquiteturas, e é necessário adaptá-las às necessidades e ao contexto do projeto em questão.

# Tecnologias

* ASP.NET Core MVC
* Entity Framework
* Microsoft SQL Server

# Como configurar para startup do projeto

Instalar o VSCode: https://code.visualstudio.com/download
  a. Instalar as Extensões
  ![image](https://github.com/Jenifferfa/myfinance-web-dotnet/assets/32148606/6a732d8d-ea6c-46dd-a7b0-e8d595471e27)

Instalar o .NET CORE SDK 6.0: https://dotnet.microsoft.com/en-us/download  
  b. Confirmando que .NET Core SDK 6.0 foi instalada corretamente
  ![image](https://github.com/Jenifferfa/myfinance-web-dotnet/assets/32148606/e3f1f0fa-c7d9-43e1-b5f1-ff025aa8f8d7)


