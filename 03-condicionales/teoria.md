# Estructuras Condicionales en C#

## 🎯 Objetivos de Aprendizaje

Al finalizar esta lección podrás:
- Dominar las estructuras `if`, `else if`, `else` en C#
- Usar la estructura `switch` para múltiples condiciones
- Aplicar operadores de comparación y lógicos
- Implementar el operador ternario para asignaciones condicionales
- Comparar eficientemente con estructuras condicionales de Python

## 🆚 Comparación Principal: if/elif/else vs if/else if/else

### Python:
```python
edad = 18

if edad < 18:
    print("Menor de edad")
elif edad == 18:
    print("Recién mayor de edad")
elif edad < 65:
    print("Adulto")
else:
    print("Adulto mayor")
```

### C#:
```csharp
int edad = 18;

if (edad < 18)
{
    Console.WriteLine("Menor de edad");
}
else if (edad == 18)
{
    Console.WriteLine("Recién mayor de edad");
}
else if (edad < 65)
{
    Console.WriteLine("Adulto");
}
else
{
    Console.WriteLine("Adulto mayor");
}
```

## 🔍 Operadores de Comparación

### Tabla de equivalencias:

| Operador | Significado | Python | C# | Ejemplo |
|----------|-------------|--------|-----|---------|
| **Igual** | Es igual a | `==` | `==` | `edad == 18` |
| **Diferente** | No es igual | `!=` | `!=` | `edad != 18` |
| **Mayor** | Mayor que | `>` | `>` | `edad > 18` |
| **Menor** | Menor que | `<` | `<` | `edad < 18` |
| **Mayor o igual** | Mayor o igual | `>=` | `>=` | `edad >= 18` |
| **Menor o igual** | Menor o igual | `<=` | `<=` | `edad <= 18` |

### Ejemplos prácticos:

```csharp
int nota = 85;
double precio = 29.99;
string nombre = "Ana";
bool activo = true;

// Comparaciones numéricas
if (nota >= 90)
    Console.WriteLine("Excelente");

if (precio < 50.0)
    Console.WriteLine("Precio accesible");

// Comparaciones de texto
if (nombre == "Ana")
    Console.WriteLine("Hola Ana");

// Comparaciones booleanas
if (activo == true)  // o simplemente: if (activo)
    Console.WriteLine("Usuario activo");
```

## 🧠 Operadores Lógicos

### Tabla de equivalencias:

| Operador | Significado | Python | C# | Ejemplo |
|----------|-------------|--------|-----|---------|
| **Y lógico** | Ambas condiciones verdaderas | `and` | `&&` | `edad >= 18 && edad < 65` |
| **O lógico** | Al menos una verdadera | `or` | `\|\|` | `dia == "sabado" \|\| dia == "domingo"` |
| **Negación** | Opuesto | `not` | `!` | `!activo` |

### Comparación lado a lado:

**Python:**
```python
edad = 25
salario = 3000
experiencia = 2

# Condiciones múltiples con and
if edad >= 18 and salario > 2500:
    print("Candidato calificado")

# Condiciones múltiples con or
if experiencia < 1 or salario < 2000:
    print("Candidato junior")

# Negación
if not activo:
    print("Usuario inactivo")
```

**C#:**
```csharp
int edad = 25;
double salario = 3000;
int experiencia = 2;

// Condiciones múltiples con &&
if (edad >= 18 && salario > 2500)
{
    Console.WriteLine("Candidato calificado");
}

// Condiciones múltiples con ||
if (experiencia < 1 || salario < 2000)
{
    Console.WriteLine("Candidato junior");
}

// Negación
if (!activo)
{
    Console.WriteLine("Usuario inactivo");
}
```

## 📐 Estructura if/else if/else

### Sintaxis básica:

```csharp
if (condición1)
{
    // Código si condición1 es verdadera
}
else if (condición2)
{
    // Código si condición2 es verdadera
}
else if (condición3)
{
    // Código si condición3 es verdadera
}
else
{
    // Código si ninguna condición anterior es verdadera
}
```

### Ejemplo: Sistema de calificaciones

```csharp
Console.Write("Ingresa tu calificación (0-100): ");
int calificacion = int.Parse(Console.ReadLine());

if (calificacion >= 90)
{
    Console.WriteLine("Calificación: A (Excelente)");
    Console.WriteLine("¡Felicitaciones!");
}
else if (calificacion >= 80)
{
    Console.WriteLine("Calificación: B (Muy bueno)");
    Console.WriteLine("Buen trabajo");
}
else if (calificacion >= 70)
{
    Console.WriteLine("Calificación: C (Bueno)");
    Console.WriteLine("Puedes mejorar");
}
else if (calificacion >= 60)
{
    Console.WriteLine("Calificación: D (Suficiente)");
    Console.WriteLine("Necesitas estudiar más");
}
else
{
    Console.WriteLine("Calificación: F (Insuficiente)");
    Console.WriteLine("Debes volver a presentar");
}
```

