# api-livraria-digital
Resolução do Curso de Arquitetura de Backend da Pós-Graduação PUC MINAS.

Api para simular o Backend de uma Livraria Digital na qual é possível alugar um livro ou uma revista.

## Boas práticas em APIs

### 1. Organize APIs ao longo de recursos.
A API foi construída levando em consideração os recursos necessários de acordo com a especificação, esses recursos são: Autores, Comentarios, Editoras, Livros, Pedidos e Usuarios. Todos os recursos são substantivos que representam entidades necessárias para o funcionamento do sistema.

### 2. Padronize as suas APIs.
Todas as URI foram padronizadas seguindo a estrutura /v1/private/RECURSO ou /v1/private/RECURSO/{id}.

### 3. Evite APIs anêmicas.
Para evitar que a API desenvolvida seja considerada anêmica, foram utilizadas Entidades para representações do 'banco de dados' (um singleton no contexto da aplicação desenvolvida) e DTOs para representar os objetos que serão repassados para os clientes. Dessa forma tem-se Entidades que contêm apenas o ID de um relacionamento e o DTO contêm todos os dados dos objetos envolvidos.


### 4. Crie APIs simples.
Todas as URIs da aplicação são simples recurso, recurso/id e ela foi pensada para ser utilizada também com recurso/id/recurso, não sendo necessário nenhuma URI mais complexa do que isso.

### 5. Considere a atualização em lote para operações complexas.
No contexto do exercício não foi necessário a criação de atualizações em lotes, mas seria aconselhado a criação ou atualização dos livros em lotes, caso isso seja uma necessidade do projeto no futuro.

### 6. Se você precisar receber datas e horas nas API, use o padrão ISO 8601.
Também no contexto do exercício não foi utilizada nenhuma data. https://www.w3.org/TR/NOTE-datetime.

### 7. Documente sua API.
A API foi documentada utilizando o Swagger e o pacote Swashbuckle. Ao utilizar o Swashbuckle no .Net Framework é possível gerar a documentação de todas as rotas que utilizam o padrão WebApi 2.1 do .Net Framework, sem a necessidade de registrar os modelos, rotas e verbos manualmente.

### 8. Use protocolo HTTPS/SSL.
Ainda no contexto do exercício não foi necessário a publicação da aplicação, mas caso a aplicação fosse publicada esse seria um requisito não funcional obrigatório.

### 9. Versione suas APIs.
A API construída está preparada para versionamento e a rota atual é a V1

### 10. Estabeleça paginação para coleções com grandes volumes de dados.


### 11. Use corretamente os códigos de retorno HTTP.
