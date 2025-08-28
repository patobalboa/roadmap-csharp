# 🐍➡️🔷 Python vs C#: Namespaces, Clases y Funciones

## 📋 Tabla de Comparación Rápida

| Concepto | Python | C# |
|----------|---------|-----|
| **Módulos/Namespaces** | `import math` | `using System.Math;` |
| **Definir clase** | `class MiClase:` | `class MiClase { }` |
| **Función/Método** | `def mi_funcion():` | `public static void MiFuncion()` |
| **Crear objeto** | `obj = MiClase()` | `MiClase obj = new MiClase();` |
| **Visibilidad** | `_privado` (convención) | `private` (palabra clave) |
| **Método estático** | `@staticmethod` | `static` |

---

## 📦 1. Módulos vs Namespaces

### Python - Módulos
```python
# archivo: matematicas.py
def sumar(a, b):
    return a + b

def restar(a, b):
    return a - b

# archivo: main.py
import matematicas
# o
from matematicas import sumar, restar

resultado = matematicas.sumar(5, 3)
# o
resultado = sumar(5, 3)
```

### C# - Namespaces
```csharp
// Archivo: Matematicas.cs
namespace MiProyecto.Matematicas
{
    public static class Calculadora
    {
        public static int Sumar(int a, int b)
        {
            return a + b;
        }
        
        public static int Restar(int a, int b)
        {
            return a - b;
        }
    }
}

// Archivo: Program.cs
using System;
using MiProyecto.Matematicas;

class Program
{
    static void Main(string[] args)
    {
        int resultado = Calculadora.Sumar(5, 3);
        Console.WriteLine(resultado);
    }
}
```

---

## 🏗️ 2. Clases: Estructura y Sintaxis

### Python - Definición de Clase
```python
class Persona:
    def __init__(self, nombre, edad):
        self.nombre = nombre
        self.edad = edad
        self._telefono = None  # "privado" por convención
    
    def saludar(self):
        return f"Hola, soy {self.nombre}"
    
    def cumplir_anos(self):
        self.edad += 1
    
    @property
    def telefono(self):
        return self._telefono
    
    @telefono.setter
    def telefono(self, valor):
        self._telefono = valor

# Uso
persona = Persona("Ana", 25)
print(persona.saludar())
persona.cumplir_anos()
persona.telefono = "123-456-7890"
```

### C# - Definición de Clase
```csharp
public class Persona
{
    // Propiedades automáticas
    public string Nombre { get; set; }
    public int Edad { get; set; }
    
    // Campo privado
    private string telefono;
    
    // Constructor
    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }
    
    // Método público
    public string Saludar()
    {
        return $"Hola, soy {Nombre}";
    }
    
    public void CumplirAnos()
    {
        Edad++;
    }
    
    // Propiedad con lógica personalizada
    public string Telefono
    {
        get { return telefono; }
        set { telefono = value; }
    }
}

// Uso
Persona persona = new Persona("Ana", 25);
Console.WriteLine(persona.Saludar());
persona.CumplirAnos();
persona.Telefono = "123-456-7890";
```

---

## ⚙️ 3. Funciones vs Métodos

### Python - Funciones
```python
# Función simple
def calcular_area_circulo(radio):
    import math
    return math.pi * radio ** 2

# Función con valores por defecto
def saludar(nombre, mensaje="Hola"):
    return f"{mensaje}, {nombre}!"

# Función que retorna múltiples valores
def obtener_estadisticas(numeros):
    return min(numeros), max(numeros), sum(numeros) / len(numeros)

# Método estático en clase
class Utilidades:
    @staticmethod
    def es_par(numero):
        return numero % 2 == 0
    
    @classmethod
    def crear_desde_string(cls, texto):
        # Método de clase
        pass

# Uso
area = calcular_area_circulo(5)
saludo = saludar("Ana")
saludo_personalizado = saludar("Ana", "Buenos días")
minimo, maximo, promedio = obtener_estadisticas([1, 2, 3, 4, 5])
es_par = Utilidades.es_par(4)
```

