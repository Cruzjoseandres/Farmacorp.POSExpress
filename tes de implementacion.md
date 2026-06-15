TEST: DESARROLLO E IMPLEMENTACIÓN
SISTEMA FARMACORP POS EXPRESS
El presente diseño representa el sistema POS EXPRESS. El sistema inicialmente nace con el módulo Express, que
permitía realizar la Venta Express de los productos, es decir una venta por artículo. Los inversionistas
posteriormente decidieron implementar el módulo ERP que permitiría incluir la funcionalidad de catálogo e
inventario base, inicialmente completaría información relacionado al producto: Costo, Código Único del Producto
(UniqueCodigo), Stock, Códigos de Barras, etc. El cual se ve reflejado en el diseño.
Como práctica se requiere implementar las siguientes transacciones con reglas de negocios Base:
1. Registro Nuevo Producto ERP.
a. El valor único para UniqueCodigo debe ser generado automáticamente.
b. Regla de Negocio 1, el precio del producto se determina como un margen del 50% del costo del
producto.
2. Registro Asignación de Códigos de Barras
a. El valor único para UniqueCodigo que representa el código de barra debe ser generado
automáticamente.
3. Registro de Asignación de Categorías de Productos
4. Registro de Venta
a. La venta es realizada para un único producto
b. Regla de Negocio 2, se desea registrar el UniqueCodigo del producto como parte de la venta.
c. Regla de Negocio 3, se aplicará un descuento del 30% si y solo si el producto está asociado a una
única categoría.
d. Regla de Negocio 4, solo se permite la venta si el articulo tiene Stock disponible.
e. Regla de Negocio 5, como parte de la venta se debe actualizar el Stock del artículo en el módulo
ERP.
El sistema debe implementarse con base tecnológica .NET en el lenguaje C#, con las siguientes condiciones:
1. El proyecto debe presentar una Arquitectura N-Capas
2. Capa de Presentación deberá ser un Proyecto de Consola.
3. Deberá incluirse los siguientes conceptos: UnitOfWork, Repositories, Inversión de Control e Inyección de
Dependencia
4. Acceso a datos con: Entity Framework Code First, Fluent API Configurations y SQL Server Express LocalDB
El proyecto puede enviarse por correo en formato. Zip o adjuntarnos el link de algún repositorio de código: Github,
GitLab, Bitbucket, etc
ESTRATEGIA GANAMAX
Como estrategia de negocio GanaMax, el sistema deberá actualizarse durante 3 meses en las correspondientes
reglas de negocios, permitiendo volver en cualquier momento a las establecidas en el negocio Base:
1. Registro Nuevo Producto ERP.
a. Regla de Negocio 1, el precio del producto se determina como un margen del 80% del costo del
producto.
2. Registro de Venta
a. Regla de Negocio 3, se aplicará un descuento del 10% si y solo si el producto está asociado a una
única categoría.
b. Regla de Negocio 4, solo se permite la venta si el articulo tiene Stock disponible y una vez
completada la venta deja un Stock por encima de 10 unidades.
Nota: Las reglas no especificadas se mantienen como se establece en el negocio Base.