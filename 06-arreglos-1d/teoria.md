# Arreglos unidimensionales (Arrays 1D) en C#

## 🎯 Objetivos del módulo
- Entender **arreglos** como colecciones de elementos del mismo tipo
- Comparar **arrays C#** vs **listas Python**
- Manejar **índices**, **longitud** y **recorrido** de arreglos
- Aplicar operaciones comunes: **búsqueda**, **ordenamiento**, **filtrado**
- Desarrollar un **mini-proyecto** de inventario en consola

## 📚 Conceptos fundamentales

### ¿Qué es un arreglo?

Un **arreglo** es una colección de elementos del mismo tipo, almacenados en posiciones consecutivas de memoria.

**Python (lista)**:
```python
numeros = [10, 25, 30, 45, 50]
nombres = ["Ana", "Juan", "María"]
```

**C# (array)**:
```csharp
int[] numeros = {10, 25, 30, 45, 50};
string[] nombres = {"Ana", "Juan", "María"};
```

### Características de los arrays en C#

✅ **Ventajas**:
- **Tamaño fijo** (más eficiente en memoria)
- **Acceso rápido** por índice
- **Tipo específico** (más seguro)

❌ **Limitaciones**:
- **No se puede cambiar el tamaño** después de creado
- **Todos los elementos** deben ser del mismo tipo

## 📝 Declaración y creación de arrays

### 1. **Declaración con inicialización**

```csharp
// Declarar e inicializar en una línea
int[] edades = {25, 30, 18, 45, 22};
string[] ciudades = {"Santiago", "Valparaíso", "Concepción"};
double[] precios = {19.99, 45.50, 12.75};
bool[] activos = {true, false, true, true};
```

### 2. **Declaración con tamaño específico**

```csharp
// Crear array de tamaño 5, inicializado con valores por defecto
int[] numeros = new int[5];        // {0, 0, 0, 0, 0}
string[] nombres = new string[3];  // {null, null, null}
bool[] estados = new bool[4];      // {false, false, false, false}

// Asignar valores después
numeros[0] = 10;
numeros[1] = 25;
nombres[0] = "Ana";
```

### 3. **Declaración con new y valores**

```csharp
// Crear array con new e inicializar
int[] puntuaciones = new int[] {95, 87, 92, 78, 88};
string[] materias = new string[] {"Matemáticas", "Historia", "Ciencias"};
```

## 🔍 Acceso a elementos

### Índices (empiezan en 0)

```csharp
string[] frutas = {"Manzana", "Pera", "Naranja", "Uva"};

// Acceso de lectura
string primera = frutas[0];        // "Manzana"
string ultima = frutas[3];         // "Uva"

// Acceso de escritura
frutas[1] = "Plátano";            // Cambiar "Pera" por "Plátano"

// Propiedad Length
int cantidad = frutas.Length;      // 4
```

### Equivalencias Python ↔ C#

| **Operación** | **Python** | **C#** |
|---------------|------------|--------|
| **Crear lista/array** | `numeros = [1, 2, 3]` | `int[] numeros = {1, 2, 3};` |
| **Acceder elemento** | `numeros[0]` | `numeros[0]` |
| **Longitud** | `len(numeros)` | `numeros.Length` |
| **Último elemento** | `numeros[-1]` | `numeros[numeros.Length - 1]` |
| **Cambiar elemento** | `numeros[0] = 5` | `numeros[0] = 5;` |

## 🔄 Recorrido de arrays

### 1. **Bucle for tradicional**

```csharp
int[] calificaciones = {85, 92, 78, 96, 88};

// Recorrer con índices
for (int i = 0; i < calificaciones.Length; i++)
{
    Console.WriteLine($"Calificación {i + 1}: {calificaciones[i]}");
}
```

### 2. **Bucle foreach (recomendado para lectura)**

```csharp
string[] estudiantes = {"Ana", "Juan", "María", "Pedro"};

// Recorrer elementos directamente
foreach (string estudiante in estudiantes)
{
    Console.WriteLine($"Estudiante: {estudiante}");
}
```

### 3. **Comparación Python ↔ C#**

**Python**:
```python
numeros = [10, 20, 30, 40, 50]

# Recorrer elementos
for numero in numeros:
    print(numero)

# Recorrer con índices
for i in range(len(numeros)):
    print(f"Posición {i}: {numeros[i]}")
```

**C# equivalente**:
```csharp
int[] numeros = {10, 20, 30, 40, 50};

// Recorrer elementos
foreach (int numero in numeros)
{
    Console.WriteLine(numero);
}

// Recorrer con índices
for (int i = 0; i < numeros.Length; i++)
{
    Console.WriteLine($"Posición {i}: {numeros[i]}");
}
```

## 🔧 Operaciones comunes con arrays

### 1. **Buscar elementos**

