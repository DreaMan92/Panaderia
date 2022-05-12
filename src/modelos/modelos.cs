using System.Collections.Generic;

namespace modelos
{
    public class Cliente
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string telefono { get; set; }
        public string pueblo { get; set; }
        public Cliente() { }
        public Cliente( string nombre, string apellido, string dni, string telefono, string pueblo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.telefono = telefono;
            this.pueblo = pueblo;
        }
        public override string ToString() =>
        $"{nombre} {apellido} con DNI: {dni} y Tfno: {telefono} - Pueblo: {pueblo} ";
    }

    public class Pedido
    {
        public Guid ID { get; set; }
        public string dniCliente { get; set;}
        public DateTime fecha { get; set; }
        public Decimal precioPedido { get; set; }
        public string pagado { get; set; }
        public Dictionary<Pan,int> listPanCant { get; set; } 
        public Dictionary<Guid,Dictionary<Pan,int>> listIdPan { get; set; }
        public Pedido(){}     

        public Pedido( Guid ID,string dniCliente, DateTime fecha, Decimal precioPedido,string pagado)
        {
            this.ID=Guid.NewGuid();
            this.dniCliente=dniCliente;
            this.fecha = fecha;
            this.precioPedido = Math.Round(precioPedido,2); 
            this.pagado=pagado;          
        }
        
    }
    public enum tipoDePan
    {
        Chapata,
        TortaDeAceite,
        PanGallego,
        Hogaza,
        BarraDePueblo

    }
    public class Pan
    {
        public tipoDePan tipo { get; set; }
        public Decimal precio { get; set; }
        public Pan(){}
        public Pan(tipoDePan tipo, Decimal precio)
        {
            this.tipo = tipo;
            this.precio = Math.Round(precio,2);
        }
        public override string ToString() =>
        $"{tipo}  precio: {precio} \u20AC";
       
    }
   


}
