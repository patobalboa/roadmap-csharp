# 🎮 Ejercicios: Iniciando con Windows Forms

## � Antes de Empezar - ¡Tu Kit de Supervivencia!

### 📋 **Configuración Inicial del Entorno**

#### 1. **Creando tu primer proyecto Windows Forms**
```
Visual Studio 2022 → Crear nuevo proyecto → Windows Forms App (.NET)
├── Nombre: MiPrimeraApp
├── Ubicación: Carpeta de trabajo
├── Framework: .NET 6.0 o superior
└── ✅ Crear
```

#### 2. **Configurando el Designer para máxima productividad**
```csharp
// Ve a: Herramientas → Opciones → Windows Forms Designer
☑️ Mostrar cuadrícula (Grid)
☑️ Ajustar a cuadrícula (Snap to Grid)
☑️ Mostrar guías de alineación
Grid Size: 8, 8 (recomendado)
```

---

## 💡 Mejores Prácticas y Consejos de Oro

### 🏷️ **1. Nomenclatura de Controles - ¡Nunca más "button1"!**

#### **¿Por qué es importante?**
Imagina tener 20 botones llamados `button1`, `button2`... ¡Es un caos! Una buena nomenclatura hace tu código **legible**, **mantenible** y **profesional**.

#### **Convención recomendada:**
```csharp
// Prefijo + Descripción + Tipo (opcional)
txtNombre        // TextBox para nombre
btnCalcular      // Button para calcular
lblResultado     // Label para resultado
cboCategorias    // ComboBox para categorías
lstProductos     // ListBox para productos
pnlPrincipal     // Panel principal
grpOpciones      // GroupBox para opciones
```

#### **⚡ Aplicar desde el primer momento:**
```csharp
// ❌ MAL - Nombres automáticos
private void button1_Click(object sender, EventArgs e)
{
    textBox1.Text = textBox2.Text + textBox3.Text;
}

// ✅ BIEN - Nombres descriptivos
private void btnCalcular_Click(object sender, EventArgs e)
{
    txtResultado.Text = txtNumero1.Text + txtNumero2.Text;
}
```

### 🎨 **2. Diseño de Interfaz - Principios Fundamentales**

#### **Regla de oro: "Si tu abuela no puede usarlo, rediseña"**

#### **📐 Layout y Espaciado:**
```
┌─────────────────────────────────────┐
│  🎯 Elementos bien alineados        │
│                                     │
│  Nombre:  [________________]        │
│  Email:   [________________]        │
│  Teléfono:[________________]        │
│                                     │
│           [Guardar] [Cancelar]      │
│                                     │
│  ✅ Espacios consistentes           │
│  ✅ Controles alineados             │  
│  ✅ Grupos lógicos separados        │
└─────────────────────────────────────┘
```

#### **🎨 Colores y Tipografía:**
```csharp
// Paleta de colores consistente
Color ColorPrimario = Color.FromArgb(41, 128, 185);    // Azul profesional
Color ColorSecundario = Color.FromArgb(52, 152, 219);  // Azul claro
Color ColorExito = Color.FromArgb(46, 125, 50);        // Verde
Color ColorError = Color.FromArgb(183, 28, 28);        // Rojo
Color ColorFondo = Color.FromArgb(245, 245, 245);      // Gris claro

// Fuentes legibles
this.Font = new Font("Segoe UI", 9F);                  // Fuente del sistema
lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
```

### ✅ **3. Validación de Datos - Tu Escudo Protector**

#### **¿Cuándo validar?**
- **Al perder el foco** (Leave event) - Validación inmediata
- **Al hacer click en botón** - Validación final
- **En tiempo real** (TextChanged) - Para casos específicos

