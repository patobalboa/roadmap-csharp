# 📖 Teoría 02: Trabajando con Objetos en C#

## 🎯 Objetivos de Aprendizaje
Al finalizar esta lección, podrás:
- Crear e instanciar objetos de una clase
- Entender cómo funcionan las referencias en C#
- Diferenciar entre métodos de instancia y métodos estáticos
- Gestionar el ciclo de vida de los objetos
- Usar correctamente el operador `new`

## 🏭 ¿Qué es un Objeto?

### Analogía del Mundo Real
Si una **clase** es el plano de una casa, entonces un **objeto** es la casa construida usando ese plano. Puedes construir muchas casas (objetos) usando el mismo plano (clase), pero cada casa será independiente y única.

### De Python a C#
```python
# Python - Crear objetos
class Persona:
    def __init__(self, nombre, edad):
        self.nombre = nombre
        self.edad = edad

# Crear objetos
persona1 = Persona("Ana", 25)
persona2 = Persona("Luis", 30)
```

```csharp
// C# - Crear objetos
public class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    
    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }
}

// Crear objetos
Persona persona1 = new Persona("Ana", 25);
Persona persona2 = new Persona("Luis", 30);
```

## 🔧 Instanciación de Objetos

### Sintaxis Básica
```csharp
// Sintaxis completa
ClaseNombre variable = new ClaseNombre();

// Con parámetros
ClaseNombre variable = new ClaseNombre(parametros);

// Sintaxis abreviada (C# 9+)
ClaseNombre variable = new(parametros);

// Declaración e inicialización separadas
ClaseNombre variable;
variable = new ClaseNombre();
```

### Ejemplo Práctico
```csharp
public class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Paginas { get; set; }
    public DateTime FechaPublicacion { get; set; }
    
    // Constructores
    public Libro()
    {
        Titulo = "Sin título";
        Autor = "Desconocido";
        Paginas = 0;
        FechaPublicacion = DateTime.Now;
    }
    
    public Libro(string titulo, string autor)
    {
        Titulo = titulo;
        Autor = autor;
        Paginas = 0;
        FechaPublicacion = DateTime.Now;
    }
    
    public Libro(string titulo, string autor, int paginas, DateTime fechaPublicacion)
    {
        Titulo = titulo;
        Autor = autor;
        Paginas = paginas;
        FechaPublicacion = fechaPublicacion;
    }
}

// Diferentes formas de crear objetos
class Program
{
    static void Main()
    {
        // Constructor por defecto
        Libro libro1 = new Libro();
        
        // Constructor con parámetros
        Libro libro2 = new Libro("1984", "George Orwell");
        
        // Constructor completo
        Libro libro3 = new Libro("El Quijote", "Cervantes", 1000, new DateTime(1605, 1, 1));
        
        // Sintaxis abreviada (C# 9+)
        Libro libro4 = new("Cien años de soledad", "García Márquez");
        
        // Inicialización de propiedades después de la creación
        libro1.Titulo = "Aprendiendo C#";
        libro1.Autor = "Programador Novato";
        libro1.Paginas = 300;
    }
}
```

## 🔗 Referencias y Memoria

### Concepto de Referencias
En C#, cuando creas un objeto, la variable no contiene el objeto directamente, sino una **referencia** (dirección) hacia donde está almacenado el objeto en memoria.

```csharp
// Ejemplo de referencias
Libro libro1 = new Libro("1984", "Orwell");
Libro libro2 = libro1;  // libro2 apunta al mismo objeto que libro1

// Modificar a través de cualquier referencia afecta al mismo objeto
libro2.Titulo = "Rebelión en la granja";
Console.WriteLine(libro1.Titulo);  // Imprime: "Rebelión en la granja"

// Crear un nuevo objeto
libro2 = new Libro("Fahrenheit 451", "Bradbury");
Console.WriteLine(libro1.Titulo);  // Imprime: "Rebelión en la granja"
Console.WriteLine(libro2.Titulo);  // Imprime: "Fahrenheit 451"
```

### Comparación de Referencias vs Valores
```csharp
public class CuentaBancaria
{
    public string NumeroCuenta { get; set; }
    public decimal Saldo { get; set; }
    
    public CuentaBancaria(string numero, decimal saldo)
    {
        NumeroCuenta = numero;
        Saldo = saldo;
    }
}

class Program
{
    static void Main()
    {
        // Crear dos objetos con los mismos valores
        CuentaBancaria cuenta1 = new CuentaBancaria("123-456", 1000m);
        CuentaBancaria cuenta2 = new CuentaBancaria("123-456", 1000m);
        
        // Comparación de referencias (false - son objetos diferentes)
        Console.WriteLine(cuenta1 == cuenta2);  // False
        
        // Comparación de referencias (true - misma referencia)
        CuentaBancaria cuenta3 = cuenta1;
        Console.WriteLine(cuenta1 == cuenta3);  // True
        
        // Para comparar contenido, necesitas sobrescribir Equals
        Console.WriteLine(cuenta1.NumeroCuenta == cuenta2.NumeroCuenta);  // True
    }
}
```

