using modelos;
using datos;
using System.Collections.Generic;




namespace sistema
{
    public class Gestor
    {
        ClientesCSV RepoClientes;
        PedidosCSV RepoPedidos;
        public List<Cliente> misClientes;
        public List<Pedido> misPedidos;
        public List<Pan> misProductos ;
        public Gestor(ClientesCSV repoC, PedidosCSV repoP){
            RepoClientes = repoC;
            RepoPedidos = repoP;
            misClientes=RepoClientes.leer();
            misPedidos=RepoPedidos.leer();
            generarPanes();
        }
//----------Pan-------------------

    public void generarPanes()
    {
        misProductos = new List<Pan>();
        Pan chapata = new Pan(tipoDePan.Chapata,1.30);
        Pan torta = new Pan(tipoDePan.TortaDeAceite,1.50);
        Pan gallego = new Pan(tipoDePan.PanGallego,1.10);
        Pan hogaza = new Pan(tipoDePan.Hogaza,2.50);
        Pan barra = new Pan(tipoDePan.BarraDePueblo,1.00);
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

// -------Gestion de Pedidos ---------------------

public int calcularPrecioPedido(Dictionary<Pan,int> unaLista)
{
    int devolver=0;
    foreach (var i in unaLista){
        devolver= devolver+i.Value;
    }
    return devolver;  
    
}














       


    }
}