# 📦 Módulo 04: Namespaces, Clases y Funciones

## 🎯 Objetivos de Aprendizaje

Al finalizar este módulo, podrás:
- Comprender qué son los namespaces y cómo organizan el código
- Entender la estructura básica de las clases en C#
- Crear y usar métodos (funciones) estáticos
- Organizar tu código de manera modular y reutilizable
- Aplicar conceptos de alcance y visibilidad

---

## 📚 1. Namespaces (Espacios de Nombres)

### ¿Qué es un Namespace?

Un **namespace** es un contenedor que organiza y agrupa clases, interfaces y otros tipos relacionados. Es como una carpeta que ayuda a evitar conflictos de nombres y mantiene el código organizado.

### Sintaxis Básica

```csharp
namespace MiProyecto
{
    // Aquí van las clases y otros tipos
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola desde MiProyecto!");
        }
    }
}
```

### Using Directives

Las directivas `using` nos permiten usar tipos de otros namespaces sin escribir el nombre completo:

```csharp
using System;           // Para Console, DateTime, etc.
using System.IO;        // Para File, Directory, etc.
using System.Collections.Generic;  // Para List<T>, Dictionary<T,K>, etc.

namespace MiAplicacion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ahora podemos usar Console directamente
            Console.WriteLine("Sin necesidad de System.Console");
            
            // También DateTime
            DateTime ahora = DateTime.Now;
            Console.WriteLine($"Fecha actual: {ahora}");
        }
    }
}
```

### Namespaces Anidados

```csharp
namespace MiEmpresa
{
    namespace Ventas
    {
        class Cliente
        {
            public string Nombre { get; set; }
        }
    }
    
    namespace Inventario
    {
        class Producto
        {
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
        }
    }
}
```

---

## 🏗️ 2. Clases Básicas

### Estructura de una Clase

Una **clase** es un molde o plantilla que define las características (propiedades) y comportamientos (métodos) de un objeto.

```csharp
namespace MiProyecto
{
    // Definición de una clase simple
    class Calculadora
    {
        // Propiedades (características)
        public string Modelo { get; set; }
        public string Marca { get; set; }
        
        // Métodos (comportamientos)
        public double Sumar(double a, double b)
        {
            return a + b;
        }
        
        public double Restar(double a, double b)
        {
            return a - b;
        }
        
        public void MostrarInfo()
        {
            Console.WriteLine($"Calculadora: {Marca} {Modelo}");
        }
    }
}
```

### Modificadores de Acceso

| Modificador | Descripción | Accesible desde |
|-------------|-------------|-----------------|
| `public` | Acceso público | Cualquier lugar |
| `private` | Acceso privado | Solo dentro de la misma clase |
| `protected` | Acceso protegido | Clase actual y clases derivadas |
| `internal` | Acceso interno | Mismo ensamblado/proyecto |

```csharp
class Ejemplo
{
    public int NumeroPublico;        // Accesible desde cualquier lugar
    private int numeroPrivado;       // Solo dentro de esta clase
    protected string textoProtegido; // Esta clase y clases hijas
    internal bool flagInterno;       // Mismo proyecto
}
```

---

## ⚙️ 3. Métodos (Funciones)

### Métodos Estáticos

Los métodos estáticos pertenecen a la clase, no a una instancia específica. Se pueden llamar directamente usando el nombre de la clase.

```csharp
class Utilidades
{
    // Método estático para calcular el área de un círculo
    public static double CalcularAreaCirculo(double radio)
    {
        return Math.PI * radio * radio;
    }
    
    // Método estático para validar si un número es par
    public static bool EsPar(int numero)
    {
        return numero % 2 == 0;
    }
    
    // Método estático para convertir temperatura
    public static double CelsiusAFahrenheit(double celsius)
    {
        return (celsius * 9.0 / 5.0) + 32.0;
    }
}

// Uso de métodos estáticos
class Program
{
    static void Main(string[] args)
    {
        // Llamada directa sin crear instancia
        double area = Utilidades.CalcularAreaCirculo(5.0);
        Console.WriteLine($"Área del círculo: {area:F2}");
        
        bool esParTres = Utilidades.EsPar(3);
        Console.WriteLine($"¿3 es par? {esParTres}");
        
        double fahrenheit = Utilidades.CelsiusAFahrenheit(25);
        Console.WriteLine($"25°C = {fahrenheit:F1}°F");
    }
}
```