## 🔄 Métodos de Instancia vs Métodos Estáticos

### Métodos de Instancia
Los métodos de instancia pertenecen a un objeto específico y pueden acceder a sus datos:

```csharp
public class Calculadora
{
    public double UltimoResultado { get; private set; }
    
    // Método de instancia - necesita un objeto para ejecutarse
    public double Sumar(double a, double b)
    {
        UltimoResultado = a + b;
        return UltimoResultado;
    }
    
    public double Multiplicar(double a, double b)
    {
        UltimoResultado = a * b;
        return UltimoResultado;
    }
    
    public void MostrarHistorial()
    {
        Console.WriteLine($"Último resultado: {UltimoResultado}");
    }
}

// Uso de métodos de instancia
Calculadora calc = new Calculadora();
double resultado = calc.Sumar(5, 3);  // Necesita el objeto 'calc'
calc.MostrarHistorial();
```

### Métodos Estáticos
Los métodos estáticos pertenecen a la clase, no a un objeto específico:

```csharp
public class UtilMath
{
    // Método estático - no necesita objeto para ejecutarse
    public static double CalcularAreaCirculo(double radio)
    {
        return Math.PI * radio * radio;
    }
    
    public static bool EsPar(int numero)
    {
        return numero % 2 == 0;
    }
    
    public static double ConvertirCelsiusAFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }
}

// Uso de métodos estáticos - no necesita crear objeto
double area = UtilMath.CalcularAreaCirculo(5);
bool esPar = UtilMath.EsPar(10);
double fahrenheit = UtilMath.ConvertirCelsiusAFahrenheit(25);
```

### Combinando Métodos de Instancia y Estáticos
```csharp
public class Empleado
{
    private static int _contadorEmpleados = 0;  // Campo estático
    
    public string Nombre { get; set; }
    public decimal Salario { get; set; }
    public int ID { get; private set; }
    
    // Constructor
    public Empleado(string nombre, decimal salario)
    {
        _contadorEmpleados++;  // Incrementa contador global
        ID = _contadorEmpleados;
        Nombre = nombre;
        Salario = salario;
    }
    
    // Método de instancia
    public decimal CalcularSalarioAnual()
    {
        return Salario * 12;
    }
    
    // Método estático
    public static int ObtenerCantidadEmpleados()
    {
        return _contadorEmpleados;
    }
    
    // Método estático para validaciones
    public static bool EsSalarioValido(decimal salario)
    {
        return salario > 0 && salario <= 100000;
    }
}

// Uso combinado
class Program
{
    static void Main()
    {
        Console.WriteLine($"Empleados creados: {Empleado.ObtenerCantidadEmpleados()}");
        
        // Validar antes de crear
        if (Empleado.EsSalarioValido(3000))
        {
            Empleado emp1 = new Empleado("Ana", 3000);
            Console.WriteLine($"Salario anual de {emp1.Nombre}: ${emp1.CalcularSalarioAnual()}");
        }
        
        Empleado emp2 = new Empleado("Luis", 4000);
        
        Console.WriteLine($"Total empleados: {Empleado.ObtenerCantidadEmpleados()}");
    }
}
```

## ♻️ Ciclo de Vida de los Objetos

### Fases del Ciclo de Vida

1. **Creación**: Se ejecuta el constructor
2. **Uso**: El objeto está en memoria y se puede usar
3. **Recolección de basura**: El objeto es eliminado automáticamente

```csharp
public class RecursoConLog
{
    public string Nombre { get; set; }
    
    // Constructor - Fase de creación
    public RecursoConLog(string nombre)
    {
        Nombre = nombre;
        Console.WriteLine($"✅ Objeto '{Nombre}' creado");
    }
    
    // Método para mostrar uso
    public void Usar()
    {
        Console.WriteLine($"🔧 Usando '{Nombre}'");
    }
    
    // Finalizer - se ejecuta antes de la recolección de basura
    ~RecursoConLog()
    {
        Console.WriteLine($"🗑️ Objeto '{Nombre}' siendo destruido");
    }
}

class Program
{
    static void Main()
    {
        // Fase 1: Creación
        RecursoConLog recurso1 = new RecursoConLog("Recurso Principal");
        
        // Fase 2: Uso
        recurso1.Usar();
        
        // Crear objeto temporal
        {
            RecursoConLog recursoTemporal = new RecursoConLog("Recurso Temporal");
            recursoTemporal.Usar();
        } // recursoTemporal sale de scope aquí
        
        // Fase 3: Limpieza manual (opcional)
        recurso1 = null;  // Elimina la referencia
        
        // Forzar recolección de basura (solo para demostración)
        GC.Collect();
        GC.WaitForPendingFinalizers();
        
        Console.WriteLine("Programa terminado");
    }
}
```

