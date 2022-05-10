
using modelos;
using System;

namespace datos
{
    public class ClientesCSV : IData<Cliente>
    {
        string _fileClientes = "../../RepositoriosCSV/clientes.csv";

        public void guardar(List<Cliente> misClientes)
        {
            List<string> data = new(){ };
            misClientes.ForEach(Cliente =>
            {
                var str =$"{Cliente.idCliente},{Cliente.nombre},{Cliente.apellido},{Cliente.dni},{Cliente.direccion}";
                data.Add(str);
            });
            File.WriteAllLines(_fileClientes, data);

        }

        public List<Cliente> leer()
        {
            List<Cliente> misClientes = new(){
                var data = File.ReadAllLines(_fileClientes).Where(row => row.Length > 0).ToList();
                data.ForEach(row =>
                {
                    var campos = row.Split(",");
                    Cliente cliente = new Cliente
                    (
                        IDCliente : campos[0],
                        Nombre : campos[1],
                        Apellido : campos[2],
                        DNI : campos[3],
                        Direccion : campos[4]
                    )
                    misClientes.Add(cliente);
                });

                return misClientes;
            }
        }

    }
    public class PedidosCSV : IData<Pedido>
    {
         string _filePedidos = "../../RepositoriosCSV/pedidos.csv";

        public void guardar(List<Pedido> misPedidos)
        {
            List<string> data = new(){ };
            misPedidos.ForEach(Pedido =>
            {
                var str =$"{Pedido.idPedido},{Pedido.fecha},{Pedido.listaDePan},{Pedido.precioPedido},{Pedido.dniCliente}";
                data.Add(str);
            });
            File.WriteAllLines(_filePedidos, data);

        }

         public List<Pedido> leer()
        {
            List<Pedido> misPedidos = new(){
                var data = File.ReadAllLines(_filePedidos).Where(row => row.Length > 0).ToList();
                data.ForEach(row =>
                {
                    var campos = row.Split(",");
                    Pedido pedido = new Pedido
                    (
                        IDPedido : campos[0],
                        Fecha : campos[1],
                        Apellido : campos[2],
                        DNI : campos[3],
                        Direccion : campos[4]
                    )
                    misPedidos.Add(pedido);
                });

                return misPedidos;
            }
        }


    }










}
