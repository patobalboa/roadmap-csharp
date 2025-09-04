# 📋 Ejercicios - Bucles for y while

## 🎯 Objetivos de Aprendizaje

Al completar estos ejercicios podrás:
- ✅ Usar bucles `for` y `while` correctamente
- ✅ Implementar `foreach` para recorrer colecciones
- ✅ Aplicar `break` y `continue` para control de flujo
- ✅ Crear bucles anidados para patrones complejos
- ✅ Comparar sintaxis con Python equivalente

---

## 📊 Ejercicio 1: Contador Simple
**Dificultad**: ⭐ Básico

### Descripción
Crea un programa que imprima los números del 1 al 10 usando un bucle `for`.

### Entrada Esperada
```
Ninguna entrada requerida
```

### Salida Esperada
```
=== CONTADOR SIMPLE ===
1
2
3
4
5
6
7
8
9
10
Fin del conteo
```

### 🐍 Comparación con Python
```python
# Python
for i in range(1, 11):
    print(i)
```

```csharp
// C#
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine(i);
}
```

---

## 📊 Ejercicio 2: Tabla de Multiplicar
**Dificultad**: ⭐ Básico

### Descripción
Pide al usuario un número y muestra su tabla de multiplicar del 1 al 12.

### Entrada Esperada
```
Ingresa un número para la tabla: 7
```

### Salida Esperada
```
=== TABLA DEL 7 ===
7 × 1 = 7
7 × 2 = 14
7 × 3 = 21
7 × 4 = 28
7 × 5 = 35
7 × 6 = 42
7 × 7 = 49
7 × 8 = 56
7 × 9 = 63
7 × 10 = 70
7 × 11 = 77
7 × 12 = 84
```

### 🐍 Comparación con Python
```python
# Python
numero = int(input("Número: "))
for i in range(1, 13):
    print(f"{numero} × {i} = {numero * i}")
```

---

## 📊 Ejercicio 3: Suma Acumulativa
**Dificultad**: ⭐⭐ Intermedio

### Descripción
Pide números al usuario hasta que ingrese 0. Calcula y muestra la suma total de todos los números ingresados (usando `while`).

### Entrada Esperada
```
Ingresa números (0 para terminar):
Número: 5
Número: 10
Número: 3
Número: 0
```

### Salida Esperada
```
=== SUMA ACUMULATIVA ===
Números ingresados: 5, 10, 3
Suma total: 18
Cantidad de números: 3
Promedio: 6.00
```

### 🐍 Comparación con Python
```python
# Python
suma = 0
contador = 0
while True:
    numero = int(input("Número: "))
    if numero == 0:
        break
    suma += numero
    contador += 1
```

---

## 📊 Ejercicio 4: Números Pares e Impares
**Dificultad**: ⭐⭐ Intermedio

### Descripción
Muestra los números del 1 al 20, indicando si cada uno es par o impar. Usa `continue` para saltar números múltiplos de 5.

### Entrada Esperada
```
Ninguna entrada requerida
```

### Salida Esperada
```
=== NÚMEROS PARES E IMPARES ===
1 - Impar
2 - Par
3 - Impar
4 - Par
6 - Par
7 - Impar
8 - Par
9 - Impar
11 - Impar
12 - Par
13 - Impar
14 - Par
16 - Par
17 - Impar
18 - Par
19 - Impar
(Se saltaron: 5, 10, 15, 20)
```

---

## 📊 Ejercicio 5: Pirámide de Asteriscos
**Dificultad**: ⭐⭐ Intermedio

### Descripción
Pide al usuario la altura de una pirámide y dibújala usando asteriscos con bucles anidados.

### Entrada Esperada
```
Ingresa la altura de la pirámide: 5
```

### Salida Esperada
```
=== PIRÁMIDE DE ASTERISCOS ===
    *
   ***
  *****
 *******
*********
```

### 🐍 Comparación con Python
```python
# Python
altura = int(input("Altura: "))
for i in range(1, altura + 1):
    espacios = " " * (altura - i)
    asteriscos = "*" * (2 * i - 1)
    print(espacios + asteriscos)
```

---

## 📊 Ejercicio 6: Adivina el Número
**Dificultad**: ⭐⭐⭐ Avanzado

### Descripción
El programa genera un número aleatorio del 1 al 100. El usuario debe adivinarlo con pistas de "mayor" o "menor". Limita a 7 intentos.

### Entrada Esperada
```
=== JUEGO: ADIVINA EL NÚMERO ===
He pensado un número del 1 al 100. ¡Adivínalo en 7 intentos!

Intento 1/7: 50
El número es MAYOR que 50

Intento 2/7: 75
El número es MENOR que 75

Intento 3/7: 62
¡Correcto! El número era 62
```

