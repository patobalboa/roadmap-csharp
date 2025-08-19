# Entrada y Salida por Consola en C#

## 🎯 Objetivos de Aprendizaje

Al finalizar esta lección podrás:
- Dominar `Console.WriteLine()` vs `Console.Write()` 
- Usar `Console.ReadLine()` para capturar entrada del usuario
- Aplicar técnicas de formateo avanzado para mostrar datos
- Manejar validación básica de entrada
- Comparar eficientemente con métodos de Python (`print()`, `input()`)

## 🆚 Comparación Principal: print() vs Console.WriteLine()

### Python - Salida:
```python
# Salida básica
print("Hola mundo")
print("Línea 1")
print("Línea 2")

# Sin salto de línea
print("Mismo", end=" ")
print("renglón")

# Con variables
nombre = "Ana"
edad = 25
print(f"Hola {nombre}, tienes {edad} años")
```

### C# - Salida:
```csharp
// Salida básica
Console.WriteLine("Hola mundo");
Console.WriteLine("Línea 1");
Console.WriteLine("Línea 2");

// Sin salto de línea
Console.Write("Mismo ");
Console.Write("renglón");

// Con variables
string nombre = "Ana";
int edad = 25;
Console.WriteLine("Hola " + nombre + ", tienes " + edad + " años");
```

## 📤 Métodos de Salida en C#

### 1. `Console.WriteLine()` - Con salto de línea

```csharp
Console.WriteLine("Esta línea termina con salto");
Console.WriteLine("Esta es una nueva línea");
Console.WriteLine();  // Línea vacía

// Salida:
// Esta línea termina con salto
// Esta es una nueva línea
//
```

### 2. `Console.Write()` - Sin salto de línea

```csharp
Console.Write("Todo ");
Console.Write("en ");
Console.Write("la ");
Console.Write("misma ");
Console.WriteLine("línea");

// Salida: Todo en la misma línea
```

### 3. Concatenación de variables

```csharp
string producto = "Laptop";
double precio = 1299.99;
int cantidad = 5;

// Método 1: Concatenación con +
Console.WriteLine("Producto: " + producto);
Console.WriteLine("Precio: $" + precio);
Console.WriteLine("Total: $" + (precio * cantidad));

// Método 2: ToString() para control de formato
Console.WriteLine("Precio formateado: $" + precio.ToString("F2"));
```

## 📥 Métodos de Entrada en C#

### Comparación Python ↔ C#:

| Función | Python | C# |
|---------|--------|-----|
| **Leer texto** | `input("Mensaje: ")` | `Console.ReadLine()` |
| **Leer número** | `int(input())` | `int.Parse(Console.ReadLine())` |
| **Leer decimal** | `float(input())` | `double.Parse(Console.ReadLine())` |

### 1. `Console.ReadLine()` - Lectura básica

```csharp
// Leer texto
Console.Write("Ingresa tu nombre: ");
string nombre = Console.ReadLine();
Console.WriteLine("Hola " + nombre);

// Leer números (requiere conversión)
Console.Write("Ingresa tu edad: ");
string edadTexto = Console.ReadLine();  // Lee como string
int edad = int.Parse(edadTexto);        // Convierte a int
Console.WriteLine("Tienes " + edad + " años");
```

### 2. Lectura y conversión en una línea

```csharp
// Patrón común: leer y convertir inmediatamente
Console.Write("Precio del producto: ");
double precio = double.Parse(Console.ReadLine());

Console.Write("¿Está activo? (true/false): ");
bool activo = bool.Parse(Console.ReadLine());

Console.Write("Ingresa una letra: ");
char letra = Console.ReadLine()[0];  // Toma primer carácter
```

## 🎨 Formateo Avanzado de Salida

### 1. Formateo de números decimales

```csharp
double precio = 1234.5678;

Console.WriteLine("Sin formato: " + precio);                    // 1234.5678
Console.WriteLine("2 decimales: " + precio.ToString("F2"));     // 1234.57
Console.WriteLine("Sin decimales: " + precio.ToString("F0"));   // 1235
Console.WriteLine("Con comas: " + precio.ToString("N2"));       // 1,234.57
Console.WriteLine("Como moneda: " + precio.ToString("C"));      // $1,234.57
```

### 2. Formateo de números enteros

```csharp
int numero = 42;
int numeroGrande = 1500000;

Console.WriteLine("Normal: " + numero);                           // 42
Console.WriteLine("Con ceros: " + numero.ToString("D5"));        // 00042
Console.WriteLine("Con comas: " + numeroGrande.ToString("N0"));  // 1,500,000
```

### 3. Formateo de fechas y horas

