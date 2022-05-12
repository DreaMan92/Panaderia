
using sistema;
using System.Linq;
using System.Collections.Generic;
using System;
using modelos;
using System.Text.RegularExpressions;






namespace consola 
{
    class Controlador
    {
        private Vista _vista;
        private Gestor _sistema;
        private Dictionary<string, Action> _casosdeUso;
        private Dictionary<string, Action> _gestionPedidos;
        private Dictionary<string, Action> _gestionClientes;
        private Dictionary<string, Action> _verClientes;
        private Dictionary<string, Action> _gestionFinanzas;

        

        public Controlador(Vista vista, Gestor logicaNegocio)
        {
            _vista = vista;
            _sistema=logicaNegocio;
            _casosdeUso = new Dictionary<string, Action>()
            {
                {"Gestión de Pedidos",gestionPedidos},
                {"Gestion de Clientes",gestionClientes},
                {"Gestion de Finanzas",gestionFinanzas},
                {"Salir y Cerrar aplicación",salir}
            };
        }
        // === Ciclo de la aplicación ===

        public void Run()
        {
            _vista.LimpiarPantalla();
            var menu = _casosdeUso.Keys.ToList<string>();

            while(true)
            try
            {
                _vista.LimpiarPantalla();
                var key = _vista.TryObtenerElementoDeLista("Panadería Biskôte",menu,"Selecciona una opción ");
                _vista.Mostrar("");
                _casosdeUso[key].Invoke();
                _vista.MostrarYReturn("Pulsa <Return> para continuar");
            }
            catch{ return; }
        }
    //-----------Casos De Uso----------------- 
    // --------------Recursos---------------------
        public void salir()
        {
            var key = "fin";
             _vista.Mostrar("Gracias\n\nHasta la próxima!!\n\n");
           
           _casosdeUso[key].Invoke();
        }
         public void volverAtras(){}

            

    // -------Gestion de Pedidos ---------------------
        private void gestionPedidos()
        {
            _gestionPedidos = new Dictionary<string, Action>()
            {
                {"Ver Pedidos",verPedidos},
                {"Añadir Pedido",aniadirPedido},
                {"Cambiar Pedido",cambiarPedido},
                 {"Volver atras",volverAtras}
            };
            var menuPedidos = _gestionPedidos.Keys.ToList<string>();
            try
            {
                 _vista.LimpiarPantalla();
                var key = _vista.TryObtenerElementoDeLista("Gestión de Pedidos",menuPedidos,"Selecciona una opción ");
                _vista.Mostrar("");
                _gestionPedidos[key].Invoke();

            }
            catch { return; }
        }

        private void aniadirPedido()
        {
            try
            {
                var dniCli = _vista.TryObtenerDatoDeTipo<string>("Introduzca dni");
                if(_sistema.misClientes.Find(cliente => dniCli.Equals(cliente.dni))==null)
                {
                    _vista.Mostrar("El dni no figura en el sistema\nPorfavor pruebe denuevo\nSi no esta registrado el dni, registre a nuevo cliente.");
                }else{
                    Dictionary<Pan, int> panParaLista= new Dictionary<Pan, int>();
                    Pan panNuevo;
                    int cantidad;
                    string fuera="";
                    Boolean salir = false;
                    while(!salir){
                        _vista.LimpiarPantalla();
                        panNuevo = _vista.TryObtenerElementoDeLista("Tipos de Pan",_sistema.misProductos,"Seleciona un Pan");
                        cantidad=_vista.TryObtenerDatoDeTipo<int>("Introduzca cantidad de unidades del pan seleccionado");
                        panParaLista.Add(panNuevo,cantidad);
                        fuera = _vista.TryObtenerDatoDeTipo<string>("Quieres salir ( S/N )");
                        if(fuera.Equals("s",StringComparison.InvariantCultureIgnoreCase))
                        {
                            salir=true;
                        }  
                    } 
                    var ID = Guid.NewGuid();
                    var fecha = DateTime.Today;   
                    var precio =_sistema.calcularPrecioPedido(panParaLista); 
                    var pagado = "false";  
                    Pedido nuevo = new Pedido
                    (
                        ID:ID,
                        dniCliente:dniCli,
                        fecha:fecha.Date,
                        precioPedido:precio,
                        pagado:pagado
                    );  
                    
                    _sistema.nuevoPedido(nuevo,panParaLista);
                }

            }catch{ return;}
            finally
            {
                _vista.Mostrar("\n\nNuevo pedido registrado.\n");
            }
        }
        private void cambiarPedido(){}

        private void verPedidos(){}



    // -------Gestion de Clientes ---------------------


        private void gestionClientes()
        {
            _gestionClientes = new Dictionary<string, Action>()
            {
                {"Añadir Cliente nuevo",aniadirCliente},
                {"Borrar Cliente",borrarCliente},
                {"Ver Cliente",verCliente},
                {"Volver atras",volverAtras}
            };
            var menuClientes = _gestionClientes.Keys.ToList<string>();
            try
            {
                 _vista.LimpiarPantalla();
                var key = _vista.TryObtenerElementoDeLista("Gestión de Clientes",menuClientes,"Selecciona una opción ");
                _vista.Mostrar("");
                _gestionClientes[key].Invoke();
            }
            catch { return; }
        }
        public void aniadirCliente()
        {
            try
            {
                var nombre = _vista.TryObtenerDatoDeTipo<string>("Nombre del cliente");
                var apellido = _vista.TryObtenerDatoDeTipo<string>("Apellido del cliente");
                var dni = _vista.TryObtenerDatoDeTipo<string>("DNI del cliente");
                var telefono = _vista.TryObtenerDatoDeTipo<string>("Telefono del cliente");
                var pueblo = _vista.TryObtenerDatoDeTipo<string>("Nombre del pueblo");
                Cliente nuevo = new Cliente
                (
                    nombre: nombre,
                    apellido: apellido,
                    dni: dni,
                    telefono: telefono,
                    pueblo: pueblo
                );
                _sistema.nuevoCliente(nuevo);
            }
            catch { return; }
            finally
            {
                _vista.Mostrar("Nuevo Cliente añadido.\nYa puede hacer su pedido.\n\n");
            }
        }
        public void borrarCliente()
        {
            Cliente c;
            c = _vista.TryObtenerElementoDeLista("Clientes registrados",_sistema.misClientes, "Selecciona un cliente para borrar sus datos");
            _sistema.borrarCliente(c);

        }
        public void verCliente()
        {
            _verClientes = new Dictionary<string, Action>()
            {
                {"Ver datos de clientes",verDatosPorCliente},
                {"Ver deudas de clientes",verDeudasPorCliente},
                {"Ver pedidos de clientes",verPedidosPorClientes}
            };
            var menuClientes2 = _verClientes.Keys.ToList<String>();
            try
            {
                 _vista.LimpiarPantalla();
                var key = _vista.TryObtenerElementoDeLista("Clientes registrados",menuClientes2,"Selecciona una cliente ");
                _vista.Mostrar("");
                _verClientes[key].Invoke();

            }catch{ return; }

        }
        public void verDatosPorCliente()
        {
           _vista.MostrarListaEnumerada<Cliente>("Lista de Clientes",_sistema.misClientes);

        }
        public void verDeudasPorCliente(){}
        public void verPedidosPorClientes(){}
        

    // -------Gestion de Finanzas ---------------------


        private void gestionFinanzas(){}





















































    }






}