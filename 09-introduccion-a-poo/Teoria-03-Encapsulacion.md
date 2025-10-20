# 📖 Teoría 03: Encapsulación y Modificadores de Acceso

## 🎯 Objetivos de Aprendizaje
Al finalizar esta lección, podrás:
- Entender el concepto de encapsulación y su importancia
- Usar correctamente los modificadores de acceso en C#
- Implementar propiedades automáticas y manuales
- Crear métodos getter y setter con validaciones
- Proteger la integridad de los datos en tus clases

## 🔐 ¿Qué es la Encapsulación?

### Analogía del Mundo Real
Imagina un **cajero automático**:
- **Lo que puedes ver**: pantalla, teclado, ranura para tarjeta
- **Lo que NO puedes ver**: el software interno, la conexión al banco, los mecanismos de seguridad

La encapsulación es similar: expones solo lo que el usuario necesita y ocultas los detalles internos complejos.

### Principios de la Encapsulación
1. **Ocultar datos**: Los campos internos deben ser privados
2. **Controlar acceso**: Usar propiedades para acceder a los datos
3. **Validar cambios**: Implementar lógica de validación
4. **Mantener consistencia**: Asegurar que el objeto siempre esté en un estado válido

### De Python a C#
```python
# Python - Encapsulación básica
class CuentaBancaria:
    def __init__(self, numero, saldo_inicial):
        self._numero = numero  # Convencion: _ = privado
        self._saldo = saldo_inicial
    
    @property
    def saldo(self):
        return self._saldo
    
    def depositar(self, cantidad):
        if cantidad > 0:
            self._saldo += cantidad
```

```csharp
// C# - Encapsulación estricta
public class CuentaBancaria
{
    private string _numero;        // Campo privado
    private decimal _saldo;        // Campo privado
    
    // Propiedad pública con validación
    public decimal Saldo 
    { 
        get { return _saldo; } 
        private set { _saldo = value; }  // Setter privado
    }
    
    public string Numero 
    { 
        get { return _numero; } 
        private set { _numero = value; } 
    }
    
    public void Depositar(decimal cantidad)
    {
        if (cantidad > 0)
            _saldo += cantidad;
    }
}
```

## 🚪 Modificadores de Acceso en C#

### Tabla de Modificadores
| Modificador | Acceso desde | Descripción |
|-------------|--------------|-------------|
| `public` | Cualquier lugar | Sin restricciones |
| `private` | Solo la misma clase | Máxima restricción |
| `protected` | Clase y clases derivadas | Para herencia |
| `internal` | Mismo ensamblado (proyecto) | Nivel de proyecto |
| `protected internal` | Clase derivada O mismo ensamblado | Combinación |
| `private protected` | Clase derivada Y mismo ensamblado | Más restrictivo |

### Ejemplos Prácticos

```csharp
public class Empleado
{
    // Campos privados - solo accesibles dentro de esta clase
    private string _nombre;
    private decimal _salario;
    private DateTime _fechaContratacion;
    
    // Propiedades públicas - accesibles desde cualquier lugar
    public string Nombre 
    { 
        get { return _nombre; }
        set { _nombre = value?.Trim() ?? throw new ArgumentNullException(); }
    }
    
    public int ID { get; private set; }  // Solo lectura desde el exterior
    
    // Propiedad protegida - accesible en clases derivadas
    protected decimal SalarioBase
    {
        get { return _salario; }
        set { _salario = value > 0 ? value : throw new ArgumentException("Salario debe ser positivo"); }
    }
    
    // Método interno - solo accesible dentro del mismo proyecto
    internal void ActualizarSistemaInterno()
    {
        // Lógica interna del sistema
    }
    
    // Método privado - solo para uso interno de la clase
    private bool ValidarEmpleado()
    {
        return !string.IsNullOrWhiteSpace(_nombre) && _salario > 0;
    }
    
    // Constructor público
    public Empleado(int id, string nombre, decimal salario)
    {
        ID = id;
        Nombre = nombre;
        SalarioBase = salario;
        _fechaContratacion = DateTime.Now;
    }
    
    // Método público con validación interna
    public bool AumentarSalario(decimal porcentaje)
    {
        if (porcentaje <= 0 || porcentaje > 100)
            return false;
            
        _salario *= (1 + porcentaje / 100);
        return true;
    }
}
```

