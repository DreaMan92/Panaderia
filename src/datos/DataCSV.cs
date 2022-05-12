
using modelos;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

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
                var str =$"{Cliente.nombre},{Cliente.apellido},{Cliente.dni},{Cliente.telefono},{Cliente.pueblo}";
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
                        nombre : campos[0],
                        apellido : campos[1],
                        dni : campos[2],
                        telefono : campos[3],
                        pueblo : campos[4]
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
                var str =$"{Pedido.ID},{Pedido.dniCliente},{Pedido.fecha.ToShortDateString()},{Pedido.precioPedido.ToString(CultureInfo.InvariantCulture)},{Pedido.pagado}";
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
                        ID : Guid.Parse(campos[0]),
                        dniCliente : campos[1],
                        fecha : DateTime.Parse(campos[2]),
                        precioPedido : Decimal.Parse(campos[3]),
                        pagado : campos[4]
                    );
                    misPedidos.Add(pedido);
                });

                return misPedidos;
            
        }    
    }
    
}