```csharp
DateTime ahora = DateTime.Now;

Console.WriteLine("Fecha completa: " + ahora);
Console.WriteLine("Solo fecha: " + ahora.ToShortDateString());   // 14/08/2025
Console.WriteLine("Solo hora: " + ahora.ToShortTimeString());    // 10:30 AM
Console.WriteLine("Personalizada: " + ahora.ToString("dd/MM/yyyy HH:mm"));
```

## 🏗️ Construcción de Mensajes Complejos

### Comparación: f-strings vs concatenación

**Python:**
```python
nombre = "Carlos"
edad = 28
salario = 3500.50

# f-string (recomendado en Python)
print(f"Empleado: {nombre}")
print(f"Edad: {edad} años")
print(f"Salario: ${salario:.2f}")
print(f"En 5 años tendrá {edad + 5} años")
```

**C#:**
```csharp
string nombre = "Carlos";
int edad = 28;
double salario = 3500.50;

// Concatenación (método principal en este nivel)
Console.WriteLine("Empleado: " + nombre);
Console.WriteLine("Edad: " + edad + " años");
Console.WriteLine("Salario: $" + salario.ToString("F2"));
Console.WriteLine("En 5 años tendrá " + (edad + 5) + " años");
```

### Crear reportes formateados

```csharp
string estudiante = "María García";
double nota1 = 8.5, nota2 = 9.0, nota3 = 7.8;
double promedio = (nota1 + nota2 + nota3) / 3;

Console.WriteLine("================================");
Console.WriteLine("         REPORTE DE NOTAS");
Console.WriteLine("================================");
Console.WriteLine("Estudiante: " + estudiante);
Console.WriteLine("Nota 1:     " + nota1.ToString("F1"));
Console.WriteLine("Nota 2:     " + nota2.ToString("F1"));
Console.WriteLine("Nota 3:     " + nota3.ToString("F1"));
Console.WriteLine("--------------------------------");
Console.WriteLine("Promedio:   " + promedio.ToString("F2"));
Console.WriteLine("Estado:     " + (promedio >= 6 ? "APROBADO" : "REPROBADO"));
Console.WriteLine("================================");
```

## ⌨️ Métodos Especiales de Entrada

### 1. `Console.ReadKey()` - Leer una tecla

```csharp
Console.WriteLine("Presiona cualquier tecla para continuar...");
Console.ReadKey();  // Pausa hasta que se presione una tecla

// También puede capturar qué tecla se presionó
Console.Write("Presiona S para continuar o N para salir: ");
ConsoleKeyInfo tecla = Console.ReadKey();
char letraPresionada = tecla.KeyChar;

if (letraPresionada == 'S' || letraPresionada == 's')
{
    Console.WriteLine("\nContinuando...");
}
```

### 2. Limpiar pantalla

```csharp
Console.Clear();  // Limpia toda la pantalla de consola
Console.WriteLine("Pantalla limpia!");
```

## ⚠️ Validación Básica de Entrada

### Problema común: entrada inválida

```csharp
// ❌ Problema: si el usuario ingresa "abc" en lugar de un número
Console.Write("Ingresa tu edad: ");
int edad = int.Parse(Console.ReadLine());  // ERROR si no es número
```

### Solución básica con TryParse

```csharp
// ✅ Mejor: validar antes de convertir
Console.Write("Ingresa tu edad: ");
string entrada = Console.ReadLine();
int edad;

if (int.TryParse(entrada, out edad))
{
    Console.WriteLine("Tu edad es: " + edad);
}
else
{
    Console.WriteLine("Error: no ingresaste un número válido");
}
```

### Función de validación reutilizable

```csharp
// Función para leer enteros de forma segura
static int LeerEntero(string mensaje)
{
    int numero;
    string entrada;
    
    do
    {
        Console.Write(mensaje);
        entrada = Console.ReadLine();
    } 
    while (!int.TryParse(entrada, out numero));
    
    return numero;
}

// Uso:
int edad = LeerEntero("Ingresa tu edad: ");
```

## 🧪 Casos Prácticos Comunes

### 1. Capturar información de usuario

```csharp
// Información personal
Console.WriteLine("=== REGISTRO DE USUARIO ===");

Console.Write("Nombre completo: ");
string nombre = Console.ReadLine();

Console.Write("Edad: ");
int edad = int.Parse(Console.ReadLine());

Console.Write("Email: ");
string email = Console.ReadLine();

Console.Write("¿Acepta términos? (true/false): ");
bool aceptaTerminos = bool.Parse(Console.ReadLine());

// Confirmación
Console.WriteLine("\n=== DATOS CAPTURADOS ===");
Console.WriteLine("Nombre: " + nombre);
Console.WriteLine("Edad: " + edad + " años");
Console.WriteLine("Email: " + email);
Console.WriteLine("Términos: " + (aceptaTerminos ? "Aceptados" : "No aceptados"));
```

