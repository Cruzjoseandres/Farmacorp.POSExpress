# Farmacorp POS Express

Sistema POS Express desarrollado en .NET 10.

## Requisitos
- .NET 10 SDK o superior
- SQL Server LocalDB

## Instrucciones de Ejecución

Para iniciar la aplicación de consola, ejecute el siguiente comando desde la raíz de la solución:

```bash
dotnet run --project Farmacorp.POSExpress.Presentacion
```

## Uso de la Aplicación

La aplicación se controla mediante un menú interactivo en consola con las siguientes opciones:

1. **Registrar Producto ERP**: Registra un producto existente en el ERP. Solicita el ID del producto, el costo y el stock inicial. Calcula automáticamente el precio de venta aplicando la regla de negocio del margen correspondiente.
2. **Asignar Codigo de Barras**: Genera y asigna de forma automática un código de barras único para el producto.
3. **Asignar Categoria**: Muestra la lista de categorías disponibles y asocia la categoría seleccionada al producto.
4. **Registrar Venta**: Registra la venta de una cantidad del producto para un cliente. Valida la existencia de stock suficiente, descuenta las unidades e ingresa la venta aplicando los descuentos correspondientes.
5. **Registrar Producto Express**: Crea un producto nuevo en el catálogo básico (módulo Express).
6. **Ver todos los Productos**: Muestra el listado de todos los productos y el detalle completo de sus datos del módulo Express, ERP y sus categorías asignadas.

## Cambiar Estrategia de Reglas de Negocio (Base / GanaMax)

Para alternar entre las reglas de negocio Base y la estrategia GanaMax:
1. Abra el archivo `Farmacorp.POSExpress.Aplicacion/DependencyInjection.cs`.
2. Registre la estrategia deseada para `IReglasNegocio`:


// Para usar reglas Base:
services.AddScoped<IReglasNegocio, ReglasNegocioBase>();

// Para usar reglas GanaMax:
// services.AddScoped<IReglasNegocio, ReglasNegocioGanaMax>();
