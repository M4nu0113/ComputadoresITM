# ComputadoresITM
La agencia de venta de computadores "ITM" tiene una única sede ubicada en la ciudad de
Medellín. Requiere un sistema para grabar las ventas de los computadores.
El sistema debe permitir grabar los computadores con sus principales características: 
número de procesadores, marca del procesador, tamaño de disco duro, tamaño de la memoria
y componentes (Es un texto libre para ingresar componente como mouse, teclado, tarjeta de video, etc).
Para el modelo solo debe considerar la agencia, el cliente, el tipo de computador (servidores,
equipo de escritorio, gamer, portátil, etc), el computador y la venta. Considere que un cliente 
sólo compra un computador a la vez, es decir, puede comprar muchos computadores en el tiempo, pero 
solo uno por "venta", un computador sólo se vende a un cliente.
No considere un modelo con tablas de referencia como marca, sedes, pais, ciudad, etc
Sólo considere las entidades sugeridas: agencia, cliente, tipo de computador, computador y venta.

## Integrantes
Juan Camilo Duarte Vasco
Manuela Estrada Villada

## Diagrama de la base de datos
![Captura de pantalla 2025-03-12 215625](https://github.com/user-attachments/assets/68d93255-0021-47d4-9578-5bb04f7706cc)

## Relaciones
- Agencia - Venta: Una agencia puede tener muchas ventas, pero una venta pertenece a una única agencia. (1 a muchos)
- Cliente - Venta: Un cliente puede realizar muchas ventas, pero una venta pertenece a un único cliente. (1 a muchos)
- Computador - Venta: Un computador puede ser vendido en una única venta, pero una venta incluye un único computador. (1 a 1)
- Tipo de Computador - Computador: Un tipo de computador puede tener muchos computadores asociados, pero un computador pertenece a un único tipo. (1 a muchos)

