# Projeto ToDo - Sistema Legado com ASP.NET Web API e AngularJS

## Descri��o

Este projeto consiste em um sistema completo para gerenciamento de tarefas (ToDo), com backend desenvolvido em **ASP.NET Web API** usando **.NET Framework 4.6** e banco de dados **PostgreSQL**, e frontend implementado em **AngularJS 1.8.3**.

O sistema permite realizar as opera��es b�sicas de CRUD (criar, ler, atualizar e deletar) de tarefas, integrando uma API REST no backend com um frontend responsivo e funcional em AngularJS.

## Objetivo

O objetivo deste projeto � fornecer uma base s�lida para entender como integrar um backend ASP.NET Web API com um frontend AngularJS, al�m de demonstrar pr�ticas comuns em sistemas legados, como acesso a banco de dados via ADO.NET e uso de APIs RESTful.

## Contexto Legado

- Backend baseado em **.NET Framework 4.6** com ASP.NET Web API cl�ssica.
- Acesso ao banco PostgreSQL feito manualmente via ADO.NET com driver Npgsql, sem Entity Framework.
- Frontend constru�do com **AngularJS 1.8.3**, um framework anterior ao Angular moderno, adotando conceitos de controllers e data binding.
- Arquitetura tradicional MVC/Web API com controllers, models e servi�os.

## Tecnologias Utilizadas

- **Backend:** ASP.NET Web API (.NET Framework 4.6)
- **Banco de Dados:** PostgreSQL
- **Driver de acesso:** Npgsql (ADO.NET)
- **Frontend:** AngularJS 1.8.3 via CDN
- **Comunica��o:** API REST

## Funcionalidades

- Listar tarefas
- Criar novas tarefas
- Editar tarefas existentes (t�tulo e status)
- Marcar tarefas como conclu�das ou pendentes
- Remover tarefas individuais
- Limpar todas as tarefas ou somente as conclu�das
- Filtros para visualizar tarefas ativas, conclu�das ou todas

## Como usar

1. Configure e rode o backend ASP.NET Web API na porta configurada (ex: 44312, usada nesse projeto).
2. Abra o frontend (index.html) em um servidor local ou navegador.
3. A interface consumir� a API REST para manipular as tarefas em tempo real.
4. CORS est� configurado no backend para permitir chamadas do frontend.

## Por que manter um sistema legado?

- Sistemas legados s�o comuns em ambientes corporativos e precisam de manuten��o e evolu��o cont�nuas.
- Preservar a estabilidade sem grandes reescritas facilita a continuidade do neg�cio.
- Projeto serve para estudo de arquitetura, integra��o e sustenta��o de sistemas mais antigos.

---

Projeto finalizado e funcional, desenvolvido para estudo e manuten��o de sistemas legados.  