### Patrón IDisposable para Recursos
```csharp
public class ArchivoManager : IDisposable
{
    private FileStream _archivo;
    private bool _disposed = false;
    
    public ArchivoManager(string rutaArchivo)
    {
        _archivo = new FileStream(rutaArchivo, FileMode.OpenOrCreate);
        Console.WriteLine($"📁 Archivo abierto: {rutaArchivo}");
    }
    
    public void EscribirTexto(string texto)
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(ArchivoManager));
            
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(texto);
        _archivo.Write(bytes, 0, bytes.Length);
    }
    
    // Implementación de IDisposable
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _archivo?.Close();
                _archivo?.Dispose();
                Console.WriteLine("📁 Archivo cerrado correctamente");
            }
            _disposed = true;
        }
    }
    
    ~ArchivoManager()
    {
        Dispose(false);
    }
}

// Uso con using statement (recomendado)
class Program
{
    static void Main()
    {
        // El using garantiza que Dispose() se ejecute automáticamente
        using (ArchivoManager archivo = new ArchivoManager("test.txt"))
        {
            archivo.EscribirTexto("Hola mundo desde C#");
        } // Dispose() se ejecuta automáticamente aquí
        
        Console.WriteLine("Archivo procesado y cerrado");
    }
}
```

## 🎯 Ejemplo Práctico Completo: Sistema de Biblioteca

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

// Clase para representar un libro
public class Libro
{
    public string ISBN { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public DateTime FechaPublicacion { get; set; }
    public bool EstaPrestado { get; private set; }
    
    public Libro(string isbn, string titulo, string autor, DateTime fechaPublicacion)
    {
        ISBN = isbn;
        Titulo = titulo;
        Autor = autor;
        FechaPublicacion = fechaPublicacion;
        EstaPrestado = false;
    }
    
    public bool Prestar()
    {
        if (!EstaPrestado)
        {
            EstaPrestado = true;
            return true;
        }
        return false;
    }
    
    public void Devolver()
    {
        EstaPrestado = false;
    }
    
    public override string ToString()
    {
        string estado = EstaPrestado ? "PRESTADO" : "DISPONIBLE";
        return $"{Titulo} por {Autor} [{estado}]";
    }
}

// Clase para gestionar la biblioteca
public class Biblioteca
{
    private List<Libro> _libros;
    private static int _totalPrestamos = 0;
    
    public string Nombre { get; set; }
    public int CantidadLibros => _libros.Count;
    
    public Biblioteca(string nombre)
    {
        Nombre = nombre;
        _libros = new List<Libro>();
    }
    
    public void AgregarLibro(Libro libro)
    {
        _libros.Add(libro);
        Console.WriteLine($"📚 Libro agregado: {libro.Titulo}");
    }
    
    public bool PrestarLibro(string isbn)
    {
        Libro libro = _libros.FirstOrDefault(l => l.ISBN == isbn);
        if (libro != null && libro.Prestar())
        {
            _totalPrestamos++;
            Console.WriteLine($"✅ Libro prestado: {libro.Titulo}");
            return true;
        }
        
        Console.WriteLine($"❌ No se pudo prestar el libro con ISBN: {isbn}");
        return false;
    }
    
    public bool DevolverLibro(string isbn)
    {
        Libro libro = _libros.FirstOrDefault(l => l.ISBN == isbn);
        if (libro != null && libro.EstaPrestado)
        {
            libro.Devolver();
            Console.WriteLine($"📤 Libro devuelto: {libro.Titulo}");
            return true;
        }
        
        Console.WriteLine($"❌ No se pudo devolver el libro con ISBN: {isbn}");
        return false;
    }
    