### Salida Esperada
```
🎉 ¡Felicidades! Adivinaste en 3 intentos
Tu puntuación: 85 puntos (100 - 15 por intentos)
```

---

## 📊 Ejercicio 7: Factorial con Validación
**Dificultad**: ⭐⭐⭐ Avanzado

### Descripción
Calcula el factorial de un número. Valida que sea positivo y pregunta si quiere calcular otro factorial.

### Entrada Esperada
```
=== CALCULADORA DE FACTORIAL ===
Ingresa un número positivo: -5
Error: El número debe ser positivo
Ingresa un número positivo: 6
¿Calcular otro factorial? (s/n): s
Ingresa un número positivo: 4
¿Calcular otro factorial? (s/n): n
```

### Salida Esperada
```
=== RESULTADOS ===
Factorial de 6 = 720
6! = 6 × 5 × 4 × 3 × 2 × 1 = 720

Factorial de 4 = 24
4! = 4 × 3 × 2 × 1 = 24

¡Gracias por usar la calculadora!
```

---

## 📊 Ejercicio 8: Patrón de Números
**Dificultad**: ⭐⭐⭐ Avanzado

### Descripción
Crea un patrón numérico usando bucles anidados según el tamaño especificado.

### Entrada Esperada
```
Ingresa el tamaño del patrón: 4
```

### Salida Esperada
```
=== PATRÓN NUMÉRICO ===
1
1 2
1 2 3
1 2 3 4
```

### Variante 2 (Patrón Decreciente)
```
=== PATRÓN DECRECIENTE ===
1 2 3 4
1 2 3
1 2
1
```

---

## 📊 Ejercicio 9: Análisis de Array
**Dificultad**: ⭐⭐⭐ Avanzado

### Descripción
Dado un array de números, encuentra el mayor, menor, suma y promedio usando `foreach`.

### Código Base
```csharp
int[] numeros = {15, 3, 27, 8, 45, 12, 33, 6, 19, 41};
```

### Salida Esperada
```
=== ANÁLISIS DE ARRAY ===
Array: [15, 3, 27, 8, 45, 12, 33, 6, 19, 41]

Estadísticas:
- Número mayor: 45
- Número menor: 3
- Suma total: 209
- Promedio: 20.90
- Cantidad de números: 10
- Números pares: 4 (8, 12, 6, 41)
- Números impares: 6
```

---

## 📊 Ejercicio 10: Menu Interactivo
**Dificultad**: ⭐⭐⭐⭐ Experto

### Descripción
Crea un menú que permita al usuario elegir entre diferentes operaciones con bucles.

### Salida Esperada
```
=== MENÚ DE OPERACIONES ===
1. Tabla de multiplicar
2. Contar números pares/impares
3. Calcular factorial
4. Dibujar pirámide
5. Salir

Elige una opción (1-5): 1
Ingresa un número: 3

=== TABLA DEL 3 ===
3 × 1 = 3
3 × 2 = 6
...

¿Volver al menú? (s/n): s
```

---

## 🎯 Retos Adicionales

### 🔥 Reto 1: Números Primos
Encuentra todos los números primos del 2 al 100 usando bucles anidados.

### 🔥 Reto 2: Fibonacci
Genera la secuencia de Fibonacci hasta el término N especificado por el usuario.

### 🔥 Reto 3: Búsqueda en Array
Implementa búsqueda lineal en un array, contando cuántas comparaciones se necesitaron.

---

## 📝 Notas para el Desarrollo

### ⚡ Consejos de Rendimiento
1. **Evita bucles infinitos** - Siempre asegúrate que la condición cambie
2. **Inicializa variables** antes de usar en bucles
3. **Usa break y continue** apropiadamente para control de flujo

### 🐛 Errores Comunes
1. **Condición incorrecta** en while (nunca se cumple)
2. **Incremento olvidado** en bucles manuales
3. **Índices fuera de rango** en arrays
4. **Variables no declaradas** dentro del scope del bucle

### 🧪 Testing Tips
1. Prueba con **valores límite** (0, 1, números grandes)
2. Verifica **casos especiales** (arrays vacíos, números negativos)
3. Confirma que los **bucles terminan** correctamente

---

## 📚 Material de Apoyo

- 📖 **Teoría**: Revisa `teoria.md` para conceptos fundamentales
- 🔧 **Soluciones**: Disponibles en `soluciones/`
- 🐍 **Python vs C#**: Comparaciones en cada ejercicio
- 💡 **Plantillas**: Usa `docs/plantillas/Program.cs` como base

---

¡Éxito en tu aprendizaje de bucles en C#! 🚀