## 🔀 Estructura switch

### Comparación con Python:

**Python (no tiene switch nativo, usa if/elif):**
```python
dia = 3

if dia == 1:
    print("Lunes")
elif dia == 2:
    print("Martes")
elif dia == 3:
    print("Miércoles")
elif dia == 4:
    print("Jueves")
elif dia == 5:
    print("Viernes")
else:
    print("Fin de semana")
```

**C# (con switch):**
```csharp
int dia = 3;

switch (dia)
{
    case 1:
        Console.WriteLine("Lunes");
        break;
    case 2:
        Console.WriteLine("Martes");
        break;
    case 3:
        Console.WriteLine("Miércoles");
        break;
    case 4:
        Console.WriteLine("Jueves");
        break;
    case 5:
        Console.WriteLine("Viernes");
        break;
    default:
        Console.WriteLine("Fin de semana");
        break;
}
```

### Switch con múltiples casos:

```csharp
char calificacion = 'B';

switch (calificacion)
{
    case 'A':
    case 'a':
        Console.WriteLine("Excelente (90-100)");
        break;
    case 'B':
    case 'b':
        Console.WriteLine("Muy bueno (80-89)");
        break;
    case 'C':
    case 'c':
        Console.WriteLine("Bueno (70-79)");
        break;
    case 'D':
    case 'd':
        Console.WriteLine("Suficiente (60-69)");
        break;
    case 'F':
    case 'f':
        Console.WriteLine("Insuficiente (0-59)");
        break;
    default:
        Console.WriteLine("Calificación no válida");
        break;
}
```

### Switch con strings:

```csharp
Console.Write("Ingresa tu estado civil: ");
string estadoCivil = Console.ReadLine().ToLower();

switch (estadoCivil)
{
    case "soltero":
    case "soltera":
        Console.WriteLine("Estado: Soltero/a");
        Console.WriteLine("Beneficios fiscales: Estándar");
        break;
    case "casado":
    case "casada":
        Console.WriteLine("Estado: Casado/a");
        Console.WriteLine("Beneficios fiscales: Declaración conjunta");
        break;
    case "divorciado":
    case "divorciada":
        Console.WriteLine("Estado: Divorciado/a");
        Console.WriteLine("Beneficios fiscales: Revisar manutención");
        break;
    case "viudo":
    case "viuda":
        Console.WriteLine("Estado: Viudo/a");
        Console.WriteLine("Beneficios fiscales: Especiales");
        break;
    default:
        Console.WriteLine("Estado civil no reconocido");
        break;
}
```

## ⚡ Operador Ternario

### Comparación con Python:

**Python:**
```python
edad = 20
mensaje = "Mayor de edad" if edad >= 18 else "Menor de edad"
print(mensaje)
```

**C#:**
```csharp
int edad = 20;
string mensaje = edad >= 18 ? "Mayor de edad" : "Menor de edad";
Console.WriteLine(mensaje);
```

### Sintaxis del operador ternario:
```
condición ? valorSiVerdadero : valorSiFalso
```

### Ejemplos prácticos:

```csharp
// Determinar si un número es par o impar
int numero = 15;
string tipo = numero % 2 == 0 ? "Par" : "Impar";

// Calcular descuento
double precio = 100;
bool esVIP = true;
double precioFinal = esVIP ? precio * 0.8 : precio;  // 20% descuento para VIP

// Mensaje de saludo
DateTime ahora = DateTime.Now;
string saludo = ahora.Hour < 12 ? "Buenos días" : "Buenas tardes";

// Validación de entrada
Console.Write("¿Continuar? (s/n): ");
string entrada = Console.ReadLine();
bool continuar = entrada.ToLower() == "s" ? true : false;
```

## 🏗️ Anidamiento de Condicionales

### Ejemplo: Sistema de acceso con múltiples validaciones

