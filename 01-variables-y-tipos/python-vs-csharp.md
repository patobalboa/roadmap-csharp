# Comparación Detallada: Python ↔ C#

## 🎯 Objetivo
Esta guía proporciona una comparación lado a lado entre Python y C# para facilitar la transición entre ambos lenguajes.

## 📋 Tabla de Equivalencias Principales

### Variables y Declaraciones

| Concepto | Python | C# | Notas |
|----------|--------|-----|-------|
| **Declarar variable entera** | `numero = 42` | `int numero = 42;` | C# requiere tipo explícito |
| **Declarar variable decimal** | `precio = 29.99` | `double precio = 29.99;` | C# distingue float/double |
| **Declarar texto** | `nombre = "Ana"` | `string nombre = "Ana";` | C# solo usa comillas dobles |
| **Declarar booleano** | `activo = True` | `bool activo = true;` | C# usa minúsculas |
| **Múltiples variables** | `x, y = 10, 20` | `int x = 10, y = 20;` | C# permite declaración múltiple |

### Operaciones Aritméticas

| Operación | Python | C# | Resultado en C# |
|-----------|--------|-----|-----------------|
| **Suma** | `5 + 3` | `5 + 3` | `8` |
| **Resta** | `5 - 3` | `5 - 3` | `2` |
| **Multiplicación** | `5 * 3` | `5 * 3` | `15` |
| **División decimal** | `5 / 2` = `2.5` | `5.0 / 2` = `2.5` | Debe haber al menos un double |
| **División entera** | `5 // 2` = `2` | `5 / 2` = `2` | Si ambos son int |
| **Módulo** | `5 % 2` | `5 % 2` | `1` |
| **Potencia** | `5 ** 2` | `Math.Pow(5, 2)` | `25` |

### Conversiones de Tipos

| Conversión | Python | C# |
|------------|--------|-----|
| **String → Int** | `int("123")` | `int.Parse("123")` |
| **String → Float** | `float("45.67")` | `double.Parse("45.67")` |
| **Int → String** | `str(123)` | `(123).ToString()` |
| **Float → String** | `str(45.67)` | `(45.67).ToString()` |
| **Float → Int** | `int(45.67)` | `(int)45.67` |
| **Bool → String** | `str(True)` | `true.ToString()` |

## 🔍 Ejemplos Lado a Lado

### Ejemplo 1: Información Personal

**Python:**
```python
# Variables básicas
nombre = "María"
apellido = "García"
edad = 22
altura = 1.65
es_estudiante = True

# Concatenación
nombre_completo = nombre + " " + apellido
presentacion = f"Hola, soy {nombre_completo}"

# Mostrar información
print("=== INFORMACIÓN PERSONAL ===")
print(f"Nombre: {nombre_completo}")
print(f"Edad: {edad} años")
print(f"Altura: {altura} metros")
print(f"¿Es estudiante?: {es_estudiante}")
```

**C#:**
```csharp
using System;

// Variables básicas
string nombre = "María";
string apellido = "García";
int edad = 22;
double altura = 1.65;
bool esEstudiante = true;

// Concatenación
string nombreCompleto = nombre + " " + apellido;
string presentacion = "Hola, soy " + nombreCompleto;

// Mostrar información
Console.WriteLine("=== INFORMACIÓN PERSONAL ===");
Console.WriteLine("Nombre: " + nombreCompleto);
Console.WriteLine("Edad: " + edad + " años");
Console.WriteLine("Altura: " + altura + " metros");
Console.WriteLine("¿Es estudiante?: " + esEstudiante);
Console.ReadKey();
```

### Ejemplo 2: Calculadora Simple

**Python:**
```python
# Entrada de datos
numero1 = float(input("Ingresa el primer número: "))
numero2 = float(input("Ingresa el segundo número: "))

# Operaciones
suma = numero1 + numero2
resta = numero1 - numero2
multiplicacion = numero1 * numero2
division = numero1 / numero2

# Resultados
print(f"\n=== RESULTADOS ===")
print(f"{numero1} + {numero2} = {suma}")
print(f"{numero1} - {numero2} = {resta}")
print(f"{numero1} * {numero2} = {multiplicacion}")
print(f"{numero1} / {numero2} = {division:.2f}")
```

**C#:**
```csharp
using System;

// Entrada de datos
Console.Write("Ingresa el primer número: ");
double numero1 = double.Parse(Console.ReadLine());

Console.Write("Ingresa el segundo número: ");
double numero2 = double.Parse(Console.ReadLine());

// Operaciones
double suma = numero1 + numero2;
double resta = numero1 - numero2;
double multiplicacion = numero1 * numero2;
double division = numero1 / numero2;

// Resultados
Console.WriteLine("\n=== RESULTADOS ===");
Console.WriteLine(numero1 + " + " + numero2 + " = " + suma);
Console.WriteLine(numero1 + " - " + numero2 + " = " + resta);
Console.WriteLine(numero1 + " * " + numero2 + " = " + multiplicacion);
Console.WriteLine(numero1 + " / " + numero2 + " = " + division.ToString("F2"));
Console.ReadKey();
```

### Ejemplo 3: Trabajando con Caracteres

**Python:**
```python
# Python no tiene tipo char específico
texto = "Programación"
primera_letra = texto[0]
ultima_letra = texto[-1]
longitud = len(texto)

print(f"Texto: {texto}")
print(f"Primera letra: {primera_letra}")
print(f"Última letra: {ultima_letra}")
print(f"Longitud: {longitud}")
```

