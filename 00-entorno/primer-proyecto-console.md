# Tu Primer Proyecto en C#: Console Application

## 🎯 Objetivo
Crear tu primera aplicación de consola en C# usando .NET 8 y entender la estructura básica del código.

## 🆚 Comparación Rápida: Python vs C#

| Aspecto | Python | C# |
|---------|--------|-----|
| **Extensión de archivo** | `.py` | `.cs` |
| **Ejecución** | `python archivo.py` | Compilar + ejecutar |
| **Tipado** | Dinámico | Estático |
| **Punto de entrada** | Primera línea | Método `Main` |
| **Imprimir** | `print("Hola")` | `Console.WriteLine("Hola");` |

## 🚀 Paso 1: Crear Nuevo Proyecto

### Usando Visual Studio 2022:

1. **Abrir Visual Studio 2022**
2. **Crear nuevo proyecto**:
   - Clic en **"Crear un proyecto"**
   - Buscar: **"Console App"**
   - Seleccionar: **"Console App"** (no "Console App (.NET Framework)")

3. **Configurar proyecto**:
   ```
   Nombre del proyecto: MiPrimerProyecto
   Ubicación: C:\Users\[TuUsuario]\source\repos\
   Nombre de la solución: MiPrimerProyecto
   Framework: .NET 8.0 (Long Term Support)
   ```

4. **Hacer clic en "Crear"**

## 📁 Estructura del Proyecto Generado

```
MiPrimerProyecto/
├─ MiPrimerProyecto.csproj    # Archivo de configuración del proyecto
├─ Program.cs                 # Archivo principal con código C#
└─ bin/                       # Carpeta con archivos ejecutables (se genera automáticamente)
   └─ Debug/
      └─ net8.0/
```

## 💻 Código Inicial: Hola Mundo

### Archivo: `Program.cs`

```csharp
// Tu primer programa en C# 
// Esto es un comentario de línea

using System;  // Importar funcionalidades del sistema

namespace MiPrimerProyecto  // Espacio de nombres (organización)
{
    internal class Program  // Clase principal (la estudiaremos más adelante)
    {
        // Método Main: punto de entrada del programa
        static void Main(string[] args)
        {
            // Imprimir mensaje en consola
            Console.WriteLine("¡Hola Mundo desde C#!");
            
            // Pausar para que no se cierre inmediatamente
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
```

### ✨ Versión simplificada con C# 12 (.NET 8):

```csharp
// Versión moderna de Hola Mundo (Top-level statements)
using System;

Console.WriteLine("¡Hola Mundo desde C#!");
Console.WriteLine("Presiona cualquier tecla para continuar...");
Console.ReadKey();
```

## 🔍 Análisis Línea por Línea

### Comparación con Python:

**Python:**
```python
# archivo: hola_mundo.py
print("¡Hola Mundo desde Python!")
input("Presiona Enter para continuar...")
```

**C# (versión moderna):**
```csharp
// archivo: Program.cs
using System;

Console.WriteLine("¡Hola Mundo desde C#!");
Console.ReadKey();
```

### Explicación de diferencias clave:

| Elemento | Python | C# | ¿Por qué? |
|----------|--------|-----|-----------|
| **Importaciones** | `import sys` | `using System;` | C# requiere declarar qué bibliotecas usar |
| **Imprimir** | `print()` | `Console.WriteLine()` | C# especifica dónde imprimir (consola) |
| **Punto y coma** | No necesario | `;` requerido | C# necesita terminar cada instrucción |
| **Pausa** | `input()` | `Console.ReadKey()` | Diferentes métodos para pausar |

## ▶️ Paso 2: Ejecutar el Programa

### Método 1: Con depuración (recomendado para aprender)
1. Presionar **F5** o clic en **"Iniciar depuración"**
2. Se abre ventana de consola
3. Ver resultado
4. Presionar cualquier tecla para cerrar

### Método 2: Sin depuración (más rápido)
1. Presionar **Ctrl + F5** o clic en **"Iniciar sin depurar"**
2. Se abre ventana de consola que permanece abierta

### Método 3: Desde terminal
```cmd
# Navegar a la carpeta del proyecto
cd "C:\Users\[TuUsuario]\source\repos\MiPrimerProyecto"

# Compilar y ejecutar
dotnet run
```

## 🧪 Experimentando: Modificaciones Básicas

