# Bucles for y while en C#

## 🎯 Objetivos del módulo
- Dominar los bucles **for** y **while** en C#
- Comparar sintaxis de bucles: **Python ↔ C#**
- Usar **foreach** para recorrer colecciones
- Aplicar **break** y **continue** para control de flujo
- Manejar **bucles anidados** y patrones comunes

## 📚 Conceptos fundamentales

Los bucles permiten **repetir** código múltiples veces de forma automática. En C# tenemos tres tipos principales:

1. **for** - Repetir un número específico de veces
2. **while** - Repetir mientras una condición sea verdadera  
3. **foreach** - Recorrer colecciones (arrays, listas)

## 🔄 Bucle FOR

### Sintaxis básica

**Python**:
```python
for i in range(5):
    print(f"Iteración {i}")
```

**C# equivalente**:
```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Iteración {i}");
}
```

### Anatomía del for en C#

```csharp
for (inicialización; condición; incremento)
{
    // Código a repetir
}
```

- **Inicialización**: `int i = 0` - Se ejecuta una sola vez al inicio
- **Condición**: `i < 5` - Se evalúa antes de cada iteración
- **Incremento**: `i++` - Se ejecuta después de cada iteración

### Ejemplos prácticos

#### 1. **Contar del 1 al 10**

```csharp
// Contar del 1 al 10
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"Número: {i}");
}
```

#### 2. **Contar hacia atrás**

```csharp
// Cuenta regresiva del 10 al 1
for (int i = 10; i >= 1; i--)
{
    Console.WriteLine($"Cuenta regresiva: {i}");
}
Console.WriteLine("¡Despegue!");
```

#### 3. **Incrementos personalizados**

```csharp
// Números pares del 0 al 20
for (int i = 0; i <= 20; i += 2)
{
    Console.WriteLine($"Número par: {i}");
}

// Tabla del 5
for (int i = 5; i <= 50; i += 5)
{
    Console.WriteLine($"5 × {i/5} = {i}");
}
```

## 🔄 Equivalencias Python ↔ C#

### Patrones comunes de bucles

| **Python** | **C#** |
|------------|--------|
| `for i in range(5):` | `for (int i = 0; i < 5; i++)` |
| `for i in range(1, 6):` | `for (int i = 1; i <= 5; i++)` |
| `for i in range(0, 10, 2):` | `for (int i = 0; i < 10; i += 2)` |
| `for i in range(10, 0, -1):` | `for (int i = 10; i > 0; i--)` |

### Ejemplo completo: Tabla de multiplicar

**Python**:
```python
numero = int(input("¿Qué tabla quieres? "))
for i in range(1, 11):
    resultado = numero * i
    print(f"{numero} × {i} = {resultado}")
```

**C# equivalente**:
```csharp
Console.Write("¿Qué tabla quieres? ");
int numero = int.Parse(Console.ReadLine());

for (int i = 1; i <= 10; i++)
{
    int resultado = numero * i;
    Console.WriteLine($"{numero} × {i} = {resultado}");
}
```

## 🔄 Bucle WHILE

### Sintaxis básica

**Python**:
```python
i = 0
while i < 5:
    print(f"Iteración {i}")
    i += 1
```

**C# equivalente**:
```csharp
int i = 0;
while (i < 5)
{
    Console.WriteLine($"Iteración {i}");
    i++;
}
```

### ¿Cuándo usar while?

- Cuando **no sabes** cuántas iteraciones necesitas
- Para **menús** interactivos
- **Validación** de entrada del usuario
- **Juegos** o simulaciones

### Ejemplos prácticos

#### 1. **Validación de entrada**

```csharp
int edad;
while (true)
{
    Console.Write("Ingresa tu edad (0-120): ");
    string entrada = Console.ReadLine();
    
    if (int.TryParse(entrada, out edad) && edad >= 0 && edad <= 120)
    {
        break; // Salir del bucle
    }
    
    Console.WriteLine("Edad inválida. Intenta de nuevo.");
}

Console.WriteLine($"Tu edad es: {edad} años");
```

#### 2. **Menú interactivo**

```csharp
string opcion = "";
while (opcion != "4")
{
    Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
    Console.WriteLine("1. Ver inventario");
    Console.WriteLine("2. Agregar producto");
    Console.WriteLine("3. Eliminar producto");
    Console.WriteLine("4. Salir");
    Console.Write("Selecciona una opción: ");
    
    opcion = Console.ReadLine();
    
    switch (opcion)
    {
        case "1":
            Console.WriteLine("Mostrando inventario...");
            break;
        case "2":
            Console.WriteLine("Agregando producto...");
            break;
        case "3":
            Console.WriteLine("Eliminando producto...");
            break;
        case "4":
            Console.WriteLine("¡Hasta luego!");
            break;
        default:
            Console.WriteLine("Opción inválida");
            break;
    }
}
```

