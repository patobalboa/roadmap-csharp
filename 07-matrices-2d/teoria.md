# Matrices bidimensionales (Arrays 2D) en C#

## 🎯 Objetivos del módulo
- Entender **matrices 2D** como tablas de datos
- Comparar **matrices C#** vs **listas de listas Python**
- Manejar **filas**, **columnas** e **índices** bidimensionales
- Aplicar operaciones: **suma**, **promedios**, **búsqueda** en matrices
- Desarrollar un **mini-proyecto** de gestión de notas

## 📚 Conceptos fundamentales

### ¿Qué es una matriz 2D?

Una **matriz bidimensional** es una estructura que organiza datos en **filas** y **columnas**, como una tabla o una hoja de cálculo.

**Python (lista de listas)**:
```python
# Matriz 3x3
matriz = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
]
```

**C# (array 2D)**:
```csharp
// Matriz 3x3
int[,] matriz = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};
```

### Representación visual

```
    Col0  Col1  Col2
Fila0  1     2     3
Fila1  4     5     6
Fila2  7     8     9
```

## 📝 Declaración y creación de matrices

### 1. **Declaración con inicialización**

```csharp
// Matriz de enteros 2x3
int[,] numeros = {
    {10, 20, 30},
    {40, 50, 60}
};

// Matriz de strings 3x2
string[,] nombres = {
    {"Ana", "Juan"},
    {"María", "Pedro"},
    {"Luis", "Carmen"}
};

// Matriz de notas (estudiantes x materias)
double[,] notas = {
    {6.5, 7.2, 5.8},  // Estudiante 1
    {7.0, 6.8, 7.5},  // Estudiante 2
    {5.5, 6.0, 6.2}   // Estudiante 3
};
```

### 2. **Declaración con tamaño específico**

```csharp
// Crear matriz 4x5 inicializada con valores por defecto
int[,] tabla = new int[4, 5];  // Todos los valores son 0

// Crear matriz de strings 3x4
string[,] empleados = new string[3, 4];  // Todos los valores son null

// Asignar valores después
tabla[0, 0] = 100;
tabla[1, 2] = 250;
empleados[0, 0] = "Ana García";
```

### 3. **Propiedades útiles**

```csharp
int[,] matriz = {
    {1, 2, 3, 4},
    {5, 6, 7, 8},
    {9, 10, 11, 12}
};

// Obtener dimensiones
int filas = matriz.GetLength(0);        // 3 filas
int columnas = matriz.GetLength(1);     // 4 columnas
int totalElementos = matriz.Length;     // 12 elementos totales

Console.WriteLine($"Matriz {filas}x{columnas} con {totalElementos} elementos");
```

## 🔍 Acceso a elementos

### Índices bidimensionales [fila, columna]

```csharp
double[,] notas = {
    {6.5, 7.2, 5.8},  // Fila 0: Estudiante 1
    {7.0, 6.8, 7.5},  // Fila 1: Estudiante 2
    {5.5, 6.0, 6.2}   // Fila 2: Estudiante 3
};

// Acceso de lectura
double nota = notas[1, 2];  // Nota del estudiante 2 en materia 3 = 7.5

// Acceso de escritura
notas[0, 1] = 8.0;  // Cambiar nota del estudiante 1 en materia 2

// Obtener dimensiones
int estudiantes = notas.GetLength(0);  // 3 estudiantes
int materias = notas.GetLength(1);     // 3 materias
```

### Equivalencias Python ↔ C#

| **Operación** | **Python** | **C#** |
|---------------|------------|--------|
| **Crear matriz** | `matriz = [[1,2], [3,4]]` | `int[,] matriz = {{1,2}, {3,4}};` |
| **Acceder elemento** | `matriz[0][1]` | `matriz[0, 1]` |
| **Número de filas** | `len(matriz)` | `matriz.GetLength(0)` |
| **Número de columnas** | `len(matriz[0])` | `matriz.GetLength(1)` |
| **Cambiar elemento** | `matriz[0][1] = 5` | `matriz[0, 1] = 5;` |

## 🔄 Recorrido de matrices

### 1. **Bucles anidados - Recorrido completo**

```csharp
int[,] tabla = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};

// Recorrer fila por fila
Console.WriteLine("Recorrido por filas:");
for (int fila = 0; fila < tabla.GetLength(0); fila++)
{
    for (int columna = 0; columna < tabla.GetLength(1); columna++)
    {
        Console.Write($"{tabla[fila, columna],4}");
    }
    Console.WriteLine(); // Nueva línea al final de cada fila
}

// Salida:
//    1   2   3
//    4   5   6
//    7   8   9
```

