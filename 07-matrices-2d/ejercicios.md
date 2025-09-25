# Ejercicios - Matrices bidimensionales (Arrays 2D)

## 🎯 Objetivos de práctica
- Aplicar **creación** y **inicialización** de matrices 2D
- Practicar **recorrido** de matrices con bucles anidados
- Implementar **operaciones** matemáticas con matrices
- Desarrollar **algoritmos de búsqueda** y **estadísticas**
- Crear **interfaces de usuario** para visualizar matrices

---

## 📝 Ejercicio 1: Calculadora de matriz básica
**Dificultad**: ⭐⭐☆☆☆ | **Tiempo estimado**: 20 minutos

### Descripción
Crea un programa que permita al usuario ingresar los elementos de una matriz 3x3 y calcule la suma total de todos sus elementos.

### Requisitos funcionales
1. **Solicitar** al usuario los 9 elementos de la matriz
2. **Mostrar** la matriz en formato tabular
3. **Calcular** y mostrar la suma total de elementos
4. **Mostrar** el elemento mayor y menor
5. **Validar** que las entradas sean números válidos

### Interfaz esperada
```
=== CALCULADORA DE MATRIZ 3x3 ===

Ingrese los elementos de la matriz:
Elemento [0,0]: 5
Elemento [0,1]: 2
Elemento [0,2]: 8
Elemento [1,0]: 3
Elemento [1,1]: 7
Elemento [1,2]: 1
Elemento [2,0]: 9
Elemento [2,1]: 4
Elemento [2,2]: 6

MATRIZ INGRESADA:
┌─────┬─────┬─────┐
│  5  │  2  │  8  │
├─────┼─────┼─────┤
│  3  │  7  │  1  │
├─────┼─────┼─────┤
│  9  │  4  │  6  │
└─────┴─────┴─────┘

RESULTADOS:
- Suma total: 45
- Elemento mayor: 9 (posición [2,0])
- Elemento menor: 1 (posición [1,2])

Presione cualquier tecla para continuar...
```

### Puntos clave a implementar
- Usar `int[,]` para la matriz
- Implementar bucles anidados para recorrido
- Formatear la salida con caracteres de tabla
- Manejar entrada inválida con `int.TryParse()`

---

## 📝 Ejercicio 2: Sistema de temperaturas por ciudades
**Dificultad**: ⭐⭐⭐☆☆ | **Tiempo estimado**: 35 minutos

### Descripción
Desarrolla un sistema que gestione temperaturas de 4 ciudades durante 7 días de la semana. El programa debe calcular estadísticas y generar reportes.

### Requisitos funcionales
1. **Crear matriz** 4x7 (ciudades x días)
2. **Llenar automáticamente** con temperaturas aleatorias entre 15°C y 35°C
3. **Mostrar tabla** de temperaturas organizadas por ciudad/día
4. **Calcular** temperatura promedio por ciudad
5. **Calcular** temperatura promedio por día de la semana
6. **Encontrar** el día más caluroso y más frío
7. **Mostrar** alertas de temperaturas extremas (>30°C o <18°C)

### Estructura de datos
```csharp
string[] ciudades = {"Santiago", "Valparaíso", "Concepción", "La Serena"};
string[] dias = {"Lun", "Mar", "Mié", "Jue", "Vie", "Sáb", "Dom"};
double[,] temperaturas = new double[4, 7];
```

### Interfaz esperada
```
=== SISTEMA DE TEMPERATURAS REGIONALES ===

TABLA DE TEMPERATURAS (°C):
┌─────────────┬─────┬─────┬─────┬─────┬─────┬─────┬─────┬─────────┐
│ CIUDAD      │ Lun │ Mar │ Mié │ Jue │ Vie │ Sáb │ Dom │ PROMEDIO│
├─────────────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────────┤
│ Santiago    │ 23.5│ 26.2│ 19.8│ 31.2│ 28.4│ 25.1│ 27.3│  25.9   │
│ Valparaíso  │ 19.2│ 21.5│ 18.7│ 24.8│ 22.3│ 20.9│ 23.1│  21.5   │
│ Concepción  │ 17.8│ 20.1│ 16.5│ 22.4│ 19.7│ 18.3│ 21.0│  19.4   │
│ La Serena   │ 25.1│ 28.3│ 24.6│ 32.1│ 29.8│ 26.7│ 30.2│  28.1   │
├─────────────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────────┤
│ PROMEDIO    │ 21.4│ 24.0│ 19.9│ 27.6│ 25.1│ 22.8│ 25.4│  23.7   │
└─────────────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────────┘

ESTADÍSTICAS:
- Temperatura más alta: 32.1°C (La Serena, Jueves)
- Temperatura más baja: 16.5°C (Concepción, Miércoles)
- Día más caluroso en promedio: Jueves (27.6°C)
- Día más frío en promedio: Miércoles (19.9°C)

ALERTAS DE TEMPERATURAS EXTREMAS:
🔥 ALTAS (>30°C):
   - Santiago, Jueves: 31.2°C
   - La Serena, Jueves: 32.1°C
   - La Serena, Domingo: 30.2°C

❄️  BAJAS (<18°C):
   - Concepción, Miércoles: 16.5°C
   - Santiago, Miércoles: 19.8°C (límite)

Presione cualquier tecla para continuar...
```

