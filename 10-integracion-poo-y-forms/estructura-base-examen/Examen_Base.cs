using System;
using System.IO;

namespace ExamenFinal
{
    // ============================================
    // CLASE PRODUCTO - COMPLETAR
    // ============================================
    class Producto
    {
        // TODO: Declarar las 4 propiedades
        // Codigo (int)
        // Nombre (string)
        // Cantidad (int)
        // Precio (int)


        // TODO: Crear el constructor que reciba los 4 parámetros


        // TODO: Implementar método ATexto()
        // Debe retornar: codigo|nombre|cantidad|precio


        // TODO: Implementar método DesdeTexto(string linea)
        // Debe usar Split('|') y crear un objeto Producto


        // TODO: Implementar método Mostrar()
        // Debe imprimir: Código: X | Nombre: Y | Cantidad: Z | Precio: $W

    }

    // ============================================
    // PROGRAMA PRINCIPAL
    // ============================================
    class Program
    {
        // TODO: Declarar arreglo de productos (30 posiciones)
        // TODO: Declarar variable contador
        // TODO: Declarar variable archivo = "productos.txt"

        static void Main(string[] args)
        {
            // Cargar productos al inicio
            CargarProductos();

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE PRODUCTOS ===");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Mostrar todos los productos");
                Console.WriteLine("3. Buscar producto por código");
                Console.WriteLine("4. Guardar y salir");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarProducto();
                        break;
                    case "2":
                        MostrarProductos();
                        break;
                    case "3":
                        BuscarProducto();
                        break;
                    case "4":
                        GuardarProductos();
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("\n¡Hasta luego!");
        }

        // ============================================
        // MÉTODO: AGREGAR PRODUCTO
        // ============================================
        static void AgregarProducto()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR PRODUCTO ===\n");

            // TODO: Validar que haya espacio en el arreglo

            // TODO: Pedir datos al usuario (Código, Nombre, Cantidad, Precio)

            // TODO: Crear objeto Producto

            // TODO: Agregarlo al arreglo

            // TODO: Incrementar contador

            // TODO: Mostrar mensaje de confirmación
        }

        // ============================================
        // MÉTODO: MOSTRAR PRODUCTOS
        // ============================================
        static void MostrarProductos()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE PRODUCTOS ===\n");

            // TODO: Validar si hay productos

            // TODO: Recorrer el arreglo hasta el contador (NO hasta Length)

            // TODO: Llamar al método Mostrar() de cada producto

            // TODO: Mostrar total de productos
        }

        // ============================================
        // MÉTODO: BUSCAR PRODUCTO
        // ============================================
        static void BuscarProducto()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR PRODUCTO ===\n");

            // TODO: Pedir código a buscar

            // TODO: Recorrer arreglo buscando el código

            // TODO: Si se encuentra, mostrar con Mostrar()

            // TODO: Si no se encuentra, mostrar mensaje
        }

        // ============================================
        // MÉTODO: GUARDAR PRODUCTOS (PROPORCIONADO)
        // ============================================
        static void GuardarProductos()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    for (int i = 0; i < cantidadProductos; i++)
                    {
                        writer.WriteLine(productos[i].ATexto());
                    }
                }
                Console.WriteLine("Productos guardados correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar: {ex.Message}");
            }
        }

        // ============================================
        // MÉTODO: CARGAR PRODUCTOS (PROPORCIONADO)
        // ============================================
        static void CargarProductos()
        {
            if (!File.Exists(archivo))
            {
                return;
            }

            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string linea;
                    cantidadProductos = 0;

                    while ((linea = reader.ReadLine()) != null)
                    {
                        productos[cantidadProductos] = Producto.DesdeTexto(linea);
                        cantidadProductos++;
                    }
                }
                Console.WriteLine($"Se cargaron {cantidadProductos} productos");
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar: {ex.Message}");
            }
        }
    }
}