### 2. **Recorrer por columnas**

```csharp
Console.WriteLine("Recorrido por columnas:");
for (int columna = 0; columna < tabla.GetLength(1); columna++)
{
    for (int fila = 0; fila < tabla.GetLength(0); fila++)
    {
        Console.Write($"{tabla[fila, columna],4}");
    }
    Console.WriteLine();
}

// Salida:
//    1   4   7
//    2   5   8
//    3   6   9
```

### 3. **Comparación Python ↔ C#**

**Python**:
```python
matriz = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
]

# Recorrer por filas
for fila in matriz:
    for elemento in fila:
        print(elemento, end=" ")
    print()

# Recorrer con índices
for i in range(len(matriz)):
    for j in range(len(matriz[i])):
        print(matriz[i][j], end=" ")
    print()
```

**C# equivalente**:
```csharp
int[,] matriz = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};

// Recorrer con bucles anidados
for (int i = 0; i < matriz.GetLength(0); i++)
{
    for (int j = 0; j < matriz.GetLength(1); j++)
    {
        Console.Write(matriz[i, j] + " ");
    }
    Console.WriteLine();
}
```

## 🔧 Operaciones comunes con matrices

### 1. **Calcular suma total**

```csharp
int[,] ventas = {
    {1200, 1500, 1800},  // Enero, Febrero, Marzo
    {1400, 1600, 2000},  // Vendedor 1, 2, 3
    {1100, 1300, 1700}
};

int sumaTotal = 0;
for (int fila = 0; fila < ventas.GetLength(0); fila++)
{
    for (int columna = 0; columna < ventas.GetLength(1); columna++)
    {
        sumaTotal += ventas[fila, columna];
    }
}

Console.WriteLine($"Ventas totales: ${sumaTotal:N0}");
```

### 2. **Calcular promedios por fila**

```csharp
double[,] notas = {
    {6.5, 7.2, 5.8, 6.9},  // Estudiante 1
    {7.0, 6.8, 7.5, 7.2},  // Estudiante 2
    {5.5, 6.0, 6.2, 5.8}   // Estudiante 3
};

Console.WriteLine("Promedios por estudiante:");
for (int estudiante = 0; estudiante < notas.GetLength(0); estudiante++)
{
    double suma = 0;
    for (int materia = 0; materia < notas.GetLength(1); materia++)
    {
        suma += notas[estudiante, materia];
    }
    
    double promedio = suma / notas.GetLength(1);
    Console.WriteLine($"Estudiante {estudiante + 1}: {promedio:F2}");
}
```

### 3. **Calcular promedios por columna**

```csharp
Console.WriteLine("Promedios por materia:");
for (int materia = 0; materia < notas.GetLength(1); materia++)
{
    double suma = 0;
    for (int estudiante = 0; estudiante < notas.GetLength(0); estudiante++)
    {
        suma += notas[estudiante, materia];
    }
    
    double promedio = suma / notas.GetLength(0);
    Console.WriteLine($"Materia {materia + 1}: {promedio:F2}");
}
```

### 4. **Encontrar el mayor/menor elemento**

```csharp
int[,] temperaturas = {
    {22, 25, 28, 24},  // Semana 1
    {20, 23, 26, 22},  // Semana 2
    {24, 27, 30, 26}   // Semana 3
};

int mayor = temperaturas[0, 0];
int menor = temperaturas[0, 0];
int filaMayor = 0, columnaMayor = 0;
int filaMenor = 0, columnaMenor = 0;

for (int i = 0; i < temperaturas.GetLength(0); i++)
{
    for (int j = 0; j < temperaturas.GetLength(1); j++)
    {
        if (temperaturas[i, j] > mayor)
        {
            mayor = temperaturas[i, j];
            filaMayor = i;
            columnaMayor = j;
        }
        
        if (temperaturas[i, j] < menor)
        {
            menor = temperaturas[i, j];
            filaMenor = i;
            columnaMenor = j;
        }
    }
}

Console.WriteLine($"Temperatura mayor: {mayor}°C en posición [{filaMayor},{columnaMayor}]");
Console.WriteLine($"Temperatura menor: {menor}°C en posición [{filaMenor},{columnaMenor}]");
```

## 📊 Ejemplo práctico: Sistema de notas

