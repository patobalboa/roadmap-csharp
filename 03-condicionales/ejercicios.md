# 📋 Ejercicios - Condicionales

## 🎯 Objetivos de Aprendizaje

Al completar estos ejercicios podrás:
- ✅ Usar estructuras `if`, `else if`, `else` correctamente
- ✅ Implementar `switch` statements con casos múltiples
- ✅ Combinar operadores lógicos (`&&`, `||`, `!`)
- ✅ Validar entrada de usuario con condicionales
- ✅ Comparar sintaxis con Python equivalente

---

## 📊 Ejercicio 1: Calculadora de Notas
**Dificultad**: ⭐ Básico

### Descripción
Crea un programa que convierta una calificación numérica (0-100) a una letra (A, B, C, D, F).

### Especificaciones
```
Escalas de calificación:
- A: 90-100
- B: 80-89
- C: 70-79
- D: 60-69
- F: 0-59
```

### Entrada Esperada
```
Ingresa la calificación numérica (0-100): 85
```

### Salida Esperada
```
=== CALCULADORA DE NOTAS ===
Calificación numérica: 85
Calificación letra: B
Estado: Aprobado
```

### 🐍 Comparación con Python
```python
# Python
nota = int(input("Calificación: "))
if nota >= 90:
    letra = 'A'
elif nota >= 80:
    letra = 'B'
# ... etc
```

**Archivo**: `01-calculadora-notas.cs`

---

## 🌡️ Ejercicio 2: Clasificador de Temperatura
**Dificultad**: ⭐ Básico

### Descripción
Clasifica la temperatura según diferentes escalas y da recomendaciones.

### Especificaciones
```
Clasificaciones (°C):
- Muy frío: < 0
- Frío: 0-15
- Templado: 16-25
- Caliente: 26-35
- Muy caliente: > 35
```

### Funcionalidades
1. Leer temperatura en Celsius
2. Clasificar temperatura
3. Dar recomendación de vestimenta
4. Mostrar equivalente en Fahrenheit

### Entrada Esperada
```
Ingresa la temperatura en Celsius: 22
```

### Salida Esperada
```
🌡️ CLASIFICADOR DE TEMPERATURA 🌡️

Temperatura: 22°C (71.6°F)
Clasificación: Templado
Recomendación: Ropa ligera y cómoda
```

**Archivo**: `02-clasificador-temperatura.cs`

---

## 🎮 Ejercicio 3: Juego de Adivinanza con Pistas
**Dificultad**: ⭐⭐ Intermedio

### Descripción
Crea un juego donde el usuario adivina un número con pistas direccionales.

### Especificaciones
- Número secreto entre 1-100
- Máximo 7 intentos
- Pistas: "muy alto", "alto", "bajo", "muy bajo"
- Diferentes mensajes según intentos restantes

### Lógica de Pistas
```
Si diferencia > 20: "muy alto/bajo"
Si diferencia > 10: "alto/bajo"  
Si diferencia <= 5: "muy cerca"
Si correcto: ¡Ganaste!
```

### Entrada Esperada
```
=== JUEGO DE ADIVINANZA ===
Intento 1/7 - Adivina el número (1-100): 50
Muy alto! Intenta con un número menor.

Intento 2/7 - Adivina el número (1-100): 25
Bajo! Intenta con un número mayor.
```

### Salida Final
```
🎉 ¡FELICIDADES! 🎉
Adivinaste en 5 intentos.
El número era: 32
```

**Archivo**: `03-juego-adivinanza.cs`

---

## 📅 Ejercicio 4: Calculadora de Días del Año
**Dificultad**: ⭐⭐ Intermedio

### Descripción
Determina información detallada sobre una fecha específica.

### Funcionalidades
1. Validar si un año es bisiesto
2. Determinar días en un mes específico
3. Calcular día del año (1-366)
4. Determinar estación del año
5. Calcular días restantes hasta fin de año

### Validaciones
- Meses válidos (1-12)
- Días válidos según el mes
- Años entre 1900-2100

### Entrada Esperada
```
=== CALCULADORA DE DÍAS ===
Ingresa el año (1900-2100): 2024
Ingresa el mes (1-12): 3
Ingresa el día: 15
```

### Salida Esperada
```
📅 INFORMACIÓN DE LA FECHA 📅

Fecha: 15 de Marzo de 2024
Año bisiesto: Sí
Día del año: 75 de 366
Días restantes: 291
Estación: Primavera (Hemisferio Norte)
Días en este mes: 31
```

**Archivo**: `04-calculadora-dias.cs`

---

## 🏪 Ejercicio 5: Sistema de Descuentos
**Dificultad**: ⭐⭐ Intermedio

### Descripción
Sistema de descuentos con múltiples criterios y membresías.

### Reglas de Descuento
```
Por Cantidad:
- $100-$199: 5%
- $200-$499: 10%
- $500-$999: 15%
- $1000+: 20%

Por Membresía:
- Premium: +10%
- VIP: +15%
- Regular: +0%

Descuento Máximo: 35%
```

### Entrada Esperada
```
=== SISTEMA DE DESCUENTOS ===
Monto de compra: $750
Tipo de membresía (Regular/Premium/VIP): Premium
```