## 🏠 Propiedades: La Clave de la Encapsulación

### Propiedades Automáticas (Simplificadas)
```csharp
public class Producto
{
    // Propiedades automáticas - C# genera los campos privados automáticamente
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    
    // Propiedad de solo lectura
    public DateTime FechaCreacion { get; private set; }
    
    // Propiedad de solo escritura (raro)
    public string Password { private get; set; }
    
    public Producto()
    {
        FechaCreacion = DateTime.Now;
    }
}
```

### Propiedades Manuales (Con Validación)
```csharp
public class Persona
{
    // Campos privados de respaldo
    private string _nombre;
    private int _edad;
    private string _email;
    
    // Propiedad con validación completa
    public string Nombre
    {
        get 
        { 
            return _nombre; 
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre no puede estar vacío");
                
            if (value.Length < 2)
                throw new ArgumentException("El nombre debe tener al menos 2 caracteres");
                
            _nombre = value.Trim().ToTitleCase();
        }
    }
    
    // Propiedad con validación de rango
    public int Edad
    {
        get { return _edad; }
        set
        {
            if (value < 0 || value > 150)
                throw new ArgumentOutOfRangeException(nameof(value), "La edad debe estar entre 0 y 150 años");
                
            _edad = value;
        }
    }
    
    // Propiedad con validación de formato
    public string Email
    {
        get { return _email; }
        set
        {
            if (!string.IsNullOrEmpty(value) && !IsValidEmail(value))
                throw new ArgumentException("Formato de email inválido");
                
            _email = value?.ToLower();
        }
    }
    
    // Propiedad calculada (solo lectura)
    public string Categoria
    {
        get
        {
            if (_edad < 18) return "Menor";
            if (_edad < 65) return "Adulto";
            return "Adulto Mayor";
        }
    }
    
    // Método privado para validación
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}

// Extensión para ToTitleCase
public static class StringExtensions
{
    public static string ToTitleCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
            
        return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
    }
}
```

### Propiedades con Lógica Compleja
```csharp
public class CuentaAhorros
{
    private decimal _saldo;
    private List<decimal> _transacciones;
    private const decimal SALDO_MINIMO = 100m;
    
    public decimal Saldo 
    { 
        get { return _saldo; }
        private set { _saldo = value; }  // Solo la clase puede modificar directamente
    }
    
    // Propiedad calculada
    public decimal PromedioTransacciones
    {
        get
        {
            if (_transacciones.Count == 0)
                return 0;
            return _transacciones.Average();
        }
    }
    
    // Propiedad que determina estado
    public bool EsCuentaActiva
    {
        get { return _saldo >= SALDO_MINIMO; }
    }
    
    public int NumeroTransacciones
    {
        get { return _transacciones.Count; }
    }
    
    public CuentaAhorros(decimal saldoInicial)
    {
        if (saldoInicial < SALDO_MINIMO)
            throw new ArgumentException($"El saldo inicial debe ser al menos ${SALDO_MINIMO}");
            
        _saldo = saldoInicial;
        _transacciones = new List<decimal>();
    }
    
    // Métodos públicos con validación
    public bool Depositar(decimal cantidad)
    {
        if (cantidad <= 0)
        {
            Console.WriteLine("La cantidad debe ser positiva");
            return false;
        }
        
        _saldo += cantidad;
        _transacciones.Add(cantidad);
        Console.WriteLine($"Depósito exitoso. Nuevo saldo: ${_saldo:F2}");
        return true;
    }
    
    public bool Retirar(decimal cantidad)
    {
        if (cantidad <= 0)
        {
            Console.WriteLine("La cantidad debe ser positiva");
            return false;
        }
        
        if (_saldo - cantidad < SALDO_MINIMO)
        {
            Console.WriteLine($"No se puede retirar. Saldo mínimo requerido: ${SALDO_MINIMO}");
            return false;
        }
        
        _saldo -= cantidad;
        _transacciones.Add(-cantidad);
        Console.WriteLine($"Retiro exitoso. Nuevo saldo: ${_saldo:F2}");
        return true;
    }
}
```

