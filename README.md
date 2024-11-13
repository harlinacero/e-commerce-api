# Encapsulamiento y abstracción
En esta entrega se implementan los conceptos de Encapsulamiento y abstracción

## Encapsulamiento
Las clases base `ProductBase` y `UserBase` han cambiado los modificadores de acceso de sus atributos a protected, de forma que solo puedan ser usados directamente por sus clases derivadas.
Para acceder a sus atributos, se debe realizar a través de los Setters y Getters. Los Setters, además realizan validaciones respectivas.

Clase ProductBase

![image](https://github.com/user-attachments/assets/cb027cea-87a4-4a95-a164-3844bab787a8)

![image](https://github.com/user-attachments/assets/4c2861fa-54aa-4c46-9618-6636fdb4285e)

Clase UserBase

![image](https://github.com/user-attachments/assets/89458b83-7bcf-4854-b6aa-f7e6daaf7a21)

![image](https://github.com/user-attachments/assets/1e8c1faf-b070-4669-b95f-f707389ec935)

Las Subclases `DigitalProduct` y `PhysicalProduct` también implementan el encapsulamiento agregando validaciones sobre sus atributos que son privados.

Clase DigitalProduct

![image](https://github.com/user-attachments/assets/6bc0105b-5942-457f-8c5a-f5368dec8366)

Clase PhysicalProduct

![image](https://github.com/user-attachments/assets/b500f1cc-c85e-4c24-b123-2e4ba7f93b1d)

De la misma forma Las Subclases de la clase `UserBase` `Customer` y `Seller` implementan el encapsulamiento agregando validaciones sobre sus atributos que son privados.

Clase Customer

![image](https://github.com/user-attachments/assets/fab93a55-ee5e-4d90-9e22-1be627c723c3)


## Abstracción
Las clases base `ProductBase` y `UserBase` son además abstractas, lo que implica que no se pueden instanciar directamente. Además, los métodos abstractos que declaran, deben, obligatoriamente ser implementados por sus clases derivadas, 
mientras que, los métodos implementados son heredados y pueden ser usados por sus clases hijas.

Clase ProductBase

![image](https://github.com/user-attachments/assets/1cb2fab1-c8fc-4895-92e8-2e9045ccc594)

![image](https://github.com/user-attachments/assets/4743aa06-1123-4cfb-86ad-8c9f5a0957a3)

Las Subclases `DigitalProduct` y `PhysicalProduct`
Se sobre escriben los métods abstractos CalculateTotalValue y ShowInfo, y se usan los métodos heredados GetGrossValue, GetTaxPercentaje y GetDisccounPercentaje de la clase padre.

![image](https://github.com/user-attachments/assets/9e121428-8db7-4e9b-8dc5-075e0cc06117)

![image](https://github.com/user-attachments/assets/4c55d512-fb19-4b1f-b6cb-c75d28cda32a)



Ejecución:


## Ejecución del Proyecto

Para ejecutar el proyecto, sigue estos pasos:

1. **Clonar el repositorio**:
    ```sh
    git clone <URL_DEL_REPOSITORIO>
    cd <NOMBRE_DEL_REPOSITORIO>
    ```


## Uso

Para ejecutar la aplicación se requiere de .net 6.
Al ajecutarlo se iniciará una ventana en el navegador con la interfaz swagger, la cual tiene un controlador con dos endpoints.
En el primero, Product, al ejecutarlo se agregan los productos al carro de compra, se calcula su valor y se muestra la información respectiva. 
Recordando que estos métodos eran abstractos en la clase base e implementados en las clases derivadas, cada uno con su propia lógica, y a su vez, al interior de ellos, usando los métodos heredados de la clase base.

![image](https://github.com/user-attachments/assets/2534076d-099d-4b01-a5f9-79329766489d)

Las funionalidades implementadas en la tarea anterior no han sido modificadas.

![image](https://github.com/user-attachments/assets/734dbe49-0ec0-4f6a-a720-2f6b01ceb187)


En el segundo endpoint Product/UpdateFormatProduct, se solicita agregar un nuevo formato para modificar el del Producto Digital cargado por defecto.

![image](https://github.com/user-attachments/assets/02177d8d-fc89-4dc6-8c76-2b7b221502ea)

La lógica de la clase DigitalProduct, verifica si el formato es válido o no para permitir el cambio:

Formato Válido

![image](https://github.com/user-attachments/assets/a2f61642-c3df-4a51-acfa-9b4193bf1f04)

Formato inválido

![image](https://github.com/user-attachments/assets/e4c0740c-7d25-432b-a686-d56d24ea0ade)

