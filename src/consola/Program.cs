using datos;
using sistema;
using consola;




var RePoC = new ClientesCSV();
var RePoP = new PedidosCSV();
var RepoPanPedido = new PanesPedidosCSV();
var view = new Vista();
var sistema = new Gestor(RePoC, RePoP,RepoPanPedido);
var controlador = new Controlador(view,sistema);
controlador.Run();