    public List<Libro> BuscarPorAutor(string autor)
    {
        return _libros.Where(l => l.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    
    public void MostrarInventario()
    {
        Console.WriteLine($"\n📖 Inventario de {Nombre}:");
        Console.WriteLine(new string('-', 50));
        
        foreach (var libro in _libros)
        {
            Console.WriteLine(libro.ToString());
        }
        
        Console.WriteLine($"\nTotal libros: {CantidadLibros}");
        Console.WriteLine($"Libros disponibles: {_libros.Count(l => !l.EstaPrestado)}");
        Console.WriteLine($"Libros prestados: {_libros.Count(l => l.EstaPrestado)}");
    }
    
    public static int ObtenerTotalPrestamos()
    {
        return _totalPrestamos;
    }
}

// Programa principal
class Program
{
    static void Main()
    {
        // Crear biblioteca
        Biblioteca biblioteca = new Biblioteca("Biblioteca Central");
        
        // Crear libros
        Libro libro1 = new Libro("978-84-376-0494-7", "1984", "George Orwell", new DateTime(1949, 6, 8));
        Libro libro2 = new Libro("978-84-376-0495-4", "Rebelión en la granja", "George Orwell", new DateTime(1945, 8, 17));
        Libro libro3 = new Libro("978-84-376-0496-1", "Fahrenheit 451", "Ray Bradbury", new DateTime(1953, 10, 19));
        
        // Agregar libros a la biblioteca
        biblioteca.AgregarLibro(libro1);
        biblioteca.AgregarLibro(libro2);
        biblioteca.AgregarLibro(libro3);
        
        // Mostrar inventario inicial
        biblioteca.MostrarInventario();
        
        // Realizar préstamos
        Console.WriteLine("\n=== PRÉSTAMOS ===");
        biblioteca.PrestarLibro("978-84-376-0494-7");  // 1984
        biblioteca.PrestarLibro("978-84-376-0496-1");  // Fahrenheit 451
        biblioteca.PrestarLibro("978-84-376-0494-7");  // Intentar prestar 1984 de nuevo
        
        // Mostrar inventario después de préstamos
        biblioteca.MostrarInventario();
        
        // Buscar libros por autor
        Console.WriteLine("\n=== BÚSQUEDA POR AUTOR ===");
        var librosOrwell = biblioteca.BuscarPorAutor("Orwell");
        Console.WriteLine($"Libros de Orwell encontrados: {librosOrwell.Count}");
        foreach (var libro in librosOrwell)
        {
            Console.WriteLine($"- {libro}");
        }
        
        // Devolver libros
        Console.WriteLine("\n=== DEVOLUCIONES ===");
        biblioteca.DevolverLibro("978-84-376-0494-7");  // Devolver 1984
        
        // Mostrar estadísticas finales
        Console.WriteLine($"\n=== ESTADÍSTICAS FINALES ===");
        biblioteca.MostrarInventario();
        Console.WriteLine($"Total de préstamos realizados: {Biblioteca.ObtenerTotalPrestamos()}");
    }
}
```

## ✅ Buenas Prácticas con Objetos

1. **Inicialización Completa en Constructores**:
```csharp
public class Persona
{
    public Persona(string nombre, int edad)
    {
        // Inicializar todas las propiedades necesarias
        Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        Edad = edad >= 0 ? edad : throw new ArgumentException("Edad no puede ser negativa");
        FechaCreacion = DateTime.Now;
    }
}
```

2. **Validación de Estados**:
```csharp
public class CuentaBancaria
{
    public bool Retirar(decimal cantidad)
    {
        if (cantidad <= 0)
        {
            Console.WriteLine("La cantidad debe ser positiva");
            return false;
        }
        
        if (cantidad > Saldo)
        {
            Console.WriteLine("Fondos insuficientes");
            return false;
        }
        
        Saldo -= cantidad;
        return true;
    }
}
```

3. **Uso Apropiado de Métodos Estáticos**:
```csharp
// ✅ Bueno - funciones utilitarias
public static class MathUtils
{
    public static double CalcularDistancia(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
}

// ❌ Malo - debería ser método de instancia
public static class PersonaUtils
{
    public static void CambiarNombre(Persona persona, string nuevoNombre)
    {
        persona.Nombre = nuevoNombre;  // Debería ser persona.CambiarNombre()
    }
}
```

## 🔚 Resumen

- Un **objeto** es una instancia de una clase
- Se crean usando el operador `new` y el constructor
- Las variables de objeto contienen **referencias**, no el objeto directamente
- Los **métodos de instancia** pertenecen a objetos específicos
- Los **métodos estáticos** pertenecen a la clase, no a objetos
- El ciclo de vida incluye creación, uso y recolección de basura
- Usa `IDisposable` para recursos que necesitan limpieza manual
- Siempre valida el estado de los objetos antes de operaciones

## ➡️ Siguiente: [Teoría 03: Encapsulación y Modificadores de Acceso](Teoria-03-Encapsulacion.md)