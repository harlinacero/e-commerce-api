# Implementación de Manejo de Excepciones y Pruebas Unitarias

## Manejo de Excepciones
Los métodos contienen excepciones para controlar errores en la creación o modificación de las propiedades de los objetos como al intentar modificar el peso y la altura de un producto con valores incorrectos:
![image](https://github.com/user-attachments/assets/302e8e7f-0a47-45f5-9e48-29f893c1f499)

O al Modificar el tamaño de un archivo:
![image](https://github.com/user-attachments/assets/d86a8eb2-fb0c-408c-b852-5f6bc281bd75)

También se agregan excepciones Personalzadas como `FailedPaymentException` y `InsufficientInventoryException`, las cuales se utilizan para controlar errores no previstos en la generación del pago o en el inventario de los productos:

![image](https://github.com/user-attachments/assets/b555a267-4157-4fb4-9db1-192971c1fa9b)

![image](https://github.com/user-attachments/assets/49c2cfc2-3a54-4417-bb51-038ee0566897)

### Ejemplo de la implementación
La excepción `FailedPaymentException` se usa en todas las formas de pago `CashPay`, `CreditCardPay`, `PayPalPay`, `TansferPay` para controlar errores que puedan producirse mientras se valida el método de pago.
![image](https://github.com/user-attachments/assets/46ba1e74-585b-4eda-85ef-74a22f3bce06)

![image](https://github.com/user-attachments/assets/c16cf76e-d651-46e8-b55d-af4934f5a4bb)

La excepción `InsufficientInventoryException` se utiliza en la clase `ShopingCarService` para controlar errores producidos cuando se intena hacer alguna operación con un producto que no existe o ha agotado su inventario.
![image](https://github.com/user-attachments/assets/cb3e8e82-2360-4746-b28a-fcc5a7ec8b9e)

Este control permite que el sistema siga operando ante situaciones no controladas.

## Pruebas unitarias
Se han creado 101 pruebas unitarias en la carpeta Test, teniendo un proyecto de Test para cada Proyecto con código fuente como domain, api, e infraestructure. Estas pruebas fueron creadas con el framework XUnit de .Net, y cubren casi todos los esenarios de cada una de las clases del proyecto hasta el momento. Estas pruebas incluyen el camino feliz y otros esenarios donde se puedan producir excepciones o errores.
En especial, las clases base y concreatas de `ProductBase`, `DigitalProduct`, `PhysicalProduct`, `UserBase`, `Customer`, `Seller`, `Admin`, cuentan con un set completo de pruebas unitarias que verifican su funcionamiento.

![image](https://github.com/user-attachments/assets/9141a5cc-5602-42c4-a03f-5556fc4e45eb)

![image](https://github.com/user-attachments/assets/9a3087a5-2562-43f6-ad76-54b0af897560)

### Ejecución
Para ejecutar la aplicación se requiere de .net 6.
Configurar la aplicación para iniciar la depuración desde el proyecto `e-commerce-api`. De esta fomra se abre la interfaz gráfica de swagger que mostrará los endpoints disponibles y permitirá ejecutarlos directamente desde el navegador.

![image](https://github.com/user-attachments/assets/4365bef9-c2bd-4eac-910d-ed726e50416b)

Estos endpoints permiten ejecutar todas las implementaciones enunciadas en este archivo.

Para ejeceutar las pruebas unitarias se puede hacer uso del comando dotnet test, o ejecutarlas manualmente desde el Visual Studio.
Esta forma nos permite observar cuantas pruebas fueron superadas y cuantas fallaron como se muestra en el ejemplo:
![image](https://github.com/user-attachments/assets/43d6d77b-03ba-449a-8978-db1c7fb512c1)

Después de corregir los errores encontrados con las pruebas unitarias o corregir la prueba como tal, según sea el caso, el test debe verse así:

![image](https://github.com/user-attachments/assets/e72d1dbe-b0d4-42c8-a5e1-4ee4fa64eeba)