```csharp
Console.Write("Usuario: ");
string usuario = Console.ReadLine();

Console.Write("Contraseña: ");
string password = Console.ReadLine();

Console.Write("¿Tienes token 2FA? (s/n): ");
bool tieneToken = Console.ReadLine().ToLower() == "s";

if (usuario == "admin")
{
    if (password == "123456")
    {
        if (tieneToken)
        {
            Console.WriteLine("✓ Acceso completo concedido");
            Console.WriteLine("Bienvenido, Administrador");
        }
        else
        {
            Console.WriteLine("⚠️ Acceso parcial - Falta 2FA");
            Console.WriteLine("Solo lectura permitida");
        }
    }
    else
    {
        Console.WriteLine("❌ Contraseña incorrecta");
    }
}
else if (usuario == "usuario")
{
    if (password == "user123")
    {
        Console.WriteLine("✓ Acceso de usuario concedido");
        Console.WriteLine("Permisos limitados");
    }
    else
    {
        Console.WriteLine("❌ Contraseña incorrecta");
    }
}
else
{
    Console.WriteLine("❌ Usuario no encontrado");
}
```

## 🧪 Casos Prácticos Comunes

### 1. Calculadora de IMC con clasificación

```csharp
Console.Write("Peso (kg): ");
double peso = double.Parse(Console.ReadLine());

Console.Write("Altura (m): ");
double altura = double.Parse(Console.ReadLine());

double imc = peso / (altura * altura);

Console.WriteLine("Tu IMC es: " + imc.ToString("F2"));

if (imc < 18.5)
{
    Console.WriteLine("Clasificación: Bajo peso");
    Console.WriteLine("Recomendación: Consulta con un nutriólogo");
}
else if (imc < 25)
{
    Console.WriteLine("Clasificación: Peso normal");
    Console.WriteLine("Recomendación: Mantén tus hábitos actuales");
}
else if (imc < 30)
{
    Console.WriteLine("Clasificación: Sobrepeso");
    Console.WriteLine("Recomendación: Considera una dieta balanceada");
}
else
{
    Console.WriteLine("Clasificación: Obesidad");
    Console.WriteLine("Recomendación: Consulta médica urgente");
}
```

### 2. Sistema de descuentos por volumen

```csharp
Console.Write("Cantidad de productos: ");
int cantidad = int.Parse(Console.ReadLine());

Console.Write("Precio unitario: ");
double precioUnitario = double.Parse(Console.ReadLine());

double subtotal = cantidad * precioUnitario;
double descuento = 0;
string nivelDescuento = "";

if (cantidad >= 100)
{
    descuento = 0.15;  // 15%
    nivelDescuento = "Premium (15%)";
}
else if (cantidad >= 50)
{
    descuento = 0.10;  // 10%
    nivelDescuento = "Gold (10%)";
}
else if (cantidad >= 20)
{
    descuento = 0.05;  // 5%
    nivelDescuento = "Silver (5%)";
}
else
{
    descuento = 0;     // 0%
    nivelDescuento = "Sin descuento";
}

double montoDescuento = subtotal * descuento;
double total = subtotal - montoDescuento;

Console.WriteLine("\n=== RESUMEN DE COMPRA ===");
Console.WriteLine("Cantidad: " + cantidad + " productos");
Console.WriteLine("Precio unitario: " + precioUnitario.ToString("C"));
Console.WriteLine("Subtotal: " + subtotal.ToString("C"));
Console.WriteLine("Descuento: " + nivelDescuento);
Console.WriteLine("Ahorro: " + montoDescuento.ToString("C"));
Console.WriteLine("TOTAL: " + total.ToString("C"));
```

### 3. Menú de restaurante

```csharp
Console.WriteLine("=== MENÚ DEL RESTAURANTE ===");
Console.WriteLine("1. Desayuno ($120)");
Console.WriteLine("2. Comida ($180)");
Console.WriteLine("3. Cena ($160)");
Console.WriteLine("4. Bebida ($35)");
Console.WriteLine("5. Postre ($55)");

Console.Write("Selecciona una opción: ");
int opcion = int.Parse(Console.ReadLine());

string platillo = "";
double precio = 0;

switch (opcion)
{
    case 1:
        platillo = "Desayuno completo";
        precio = 120;
        Console.WriteLine("Incluye: huevos, pan, jugo, café");
        break;
    case 2:
        platillo = "Comida del día";
        precio = 180;
        Console.WriteLine("Incluye: sopa, guisado, postre, agua");
        break;
    case 3:
        platillo = "Cena especial";
        precio = 160;
        Console.WriteLine("Incluye: ensalada, plato principal, pan");
        break;
    case 4:
        platillo = "Bebida";
        precio = 35;
        Console.WriteLine("Refrescos, agua, jugos naturales");
        break;
    case 5:
        platillo = "Postre";
        precio = 55;
        Console.WriteLine("Flan, helado, pay, gelatina");
        break;
    default:
        Console.WriteLine("Opción no válida");
        return;  // Salir del programa
}

Console.Write("¿Eres estudiante? (s/n): ");
bool esEstudiante = Console.ReadLine().ToLower() == "s";

double descuentoEstudiante = esEstudiante ? 0.10 : 0;  // 10% estudiantes
double precioFinal = precio * (1 - descuentoEstudiante);

Console.WriteLine("\n=== ORDEN ===");
Console.WriteLine("Platillo: " + platillo);
Console.WriteLine("Precio: " + precio.ToString("C"));

if (esEstudiante)
{
    Console.WriteLine("Descuento estudiante: -" + (precio * descuentoEstudiante).ToString("C"));
}

Console.WriteLine("TOTAL A PAGAR: " + precioFinal.ToString("C"));
```

