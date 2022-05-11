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
        public Gestor(ClientesCSV repoC, PedidosCSV repoP){
            RepoClientes = repoC;
            RepoPedidos = repoP;
            misClientes=RepoClientes.leer();
            misPedidos=RepoPedidos.leer();
        }




// -------Gestion de Clientes ---------------------

    public void nuevoCliente(Cliente c)
    {
        misClientes.Add(c);
        RepoClientes.guardar(misClientes);
    }

















       


    }
}