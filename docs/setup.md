# Setup inicial do projeto
Documentação de apoio para a configuração e execução do projeto de desenvolvimento do GTA Torcidas utilizando o framework SampSharp.

### Pré Requisitos 🖥
- [GIT](https://git-scm.com/download/win)
- [.NET Core 6](https://dotnet.microsoft.com/pt-br/download/dotnet/thank-you/sdk-6.0.417-windows-x64-installer)
- [.Net Core 6 Runtime x86](https://dotnet.microsoft.com/pt-br/download/dotnet/thank-you/runtime-6.0.25-windows-x86-binaries)
- [Visual studio 2022](https://visualstudio.microsoft.com/pt-br/vs/community/) com .NET Core (Recomendamos instalar em Inglês)
- [Docker](https://docs.docker.com/desktop/install/windows-install/)

### Ferramentas úteis ⚙️
- [Sourcetree](https://www.sourcetreeapp.com/) GIT via modo visual (Recomendamos instalar em Inglês)
- [Cmder](https://cmder.app/) Bash/Terminal para Windows (Recomendamos instalar a versão Full)

## Colocando a mão na massa 
- Faça o clone do repositório usando o GIT por meio do comando:
   - `git clone https://github.com/gtatorcidas/csharp.dev.server` ou por meio do Sourcetree.
- Após fazer o clone, acesse a passta do projeto por meio de um bash/terminal e faça o clone do submódulo que é o repositório que contém os arquivos de um servidor SAMP e que fica na pasta `env` por meio do comando:
  - `git submodule update --init --recursive`
- Crie os containers do banco de dados PostgreSQL usando o comando `docker-compose up -d` dentro da pasta `docker/db`
- Abra o Docker Desktop e ligue os containers do postgres e do pgAdmin4.
- Acesse o [pgAdmin4](http://127.0.0.1:16543/) e faça login usando o e-mail: `admin@postgres.com` e senha `postgres` e adicione o servidor local do postgres.
 - Veja por meio [deste vídeo](https://www.youtube.com/watch?v=UjQiwonRMas) como fazer a conexão no banco de dados por meio do PgAdmin4, você deve-se atentar com o endereço de IP do servidor, o seu provavelmente será algo como 172.19.0.1 ou 172.19.0.2 (IP do Container no docker), caso não seja basta pegar o endereço de IP no Container do docker, você pode por meio [deste vídeo](https://www.youtube.com/watch?v=h1xPPaTNxHI) visualizar como pegar o ip do seu servidor do PostgreSQL. 
 - Crie um banco de dados chamado `gt_dev` no PgAdmin4, [este vídeo](https://www.youtube.com/watch?v=Fb2UHQJMsYQ) deve ajudá-lo.
- Precisamos fazer a configuração do Entity Framework e executar as migrations pra ser criado as tabelas do banco de dados, abra um terminal dentro da pasta `src/Torcidas` no projeto e rode os seguintes comandos:
   - Instalação do Entity Framework: `dotnet tool install --global dotnet-ef --version 7.0.14`
   - Criação da Migration: `dotnet ef migrations add Start —project Torcidas.Infra`
   - Execução da Migartion no banco de dados: `dotnet ef database update —project Torcidas.Infra`
- No Visual Studio 2022 Selecione o projeto Torcidas.UI como principal e execute o `Start Samp Server`
- Abra o SAMP e adicione o servidor de IP: `127.0.0.1:2009`