### Puntos clave a implementar
- Usar `Random` para generar temperaturas
- Implementar formateo avanzado de tablas
- Crear métodos para cálculos estadísticos
- Detectar temperaturas extremas con lógica condicional

---

## 📝 Ejercicio 3: Juego de búsqueda del tesoro
**Dificultad**: ⭐⭐⭐☆☆ | **Tiempo estimado**: 40 minutos

### Descripción
Crea un juego donde el jugador debe encontrar un tesoro oculto en una matriz 5x5. El juego debe mostrar pistas sobre qué tan cerca está el jugador del tesoro.

### Requisitos funcionales
1. **Crear tablero** 5x5 con tesoro oculto en posición aleatoria
2. **Mostrar tablero** con posiciones exploradas y no exploradas
3. **Permitir** al jugador elegir coordenadas
4. **Calcular distancia** al tesoro (distancia Manhattan)
5. **Dar pistas**: "Muy lejos", "Lejos", "Cerca", "Muy cerca", "¡Tesoro!"
6. **Contar intentos** y mostrar puntuación final
7. **Validar** coordenadas dentro del rango

### Estructura del juego
```csharp
char[,] tablero = new char[5, 5];  // '.' = no explorado, 'X' = explorado, 'T' = tesoro
int tesoroFila, tesoroColumna;
int intentos = 0;
bool encontrado = false;
```

### Interfaz esperada
```
=== BÚSQUEDA DEL TESORO ===

¡Encuentra el tesoro oculto en el tablero 5x5!
Usa coordenadas (fila, columna) desde 0 hasta 4.

    0   1   2   3   4
  ┌───┬───┬───┬───┬───┐
0 │ . │ . │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
1 │ . │ . │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
2 │ . │ . │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
3 │ . │ . │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
4 │ . │ . │ . │ . │ . │
  └───┴───┴───┴───┴───┘

Intento #1
Ingrese fila (0-4): 2
Ingrese columna (0-4): 1

    0   1   2   3   4
  ┌───┬───┬───┬───┬───┐
0 │ . │ . │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
1 │ . │ . │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
2 │ . │ X │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
3 │ . │ . │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
4 │ . │ . │ . │ . │ . │
  └───┴───┴───┴───┴───┘

🔍 Pista: ¡CERCA! (distancia: 2)

Intento #2
Ingrese fila (0-4): 3
Ingrese columna (0-4): 2

    0   1   2   3   4
  ┌───┬───┬───┬───┬───┐
0 │ . │ . │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
1 │ . │ . │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
2 │ . │ X │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
3 │ . │ . │ X │ . │ . │
  ├───┼───┼───┼───┼───┤
4 │ . │ . │ . │ . │ . │
  └───┴───┴───┴───┴───┘

🔍 Pista: ¡MUY CERCA! (distancia: 1)

Intento #3
Ingrese fila (0-4): 3
Ingrese columna (0-4): 3

    0   1   2   3   4
  ┌───┬───┬───┬───┬───┐
0 │ . │ . │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
1 │ . │ . │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
2 │ . │ X │ . │ . │ . │
  ├───┼───┼───┼───┼───┤
3 │ . │ . │ X │ T │ . │
  ├───┼───┼───┼───┼───┤
4 │ . │ . │ . │ . │ . │
  └───┴───┴───┴───┴───┘

🎉 ¡FELICITACIONES! ¡Encontraste el tesoro!

PUNTUACIÓN FINAL:
- Intentos utilizados: 3
- Puntuación: 150 puntos (300 - 50 × intentos)
- Categoría: ¡Excelente!

¿Jugar de nuevo? (s/n):
```

### Puntos clave a implementar
- Calcular distancia Manhattan: `Math.Abs(fila1 - fila2) + Math.Abs(col1 - col2)`
- Sistema de pistas basado en distancia
- Validación de coordenadas y posiciones ya exploradas
- Interfaz visual atractiva con caracteres de tabla

---