### C# - Métodos
```csharp
public class Utilidades
{
    // Método estático simple
    public static double CalcularAreaCirculo(double radio)
    {
        return Math.PI * radio * radio;
    }
    
    // Método con parámetros opcionales
    public static string Saludar(string nombre, string mensaje = "Hola")
    {
        return $"{mensaje}, {nombre}!";
    }
    
    // Método que retorna múltiples valores (tupla)
    public static (double min, double max, double promedio) ObtenerEstadisticas(double[] numeros)
    {
        double min = numeros.Min();
        double max = numeros.Max();
        double promedio = numeros.Average();
        return (min, max, promedio);
    }
    
    // Método estático
    public static bool EsPar(int numero)
    {
        return numero % 2 == 0;
    }
    
    // Método con parámetros de salida
    public static bool TryParseInt(string texto, out int resultado)
    {
        return int.TryParse(texto, out resultado);
    }
}

// Uso
double area = Utilidades.CalcularAreaCirculo(5);
string saludo = Utilidades.Saludar("Ana");
string saludoPersonalizado = Utilidades.Saludar("Ana", "Buenos días");

double[] numeros = {1, 2, 3, 4, 5};
var (min, max, promedio) = Utilidades.ObtenerEstadisticas(numeros);

bool esPar = Utilidades.EsPar(4);

// Parámetro de salida
if (Utilidades.TryParseInt("123", out int numero))
{
    Console.WriteLine($"Número parseado: {numero}");
}
```

---

## 🔐 4. Visibilidad y Encapsulación

### Python - Convenciones de Privacidad
```python
class Ejemplo:
    def __init__(self):
        self.publico = "Accesible desde cualquier lugar"
        self._protegido = "Por convención, uso interno"
        self.__privado = "Name mangling, más privado"
    
    def metodo_publico(self):
        return "Método público"
    
    def _metodo_protegido(self):
        return "Método protegido por convención"
    
    def __metodo_privado(self):
        return "Método privado"

# Uso
obj = Ejemplo()
print(obj.publico)        # ✅ Funciona
print(obj._protegido)     # ⚠️ Funciona pero no recomendado
# print(obj.__privado)    # ❌ Error (name mangling)
print(obj._Ejemplo__privado)  # ✅ Funciona con name mangling
```

### C# - Modificadores de Acceso Explícitos
```csharp
public class Ejemplo
{
    public string publico = "Accesible desde cualquier lugar";
    protected string protegido = "Solo esta clase y clases derivadas";
    private string privado = "Solo dentro de esta clase";
    internal string interno = "Solo dentro del mismo ensamblado";
    
    public string MetodoPublico()
    {
        return "Método público";
    }
    
    protected string MetodoProtegido()
    {
        return "Método protegido";
    }
    
    private string MetodoPrivado()
    {
        return "Método privado";
    }
}

// Uso
Ejemplo obj = new Ejemplo();
Console.WriteLine(obj.publico);     // ✅ Funciona
// Console.WriteLine(obj.privado);  // ❌ Error de compilación
// obj.MetodoPrivado();             // ❌ Error de compilación
```

---

## 🏃‍♂️ 5. Ejemplos Prácticos Comparativos

### Ejemplo: Sistema de Gestión de Estudiantes

#### Python
```python
class Estudiante:
    def __init__(self, nombre, edad):
        self.nombre = nombre
        self.edad = edad
        self.notas = []
    
    def agregar_nota(self, nota):
        if 0 <= nota <= 10:
            self.notas.append(nota)
        else:
            raise ValueError("La nota debe estar entre 0 y 10")
    
    def calcular_promedio(self):
        if not self.notas:
            return 0
        return sum(self.notas) / len(self.notas)
    
    def esta_aprobado(self):
        return self.calcular_promedio() >= 6.0
    
    def __str__(self):
        return f"Estudiante: {self.nombre}, Promedio: {self.calcular_promedio():.2f}"

class UtilidadesEstudiante:
    @staticmethod
    def determinar_nivel(promedio):
        if promedio >= 9.0:
            return "Excelente"
        elif promedio >= 7.0:
            return "Bueno"
        elif promedio >= 5.0:
            return "Regular"
        else:
            return "Insuficiente"
    
    @staticmethod
    def estudiantes_aprobados(estudiantes):
        return [est for est in estudiantes if est.esta_aprobado()]

# Uso
estudiante = Estudiante("Ana", 20)
estudiante.agregar_nota(8.5)
estudiante.agregar_nota(7.0)
print(estudiante)
print(f"Nivel: {UtilidadesEstudiante.determinar_nivel(estudiante.calcular_promedio())}")
```

