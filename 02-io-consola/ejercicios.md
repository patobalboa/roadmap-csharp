# Ejercicios: Entrada/Salida por Consola

## 🎯 Objetivos
Dominar `Console.ReadLine()`, `Console.WriteLine()`, conversiones de tipos y formateo de salida comparando con Python.

---

## 📋 Ejercicio 1: Registro de Estudiante

### Enunciado:
Crea un programa que capture información completa de un estudiante y la muestre en formato de ficha oficial.

**Información a capturar:**
- Nombre completo
- Número de estudiante (entero)
- Carrera
- Semestre actual (entero)
- Promedio acumulado (decimal)
- ¿Es becario? (booleano)

### Entrada esperada:
```
=== REGISTRO DE ESTUDIANTE ===
Nombre completo: Ana María Rodríguez
Número de estudiante: 20241234
Carrera: Ingeniería en Sistemas
Semestre actual: 5
Promedio acumulado: 8.75
¿Es becario? (true/false): true
```

### Salida esperada:
```
╔══════════════════════════════════════╗
║            FICHA ESTUDIANTIL         ║
╠══════════════════════════════════════╣
║ Nombre: Ana María Rodríguez          ║
║ No. Estudiante: 20241234             ║
║ Carrera: Ingeniería en Sistemas      ║
║ Semestre: 5to                        ║
║ Promedio: 8.75                       ║
║ Becario: SÍ                          ║
╚══════════════════════════════════════╝

Presiona cualquier tecla para continuar...
```

### Pistas:
- Usa caracteres especiales para el marco decorativo
- Convierte el boolean a texto legible (SÍ/NO)
- Añade "to" al número de semestre para formato

---

## 📋 Ejercicio 2: Calculadora de Gastos Mensuales

### Enunciado:
Desarrolla una calculadora que capture los gastos mensuales de una persona y genere un reporte detallado con totales y porcentajes.

**Gastos a capturar:**
- Vivienda (renta/hipoteca)
- Alimentación
- Transporte
- Entretenimiento
- Otros gastos

### Entrada esperada:
```
=== CALCULADORA DE GASTOS MENSUALES ===
Ingresa tus gastos del mes:
Vivienda (renta/hipoteca): 8000
Alimentación: 3500
Transporte: 1500
Entretenimiento: 2000
Otros gastos: 1200
```

### Salida esperada:
```
════════════════════════════════════════
           REPORTE DE GASTOS
════════════════════════════════════════
Vivienda:          $ 8,000.00  (49.2%)
Alimentación:      $ 3,500.00  (21.5%)
Transporte:        $ 1,500.00  ( 9.2%)
Entretenimiento:   $ 2,000.00  (12.3%)
Otros:             $ 1,200.00  ( 7.4%)
────────────────────────────────────────
TOTAL MENSUAL:     $16,200.00 (100.0%)
TOTAL ANUAL:       $194,400.00
════════════════════════════════════════
```

### Pistas:
- Calcula porcentajes: `(gasto / total) * 100`
- Usa `.ToString("C")` para formato de moneda
- Usa `.ToString("F1")` para porcentajes con 1 decimal

---

## 📋 Ejercicio 3: Sistema de Login Simple

### Enunciado:
Crea un simulador de login que capture credenciales y simule una validación básica.

**Proceso:**
1. Mostrar pantalla de bienvenida
2. Solicitar usuario y contraseña
3. Simular validación (usuario: "admin", password: "123456")
4. Mostrar mensaje de éxito o error
5. Si es exitoso, mostrar panel de usuario

### Entrada esperada (caso éxito):
```
Nombre de usuario: admin
Contraseña: 123456
```

### Salida esperada (caso éxito):
```
┌─────────────────────────────────────┐
│         SISTEMA ACADÉMICO           │
│            Versión 2.1              │
└─────────────────────────────────────┘

Nombre de usuario: admin
Contraseña: 123456

✓ ACCESO CONCEDIDO
Bienvenido, Administrador

═══════════════════════════════════════
          PANEL PRINCIPAL
═══════════════════════════════════════
Usuario: admin
Última conexión: 14/08/2025 10:30 AM
Estado: En línea
Permisos: Administrador
═══════════════════════════════════════
```