## 📝 Ejercicio 4: Análisis de ventas por regiones
**Dificultad**: ⭐⭐⭐⭐☆ | **Tiempo estimado**: 45 minutos

### Descripción
Desarrolla un sistema de análisis de ventas que gestione datos de 6 regiones durante 12 meses. Debe generar múltiples reportes y estadísticas avanzadas.

### Requisitos funcionales
1. **Gestionar matriz** 6x12 (regiones x meses)
2. **Permitir entrada** manual o generación automática de datos
3. **Calcular** totales por región y por mes
4. **Identificar** mejor y peor región del año
5. **Detectar** tendencias de crecimiento/decrecimiento
6. **Generar reportes** detallados en múltiples formatos
7. **Exportar** datos en formato CSV simulado

### Estructura de datos
```csharp
string[] regiones = {"Norte", "Centro", "Sur", "Oriente", "Poniente", "Metropolitana"};
string[] meses = {"Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"};
decimal[,] ventas = new decimal[6, 12];
```

### Interfaz esperada
```
=== SISTEMA DE ANÁLISIS DE VENTAS ===

Opciones de datos:
1. Ingresar datos manualmente
2. Generar datos aleatorios de prueba
3. Cargar datos de ejemplo

Seleccione opción (1-3): 2

Generando datos aleatorios de ventas...
✓ Datos generados para 6 regiones × 12 meses

TABLA DE VENTAS ANUALES (Miles de pesos):
┌──────────────┬─────┬─────┬─────┬─────┬─────┬─────┬─────┬─────┬─────┬─────┬─────┬─────┬─────────┐
│ REGIÓN       │ Ene │ Feb │ Mar │ Abr │ May │ Jun │ Jul │ Ago │ Sep │ Oct │ Nov │ Dic │  TOTAL  │
├──────────────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────────┤
│ Norte        │ 450 │ 520 │ 610 │ 580 │ 640 │ 590 │ 620 │ 660 │ 580 │ 570 │ 630 │ 700 │  7,150  │
│ Centro       │ 380 │ 420 │ 460 │ 440 │ 480 │ 450 │ 470 │ 490 │ 440 │ 430 │ 470 │ 520 │  5,450  │
│ Sur          │ 320 │ 350 │ 390 │ 370 │ 410 │ 380 │ 400 │ 420 │ 370 │ 360 │ 400 │ 450 │  4,620  │
│ Oriente      │ 520 │ 580 │ 640 │ 610 │ 670 │ 620 │ 650 │ 690 │ 610 │ 600 │ 660 │ 730 │  7,580  │
│ Poniente     │ 410 │ 450 │ 490 │ 470 │ 510 │ 480 │ 500 │ 520 │ 470 │ 460 │ 500 │ 550 │  5,810  │
│ Metropolitana│ 680 │ 750 │ 820 │ 790 │ 860 │ 800 │ 830 │ 880 │ 790 │ 780 │ 850 │ 920 │  9,750  │
├──────────────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────────┤
│ TOTAL MENSUAL│2,760│3,070│3,410│3,260│3,570│3,320│3,470│3,660│3,260│3,200│3,510│3,870│ 40,360  │
└──────────────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────────┘

ANÁLISIS ESTADÍSTICO:

📊 RANKING DE REGIONES:
1. Metropolitana: $9,750,000 (24.1% del total)
2. Oriente: $7,580,000 (18.8% del total)
3. Norte: $7,150,000 (17.7% del total)
4. Poniente: $5,810,000 (14.4% del total)
5. Centro: $5,450,000 (13.5% del total)
6. Sur: $4,620,000 (11.4% del total)

📈 ANÁLISIS TEMPORAL:
- Mejor mes: Diciembre ($3,870,000)
- Peor mes: Enero ($2,760,000)
- Crecimiento Ene-Dic: +40.2%
- Promedio mensual: $3,363,333

🎯 METAS Y DESEMPEÑO:
- Meta anual total: $36,000,000
- Ventas reales: $40,360,000
- Superación de meta: +12.1% ✓

⚠️  ALERTAS:
- Sur: Región con menor crecimiento (40.6%)
- Feb-Mar: Mayor crecimiento intermensual (+11.1%)

TENDENCIAS POR REGIÓN:
Norte:     ▲ Crecimiento sostenido (+55.6%)
Centro:    ▲ Crecimiento moderado (+36.8%)
Sur:       ▲ Crecimiento bajo (+40.6%)
Oriente:   ▲ Crecimiento fuerte (+40.4%)
Poniente:  ▲ Crecimiento moderado (+34.1%)
Metropolitana: ▲ Crecimiento sólido (+35.3%)

¿Desea generar algún reporte específico?
1. Exportar a CSV
2. Análisis trimestral
3. Proyección próximo año
4. Volver al menú principal

Seleccione opción (1-4):
```

