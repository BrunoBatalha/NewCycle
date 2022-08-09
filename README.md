# NewCycle
Um projeto para quem está sempre iniciando ou encerrando ciclos no Linkedin 😛.

### Tecnologias

- Angular
- ASP.NET Core
- MySQL

### Descrição

Um projeto para estudo de Web Crawler com a biblioteca [PuppeteerSharp](https://www.puppeteersharp.com).

O projeto funciona da seguinte forma, no backend existe um Cron Job que executa a cada 6 horas uma rotina na qual roda um Web Crawler 
para buscar as informações no Linkedin relacionadas a ciclos e salvar no banco de dados. O Web Crawler carrega uma certa quantidade de itens e após isso ele começa a coletar os dados, 
sempre verificando se a informação coletada já está no banco de dados.
O frontend consome a API do backend que obtêm um item do banco de dados de forma aleatória, retornando para a tela, permitindo copiar todo o conteúdo.