### Entrada esperada (caso error):
```
Nombre de usuario: usuario123
Contraseña: password
```

### Salida esperada (caso error):
```
✗ ACCESO DENEGADO
Credenciales incorrectas.
Inténtalo de nuevo.
```

### Pistas:
- Usa `DateTime.Now` para mostrar fecha/hora actual
- Compara strings con `==`
- Usa símbolos Unicode para ✓ y ✗

---

## 📋 Ejercicio 4: Conversor de Unidades Interactivo

### Enunciado:
Desarrolla un conversor que permita al usuario elegir entre diferentes tipos de conversiones mediante un menú interactivo.

**Opciones disponibles:**
1. Longitud (metros ↔ pies)
2. Peso (kilogramos ↔ libras)
3. Temperatura (Celsius ↔ Fahrenheit)
4. Salir

### Entrada esperada:
```
Selecciona una opción:
1. Convertir longitud (m ↔ ft)
2. Convertir peso (kg ↔ lb)
3. Convertir temperatura (°C ↔ °F)
4. Salir
Opción: 2

Conversión de peso seleccionada:
1. Kilogramos a Libras
2. Libras a Kilogramos
Subopción: 1

Ingresa el peso en kilogramos: 70.5
```

### Salida esperada:
```
╔═══════════════════════════════════╗
║        CONVERSOR DE UNIDADES      ║
╚═══════════════════════════════════╝

CONVERSIÓN DE PESO
──────────────────
Valor original:    70.50 kg
Valor convertido: 155.42 lb
Factor usado:      2.20462
──────────────────
Conversión completada exitosamente

¿Realizar otra conversión? (s/n): n
¡Gracias por usar el conversor!
```

### Pistas:
- Factores: 1m = 3.28084 ft, 1kg = 2.20462 lb
- Temperatura: °F = (°C × 9/5) + 32, °C = (°F - 32) × 5/9
- Usa menu anidados (switch dentro de switch)

---

## 📋 Ejercicio 5: Reporte de Ventas Diarias

### Enunciado:
Crea un sistema que capture las ventas de diferentes productos durante el día y genere un reporte de cierre.

**Datos a capturar por cada venta:**
- Producto vendido
- Cantidad
- Precio unitario
- Descuento aplicado (porcentaje)

**El programa debe:**
1. Preguntar cuántas ventas se registrarán
2. Capturar cada venta
3. Calcular subtotales, descuentos y totales
4. Generar reporte final

### Entrada esperada:
```
¿Cuántas ventas registrarás hoy?: 2

=== VENTA #1 ===
Producto: Laptop Dell
Cantidad: 1
Precio unitario: 15000
Descuento (%): 10

=== VENTA #2 ===
Producto: Mouse inalámbrico
Cantidad: 3
Precio unitario: 450
Descuento (%): 5
```

### Salida esperada:
```
╔══════════════════════════════════════════════════════════╗
║                    REPORTE DE VENTAS                     ║
║                     14/08/2025                           ║
╚══════════════════════════════════════════════════════════╝

VENTA #1
────────
Producto: Laptop Dell
Cantidad: 1 x $15,000.00 = $15,000.00
Descuento (10%): -$1,500.00
Subtotal: $13,500.00

VENTA #2
────────
Producto: Mouse inalámbrico
Cantidad: 3 x $450.00 = $1,350.00
Descuento (5%): -$67.50
Subtotal: $1,282.50

══════════════════════════════════════════════════════════
RESUMEN DEL DÍA
──────────────────────────────────────────────────────────
Total de ventas: 2
Ventas brutas: $16,350.00
Descuentos totales: $1,567.50
TOTAL NETO: $14,782.50
══════════════════════════════════════════════════════════
```

### Pistas:
- Usa un bucle for para múltiples ventas
- Subtotal = cantidad × precio × (1 - descuento/100)
- Acumula totales en variables separadas

---

