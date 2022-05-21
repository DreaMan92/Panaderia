# PANADERÍA - TRABAJO ENTORNOS

## Contextualización
---
<br>

>Se nos plantea ayudar a un panadero, asentado en los pirineos, a digitalizar su negocio. Nuestra parte es diseñar y programar una aplicación que le sirva para controlar los cobros de su panadería, para así obtener un control más preciso. Debido a la libertad de implementación, he decido que las necesidades y competencias del programa sean las siguientes:

<br>

+ Nuestro cliente es un panadero que regenta un obrador enfocado a la panadería. Este se encarga de proveer de pan a las panaderías de los pueblos aledaños. Entre ellos se encuentra el suyo propio, donde está su mujer, quien regenta y se encarga de la venta de pan que hace su marido en una pequeña tienda. Su mujer será considerada por el programa como un cliente más, aunque luego en su casa el dinero vaya al mismo baúl.

<br>

+ El panadero nos comunica que él se encarga de vender pan al por mayor, por eso tiene unos pedidos fijos, que no suelen variar. Algunos de sus clientes pagan en el día, otros al final de la semana e incluso algunos al final del mes. Debido a las necesidades, la aplicación se ocupa de mantener un registro de quien ha pagado o quien está pendiente de hacerlo. De todas formas, esta aplicación no maneja registros de ganancias, solo gestiona los cobros para saber quien debe dinero y quien no. Si se quisiera llevar a cabo, habría que añadir las funciones necesarias para guardar los ingresos y los gastos, calcularlos y elegir un modo de mostrarlos como gráficos, tablas...

<br>

## Diseño
---
<br>

> Para el diseño de esta aplicación de consola he decidido enfocarme en las funcionalidades básicas:

<br>

 + Gestión de Pedidos
 + Gestión de Clientes
 + Gestión de Finanzas

> Cada una, como su nombre bien indica, atiende a dichas responsabilidades. Además, he querido agregar un funcionamiento automático. Este, comprueba cada día inicia la aplicación, que se renuevan los pedidos para el día siguiente. Para hacerlo comprueba el estado del pedido, si  sin que se pie a no ser que se modifiquen mediante el uso del programa.  

> Considero que el panadero haría uso de la aplicación a diario, por eso esta función es muy útil. Sin embargo, no he considerado que la entrega pueda fallar o que el propio panadero se ponga enfermo. 

<br>

## Diagramas
---
<br>
<center>

### Casos de uso de negocio
---

<br>

![](Imagenes/Casos%20de%20uso%20de%20negocio.png) 
</center>




<br>

<br>
<center>

### Casos de uso de sistema
---

<br>

![](Imagenes/Casos%20de%20uso%20de%20Sistema.png) 
</center>




<br>

<br>
<center>

### Diagrama de actividad
---

<br>

![](Imagenes/) 
</center>




<br>

<br>
<center>

### Diagrama de estado
---

<br>

![](Imagenes/Diagrama%20Estado%20de%20Pedido.jpg) 
</center>




<br>

<br>
<center>

### Diagrama de secuencia
---

<br>

![](Imagenes/A%C3%B1adir%20Pedido.jpg)
</center>


 

<br>

<br>
<center>

### Diagrama de clase de modelos de negocio
---

<br>

![](Imagenes/Diagrama%20de%20clases%20Modelos%20de%20Negocio.jpg) 
</center>




<br>

<br>
<center>

### Diagrama de clases de arquitectura
---

<br>

![](Imagenes/Diagrama%20de%20clases.jpg) 
</center>




<br>

## Capturas de ejecución
---

<br>
<center>

### Menu Principal
---

<br>

![](Imagenes/MenuPrincipal.png) 
</center>

<br>
<center>

### Menu Gestión de Pedidos
---

<br>

![](Imagenes/MenuPedidos.png) 
</center>

<br>
<center>

### Menu Gestión de Clientes
---

<br>

![](Imagenes/MenuClientes.png) 
</center>

<br>
<center>

### Menu Gestión de Finanzas
---

<br>

![](Imagenes/MenuFinanzas.png) 
</center>

<br>
<center>

### Ver Pedidos en Gestion de Pedidos
---

<br>

![](Imagenes/VerPedidos.png) 
</center>

<br>
<center>

### Ver Pedidos Por Cliente en Gestión de Clientes
---

<br>

![](Imagenes/VerPedidosPorCliente.png) 
</center>

<br>
<center>

### Liquidar Deudas de Gestión de Finanzas
---

<br>

![](Imagenes/LiquidarDeudas.png) 
</center>

<br>

## Problemas
---