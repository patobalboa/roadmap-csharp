# 🎮 Ejercicios: Iniciando con Windows Forms

## 📋 Menú de Ejercicios por Nivel

### 🚀 **Ejercicios Cortos para Actividad en Clase**

- **[EC-01](#ec-01-hola-mundo-express)** - Hola Mundo Express
- **[EC-02](#ec-02-contador-simple)** - Contador Simple  
- **[EC-03](#ec-03-cambio-de-colores)** - Cambio de Colores
- **[EC-04](#ec-04-validador-de-nombre)** - Validador de Nombre
- **[EC-05](#ec-05-lista-interactiva)** - Lista Interactiva

### 📚 **Ejercicios para Practicar**

#### 🔰 **Básico** *(20-30 minutos cada uno)*
- **[EB-01](#eb-01-generador-de-saludos)** - Generador de Saludos Personalizado
- **[EB-02](#eb-02-calculadora-simple)** - Calculadora de Operaciones Básicas
- **[EB-03](#eb-03-conversor-de-temperatura)** - Conversor de Temperatura

#### 🚀 **Intermedio** *(45-60 minutos cada uno)*
- **[EI-01](#ei-01-lista-de-tareas)** - Lista de Tareas (ToDo List)
- **[EI-02](#ei-02-calculadora-avanzada)** - Calculadora con Historial
- **[EI-03](#ei-03-administrador-de-contactos)** - Administrador de Contactos Simple

#### 🏆 **Avanzado** *(90+ minutos cada uno)*
- **[EA-01](#ea-01-juego-de-memoria)** - Juego de Memory con Timer
- **[EA-02](#ea-02-editor-de-texto)** - Editor de Texto con Menús
- **[EA-03](#ea-03-sistema-pos)** - Sistema POS (Punto de Venta)

---

# 🚀 Ejercicios Cortos para Actividad en Clase

## EC-01: Hola Mundo Express
**⏰ Tiempo:** 10 minutos | **🎯 Nivel:** Principiante

### Objetivo
Crear tu primera ventana con un botón que muestre un mensaje personalizado.

### Lo que necesitas
- 1 Label con texto "¡Presiona el botón!"
- 1 Button con texto "Saludar"

### Resultado esperado
Al presionar el botón → aparece MessageBox con "¡Hola desde Windows Forms!"

---

## EC-02: Contador Simple  
**⏰ Tiempo:** 15 minutos | **🎯 Nivel:** Principiante

### Objetivo
Botones para sumar y restar que muestren el resultado en tiempo real.

### Lo que necesitas
- 1 Label grande para mostrar el número (empezar en 0)
- 1 Button con texto "+" 
- 1 Button con texto "-"

### Funcionalidad
- Botón "+" aumenta el número en 1
- Botón "-" disminuye el número en 1
- El número se actualiza inmediatamente

---

## EC-03: Cambio de Colores
**⏰ Tiempo:** 12 minutos | **🎯 Nivel:** Principiante  

### Objetivo
Botones que cambien el color de fondo del formulario.

### Lo que necesitas
- 3 Buttons: "Rojo", "Verde", "Azul"
- 1 Button: "Normal" (para volver al color original)

### Funcionalidad
Cada botón cambia el color de fondo del formulario al color correspondiente.

---

## EC-04: Validador de Nombre
**⏰ Tiempo:** 15 minutos | **🎯 Nivel:** Principiante

### Objetivo  
TextBox que valide si el texto ingresado es un nombre válido.

### Lo que necesitas
- 1 Label: "Ingresa tu nombre:"
- 1 TextBox para escribir
- 1 Label para mostrar resultado (inicialmente vacío)

### Funcionalidad
- Si el TextBox está vacío → "⚠️ Nombre requerido"
- Si tiene texto → "✅ Nombre válido: [texto]"
- La validación ocurre al escribir (evento TextChanged)

---

## EC-05: Lista Interactiva
**⏰ Tiempo:** 15 minutos | **🎯 Nivel:** Principiante

### Objetivo
Agregar y quitar elementos de una lista con botones.

### Lo que necesitas
- 1 TextBox para escribir nombres de frutas
- 1 Button "Agregar"
- 1 ListBox para mostrar las frutas
- 1 Button "Quitar Seleccionado"

### Funcionalidad
- Agregar: toma el texto del TextBox y lo agrega a la ListBox
- Quitar: elimina el elemento seleccionado de la ListBox

---

# 📚 Ejercicios para Practicar

# 🔰 Básico

## EB-01: Generador de Saludos Personalizado
**⏰ Tiempo:** 25 minutos | **🎯 Nivel:** Básico

### Descripción
Aplicación que genere saludos personalizados según la hora del día y el nombre del usuario.

### Controles necesarios
- **Label:** "¿Cuál es tu nombre?"
- **TextBox:** Para ingresar nombre
- **Button:** "¡Saludarme!"
- **Label:** Para mostrar resultado (Font más grande)
- **Button:** "Limpiar"

### Funcionalidades
1. Validar que el nombre no esté vacío
2. Generar saludo según la hora:
   - 6-12: "¡Buenos días, [nombre]!"
   - 12-18: "¡Buenas tardes, [nombre]!" 
   - 18-24: "¡Buenas noches, [nombre]!"
   - 0-6: "¡Muy buenas madrugadas, [nombre]!"
3. Mostrar también la fecha actual
4. Botón limpiar que borre todo

### Bonus
- Cambiar color del saludo según la hora
- Agregar emojis según el momento del día

---

## EB-02: Calculadora Simple  
**⏰ Tiempo:** 30 minutos | **🎯 Nivel:** Básico

### Descripción
Calculadora básica con las 4 operaciones fundamentales.

### Controles necesarios
- **2 TextBox:** Para números
- **4 Buttons:** +, -, ×, ÷
- **Label:** Para mostrar resultado
- **Button:** Limpiar
- **Labels:** Para identificar "Número 1", "Número 2", "Resultado"

### Funcionalidades
1. Validar que ambos números sean válidos
2. Realizar la operación seleccionada
3. Mostrar resultado con 2 decimales
4. Manejar división por cero
5. Limpiar todos los campos

### Validaciones requeridas
- Solo permitir números en los TextBox
- Mostrar mensajes de error claros
- No permitir operaciones con campos vacíos

---

## EB-03: Conversor de Temperatura
**⏰ Tiempo:** 25 minutos | **🎯 Nivel:** Básico

### Descripción
Convertir temperaturas entre Celsius, Fahrenheit y Kelvin.

### Controles necesarios
- **TextBox:** Temperatura a convertir
- **3 RadioButtons:** Celsius, Fahrenheit, Kelvin (origen)
- **3 CheckBoxes:** Para seleccionar conversiones destino
- **Button:** "Convertir"
- **ListBox:** Para mostrar todos los resultados
- **Button:** "Limpiar"

### Funcionalidades
1. Seleccionar escala de origen (solo una)
2. Seleccionar escalas de destino (una o más)
3. Mostrar todas las conversiones en la ListBox
4. Fórmulas:
   - C a F: (C × 9/5) + 32
   - C a K: C + 273.15
   - F a C: (F - 32) × 5/9
   - Y las combinaciones restantes

---

# 🚀 Intermedio

## EI-01: Lista de Tareas (ToDo List)
**⏰ Tiempo:** 50 minutos | **🎯 Nivel:** Intermedio

### Descripción
Aplicación completa para gestionar tareas pendientes con estadísticas.

### Controles necesarios
- **TextBox:** Nueva tarea
- **Button:** "Agregar Tarea"
- **CheckedListBox:** Lista de tareas
- **3 Buttons:** "Completar", "Eliminar", "Limpiar Completadas"
- **3 Labels:** Total, Pendientes, Completadas (con contadores)
- **ProgressBar:** Progreso visual de completitud

### Funcionalidades
1. Agregar nuevas tareas (no vacías, no duplicadas)
2. Marcar tareas como completadas
3. Eliminar tareas seleccionadas
4. Limpiar solo las completadas
5. Actualizar contadores automáticamente
6. Barra de progreso que muestre % de completitud

### Características adicionales
- Confirmar eliminación con MessageBox
- Cambiar color de tareas completadas
- Atajos de teclado (Enter para agregar)

---

## EI-02: Calculadora Avanzada
**⏰ Tiempo:** 60 minutos | **🎯 Nivel:** Intermedio

### Descripción
Calculadora con historial de operaciones y funciones adicionales.

### Controles necesarios
- **TextBox:** Display principal
- **16 Buttons:** Dígitos 0-9, operaciones +,-,×,÷, =, C
- **ListBox:** Historial de operaciones
- **4 Buttons:** M+, M-, MR, MC (memoria)
- **Label:** Indicador de memoria
- **Button:** "Limpiar Historial"

### Funcionalidades
1. Calculadora completamente funcional
2. Historial de todas las operaciones
3. Sistema de memoria (guardar, sumar, restar, recuperar)
4. Soporte para operaciones en cadena
5. Manejo de errores elegante

### Características técnicas
- Validar entrada numérica
- Manejar operadores consecutivos
- Precisión decimal adecuada
- Interface similar a calculadora de Windows

---

## EI-03: Administrador de Contactos Simple
**⏰ Tiempo:** 55 minutos | **🎯 Nivel:** Intermedio

### Descripción
Sistema básico para gestionar información de contactos personales.

### Controles necesarios
- **4 TextBoxes:** Nombre, Apellido, Teléfono, Email
- **1 TextBox multilínea:** Notas
- **DataGridView:** Lista de contactos
- **4 Buttons:** Agregar, Editar, Eliminar, Limpiar
- **TextBox:** Buscador
- **Label:** Contador de contactos

### Funcionalidades
1. Agregar contactos con validación completa
2. Editar contacto seleccionado
3. Eliminar con confirmación
4. Búsqueda en tiempo real (nombre o apellido)
5. Mostrar contactos en grilla organizada
6. Validar formato de email y teléfono

### Validaciones requeridas
- Nombre y apellido obligatorios
- Email con formato válido
- Teléfono solo números y guiones
- No duplicar contactos (mismo nombre y apellido)

---

# 🏆 Avanzado

## EA-01: Juego de Memory con Timer
**⏰ Tiempo:** 90 minutos | **🎯 Nivel:** Avanzado

### Descripción
Juego completo de memoria con cartas, puntuación y niveles de dificultad.

### Controles necesarios
- **16 Buttons:** Cartas (4x4)
- **Timer:** Cronómetro
- **Labels:** Tiempo, Intentos, Parejas encontradas
- **ComboBox:** Nivel de dificultad
- **2 Buttons:** Nuevo Juego, Reiniciar
- **ProgressBar:** Progreso del juego

### Funcionalidades
1. Grilla de cartas con símbolos ocultos
2. Cronómetro que cuenta tiempo transcurrido
3. Sistema de puntuación (menos tiempo = más puntos)
4. Diferentes niveles (3x4, 4x4, 5x4)
5. Animaciones básicas (voltear cartas)
6. Tabla de mejores tiempos

### Mecánica del juego
- Click revela carta por 1 segundo
- Dos cartas iguales = pareja encontrada
- Dos cartas diferentes = se ocultan automáticamente
- Ganar = encontrar todas las parejas
- Ranking por tiempo y nivel

---

## EA-02: Editor de Texto con Menús
**⏰ Tiempo:** 85 minutos | **🎯 Nivel:** Avanzado

### Descripción
Editor de texto básico con funcionalidades de archivo y formato.

### Controles necesarios
- **TextBox multilínea:** Área de edición principal
- **MenuStrip:** Menús Archivo, Edición, Formato, Ver
- **StatusStrip:** Barra de estado
- **FontDialog, ColorDialog, OpenFileDialog, SaveFileDialog**

### Funcionalidades - Menú Archivo
1. Nuevo (Ctrl+N)
2. Abrir (Ctrl+O) 
3. Guardar (Ctrl+S)
4. Guardar Como (Ctrl+Shift+S)
5. Salir (Alt+F4)

### Funcionalidades - Formato
1. Cambiar fuente
2. Cambiar color de texto
3. Negrita, Cursiva, Subrayado
4. Alineación (Izquierda, Centro, Derecha)

### Características adicionales
- Detectar cambios no guardados
- Contador de palabras y caracteres en tiempo real
- Buscar y reemplazar texto
- Zoom del texto
- Configurar margins y wrap de línea

---

## EA-03: Sistema POS (Punto de Venta)
**⏰ Tiempo:** 120 minutos | **🎯 Nivel:** Avanzado

### Descripción
Sistema completo de punto de venta para pequeña tienda con inventario básico.

### Controles necesarios
- **DataGridView:** Productos disponibles
- **DataGridView:** Items de venta actual
- **TextBox:** Búsqueda de productos
- **Labels:** Subtotal, IVA, Total
- **ComboBox:** Forma de pago
- **NumericUpDown:** Cantidad
- **Multiple Buttons:** Agregar, Quitar, Procesar Venta, Nueva Venta

### Módulos requeridos

#### 1. Gestión de Productos
- Lista predefinida de productos (código, nombre, precio, stock)
- Búsqueda rápida por código o nombre
- Actualización automática de stock

#### 2. Proceso de Venta
- Agregar productos al ticket actual
- Modificar cantidades
- Calcular automáticamente subtotal, IVA (21%), total
- Validar stock disponible

#### 3. Finalización
- Procesar venta completa
- Actualizar inventario
- Mostrar cambio si es efectivo
- Limpiar para nueva venta

### Funcionalidades técnicas
- Validación completa de datos
- Manejo de stock insuficiente
- Cálculos precisos con decimales
- Interface intuitiva tipo caja registradora

---

## 📊 Criterios de Evaluación

### **Funcionalidad (40%)**
- ✅ Todas las características implementadas correctamente
- ✅ Sin errores durante uso normal
- ✅ Validaciones apropiadas funcionando
- ✅ Flujo de trabajo intuitivo

### **Diseño de Interfaz (30%)**
- ✅ Controles bien organizados y alineados
- ✅ Uso efectivo del espacio disponible
- ✅ Colores y fuentes apropiados y consistentes
- ✅ Navegación clara y lógica

### **Calidad del Código (20%)**
- ✅ Nombres descriptivos para controles y variables
- ✅ Event handlers bien estructurados
- ✅ Manejo adecuado de excepciones
- ✅ Código limpio y comentado

### **Experiencia de Usuario (10%)**
- ✅ Aplicación fácil de usar e intuitiva
- ✅ Mensajes informativos claros
- ✅ Respuesta adecuada a errores
- ✅ Diseño atractivo y profesional

---

## 🚀 ¡A Programar!

¡Estos ejercicios te darán una base sólida en Windows Forms! 

**💡 Consejos finales:**
- Empieza con los ejercicios de clase para dominar lo básico
- Practica con los básicos antes de avanzar
- Los ejercicios avanzados son desafiantes, ¡tómate tu tiempo!
- No tengas miedo de experimentar y personalizar

💪 **¡Tu primera aplicación Windows Forms te está esperando!** 🎯