```csharp
string[] productos = {"Laptop", "Mouse", "Teclado", "Monitor"};
string buscar = "Teclado";

// Buscar si existe
bool encontrado = false;
int posicion = -1;

for (int i = 0; i < productos.Length; i++)
{
    if (productos[i] == buscar)
    {
        encontrado = true;
        posicion = i;
        break;
    }
}

if (encontrado)
{
    Console.WriteLine($"{buscar} encontrado en posición {posicion}");
}
else
{
    Console.WriteLine($"{buscar} no encontrado");
}
```

### 2. **Encontrar el mayor/menor**

```csharp
int[] temperaturas = {22, 18, 25, 30, 19, 27};

int mayor = temperaturas[0];
int menor = temperaturas[0];

foreach (int temperatura in temperaturas)
{
    if (temperatura > mayor)
        mayor = temperatura;
    
    if (temperatura < menor)
        menor = temperatura;
}

Console.WriteLine($"Temperatura mayor: {mayor}°C");
Console.WriteLine($"Temperatura menor: {menor}°C");
```

### 3. **Calcular suma y promedio**

```csharp
double[] notas = {6.5, 7.2, 5.8, 8.1, 7.0};

double suma = 0;
foreach (double nota in notas)
{
    suma += nota;
}

double promedio = suma / notas.Length;

Console.WriteLine($"Suma total: {suma:F2}");
Console.WriteLine($"Promedio: {promedio:F2}");
```

### 4. **Contar elementos que cumplen condición**

```csharp
int[] edades = {17, 22, 16, 25, 19, 30, 15};
int mayoresDeEdad = 0;

foreach (int edad in edades)
{
    if (edad >= 18)
    {
        mayoresDeEdad++;
    }
}

Console.WriteLine($"Mayores de edad: {mayoresDeEdad} de {edades.Length}");
```

## 📊 Arrays con datos relacionados (paralelos)

### Gestión de inventario básica

```csharp
// Arrays paralelos para gestionar inventario
string[] productos = {"Laptop", "Mouse", "Teclado", "Monitor"};
int[] stock = {5, 15, 8, 3};
double[] precios = {850000, 25000, 45000, 320000};

// Mostrar inventario completo
Console.WriteLine("=== INVENTARIO ACTUAL ===");
for (int i = 0; i < productos.Length; i++)
{
    Console.WriteLine($"{i + 1}. {productos[i]}");
    Console.WriteLine($"   Stock: {stock[i]} unidades");
    Console.WriteLine($"   Precio: {precios[i]:C}");
    Console.WriteLine($"   Valor total: {(stock[i] * precios[i]):C}");
    Console.WriteLine();
}

// Calcular valor total del inventario
double valorTotal = 0;
for (int i = 0; i < productos.Length; i++)
{
    valorTotal += stock[i] * precios[i];
}

Console.WriteLine($"Valor total del inventario: {valorTotal:C}");
```

## 🔄 Métodos útiles de Array

### 1. **Array.Sort() - Ordenar**

```csharp
int[] numeros = {45, 12, 78, 23, 56};

// Mostrar original
Console.WriteLine("Original: " + string.Join(", ", numeros));

// Ordenar
Array.Sort(numeros);

// Mostrar ordenado
Console.WriteLine("Ordenado: " + string.Join(", ", numeros));
// Resultado: 12, 23, 45, 56, 78
```

### 2. **Array.Reverse() - Invertir**

```csharp
string[] nombres = {"Ana", "Juan", "María", "Pedro"};

Console.WriteLine("Original: " + string.Join(", ", nombres));

Array.Reverse(nombres);

Console.WriteLine("Invertido: " + string.Join(", ", nombres));
// Resultado: Pedro, María, Juan, Ana
```

### 3. **Array.IndexOf() - Buscar posición**

```csharp
string[] colores = {"Rojo", "Verde", "Azul", "Amarillo"};
string buscar = "Azul";

int posicion = Array.IndexOf(colores, buscar);

if (posicion != -1)
{
    Console.WriteLine($"{buscar} está en posición {posicion}");
}
else
{
    Console.WriteLine($"{buscar} no encontrado");
}
```

## 🎯 Ejemplo práctico completo: Sistema de calificaciones