## 🛡️ Estrategias de Protección de Datos

### 1. Validación en Setters
```csharp
public class ConfiguracionSistema
{
    private int _timeoutSegundos;
    private string _rutaArchivos;
    
    public int TimeoutSegundos
    {
        get { return _timeoutSegundos; }
        set
        {
            if (value < 1 || value > 3600)  // Entre 1 segundo y 1 hora
                throw new ArgumentOutOfRangeException("Timeout debe estar entre 1 y 3600 segundos");
            _timeoutSegundos = value;
        }
    }
    
    public string RutaArchivos
    {
        get { return _rutaArchivos; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("La ruta no puede estar vacía");
                
            if (!System.IO.Directory.Exists(value))
                throw new DirectoryNotFoundException($"La ruta no existe: {value}");
                
            _rutaArchivos = value;
        }
    }
}
```

### 2. Estados Inmutables
```csharp
public class Coordenada
{
    public double X { get; private set; }
    public double Y { get; private set; }
    
    public Coordenada(double x, double y)
    {
        X = x;
        Y = y;
    }
    
    // En lugar de modificar, crear nueva instancia
    public Coordenada Mover(double deltaX, double deltaY)
    {
        return new Coordenada(X + deltaX, Y + deltaY);
    }
    
    public double DistanciaAlOrigen()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
}
```

### 3. Lazy Loading (Carga Diferida)
```csharp
public class ReporteComplejo
{
    private List<string> _datos;
    private string _resumenCalculado;
    
    public List<string> Datos 
    { 
        get { return _datos ?? (_datos = new List<string>()); }
        private set { _datos = value; }
    }
    
    // Propiedad que se calcula solo cuando se necesita
    public string Resumen
    {
        get
        {
            if (_resumenCalculado == null)
            {
                _resumenCalculado = CalcularResumen();
            }
            return _resumenCalculado;
        }
    }
    
    public void AgregarDato(string dato)
    {
        Datos.Add(dato);
        _resumenCalculado = null;  // Invalidar resumen calculado
    }
    
    private string CalcularResumen()
    {
        // Simulación de cálculo complejo
        return $"Resumen de {Datos.Count} elementos procesados";
    }
}
```