### Puntos clave a implementar
- Uso de `decimal` para manejar dinero con precisión
- Cálculos de porcentajes y tendencias
- Formateo avanzado de números con `:N0` y `:P1`
- Algoritmos de ordenamiento para rankings
- Manejo de múltiples tipos de análisis

---

## 📝 Ejercicio 5: Multiplicación de matrices
**Dificultad**: ⭐⭐⭐⭐☆ | **Tiempo estimado**: 50 minutos

### Descripción
Implementa un programa que realice multiplicación de matrices con validación de dimensiones y visualización del proceso paso a paso.

### Requisitos funcionales
1. **Leer dimensiones** de dos matrices del usuario
2. **Validar** que las matrices se puedan multiplicar (columnas A = filas B)
3. **Solicitar elementos** de ambas matrices
4. **Realizar multiplicación** matriz A × B = C
5. **Mostrar proceso** paso a paso (opcional)
6. **Visualizar** matrices de entrada y resultado
7. **Manejar errores** de dimensiones incompatibles

### Conceptos matemáticos
```
Multiplicación de matrices A(m×n) × B(n×p) = C(m×p)

C[i,j] = Σ(k=0 to n-1) A[i,k] × B[k,j]
```

### Interfaz esperada
```
=== MULTIPLICACIÓN DE MATRICES ===

CONFIGURACIÓN DE MATRICES:

Matriz A:
Ingrese número de filas: 2
Ingrese número de columnas: 3

Matriz B:
Ingrese número de filas: 3
Ingrese número de columnas: 2

✓ Las matrices son compatibles para multiplicación (A: 2×3, B: 3×2 → C: 2×2)

INGRESO DE ELEMENTOS - MATRIZ A (2×3):
A[0,0]: 2
A[0,1]: 3
A[0,2]: 1
A[1,0]: 4
A[1,1]: 0
A[1,2]: 5

INGRESO DE ELEMENTOS - MATRIZ B (3×2):
B[0,0]: 1
B[0,1]: 2
B[1,0]: 3
B[1,1]: 4
B[2,0]: 5
B[2,1]: 6

MATRICES DE ENTRADA:

Matriz A (2×3):          Matriz B (3×2):
┌─────┬─────┬─────┐      ┌─────┬─────┐
│  2  │  3  │  1  │      │  1  │  2  │
├─────┼─────┼─────┤      ├─────┼─────┤
│  4  │  0  │  5  │      │  3  │  4  │
└─────┴─────┴─────┘      ├─────┼─────┤
                         │  5  │  6  │
                         └─────┴─────┘

PROCESO DE MULTIPLICACIÓN:

Calculando C[0,0]: (2×1) + (3×3) + (1×5) = 2 + 9 + 5 = 16
Calculando C[0,1]: (2×2) + (3×4) + (1×6) = 4 + 12 + 6 = 22
Calculando C[1,0]: (4×1) + (0×3) + (5×5) = 4 + 0 + 25 = 29
Calculando C[1,1]: (4×2) + (0×4) + (5×6) = 8 + 0 + 30 = 38

RESULTADO - Matriz C (2×2):
┌──────┬──────┐
│  16  │  22  │
├──────┼──────┤
│  29  │  38  │
└──────┴──────┘

VERIFICACIÓN:
A × B = C
[2×3] × [3×2] = [2×2] ✓

¿Realizar otra multiplicación? (s/n):
```

### Puntos clave a implementar
- Validación de dimensiones antes de la multiplicación
- Algoritmo triple bucle para multiplicación
- Visualización clara del proceso matemático
- Manejo de matrices de tamaños variables
- Formateo alineado de matrices con diferentes tamaños

---

## 📝 Ejercicio 6: Buscaminas simplificado
**Dificultad**: ⭐⭐⭐⭐⭐ | **Tiempo estimado**: 60 minutos

### Descripción
Desarrolla una versión simplificada del juego Buscaminas usando una matriz bidimensional. El juego debe gestionar minas ocultas, contadores de minas adyacentes y mecánica de revelado de casillas.

### Requisitos funcionales
1. **Crear tablero** de tamaño configurable (mínimo 5x5)
2. **Colocar minas** aleatoriamente (15-20% de las casillas)
3. **Calcular números** de minas adyacentes para cada casilla
4. **Permitir** al jugador revelar casillas
5. **Detectar** si el jugador tocó una mina (Game Over)
6. **Verificar** condición de victoria (todas las casillas sin minas reveladas)
7. **Mostrar** tablero con casillas reveladas y ocultas

