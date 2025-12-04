# Material de Reforzamiento - Taller de Programación I

**Modalidad:** Autoestudio  
**Destinado a:** Estudiantes que rinden examen

---

## Objetivo de la Clase

Reforzar los conceptos fundamentales evaluados en el examen:
- Arreglos (vectores y matrices)
- Funciones y métodos
- Programación Orientada a Objetos (clases simples)
- Uso de archivos de texto (lectura y escritura)

---

## Estructura del Material

1. **Ejemplo Guiado Completo**
2. **Ejercicio de Práctica**
3. **Errores Comunes y Buenas Prácticas**

---

## PARTE 1: Ejemplo Guiado Completo

### Problema: Sistema de Gestión de Productos

**Descripción:** Crear un programa de consola que gestione productos de una tienda pequeña.

**Requisitos:**
- Usar una clase `Producto`
- Almacenar productos en un arreglo
- Guardar y cargar datos desde un archivo TXT
- Implementar métodos para agregar, mostrar y buscar productos

---

### Paso 1: Crear la clase Producto

```csharp
using System;

namespace GestionProductos
{
    class Producto
    {
        // Propiedades
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        // Constructor
        public Producto(int codigo, string nombre, int cantidad, decimal precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
        }

        // Método para convertir a texto (para guardar en archivo)
        public string ATexto()
        {
            return $"{Codigo}|{Nombre}|{Cantidad}|{Precio}";
        }

        // Método para crear producto desde texto (para leer de archivo)
        public static Producto DesdeTexto(string linea)
        {
            string[] datos = linea.Split('|');
            return new Producto(
                int.Parse(datos[0]),
                datos[1],
                int.Parse(datos[2]),
                decimal.Parse(datos[3])
            );
        }

        // Método para mostrar información
        public void Mostrar()
        {
            Console.WriteLine($"Código: {Codigo} | Nombre: {Nombre} | Cantidad: {Cantidad} | Precio: ${Precio}");
        }
    }
}
```

**Explicación:**
- La clase tiene 4 propiedades básicas
- El constructor inicializa el objeto
- `ATexto()` convierte el objeto a string para guardar
- `DesdeTexto()` crea un objeto desde una línea de texto
- `Mostrar()` imprime la información en consola

---

### Paso 2: Crear el programa principal

```csharp
using System;
using System.IO;

namespace GestionProductos
{
    class Program
    {
        // Arreglo de productos (máximo 100)
        static Producto[] productos = new Producto[100];
        static int cantidadProductos = 0;
        static string archivo = "productos.txt";

        static void Main(string[] args)
        {
            CargarProductos();

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTIÓN DE PRODUCTOS ===");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Mostrar todos los productos");
                Console.WriteLine("3. Buscar producto por código");
                Console.WriteLine("4. Salir");
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
    }
}
```

**Explicación:**
- Arreglo estático `productos[]` para almacenar hasta 100 productos
- Variable `cantidadProductos` para llevar el conteo
- Menú con while para mantener el programa ejecutándose
- Switch para manejar las opciones del usuario

---

### Paso 3: Implementar el método AgregarProducto

```csharp
static void AgregarProducto()
{
    Console.Clear();
    Console.WriteLine("=== AGREGAR PRODUCTO ===\n");

    if (cantidadProductos >= productos.Length)
    {
        Console.WriteLine("ERROR: No hay espacio para más productos");
        return;
    }

    Console.Write("Código: ");
    int codigo = int.Parse(Console.ReadLine());

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Cantidad: ");
    int cantidad = int.Parse(Console.ReadLine());

    Console.Write("Precio: ");
    decimal precio = decimal.Parse(Console.ReadLine());

    // Crear el producto y agregarlo al arreglo
    productos[cantidadProductos] = new Producto(codigo, nombre, cantidad, precio);
    cantidadProductos++;

    Console.WriteLine("\n¡Producto agregado exitosamente!");
}
```

