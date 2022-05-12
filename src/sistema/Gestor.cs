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
    guardarPanespedido(uno);
}

public void guardarPanespedido(Dictionary<Pan, int> uno)
{
    

}












       


    }
}