### Salida Esperada
```
🛒 RESUMEN DE COMPRA 🛒

Subtotal: $750.00
Descuento por cantidad (15%): -$112.50
Descuento por membresía Premium (10%): -$63.75
═════════════════════════════
Descuento total (25%): -$176.25
Total a pagar: $573.75
Ahorro: $176.25
```

**Archivo**: `05-sistema-descuentos.cs`

---

## 🎯 Ejercicio 6: Validador de Contraseñas
**Dificultad**: ⭐⭐⭐ Avanzado

### Descripción
Valida contraseñas según criterios de seguridad y da recomendaciones.

### Criterios de Validación
```
Obligatorios:
- Mínimo 8 caracteres
- Al menos 1 mayúscula
- Al menos 1 minúscula  
- Al menos 1 número
- Al menos 1 símbolo (!@#$%^&*)

Puntuación:
- Cada criterio cumplido: +20 puntos
- Longitud > 12: +10 puntos
- Sin caracteres repetidos consecutivos: +10 puntos
```

### Niveles de Seguridad
- 0-40: Muy débil ❌
- 50-60: Débil ⚠️
- 70-80: Aceptable ✅
- 90-100: Fuerte 🔒
- 110+: Muy fuerte 🛡️

### Entrada Esperada
```
=== VALIDADOR DE CONTRASEÑAS ===
Ingresa tu contraseña: MyP@ssw0rd2024!
```

### Salida Esperada
```
🔐 ANÁLISIS DE CONTRASEÑA 🔐

Contraseña: MyP@ssw0rd2024! (14 caracteres)

Criterios cumplidos:
✅ Longitud mínima (8+ caracteres)
✅ Contiene mayúsculas (M, P)
✅ Contiene minúsculas (y, s, s, w, r, d)
✅ Contiene números (0, 2, 0, 2, 4)
✅ Contiene símbolos (@, !)
✅ Longitud extendida (12+ caracteres)
❌ Tiene caracteres repetidos consecutivos (ss)

Puntuación: 110/120
Nivel: 🛡️ MUY FUERTE

Recomendación: Excelente contraseña. Evita caracteres repetidos para máxima seguridad.
```

**Archivo**: `06-validador-contraseñas.cs`

---

## 🎲 Ejercicio 7: Juego de Dados RPG
**Dificultad**: ⭐⭐⭐ Avanzado

### Descripción
Simula un sistema de dados para juegos de rol con diferentes tipos de acciones.

### Tipos de Dados y Acciones
```
Acciones:
1. Ataque físico (2d6 + fuerza)
2. Hechizo (1d8 + magia)
3. Curación (1d4 + 2)
4. Crítico (doble daño si sale 20 en d20)
5. Defensa (1d12 + armadura)
```

### Mecánicas Especiales
- Crítico automático: natural 20
- Fallo crítico: natural 1
- Modificadores por estadísticas
- Diferentes mensajes según resultado

### Entrada Esperada
```
=== JUEGO DE DADOS RPG ===

Estadísticas del personaje:
Fuerza: 5
Magia: 3
Armadura: 2

Selecciona acción:
1. Ataque físico (2d6 + fuerza)
2. Lanzar hechizo (1d8 + magia)  
3. Curación (1d4 + 2)
4. Defensa (1d12 + armadura)

Opción: 1
```

### Salida Esperada
```
🎲 RESULTADO DE ACCIÓN 🎲

Acción: Ataque Físico
Dados: 2d6 = [4, 6] = 10
Modificador: +5 (Fuerza)
═══════════════════════════
Total: 15 puntos de daño

🔥 ¡GOLPE PODEROSO!
El enemigo recibe un daño considerable.
```

**Archivo**: `07-juego-dados-rpg.cs`

---

## 🚗 Ejercicio 8: Simulador de Semáforo Inteligente
**Dificultad**: ⭐⭐⭐ Avanzado

### Descripción
Simula un semáforo inteligente que cambia según condiciones de tráfico.

### Variables del Sistema
```
Factores:
- Hora del día (Rush, Normal, Nocturno)
- Cantidad de vehículos en cada dirección
- Vehículos de emergencia
- Peatones esperando
- Condiciones climáticas
```

### Lógica de Decisión
```
Prioridades:
1. Emergencia: Inmediato verde
2. Rush + alta densidad: Tiempo extendido
3. Peatones > 30 seg: Activar cruce
4. Equilibrio de tráfico
5. Modo nocturno: Tiempos reducidos
```

### Entrada Esperada
```
=== SIMULADOR DE SEMÁFORO INTELIGENTE ===

Estado actual: 🔴 ROJO - Norte/Sur
Tiempo restante: 15 segundos

Ingresa condiciones:
Hora (0-23): 8
Vehículos Norte: 15
Vehículos Sur: 12
Vehículos Este: 8
Vehículos Oeste: 6
Peatones esperando: 5
¿Emergencia? (s/n): n
Clima (Despejado/Lluvia/Niebla): Lluvia
```