#### **Ejemplos prácticos:**
```csharp
// Validación de campo vacío
private void txtNombre_Leave(object sender, EventArgs e)
{
    if (string.IsNullOrWhiteSpace(txtNombre.Text))
    {
        // Feedback visual inmediato
        txtNombre.BackColor = Color.LightPink;
        lblErrorNombre.Text = "⚠️ El nombre es requerido";
        lblErrorNombre.Visible = true;
    }
    else
    {
        // Restaurar estado normal
        txtNombre.BackColor = Color.White;
        lblErrorNombre.Visible = false;
    }
}

// Validación numérica en tiempo real
private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
{
    // Solo permite números, punto decimal y backspace
    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
    {
        e.Handled = true;
    }
}

// Validación de email con regex
private bool ValidarEmail(string email)
{
    try
    {
        var addr = new System.Net.Mail.MailAddress(email);
        return addr.Address == email;
    }
    catch
    {
        return false;
    }
}
```

### 🛡️ **4. Manejo de Errores - Nunca Rompas la Experiencia**

#### **El principio: "La aplicación nunca debe crashear"**

```csharp
// Patrón básico de manejo de errores
private void btnCalcular_Click(object sender, EventArgs e)
{
    try
    {
        // Validar entrada
        if (!ValidarDatos())
        {
            MostrarError("Por favor, revisa los datos ingresados");
            return;
        }

        // Operación principal
        double resultado = RealizarCalculo();
        
        // Mostrar resultado
        txtResultado.Text = resultado.ToString("F2");
        MostrarExito("Cálculo realizado correctamente");
    }
    catch (DivideByZeroException)
    {
        MostrarError("No se puede dividir por cero");
    }
    catch (OverflowException)
    {
        MostrarError("El número es demasiado grande");
    }
    catch (Exception ex)
    {
        MostrarError($"Error inesperado: {ex.Message}");
        // Log del error para debugging
        System.Diagnostics.Debug.WriteLine($"Error: {ex}");
    }
}

// Método helper para mostrar errores
private void MostrarError(string mensaje)
{
    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

### 🎯 **5. Experiencia de Usuario (UX) - Haz que Amen tu App**

#### **Principios fundamentales:**

##### **🔄 Feedback Inmediato:**
```csharp
// Botón que cambia mientras procesa
private async void btnProcesar_Click(object sender, EventArgs e)
{
    // Estado: Procesando
    btnProcesar.Enabled = false;
    btnProcesar.Text = "Procesando...";
    this.Cursor = Cursors.WaitCursor;
    
    try
    {
        // Operación larga
        await Task.Delay(2000); // Simula proceso
        
        // Estado: Completado
        btnProcesar.Text = "✅ Completado";
        await Task.Delay(1000);
    }
    finally
    {
        // Estado: Normal
        btnProcesar.Enabled = true;
        btnProcesar.Text = "Procesar";
        this.Cursor = Cursors.Default;
    }
}
```

##### **⌨️ Atajos de Teclado:**
```csharp
// En el constructor o Load del formulario
private void ConfigurarAtajos()
{
    // Ctrl+N para nuevo
    this.KeyPreview = true;
    this.KeyDown += Form_KeyDown;
}

private void Form_KeyDown(object sender, KeyEventArgs e)
{
    if (e.Control && e.KeyCode == Keys.N)
    {
        btnNuevo_Click(null, null);
    }
    else if (e.Control && e.KeyCode == Keys.S)
    {
        btnGuardar_Click(null, null);
    }
}
```

##### **📱 Responsividad Visual:**
```csharp
// Anclar controles para diferentes tamaños
txtDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

