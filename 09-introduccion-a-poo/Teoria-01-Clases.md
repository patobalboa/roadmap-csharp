# 📖 Teoría 01: Fundamentos de Clases en C#

## 🎯 Objetivos de Aprendizaje
Al finalizar esta lección, podrás:
- Entender qué es una clase y por qué es importante
- Identificar los componentes básicos de una clase
- Crear tu primera clase en C#
- Usar constructores para inicializar objetos
- Diferenciar entre campos y propiedades

## 🤔 ¿Qué es una Clase?

### Analogía del Mundo Real
Imagina que quieres describir un **automóvil**. Un automóvil tiene:
- **Características**: marca, modelo, color, año, número de puertas
- **Acciones**: acelerar, frenar, encender, apagar

En programación, una **clase** es como un plano o molde que describe:
- **Qué características** puede tener un objeto (propiedades/campos)
- **Qué acciones** puede realizar un objeto (métodos)

### De Python a C#
```python
# Python - Definición de clase
class Automovil:
    def __init__(self, marca, modelo):
        self.marca = marca
        self.modelo = modelo
    
    def acelerar(self):
        print(f"El {self.marca} {self.modelo} está acelerando")
```

```csharp
// C# - Definición de clase
public class Automovil
{
    // Campos (variables de la clase)
    public string Marca;
    public string Modelo;
    
    // Constructor
    public Automovil(string marca, string modelo)
    {
        Marca = marca;
        Modelo = modelo;
    }
    
    // Método
    public void Acelerar()
    {
        Console.WriteLine($"El {Marca} {Modelo} está acelerando");
    }
}
```

## 🏗️ Anatomía de una Clase en C#

### Estructura Básica
```csharp
public class NombreDeLaClase
{
    // 1. CAMPOS (variables de la clase)
    private string _campoPrivado;
    public int CampoPublico;
    
    // 2. PROPIEDADES (acceso controlado a datos)
    public string Propiedad { get; set; }
    
    // 3. CONSTRUCTORES (inicializan el objeto)
    public NombreDeLaClase()
    {
        // Constructor por defecto
    }
    
    public NombreDeLaClase(string parametro)
    {
        // Constructor con parámetros
        Propiedad = parametro;
    }
    
    // 4. MÉTODOS (acciones que puede realizar)
    public void HacerAlgo()
    {
        // Código del método
    }
    
    public string ObtenerInformacion()
    {
        return $"Información: {Propiedad}";
    }
}
```

## 🧱 Componentes de una Clase

### 1. Campos (Fields)
Los **campos** son variables que almacenan datos de la clase:

```csharp
public class Estudiante
{
    // Campos públicos (no recomendado)
    public string Nombre;
    public int Edad;
    
    // Campos privados (recomendado)
    private double _promedio;
    private List<string> _materias;
}
```

### 2. Propiedades (Properties)
Las **propiedades** proporcionan acceso controlado a los campos:

```csharp
public class Estudiante
{
    private string _nombre;
    private int _edad;
    
    // Propiedad con validación
    public string Nombre
    {
        get { return _nombre; }
        set 
        {
            if (!string.IsNullOrEmpty(value))
                _nombre = value;
        }
    }
    
    // Propiedad automática (más simple)
    public int Edad { get; set; }
    
    // Propiedad de solo lectura
    public string NombreCompleto 
    { 
        get { return $"{_nombre} (Edad: {Edad})"; } 
    }
}
```

### 3. Constructores
Los **constructores** inicializan nuevos objetos:

```csharp
public class Estudiante
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public double Promedio { get; set; }
    
    // Constructor por defecto
    public Estudiante()
    {
        Nombre = "Sin nombre";
        Edad = 0;
        Promedio = 0.0;
    }
    
    // Constructor con parámetros
    public Estudiante(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
        Promedio = 0.0;
    }
    
    // Constructor completo
    public Estudiante(string nombre, int edad, double promedio)
    {
        Nombre = nombre;
        Edad = edad;
        Promedio = promedio;
    }
}
```

### 4. Métodos
Los **métodos** definen las acciones que puede realizar la clase:

```csharp
public class Estudiante
{
    public string Nombre { get; set; }
    public List<double> Calificaciones { get; set; }
    
    public Estudiante()
    {
        Calificaciones = new List<double>();
    }
    
    // Método para agregar calificación
    public void AgregarCalificacion(double calificacion)
    {
        if (calificacion >= 0 && calificacion <= 20)
        {
            Calificaciones.Add(calificacion);
        }
    }
    
    // Método para calcular promedio
    public double CalcularPromedio()
    {
        if (Calificaciones.Count == 0)
            return 0;
            
        return Calificaciones.Average();
    }
    
    // Método para mostrar información
    public string ObtenerInformacion()
    {
        return $"Estudiante: {Nombre}, Promedio: {CalcularPromedio():F2}";
    }
}
```

## 💡 Ejemplo Completo: Clase Producto