## 🎯 Ejemplo Práctico Completo: Sistema de Gestión de Estudiantes

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Estudiante
{
    // Campos privados
    private string _nombre;
    private string _apellido;
    private int _edad;
    private List<double> _calificaciones;
    private const double NOTA_MINIMA = 0.0;
    private const double NOTA_MAXIMA = 20.0;
    private const double NOTA_APROBATORIA = 10.5;
    
    // Propiedades públicas con validación
    public string Nombre
    {
        get { return _nombre; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre no puede estar vacío");
            _nombre = value.Trim().ToTitleCase();
        }
    }
    
    public string Apellido
    {
        get { return _apellido; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El apellido no puede estar vacío");
            _apellido = value.Trim().ToTitleCase();
        }
    }
    
    public int Edad
    {
        get { return _edad; }
        set
        {
            if (value < 16 || value > 100)
                throw new ArgumentOutOfRangeException("La edad debe estar entre 16 y 100 años");
            _edad = value;
        }
    }
    
    // Propiedad de solo lectura calculada
    public string NombreCompleto
    {
        get { return $"{_nombre} {_apellido}"; }
    }
    
    // Propiedades calculadas basadas en calificaciones
    public double Promedio
    {
        get
        {
            if (_calificaciones.Count == 0)
                return 0;
            return _calificaciones.Average();
        }
    }
    
    public bool EstaAprobado
    {
        get { return Promedio >= NOTA_APROBATORIA; }
    }
    
    public int NumeroCalificaciones
    {
        get { return _calificaciones.Count; }
    }
    
    public string RendimientoAcademico
    {
        get
        {
            double promedio = Promedio;
            if (promedio >= 18) return "Excelente";
            if (promedio >= 15) return "Muy Bueno";
            if (promedio >= 12) return "Bueno";
            if (promedio >= NOTA_APROBATORIA) return "Regular";
            return "Deficiente";
        }
    }
    
    // Propiedades de solo lectura para acceso seguro a colecciones
    public IReadOnlyList<double> Calificaciones
    {
        get { return _calificaciones.AsReadOnly(); }
    }
    
    // Constructor
    public Estudiante(string nombre, string apellido, int edad)
    {
        Nombre = nombre;  // Usa la propiedad para validar
        Apellido = apellido;
        Edad = edad;
        _calificaciones = new List<double>();
    }
    
    // Métodos públicos para manipular calificaciones
    public bool AgregarCalificacion(double calificacion)
    {
        if (calificacion < NOTA_MINIMA || calificacion > NOTA_MAXIMA)
        {
            Console.WriteLine($"Calificación inválida. Debe estar entre {NOTA_MINIMA} y {NOTA_MAXIMA}");
            return false;
        }
        
        _calificaciones.Add(calificacion);
        Console.WriteLine($"Calificación {calificacion} agregada a {NombreCompleto}");
        return true;
    }
    
    public bool EliminarUltimaCalificacion()
    {
        if (_calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones para eliminar");
            return false;
        }
        
        double ultimaCalificacion = _calificaciones.Last();
        _calificaciones.RemoveAt(_calificaciones.Count - 1);
        Console.WriteLine($"Calificación {ultimaCalificacion} eliminada de {NombreCompleto}");
        return true;
    }
    
    public void MostrarReporte()
    {
        Console.WriteLine($"\n📊 Reporte de {NombreCompleto}");
        Console.WriteLine($"Edad: {_edad} años");
        Console.WriteLine($"Número de calificaciones: {NumeroCalificaciones}");
        
        if (NumeroCalificaciones > 0)
        {
            Console.WriteLine($"Calificaciones: {string.Join(", ", _calificaciones)}");
            Console.WriteLine($"Promedio: {Promedio:F2}");
            Console.WriteLine($"Estado: {(EstaAprobado ? "APROBADO" : "REPROBADO")}");
            Console.WriteLine($"Rendimiento: {RendimientoAcademico}");
        }
        else
        {
            Console.WriteLine("Sin calificaciones registradas");
        }
    }
    
    // Sobrescribir ToString para representación limpia
    public override string ToString()
    {
        return $"{NombreCompleto} (Promedio: {Promedio:F2}, {RendimientoAcademico})";
    }
}

// Clase para gestionar múltiples estudiantes
public class GestorEstudiantes
{
    private List<Estudiante> _estudiantes;
    
    public int CantidadEstudiantes { get { return _estudiantes.Count; } }
    
    public IReadOnlyList<Estudiante> Estudiantes
    {
        get { return _estudiantes.AsReadOnly(); }
    }
    
    public GestorEstudiantes()
    {
        _estudiantes = new List<Estudiante>();
    }
    
