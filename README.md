# api-livraria-digital
Resolução do execício do Curso de Arquitetura de Backend da Pós-Graduação PUC MINAS.

Api para simular o Backend de uma Livraria Digital na qual é possível alugar um livro ou uma revista.

Autores: Lucas Maciel e Raphael Fernandes.

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
O objeto Livro carrega a informação de sua data de publicação usando a classe DateTime do .NET. Para transferir para o padrão ISO8601, durante a conversão da entidade de 'banco de dados' para DTO, foi utilizada a conversão para string, utilizando o formato adequado.

### 7. Documente sua API.
A API foi documentada utilizando o Swagger e o pacote Swashbuckle. Ao utilizar o Swashbuckle no .Net Framework é possível gerar a documentação de todas as rotas que utilizam o padrão WebApi 2.1 do .Net Framework, sem a necessidade de registrar os modelos, rotas e verbos manualmente.

### 8. Use protocolo HTTPS/SSL.
Ainda no contexto do exercício não foi necessário a publicação da aplicação, mas caso a aplicação fosse publicada esse seria um requisito não funcional obrigatório.

### 9. Versione suas APIs.
A API construída está preparada para versionamento e a rota atual é a V1

### 10. Estabeleça paginação para coleções com grandes volumes de dados.
Como o número de entidades instanciadas inicialmente era pequena, não houve necessidade de implementar paginação.

### 11. Use corretamente os códigos de retorno HTTP.
Foram observados os códigos de retorno HTTP assim como consta na descrição do mesmo. Esse padrão pode ser observado ao buscar o recurso de Autor pelo Id. Inicialmente, tem-se apenas dois autores cadastrados (id = 1 e id = 2). Buscando autores por esses Ids, o sistema retorna com o código de sucesso (200). Buscando autores por códigos não existentes (ex: id = 3), a API retorna uma mensagem HTTP com o código = 404 (não encontrado).