## ⚠️ Errores Comunes y Cómo Evitarlos

### 1. Usar `=` en lugar de `==`

```csharp
// ❌ Error: asignación en lugar de comparación
int edad = 18;
if (edad = 18)  // Error de compilación
{
    Console.WriteLine("Mayor de edad");
}

// ✅ Correcto: usar == para comparar
if (edad == 18)
{
    Console.WriteLine("Mayor de edad");
}
```

### 2. Olvidar `break` en switch

```csharp
// ❌ Error: fall-through no intencional
int opcion = 1;
switch (opcion)
{
    case 1:
        Console.WriteLine("Opción 1");
        // Falta break - ejecutará también case 2
    case 2:
        Console.WriteLine("Opción 2");
        break;
}

// ✅ Correcto: siempre incluir break
switch (opcion)
{
    case 1:
        Console.WriteLine("Opción 1");
        break;
    case 2:
        Console.WriteLine("Opción 2");
        break;
}
```

### 3. Confundir operadores lógicos

```csharp
// ❌ Error: usar Python syntax
int edad = 25;
double salario = 3000;
if (edad >= 18 and salario > 2500)  // Error: 'and' no existe en C#
{
    Console.WriteLine("Calificado");
}

// ✅ Correcto: usar && para AND lógico
if (edad >= 18 && salario > 2500)
{
    Console.WriteLine("Calificado");
}
```

### 4. No usar llaves en if de una línea

```csharp
// ❌ Problemático: sin llaves es confuso
if (edad >= 18)
    Console.WriteLine("Mayor de edad");
    Console.WriteLine("Puede votar");  // Esta línea SIEMPRE se ejecuta

// ✅ Mejor: siempre usar llaves para claridad
if (edad >= 18)
{
    Console.WriteLine("Mayor de edad");
    Console.WriteLine("Puede votar");
}
```

## 📋 Tabla Comparativa Completa: Python vs C#

| Concepto | Python | C# |
|----------|--------|-----|
| **if básico** | `if edad >= 18:` | `if (edad >= 18) {` |
| **else if** | `elif edad < 65:` | `else if (edad < 65) {` |
| **else** | `else:` | `else {` |
| **AND lógico** | `and` | `&&` |
| **OR lógico** | `or` | `\|\|` |
| **NOT lógico** | `not` | `!` |
| **Ternario** | `valor if condicion else otro` | `condicion ? valor : otro` |
| **switch** | No nativo | `switch (variable) { case valor: }` |
| **Igualdad** | `==` | `==` |
| **Diferente** | `!=` | `!=` |

## 💡 Tips del Depurador

### 1. Usar breakpoints en condiciones
- Colocar breakpoints en cada rama del if
- Ver qué condiciones se evalúan como true/false
- Inspeccionar valores de variables en "Watch"

### 2. Evaluar expresiones complejas
- En ventana "Watch": `edad >= 18 && salario > 2500`
- Ver resultado booleano paso a paso
- Identificar qué parte de la condición falla

### 3. Seguimiento de flujo
- F10 para ejecutar paso a paso
- Ver exactamente qué rama se ejecuta
- Validar que la lógica es correcta

## 🎯 Resumen de Conceptos Clave

### Diferencias principales con Python:
1. **Paréntesis obligatorios**: `if (condicion)` vs `if condicion:`
2. **Llaves obligatorias**: `{` `}` vs indentación
3. **Operadores lógicos**: `&&` `||` `!` vs `and` `or` `not`
4. **switch statement**: C# tiene switch nativo, Python no
5. **break requerido**: en switch, cada case necesita break

### Patrones comunes:
```csharp
// Patrón de validación
if (condicion1 && condicion2)
{
    // Acción válida
}
else
{
    // Manejo de error
}

// Patrón de menú
switch (opcion)
{
    case 1:
        // Acción 1
        break;
    default:
        // Opción no válida
        break;
}

// Patrón ternario para asignación
variable = condicion ? valorTrue : valorFalse;
```

## 🎯 Siguiente Paso

¡Excelente! Ya dominas las estructuras condicionales en C#.

👉 **Continúa con**: [`ejercicios.md`](ejercicios.md) para practicar estos conceptos.