### Estructura de un Método

```csharp
[modificador] [static] tipo_retorno NombreMetodo(parametros)
{
    // Cuerpo del método
    return valor; // Si el tipo de retorno no es void
}
```

### Tipos de Métodos

#### 1. Métodos que No Retornan Valor (void)

```csharp
public static void MostrarMensaje(string mensaje)
{
    Console.WriteLine($"Mensaje: {mensaje}");
    // No hay return porque es void
}

public static void DibujarLinea(int longitud)
{
    for (int i = 0; i < longitud; i++)
    {
        Console.Write("-");
    }
    Console.WriteLine(); // Nueva línea al final
}
```

#### 2. Métodos que Retornan Valor

```csharp
public static int Multiplicar(int a, int b)
{
    return a * b;
}

public static string ObtenerSaludo(string nombre)
{
    return $"¡Hola, {nombre}!";
}

public static bool EsMayorDeEdad(int edad)
{
    return edad >= 18;
}
```

#### 3. Métodos con Múltiples Parámetros

```csharp
public static double CalcularPromedio(double nota1, double nota2, double nota3)
{
    return (nota1 + nota2 + nota3) / 3.0;
}

public static void MostrarInformacionPersona(string nombre, int edad, double altura)
{
    Console.WriteLine($"Nombre: {nombre}");
    Console.WriteLine($"Edad: {edad} años");
    Console.WriteLine($"Altura: {altura:F2} metros");
}
```

---

## 🔧 4. Organización del Código

### Ejemplo Completo: Sistema de Gestión de Estudiantes

```csharp
using System;

namespace SistemaEducativo
{
    // Clase para representar un estudiante
    class Estudiante
    {
        // Propiedades
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double NotaPromedio { get; set; }
        
        // Método para mostrar información
        public void MostrarInformacion()
        {
            Console.WriteLine($"Estudiante: {Nombre}");
            Console.WriteLine($"Edad: {Edad} años");
            Console.WriteLine($"Promedio: {NotaPromedio:F2}");
        }
    }
    
    // Clase con métodos utilitarios
    class UtilidadesEstudiante
    {
        public static string DeterminarNivel(double promedio)
        {
            if (promedio >= 9.0)
                return "Excelente";
            else if (promedio >= 7.0)
                return "Bueno";
            else if (promedio >= 5.0)
                return "Regular";
            else
                return "Insuficiente";
        }
        
        public static bool EstaAprobado(double promedio)
        {
            return promedio >= 6.0;
        }
        
        public static void MostrarEstadisticas(double[] notas)
        {
            double suma = 0;
            double mayor = notas[0];
            double menor = notas[0];
            
            foreach (double nota in notas)
            {
                suma += nota;
                if (nota > mayor) mayor = nota;
                if (nota < menor) menor = nota;
            }
            
            double promedio = suma / notas.Length;
            
            Console.WriteLine("=== ESTADÍSTICAS ===");
            Console.WriteLine($"Promedio: {promedio:F2}");
            Console.WriteLine($"Nota más alta: {mayor:F2}");
            Console.WriteLine($"Nota más baja: {menor:F2}");
            Console.WriteLine($"Nivel: {DeterminarNivel(promedio)}");
            Console.WriteLine($"Estado: {(EstaAprobado(promedio) ? "APROBADO" : "REPROBADO")}");
        }
    }
    
    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {
            // Crear un estudiante
            Estudiante estudiante1 = new Estudiante();
            estudiante1.Nombre = "Ana García";
            estudiante1.Edad = 20;
            estudiante1.NotaPromedio = 8.5;
            
            // Mostrar información
            estudiante1.MostrarInformacion();
            
            // Usar métodos utilitarios
            string nivel = UtilidadesEstudiante.DeterminarNivel(estudiante1.NotaPromedio);
            bool aprobado = UtilidadesEstudiante.EstaAprobado(estudiante1.NotaPromedio);
            
            Console.WriteLine($"Nivel académico: {nivel}");
            Console.WriteLine($"¿Está aprobado? {(aprobado ? "Sí" : "No")}");
            
            // Ejemplo con array de notas
            double[] notas = {7.5, 8.0, 9.2, 6.8, 8.7};
            UtilidadesEstudiante.MostrarEstadisticas(notas);
        }
    }
}
```

