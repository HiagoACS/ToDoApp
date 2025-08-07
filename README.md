# Projeto ToDo - Sistema Legado com ASP.NET Web API e AngularJS

## Descri��o

Este projeto � uma API backend para um sistema **legado** de gerenciamento de tarefas (ToDo), desenvolvido em **ASP.NET Web API** utilizando **.NET Framework 4.6** e banco de dados **PostgreSQL**. 

O frontend do sistema ser� constru�do em **AngularJS (1.x)**
## Objetivo

O objetivo deste projeto � manter, evoluir e dar suporte a um sistema legado que j� est� em produ��o, preservando a arquitetura original e facilitando a integra��o com o frontend em AngularJS. 

O sistema permite realizar as opera��es b�sicas de CRUD para tarefas, possibilitando a cria��o, visualiza��o, edi��o e remo��o de itens ToDo.

## Contexto Legado

- Backend em **.NET Framework 4.6** (n�o .NET Core), utilizando Web API cl�ssica.
- Acesso ao banco � feito via ADO.NET com o driver Npgsql, sem uso de Entity Framework, para manter simplicidade e compatibilidade.
- Frontend em **AngularJS 1.x**, um framework anterior ao Angular 2+, com conceitos diferentes de componentes e arquitetura.
- Estrutura de c�digo baseada em Controllers, Repositories e Models t�picos do padr�o MVC/Web API.

## Tecnologias Utilizadas

- Backend: ASP.NET Web API (.NET Framework 4.6)
- Banco de Dados: PostgreSQL
- Acesso ao BD: Npgsql (driver ADO.NET)
- Frontend: AngularJS 1.x

## Porque manter este sistema?

Embora tecnologias mais modernas existam, sistemas legados s�o comuns em ambientes corporativos.

Os objetivos s�o:

- Manter a opera��o est�vel sem grandes reescritas
- Garantir a continuidade do neg�cio
- Evoluir funcionalidades sem romper o sistema existente
- Aprender sobre arquitetura e integra��o de sistemas mais antigos

## Como usar este projeto

- O backend exp�e uma API REST para gerenciamento dos ToDos
- O frontend AngularJS ir� consomir essa API para apresentar a interface e interagir com o usu�rio
- O projeto pode ser usado para estudo sobre sustenta��o de sistemas legados, integra��o Web API + AngularJS e acesso manual ao banco com Npgsql

## Pr�ximos passos

- Aprimorar a interface AngularJS com melhores pr�ticas
- Adicionar autentica��o b�sica no backend e frontend
- Criar testes automatizados para backend e frontend
- Evoluir para arquitetura mais moderna aos poucos, se poss�vel

---

Projeto desenvolvido para fins de estudo, aprendizado e prepara��o sobre sistemas legados.
Qualquer d�vida ou sugest�o, fique � vontade para abrir issues ou entrar em contato.
