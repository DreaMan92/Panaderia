
using sistema;
using System.Linq;
using System.Collections.Generic;
using System;






namespace consola 
{
    class Controlador
    {
        private Vista _vista;
        private Gestor _sistema;
        private Dictionary<string, Action> _casosdeUso;
        private Dictionary<string, Action> _gestionPedidos;
        private Dictionary<string, Action> _gestionClientess;
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
        public void salir()
        {
            var key = "fin";
             _vista.Mostrar("Gracias\n\nHasta la próxima!!\n\n");
           
           _casosdeUso[key].Invoke();
        }
        // === Casos De Uso ===

    // -------Gestion de Pedidos ---------------------
        private void gestionPedidos()
        {
            _gestionPedidos = new Dictionary<string, Action>()
            {
                {"Ver Pedidos",verPedidos},
                {"Añadir Pedido",aniadirPedido},
                {"Cambiar Pedido",cambiarPedido}
            };
            var menuPedidos = _gestionPedidos.Keys.ToList<string>();
            try
            {
                 _vista.LimpiarPantalla();
                var key = _vista.TryObtenerElementoDeLista("Gestión de Pedidos",menuPedidos,"Selecciona una opción ");
                _vista.Mostrar("");
                _casosdeUso[key].Invoke();
                _vista.MostrarYReturn("Pulsa <Return> para continuar");

            }
            catch { return; }
        }

        private void aniadirPedido()
        {
            try
            {
                var dniCliente = _vista.TryObtenerDatoDeTipo<string>("Introduzca dni");
                if(_sistema.misClientes.Find(cliente => dniCliente.Equals(cliente.dni))==null)
                {
                    _vista.Mostrar("El dni no figura en el sistema\nPorfavor pruebe denuevo\no registre a nuevo cliente.");
                }else{
                    

                    // var fecha = _vista.TryObtenerDatoDeTipo<string>("Introduzca fecha");
                    // var precioPedido
                }

            }
        }
        private void cambiarPedido(){}

        private void verPedidos(){}



    // -------Gestion de Clientes ---------------------


        private void gestionClientes(){}


    // -------Gestion de Finanzas ---------------------


        private void gestionFinanzas(){}





















































    }






}