### Salida Esperada
```
🚦 ANÁLISIS DEL SEMÁFORO 🚦

Situación detectada:
⏰ Hora rush matutina
🌧️ Condiciones de lluvia
🚗 Alta densidad Norte-Sur (27 vehículos)
🚶 Peatones moderados (5 personas)

Decisión del sistema:
🟢 VERDE Norte-Sur por 45 segundos (+15 por lluvia)
🔴 ROJO Este-Oeste

Próximo cambio: 45 segundos
Razón: Priorizar flujo principal en hora rush con precaución por lluvia
```

**Archivo**: `08-simulador-semaforo.cs`

---

## 🏥 Ejercicio 9: Sistema de Triaje Médico
**Dificultad**: ⭐⭐⭐⭐ Experto

### Descripción
Sistema de clasificación de pacientes por prioridad médica.

### Niveles de Triaje
```
Nivel 1 - CRÍTICO (Rojo):
- Dolor pecho + dificultad respirar
- Trauma severo + pérdida conciencia
- Temperatura > 40°C + síntomas graves

Nivel 2 - URGENTE (Naranja):  
- Dolor severo (8-10/10)
- Fiebre alta + síntomas moderados
- Lesiones moderadas

Nivel 3 - MENOS URGENTE (Amarillo):
- Dolor moderado (5-7/10)
- Síntomas estables
- Lesiones menores

Nivel 4 - NO URGENTE (Verde):
- Dolor leve (1-4/10)
- Síntomas leves
- Consulta preventiva
```

### Variables a Evaluar
- Síntomas principales
- Escala de dolor (1-10)
- Signos vitales
- Edad del paciente
- Condiciones preexistentes
- Tiempo de evolución

### Entrada Esperada
```
=== SISTEMA DE TRIAJE MÉDICO ===

Datos del paciente:
Edad: 45
Síntoma principal: Dolor de pecho
Escala de dolor (1-10): 9
¿Dificultad para respirar? (s/n): s
¿Pérdida de conciencia? (s/n): n
Temperatura (°C): 37.2
¿Antecedentes cardíacos? (s/n): s
Tiempo de evolución (horas): 1
```

### Salida Esperada
```
🏥 RESULTADO DEL TRIAJE 🏥

PACIENTE: [ID-001]
═══════════════════════════════

🔴 NIVEL 1 - CRÍTICO
Prioridad: INMEDIATA

Factores determinantes:
⚠️ Dolor de pecho severo (9/10)
⚠️ Dificultad respiratoria  
⚠️ Antecedentes cardíacos
⚠️ Evolución reciente (1 hora)

ACCIÓN REQUERIDA:
🚨 Atención médica INMEDIATA
🩺 Monitoreo cardíaco continuo
💊 Preparar protocolo síndrome coronario

Tiempo máximo de espera: 0 minutos
```

**Archivo**: `09-sistema-triaje.cs`

---

## 📊 Criterios de Evaluación

### Funcionalidad (40%)
- ✅ El programa compila sin errores
- ✅ Todas las funcionalidades funcionan correctamente
- ✅ Maneja casos borde apropiadamente
- ✅ Validación de entrada robusta

### Lógica Condicional (30%)
- ✅ Uso correcto de if/else if/else
- ✅ Implementación apropiada de switch cuando es necesario
- ✅ Operadores lógicos usados correctamente
- ✅ Anidación de condicionales bien estructurada

### Calidad del Código (20%)
- ✅ Código bien estructurado y legible
- ✅ Nombres de variables descriptivos
- ✅ Comentarios apropiados
- ✅ Separación lógica en funciones

### Experiencia de Usuario (10%)
- ✅ Mensajes claros y amigables
- ✅ Formato de salida apropiado
- ✅ Manejo de errores con mensajes útiles
- ✅ Interfaz intuitiva

---

## 🎯 Desafíos Adicionales (Opcional)

### 🏆 Desafío 1: Combinador de Ejercicios
Crea un programa que combine 3 ejercicios anteriores en un menú principal.

### 🏆 Desafío 2: Optimización de Condicionales
Refactoriza uno de tus ejercicios para usar el menor número de condicionales posible.

### 🏆 Desafío 3: Comparación Python vs C#
Para cada ejercicio, escribe la versión equivalente en Python y compara:
- Número de líneas de código
- Legibilidad
- Rendimiento
- Facilidad de debugging

---

## 📝 Instrucciones de Entrega

1. **Crear** una carpeta `03-condicionales-solucion`
2. **Implementar** cada ejercicio en su archivo correspondiente
3. **Probar** todos los casos de uso mencionados
4. **Documentar** cualquier decisión de diseño especial
5. **Comparar** al menos 3 ejercicios con su equivalente en Python

### Estructura de Entrega
```
03-condicionales-solucion/
├── 01-calculadora-notas.cs
├── 02-clasificador-temperatura.cs
├── 03-juego-adivinanza.cs
├── 04-calculadora-dias.cs
├── 05-sistema-descuentos.cs
├── 06-validador-contraseñas.cs
├── 07-juego-dados-rpg.cs
├── 08-simulador-semaforo.cs
├── 09-sistema-triaje.cs
└── comparacion-python.md
```

¡Buena suerte con los ejercicios! 🚀