```csharp
// Sistema de gestión de notas por materias
Console.WriteLine("=== SISTEMA DE GESTIÓN DE NOTAS ===\n");

// Definir estructura
string[] estudiantes = {"Ana García", "Juan Pérez", "María López", "Pedro Silva"};
string[] materias = {"Matemáticas", "Historia", "Ciencias", "Inglés"};
double[,] notas = new double[estudiantes.Length, materias.Length];

// Llenar matriz con notas
Random random = new Random();
for (int i = 0; i < estudiantes.Length; i++)
{
    for (int j = 0; j < materias.Length; j++)
    {
        notas[i, j] = Math.Round(random.NextDouble() * 3 + 4, 1); // Notas entre 4.0 y 7.0
    }
}

// Mostrar tabla de notas
Console.WriteLine("TABLA DE NOTAS:");
Console.WriteLine("┌─────────────────┬─────────────┬─────────┬─────────┬─────────┬─────────┐");
Console.WriteLine("│ ESTUDIANTE      │ MATEMÁTICAS │ HISTORIA│ CIENCIAS│ INGLÉS  │ PROMEDIO│");
Console.WriteLine("├─────────────────┼─────────────┼─────────┼─────────┼─────────┼─────────┤");

for (int i = 0; i < estudiantes.Length; i++)
{
    Console.Write($"│ {estudiantes[i],-15} │");
    
    double sumaEstudiante = 0;
    for (int j = 0; j < materias.Length; j++)
    {
        Console.Write($"    {notas[i, j],4:F1} │");
        sumaEstudiante += notas[i, j];
    }
    
    double promedioEstudiante = sumaEstudiante / materias.Length;
    Console.WriteLine($"   {promedioEstudiante,4:F1} │");
}

Console.WriteLine("└─────────────────┴─────────────┴─────────┴─────────┴─────────┴─────────┘");

// Calcular promedios por materia
Console.WriteLine("\nPROMEDIOS POR MATERIA:");
for (int j = 0; j < materias.Length; j++)
{
    double sumaMateria = 0;
    for (int i = 0; i < estudiantes.Length; i++)
    {
        sumaMateria += notas[i, j];
    }
    
    double promedioMateria = sumaMateria / estudiantes.Length;
    Console.WriteLine($"{materias[j]}: {promedioMateria:F2}");
}

// Encontrar mejor y peor estudiante
double mejorPromedio = 0;
double peorPromedio = 7;
int indiceMejor = 0, indicePeor = 0;

for (int i = 0; i < estudiantes.Length; i++)
{
    double suma = 0;
    for (int j = 0; j < materias.Length; j++)
    {
        suma += notas[i, j];
    }
    
    double promedio = suma / materias.Length;
    
    if (promedio > mejorPromedio)
    {
        mejorPromedio = promedio;
        indiceMejor = i;
    }
    
    if (promedio < peorPromedio)
    {
        peorPromedio = promedio;
        indicePeor = i;
    }
}

Console.WriteLine("\nESTADÍSTICAS:");
Console.WriteLine($"Mejor estudiante: {estudiantes[indiceMejor]} ({mejorPromedio:F2})");
Console.WriteLine($"Estudiante con menor promedio: {estudiantes[indicePeor]} ({peorPromedio:F2})");

Console.ReadKey();
```

## 🎯 Matrices especiales

### 1. **Matriz identidad**

```csharp
// Crear matriz identidad 4x4
int tamaño = 4;
int[,] identidad = new int[tamaño, tamaño];

for (int i = 0; i < tamaño; i++)
{
    for (int j = 0; j < tamaño; j++)
    {
        identidad[i, j] = (i == j) ? 1 : 0;
    }
}

// Resultado:
// 1 0 0 0
// 0 1 0 0
// 0 0 1 0
// 0 0 0 1
```

### 2. **Matriz triangular superior**

```csharp
int[,] triangular = new int[4, 4];

for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        if (j >= i)
        {
            triangular[i, j] = i + j + 1;
        }
        else
        {
            triangular[i, j] = 0;
        }
    }
}

// Resultado:
// 1 2 3 4
// 0 3 4 5
// 0 0 5 6
// 0 0 0 7
```

### 3. **Matriz simétrica**

```csharp
// Crear matriz simétrica (matriz[i,j] = matriz[j,i])
int[,] simetrica = new int[3, 3];

// Llenar solo la mitad superior
for (int i = 0; i < 3; i++)
{
    for (int j = i; j < 3; j++)
    {
        int valor = (i + 1) * (j + 1);
        simetrica[i, j] = valor;
        simetrica[j, i] = valor;  // Simetría
    }
}

// Resultado:
// 1 2 3
// 2 4 6
// 3 6 9
```

