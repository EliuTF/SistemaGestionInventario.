using SistemaGestionInventario.Controladores;
using SistemaGestionInventario.Modelos;
using System;
using System.Linq;

namespace SistemaGestionInventario
{
    class Program
    {
        private static ConexionDB GetContext()
        {
            ConexionDB conexionDB = null;
            return conexionDB;
        }

        static void Main(string[] args, ConexionDB context)
        {
            ConexionDB conexionDB = new ConexionDB();
            var productoController = new ProductoController(context);

            var nuevoProducto = new Producto
            {
                Nombre = "Laptop",
                Codigo = "LPT-100",
                Categoria = "Electrónica",
                Precio = 750.00M,
                Existencia = 15,
                Proveedor = "ProveedorX"
            };

            productoController.AgregarProducto(nuevoProducto);
            Console.WriteLine("Producto agregado: Laptop");

            var productosElectronica = productoController.ConsultarPorCategoria("Electrónica").ToList();
            Console.WriteLine("\nProductos en la categoría 'Electrónica':");
            foreach (var producto in productosElectronica)
            {
                Console.WriteLine($"Producto: {producto.Nombre}, Precio: {producto.Precio}, Stock: {producto.Existencia}");
            }

            var productosBajoStock = productoController.ObtenerStockBajo().ToList();
            Console.WriteLine("\nProductos con stock bajo:");
            foreach (var producto in productosBajoStock)
            {
                Console.WriteLine($"Producto: {producto.Nombre}, Stock: {producto.Existencia}");
            }

            var exportador = new Exportador();
            exportador.ExportarProductosACSV(productosElectronica);
            Console.WriteLine("\nProductos exportados a productos.csv");
        }
    }
}