## 📋 Ejercicio 6: Cuestionario de Satisfacción

### Enunciado:
Diseña un cuestionario de satisfacción que capture respuestas y genere estadísticas básicas.

**Preguntas del cuestionario:**
1. Califica el servicio (1-10)
2. ¿Recomendarías el producto? (s/n)
3. ¿Qué tan fácil fue usar el sistema? (1-5)
4. Comentarios adicionales (texto libre)

### Entrada esperada:
```
CUESTIONARIO DE SATISFACCIÓN
============================

1. Califica nuestro servicio (1-10): 8
2. ¿Recomendarías nuestro producto? (s/n): s
3. ¿Qué tan fácil fue usar el sistema? (1-5): 4
4. Comentarios adicionales: Muy buena experiencia, seguiré usando el servicio.
```

### Salida esperada:
```
╔═══════════════════════════════════════════════════════╗
║                RESPUESTAS REGISTRADAS                 ║
╚═══════════════════════════════════════════════════════╝

Calificación del servicio: ⭐⭐⭐⭐⭐⭐⭐⭐ (8/10)
Recomendación: SÍ ✓
Facilidad de uso: ████ (4/5)
Comentarios: "Muy buena experiencia, seguiré usando 
             el servicio."

═══════════════════════════════════════════════════════
ANÁLISIS RÁPIDO
───────────────────────────────────────────────────────
Calificación: Muy buena (8.0/10)
Cliente promotor: SÍ
Usabilidad: Buena (4.0/5)
═══════════════════════════════════════════════════════

¡Gracias por tu tiempo!
Tus comentarios son muy valiosos para nosotros.
```

### Pistas:
- Usa string.Repeat() para crear barras de progreso
- Clasifica las calificaciones: 1-3=Malo, 4-6=Regular, 7-8=Bueno, 9-10=Excelente
- Usa caracteres Unicode para estrellas: ⭐

---

## 📋 Ejercicio 7: Calculadora de IMC con Recomendaciones

### Enunciado:
Crea una calculadora de Índice de Masa Corporal (IMC) que incluya interpretación y recomendaciones personalizadas.

### Entrada esperada:
```
=== CALCULADORA DE IMC ===

Información personal:
Nombre: Carlos Méndez
Edad: 28
Peso (kg): 75.5
Altura (metros): 1.78
Sexo (M/F): M
¿Realizas ejercicio regularmente? (s/n): s
```

### Salida esperada:
```
╔═══════════════════════════════════════════════════════╗
║                   REPORTE DE IMC                      ║
╚═══════════════════════════════════════════════════════╝

DATOS PERSONALES
────────────────
Nombre: Carlos Méndez
Edad: 28 años
Sexo: Masculino
Actividad física: Regular

MEDICIONES
──────────
Peso: 75.5 kg
Altura: 1.78 m
IMC: 23.8

INTERPRETACIÓN
──────────────
Clasificación: PESO NORMAL ✓
Rango saludable: 18.5 - 24.9
Tu IMC está dentro del rango ideal

RECOMENDACIONES
───────────────
• Mantén tu peso actual
• Continúa con ejercicio regular
• Dieta balanceada
• Chequeos médicos anuales

═══════════════════════════════════════════════════════
IMC = peso (kg) / altura² (m²)
═══════════════════════════════════════════════════════
```

### Pistas:
- IMC = peso / (altura × altura)
- Rangos: <18.5=Bajo, 18.5-24.9=Normal, 25-29.9=Sobrepeso, ≥30=Obesidad
- Adapta recomendaciones según IMC y ejercicio

---

## 📋 Ejercicio 8: Generador de Facturas

### Enunciado:
Desarrolla un generador de facturas que capture productos y genere una factura profesional.

### Entrada esperada:
```
=== GENERADOR DE FACTURAS ===

Datos del cliente:
Nombre/Empresa: Tecnología Avanzada S.A.
RFC/ID: TAV120814AB3
Dirección: Av. Innovación 123, Col. Futuro

¿Cuántos productos facturar?: 2

PRODUCTO #1
───────────
Descripción: Consultoría de software
Cantidad: 10
Precio unitario: 1500
IVA aplicable (%): 16

PRODUCTO #2
───────────
Descripción: Licencia anual
Cantidad: 1  
Precio unitario: 25000
IVA aplicable (%): 16
```

