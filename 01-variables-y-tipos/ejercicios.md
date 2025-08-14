# Ejercicios: Variables y Tipos de Datos

## 🎯 Objetivos
Practicar la declaración de variables, conversiones de tipos y operaciones básicas en C#, comparando con conceptos conocidos de Python.

---

## 📋 Ejercicio 1: Información del Estudiante

### Enunciado:
Crea un programa que solicite y almacene la siguiente información de un estudiante:
- Nombre (string)
- Apellido (string)  
- Edad (int)
- Promedio (double)
- ¿Es estudiante regular? (bool)
- Inicial del segundo nombre (char)

### Entrada esperada:
```
Nombre: Carlos
Apellido: Rodríguez
Edad: 19
Promedio: 8.5
¿Es estudiante regular? (true/false): true
Inicial del segundo nombre: M
```

### Salida esperada:
```
=== FICHA DEL ESTUDIANTE ===
Nombre completo: Carlos M. Rodríguez
Edad: 19 años
Promedio: 8.50
Estudiante regular: True
========================
```

### Pistas:
- Usa `Console.ReadLine()` para leer texto
- Usa `int.Parse()` y `double.Parse()` para convertir
- Usa `bool.Parse()` para leer booleanos
- Para char: `char inicial = Console.ReadLine()[0];`

---

## 📋 Ejercicio 2: Calculadora de Notas

### Enunciado:
Escribe un programa que calcule el promedio de 4 notas de un estudiante. El programa debe:
1. Solicitar las 4 notas (pueden tener decimales)
2. Calcular el promedio
3. Determinar si aprobó (promedio >= 6.0)
4. Mostrar información completa

### Entrada esperada:
```
Ingresa la nota 1: 7.5
Ingresa la nota 2: 8.0
Ingresa la nota 3: 6.5
Ingresa la nota 4: 9.0
```

### Salida esperada:
```
=== REPORTE DE NOTAS ===
Nota 1: 7.50
Nota 2: 8.00
Nota 3: 6.50
Nota 4: 9.00
------------------
Promedio: 7.75
Estado: APROBADO
=====================
```

### Pistas:
- Declara 4 variables `double` para las notas
- El promedio es la suma dividida por 4
- Usa `.ToString("F2")` para mostrar 2 decimales

---

## 📋 Ejercicio 3: Conversor de Temperaturas

### Enunciado:
Crea un programa que convierta temperaturas entre Celsius y Fahrenheit. El programa debe:
1. Solicitar una temperatura en Celsius
2. Convertirla a Fahrenheit usando la fórmula: `F = (C * 9/5) + 32`
3. Mostrar ambas temperaturas con 1 decimal

### Entrada esperada:
```
Ingresa la temperatura en Celsius: 25
```

### Salida esperada:
```
=== CONVERSOR DE TEMPERATURA ===
Temperatura en Celsius: 25.0°C
Temperatura en Fahrenheit: 77.0°F
===============================
```

### Pistas:
- Cuidado con la división: usa `9.0/5` para obtener decimales
- Usa `.ToString("F1")` para 1 decimal

---

## 📋 Ejercicio 4: Información de Producto

### Enunciado:
Diseña un programa para registrar información de un producto en una tienda:
- Nombre del producto (string)
- Código (char para la categoría + número)
- Precio unitario (double)
- Cantidad en stock (int)
- ¿Está en oferta? (bool)

Calcula y muestra el valor total del inventario de ese producto.

### Entrada esperada:
```
Nombre del producto: Laptop Gaming
Categoría (letra): L
Código numérico: 1001
Precio unitario: 1299.99
Cantidad en stock: 15
¿Está en oferta? (true/false): true
```

### Salida esperada:
```
=== INFORMACIÓN DEL PRODUCTO ===
Producto: Laptop Gaming
Código: L1001
Precio unitario: $1299.99
Stock disponible: 15 unidades
En oferta: Sí
Valor total inventario: $19499.85
================================
```

### Pistas:
- Concatena `char` y `int` para formar el código
- Valor total = precio × cantidad
- Usa condicional simple: `string oferta = enOferta ? "Sí" : "No";`

---

## 📋 Ejercicio 5: Datos Personales Completos

### Enunciado:
Crea un programa que recopile datos personales completos:
- Nombre completo (string)
- Edad (int)
- Altura en metros (double)
- Peso en kg (double)
- Inicial del estado civil (char): S=Soltero, C=Casado, D=Divorciado
- ¿Tiene hijos? (bool)

Calcula el IMC (Índice de Masa Corporal) = peso / (altura²)

### Entrada esperada:
```
Nombre completo: Ana María García
Edad: 28
Altura (metros): 1.65
Peso (kg): 58.5
Estado civil (S/C/D): S
¿Tiene hijos? (true/false): false
```

### Salida esperada:
```
=== DATOS PERSONALES ===
Nombre: Ana María García
Edad: 28 años
Altura: 1.65 m
Peso: 58.5 kg
Estado civil: Soltero
Hijos: No
IMC: 21.49
Clasificación: Normal
=======================
```

### Pistas:
- IMC = peso / (altura * altura)
- Usar switch expression o if para clasificación IMC
- Clasificación: <18.5=Bajo peso, 18.5-24.9=Normal, ≥25=Sobrepeso

---

## 📋 Ejercicio 6: Tiempo y Distancia