**Explicación:**
- Verifica que haya espacio en el arreglo
- Lee los datos del usuario
- Crea un nuevo objeto `Producto`
- Lo agrega al arreglo en la posición `cantidadProductos`
- Incrementa el contador

---

### Paso 4: Implementar MostrarProductos y BuscarProducto

```csharp
static void MostrarProductos()
{
    Console.Clear();
    Console.WriteLine("=== LISTA DE PRODUCTOS ===\n");

    if (cantidadProductos == 0)
    {
        Console.WriteLine("No hay productos registrados");
        return;
    }

    for (int i = 0; i < cantidadProductos; i++)
    {
        productos[i].Mostrar();
    }

    Console.WriteLine($"\nTotal de productos: {cantidadProductos}");
}

static void BuscarProducto()
{
    Console.Clear();
    Console.WriteLine("=== BUSCAR PRODUCTO ===\n");

    Console.Write("Ingrese el código del producto: ");
    int codigo = int.Parse(Console.ReadLine());

    bool encontrado = false;
    for (int i = 0; i < cantidadProductos; i++)
    {
        if (productos[i].Codigo == codigo)
        {
            Console.WriteLine("\nProducto encontrado:");
            productos[i].Mostrar();
            encontrado = true;
            break;
        }
    }

    if (!encontrado)
    {
        Console.WriteLine("\nProducto no encontrado");
    }
}
```

**Explicación:**
- `MostrarProductos()` recorre el arreglo con un for hasta `cantidadProductos`
- `BuscarProducto()` busca por código usando un for y una bandera `encontrado`

---

### Paso 5: Implementar persistencia con archivos

```csharp
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

static void CargarProductos()
{
    if (!File.Exists(archivo))
    {
        return; // Si no existe el archivo, no hay nada que cargar
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
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al cargar: {ex.Message}");
    }
}
```

**Explicación:**
- `GuardarProductos()` escribe cada producto en una línea del archivo
- Usa el método `ATexto()` de la clase Producto
- `CargarProductos()` lee línea por línea
- Usa el método `DesdeTexto()` para recrear los objetos
- Try-catch para manejar errores de archivo

---

### Ejecución Esperada

```
=== SISTEMA DE GESTIÓN DE PRODUCTOS ===
1. Agregar producto
2. Mostrar todos los productos
3. Buscar producto por código
4. Salir

Seleccione una opción: 1

=== AGREGAR PRODUCTO ===

Código: 101
Nombre: Laptop
Cantidad: 5
Precio: 599990

¡Producto agregado exitosamente!

Presione una tecla para continuar...
```

---

## PARTE 2: Ejercicio de Práctica

### Problema: Sistema de Registro de Libros

**Instrucciones:** Crea un programa de consola que gestione una biblioteca simple.

**Requisitos:**

1. **Clase Libro** con las siguientes propiedades:
   - `int Codigo` - Código del libro
   - `string Titulo` - Título del libro
   - `string Autor` - Autor del libro
   - `int Cantidad` - Cantidad disponible

2. **Constructor** que reciba los 4 parámetros

3. **Métodos de la clase:**
   - `string ATexto()` - convierte a formato: `codigo|titulo|autor|cantidad`
   - `static Libro DesdeTexto(string linea)` - crea un libro desde texto
   - `void Mostrar()` - imprime: Código, Título, Autor y Cantidad

4. **Programa principal:**
   - Arreglo de libros (máximo 30)
   - Menú con opciones:
     - Agregar libro
     - Mostrar todos los libros
     - Buscar libro por código
     - Guardar y salir
   - Guardar en archivo `libros.txt`
   - Cargar datos al inicio

**Pistas:**
- Usa el mismo patrón que el ejemplo de Productos
- El formato del archivo: `codigo|titulo|autor|cantidad`
- Ejemplo: `1|Cien Años de Soledad|Gabriel García Márquez|3`

---

### Solución del Ejercicio Individual

<details>
<summary><b>Haz clic para ver la solución (NO mirar hasta intentarlo)</b></summary>