#### 3. **Juego de adivinanza**

```csharp
Random random = new Random();
int numeroSecreto = random.Next(1, 101); // Número entre 1 y 100
int intentos = 0;
int numeroUsuario = 0;

Console.WriteLine("¡Adivina el número entre 1 y 100!");

while (numeroUsuario != numeroSecreto)
{
    Console.Write("Tu número: ");
    
    if (int.TryParse(Console.ReadLine(), out numeroUsuario))
    {
        intentos++;
        
        if (numeroUsuario < numeroSecreto)
        {
            Console.WriteLine("¡Muy bajo! Intenta un número mayor.");
        }
        else if (numeroUsuario > numeroSecreto)
        {
            Console.WriteLine("¡Muy alto! Intenta un número menor.");
        }
        else
        {
            Console.WriteLine($"¡Correcto! Lo adivinaste en {intentos} intentos.");
        }
    }
    else
    {
        Console.WriteLine("Ingresa un número válido.");
    }
}
```

## 🔄 Bucle FOREACH

### Para recorrer colecciones

```csharp
// Array de nombres
string[] nombres = { "Ana", "Juan", "María", "Pedro" };

// Recorrer con foreach
foreach (string nombre in nombres)
{
    Console.WriteLine($"Hola {nombre}");
}

// Equivalente con for tradicional
for (int i = 0; i < nombres.Length; i++)
{
    Console.WriteLine($"Hola {nombres[i]}");
}
```

### Ejemplo con números

```csharp
int[] numeros = { 10, 25, 30, 45, 50 };
int suma = 0;

foreach (int numero in numeros)
{
    suma += numero;
    Console.WriteLine($"Sumando {numero}, total: {suma}");
}

Console.WriteLine($"Suma total: {suma}");
```

## 🎛️ Control de flujo: break y continue

### break - Salir del bucle

```csharp
// Buscar el primer número par
for (int i = 1; i <= 10; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine($"Primer número par encontrado: {i}");
        break; // Sale del bucle inmediatamente
    }
    Console.WriteLine($"Revisando {i}...");
}
```

### continue - Saltar a la siguiente iteración

```csharp
// Mostrar solo números impares
for (int i = 1; i <= 10; i++)
{
    if (i % 2 == 0)
    {
        continue; // Salta el resto del código y va a la siguiente iteración
    }
    Console.WriteLine($"Número impar: {i}");
}
```

## 🔄 Bucles anidados

### Ejemplo: Tabla de multiplicar completa

```csharp
Console.WriteLine("=== TABLAS DE MULTIPLICAR DEL 1 AL 5 ===\n");

for (int tabla = 1; tabla <= 5; tabla++)
{
    Console.WriteLine($"--- Tabla del {tabla} ---");
    
    for (int multiplicador = 1; multiplicador <= 10; multiplicador++)
    {
        int resultado = tabla * multiplicador;
        Console.WriteLine($"{tabla} × {multiplicador} = {resultado}");
    }
    
    Console.WriteLine(); // Línea en blanco
}
```

### Ejemplo: Patrón de asteriscos

```csharp
// Triángulo de asteriscos
int filas = 5;

for (int i = 1; i <= filas; i++)
{
    // Imprimir asteriscos para cada fila
    for (int j = 1; j <= i; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine(); // Nueva línea
}

// Resultado:
// *
// **
// ***
// ****
// *****
```

## 🎯 Ejemplo práctico completo