#### C#
```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Estudiante
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    private List<double> notas = new List<double>();
    
    public Estudiante(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }
    
    public void AgregarNota(double nota)
    {
        if (nota >= 0 && nota <= 10)
        {
            notas.Add(nota);
        }
        else
        {
            throw new ArgumentException("La nota debe estar entre 0 y 10");
        }
    }
    
    public double CalcularPromedio()
    {
        if (notas.Count == 0)
            return 0;
        return notas.Average();
    }
    
    public bool EstaAprobado()
    {
        return CalcularPromedio() >= 6.0;
    }
    
    public override string ToString()
    {
        return $"Estudiante: {Nombre}, Promedio: {CalcularPromedio():F2}";
    }
}

public static class UtilidadesEstudiante
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
    
    public static List<Estudiante> EstudiantesAprobados(List<Estudiante> estudiantes)
    {
        return estudiantes.Where(est => est.EstaAprobado()).ToList();
    }
}

// Uso
class Program
{
    static void Main(string[] args)
    {
        Estudiante estudiante = new Estudiante("Ana", 20);
        estudiante.AgregarNota(8.5);
        estudiante.AgregarNota(7.0);
        
        Console.WriteLine(estudiante);
        Console.WriteLine($"Nivel: {UtilidadesEstudiante.DeterminarNivel(estudiante.CalcularPromedio())}");
    }
}
```

---

## 📊 6. Diferencias Clave

### Filosofía y Enfoque

| Aspecto | Python | C# |
|---------|---------|-----|
| **Tipado** | Dinámico | Estático |
| **Encapsulación** | Por convención | Forzada por compilador |
| **Sintaxis** | Minimalista | Más verbosa pero explícita |
| **Flexibilidad** | Alta | Media-Alta |
| **Rendimiento** | Interpretado | Compilado |
| **Detección de errores** | Tiempo de ejecución | Tiempo de compilación |

### Ventajas de cada enfoque

#### Python
✅ **Ventajas:**
- Sintaxis más concisa
- Flexibilidad en tipos de datos
- Duck typing
- Menos código repetitivo

❌ **Desventajas:**
- Errores descubiertos en runtime
- Rendimiento más lento
- Menos seguridad de tipos

#### C#
✅ **Ventajas:**
- Detección temprana de errores
- Mejor rendimiento
- IntelliSense más preciso
- Seguridad de tipos

❌ **Desventajas:**
- Más verboso
- Curva de aprendizaje más pronunciada
- Menos flexibilidad en algunos casos

---

## 🎯 7. Guía de Migración de Conceptos

### Al migrar de Python a C#, recuerda:

1. **Indentación → Llaves**: Python usa indentación, C# usa `{ }`
2. **duck typing → static typing**: Debes declarar tipos explícitamente
3. **Convenciones → Keywords**: `_private` se convierte en `private`
4. **import → using**: Cambio en la sintaxis de importación
5. **self → this**: Referencia al objeto actual
6. **@staticmethod → static**: Métodos estáticos
7. **if __name__ == "__main__": → static void Main()**: Punto de entrada

### Checklist de conversión:
- [ ] Agregar modificadores de acceso explícitos
- [ ] Declarar tipos de variables y parámetros
- [ ] Cambiar `def` por el tipo de retorno + nombre
- [ ] Agregar llaves para bloques de código
- [ ] Usar punto y coma al final de sentencias
- [ ] Convertir snake_case a PascalCase/camelCase
- [ ] Agregar using statements para namespaces

¡Con estos conceptos ya puedes comenzar a estructurar mejor tu código C#! 🚀
