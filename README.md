# Polimorfismo, Sobrecarga y Sobreescritura
En esta entrega se implementan los conceptos de Polimorfismo, Sobrecarga y Sobre escritura de la Programación orientada a objetos.

##Polimorfismo

Las Subclases `DigitalProduct` y `PhysicalProduct` implementan los métodos abstractos CalcultateTotalValue y ShowInfo de la clase base ProductBase, para que, cada uno pueda hacerlo bajo su propia lógica.
Sin embargo, al tratar estos objetos concretos como su clase base dentro de una lista que recibe objetos de tipo ProductBase se ejecutan sin problema.

`ProductBase.cs`
![image](https://github.com/user-attachments/assets/afdae610-6eff-4781-a3bd-e178526c4fea)

`PhysicalProduct.cs`
![image](https://github.com/user-attachments/assets/3c977582-4bca-4c34-869c-5ca80f9b8571)

`DigitalProduct.cs`
![image](https://github.com/user-attachments/assets/244de58c-6e6d-4f5b-b42e-971adbf73048)

Ejecución:
La clase `ShoppingCarService` crea un objeto de la clase ShoppingCar, la cual está compuesta por un Usuario de tipo Costumer y una Lista de productos base, sin distinguir entre las implementaciones concretas:
![image](https://github.com/user-attachments/assets/861b80fd-9461-42af-bf11-1aa2e7a9a0ff)

Ejecuta los métodos mencionados sin distinguir entre sus implementaciones.
![image](https://github.com/user-attachments/assets/b5593a23-c1b0-4f69-b427-ba02e2c743d4)

## Sobre carga
En la sobre carga se crean métodos que tienen el mismo nombre pero que reciben parámetros diferentes. En este caso, se han creado 3 sobre cargas para el Método AddProduct y 2 sobre cargas para el método RemoveProduct.
En ellas se reciben como parámetros, el Id del Producto, El nombre del Producto, y el objeto completo. Las sobrecargas funcionan de forma satisfactoria en cada caso. 
Esta implementación se observa en la clase  `ShoppingCarService` y se ejecutan en la case  `ProductController`.
![image](https://github.com/user-attachments/assets/bd970209-b760-4612-854d-783d1c5605d3)
![image](https://github.com/user-attachments/assets/d2d8419f-2bcc-4c68-a3cf-980d8429210e)

## Sobreescritura
La clasebase  `ProductBase` no implementa los métodos CalculateTotalValue y ShowInfo, obligando a las clases hijas `DigitalProduct` y `PhysicalProduct` a implementarlos, cada uno según su propia lógica.
![image](https://github.com/user-attachments/assets/f5e7c0fd-05a0-4852-8c7e-74ee79056ac6)

![image](https://github.com/user-attachments/assets/416d96fc-12b9-4631-a6a5-9aea4447ed66)

![image](https://github.com/user-attachments/assets/41c397b1-a8f5-4fc3-aecb-c929e33e1bce)

## Ejecución del Proyecto

Para ejecutar el proyecto, sigue estos pasos:

1. **Clonar el repositorio**:
    ```sh
    git clone <URL_DEL_REPOSITORIO>
    cd <NOMBRE_DEL_REPOSITORIO>
    ```


## Uso

Para ejecutar la aplicación se requiere de .net 6.
Al ajecutarlo se iniciará una ventana en el navegador con la interfaz swagger, la cual tiene un único controlador, que puede ejecutarse sin necesidad de parámetros para ver la ejecución del los conceptos mencionados.

![image](https://github.com/user-attachments/assets/929f98b0-4418-4283-9366-64de55d84e61)