```csharp
// Programa: Análisis de calificaciones de estudiantes
Console.WriteLine("=== ANÁLISIS DE CALIFICACIONES ===\n");

// Solicitar número de estudiantes
Console.Write("¿Cuántos estudiantes hay? ");
int numeroEstudiantes = int.Parse(Console.ReadLine());

double sumaTotal = 0;
int aprobados = 0;
int reprobados = 0;
double notaMinima = 7.0; // Para aprobar

for (int i = 1; i <= numeroEstudiantes; i++)
{
    Console.Write($"Ingresa la nota del estudiante {i} (1-7): ");
    double nota = double.Parse(Console.ReadLine());
    
    // Validar nota
    while (nota < 1.0 || nota > 7.0)
    {
        Console.Write("Nota inválida. Ingresa una nota entre 1 y 7: ");
        nota = double.Parse(Console.ReadLine());
    }
    
    // Acumular estadísticas
    sumaTotal += nota;
    
    if (nota >= notaMinima)
    {
        aprobados++;
        Console.WriteLine($"  ✅ Estudiante {i}: APROBADO ({nota:F1})");
    }
    else
    {
        reprobados++;
        Console.WriteLine($"  ❌ Estudiante {i}: REPROBADO ({nota:F1})");
    }
}

// Calcular y mostrar estadísticas
double promedio = sumaTotal / numeroEstudiantes;
double porcentajeAprobados = (double)aprobados / numeroEstudiantes * 100;

Console.WriteLine("\n=== ESTADÍSTICAS FINALES ===");
Console.WriteLine($"Total de estudiantes: {numeroEstudiantes}");
Console.WriteLine($"Promedio general: {promedio:F2}");
Console.WriteLine($"Estudiantes aprobados: {aprobados} ({porcentajeAprobados:F1}%)");
Console.WriteLine($"Estudiantes reprobados: {reprobados}");

Console.ReadKey();
```

## ⚠️ Errores comunes y soluciones

### Error 1: Bucle infinito

```csharp
// ❌ Bucle infinito - nunca se actualiza i
int i = 0;
while (i < 5)
{
    Console.WriteLine(i);
    // Falta: i++;
}
```

**✅ Corrección:**
```csharp
int i = 0;
while (i < 5)
{
    Console.WriteLine(i);
    i++; // ✅ Actualizar la variable de control
}
```

### Error 2: Condición incorrecta en for

```csharp
// ❌ Error de límites
for (int i = 0; i <= 5; i++)  // Ejecuta 6 veces (0,1,2,3,4,5)
{
    Console.WriteLine(i);
}
```

**✅ Corrección:**
```csharp
for (int i = 0; i < 5; i++)   // ✅ Ejecuta 5 veces (0,1,2,3,4)
{
    Console.WriteLine(i);
}
```

### Error 3: Modificar variable de foreach

```csharp
int[] numeros = {1, 2, 3, 4, 5};

// ❌ No se puede modificar la variable de iteración
foreach (int numero in numeros)
{
    numero++; // Error de compilación
}
```

**✅ Corrección:**
```csharp
int[] numeros = {1, 2, 3, 4, 5};

// ✅ Usar for tradicional para modificar
for (int i = 0; i < numeros.Length; i++)
{
    numeros[i]++; // ✅ Correcto
}
```

## 🎮 Patrones útiles

### 1. **Acumulador**

```csharp
int suma = 0;
for (int i = 1; i <= 100; i++)
{
    suma += i;
}
Console.WriteLine($"Suma de 1 a 100: {suma}");
```

### 2. **Contador**

```csharp
int contador = 0;
for (int i = 1; i <= 100; i++)
{
    if (i % 2 == 0)
    {
        contador++;
    }
}
Console.WriteLine($"Números pares del 1 al 100: {contador}");
```

### 3. **Búsqueda**

```csharp
int[] numeros = {5, 12, 8, 21, 15};
int buscar = 21;
bool encontrado = false;

for (int i = 0; i < numeros.Length; i++)
{
    if (numeros[i] == buscar)
    {
        Console.WriteLine($"Número {buscar} encontrado en posición {i}");
        encontrado = true;
        break;
    }
}

if (!encontrado)
{
    Console.WriteLine($"Número {buscar} no encontrado");
}
```

## 🎯 Comparación final Python ↔ C#

| **Concepto** | **Python** | **C#** |
|--------------|------------|--------|
| **For básico** | `for i in range(5):` | `for (int i = 0; i < 5; i++)` |
| **For con inicio** | `for i in range(1, 6):` | `for (int i = 1; i <= 5; i++)` |
| **For con paso** | `for i in range(0, 10, 2):` | `for (int i = 0; i < 10; i += 2)` |
| **While** | `while condicion:` | `while (condicion)` |
| **For each** | `for item in lista:` | `foreach (var item in lista)` |
| **Break** | `break` | `break;` |
| **Continue** | `continue` | `continue;` |

## 📚 Siguiente paso

Ahora que dominas los bucles en C#, continúa con:
- **Ejercicios prácticos**: `ejercicios.md`
- **Siguiente módulo**: `05-arreglos-1d/teoria.md`

---
¡Has completado bucles for y while en C#! 🎉
