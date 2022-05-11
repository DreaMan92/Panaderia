using datos;
using sistema;
using consola;




var RePoC = new ClientesCSV();
var RePoP = new PedidosCSV();
var view = new Vista();
var sistema = new Gestor(RePoC, RePoP);
var controlador = new Controlador(view,sistema);
controlador.Run();