```csharp
// Sistema de gestión de calificaciones
Console.WriteLine("=== SISTEMA DE CALIFICACIONES ===\n");

// Solicitar número de estudiantes
Console.Write("¿Cuántos estudiantes hay? ");
int numEstudiantes = int.Parse(Console.ReadLine());

// Crear arrays
string[] nombres = new string[numEstudiantes];
double[] promedios = new double[numEstudiantes];

// Recolectar datos
for (int i = 0; i < numEstudiantes; i++)
{
    Console.Write($"Nombre del estudiante {i + 1}: ");
    nombres[i] = Console.ReadLine();
    
    Console.Write($"Promedio de {nombres[i]}: ");
    promedios[i] = double.Parse(Console.ReadLine());
}

// Análisis de datos
double sumaTotal = 0;
double mayorPromedio = promedios[0];
double menorPromedio = promedios[0];
string mejorEstudiante = nombres[0];
string peorEstudiante = nombres[0];
int aprobados = 0;

for (int i = 0; i < numEstudiantes; i++)
{
    sumaTotal += promedios[i];
    
    if (promedios[i] > mayorPromedio)
    {
        mayorPromedio = promedios[i];
        mejorEstudiante = nombres[i];
    }
    
    if (promedios[i] < menorPromedio)
    {
        menorPromedio = promedios[i];
        peorEstudiante = nombres[i];
    }
    
    if (promedios[i] >= 4.0)
    {
        aprobados++;
    }
}

double promedioGeneral = sumaTotal / numEstudiantes;
double porcentajeAprobados = (double)aprobados / numEstudiantes * 100;

// Mostrar reporte
Console.WriteLine("\n=== REPORTE FINAL ===");
Console.WriteLine($"Total de estudiantes: {numEstudiantes}");
Console.WriteLine($"Promedio general: {promedioGeneral:F2}");
Console.WriteLine($"Estudiantes aprobados: {aprobados} ({porcentajeAprobados:F1}%)");
Console.WriteLine($"Mejor estudiante: {mejorEstudiante} ({mayorPromedio:F2})");
Console.WriteLine($"Estudiante con menor promedio: {peorEstudiante} ({menorPromedio:F2})");

Console.WriteLine("\n=== LISTADO COMPLETO ===");
for (int i = 0; i < numEstudiantes; i++)
{
    string estado = promedios[i] >= 4.0 ? "APROBADO" : "REPROBADO";
    Console.WriteLine($"{nombres[i]}: {promedios[i]:F2} - {estado}");
}

Console.ReadKey();
```

## ⚠️ Errores comunes y soluciones

### Error 1: Índice fuera de rango

```csharp
int[] numeros = {1, 2, 3, 4, 5};

// ❌ Error: índice 5 no existe (máximo es 4)
// int ultimo = numeros[5];

// ✅ Correcto: usar Length - 1
int ultimo = numeros[numeros.Length - 1];
```

### Error 2: No inicializar array antes de usar

```csharp
// ❌ Error: array declarado pero no inicializado
int[] numeros;
// numeros[0] = 5; // Error: variable no inicializada

// ✅ Correcto: inicializar primero
int[] numeros = new int[5];
numeros[0] = 5;
```

### Error 3: Intentar cambiar tamaño del array

```csharp
int[] numeros = {1, 2, 3};

// ❌ No se puede cambiar el tamaño
// numeros[3] = 4; // Error: índice fuera de rango

// ✅ Alternativas:
// 1. Crear array más grande desde el inicio
int[] numerosMasGrandes = new int[5];

// 2. Usar List<T> en lugar de array (módulo siguiente)
```

## 🎮 Patrones útiles con arrays

### 1. **Inicializar array con valores específicos**

```csharp
// Llenar array con un valor específico
int[] ceros = new int[10]; // Ya son ceros por defecto

// Llenar con otro valor
int[] doses = new int[5];
for (int i = 0; i < doses.Length; i++)
{
    doses[i] = 2;
}
```

### 2. **Copiar arrays**

```csharp
int[] original = {1, 2, 3, 4, 5};
int[] copia = new int[original.Length];

// Copiar elemento por elemento
for (int i = 0; i < original.Length; i++)
{
    copia[i] = original[i];
}

// O usar Array.Copy
Array.Copy(original, copia, original.Length);
```

### 3. **Filtrar elementos**

```csharp
int[] numeros = {1, 15, 8, 23, 4, 16, 7, 30};

// Contar pares
int contadorPares = 0;
foreach (int numero in numeros)
{
    if (numero % 2 == 0)
        contadorPares++;
}

// Crear array solo con pares
int[] pares = new int[contadorPares];
int indicePares = 0;

foreach (int numero in numeros)
{
    if (numero % 2 == 0)
    {
        pares[indicePares] = numero;
        indicePares++;
    }
}
```

## 📚 Próximo paso: Mini-proyecto

Ahora que dominas arrays unidimensionales, es momento de aplicar todo en un proyecto real:

🎯 **Mini-proyecto**: `miniproyecto-inventario-console.md`

## 📚 Resumen de equivalencias Python ↔ C#

| **Concepto** | **Python** | **C#** |
|--------------|------------|--------|
| **Crear lista/array** | `lista = [1, 2, 3]` | `int[] array = {1, 2, 3};` |
| **Tamaño** | `len(lista)` | `array.Length` |
| **Acceder** | `lista[0]` | `array[0]` |
| **Último elemento** | `lista[-1]` | `array[array.Length - 1]` |
| **Recorrer elementos** | `for item in lista:` | `foreach (int item in array)` |
| **Recorrer con índice** | `for i in range(len(lista)):` | `for (int i = 0; i < array.Length; i++)` |
| **Buscar elemento** | `if item in lista:` | `Array.IndexOf(array, item) != -1` |
| **Ordenar** | `lista.sort()` | `Array.Sort(array);` |

---

## 🚀 Siguiente paso

✅ **Ejercicios**: `ejercicios.md`
✅ **Mini-proyecto**: `miniproyecto-inventario-console.md`
✅ **Siguiente módulo**: `06-matrices-2d/teoria.md`

¡Has completado arrays unidimensionales en C#! 🎉