// O usar TableLayoutPanel para layouts complejos
```

---

## 🛠️ Herramientas y Snippets Útiles

### **📝 Snippets de Código Esenciales:**

#### **Validación rápida de TextBox:**
```csharp
private bool ValidarCampo(TextBox txt, string nombreCampo)
{
    if (string.IsNullOrWhiteSpace(txt.Text))
    {
        MessageBox.Show($"El campo {nombreCampo} es requerido", 
                       "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txt.Focus();
        return false;
    }
    return true;
}
```

#### **Limpiar formulario:**
```csharp
private void LimpiarFormulario()
{
    foreach (Control control in this.Controls)
    {
        if (control is TextBox txt)
            txt.Clear();
        else if (control is ComboBox cbo)
            cbo.SelectedIndex = -1;
        else if (control is CheckBox chk)
            chk.Checked = false;
    }
}
```

#### **Confirmar acción destructiva:**
```csharp
private bool ConfirmarAccion(string mensaje)
{
    var resultado = MessageBox.Show(mensaje, "Confirmar", 
                                   MessageBoxButtons.YesNo, 
                                   MessageBoxIcon.Question);
    return resultado == DialogResult.Yes;
}
```

### **🔧 Configuraciones Útiles:**

#### **Formulario profesional desde el inicio:**
```csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        ConfigurarFormulario();
    }
    
    private void ConfigurarFormulario()
    {
        // Centrar en pantalla
        this.StartPosition = FormStartPosition.CenterScreen;
        
        // Tamaño fijo (opcional)
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        
        // Icono personalizado (opcional)
        // this.Icon = new Icon("mi_icono.ico");
        
        // Focus inicial
        this.ActiveControl = txtPrimerCampo;
        
        // Enter actúa como Tab
        this.KeyPreview = true;
    }
}
```

---

## ⏰ Cuándo y Cómo Aplicar Cada Consejo

### **🚦 Fase 1: Planificación (5-10 minutos)**
```
├── 📝 Boceto en papel de la interfaz
├── 🏷️ Lista de controles con sus nombres
├── 🔄 Definir flujo de usuario principal
└── ✅ Identificar validaciones necesarias
```

### **🚦 Fase 2: Diseño Visual (15-20 minutos)**
```
├── 🎨 Arrastrar controles del Toolbox
├── 🏷️ Renombrar TODOS los controles importantes
├── 📐 Ajustar alineación y espaciado
└── 🎯 Configurar propiedades básicas
```

### **🚦 Fase 3: Programación (Tiempo variable)**
```
├── 🛡️ Agregar validaciones básicas
├── ⚡ Implementar funcionalidad principal
├── 🚨 Agregar manejo de errores
└── 🎨 Pulir UX (feedback, atajos, etc.)
```

### **🚦 Fase 4: Testing (10-15 minutos)**
```
├── 🧪 Probar casos normales
├── 💥 Probar casos extremos
├── 📱 Probar en diferentes tamaños
└── 👤 Probar facilidad de uso
```

---

## �📋 Instrucciones Generales

1. **Proyecto tipo**: Windows Forms App (.NET) en Visual Studio 2022
2. **Nomenclatura**: Usa nombres descriptivos para todos los controles
3. **Validación**: Siempre valida la entrada del usuario
4. **UX**: Piensa en la experiencia del usuario final
5. **Designer**: Usa el diseñador visual para crear las interfaces

---

## 🔰 Ejercicios Básicos - ¡Tus Primeras Apps!

### **Ejercicio 1: Hola Mundo Personalizado** 
**Dificultad:** ⭐  
**Tiempo estimado:** 20 minutos

Crea tu primera aplicación Windows Forms que permita al usuario ingresar su nombre y recibir un saludo personalizado.

#### 📋 **Requisitos:**
- **TextBox** para ingresar el nombre
- **Label** con instrucciones claras
- **Button** para generar el saludo
- **Label** para mostrar el resultado
- Validar que el nombre no esté vacío

#### 🎨 **Diseño sugerido:**
```
┌─────────────────────────────────────┐
│  👋 Generador de Saludos             │
├─────────────────────────────────────┤
│                                     │
│  ¿Cuál es tu nombre?                │
│  ┌─────────────────────────────────┐ │
│  │ [Escribe aquí...]               │ │
│  └─────────────────────────────────┘ │
│                                     │
│           [ ¡Saludarme! ]           │
│                                     │
│  ╔═══════════════════════════════╗ │
│  ║ ¡Hola [Nombre]!               ║ │
│  ║ ¡Bienvenido/a a Windows Forms!║ │
│  ╚═══════════════════════════════╝ │
└─────────────────────────────────────┘
```

#### ✅ **Características adicionales:**
- Saludo diferente según la hora del día
- Limpiar campos con un botón adicional
- Mostrar la fecha actual en el saludo

---

### **Ejercicio 2: Contador Interactivo**
**Dificultad:** ⭐  
**Tiempo estimado:** 25 minutos

Desarrolla un contador que permita incrementar, decrementar y resetear un número.

#### 📋 **Requisitos:**
- **Label** grande para mostrar el número actual
- **Button** para incrementar (+1)
- **Button** para decrementar (-1) 
- **Button** para resetear a 0
- **Label** que muestre si el número es par o impar

#### 🎨 **Diseño sugerido:**
```
┌─────────────────────────────────────┐
│  🔢 Contador Mágico                  │
├─────────────────────────────────────┤
│                                     │
│            📊 0 📊                  │
│         (Número Par)                │
│                                     │
│  [ - ]     [ Reset ]     [ + ]      │
│                                     │
│  Historial: 0 → 1 → 0               │
└─────────────────────────────────────┘
```

#### ✅ **Características adicionales:**
- Límites mínimo (-10) y máximo (+10)
- Cambiar color del número según su valor
- Historial de los últimos 5 cambios
- Sonido al llegar a múltiplos de 5

---

### **Ejercicio 3: Generador de Colores Aleatorios**
**Dificultad:** ⭐⭐  
**Tiempo estimado:** 30 minutos

Crea una aplicación que genere colores aleatorios y permita copiar los códigos de color.

#### 📋 **Requisitos:**
- **Panel** grande que muestre el color actual
- **Button** para generar color aleatorio
- **Labels** para mostrar códigos RGB y Hexadecimal
- **Button** para copiar código al clipboard
- **ListBox** con historial de colores generados

#### 🎨 **Funcionalidades:**
- Generar colores RGB aleatorios
- Mostrar vista previa del color
- Copiar código hex al portapapeles
- Historial de últimos 10 colores
- Información del color (claro/oscuro)

---

## 🚀 Ejercicios Intermedios - ¡Subiendo el Nivel!

### **Ejercicio 4: Calculadora Básica**
**Dificultad:** ⭐⭐  
**Tiempo estimado:** 45 minutos

Desarrolla una calculadora con operaciones básicas y una interfaz intuitiva.

#### 📋 **Requisitos:**
- **TextBox** para mostrar números y resultados
- **Buttons** para dígitos (0-9)
- **Buttons** para operaciones (+, -, ×, ÷)
- **Button** para igual (=) y limpiar (C)
- Manejo de errores (división por cero)

#### 🎨 **Layout sugerido:**
```
┌─────────────────────────────────────┐
│  🧮 Mi Calculadora                   │
├─────────────────────────────────────┤
│  ┌─────────────────────────────────┐ │
│  │              0              │ │ │
│  └─────────────────────────────────┘ │
│                                     │
│  [ C ] [ ± ] [ % ] [ ÷ ]           │
│  [ 7 ] [ 8 ] [ 9 ] [ × ]           │
│  [ 4 ] [ 5 ] [ 6 ] [ - ]           │
│  [ 1 ] [ 2 ] [ 3 ] [ + ]           │
│  [   0   ] [ . ] [ = ]             │
└─────────────────────────────────────┘
```

#### ✅ **Características adicionales:**
- Historial de operaciones
- Memoria (M+, M-, MR, MC)
- Operaciones científicas básicas
- Modo oscuro/claro

---

### **Ejercicio 5: Lista de Tareas (ToDo List)**
**Dificultad:** ⭐⭐  
**Tiempo estimado:** 50 minutos

Crea una aplicación completa para gestionar tareas pendientes.

#### 📋 **Requisitos:**
- **TextBox** para nueva tarea
- **Button** para agregar tarea
- **ListBox** o **CheckedListBox** para mostrar tareas
- **Buttons** para marcar como completada y eliminar
- **Labels** para estadísticas (total, pendientes, completadas)

#### 🎨 **Funcionalidades:**
- Agregar nuevas tareas
- Marcar tareas como completadas
- Eliminar tareas
- Contador de tareas pendientes/completadas
- Limpiar todas las tareas completadas

#### 🎯 **Interfaz sugerida:**
```
┌─────────────────────────────────────┐
│  ✅ Mis Tareas                       │
├─────────────────────────────────────┤
│  Nueva tarea:                       │
│  ┌─────────────────────────────────┐ │
│  │ [Escribe tu tarea...]           │ │
│  └─────────────────────────────────┘ │
│                [ Agregar ]          │
│                                     │
│  📋 Tareas:                         │
│  ┌─────────────────────────────────┐ │
│  │ ☐ Estudiar Windows Forms        │ │
│  │ ☑ Hacer ejercicios             │ │
│  │ ☐ Crear mi primera app         │ │
│  └─────────────────────────────────┘ │
│                                     │
│  [ Completar ] [ Eliminar ]         │
│                                     │
│  📊 Total: 3 | Pendientes: 2 | ✅: 1 │
└─────────────────────────────────────┘
```

---

### **Ejercicio 6: Conversor de Unidades Avanzado**
**Dificultad:** ⭐⭐⭐  
**Tiempo estimado:** 60 minutos

Desarrolla un conversor completo con múltiples categorías de unidades.

#### 📋 **Requisitos:**
- **ComboBox** para seleccionar categoría (Longitud, Peso, Temperatura)
- **ComboBoxes** para unidad origen y destino
- **TextBox** para valor a convertir
- **TextBox** readonly para resultado
- **Button** para intercambiar unidades
- Validación numérica completa

#### 🎨 **Categorías a implementar:**

**Longitud:**
- Metro, Kilómetro, Centímetro, Milímetro
- Pie, Pulgada, Yarda, Milla

**Peso:**
- Kilogramo, Gramo, Libra, Onza

**Temperatura:**
- Celsius, Fahrenheit, Kelvin

#### ✅ **Características adicionales:**
- Conversión automática mientras escribe
- Historial de conversiones
- Copiar resultado al clipboard
- Intercambiar unidades con un click

---

## 🏆 Ejercicios Avanzados - ¡Para Expertos!

### **Ejercicio 7: Juego de Memoria (Memory Game)**
**Dificultad:** ⭐⭐⭐  
**Tiempo estimado:** 90 minutos

Crea un juego de memoria con cartas que se voltean para encontrar parejas.

#### 📋 **Requisitos:**
- Grilla de **Buttons** representando cartas (4x4 = 16 cartas)
- Sistema de puntuación y intentos
- Cronómetro para medir tiempo
- **Labels** para mostrar estadísticas
- Diferentes niveles de dificultad

#### 🎮 **Mecánicas del juego:**
- Al inicio, todas las cartas están boca abajo
- Click en carta la voltea y muestra símbolo
- Si dos cartas coinciden, quedan volteadas
- Si no coinciden, se voltean automáticamente
- Ganar cuando todas las parejas están encontradas

#### 🎨 **Símbolos sugeridos:**
🎯 🎮 🎲 🎪 🎨 🎭 🎸 🎺

#### ✅ **Características adicionales:**
- Diferentes tamaños de grilla (3x4, 4x4, 5x4)
- Efectos sonoros para match/no match
- Ranking de mejores tiempos
- Animaciones simples para voltear cartas

---

### **Ejercicio 8: Editor de Texto Simple**
**Dificultad:** ⭐⭐⭐  
**Tiempo estimado:** 75 minutos

Desarrolla un editor de texto básico con funciones de archivo y formato.

#### 📋 **Requisitos:**
- **TextBox** multilínea grande para editar texto
- **MenuStrip** con menús Archivo y Formato
- **StatusStrip** para mostrar información del documento
- Funciones: Nuevo, Abrir, Guardar, Guardar Como
- Formato: Fuente, Tamaño, Color, Negrita, Cursiva

#### 🎨 **Estructura de menús:**
```
Archivo
├── Nuevo         (Ctrl+N)
├── Abrir         (Ctrl+O)  
├── Guardar       (Ctrl+S)
├── Guardar Como  (Ctrl+Shift+S)
├── ─────────────
└── Salir         (Alt+F4)

