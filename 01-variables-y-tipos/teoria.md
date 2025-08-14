# Variables y Tipos de Datos en C#

## 🎯 Objetivos de Aprendizaje

Al finalizar esta lección podrás:
- Declarar variables con tipado explícito en C#
- Entender las diferencias entre tipado dinámico (Python) y estático (C#)
- Usar los tipos de datos fundamentales: `int`, `double`, `string`, `bool`, `char`
- Convertir entre tipos de datos usando casting y métodos Parse
- Aplicar convenciones de nomenclatura en C#

## 🆚 Diferencia Principal: Tipado Dinámico vs Estático

### Python (Tipado Dinámico):
```python
# Python decide el tipo automáticamente
numero = 42          # Python: "Es un int"
numero = 3.14        # Python: "Ahora es un float"
numero = "Hola"      # Python: "Ahora es un string"
```

### C# (Tipado Estático):
```csharp
// Debes declarar el tipo explícitamente
int numero = 42;         // C#: "numero es SIEMPRE int"
// numero = 3.14;        // ❌ ERROR: No puedes cambiar el tipo
// numero = "Hola";      // ❌ ERROR: No puedes asignar string a int

double decimal = 3.14;   // Variable diferente para double
string texto = "Hola";   // Variable diferente para string
```

## 📊 Tipos de Datos Fundamentales

### 1. Números Enteros (`int`)

**Python:**
```python
edad = 25
year = 2024
temperatura = -10
```

**C#:**
```csharp
int edad = 25;
int year = 2024;
int temperatura = -10;

// Límites de int en C#
int minimo = int.MinValue;  // -2,147,483,648
int maximo = int.MaxValue;  // 2,147,483,647
```

### 2. Números Decimales (`double`)

**Python:**
```python
precio = 29.99
promedio = 8.75
pi = 3.14159
```

**C#:**
```csharp
double precio = 29.99;
double promedio = 8.75;
double pi = 3.14159;

// También existe 'float' (menos precisión)
float temperatura = 36.5f;  // Nota la 'f' al final
```

### 3. Texto (`string`)

**Python:**
```python
nombre = "María"
apellido = 'García'
mensaje = "Hola mundo"
```

**C#:**
```csharp
string nombre = "María";
string apellido = "García";    // Solo comillas dobles
string mensaje = "Hola mundo";

// Concatenación
string nombreCompleto = nombre + " " + apellido;
```

### 4. Valores Lógicos (`bool`)

**Python:**
```python
activo = True
terminado = False
es_mayor = edad > 18
```

**C#:**
```csharp
bool activo = true;           // Nota: minúscula
bool terminado = false;       // Nota: minúscula
bool esMayor = edad > 18;     // Convención camelCase
```

### 5. Caracteres Individuales (`char`)

**Python:**
```python
# Python no tiene tipo char específico
inicial = "M"    # Es un string de longitud 1
```

**C#:**
```csharp
char inicial = 'M';           // Comillas simples para char
char grado = 'A';
char simbolo = '@';

// Conversión char ↔ string
string texto = inicial.ToString();  // char → string
char letra = "X"[0];               // string → char (primer carácter)
```

## 🔄 Declaración de Variables

### Sintaxis básica:
```csharp
// Patrón: tipo nombreVariable = valor;
int edad = 20;
double altura = 1.75;
string nombre = "Carlos";
bool esEstudiante = true;
char calificacion = 'A';
```

### Declaración múltiple:
```csharp
// Mismo tipo, múltiples variables
int x = 10, y = 20, z = 30;

// Declarar sin inicializar (tienen valores por defecto)
int contador;        // Valor por defecto: 0
string mensaje;      // Valor por defecto: null
bool activo;         // Valor por defecto: false
```

### Inferencia de tipos con `var`:
```csharp
// C# puede inferir el tipo (pero sigue siendo estático)
var numero = 42;         // int (inferido)
var precio = 29.99;      // double (inferido)
var nombre = "Ana";      // string (inferido)

// Una vez declarado, el tipo no cambia
// numero = "Hola";      // ❌ ERROR: numero sigue siendo int
```

## 🔁 Conversión de Tipos (Casting)

### 1. Conversión Implícita (Automática):
```csharp
int entero = 42;
double decimal = entero;    // ✅ int → double (automático)
Console.WriteLine(decimal); // 42.0
```

### 2. Conversión Explícita (Manual):
```csharp
double decimal = 42.8;
int entero = (int)decimal;  // ✅ double → int (pierde decimales)
Console.WriteLine(entero);  // 42 (se trunca, no redondea)
```

### 3. Métodos Parse (String → Otros tipos):
```csharp
// Similar a int() y float() en Python
string numeroTexto = "123";
string decimalTexto = "45.67";

int numero = int.Parse(numeroTexto);       // "123" → 123
double decimal = double.Parse(decimalTexto); // "45.67" → 45.67
bool activo = bool.Parse("true");          // "true" → true
```

### 4. ToString (Otros tipos → String):
```csharp
int numero = 123;
double decimal = 45.67;
bool activo = true;

string numeroTexto = numero.ToString();    // 123 → "123"
string decimalTexto = decimal.ToString();  // 45.67 → "45.67"
string activoTexto = activo.ToString();    // true → "true"
```

## 📝 Convenciones de Nomenclatura

### Python vs C#:

| Tipo | Python | C# |
|------|--------|-----|
| **Variables** | `nombre_completo` | `nombreCompleto` |
| **Constantes** | `PI_VALUE` | `PiValue` |
| **Funciones** | `calcular_promedio()` | `CalcularPromedio()` |

### Ejemplos en C#:
```csharp
// ✅ Convención correcta (camelCase para variables)
int edadEstudiante = 20;
double promedioSemestre = 8.5;
string nombreCompleto = "María García";
bool esMayorDeEdad = true;

// ❌ Incorrecto (estilo Python)
int edad_estudiante = 20;
double promedio_semestre = 8.5;
```

## 🧮 Operadores Aritméticos

### Comparación Python ↔ C#:

| Operación | Python | C# | Resultado |
|-----------|--------|-----|-----------|
| **Suma** | `5 + 3` | `5 + 3` | `8` |
| **Resta** | `5 - 3` | `5 - 3` | `2` |
| **Multiplicación** | `5 * 3` | `5 * 3` | `15` |
| **División decimal** | `5 / 2` | `5.0 / 2` | `2.5` |
| **División entera** | `5 // 2` | `5 / 2` | `2` (si ambos son int) |
| **Módulo** | `5 % 2` | `5 % 2` | `1` |
| **Potencia** | `5 ** 2` | `Math.Pow(5, 2)` | `25` |

### Ejemplos prácticos:
```csharp
using System;

// Operaciones básicas
int a = 10;
int b = 3;

int suma = a + b;           // 13
int resta = a - b;          // 7
int multiplicacion = a * b; // 30
int division = a / b;       // 3 (división entera)
int modulo = a % b;         // 1

// Para división decimal
double divisionDecimal = (double)a / b;  // 3.333...
// o también:
double divisionDecimal2 = a / 3.0;       // 3.333...
```

## ⚠️ Errores Comunes y Cómo Evitarlos

### 1. Olvidar declarar el tipo:
```csharp
// ❌ Error
numero = 42;                // Error: falta tipo

// ✅ Correcto
int numero = 42;           
// o
var numero = 42;
```

### 2. Cambiar tipo después de declarar:
```csharp
// ❌ Error
int numero = 42;
numero = "Hola";           // Error: no puedes cambiar int a string

// ✅ Correcto: usa variables diferentes
int numero = 42;
string texto = "Hola";
```

### 3. División entera inesperada:
```csharp
// ❌ Resultado inesperado
int resultado = 5 / 2;     // 2 (no 2.5)

// ✅ Correcto para decimales
double resultado = 5.0 / 2; // 2.5
// o
double resultado = (double)5 / 2; // 2.5
```

### 4. Comparaciones con bool:
```csharp
// ❌ Incorrecto (estilo Python)
bool activo = True;        // Error: debe ser minúscula

// ✅ Correcto
bool activo = true;
bool inactivo = false;
```

## 🧪 Ejercicio Práctico: Variables Básicas

```csharp
using System;

// Información de un estudiante
string nombre = "Carlos";
string apellido = "Rodríguez";
int edad = 19;
double altura = 1.78;
char seccion = 'B';
bool esRegular = true;
double nota1 = 8.5;
double nota2 = 9.0;
double nota3 = 7.5;

// Cálculos
string nombreCompleto = nombre + " " + apellido;
double promedio = (nota1 + nota2 + nota3) / 3;
int edadEnMeses = edad * 12;

// Mostrar información
Console.WriteLine("=== INFORMACIÓN DEL ESTUDIANTE ===");
Console.WriteLine("Nombre completo: " + nombreCompleto);
Console.WriteLine("Edad: " + edad + " años (" + edadEnMeses + " meses)");
Console.WriteLine("Altura: " + altura + " metros");
Console.WriteLine("Sección: " + seccion);
Console.WriteLine("Estudiante regular: " + esRegular);
Console.WriteLine("Promedio: " + promedio.ToString("F2")); // 2 decimales
Console.ReadKey();
```

## 💡 Tips para el Depurador

### Usar breakpoints para inspeccionar variables:
1. Hacer clic en el margen izquierdo (aparece círculo rojo)
2. Ejecutar con F5
3. Cuando se detiene, ver valores en "Variables locales"
4. Continuar con F5 o F10 (paso a paso)

### Ver tipo de variable:
- Pasar mouse sobre variable → tooltip muestra tipo y valor
- Ventana "Watch" → agregar variables para monitorear

## 📋 Resumen de Conceptos Clave

| Concepto | Python | C# |
|----------|--------|-----|
| **Declaración** | `numero = 42` | `int numero = 42;` |
| **Tipado** | Dinámico | Estático |
| **Conversión** | `int("123")` | `int.Parse("123")` |
| **Concatenación** | `"Hola " + nombre` | `"Hola " + nombre` |
| **Booleanos** | `True`/`False` | `true`/`false` |
| **División** | `5/2 = 2.5` | `5/2 = 2` (int), `5.0/2 = 2.5` |

## 🎯 Siguiente Paso

¡Excelente! Ya dominas las variables y tipos en C#.

👉 **Continúa con**: [`ejercicios.md`](ejercicios.md) para practicar estos conceptos.