### Estructura del juego
```csharp
int filas = 8, columnas = 8;
bool[,] minas = new bool[filas, columnas];           // true = hay mina
int[,] contadores = new int[filas, columnas];        // número de minas adyacentes
bool[,] reveladas = new bool[filas, columnas];       // true = casilla revelada
```

### Interfaz esperada
```
=== BUSCAMINAS SIMPLIFICADO ===

Configuración del juego:
Tamaño del tablero: 6×6
Número de minas: 7

Instrucciones:
- Ingrese coordenadas (fila, columna) para revelar casilla
- Evite las minas (💣)
- Los números indican minas adyacentes
- Revele todas las casillas sin minas para ganar

    0   1   2   3   4   5
  ┌───┬───┬───┬───┬───┬───┐
0 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
1 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
2 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
3 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
4 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
5 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  └───┴───┴───┴───┴───┴───┘

Casillas restantes: 29 | Minas: 7

Ingrese fila (0-5): 2
Ingrese columna (0-5): 3

    0   1   2   3   4   5
  ┌───┬───┬───┬───┬───┬───┐
0 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
1 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
2 │ ▓ │ ▓ │ ▓ │ 2 │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
3 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
4 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
5 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  └───┴───┴───┴───┴───┴───┘

Casillas restantes: 28 | Minas: 7

Ingrese fila (0-5): 1
Ingrese columna (0-5): 1

    0   1   2   3   4   5
  ┌───┬───┬───┬───┬───┬───┐
0 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
1 │ ▓ │ 💣│ ▓ │ ▓ │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
2 │ ▓ │ ▓ │ ▓ │ 2 │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
3 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
4 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  ├───┼───┼───┼───┼───┼───┤
5 │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │ ▓ │
  └───┴───┴───┴───┴───┴───┘

💥 ¡GAME OVER! 💥
Has tocado una mina en la posición [1,1]

Tablero completo revelado:
    0   1   2   3   4   5
  ┌───┬───┬───┬───┬───┬───┐
0 │ 1 │ 2 │ 💣│ 2 │ 1 │ 0 │
  ├───┼───┼───┼───┼───┼───┤
1 │ 2 │ 💣│ 3 │ 💣│ 2 │ 0 │
  ├───┼───┼───┼───┼───┼───┤
2 │ 💣│ 3 │ 3 │ 2 │ 1 │ 0 │
  ├───┼───┼───┼───┼───┼───┤
3 │ 1 │ 2 │ 💣│ 1 │ 0 │ 0 │
  ├───┼───┼───┼───┼───┼───┤
4 │ 0 │ 1 │ 1 │ 1 │ 0 │ 0 │
  ├───┼───┼───┼───┼───┼───┤
5 │ 0 │ 0 │ 0 │ 0 │ 0 │ 0 │
  └───┴───┴───┴───┴───┴───┘

Puntuación: 2 casillas reveladas
Tiempo jugado: 45 segundos

¿Jugar de nuevo? (s/n):
```

### Puntos clave a implementar
- Algoritmo para colocar minas aleatoriamente sin repetir posiciones
- Calcular contadores verificando las 8 casillas adyacentes
- Validar coordenadas dentro del tablero
- Gestionar estados del juego (jugando, ganado, perdido)
- Usar Unicode para caracteres especiales (💣, ▓)

---

## 🎯 Criterios de evaluación

### ⭐ Nivel básico (Ejercicios 1-2)
- **Funcionalidad**: Programa ejecuta sin errores
- **Sintaxis**: Uso correcto de matrices 2D `[,]`
- **Lógica**: Bucles anidados implementados correctamente
- **Interfaz**: Salida legible y organizada

### ⭐⭐ Nivel intermedio (Ejercicios 3-4)
- **Algoritmos**: Implementación eficiente de búsquedas y cálculos
- **Validación**: Manejo adecuado de entradas inválidas
- **Organización**: Código estructurado con métodos auxiliares
- **Presentación**: Interfaz atractiva con formato tabular

### ⭐⭐⭐ Nivel avanzado (Ejercicios 5-6)
- **Complejidad**: Manejo de algoritmos matemáticos complejos
- **Arquitectura**: Diseño modular y reutilizable
- **Experiencia**: Interfaz de usuario pulida y funcional
- **Robustez**: Manejo completo de casos edge y errores

## 🚀 Próximo paso

Una vez completados estos ejercicios, estarás listo para el **mini-proyecto final**:

🎯 **Mini-proyecto**: `miniproyecto-notas-matriz-console.md`

¡Practica paso a paso y domina las matrices bidimensionales! 🎉
