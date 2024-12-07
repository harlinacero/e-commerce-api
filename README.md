# Implementación de Patrones de Diseño Singleton, Factory, y Observer

## Patrón Singleton
Se ha creado la clase `SystemConfiuration` para obtener los parámetros de configuración de la aplicaicón, como la cadena de conexión con la base de datos y otras en el archivo appsettings.json.
Con el fin de cargar una única vez esta configuración durante todo el ciclo de vida la clase `SystemConfiuration` implemente el patrón `Singleton`, al tener un constructor privado que impida que se creen nuevas instancia por fuera de la clase.
De esta forma, mediante el método GetInstance se crea verifica la creación de la única instancia. De esta forma, las clases que deseen utilizar estas configuraciones no pueden crear objetos nuevos.

![Captura de pantalla 2024-12-06 181822](https://github.com/user-attachments/assets/74de1200-87b2-461d-91d1-d16a136ff95a)

![image](https://github.com/user-attachments/assets/04156318-d13d-4d0e-b28e-f722f9651506)

Las clases `DigitalInventoryManager` y `PhysicalInventoryManager` también implementan este patrón, ya que al ser las clases que controlan los inventarios en la memoria del ciclo de vida, deben inicializarse una sola vez.

## Patrón Factory
Con el fin de centralizar la creación de productos en una única clase, se ha implementado el patrón factory, con la clase `ProductFactoory`. Esta clase estática recibe como parámetro un Enumerador con el tipo de producto a crear, de esta forma
crea un producto Concreto. Este método retorna un ProductoBase para poder acceder a los métodos implementados por las clases hijas correspondientes.

![image](https://github.com/user-attachments/assets/f103d8ef-d15e-4aa7-918d-d7337e764ea3)

![image](https://github.com/user-attachments/assets/3c8ea148-56c4-4f04-9adb-2b10d7d758ec)

Dado que ambas clases heredan los atributos y métodos de la clase base, pueden comportarse como ella.

![image](https://github.com/user-attachments/assets/06ad4f14-35cd-41b9-916f-7de379b93477)

Por otro lado, también se ha implementado esta misma lógica en la creación de Inventarios concretos, esto es, `DigitalInventoryManager` y `PhysicalInventoryManager` como implementaciones concretas de la clase `InventoryManager`.
De esta forma, también se delega la responsabilidad de la creación de estos inventarios concretos en la clase fábrica `InventoryManager`.

![image](https://github.com/user-attachments/assets/6e489ba6-f725-4ddf-b179-0cf65aa835b9)


En el controlador `ProductController` se puede observar, en el método CreateProduct, la ejecución de esta Lógica:

![image](https://github.com/user-attachments/assets/a6a8cfa7-dfb0-40b4-bb55-ed89fb3e0251)

## Patrón observer
El patrón Observer se implementó para permitir que los objetos se suscriban y reciban notificaciones de cambios en el estado de otro objeto. En este caso, los observadores se notifican cuando se agregan, actualizan o eliminan productos en el inventario.
Este patrón está conformado por las siguientes clases e interfaces:

1. Interface `IInventoryObserver`: su objetivo es definir un contrato para los observadores del inventario. Las clases que implementan esta interfaz sean notificadas cada vez que se agrega, actualiza o elimina un producto en el inventario. 
Métodos de la Interfaz IInventoryObserver
•	void OnProductAdded(ProductBase product): Este método se llama cuando se agrega un nuevo producto al inventario. El parámetro product proporciona información sobre el producto agregado.
•	void OnProductUpdated(Guid productId, int newStock): Este método se llama cuando se actualiza el stock de un producto existente en el inventario. Los parámetros productId y newStock proporcionan información sobre el producto actualizado y su nuevo stock.
•	void OnProductDeleted(Guid productId): Este método se llama cuando se elimina un producto del inventario. El parámetro productId proporciona información sobre el producto eliminado.

![image](https://github.com/user-attachments/assets/4148fdf2-43ca-4b7b-95d5-7637c9420221)

En este caso, la clase `InventoryObserver` que implementa esta interfaz, utiliza estos métodos para notificar mendiante mensajes en la consola, que un producto ha sido agregado, actualizado o eliminado.

![image](https://github.com/user-attachments/assets/410e828b-cdd7-4af4-b6fd-2399ff3250db)

Para este ejemplo, la clase abstracta `InventoryManager` ha sido modificada para mantener una lista de observadores y los notifique sobre los cambios:

![image](https://github.com/user-attachments/assets/607caa5c-5746-425b-9553-cf222119b27c)

Por último, las clases `DigitalInventoryManager` y `PhysicalInventoryManager`, que heredan de `InventoryManager`, emplean los métodos para Notificar cada vez que un producto es agregado, actualizado o eliminado.

![image](https://github.com/user-attachments/assets/4fcdf494-d793-4a8a-8ba8-01c263c8c109)

![image](https://github.com/user-attachments/assets/96bbbaee-678a-4dd4-bf5d-f3299321dd62)

Por último, es indispensable que el Observador concreto sea agregado a la instancia del Inventario que se crea, esto mediante la línea:
 inventoryManager.AddObserver(new InventoryObserver());

![image](https://github.com/user-attachments/assets/5d55da03-14c8-4274-9420-681d3e767f53)


### Ejecución
Para ejecutar la aplicación se requiere de .net 6.
Configurar la aplicación para iniciar la depuración desde el proyecto `e-commerce-api`. De esta fomra se abre la interfaz gráfica de swagger que mostrará los endpoints disponibles y permitirá ejecutarlos directamente desde el navegador.

![image](https://github.com/user-attachments/assets/4365bef9-c2bd-4eac-910d-ed726e50416b)

Estos endpoints permiten ejecutar todas las implementaciones enunciadas en este archivo.



