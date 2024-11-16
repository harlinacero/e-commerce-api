# Implementación de Interfaces y Clases Abstractas
En esta entrega se implementan los conceptos de clases abstractas e Interfaces.
Ya que mostrar el proceso interno de cada caso mediante el API Rest es un poco complicado, para esta entrega se ha creado un proyecto de consola que implementa la lógica correspondiente
y permite conocer lo que sucede al interior de cada implementación.

## Clases abstractas
Las clases abstracta `InventoryManager` contiene los métodos abstractos AddProduct, DeleteProduct y UpdateStock que deben ser implementados por sus clases hijas: `PhysicalInventoryManager` y `DigitalInventoryManager`.

Clase `InventoryManager`

![image](https://github.com/user-attachments/assets/9e61ac81-e10f-4948-9ac2-242612319d6c)

Clase `PhysicalInventoryManager`

![image](https://github.com/user-attachments/assets/7ed16acd-56e3-429e-8e1f-e06737c0dcc5)

Clase `DigitalInventoryManager` 

![image](https://github.com/user-attachments/assets/a09f28f3-0ec1-45ab-9f5a-60ae50b041ef)

### Ejecucución
Para ejecutar la aplicación se requiere de .net 6.
Establecer el proyecto e-commerce-console como proyecto de inicio y ejecutarlo.

![image](https://github.com/user-attachments/assets/70b8b801-92ce-47b9-ba73-039f6cb67f64)

La ejecución por consola arroja la siguiente salida:
![image](https://github.com/user-attachments/assets/e8f474b1-0288-45b7-bd39-8ea5c3b4c5a6)


## Interfaces
Se ha creado la interaz `IPayProcess` que define los métodos BeginPayProcess, IsPayProcessAvailable y ConfirmPay, los cuales deben ser implementados por las clases concretas `PayPalPay`, `CreditCardPay`, 
`CashPay` y `TransferPay`, cada una, con su propia lógica y condiciones. Para gestionar mejor la creación de estos objetos se ha hecho uso del patrón Factory, el cual, se encargará de esta lógica.
Tanto la interfaz como las clases se encuentran en la carpeta PayFactory de la carpeta servicios en el proyecto e-commerce-domain.

![image](https://github.com/user-attachments/assets/81363ed3-3a18-489d-be5d-e9cfc4ed38a6)

Clase fábrica: `PayProcessFactory`

![image](https://github.com/user-attachments/assets/2ec7a3f7-442e-4e8e-ad10-a3fe54cad6cc)

Como se observa, el método Create, recibe como parámetro un método de pago y una orden de compra. De acuerdo con el método seleccionado, se retorna una implementación concreta de la interfaz `IPayProcess`.

Interfaz `IPayProcess` 

![image](https://github.com/user-attachments/assets/9d0b2ff4-11a1-4cef-b15e-f705ab436269)

Clase `PayPalPay`

![image](https://github.com/user-attachments/assets/4e485bac-b33f-47ed-98f2-b95c8cfb2b53)

Clase `CreditCardPay`

![image](https://github.com/user-attachments/assets/1980d8da-036e-454d-8756-19127414cd7c)

### Ejecución
Para ejecutar la aplicación se requiere de .net 6.
Establecer el proyecto e-commerce-console como proyecto de inicio y ejecutarlo.
El método PayOrderProcess en la clase main del proyecto de consola contiene la lógica para la creación de órdenes de pago con diferente número de productos y cada orden con ún método de pago diferente.

![image](https://github.com/user-attachments/assets/48cd9d1a-9227-4622-966a-753b22d3fdd8)

La ejecución de este método, arroja la siguiente salida por consola.
![image](https://github.com/user-attachments/assets/d1c73906-c5c2-4ccf-9416-4a2c4dafa0fb)