### Enunciado:
Programa para calcular información de un viaje:
1. Solicitar distancia en kilómetros (double)
2. Solicitar tiempo en horas (double)
3. Calcular velocidad promedio
4. Convertir la distancia a metros y millas
5. Convertir el tiempo a minutos

**Conversiones:**
- 1 km = 1000 metros
- 1 km = 0.621371 millas
- 1 hora = 60 minutos

### Entrada esperada:
```
Distancia recorrida (km): 120.5
Tiempo empleado (horas): 2.5
```

### Salida esperada:
```
=== INFORMACIÓN DEL VIAJE ===
Distancia: 120.50 km (120500 m) (74.88 millas)
Tiempo: 2.50 horas (150 minutos)
Velocidad promedio: 48.20 km/h
=============================
```

### Pistas:
- Velocidad = distancia / tiempo
- Para metros: distancia * 1000
- Para millas: distancia * 0.621371
- Para minutos: tiempo * 60

---

## 📋 Ejercicio 7: Operaciones con Caracteres

### Enunciado:
Crea un programa que trabaje con caracteres:
1. Solicitar una letra mayúscula
2. Mostrar su código ASCII
3. Convertirla a minúscula
4. Mostrar el código ASCII de la minúscula
5. Calcular la diferencia entre códigos

### Entrada esperada:
```
Ingresa una letra mayúscula: M
```

### Salida esperada:
```
=== ANÁLISIS DE CARÁCTER ===
Letra original: M
Código ASCII: 77
Letra minúscula: m
Código ASCII: 109
Diferencia: 32
============================
```

### Pistas:
- Usar `char.ToLower()` para convertir a minúscula
- Casting `(int)` para obtener código ASCII
- La diferencia entre mayúscula y minúscula es siempre 32

---

## 📋 Ejercicio 8: Cálculos Financieros Básicos

### Enunciado:
Programa para calcular información financiera simple:
1. Solicitar salario mensual (double)
2. Solicitar porcentaje de descuentos (double, ej: 15.5 para 15.5%)
3. Solicitar porcentaje de bonificaciones (double)
4. Calcular salario neto
5. Proyectar salario anual

### Entrada esperada:
```
Salario mensual bruto: 5000
Porcentaje de descuentos: 18.5
Porcentaje de bonificaciones: 10
```

### Salida esperada:
```
=== CÁLCULO SALARIAL ===
Salario bruto mensual: $5000.00
Descuentos (18.5%): $925.00
Bonificaciones (10%): $500.00
Salario neto mensual: $4575.00
Proyección anual: $54900.00
=========================
```

### Pistas:
- Descuentos = salario * (porcentajeDescuentos / 100)
- Bonificaciones = salario * (porcentajeBonif / 100)
- Neto = bruto - descuentos + bonificaciones
- Anual = neto * 12

---

## 🎯 Desafío+

### Ejercicio 9: Conversor Universal

Crea un programa que permita al usuario elegir qué tipo de conversión realizar:
- Temperaturas (°C ↔ °F)
- Distancias (km ↔ millas)
- Pesos (kg ↔ libras)
- Monedas (USD → pesos, usando tasa fija)

**Entrada esperada:**
```
Selecciona conversión:
1. Temperatura (C a F)
2. Distancia (km a millas)
3. Peso (kg a libras)
Opción: 2
Valor a convertir: 100
```

**Salida esperada:**
```
=== CONVERSIÓN DE DISTANCIA ===
100.00 km = 62.14 millas
===========================
```

---

## ⚠️ Errores Frecuentes y Cómo Evitarlos

### 1. Olvidar punto y coma
```csharp
// ❌ Error
int edad = 25

// ✅ Correcto
int edad = 25;
```

### 2. División entera inesperada
```csharp
// ❌ Resultado inesperado
int promedio = (7 + 8 + 9) / 3;  // 8, no 8.0

// ✅ Correcto
double promedio = (7 + 8 + 9) / 3.0;  // 8.0
```

### 3. Conversiones incorrectas
```csharp
// ❌ Error de compilación
string edad = "25";
int edadNumerica = edad;  // No se puede convertir implícitamente

// ✅ Correcto
string edad = "25";
int edadNumerica = int.Parse(edad);
```

### 4. Usar True/False en lugar de true/false
```csharp
// ❌ Error
bool activo = True;

// ✅ Correcto  
bool activo = true;
```

### 5. Olvidar usar System
```csharp
// ❌ Error si no hay using System
Console.WriteLine("Hola");

// ✅ Correcto
using System;
// ...
Console.WriteLine("Hola");
```

---

## 📝 Lista de Verificación

Antes de continuar al siguiente módulo, asegúrate de que puedes:

- [ ] Declarar variables de diferentes tipos (int, double, string, bool, char)
- [ ] Convertir entre tipos usando Parse() y casting
- [ ] Realizar operaciones aritméticas básicas
- [ ] Leer entrada del usuario con Console.ReadLine()
- [ ] Formatear salida con ToString()
- [ ] Entender la diferencia entre división entera y decimal
- [ ] Usar variables bool correctamente (true/false)
- [ ] Concatenar strings con +
- [ ] Debuggear usando breakpoints

---

## 🎯 Siguiente Paso

¡Excelente trabajo! Ya dominas las variables y tipos en C#.

👉 **Continúa con**: [`../02-io-consola/teoria.md`](../02-io-consola/teoria.md)

---

*¿Necesitas ayuda con algún ejercicio? Revisa las soluciones en [`soluciones/ejercicios-soluciones.cs`](soluciones/ejercicios-soluciones.cs)*
