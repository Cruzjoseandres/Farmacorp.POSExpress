using Farmacorp.POSExpress.Aplicacion;
using Farmacorp.POSExpress.Aplicacion.Dto.Request;
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
    Console.WriteLine("6. Ver todos los Productos");
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
        case "6": await VerProductos(scope.ServiceProvider); break;
        case "0": salir = true; break;
        default:
            Console.WriteLine("Opcion no valida.");
            Console.ReadKey();
            break;
    }
}

static async Task RegistrarProductoExpress(IServiceProvider serviceProvider)
{
    Console.Clear();
    Console.WriteLine("REGISTRAR PRODUCTO EXPRESS");

    Console.Write("Nombre del Producto: ");
    string nombre = Console.ReadLine();

    Console.Write("Tipo de Producto (1 = General): ");
    int idTipo = int.Parse(Console.ReadLine());

    Console.Write("Fecha de Vencimiento (dd/MM/yyyy): ");
    DateTime fechaVenc = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

    Console.Write("Observaciones (opcional, Enter para omitir): ");
    string obs = Console.ReadLine();
    try
    {
        var service = serviceProvider.GetRequiredService<IExpProductoService>();
        var dto = new RegistrarProductoExpressDto
        {
            Nombre = nombre,
            IdTipoProducto = idTipo,
            FechaVencimiento = fechaVenc,
            Observaciones = string.IsNullOrWhiteSpace(obs) ? null : obs
        };
        var producto = await service.RegistrarProductoExpressAsync(dto);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✓ Producto Express registrado exitosamente.");
        Console.ResetColor();
        Console.WriteLine($"  ID:               {producto.IdProducto}");
        Console.WriteLine($"  Nombre:           {producto.Nombre}");
        Console.WriteLine($"  Tipo Producto:    {producto.IdTipoProducto}");
        Console.WriteLine($"  Fecha Venc.:      {producto.FechaVencimiento:dd/MM/yyyy}");
        Console.WriteLine($"  Precio Actual:    {producto.Precio:C2} (se calcula al registrar en ERP)");
        Console.WriteLine($"  Activo:           {(producto.Activo ? "Sí" : "No")}");
        Console.WriteLine($"  Observaciones:    {producto.Observaciones ?? "(ninguna)"}");
    }
    catch (Exception ex) 
    { 
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n✗ Error:  {ex.Message}");
        Console.WriteLine($"  Causa:  {ex.InnerException?.Message}");
        Console.WriteLine($"  SQL:    {ex.InnerException?.InnerException?.Message}");
        Console.ResetColor();
    }
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
    Console.Write("Stock: ");
    int stock = int.Parse(Console.ReadLine());
    try
    {
        var service = sp.GetRequiredService<IErpProductoService>();
        await service.RegistrarProductoErpAsync(idProducto, costo, stock);
        Console.WriteLine("\n Producto ERP registrado, Precio calculado automaticamente");
    }
    catch (Exception ex) 
    { 
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n✗ Error:  {ex.Message}");
        Console.WriteLine($"  Causa:  {ex.InnerException?.Message}");
        Console.WriteLine($"  SQL:    {ex.InnerException?.InnerException?.Message}");
        Console.ResetColor();
    }
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
    catch (Exception ex) 
    { 
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n✗ Error:  {ex.Message}");
        Console.WriteLine($"  Causa:  {ex.InnerException?.Message}");
        Console.WriteLine($"  SQL:    {ex.InnerException?.InnerException?.Message}");
        Console.ResetColor();
    }
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
    
    try
    {
        var unitOfWork = sp.GetRequiredService<Farmacorp.POSExpress.Dominio.Interfaces.IUnitOfWork>();
        var categorias = await unitOfWork.Categorias.GetAllAsync();
        Console.WriteLine("\nCategorías disponibles:");
        foreach (var cat in categorias)
        {
            Console.WriteLine($"  ID: {cat.IdCategoria} - {cat.Descripcion} ({(cat.Activo ? "Activa" : "Inactiva")})");
        }
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Advertencia al cargar categorías: {ex.Message}");
    }

    Console.Write("ID de la Categoria: ");
    int idCategoria = int.Parse(Console.ReadLine());
    try
    {
        var service = sp.GetRequiredService<IProductoCategoriaService>();
        await service.AsignarCategoriaAsync(idProducto, idCategoria);
        Console.WriteLine("\n Categoria asignada correctamente");
    }
    catch (Exception ex) 
    { 
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n✗ Error:  {ex.Message}");
        Console.WriteLine($"  Causa:  {ex.InnerException?.Message}");
        Console.WriteLine($"  SQL:    {ex.InnerException?.InnerException?.Message}");
        Console.ResetColor();
    }
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
    catch (Exception ex) 
    { 
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n✗ Error:  {ex.Message}");
        Console.WriteLine($"  Causa:  {ex.InnerException?.Message}");
        Console.WriteLine($"  SQL:    {ex.InnerException?.InnerException?.Message}");
        Console.ResetColor();
    }
    Console.WriteLine("\nPresione una tecla para continuar");
    Console.ReadKey();
}

// Ver todos los productos
static async Task VerProductos(IServiceProvider sp)
{
    Console.Clear();
    Console.WriteLine("╔══════════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                     LISTA DE PRODUCTOS                          ║");
    Console.WriteLine("╚══════════════════════════════════════════════════════════════════╝");
    try
    {
        var service = sp.GetRequiredService<IExpProductoService>();
        var productos = await service.ObtenerTodosAsync();
        var lista = productos.ToList();

        if (!lista.Any())
        {
            Console.WriteLine("\n  No hay productos registrados.");
        }
        else
        {
            Console.WriteLine($"\n  Total de productos: {lista.Count}");
            Console.WriteLine();
            foreach (var p in lista)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"  ID: {p.IdProducto} — {p.Nombre}");
                Console.ResetColor();
                Console.WriteLine($"    Precio:        {p.Precio:C2}");
                Console.WriteLine($"    Activo:        {(p.Activo ? "Sí" : "No")}");
                Console.WriteLine($"    Vencimiento:   {p.FechaVencimiento:dd/MM/yyyy}");
                Console.WriteLine($"    Observaciones: {p.Observaciones ?? "(ninguna)"}");

                if (p.ErpProductos != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"    [ERP] Costo:   {p.ErpProductos.Costo:C2}");
                    Console.WriteLine($"    [ERP] Stock:   {p.ErpProductos.Stock}");
                    Console.WriteLine($"    [ERP] Código:  {p.ErpProductos.UniqueCodigo}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("    [ERP] Sin datos ERP registrados");
                    Console.ResetColor();
                }

                var cantCat = p.ProductosCategorias?.Count ?? 0;
                if (cantCat > 0)
                {
                    var nombresCategorias = string.Join(", ", p.ProductosCategorias.Select(pc => pc.Categoria?.Descripcion ?? $"ID: {pc.IdCategoria}"));
                    Console.WriteLine($"    Categorías:    {nombresCategorias}");
                }
                else
                {
                    Console.WriteLine("    Categorías:    Ninguna");
                }
                Console.WriteLine("    ──────────────────────────────────────────────────");
            }
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n✗ Error:  {ex.Message}");
        Console.WriteLine($"  Causa:  {ex.InnerException?.Message}");
        Console.ResetColor();
    }
    Console.WriteLine("\nPresione una tecla para continuar...");
    Console.ReadKey();
}



