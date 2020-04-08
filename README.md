# web-app-clientes
👨‍🦱 App Web para cadastro clientes utilizando CQRS com bancos PostgreSQL e MongoDB.

Aplicação web criada em ASP NET Core utilizando o padrão arquitetural CQRS. A divisão de responsabilidade de gravação e leitura está separada de forma conceitual e física, sendo utilizado os bancos PostgreSQL e MongoDb. A estratégia de sincronização adotada foi a **atualização automática**, ou seja, toda alteração de estado do banco de gravação dispara um processo síncrono para atualização do banco de leitura.

Abaixo, segue diagrama de como está separado as camadas do Projeto:

![](https://github.com/rafaeldalsenter/web-app-clientes/blob/master/diagrama.png)

Há um arquivo **docker-compose** para subir o ambiente, o mesmo subirá a aplicação e os bancos PostgreSQL e MongoDB, só rodar :)

```
docker-compose up --build -d
```