---

## 📊 5. Alcance y Visibilidad

### Variables Locales vs Variables de Clase

```csharp
class EjemploAlcance
{
    // Variable de clase (campo)
    private static int contadorGlobal = 0;
    
    public static void MetodoEjemplo()
    {
        // Variable local
        int contadorLocal = 0;
        
        contadorGlobal++;    // Accesible en toda la clase
        contadorLocal++;     // Solo accesible en este método
        
        Console.WriteLine($"Global: {contadorGlobal}, Local: {contadorLocal}");
    }
    
    public static void OtroMetodo()
    {
        contadorGlobal++;    // ✅ Accesible
        // contadorLocal++;  // ❌ Error: no está en alcance
        
        Console.WriteLine($"Global desde otro método: {contadorGlobal}");
    }
}
```

---

## 🎯 6. Buenas Prácticas

### 1. Nomenclatura
- **Clases**: PascalCase (`MiClase`, `CalculadoraAvanzada`)
- **Métodos**: PascalCase (`CalcularPromedio`, `MostrarResultado`)
- **Variables locales**: camelCase (`miVariable`, `numeroEstudiantes`)
- **Propiedades**: PascalCase (`Nombre`, `FechaNacimiento`)

### 2. Organización
```csharp
// ✅ Buena organización
namespace MiProyecto.Matematicas
{
    class Calculadora
    {
        // Primero las propiedades
        public string Modelo { get; set; }
        
        // Luego los métodos públicos
        public double Sumar(double a, double b)
        {
            return a + b;
        }
        
        // Finalmente los métodos privados
        private void ValidarEntrada(double numero)
        {
            // Validación interna
        }
    }
}
```

### 3. Comentarios y Documentación
```csharp
/// <summary>
/// Calcula el área de un rectángulo
/// </summary>
/// <param name="ancho">Ancho del rectángulo en metros</param>
/// <param name="alto">Alto del rectángulo en metros</param>
/// <returns>Área en metros cuadrados</returns>
public static double CalcularAreaRectangulo(double ancho, double alto)
{
    // Validar que los valores sean positivos
    if (ancho <= 0 || alto <= 0)
    {
        throw new ArgumentException("Las dimensiones deben ser positivas");
    }
    
    return ancho * alto;
}
```

---

## 🧪 7. Ejercicios Prácticos

### Ejercicio 1: Mi Primera Clase
Crea una clase `Persona` con propiedades para nombre, edad y ciudad. Incluye un método para mostrar la información.

### Ejercicio 2: Calculadora de Utilidades
Crea una clase `UtilidadesMatematicas` con métodos estáticos para:
- Calcular el factorial de un número
- Determinar si un número es primo
- Calcular la potencia de un número

### Ejercicio 3: Sistema de Biblioteca
Diseña un sistema simple con:
- Clase `Libro` con propiedades (título, autor, año)
- Clase `BibliotecaUtils` con métodos para buscar y clasificar libros

---

## 🔍 Conceptos Clave para Recordar

1. **Namespace**: Organiza y agrupa el código relacionado
2. **Clase**: Plantilla que define propiedades y métodos
3. **Método estático**: Se llama directamente desde la clase, sin crear instancia
4. **Modificadores de acceso**: Controlan quién puede acceder a qué
5. **Alcance**: Determina dónde son accesibles las variables
6. **Reutilización**: Los métodos permiten escribir código una vez y usarlo muchas veces

¡Siguiente paso: Aplicar estos conceptos en ejercicios prácticos! 🚀
