using modelos;
using sistema;
using System.Globalization;

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
        private Dictionary<string, Action> _marcarPedidos;
        private Dictionary<string, Action> _validarPedidos;



        public Controlador(Vista vista, Gestor logicaNegocio)
        {
            _vista = vista;
            _sistema = logicaNegocio;
            _casosdeUso = new Dictionary<string, Action>()
            {
                {"Gestión de Pedidos",gestionPedidos},
                {"Gestion de Clientes",gestionClientes},
                {"Gestion de Finanzas",gestionFinanzas},
                {"Salir y Cerrar aplicación",salir}
            };
        }
        // =========== Ciclo de la aplicación ==========

        public void Run()
        {
            _vista.LimpiarPantalla();
            var menu = _casosdeUso.Keys.ToList<string>();

            while (true)
                try
                {
                    _vista.LimpiarPantalla();
                    var key = _vista.TryObtenerElementoDeLista("Panadería Biskôte", menu, "Selecciona una opción ");
                    _vista.Mostrar("");
                    _casosdeUso[key].Invoke();
                    _vista.MostrarYReturn("Pulsa <Return> para continuar");
                }
                catch { return; }
        }
        //----------------------Casos De Uso-----------------

        // -----------------------Recursos---------------------
        public void salir()
        {
            var key = "fin";
            _vista.Mostrar("Gracias\n\nHasta la próxima!!\n\n");

            _casosdeUso[key].Invoke();
        }
        public void volverAtras() { }



        // -------------------Gestion de Pedidos ---------------------
        private void gestionPedidos()
        {
            _gestionPedidos = new Dictionary<string, Action>()
            {
                {"Ver Pedidos",verPedidos},
                {"Marcar pedido como pagado",marcarPedidoDiaSiguiente},
                {"Validar pedido para el dia siguiente",validarPedidoDiaSiguiente},
                {"Añadir Pedido",aniadirPedido},
                {"Cambiar Pedido",cambiarPedido},
                {"Borrar Pedido",borrarPedidio},
                {"Volver atras",volverAtras}
            };
            var menuPedidos = _gestionPedidos.Keys.ToList<string>();
            try
            {
                _vista.LimpiarPantalla();
                var key = _vista.TryObtenerElementoDeLista("Gestión de Pedidos", menuPedidos, "Selecciona una opción ");
                _vista.Mostrar("");
                _gestionPedidos[key].Invoke();

            }
            catch { return; }
        }
        private void verPedidos()
        {
            foreach (Pedido i in _sistema.misPedidos)
            {
                _vista.Mostrar(i.ToString());
                foreach (PanesPedido j in i.listaDePan)
                {
                    _vista.Mostrar("          " + j.ToString());

                }
            }
            _vista.Mostrar("\n");
        }
        public void marcarPedidoDiaSiguiente()
        {
            _marcarPedidos = new Dictionary<string, Action>()
            {
                {"Marcar un pedido del dia como pagado",marcarPedidoPagado},
                {"Marcar todos los pedidos del dia como pagados",marcarAPagadoTodos},
                {"Volver atras",volverAtras}
            };
            var menuMarcar = _marcarPedidos.Keys.ToList<String>();
            try
            {
                _vista.LimpiarPantalla();
                var key = _vista.TryObtenerElementoDeLista("Opciones para Pedido", menuMarcar, "Selecciona una opción ");
                _vista.Mostrar("");
                _marcarPedidos[key].Invoke();

            }
            catch { return; }
        }

        public void marcarPedidoPagado()
        {
            Pedido nuevo = _vista.TryObtenerElementoDeLista("Lista de Pedidos", _sistema.misPedidos, "Seleciona una pedido");
            if (nuevo.estado.ToString().Equals(estadoPedido.pagado.ToString()))
            {
                _vista.Mostrar("\nEste pedido ya esta pagado!!\nPorfavor, selecciona otro", ConsoleColor.Red);
            }
            else
            {
                nuevo.estado = estadoPedido.pagado;
                _vista.Mostrar("\n\nPedido actualizado.\n", ConsoleColor.DarkYellow);
                _sistema.actualizarMisPedidosConPedidoActualizado();
            }

        }
        public void marcarAPagadoTodos()
        {
            _sistema.marcarAPagadoTodos();
            _vista.Mostrar("\n\nPedidos actualizados. \n", ConsoleColor.DarkYellow);
        }

        public void validarPedidoDiaSiguiente()
        {
            _validarPedidos = new Dictionary<string, Action>()
            {
                {"Validar un pedido para el dia siguiente",cambiarFechaPedido},
                {"Validar todos los pedidos para el dia siguiente",cambiarFechasPedidos},
                {"Volver atras",volverAtras}
            };
            var menuValidar = _validarPedidos.Keys.ToList<String>();
            try
            {
                _vista.LimpiarPantalla();
                var key = _vista.TryObtenerElementoDeLista("Opciones para Pedido", menuValidar, "Selecciona una opción ");
                _vista.Mostrar("");
                _validarPedidos[key].Invoke();

            }
            catch { return; }
        }
        public void cambiarFechaPedido()
        {
            Pedido nuevo = _vista.TryObtenerElementoDeLista("Lista de Pedidos", _sistema.misPedidos, "Seleciona una pedido");
            if (nuevo.fecha.ToShortDateString().Equals(_sistema.undiaMas(DateTime.Today).ToShortDateString()))
            {
                _vista.Mostrar("\nEste pedido ya es para mañana!!\nPorfavor, selecciona otro", ConsoleColor.Red);
            }
            else
            {
                nuevo.fecha = _sistema.undiaMas(DateTime.Today);
                _sistema.actualizarMisPedidosConPedidoActualizado();
                _vista.Mostrar("\n\nPedido actualizado para el dia siguiente.\n", ConsoleColor.DarkYellow);
            }


        }
        public void cambiarFechasPedidos()
        {
            _sistema.cambiarFechasPedidos();
            _vista.Mostrar("\n\nPedidos actualizados para el dia siguiente.\n", ConsoleColor.DarkYellow);
        }

        private void aniadirPedido()
        {
            try
            {
                var dniCli = _vista.TryObtenerDatoDeTipo<string>("Introduzca dni");
                if (_sistema.misClientes.Find(cliente => dniCli.Equals(cliente.dni)) == null)
                {
                    _vista.Mostrar("El dni no figura en el sistema\nPorfavor pruebe denuevo\nSi no esta registrado el dni, registre a nuevo cliente.");
                }
                else
                {
                    if (_sistema.clienteTienePedido(dniCli))
                    {
                        _vista.Mostrar("Ya hay un pedido registrado con este dni.\nSi quiere modificarlo acceda a cambiar pedido.");
                    }
                    else
                    {
                        Dictionary<Pan, int> panParaLista = new Dictionary<Pan, int>();
                        Pan panNuevo;
                        int cantidad;
                        string fuera = "";
                        while (true)
                        {
                            _vista.LimpiarPantalla();
                            try
                            {
                                panNuevo = _vista.TryObtenerElementoDeLista("Tipos de Pan", _sistema.misProductos, "Seleciona un Pan");
                                cantidad = _vista.TryObtenerDatoDeTipo<int>("Introduzca cantidad de unidades del pan seleccionado");
                                panParaLista.Add(panNuevo, cantidad);
                            }
                            catch { _vista.Mostrar("\nYa se ha introducido datos para este tipo de pan\n"); }
                            fuera = _vista.TryObtenerDatoDeTipo<string>("Has terminado?? ( S/N )");
                            if (fuera.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                                break;
                        }
                        var ID = Guid.NewGuid();
                        var fecha = _sistema.undiaMas(DateTime.Today);
                        var precio = _sistema.calcularPrecioPedido(panParaLista);
                        var estado = estadoPedido.pendiente;
                        Pedido nuevo = new Pedido
                        (
                            ID: ID,
                            dniCliente: dniCli,
                            fecha: fecha.Date,
                            precioPedido: precio,
                            estado: estado
                        );
                        _sistema.nuevoPedido(nuevo, panParaLista);
                        _vista.Mostrar("\n\nNuevo pedido registrado.\n", ConsoleColor.DarkYellow);

                    }
                }

            }
            catch { return; }
        }
        private void cambiarPedido()
        {
            try
            {
                Pedido nuevo = _vista.TryObtenerElementoDeLista<Pedido>("Lista de Pedidos", _sistema.misPedidos, "Selecciona un pedido que quieras cambiar");
                Dictionary<Pan, int> panParaLista = new Dictionary<Pan, int>();
                Pan panNuevo;
                int cantidad;
                string fuera = "";
                while (true)
                {
                    _vista.LimpiarPantalla();
                    try
                    {
                        panNuevo = _vista.TryObtenerElementoDeLista("Tipos de Pan", _sistema.misProductos, "Seleciona un Pan");
                        cantidad = _vista.TryObtenerDatoDeTipo<int>("Introduzca cantidad de unidades del pan seleccionado");
                        panParaLista.Add(panNuevo, cantidad);
                    }
                    catch { _vista.Mostrar("\nYa se ha introducido datos para este tipo de pan\n"); }
                    fuera = _vista.TryObtenerDatoDeTipo<string>("Has terminado?? ( S/N )");
                    if (fuera.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                        break;
                }
                var ID = Guid.NewGuid();
                var fecha = _sistema.undiaMas(DateTime.Today);
                var precio = _sistema.calcularPrecioPedido(panParaLista);
                var estado = estadoPedido.pendiente;
                Pedido otro = new Pedido
                    (
                        ID: ID,
                        dniCliente: nuevo.dniCliente,
                        fecha: fecha.Date,
                        precioPedido: precio,
                        estado: estado
                    );

                _sistema.nuevoPedido(otro, panParaLista);
                _sistema.borrarPedido(nuevo);

                _vista.Mostrar("\n\nPedido actualizado\n", ConsoleColor.DarkYellow);
            }
            catch { return; }
        }
        private void borrarPedidio()
        {
            Pedido nuevo = _vista.TryObtenerElementoDeLista<Pedido>("Pedidos registrados", _sistema.misPedidos, "Selecciona un pedido");
            _sistema.borrarPedido(nuevo);
            _vista.Mostrar("\n\nPedido borrado\n", ConsoleColor.DarkYellow);
        }


        // -------------------Gestion de Clientes ---------------------


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
                var key = _vista.TryObtenerElementoDeLista("Gestión de Clientes", menuClientes, "Selecciona una opción ");
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
            c = _vista.TryObtenerElementoDeLista("Clientes registrados", _sistema.misClientes, "Selecciona un cliente para borrar sus datos");
            _sistema.borrarCliente(c);

        }
        public void verCliente()
        {
            _verClientes = new Dictionary<string, Action>()
            {
                {"Ver datos de clientes",verDatosPorCliente},
                {"Ver clientes con precio del pedido diario",verDeudasDiariasPorCliente},
                {"Ver clientes con deudas pendientes",verTotalDeudasPorCliente},
                {"Ver pedidos por cliente",verPedidosPorClientes},
                {"Volver atras",volverAtras}
            };
            var menuClientes2 = _verClientes.Keys.ToList<String>();
            try
            {
                _vista.LimpiarPantalla();
                var key = _vista.TryObtenerElementoDeLista("Clientes registrados", menuClientes2, "Selecciona una cliente ");
                _vista.Mostrar("");
                _verClientes[key].Invoke();

            }
            catch { return; }

        }
        public void verDatosPorCliente()
        {
            _vista.MostrarListaEnumerada<Cliente>("Lista de Clientes", _sistema.misClientes);

        }
        public void verDeudasDiariasPorCliente()
        {
            List<string> lista = new List<string>();
            foreach (Cliente i in _sistema.misClientes)
            {
                if (_sistema.pedidoDeCliente(i) != null && _sistema.pedidoDeCliente(i).estado == estadoPedido.pendiente)
                {
                    lista.Add(i.verClientesConPedido() + " - Deuda a pagar: " + _sistema.pedidoDeCliente(i).precioPedido + " \u20AC ");
                }
                else if (_sistema.pedidoDeCliente(i) != null)
                {
                    lista.Add(i.verClientesConPedido() + " - Deuda a pagar: 0  \u20AC");
                }

            }
            _vista.MostrarListaEnumerada<string>("Lista de Clientes con sus Deudas diarias", lista);

        }
        public void verTotalDeudasPorCliente()
        {
            List<string> lista = new List<string>();
            foreach (Cliente i in _sistema.misClientes)
            {
                if (_sistema.pedidoDeCliente(i) != null && _sistema.pedidoDeCliente(i).estado == estadoPedido.pendiente)
                {
                    lista.Add(i.verClientesConPedido() + " - Deuda a pagar: " + (_sistema.asignarDeudaSPorCliente2(i) + _sistema.pedidoDeCliente(i).precioPedido) + " \u20AC ");/**/
                }
                else if (_sistema.pedidoDeCliente(i) != null && _sistema.pedidoDeCliente(i).estado == estadoPedido.pagado)
                {
                    lista.Add(i.verClientesConPedido() + " - Deuda a pagar: " + _sistema.asignarDeudaSPorCliente2(i) + " \u20AC");
                }
                else if (_sistema.pedidoDeCliente(i) != null)
                {
                    lista.Add(i.verClientesConPedido() + " - Deuda a pagar: 0 \u20AC");
                }

            }
            _vista.MostrarListaEnumerada<string>("Lista de Clientes con sus Deudas", lista);

        }

        public void verPedidosPorClientes()
        {
            Cliente nuevo;
            nuevo = _vista.TryObtenerElementoDeLista("Clientes", _sistema.misClientes, "Selecciona un cliente");
            _vista.Mostrar("\nCliente", ConsoleColor.DarkYellow);
            _vista.Mostrar(nuevo.ToString());
            _vista.Mostrar("\nPedido: ", ConsoleColor.DarkYellow);
            _vista.Mostrar(_sistema.pedidoDeCliente(nuevo).stringParaVerCliente() + "\n");
            _vista.Mostrar("Lista de panes\n", ConsoleColor.DarkYellow);

            foreach (PanesPedido i in _sistema.pedidoDeCliente(nuevo).listaDePan)
            {
                _vista.Mostrar(i.ToString() + "\n");
            }
            _vista.Mostrar("\n");
        }


        // ---------------Gestion de Finanzas ---------------------


        private void gestionFinanzas()
        {
            _gestionFinanzas = new Dictionary<string, Action>()
            {
                {"Liquidar deudas por cliente",liquidarDeudasPorCliente},
                {"Ver deudas diarias por cliente",verDeudasDiariasPorCliente},
                {"Ver deudas pendientes Totales por cliente",verTotalDeudasPorCliente},
                {"Volver atras",volverAtras}

            };
            var menuFinanzas = _gestionFinanzas.Keys.ToList<String>();
            try
            {
                _vista.LimpiarPantalla();
                var key = _vista.TryObtenerElementoDeLista("Gestion de Finanzas", menuFinanzas, "Selecciona una opción");
                _vista.Mostrar("");
                _gestionFinanzas[key].Invoke();

            }
            catch { return; }
        }
        public void liquidarDeudasPorCliente()
        {
            Decimal dineroAPagar = 0;
            Cliente nuevo = _vista.TryObtenerElementoDeLista<Cliente>("Clientes de la Panaderia", _sistema.misClientes, "Selecciona un cliente");

            if (nuevo.deudasPendientes > 0)
            {
                dineroAPagar = nuevo.deudasPendientes;
                if (_sistema.pedidoDeCliente(nuevo).estado == estadoPedido.pendiente)
                {
                    var esto = _vista.TryObtenerDatoDeTipo<string>("\nQuieres añadir el pedido de hoy a la suma del dinero pendiente?? S/N\n");
                    if (esto.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                    {
                        dineroAPagar += _sistema.pedidoDeCliente(nuevo).precioPedido;
                        _sistema.pedidoDeCliente(nuevo).estado = estadoPedido.pagado;

                    }

                }
                _vista.Mostrar("\nTotal a pagar " + dineroAPagar.ToString(CultureInfo.InvariantCulture) + "\n", ConsoleColor.DarkYellow);
                _sistema.borrarDeudas(nuevo);
                _sistema.actualizarMisDeudasConPedidoActualizado();
                _sistema.actualizarMisPedidosConPedidoActualizado();
                _vista.Mostrar("Deudas liquidadas.\nGracias.");

            }
            else
            {
                _vista.Mostrar("\nEste cliente no tiene deudas pendientes\nVe a gestion de clientes/ver clientes/ver clientes con deudas pendientes,\no Ve a gestion finanzas/Ver deudas pendientes Totales por cliente\nPara ver quienes tienen deudas pendientes.\nGracias\n", ConsoleColor.Red);
            }


        }

    }

}