    public bool AgregarEstudiante(Estudiante estudiante)
    {
        if (estudiante == null)
        {
            Console.WriteLine("El estudiante no puede ser nulo");
            return false;
        }
        
        // Verificar que no exista ya
        if (_estudiantes.Any(e => e.NombreCompleto.Equals(estudiante.NombreCompleto, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Ya existe un estudiante con el nombre {estudiante.NombreCompleto}");
            return false;
        }
        
        _estudiantes.Add(estudiante);
        Console.WriteLine($"✅ Estudiante {estudiante.NombreCompleto} agregado correctamente");
        return true;
    }
    
    public Estudiante BuscarEstudiante(string nombreCompleto)
    {
        return _estudiantes.FirstOrDefault(e => 
            e.NombreCompleto.Equals(nombreCompleto, StringComparison.OrdinalIgnoreCase));
    }
    
    public List<Estudiante> ObtenerAprobados()
    {
        return _estudiantes.Where(e => e.EstaAprobado).ToList();
    }
    
    public double PromedioGeneral()
    {
        if (_estudiantes.Count == 0 || !_estudiantes.Any(e => e.NumeroCalificaciones > 0))
            return 0;
            
        return _estudiantes.Where(e => e.NumeroCalificaciones > 0).Average(e => e.Promedio);
    }
    
    public void MostrarEstadisticas()
    {
        Console.WriteLine($"\n📈 Estadísticas del Curso");
        Console.WriteLine($"Total estudiantes: {CantidadEstudiantes}");
        Console.WriteLine($"Estudiantes aprobados: {ObtenerAprobados().Count}");
        Console.WriteLine($"Promedio general: {PromedioGeneral():F2}");
        
        var estudiantesConNotas = _estudiantes.Where(e => e.NumeroCalificaciones > 0).ToList();
        if (estudiantesConNotas.Any())
        {
            var mejorEstudiante = estudiantesConNotas.OrderByDescending(e => e.Promedio).First();
            Console.WriteLine($"Mejor estudiante: {mejorEstudiante.NombreCompleto} ({mejorEstudiante.Promedio:F2})");
        }
    }
}

// Programa principal de demostración
class Program
{
    static void Main()
    {
        var gestor = new GestorEstudiantes();
        
        try
        {
            // Crear estudiantes
            var estudiante1 = new Estudiante("Ana", "García", 20);
            var estudiante2 = new Estudiante("Luis", "Martínez", 19);
            var estudiante3 = new Estudiante("María", "López", 21);
            
            // Agregar al gestor
            gestor.AgregarEstudiante(estudiante1);
            gestor.AgregarEstudiante(estudiante2);
            gestor.AgregarEstudiante(estudiante3);
            
            // Agregar calificaciones
            estudiante1.AgregarCalificacion(15.5);
            estudiante1.AgregarCalificacion(18.0);
            estudiante1.AgregarCalificacion(16.5);
            
            estudiante2.AgregarCalificacion(12.0);
            estudiante2.AgregarCalificacion(14.5);
            estudiante2.AgregarCalificacion(13.0);
            
            estudiante3.AgregarCalificacion(19.0);
            estudiante3.AgregarCalificacion(18.5);
            estudiante3.AgregarCalificacion(19.5);
            
            // Mostrar reportes individuales
            foreach (var estudiante in gestor.Estudiantes)
            {
                estudiante.MostrarReporte();
            }
            
            // Mostrar estadísticas generales
            gestor.MostrarEstadisticas();
            
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error de validación: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
        }
    }
}
```

## ✅ Buenas Prácticas de Encapsulación

### 1. Principio de Responsabilidad Única
```csharp
// ✅ Bueno - cada clase tiene una responsabilidad
public class Validador
{
    public static bool EsEmailValido(string email) { /* ... */ }
    public static bool EsTelefonoValido(string telefono) { /* ... */ }
}

public class Persona
{
    private string _email;
    
    public string Email
    {
        get { return _email; }
        set
        {
            if (!Validador.EsEmailValido(value))
                throw new ArgumentException("Email inválido");
            _email = value;
        }
    }
}
```

### 2. Inmutabilidad Cuando Sea Posible
```csharp
public class Punto
{
    public double X { get; private set; }
    public double Y { get; private set; }
    
    public Punto(double x, double y)
    {
        X = x;
        Y = y;
    }
    
    // Crear nuevo objeto en lugar de modificar
    public Punto Trasladar(double deltaX, double deltaY)
    {
        return new Punto(X + deltaX, Y + deltaY);
    }
}
```

### 3. Uso de Interfaces para Contratos
```csharp
public interface INotificable
{
    void EnviarNotificacion(string mensaje);
}

public class Usuario : INotificable
{
    private string _email;
    
    public void EnviarNotificacion(string mensaje)
    {
        // Implementación específica
    }
}
```

## 🔚 Resumen

- La **encapsulación** protege los datos y controla el acceso
- Usa **modificadores de acceso** apropiados: `private` para datos, `public` para interfaz
- Las **propiedades** proporcionan acceso controlado con validación
- Valida datos en los **setters** para mantener consistencia
- Usa **propiedades automáticas** para casos simples
- Implementa **propiedades manuales** cuando necesites validación
- Protege las **colecciones** usando `IReadOnlyList` o similar
- Aplica el **principio de responsabilidad única**

## ➡️ Siguiente: [Teoría 04: Herencia](Teoria-04-Herencia.md)