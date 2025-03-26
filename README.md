# TecnicoBemol
Avaliação Técnica

# OmniConnect

Projeto feito como desafio técnico, tendo foco na criação de contas de usuários com validação de endereço via API do ViaCEP. 
> Por enquanto, a feature implementada é somente o cadastro de usuários, com validação de CEP real conforme foi solicitado.

---

## Tecnologias utilizadas

- ASP.NET Core 8 Web API
- Razor Pages (.NET 8)
- DDD Clássico (Domínio / Aplicação / Infraestrutura)
- SOLID + Design Patterns
- Swagger
- Testes com xUnit + Moq
- HTTP Client + ViaCEP API

---

## Funcionalidade

- Cadastro de usuário com:
  - Nome
  - Email
  - CEP

- Validação de endereço via [https://viacep.com.br](https://viacep.com.br)
- Interface web usando Razor Pages para o usuário preencher os dados para a validação da avaliação

---

## Rodando o Projeto

Precisa do **.NET 8 SDK** instalado.

- Clone o repositório:

https://github.com/ErickARCoelho/TecnicoBemol.git

Abra a solução no Visual Studio 2022.

Configure para rodar dois projetos ao mesmo tempo:

OmniConnect.API

OmniConnect.Web

Botão direito na solução => Configure Startup Projects => marque os dois com Start

Rode com F5

- Acessos
Swagger da API: https://localhost:7147/swagger

Interface web (Razor): https://localhost:7231

Pode variar dependendo da sua porta. Ajuste no launchSettings.json se necessário.

- Considerações finais
Projeto preparado pra receber novas features
A lógica de negócio está encapsulada e separada por camadas

Validações são aplicadas na criação das entidades para garantir a consistência

- Diagrama C4
Realizado no Draw.io => https://app.diagrams.net/

- Respostas do Desafio Técnico – OmniConnect
A solução deve ser disponibilizada em Cloud ou On-premise?
R:Segundo meu conhecimento, a melhor abordagem seria em Cloud por tratar de uma solução que exige
escalabilidade e disponibilidade. Azure ou AWS oferecem Infra e serviços que atendem perfeitamente esse cenário.

Considerando a participação de 4 pessoas técnicas no time, qual ferramenta você usaria para controle de tarefas? A ferramenta é ágil?
R: O AzureDevops é uma ferramenta completa e também ágil e que se encaixa bem nesse cenário.

Você se sente capaz de liderar esta equipe? Por quê?
R: Sim, tenho experiência em boas práticas como DDD, SOLID, Testes e um pouco de CI/CD, o que ainda não sou especialista posso me
aperfeiçoar conforme a necessidade da empresa.

Se pudesse sugerir uma melhoria, mudança ou oportunidade, o que seria?
R: Eu particularmente gostei do desafio, pois foi simples e eficiente em expor a problemática e solicitar a solução, dando liberdade para
execução.

Acha válido esse desafio para o processo que está participando?
R:O desafio foi prático, e bem contextualizado.
