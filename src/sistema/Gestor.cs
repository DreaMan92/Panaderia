﻿using modelos;
using datos;
using System.Collections.Generic;




namespace sistema
{
    public class Gestor
    {
        ClientesCSV RepoClientes;
        PedidosCSV RepoPedidos;
        PanesPedidosCSV RepoPanPedido;
        public List<Cliente> misClientes;
        public List<Pedido> misPedidos;
        public List<Pan> misProductos ;
        public List<PanesPedido> misPanesPorPedido;
        public Gestor(ClientesCSV repoC, PedidosCSV repoP, PanesPedidosCSV repoPanPedido){
            RepoClientes = repoC;
            RepoPedidos = repoP;
            RepoPanPedido = repoPanPedido;
            misClientes=RepoClientes.leer();
            misPedidos=RepoPedidos.leer();
            misPanesPorPedido = RepoPanPedido.leer();
            generarPanes();
            asignarPanPedidoAPedido();  
 
        }
//----------Pan-------------------

    public void generarPanes()
    {
        misProductos = new List<Pan>();
        Pan chapata = new Pan(tipoDePan.Chapata,1.30M);
        Pan torta = new Pan(tipoDePan.TortaDeAceite,1.50M);
        Pan gallego = new Pan(tipoDePan.PanGallego,1.10M);
        Pan hogaza = new Pan(tipoDePan.Hogaza,2.50M);
        Pan barra = new Pan(tipoDePan.BarraDePueblo,1.00M);
        misProductos.Add(chapata);
        misProductos.Add(torta);
        misProductos.Add(gallego);
        misProductos.Add(hogaza);
        misProductos.Add(barra);
    }

// -------Gestion de Clientes ---------------------

    public void nuevoCliente(Cliente c)
    {
        misClientes.Add(c);
        RepoClientes.guardar(misClientes);
    }
    public void borrarCliente(Cliente c){
        misClientes.Remove(c);
        RepoClientes.guardar(misClientes);
    }

    public bool tienePedido(string dni)
    {
        bool respuesta= false;
        foreach(Pedido i in misPedidos)
        {
            if(i.dniCliente.Equals(dni)){
            respuesta = true;
            }
        }
        return respuesta;

    }
    public Cliente encontrarClientePorDni(string dni)=>
    misClientes.Find(cliente => dni.Equals(cliente.dni));
    public Pedido pedidoDeCliente(Cliente uno)=>
        misPedidos.Find(pedido => uno.dni.Equals(pedido.dniCliente));




// -------Gestion de Pedidos ---------------------

public Decimal calcularPrecioPedido(Dictionary<Pan,int> unaLista)
{
    Decimal devolver=0;
    foreach (var i in unaLista){
        devolver= devolver+(i.Key.precio*i.Value);
    }
    return devolver;      
}
public void nuevoPedido(Pedido p,Dictionary<Pan, int> uno)
{
    misPedidos.Add(p);
    RepoPedidos.guardar(misPedidos);
    guardarPanespedido(p,uno);
}

public void guardarPanespedido(Pedido p,Dictionary<Pan, int> uno)
{
   List<PanesPedido> nuevaLista = new List<PanesPedido>();
   foreach( var i in uno)

   {
       PanesPedido nuevo = new PanesPedido
       (
           ID : p.ID,
           pan : i.Key,
           cantidad : i.Value
       );
       nuevaLista.Add(nuevo);
   }
   foreach(var i in nuevaLista){
       misPanesPorPedido.Add(i);
   }
   RepoPanPedido.guardar(misPanesPorPedido);  
}
public void asignarPanPedidoAPedido()
{    
    foreach(PanesPedido i in misPanesPorPedido)
        {
            misPedidos.Find(pedido => i.ID.ToString().Equals(pedido.ID.ToString())).listaDePan.Add(i);
        }
}

public void borrarPedido(Pedido uno)
{
    misPanesPorPedido.RemoveAll(pedido => uno.ID.ToString().Equals(pedido.ID.ToString()));
    misPedidos.Remove(misPedidos.Find(pedido => uno.ID.ToString().Equals(pedido.ID.ToString())));
    RepoPanPedido.guardar(misPanesPorPedido);
    RepoPedidos.guardar(misPedidos);
    
}






/*------------------Gestion Panes Pedido-------------------*/



    }
}