Formato
├── Fuente...
├── Color...
├── ─────────────
├── Negrita       (Ctrl+B)
├── Cursiva       (Ctrl+I)
└── Subrayado     (Ctrl+U)

Ver
├── Barra de estado
└── Zoom
    ├── Acercar   (Ctrl++)
    ├── Alejar    (Ctrl+-)
    └── Normal    (Ctrl+0)
```

#### ✅ **Características adicionales:**
- Contador de caracteres y palabras en tiempo real
- Buscar y reemplazar texto
- Modo oscuro/claro
- Zoom del texto
- Verificar cambios no guardados al cerrar

---

### **Ejercicio 9: Sistema de Gestión de Contactos**
**Dificultad:** ⭐⭐⭐⭐  
**Tiempo estimado:** 120 minutos

Crea una aplicación completa para gestionar una libreta de contactos.

#### 📋 **Requisitos principales:**
- **DataGridView** para mostrar lista de contactos
- **Forms** secundarios para agregar/editar contactos
- Campos: Nombre, Apellido, Teléfono, Email, Dirección, Notas
- Funciones: Agregar, Editar, Eliminar, Buscar
- Validación completa de datos

#### 🗂️ **Estructura de datos:**
```csharp
public class Contacto
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
    public string Notas { get; set; }
    public DateTime FechaCreacion { get; set; }
}
```

#### 🎨 **Diseño de interfaz:**

**Formulario Principal:**
```
┌─────────────────────────────────────────────────────────┐
│  📇 Gestor de Contactos                [_] [□] [×]      │
├─────────────────────────────────────────────────────────┤
│  🔍 [Buscar contacto...]          [ Nuevo ] [ Editar ] │
│                                                         │
│  ┌─────────────────────────────────────────────────────┐ │
│  │ Nombre    │ Apellido   │ Teléfono    │ Email       │ │
│  ├─────────────────────────────────────────────────────┤ │
│  │ Juan      │ Pérez      │ 123-456-789 │ j@email.com │ │
│  │ María     │ González   │ 987-654-321 │ m@email.com │ │
│  │ ...       │ ...        │ ...         │ ...         │ │
│  └─────────────────────────────────────────────────────┘ │
│                                                         │
│  [ Eliminar ] [ Exportar ] [ Importar ]  Total: 25     │
└─────────────────────────────────────────────────────────┘
```

#### ✅ **Características adicionales:**
- Exportar/Importar desde CSV
- Fotos de contactos
- Categorías (Familia, Trabajo, Amigos)
- Historial de comunicación
- Backup automático

---

## 🎯 Proyecto Final - ¡Tu Obra Maestra!

### **Ejercicio 10: Sistema POS (Point of Sale) Básico**
**Dificultad:** ⭐⭐⭐⭐⭐  
**Tiempo estimado:** 180 minutos (3 horas)

Desarrolla un sistema de punto de venta completo para una pequeña tienda.

#### 📋 **Módulos requeridos:**

**1. Gestión de Productos:**
- Alta, baja, modificación de productos
- Código, nombre, precio, stock, categoría
- Búsqueda y filtrado

**2. Ventas:**
- Interfaz de caja registradora
- Escaneo/búsqueda de productos
- Cálculo de totales e impuestos
- Múltiples formas de pago

**3. Reportes:**
- Ventas del día
- Productos más vendidos
- Inventario bajo stock
- Ingresos por período

#### 🏪 **Diseño sugerido:**

**Ventana Principal - Venta:**
```
┌───────────────────────────────────────────────────────────────┐
│  🏪 Sistema POS - Tienda ABC    [Productos] [Reportes] [Config]│
├───────────────────────────────────────────────────────────────┤
│                                                               │
│  🔍 [Buscar producto...]                    Cliente: General  │
│                                                               │
│  ┌─── Productos Disponibles ─────┐  ┌─── Venta Actual ─────┐ │
│  │ [001] Coca Cola - $2.50      │  │ Coca Cola      $2.50 │ │
│  │ [002] Agua      - $1.00      │  │ Pan Integral   $3.20 │ │
│  │ [003] Pan Integral - $3.20   │  │ Leche          $4.50 │ │
│  │ ...                          │  │ ──────────────────── │ │
│  │                              │  │ Subtotal:    $10.20 │ │
│  │ [Agregar Producto]           │  │ IVA (21%):    $2.14 │ │
│  └──────────────────────────────┘  │ TOTAL:       $12.34 │ │
│                                    │                      │ │
│  💰 Pago: [Efectivo ▼] $20.00      │ [ - ] [Cantidad] [ X ] │
│     Cambio: $7.66                  └──────────────────────┘ │
│                                                               │
│  [Cancelar Venta]  [Procesar Venta]  [Imprimir Ticket]       │
│                                                               │
│  🕐 15:30:45  👤 Usuario: Admin  📊 Ventas hoy: $458.30      │
└───────────────────────────────────────────────────────────────┘
```

#### 🗃️ **Estructura de datos:**
```csharp
public class Producto
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public string Categoria { get; set; }
}