**C#:**
```csharp
using System;

// C# tiene tipo char específico
string texto = "Programación";
char primeraLetra = texto[0];
char ultimaLetra = texto[texto.Length - 1];
int longitud = texto.Length;

Console.WriteLine("Texto: " + texto);
Console.WriteLine("Primera letra: " + primeraLetra);
Console.WriteLine("Última letra: " + ultimaLetra);
Console.WriteLine("Longitud: " + longitud);
Console.ReadKey();
```

## ⚠️ Diferencias Importantes a Recordar

### 1. Tipado

| Aspecto | Python | C# |
|---------|--------|-----|
| **Naturaleza** | Dinámico | Estático |
| **Cambio de tipo** | `x = 5; x = "hola"` ✅ | `int x = 5; x = "hola"` ❌ |
| **Detección de errores** | En tiempo de ejecución | En tiempo de compilación |

### 2. Sintaxis de Declaración

```python
# Python: Inferencia automática
edad = 25          # Python decide que es int
nombre = "Ana"     # Python decide que es string
```

```csharp
// C#: Declaración explícita
int edad = 25;           // Debo decir que es int
string nombre = "Ana";   // Debo decir que es string

// O inferencia con var (pero sigue siendo estático)
var edad = 25;           // C# infiere int, pero no puede cambiar
var nombre = "Ana";      // C# infiere string, pero no puede cambiar
```

### 3. Booleanos

```python
# Python: Primera letra mayúscula
activo = True
inactivo = False
```

```csharp
// C#: Todo en minúsculas
bool activo = true;
bool inactivo = false;
```

### 4. División

```python
# Python 3: Siempre decimal por defecto
resultado = 5 / 2        # 2.5
division_entera = 5 // 2 # 2
```

```csharp
// C#: Depende del tipo de los operandos
int resultado1 = 5 / 2;      // 2 (división entera)
double resultado2 = 5.0 / 2; // 2.5 (división decimal)
double resultado3 = (double)5 / 2; // 2.5 (casting)
```

### 5. Conversiones

```python
# Python: Funciones integradas
numero = int("123")
texto = str(456)
decimal = float("78.9")
```

```csharp
// C#: Métodos específicos
int numero = int.Parse("123");
string texto = (456).ToString();
double decimal = double.Parse("78.9");
```

## 🎯 Casos de Uso Comunes

### Caso 1: Intercambiar valores de variables

**Python:**
```python
a = 10
b = 20
a, b = b, a  # Intercambio directo
print(f"a = {a}, b = {b}")  # a = 20, b = 10
```

**C#:**
```csharp
int a = 10;
int b = 20;

// Método tradicional con variable temporal
int temp = a;
a = b;
b = temp;

Console.WriteLine($"a = {a}, b = {b}");  // a = 20, b = 10
```

### Caso 2: Formateo de números

**Python:**
```python
pi = 3.14159
print(f"Pi con 2 decimales: {pi:.2f}")      # 3.14
print(f"Pi como porcentaje: {pi:.1%}")      # 314.2%
```

**C#:**
```csharp
double pi = 3.14159;
Console.WriteLine("Pi con 2 decimales: " + pi.ToString("F2"));     // 3.14
Console.WriteLine("Pi como porcentaje: " + (pi/100).ToString("P1")); // Adaptación necesaria
```

## 🧠 Ejercicios de Transición

### Ejercicio 1: Traduce de Python a C#

**Python:**
```python
nombre = input("Tu nombre: ")
edad = int(input("Tu edad: "))
es_mayor = edad >= 18
mensaje = f"{nombre} {'es' if es_mayor else 'no es'} mayor de edad"
print(mensaje)
```

**Tu traducción a C#:**
```csharp
// Escribe aquí tu traducción
// (Solución en el archivo de soluciones)
```

### Ejercicio 2: Traduce de C# a Python

**C#:**
```csharp
double peso = 70.5;
double altura = 1.75;
double imc = peso / (altura * altura);
string clasificacion = imc < 18.5 ? "Bajo peso" : 
                      imc < 25 ? "Normal" : "Sobrepeso";
Console.WriteLine("IMC: " + imc.ToString("F1") + " - " + clasificacion);
```

**Tu traducción a Python:**
```python
# Escribe aquí tu traducción
# (Solución en el archivo de soluciones)
```

## 💡 Tips para la Transición

### 1. **Cambio de mentalidad:**
- Python: "¿Qué quiero hacer?"
- C#: "¿Qué tipo de datos estoy manejando y qué quiero hacer?"

### 2. **Herramientas de ayuda:**
- IntelliSense en Visual Studio muestra tipos automáticamente
- Usar `var` mientras aprendes, pero entender qué tipo se infiere
- Breakpoints para inspeccionar tipos y valores

### 3. **Errores frecuentes:**
- Olvidar punto y coma (`;`)
- Usar `True/False` en lugar de `true/false`
- No declarar tipo de variable
- Confundir división entera vs decimal

### 4. **Ventajas del tipado estático:**
- Errores detectados antes de ejecutar
- IntelliSense más preciso
- Código más autodocumentado
- Mejor rendimiento

## 🎯 Siguiente Paso

¡Ya tienes las herramientas para traducir entre Python y C#!

👉 **Continúa con**: [`ejercicios.md`](ejercicios.md) para practicar la transición.
