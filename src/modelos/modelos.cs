﻿namespace modelos;
public class modelos
{
    public abstract class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }

        public Persona(){
            nombre="";
            apellido="";
            dni="";
            telefono="";
            direccion="";
        }
        public Persona(string nombre, string apellido, string dni, string telefono, string direccion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.telefono = telefono;
            this.direccion = direccion;
        }
    //falta toString()

    }
    public class Cliente : Persona
    {
        public int idCliente { get; set; } =0;

        public Cliente(){}
        public Cliente(int idCliente,string nombre, string apellido, string dni, string telefono, string direccion)
        {
            this.idCliente=idCliente;
            this.nombre=nombre;
            this.apellido=apellido;
            this.dni=dni;
            this.telefono=telefono;
            this.direccion=direccion;
        }
    //falta toString(    
    }

    public class Pedido
    {
        public int idPedido { get; set; }
        public DateTime fecha { get; set; }
        public List<Pan> listaDePan { get; set; } 
        public double precioPedido { get; set; }
        public string dniCliente { get; set; }

        public Pedido(int idPedido, string dniCliente, List<Pan> listaDePan,DateTime fecha, double precio)
        {this.idPedido=idPedido;
        this.fecha = fecha;
        this.listaDePan=listaDePan;
        this.precioPedido=precio;
        this.dniCliente=dniCliente;
        }
        public Pedido(int idPedido, string fecha, List<Pan> listaDePan, double precio)
        {
        }
    }

    public enum tipoDePan
    {
        Chapata,//900gr
        TortaDeAceite,
        PanGallego,
        Mollete,
        Hogaza,
        Grissini

    }
    public class Pan
    {
        public tipoDePan tipo { get; set;} 
        public double precio { get; set; }
        public double peso { get; set; }

        public Pan(tipoDePan tipo, double precio, double peso){
            this.tipo=tipo;
            this.precio=precio;
            this.peso=peso;
        }

    }


}