## ⚠️ Errores comunes y soluciones

### Error 1: Confundir orden de índices

```csharp
int[,] matriz = new int[3, 4];  // 3 filas, 4 columnas

// ❌ Error: confundir filas y columnas
// int elemento = matriz[4, 3];  // Error: índice fuera de rango

// ✅ Correcto: recordar [fila, columna]
int elemento = matriz[2, 3];     // Última fila, última columna
```

### Error 2: Usar mal GetLength()

```csharp
int[,] matriz = new int[3, 4];

// ❌ Error: usar Length en lugar de GetLength
// for (int i = 0; i < matriz.Length; i++)  // Length = 12 (total elementos)

// ✅ Correcto: usar GetLength para dimensiones
for (int i = 0; i < matriz.GetLength(0); i++)      // Filas
{
    for (int j = 0; j < matriz.GetLength(1); j++)  // Columnas
    {
        // Procesar matriz[i, j]
    }
}
```

### Error 3: Inicialización incorrecta

```csharp
// ❌ Error: syntax incorrecta
// int[,] matriz = {{1, 2}, {3, 4}, {5}};  // Filas de diferentes tamaños

// ✅ Correcto: todas las filas deben tener el mismo número de columnas
int[,] matriz = {
    {1, 2, 0},
    {3, 4, 0},
    {5, 6, 0}
};
```

## 🎮 Algoritmos útiles con matrices

### 1. **Transposición de matriz**

```csharp
static int[,] Transponer(int[,] original)
{
    int filas = original.GetLength(0);
    int columnas = original.GetLength(1);
    int[,] transpuesta = new int[columnas, filas];
    
    for (int i = 0; i < filas; i++)
    {
        for (int j = 0; j < columnas; j++)
        {
            transpuesta[j, i] = original[i, j];
        }
    }
    
    return transpuesta;
}
```

### 2. **Suma de matrices**

```csharp
static int[,] SumarMatrices(int[,] a, int[,] b)
{
    int filas = a.GetLength(0);
    int columnas = a.GetLength(1);
    
    // Verificar que tengan las mismas dimensiones
    if (filas != b.GetLength(0) || columnas != b.GetLength(1))
    {
        throw new ArgumentException("Las matrices deben tener las mismas dimensiones");
    }
    
    int[,] resultado = new int[filas, columnas];
    
    for (int i = 0; i < filas; i++)
    {
        for (int j = 0; j < columnas; j++)
        {
            resultado[i, j] = a[i, j] + b[i, j];
        }
    }
    
    return resultado;
}
```

### 3. **Buscar elemento en matriz**

```csharp
static bool BuscarElemento(int[,] matriz, int valor, out int fila, out int columna)
{
    for (int i = 0; i < matriz.GetLength(0); i++)
    {
        for (int j = 0; j < matriz.GetLength(1); j++)
        {
            if (matriz[i, j] == valor)
            {
                fila = i;
                columna = j;
                return true;
            }
        }
    }
    
    fila = -1;
    columna = -1;
    return false;
}
```

## 📚 Próximo paso: Mini-proyecto

Ahora aplicarás todo lo aprendido en un proyecto completo:

🎯 **Mini-proyecto**: `miniproyecto-notas-matriz-console.md`

## 📚 Resumen de equivalencias Python ↔ C#

| **Concepto** | **Python** | **C#** |
|--------------|------------|--------|
| **Crear matriz** | `matriz = [[1,2], [3,4]]` | `int[,] matriz = {{1,2}, {3,4}};` |
| **Acceder elemento** | `matriz[i][j]` | `matriz[i, j]` |
| **Número de filas** | `len(matriz)` | `matriz.GetLength(0)` |
| **Número de columnas** | `len(matriz[0])` | `matriz.GetLength(1)` |
| **Recorrer filas** | `for fila in matriz:` | `for (int i = 0; i < matriz.GetLength(0); i++)` |
| **Recorrer elementos** | `for elem in fila:` | `for (int j = 0; j < matriz.GetLength(1); j++)` |

---

## 🚀 Siguiente paso

✅ **Ejercicios**: `ejercicios.md`
✅ **Mini-proyecto**: `miniproyecto-notas-matriz-console.md`
✅ **Evaluación**: `99-evaluacion/`

¡Has completado matrices bidimensionales en C#! 🎉
