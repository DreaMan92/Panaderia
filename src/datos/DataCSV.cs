
using modelos;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                var str =$"{Cliente.nombre},{Cliente.apellido},{Cliente.dni},{Cliente.telefono},{Cliente.direccion}";
                data.Add(str);
            });
            File.WriteAllLines(_fileClientes, data);

        }

        public List<Cliente> leer()
        {
            List<Cliente> misClientes = new();
                var data = File.ReadAllLines(_fileClientes).Where(row => row.Length > 0).ToList();
                data.ForEach(row =>
                {
                    var campos = row.Split(",");
                    Cliente cliente = new Cliente
                    (               
                        nombre : campos[1],
                        apellido : campos[2],
                        dni : campos[3],
                        telefono : campos[4],
                        direccion : campos[5]
                    );
                    misClientes.Add(cliente);
                });

                return misClientes;
            
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
                var str =$"{Pedido.dniCliente},{Pedido.fecha},{Pedido.precioPedido}";
                data.Add(str);
            });
            File.WriteAllLines(_filePedidos, data);

        }

         public List<Pedido> leer()
        {
            List<Pedido> misPedidos = new();
                var data = File.ReadAllLines(_filePedidos).Where(row => row.Length > 0).ToList();
                data.ForEach(row =>
                {
                    var campos = row.Split(",");
                    Pedido pedido = new Pedido
                    (
                        dniCliente : campos[0],
                        fecha : campos[1],
                        precioPedido : double.Parse(campos[2])
                    );
                    misPedidos.Add(pedido);
                });

                return misPedidos;
            
        }    
    }
}
