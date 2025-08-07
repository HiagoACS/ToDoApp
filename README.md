# Projeto ToDo - Sistema Legado com ASP.NET Web API e AngularJS

## Descrição

Este projeto é uma API backend para um sistema **legado** de gerenciamento de tarefas (ToDo), desenvolvido em **ASP.NET Web API** utilizando **.NET Framework 4.6** e banco de dados **PostgreSQL**. 

O frontend do sistema será construído em **AngularJS (1.x)**
## Objetivo

O objetivo deste projeto é manter, evoluir e dar suporte a um sistema legado que já está em produção, preservando a arquitetura original e facilitando a integração com o frontend em AngularJS. 

O sistema permite realizar as operações básicas de CRUD para tarefas, possibilitando a criação, visualização, edição e remoção de itens ToDo.

## Contexto Legado

- Backend em **.NET Framework 4.6** (não .NET Core), utilizando Web API clássica.
- Acesso ao banco é feito via ADO.NET com o driver Npgsql, sem uso de Entity Framework, para manter simplicidade e compatibilidade.
- Frontend em **AngularJS 1.x**, um framework anterior ao Angular 2+, com conceitos diferentes de componentes e arquitetura.
- Estrutura de código baseada em Controllers, Repositories e Models típicos do padrão MVC/Web API.

## Tecnologias Utilizadas

- Backend: ASP.NET Web API (.NET Framework 4.6)
- Banco de Dados: PostgreSQL
- Acesso ao BD: Npgsql (driver ADO.NET)
- Frontend: AngularJS 1.x

## Porque manter este sistema?

Embora tecnologias mais modernas existam, sistemas legados são comuns em ambientes corporativos.

Os objetivos são:

- Manter a operação estável sem grandes reescritas
- Garantir a continuidade do negócio
- Evoluir funcionalidades sem romper o sistema existente
- Aprender sobre arquitetura e integração de sistemas mais antigos

## Como usar este projeto

- O backend expõe uma API REST para gerenciamento dos ToDos
- O frontend AngularJS irá consomir essa API para apresentar a interface e interagir com o usuário
- O projeto pode ser usado para estudo sobre sustentação de sistemas legados, integração Web API + AngularJS e acesso manual ao banco com Npgsql

## Próximos passos

- Aprimorar a interface AngularJS com melhores práticas
- Adicionar autenticação básica no backend e frontend
- Criar testes automatizados para backend e frontend
- Evoluir para arquitetura mais moderna aos poucos, se possível

---

Projeto desenvolvido para fins de estudo, aprendizado e preparação sobre sistemas legados.
Qualquer dúvida ou sugestão, fique à vontade para abrir issues ou entrar em contato.
