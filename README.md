## EShop

Technology Assessment

---

### Used Technologies

*   Net 6.0
*   EFCore 6.0
*   MsSql (to store product, customer, order)
*   Mongo (to store the order snapshot, denormalize data)
*   RabbitMQ (to publish order created event via RabbitMQ, to handle order created event and to create order snapshot)
*   Docker
*   3rd party libraries: Mediatr (to segregate command - query, to isolate business), Ocelot (Api Gateway)

### How to Running

```plaintext
docker-compose up -d
```

To check containers

```plaintext
docker-compose ps
```

To stp all containers of the project

```plaintext
docker-compose down
```

<table><tbody><tr><td><strong>Ocelot Api Gateway</strong></td><td>http://localhost:5000/swagger/index.html</td></tr><tr><td><strong>Customer Api</strong></td><td>http://localhost:5001/swagger/index.html</td></tr><tr><td><strong>Product Api</strong></td><td>http://localhost:5002/swagger/index.html</td></tr><tr><td><strong>Order Api</strong></td><td>http://localhost:5003/swagger/index.html</td></tr><tr><td><strong>Mongo Management Ui</strong></td><td>http://localhost:8081</td></tr></tbody></table>

### Architecture
![Architecture](/architecture/architecture.drawio.png)


### Product Entity Relationship
![Product Entity](/architecture/product.drawio.png)


### Customer And Order Entity Relationship
![Customer And Order Entity](/architecture/CustomerAndOrder.drawio.png)



