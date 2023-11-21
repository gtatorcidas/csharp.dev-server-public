# Repositório oficial de Desenvolvimento do GameMode do GTA Torcidas

### Pré Requisitos 🖥
- [GIT](https://git-scm.com/download/win)
- [.NET Core 6](https://dotnet.microsoft.com/pt-br/download/dotnet/thank-you/sdk-6.0.417-windows-x64-installer)
- [.Net Core 6 Runtime x86](https://dotnet.microsoft.com/pt-br/download/dotnet/thank-you/runtime-6.0.25-windows-x86-binaries)
- [Visual studio 2022](https://visualstudio.microsoft.com/pt-br/vs/community/) com .NET Core (Recomendamos instalar em Inglês)

### Ferramentas úteis ⚙️
- [Sourcetree](https://www.sourcetreeapp.com/) GIT via modo visual (Recomendamos instalar em Inglês)
- [Cmder](https://cmder.app/) Bash/Terminal para Windows (Recomendamos instalar a versão Full)

### Como fazer a configuração do projeto?
- Faça o clone do repositório usando o GIT por meio do comando:
   - `git clone https://github.com/gtatorcidas/csharp.server` ou por meio do Sourcetree.
- Após fazer o clone, acesse a passta do projeto por meio de um bash/terminal e faça o clone do submódulo que é o repositório que contém os arquivos de um servidor SAMP e que fica na pasta `env` por meio do comando:
  - `git submodule update --init --recursive`
- No Visual Studio 2022 Selecione o projeto Torcidas.UI como principal e execute o `Start Samp Server`
- Abra o SAMP e adicione o servidor de IP: `127.0.0.1:2009`

### Links importantes 📜
- [Documentação oficial do SampSharp (S#)](https://sampsharp.net/)
- [Exemplo de GameMode com S# Entities by @SampSharp](https://github.com/SampSharp/sample-ecs-grandlarc)
- [Exemplo de GameMode com S# Entities by @CiprianN23](https://github.com/CiprianN23/PrisonRP)
- [Link do Discord do Sampsharp](https://discord.gg/gwcHpqp)
- [Link do Nosso Discord](https://discord.gg/sWyDf3SR)