### 2. Calculadora interactiva

```csharp
Console.WriteLine("=== CALCULADORA SIMPLE ===");

Console.Write("Primer número: ");
double num1 = double.Parse(Console.ReadLine());

Console.Write("Segundo número: ");
double num2 = double.Parse(Console.ReadLine());

Console.Write("Operación (+, -, *, /): ");
char operacion = Console.ReadLine()[0];

double resultado = 0;

switch (operacion)
{
    case '+':
        resultado = num1 + num2;
        break;
    case '-':
        resultado = num1 - num2;
        break;
    case '*':
        resultado = num1 * num2;
        break;
    case '/':
        resultado = num1 / num2;
        break;
}

Console.WriteLine("\nResultado: " + num1 + " " + operacion + " " + num2 + " = " + resultado);
```

### 3. Menú de opciones

```csharp
Console.WriteLine("=== MENÚ PRINCIPAL ===");
Console.WriteLine("1. Ver información");
Console.WriteLine("2. Agregar datos");
Console.WriteLine("3. Salir");
Console.Write("Selecciona una opción: ");

int opcion = int.Parse(Console.ReadLine());

switch (opcion)
{
    case 1:
        Console.WriteLine("Mostrando información...");
        break;
    case 2:
        Console.WriteLine("Agregando datos...");
        break;
    case 3:
        Console.WriteLine("¡Hasta luego!");
        break;
    default:
        Console.WriteLine("Opción no válida");
        break;
}
```

## 🎨 Mejorando la Presentación

### 1. Líneas decorativas

```csharp
Console.WriteLine("==========================================");
Console.WriteLine("              MI APLICACIÓN");
Console.WriteLine("==========================================");
Console.WriteLine();

// Contenido principal...

Console.WriteLine();
Console.WriteLine("------------------------------------------");
Console.WriteLine("Gracias por usar nuestra aplicación");
Console.WriteLine("------------------------------------------");
```

### 2. Espaciado y organización

```csharp
// Separadores visuales
Console.WriteLine("Pregunta 1:");
Console.Write("  Respuesta: ");
string respuesta1 = Console.ReadLine();

Console.WriteLine();  // Línea en blanco

Console.WriteLine("Pregunta 2:");
Console.Write("  Respuesta: ");
string respuesta2 = Console.ReadLine();
```

## 📋 Tabla Comparativa: Python vs C#

| Acción | Python | C# |
|--------|--------|-----|
| **Imprimir con salto** | `print("Hola")` | `Console.WriteLine("Hola");` |
| **Imprimir sin salto** | `print("Hola", end="")` | `Console.Write("Hola");` |
| **Leer texto** | `nombre = input("Nombre: ")` | `Console.Write("Nombre: "); string nombre = Console.ReadLine();` |
| **Leer entero** | `edad = int(input())` | `int edad = int.Parse(Console.ReadLine());` |
| **Formatear decimal** | `f"{precio:.2f}"` | `precio.ToString("F2")` |
| **Limpiar pantalla** | `os.system('cls')` | `Console.Clear();` |
| **Pausa** | `input("Presiona Enter...")` | `Console.ReadKey();` |

## 💡 Tips del Depurador

### 1. Inspeccionar valores de entrada
- Usar breakpoints después de `Console.ReadLine()`
- Ver qué contiene la variable antes de Parse()
- Verificar conversiones en ventana "Watch"

### 2. Probar diferentes entradas
- Números válidos e inválidos
- Texto vacío (solo Enter)
- Espacios extra
- Mayúsculas/minúsculas en booleanos

## 🎯 Resumen de Conceptos Clave

### Diferencias principales con Python:
1. **Métodos específicos**: `Console.WriteLine()` vs `print()`
2. **Lectura requiere conversión**: `int.Parse(Console.ReadLine())` vs `int(input())`
3. **Formateo con ToString()**: `.ToString("F2")` vs `f"{valor:.2f}"`
4. **Sin f-strings**: Concatenación con `+` por ahora
5. **Pausas explícitas**: `Console.ReadKey()` para evitar que se cierre

### Patrones comunes:
```csharp
// Patrón de entrada
Console.Write("Mensaje: ");
tipo variable = conversion(Console.ReadLine());

// Patrón de salida formateada
Console.WriteLine("Texto: " + variable.ToString("formato"));

// Patrón de confirmación
Console.WriteLine("Resultado mostrado");
Console.ReadKey();
```

## 🎯 Siguiente Paso

¡Excelente! Ya dominas la entrada/salida por consola en C#.

👉 **Continúa con**: [`ejercicios.md`](ejercicios.md) para practicar estos conceptos.