```csharp
using System;

public class Producto
{
    // Campos privados
    private string _nombre;
    private decimal _precio;
    private int _stock;
    
    // Propiedades con validación
    public string Nombre
    {
        get { return _nombre; }
        set 
        {
            if (!string.IsNullOrWhiteSpace(value))
                _nombre = value;
            else
                throw new ArgumentException("El nombre no puede estar vacío");
        }
    }
    
    public decimal Precio
    {
        get { return _precio; }
        set
        {
            if (value >= 0)
                _precio = value;
            else
                throw new ArgumentException("El precio no puede ser negativo");
        }
    }
    
    public int Stock
    {
        get { return _stock; }
        set
        {
            if (value >= 0)
                _stock = value;
            else
                throw new ArgumentException("El stock no puede ser negativo");
        }
    }
    
    // Propiedad calculada
    public decimal ValorInventario
    {
        get { return _precio * _stock; }
    }
    
    // Constructores
    public Producto()
    {
        _nombre = "Producto sin nombre";
        _precio = 0;
        _stock = 0;
    }
    
    public Producto(string nombre, decimal precio, int stock)
    {
        Nombre = nombre;  // Usa la propiedad para validar
        Precio = precio;
        Stock = stock;
    }
    
    // Métodos
    public bool VenderProducto(int cantidad)
    {
        if (cantidad <= 0)
            return false;
            
        if (cantidad <= _stock)
        {
            _stock -= cantidad;
            return true;
        }
        
        return false;
    }
    
    public void AgregarStock(int cantidad)
    {
        if (cantidad > 0)
        {
            _stock += cantidad;
        }
    }
    
    public string ObtenerInformacion()
    {
        return $"Producto: {_nombre}\n" +
               $"Precio: ${_precio:F2}\n" +
               $"Stock: {_stock} unidades\n" +
               $"Valor Total: ${ValorInventario:F2}";
    }
    
    public override string ToString()
    {
        return $"{_nombre} - ${_precio:F2} ({_stock} unidades)";
    }
}
```

## 🎯 Uso de la Clase Producto

```csharp
// Crear objetos usando diferentes constructores
Producto producto1 = new Producto();
Producto producto2 = new Producto("Laptop Gaming", 1200.50m, 10);

// Modificar propiedades
producto1.Nombre = "Mouse Inalámbrico";
producto1.Precio = 25.99m;
producto1.Stock = 50;

// Usar métodos
Console.WriteLine(producto2.ObtenerInformacion());

// Vender productos
if (producto2.VenderProducto(3))
{
    Console.WriteLine("Venta exitosa");
}
else
{
    Console.WriteLine("No hay suficiente stock");
}

// Agregar stock
producto2.AgregarStock(5);

Console.WriteLine($"Nuevo stock: {producto2.Stock}");
Console.WriteLine($"Valor del inventario: ${producto2.ValorInventario:F2}");
```

## 🎨 Convenciones de Nomenclatura en C#

### Para Clases
- **PascalCase**: `Producto`, `EstudianteUniversitario`, `ManejadorArchivos`
- Nombres descriptivos y sustantivos
- Evitar abreviaciones: `Estudiante` ✅, `Est` ❌

### Para Propiedades y Métodos
- **PascalCase**: `Nombre`, `CalcularPromedio()`, `ObtenerInformacion()`

### Para Campos Privados
- **camelCase con _**: `_nombre`, `_precio`, `_fechaCreacion`

### Para Parámetros y Variables Locales
- **camelCase**: `nombre`, `precio`, `cantidadVendida`

## ✅ Buenas Prácticas

1. **Encapsulación**: Usa campos privados y propiedades públicas
```csharp
// ❌ Malo
public string Nombre;

// ✅ Bueno
private string _nombre;
public string Nombre 
{ 
    get { return _nombre; } 
    set { _nombre = value; } 
}
```

2. **Validación en Propiedades**:
```csharp
public int Edad
{
    get { return _edad; }
    set
    {
        if (value >= 0 && value <= 120)
            _edad = value;
        else
            throw new ArgumentOutOfRangeException("Edad debe estar entre 0 y 120");
    }
}
```

3. **Constructores Múltiples**:
```csharp
public Persona() : this("Sin nombre", 0) { }
public Persona(string nombre) : this(nombre, 0) { }
public Persona(string nombre, int edad)
{
    Nombre = nombre;
    Edad = edad;
}
```

4. **Métodos con Propósito Único**:
```csharp
// Cada método hace una sola cosa
public double CalcularPromedio() { /* ... */ }
public void AgregarCalificacion(double calificacion) { /* ... */ }
public bool EsAprobado() { /* ... */ }
```

## 🔚 Resumen

- Una **clase** es un molde para crear objetos
- Contiene **campos** (datos), **propiedades** (acceso controlado), **constructores** (inicialización) y **métodos** (acciones)
- Los **constructores** permiten diferentes formas de crear objetos
- Las **propiedades** proporcionan acceso seguro a los datos
- Los **métodos** definen el comportamiento de los objetos
- Usa convenciones de nomenclatura consistentes
- Aplica encapsulación desde el principio

## ➡️ Siguiente: [Teoría 02: Trabajando con Objetos](Teoria-02-Objetos.md)