### Salida esperada:
```
╔══════════════════════════════════════════════════════════════╗
║                         FACTURA                              ║
║                    No. 001-2025-001                          ║
║                    Fecha: 14/08/2025                         ║
╚══════════════════════════════════════════════════════════════╝

CLIENTE
─────────────────────────────────────────────────────────────
Tecnología Avanzada S.A.
RFC: TAV120814AB3
Av. Innovación 123, Col. Futuro

DETALLE DE PRODUCTOS
─────────────────────────────────────────────────────────────
Cant. | Descripción          | P.Unit.    | Subtotal
─────────────────────────────────────────────────────────────
  10  | Consultoría de       | $1,500.00  | $15,000.00
      | software             |            |
   1  | Licencia anual       |$25,000.00  | $25,000.00
─────────────────────────────────────────────────────────────

TOTALES
─────────────────────────────────────────────────────────────
Subtotal:                                       $40,000.00
IVA (16%):                                       $6,400.00
═════════════════════════════════════════════════════════════
TOTAL:                                          $46,400.00
═════════════════════════════════════════════════════════════

¡Gracias por su preferencia!
```

### Pistas:
- Usa contadores para números de factura
- IVA = subtotal × (porcentaje/100)
- Formatea dinero con `.ToString("C")`

---

## 🎯 Desafío+

### Ejercicio 9: Sistema de Menú Completo

Crea un sistema con múltiples módulos que permita:
1. Registro de usuarios
2. Calculadora científica
3. Conversor de unidades
4. Generador de reportes
5. Configuración del sistema

Debe incluir:
- Menú principal navegable
- Validación de entradas
- Manejo de errores básico
- Formato profesional
- Opción de regresar al menú desde cualquier módulo

---

## ⚠️ Errores Frecuentes y Cómo Evitarlos

### 1. No validar entrada numérica
```csharp
// ❌ Error: se rompe si el usuario ingresa texto
int edad = int.Parse(Console.ReadLine());

// ✅ Mejor: validar con TryParse
int edad;
while (!int.TryParse(Console.ReadLine(), out edad))
{
    Console.Write("Por favor ingresa un número válido: ");
}
```

### 2. Olvidar formatear números
```csharp
// ❌ Salida: 1234.5678901
double precio = 1234.5678901;
Console.WriteLine("Precio: " + precio);

// ✅ Salida: Precio: $1,234.57
Console.WriteLine("Precio: " + precio.ToString("C"));
```

### 3. No usar pausas en programas
```csharp
// ❌ El programa termina inmediatamente
Console.WriteLine("Resultado: " + resultado);

// ✅ Permite ver el resultado
Console.WriteLine("Resultado: " + resultado);
Console.ReadKey();
```

---

## 📝 Lista de Verificación

Antes de continuar al siguiente módulo, asegúrate de que puedes:

- [ ] Usar `Console.WriteLine()` y `Console.Write()` apropiadamente
- [ ] Capturar entrada con `Console.ReadLine()` y convertir tipos
- [ ] Formatear números con `.ToString()` y especificadores
- [ ] Crear reportes bien formateados con líneas decorativas
- [ ] Validar entrada básica con `TryParse()`
- [ ] Usar `Console.ReadKey()` para pausas
- [ ] Comparar eficientemente con Python (`print()` vs `Console.WriteLine()`)
- [ ] Manejar entrada de diferentes tipos de datos

---

## 🎯 Siguiente Paso

¡Excelente! Ya dominas la entrada/salida por consola en C#.

👉 **Continúa con**: [`../03-condicionales/teoria.md`](../03-condicionales/teoria.md)

---

*¿Necesitas ayuda con algún ejercicio? Revisa las soluciones en [`soluciones/ejercicios-soluciones.cs`](soluciones/ejercicios-soluciones.cs)*