### Ejercicio 1: Múltiples líneas
```csharp
using System;

Console.WriteLine("=== MI PRIMER PROGRAMA ===");
Console.WriteLine("Nombre: [Tu nombre aquí]");
Console.WriteLine("Fecha: " + DateTime.Now.ToShortDateString());
Console.WriteLine("Lenguaje: C#");
Console.WriteLine("Framework: .NET 8");
Console.WriteLine("===========================");
Console.ReadKey();
```

### Ejercicio 2: Con variables (adelanto)
```csharp
using System;

string nombre = "Estudiante";
int edad = 20;
double promedio = 8.5;

Console.WriteLine("Información del estudiante:");
Console.WriteLine("Nombre: " + nombre);
Console.WriteLine("Edad: " + edad);
Console.WriteLine("Promedio: " + promedio);
Console.ReadKey();
```

## 🔧 Diferencias Técnicas Importantes

### 1. Compilación vs Interpretación

**Python (Interpretado):**
```bash
python hola_mundo.py  # Se ejecuta directamente
```

**C# (Compilado):**
```bash
dotnet build          # Primero compila
dotnet run            # Luego ejecuta
```

### 2. Archivos generados

**Python:** Solo tu archivo `.py`

**C#:** Se generan varios archivos:
```
bin/Debug/net8.0/
├─ MiPrimerProyecto.exe       # Ejecutable
├─ MiPrimerProyecto.dll       # Biblioteca compilada
├─ MiPrimerProyecto.deps.json # Dependencias
└─ MiPrimerProyecto.runtimeconfig.json # Configuración
```

### 3. Detección de errores

**Python:** Errores se detectan al ejecutar
**C#:** Errores se detectan al compilar (antes de ejecutar)

## 🐛 Errores Comunes y Soluciones

### Error 1: "The name 'Console' does not exist"
**Causa:** Falta `using System;`
```csharp
// ❌ Incorrecto
Console.WriteLine("Hola");

// ✅ Correcto
using System;
Console.WriteLine("Hola");
```

### Error 2: "Expected ;"
**Causa:** Falta punto y coma
```csharp
// ❌ Incorrecto
Console.WriteLine("Hola")

// ✅ Correcto
Console.WriteLine("Hola");
```

### Error 3: La consola se cierra inmediatamente
**Causa:** Falta pausa al final
```csharp
// ❌ Se cierra inmediatamente
Console.WriteLine("Hola");

// ✅ Espera entrada del usuario
Console.WriteLine("Hola");
Console.ReadKey();
```

## 🎯 Mini-Desafío

### Desafío 1: Información Personal
Crea un programa que muestre:
- Tu nombre
- Tu edad
- Tu carrera
- Tu materia favorita

**Salida esperada:**
```
========== MI INFORMACIÓN ==========
Nombre: María García
Edad: 19 años
Carrera: Ingeniería en Sistemas
Materia favorita: Programación
====================================
```

### Desafío 2: Calculadora de Suma Simple (adelanto)
```csharp
using System;

int numero1 = 10;
int numero2 = 25;
int suma = numero1 + numero2;

Console.WriteLine("Número 1: " + numero1);
Console.WriteLine("Número 2: " + numero2);
Console.WriteLine("La suma es: " + suma);
Console.ReadKey();
```

## 📝 Lista de Verificación

Antes de continuar al siguiente módulo, asegúrate de que puedes:

- [ ] Crear un nuevo proyecto Console App en Visual Studio
- [ ] Escribir y ejecutar un programa "Hola Mundo"
- [ ] Entender qué hace `using System;`
- [ ] Saber cuándo usar punto y coma (`;`)
- [ ] Ejecutar el programa con F5 y Ctrl+F5
- [ ] Ver la diferencia entre `Console.WriteLine()` y `print()`
- [ ] Usar `Console.ReadKey()` para pausar el programa

## 🎯 Siguiente Paso

¡Excelente! Has creado tu primer programa en C#. 

👉 **Continúa con**: [`01-variables-y-tipos/teoria.md`](../01-variables-y-tipos/teoria.md)

---

## 💡 Tips para la Transición Python → C#

### 1. **Mentalidad de tipado:**
- Python: "¿Qué valor tiene?"
- C#: "¿Qué tipo de valor es y qué valor tiene?"

### 2. **Sintaxis rigurosa:**
- En Python: La indentación es importante
- En C#: Los `;` y `{}` son importantes

### 3. **Herramientas:**
- Python: Editor de texto + intérprete
- C#: IDE completo con IntelliSense y depurador

---

*¡Felicitaciones! Has dado tu primer paso en el mundo de C# y .NET 🎉*