public class ItemVenta
{
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }
    public decimal Subtotal => Producto.Precio * Cantidad;
}

public class Venta
{
    public int NumeroVenta { get; set; }
    public DateTime Fecha { get; set; }
    public List<ItemVenta> Items { get; set; }
    public decimal Total { get; set; }
    public string FormaPago { get; set; }
}
```

#### ✅ **Características mínimas:**
- Gestión completa de productos
- Proceso de venta con múltiples items
- Cálculo automático de totales
- Impresión de tickets
- Reportes básicos

#### 🌟 **Características avanzadas:**
- Código de barras simulado
- Descuentos y promociones
- Múltiples formas de pago
- Base de datos simple (archivos)
- Sistema de usuarios

---

## 📊 Criterios de Evaluación

### **Funcionalidad (35%)**
- [ ] Todas las características implementadas
- [ ] Sin errores durante uso normal
- [ ] Validaciones apropiadas
- [ ] Flujo de trabajo intuitivo

### **Diseño de Interfaz (25%)**
- [ ] Controles bien organizados
- [ ] Uso efectivo del espacio
- [ ] Colores y fuentes apropiados
- [ ] Navegación clara

### **Calidad del Código (25%)**
- [ ] Nombres descriptivos para controles
- [ ] Event handlers bien estructurados
- [ ] Manejo de excepciones
- [ ] Código limpio y comentado

### **Experiencia de Usuario (15%)**
- [ ] Aplicación fácil de usar
- [ ] Mensajes informativos claros
- [ ] Respuesta adecuada a errores
- [ ] Diseño atractivo

---

##  ¡A Programar!

¡Estos ejercicios te darán una base sólida en Windows Forms! Empieza con los básicos y ve subiendo de nivel gradualmente. 

**Recuerda:** La práctica hace al maestro. ¡No tengas miedo de experimentar y hacer tus aplicaciones únicas! 

💪 **¡Tu primera aplicación Windows Forms te está esperando!** 🎯