# csharp-dev.server
#### Repositório oficial de desenvolvimento do GTA Torcidas

### Pré Requisitos 🖥
- Visual studio 2022 com .NET Core
- .NET Core 6
- .Net Core 6 Runtime x86


### Como fazer a configuração do projeto?
- Faça o clone do repositório usando o Git
- Após fazer o clone, acesse a passta do projeto por meio de um bash/terminal e faça o clone do submódulo que é o repositório que contém os arquivos de um servidor SAMP e que fica na pasta `env` por meio do comando: `git submodule update --init --recursive`
- No Visual Studio 2022 Selecione o projeto Torcidas.UI como principal e execute o `Start Samp Server`
- Abra o SAMP e adicione o servidor de IP: `127.0.0.1:2009`

### Links importantes 📜
- [Documentação oficial do SampSharp (S#)](https://sampsharp.net/)
- [Exemplo de GameMode com S# Entities by @SampSharp](https://github.com/SampSharp/sample-ecs-grandlarc)
- [Exemplo de GameMode com S# Entities by @CiprianN23](https://github.com/CiprianN23/PrisonRP)
- [Link do Discord do Sampsharp](https://discord.gg/gwcHpqp)

