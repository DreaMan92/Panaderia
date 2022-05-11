using System.Collections.Generic;

namespace modelos
{


    public abstract class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
    }
    public class Cliente : Persona
    {
        public Cliente() { }
        public Cliente( string nombre, string apellido, string dni, string telefono, string direccion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.telefono = telefono;
            this.direccion = direccion;
        }
        //falta toString(    
    }

    public class Pedido
    {
        public int ID { get; set; }
        public string dniCliente { get; set;}
        public string fecha { get; set; }
        public double precioPedido { get; set; }
        public List<Pan> listaDePan { get; set; }        

        public Pedido( int ID,string dniCliente, string fecha, double precioPedido)
        {
            this.ID=ID;
            this.dniCliente=dniCliente;
            this.fecha = fecha;
            this.precioPedido = precioPedido;           
        }
        public Pedido(){}
    }
    public class listaPan
    {
        public Guid IDPedido { get; set; }
        public tipoDePan tipo { get; set; }
        public int cantidad { get; set; }

        public listaPan(Guid IDPedido, tipoDePan tipo, int cantidad)
        {
            this.IDPedido=Guid.NewGuid();
            this.tipo=tipo;
            this.cantidad=cantidad;
        }
    }
    public enum tipoDePan
    {
        Chapata,//900gr
        TortaDeAceite,
        PanGallego,
        Hogaza,
        BarraDePueblo

    }
    public class Pan
    {
        public tipoDePan tipo { get; set; }
        public double precio { get; set; }
        public double peso { get; set; }
        public Pan(){}
        public Pan(tipoDePan tipo, double precio, double peso)
        {
            this.tipo = tipo;
            this.precio = precio;
            this.peso = peso;
        }

    }


}