```csharp
using System;
using System.IO;

namespace GestionLibros
{
    class Libro
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Cantidad { get; set; }

        public Libro(int codigo, string titulo, string autor, int cantidad)
        {
            Codigo = codigo;
            Titulo = titulo;
            Autor = autor;
            Cantidad = cantidad;
        }

        public string ATexto()
        {
            return $"{Codigo}|{Titulo}|{Autor}|{Cantidad}";
        }

        public static Libro DesdeTexto(string linea)
        {
            string[] datos = linea.Split('|');
            return new Libro(
                int.Parse(datos[0]),
                datos[1],
                datos[2],
                int.Parse(datos[3])
            );
        }

        public void Mostrar()
        {
            Console.WriteLine($"Código: {Codigo} | Título: {Titulo} | Autor: {Autor} | Cantidad: {Cantidad}");
        }
    }

    class Program
    {
        static Libro[] libros = new Libro[30];
        static int cantidadLibros = 0;
        static string archivo = "libros.txt";

        static void Main(string[] args)
        {
            CargarLibros();

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE BIBLIOTECA ===");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Mostrar todos los libros");
                Console.WriteLine("3. Buscar libro por código");
                Console.WriteLine("4. Guardar y salir");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarLibro();
                        break;
                    case "2":
                        MostrarLibros();
                        break;
                    case "3":
                        BuscarLibro();
                        break;
                    case "4":
                        GuardarLibros();
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

        static void AgregarLibro()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR LIBRO ===\n");

            if (cantidadLibros >= libros.Length)
            {
                Console.WriteLine("ERROR: No hay espacio para más libros");
                return;
            }

            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());

            libros[cantidadLibros] = new Libro(codigo, titulo, autor, cantidad);
            cantidadLibros++;

            Console.WriteLine("\n¡Libro agregado exitosamente!");
        }

        static void MostrarLibros()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE LIBROS ===\n");

            if (cantidadLibros == 0)
            {
                Console.WriteLine("No hay libros registrados");
                return;
            }

            for (int i = 0; i < cantidadLibros; i++)
            {
                libros[i].Mostrar();
            }

            Console.WriteLine($"\nTotal de libros: {cantidadLibros}");
        }

        static void BuscarLibro()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR LIBRO ===\n");

            Console.Write("Ingrese el código del libro: ");
            int codigo = int.Parse(Console.ReadLine());

            bool encontrado = false;
            for (int i = 0; i < cantidadLibros; i++)
            {
                if (libros[i].Codigo == codigo)
                {
                    Console.WriteLine("\nLibro encontrado:");
                    libros[i].Mostrar();
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("\nLibro no encontrado");
            }
        }

        static void GuardarLibros()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    for (int i = 0; i < cantidadLibros; i++)
                    {
                        writer.WriteLine(libros[i].ATexto());
                    }
                }
                Console.WriteLine("Libros guardados correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar: {ex.Message}");
            }
        }

        static void CargarLibros()
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
                    cantidadLibros = 0;

                    while ((linea = reader.ReadLine()) != null)
                    {
                        libros[cantidadLibros] = Libro.DesdeTexto(linea);
                        cantidadLibros++;
                    }
                }
                Console.WriteLine($"Se cargaron {cantidadLibros} libros");
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar: {ex.Message}");
            }
        }
    }
}
```

</details>

---

## PARTE 3: Errores Comunes y Buenas Prácticas

### Errores Comunes

#### 1. No validar el tamaño del arreglo antes de agregar
```csharp
// MAL
productos[cantidadProductos] = new Producto(...);
cantidadProductos++;

// BIEN
if (cantidadProductos >= productos.Length)
{
    Console.WriteLine("ERROR: No hay espacio");
    return;
}
productos[cantidadProductos] = new Producto(...);
cantidadProductos++;
```

#### 2. Olvidar incrementar el contador
```csharp
// MAL
productos[cantidadProductos] = new Producto(...);
// Falta: cantidadProductos++;

// BIEN
productos[cantidadProductos] = new Producto(...);
cantidadProductos++;
```

