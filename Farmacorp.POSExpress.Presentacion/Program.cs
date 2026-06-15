using Farmacorp.POSExpress.Aplicacion;
using Farmacorp.POSExpress.Aplicacion.Interfaces.Erp;
using Farmacorp.POSExpress.Aplicacion.Interfaces.Express;
using Farmacorp.POSExpress.Aplicacion.Services.Erp;
using Farmacorp.POSExpress.Aplicacion.Services.Express;
using Farmacorp.POSExpress.Infraestructura;
using Farmacorp.POSExpress.Infraestructura.Data;
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var services = new ServiceCollection();
services.AddInfraestructura(configuration);
services.AddAplicacion();
var provider = services.BuildServiceProvider();
// Crear la base de datos si no existe
using (var scope = provider.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}
// Menú principal
bool salir = false;
while (!salir)
{
    Console.Clear();
    
    Console.WriteLine("FARMACORP POS EXPRESS");
    Console.WriteLine("1. Registrar Producto ERP");
    Console.WriteLine("2. Asignar Código de Barras");
    Console.WriteLine("3. Asignar Categoría");
    Console.WriteLine("4. Registrar Venta");
    Console.WriteLine("5. Registrar Producto Express");
    Console.WriteLine("0. Salir");
    
    Console.Write("\nSeleccione una opción: ");
    var opcion = Console.ReadLine();
    using var scope = provider.CreateScope();
    switch (opcion)
    {
        case "1": await RegistrarProductoErp(scope.ServiceProvider); break;
        case "2": await AsignarCodigoBarra(scope.ServiceProvider); break;
        case "3": await AsignarCategoria(scope.ServiceProvider); break;
        case "4": await RegistrarVenta(scope.ServiceProvider); break;
        case "5": await RegistrarProductoExpress(scope.ServiceProvider); break;
        case "0": salir = true; break;
        default:
            Console.WriteLine("Opcion no valida.");
            Console.ReadKey();
            break;
    }
}

async Task RegistrarProductoExpress(IServiceProvider serviceProvider)
{
    Console.Clear();
    Console.WriteLine("REGISTRAR PRODUCTO EXPRESS");
    Console.Write("ID del Producto Express: ");
    int idProducto = int.Parse(Console.ReadLine());
    Console.Write("Costo: ");
    decimal costo = decimal.Parse(Console.ReadLine());
    try
    {
        var service = sp.GetRequiredService<IErpProductoService>();
        await service.RegistrarProductoErpAsync(idProducto, costo);
        Console.WriteLine("\n Producto ERP registrado, Precio calculado automaticamente");
    }
    catch (Exception ex) { Console.WriteLine($"\n Error: {ex.Message}"); }
    Console.WriteLine("\nPresione una tecla para continuar");
    Console.ReadKey();
}


// Transacción 1 
static async Task RegistrarProductoErp(IServiceProvider sp)
{
    Console.Clear();
    Console.WriteLine("REGISTRAR PRODUCTO ERP");
    Console.Write("ID del Producto Express: ");
    int idProducto = int.Parse(Console.ReadLine());
    Console.Write("Costo: ");
    decimal costo = decimal.Parse(Console.ReadLine());
    try
    {
        var service = sp.GetRequiredService<IErpProductoService>();
        await service.RegistrarProductoErpAsync(idProducto, costo);
        Console.WriteLine("\n Producto ERP registrado, Precio calculado automaticamente");
    }
    catch (Exception ex) { Console.WriteLine($"\n Error: {ex.Message}"); }
    Console.WriteLine("\nPresione una tecla para continuar");
    Console.ReadKey();
}
// Transacción 2
static async Task AsignarCodigoBarra(IServiceProvider sp)
{
    Console.Clear();
    Console.WriteLine("ASIGNAR CODIGO DE BARRAS");
    Console.Write("ID del Producto: ");
    int idProducto = int.Parse(Console.ReadLine());
    try
    {
        var service = sp.GetRequiredService<ICodigoBarrasService>();
        await service.AsignarCodigoBarraAsync(idProducto);
        Console.WriteLine("\n Codigo de barras asignado, UniqueCodigo generado automaticamente.");
    }
    catch (Exception ex) { Console.WriteLine($"\n✗ Error: {ex.Message}"); }
    Console.WriteLine("\nPresione una tecla para continuar");
    Console.ReadKey();
}
//Transacción 3
static async Task AsignarCategoria(IServiceProvider sp)
{
    Console.Clear();
    Console.WriteLine("ASIGNAR CATEGORIA A PRODUCTO");
    Console.Write("ID del Producto: ");
    int idProducto = int.Parse(Console.ReadLine());
    Console.Write("ID de la Categoria: ");
    int idCategoria = int.Parse(Console.ReadLine());
    try
    {
        var service = sp.GetRequiredService<IProductoCategoriaService>();
        await service.AsignarCategoriaAsync(idProducto, idCategoria);
        Console.WriteLine("\n Categoria asignada correctamente");
    }
    catch (Exception ex) { Console.WriteLine($"\n Error: {ex.Message}"); }
    Console.WriteLine("\nPresione una tecla para continuar");
    Console.ReadKey();
}
//Transacción 4
static async Task RegistrarVenta(IServiceProvider sp)
{
    Console.Clear();
    Console.WriteLine("REGISTRAR VENTA");
    Console.Write("ID del Producto: ");
    int idProducto = int.Parse(Console.ReadLine());
    Console.Write("Cliente: ");
    string cliente = Console.ReadLine();
    Console.Write("Cantidad: ");
    int cantidad = int.Parse(Console.ReadLine());
    try
    {
        var service = sp.GetRequiredService<IVentaExpressService>();
        await service.RegistrarVentaAsync(idProducto,  cantidad, cliente);
        Console.WriteLine("\n Venta registrada correctamente");
    }
    catch (Exception ex) { Console.WriteLine($"\n Error: {ex.Message}"); }
    Console.WriteLine("\nPresione una tecla para continuar");
    Console.ReadKey();
}




