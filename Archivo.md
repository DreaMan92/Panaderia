# PANADERIA - TRABAJO ENTORNOS

## Contextualización
> Se nos plantea satisfacer la demanda de un panadero, que quiere poder llevar un mejor control de sus gastos e ingresos.
> Ya que nos has dado mucha libertad para realizar este ejercicio, se nos plantea realizar una planifcacion concreta, para fijar los limites de nuestro programa, siempre cumpliendo los objetivos.
> yo por ejemplo planteo el siguiente contexto:
+ La panaderia lleva 25 años siendo la panaderia principal de la zona, es decir a aparte de vender en la tienda de su pueblo que regenta su mujer, donde esta situado el obrador, provee de pan recien hecho todos los dias a los pueblos de la zona. Se desplaza hasta 10 pueblos. 
Hay algunos que realizan sus pedidos de manera rutinaria, es decir una cantidad fija y otros que deciden al dia, sea como sea el plazo maximo para hacer el encargo es el dia anterior con el reparto del pan. Si a esas alturas en el pedido figuran 10, se entrgan 10 y se facturan 10. Entonces que queire decir esto, que aunque el programa permita modificar pedidos, parto de un datos fijos que no varian a no ser que quieran ser modificados.

> esta aplicacion no maneja resgistros de ganancias, solo gestiona los cobros para saber quien le debe dinero o quien no, para llevarlo acabo seria añadir las funciones necesarias para guardar los ingresos.






---
<br>
<br>
<br>
<br>
<br>
<br>

## A tener en cuenta
> 1kg de pan se hace con 750 gr de harina, 30 gr de levadura, media cucharada de sal, 400 ml de agua, y una pizca de azucar.

<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>

# Problemas
+ Decidir como crear mi pedidos, a psear de tener un lista de panes que forman para de lo atributos del objeto pedio, ovy a tratar las lista de panes con un fichero aparte. Usando un 

+   cuando se crea un cliente hay que añadir un objeto deuda a cada uno para tner un fichero aparte que guarde esos datos.
    y aqui si se inicia el progrma y la fecha no es la de hoy entonce guardamos el dinero en deudas actualizamos la fecha al dia siguiente
    osea seria si la fecha no es la de mañana y estado es pendiente guardamos en deudad
    si no si el estado es pagado, cambiaremos fecha y no añadiremos nada nuevo.
    coon eso logramos es que si un cliente no paga al dia tener registrado lo que nos debe.
    cambiar el dato de ver cliente con deudas en vez del precio del pedido deudas totales.
    esto es una forma de automatizar que cuando se inicie el programa automaticamente actualice los pedidos al proximo dia y guarde las deudas.

> comprobar que cuando hago pruebas y pongo el pedido a pagado luego no me muestra nada al ver deudas comprobar 
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>

# Diario
+ ### inicio 03/05
+ ### 2 horas 03/05
    > Organización de modelos
    > Implementación de modelos.
+ ### 2 horas y media 09/05
    > Estructuración del codigo
    > Desarrollo de casos de uso
    > Inicio de controlador y gestor csv
+ ### 2 horas 10/05
    > Resolviendo problemas
    > empezando gestor
+ ### 4 horas 11/05
    > avanzando mucho
    >todavia falta la mitad
+ ### 4 horas 12/05
    > en calse avanzado con pedidos
+ ### 2 horas 13/05
    > dos horas mas en casa haciendo csv y metodos para panpedidos
+ ### 1 horas 14/05
    > decidiendo como implementar subcasos de uso
+ ### 3 horas 15/05
    > avanzando corregir metodo para asignar lista de panes a pedido.
+ ### 3 horas 17/05
    > avanzando corregir metodo para asignar lista de panes a pedido.
+ ### 2 horas 17/05
    > en clase durante el dia avanzando con la gestion de finanzas





# ENLACES
+ https://docs.microsoft.com/es-es/dotnet/api/system.guid.newguid?view=net-6.0
+ https://github.com/krs98/Mascotas/blob/master/src/Models/Models.cs
+ https://support.ptc.com/help/creo/creo_schem/usascii/index.html#page/Schematics_hc/About_Including_a_List_of_Values_in_a_CSV_File.html
+ http://net-informations.com/q/faq/stringdate.html (Parsear string to fecha)
+ https://docs.microsoft.com/es-es/dotnet/api/system.decimal.tostring?view=net-6.0#system-decimal-tostring(system-iformatprovider)(Quitar punto en decimal)