#### 3. Recorrer todo el arreglo en lugar de solo los elementos ocupados
```csharp
// MAL
for (int i = 0; i < productos.Length; i++)
{
    productos[i].Mostrar(); // Error si i >= cantidadProductos
}

// BIEN
for (int i = 0; i < cantidadProductos; i++)
{
    productos[i].Mostrar();
}
```

#### 4. No usar try-catch al trabajar con archivos
```csharp
// MAL
using (StreamWriter writer = new StreamWriter(archivo))
{
    // ... escribir
}

// BIEN
try
{
    using (StreamWriter writer = new StreamWriter(archivo))
    {
        // ... escribir
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

#### 5. Olvidar usar Split() correctamente
```csharp
// MAL
string[] datos = linea.Split('|'); // Error: Split recibe char[] o string[]

// BIEN
string[] datos = linea.Split('|');
// O también:
string[] datos = linea.Split(new char[] { '|' });
```

#### 6. No verificar si el archivo existe antes de cargar
```csharp
// MAL
using (StreamReader reader = new StreamReader(archivo))
{
    // Error si el archivo no existe
}

// BIEN
if (!File.Exists(archivo))
{
    return; // O mostrar mensaje
}
using (StreamReader reader = new StreamReader(archivo))
{
    // ... leer
}
```

---

### Buenas Prácticas

#### 1. Usar nombres descriptivos
```csharp
// MAL
int c = 0;
Producto[] p = new Producto[100];

// BIEN
int cantidadProductos = 0;
Producto[] productos = new Producto[100];
```

#### 2. Separar responsabilidades en métodos
```csharp
// BIEN
static void Main()
{
    CargarProductos();
    MostrarMenu();
    GuardarProductos();
}
```

#### 3. Validar entradas del usuario
```csharp
// BIEN
Console.Write("Precio: ");
string entrada = Console.ReadLine();
if (!decimal.TryParse(entrada, out decimal precio))
{
    Console.WriteLine("Precio inválido");
    return;
}
```

#### 4. Usar propiedades en lugar de campos públicos
```csharp
// MAL
public int codigo;

// BIEN
public int Codigo { get; set; }
```

#### 5. Comentar el código complejo
```csharp
// Buscar producto por código en el arreglo
for (int i = 0; i < cantidadProductos; i++)
{
    if (productos[i].Codigo == codigo)
    {
        return productos[i];
    }
}
```

#### 6. Cerrar recursos con using
```csharp
// BIEN
using (StreamWriter writer = new StreamWriter(archivo))
{
    // El archivo se cierra automáticamente
}
```

---

## Checklist para el Examen

Antes de entregar tu examen, verifica:

- [ ] ¿Creé correctamente la clase con propiedades y constructor?
- [ ] ¿Implementé los métodos `ATexto()` y `DesdeTexto()`?
- [ ] ¿Declaré el arreglo con el tamaño adecuado?
- [ ] ¿Tengo una variable contador para los elementos ocupados?
- [ ] ¿Valido el tamaño del arreglo antes de agregar?
- [ ] ¿Incremento el contador después de agregar?
- [ ] ¿Uso `cantidadElementos` y no `arreglo.Length` en los for?
- [ ] ¿Implementé correctamente `GuardarArchivo()` con StreamWriter?
- [ ] ¿Implementé correctamente `CargarArchivo()` con StreamReader?
- [ ] ¿Uso try-catch al trabajar con archivos?
- [ ] ¿Verifico si el archivo existe antes de leerlo?
- [ ] ¿Probé el programa con al menos 3 registros?

---

## Consejos Finales

1. **Lee bien el enunciado** - Asegúrate de entender qué te piden
2. **Empieza por la clase** - Siempre crea primero la clase con sus propiedades
3. **Prueba frecuentemente** - No escribas todo el código sin probar
4. **Maneja errores básicos** - Usa try-catch en archivos
5. **Revisa antes de entregar** - Verifica que compile y funcione

---

