using DataAccess_Library;
using Noleggio_Library;

var controller = new SistemaNoleggiDataController();

// TODO Prova
await controller.AddCliente(new Cliente("Lorenzo", "Conti", "L:SKDJF"));
Console.ReadKey();