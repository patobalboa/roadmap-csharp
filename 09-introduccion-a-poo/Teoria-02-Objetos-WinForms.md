# 📖 Teoría 02: Trabajando con Objetos en Windows Forms

## 🎯 Objetivos de Aprendizaje
Al finalizar esta lección, podrás:
- Entender qué es un objeto y cómo se diferencia de una clase
- Crear múltiples objetos desde una misma clase
- Almacenar y manipular objetos en memoria
- Usar objetos para construir aplicaciones Windows Forms

## 🤔 ¿Qué es un Objeto?

### Analogía de la Vida Real

Imagina que tienes una **receta de pastel** (esto es como una CLASE):
- La receta dice qué ingredientes llevar
- La receta explica los pasos

Pero cuando SIGUES esa receta y horneas un pastel, **ESO es un OBJETO**.

```
┌─────────────────────────────────────────────────────────┐
│  📜 RECETA (CLASE)                                      │
│  ─────────────────                                      │
│  Clase: Pastel                                          │
│  - sabor                                                │
│  - tamaño                                               │
│  - Hornear()                                            │
└─────────────────────────────────────────────────────────┘
              │
              │ Usamos la receta 3 veces
              ↓
┌──────────────┐   ┌──────────────┐   ┌──────────────┐
│ 🍰 OBJETO 1  │   │ 🍰 OBJETO 2  │   │ 🍰 OBJETO 3  │
│ ────────────│   │ ────────────│   │ ────────────│
│ sabor: Fresa │   │ sabor: Choco │   │ sabor: Vain  │
│ tamaño: Gde  │   │ tamaño: Med  │   │ tamaño: Peq  │
└──────────────┘   └──────────────┘   └──────────────┘
```

### Diferencia Clave
- **CLASE**: El plano, la plantilla, el molde (solo existe 1)
- **OBJETO**: La cosa real que construyes (puedes hacer muchos)

## 📦 Crear un Objeto: Paso a Paso

### Paso 1: Tener una Clase

Primero necesitas una clase. Usemos esta clase **Estudiante**:

```csharp
public class Estudiante
{
    // Propiedades
    public string Nombre { get; set; }
    public int Nota { get; set; }
    
    // Constructor
    public Estudiante()
    {
        Nombre = "";
        Nota = 0;
    }
    
    // Método
    public string ObtenerEstado()
    {
        if (Nota >= 60)
            return "Aprobado";
        else
            return "Reprobado";
    }
}
```

### Paso 2: Crear el Objeto

Para crear un objeto usamos la palabra clave **`new`**:

```csharp
// Sintaxis:
// TipoDeDato nombreVariable = new Constructor();

Estudiante estudiante1 = new Estudiante();
```

**Visual del proceso:**
```
┌─────────────────────────────────────────────┐
│  MEMORIA DE LA COMPUTADORA                  │
│                                             │
│  estudiante1 ──────→ 📦 Objeto Estudiante  │
│                         Nombre: ""          │
│                         Nota: 0             │
│                                             │
└─────────────────────────────────────────────┘
```

### Paso 3: Darle Valores al Objeto

```csharp
estudiante1.Nombre = "Ana García";
estudiante1.Nota = 85;
```

**Ahora la memoria se ve así:**
```
┌─────────────────────────────────────────────┐
│  MEMORIA                                    │
│                                             │
│  estudiante1 ──────→ 📦 Objeto Estudiante  │
│                         Nombre: "Ana García"│
│                         Nota: 85            │
│                                             │
└─────────────────────────────────────────────┘
```

### Paso 4: Usar los Métodos del Objeto

```csharp
string resultado = estudiante1.ObtenerEstado();
// resultado ahora tiene "Aprobado"
```

## 🎭 Múltiples Objetos de la Misma Clase

¡Aquí está la magia! Puedes crear MUCHOS objetos de la misma clase:

```csharp
// Crear 3 estudiantes diferentes
Estudiante est1 = new Estudiante();
est1.Nombre = "Ana";
est1.Nota = 85;

Estudiante est2 = new Estudiante();
est2.Nombre = "Luis";
est2.Nota = 55;

Estudiante est3 = new Estudiante();
est3.Nombre = "María";
est3.Nota = 92;
```

**Visual en memoria:**
```
┌─────────────────────────────────────────────────────────┐
│  MEMORIA DE LA COMPUTADORA                              │
│                                                         │
│  est1 ────→ 📦 Objeto 1          (Independiente)       │
│                Nombre: "Ana"                            │
│                Nota: 85                                 │
│                                                         │
│  est2 ────→ 📦 Objeto 2          (Independiente)       │
│                Nombre: "Luis"                           │
│                Nota: 55                                 │
│                                                         │
│  est3 ────→ 📦 Objeto 3          (Independiente)       │
│                Nombre: "María"                          │
│                Nota: 92                                 │
│                                                         │
└─────────────────────────────────────────────────────────┘
```

**¡IMPORTANTE!** Cada objeto es INDEPENDIENTE. Cambiar `est1.Nota` NO afecta a `est2.Nota`.

## 💡 Ejemplo Completo con Windows Forms

### Clase Producto

```csharp
public class Producto
{
    // Propiedades
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    
    // Constructor vacío
    public Producto()
    {
        Codigo = "";
        Nombre = "";
        Precio = 0;
        Stock = 0;
    }
    
    // Constructor con parámetros
    public Producto(string codigo, string nombre, decimal precio, int stock)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }
    
    // Métodos
    public decimal CalcularTotal(int cantidad)
    {
        return Precio * cantidad;
    }
    
    public bool HayStock(int cantidad)
    {
        return Stock >= cantidad;
    }
    
    public string ObtenerInfo()
    {
        return $"{Codigo} - {Nombre}\n" +
               $"Precio: ${Precio:N2}\n" +
               $"Stock: {Stock} unidades";
    }
}
```

### Usando Objetos en el Formulario

**Diseño del Form:**
```
┌────────────────────────────────────────┐
│  Sistema de Productos                  │
├────────────────────────────────────────┤
│                                        │
│  Código:    [txtCodigo  ]             │
│  Nombre:    [txtNombre  ]             │
│  Precio:    [txtPrecio  ]             │
│  Stock:     [txtStock   ]             │
│                                        │
│  [btnCrearProducto]  [btnMostrarInfo] │
│                                        │
│  ┌──────────────────────────────────┐ │
│  │  txtResultado                    │ │
│  │  (MultiLine)                     │ │
│  │                                  │ │
│  └──────────────────────────────────┘ │
└────────────────────────────────────────┘
```

**Código del formulario:**

```csharp
public partial class Form1 : Form
{
    // Variable para guardar el objeto producto
    private Producto productoActual;
    
    public Form1()
    {
        InitializeComponent();
    }
    
    private void btnCrearProducto_Click(object sender, EventArgs e)
    {
        // Validar campos
        if (string.IsNullOrWhiteSpace(txtCodigo.Text))
        {
            MessageBox.Show("Ingrese un código");
            return;
        }
        
        // Crear el objeto con el constructor con parámetros
        productoActual = new Producto(
            txtCodigo.Text,
            txtNombre.Text,
            decimal.Parse(txtPrecio.Text),
            int.Parse(txtStock.Text)
        );
        
        MessageBox.Show("¡Producto creado exitosamente!");
    }
    
    private void btnMostrarInfo_Click(object sender, EventArgs e)
    {
        if (productoActual == null)
        {
            MessageBox.Show("Primero cree un producto");
            return;
        }
        
        // Usar el método del objeto
        txtResultado.Text = productoActual.ObtenerInfo();
        
        // Usar otro método
        bool hayStock = productoActual.HayStock(5);
        txtResultado.Text += $"\n\n¿Hay stock para 5 unidades? {(hayStock ? "Sí" : "No")}";
        
        // Calcular un total
        decimal total = productoActual.CalcularTotal(5);
        txtResultado.Text += $"\nTotal por 5 unidades: ${total:N2}";
    }
}
```

## 🎯 Ejercicio Guiado: Lista de Tareas

Vamos a crear una aplicación para gestionar tareas usando objetos.

### Paso 1: Crear la Clase Tarea

```csharp
public class Tarea
{
    // Propiedades
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public bool Completada { get; set; }
    public DateTime FechaCreacion { get; set; }
    
    // Constructor
    public Tarea(string titulo, string descripcion)
    {
        Titulo = titulo;
        Descripcion = descripcion;
        Completada = false;
        FechaCreacion = DateTime.Now;
    }
    
    // Métodos
    public void Completar()
    {
        Completada = true;
    }
    
    public string ObtenerResumen()
    {
        string estado = Completada ? "✓ Completada" : "○ Pendiente";
        return $"{estado} - {Titulo}\n{Descripcion}\nCreada: {FechaCreacion:dd/MM/yyyy}";
    }
}
```

### Paso 2: Diseño del Formulario

```
┌──────────────────────────────────────────┐
│  📋 Gestor de Tareas                     │
├──────────────────────────────────────────┤
│                                          │
│  Nueva Tarea:                            │
│  Título:       [txtTitulo         ]      │
│  Descripción:  [txtDescripcion    ]      │
│                                          │
│  [btnAgregarTarea]  [btnCompletar]       │
│                                          │
│  Tareas:                                 │
│  ┌────────────────────────────────────┐ │
│  │ lstTareas                          │ │
│  │                                    │ │
│  │                                    │ │
│  └────────────────────────────────────┘ │
│                                          │
│  Detalle:                                │
│  ┌────────────────────────────────────┐ │
│  │ txtDetalle                         │ │
│  │                                    │ │
│  └────────────────────────────────────┘ │
└──────────────────────────────────────────┘
```

### Paso 3: Código del Formulario

```csharp
public partial class FormTareas : Form
{
    // Lista para guardar múltiples objetos Tarea
    private List<Tarea> listaTareas;
    
    public FormTareas()
    {
        InitializeComponent();
        listaTareas = new List<Tarea>();
    }
    
    private void btnAgregarTarea_Click(object sender, EventArgs e)
    {
        // Validar
        if (string.IsNullOrWhiteSpace(txtTitulo.Text))
        {
            MessageBox.Show("Ingrese un título");
            return;
        }
        
        // Crear nuevo objeto Tarea
        Tarea nuevaTarea = new Tarea(
            txtTitulo.Text,
            txtDescripcion.Text
        );
        
        // Agregar a la lista
        listaTareas.Add(nuevaTarea);
        
        // Actualizar la interfaz
        ActualizarLista();
        
        // Limpiar campos
        txtTitulo.Clear();
        txtDescripcion.Clear();
        txtTitulo.Focus();
        
        MessageBox.Show("Tarea agregada exitosamente");
    }
    
    private void ActualizarLista()
    {
        lstTareas.Items.Clear();
        
        // Recorrer todos los objetos de la lista
        foreach (Tarea tarea in listaTareas)
        {
            string icono = tarea.Completada ? "✓" : "○";
            lstTareas.Items.Add($"{icono} {tarea.Titulo}");
        }
    }
    
    private void lstTareas_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstTareas.SelectedIndex < 0) return;
        
        // Obtener el objeto seleccionado
        Tarea tareaSeleccionada = listaTareas[lstTareas.SelectedIndex];
        
        // Mostrar su información usando el método
        txtDetalle.Text = tareaSeleccionada.ObtenerResumen();
    }
    
    private void btnCompletar_Click(object sender, EventArgs e)
    {
        if (lstTareas.SelectedIndex < 0)
        {
            MessageBox.Show("Seleccione una tarea");
            return;
        }
        
        // Obtener la tarea seleccionada
        Tarea tarea = listaTareas[lstTareas.SelectedIndex];
        
        // Llamar a su método Completar
        tarea.Completar();
        
        // Actualizar la interfaz
        ActualizarLista();
        txtDetalle.Text = tarea.ObtenerResumen();
        
        MessageBox.Show("¡Tarea completada!");
    }
}
```

### Visual del Proceso en Memoria

```
┌─────────────────────────────────────────────────────────┐
│  listaTareas (List<Tarea>)                              │
│  ═══════════════════════════                            │
│                                                         │
│  [0] ──→ 📦 Tarea 1                                     │
│           Titulo: "Estudiar C#"                         │
│           Descripcion: "Repasar clases"                 │
│           Completada: false                             │
│           FechaCreacion: 30/10/2025                     │
│                                                         │
│  [1] ──→ 📦 Tarea 2                                     │
│           Titulo: "Hacer ejercicios"                    │
│           Descripcion: "Completar 5 ejercicios"         │
│           Completada: true                              │
│           FechaCreacion: 30/10/2025                     │
│                                                         │
│  [2] ──→ 📦 Tarea 3                                     │
│           Titulo: "Proyecto final"                      │
│           Descripcion: "Terminar WinForms"              │
│           Completada: false                             │
│           FechaCreacion: 30/10/2025                     │
│                                                         │
└─────────────────────────────────────────────────────────┘
```

## 🔄 Ciclo de Vida de un Objeto

Entender qué pasa con un objeto desde que nace hasta que muere:

```
1. CREACIÓN
   ════════
   Tarea t = new Tarea("Título", "Descripción");
   
   📦 Objeto creado en memoria
   
   
2. USO
   ════
   t.Completar();
   string info = t.ObtenerResumen();
   
   📦 Objeto existe y funciona
   
   
3. REFERENCIA NULA
   ══════════════
   t = null;
   
   💀 Ya no podemos acceder al objeto
   
   
4. RECOLECCIÓN DE BASURA (Garbage Collection)
   ═══════════════════════════════════════════
   (Automático en C#)
   
   🗑️ El objeto se elimina de la memoria
```

## 🎨 Conceptos Importantes

### 1. Referencia vs Valor

```csharp
// Los objetos son REFERENCIAS
Tarea tarea1 = new Tarea("Tarea A", "Desc A");
Tarea tarea2 = tarea1;  // ¡tarea2 apunta al MISMO objeto!

tarea2.Titulo = "Tarea B";

// ¿Qué muestra esto?
MessageBox.Show(tarea1.Titulo);  // Muestra "Tarea B"
```

**Visual:**
```
┌─────────────────────────────────────────┐
│  MEMORIA                                │
│                                         │
│  tarea1 ────┐                           │
│             ├──→ 📦 Objeto Tarea        │
│  tarea2 ────┘     Titulo: "Tarea B"    │
│                   Descripcion: "Desc A" │
│                                         │
└─────────────────────────────────────────┘
     Ambas variables apuntan al mismo objeto
```

### 2. Objeto Null

```csharp
Tarea tarea = null;  // No apunta a ningún objeto

// ¡PELIGRO! Esto causará un error:
// tarea.Completar();  // NullReferenceException

// Siempre verificar:
if (tarea != null)
{
    tarea.Completar();
}
```

**Visual:**
```
┌─────────────────────────────────┐
│  tarea ──→ ∅ (null)             │
│                                 │
│  No hay ningún objeto           │
└─────────────────────────────────┘
```

### 3. Muchos Objetos, Una Clase

```
        📋 CLASE ESTUDIANTE (1 sola)
                  │
        ┌─────────┼─────────┐
        │         │         │
        ↓         ↓         ↓
    📦 Ana    📦 Luis   📦 María
  (Objeto 1) (Objeto 2) (Objeto 3)
  
  Nota: 85   Nota: 55   Nota: 92
```

## 📝 Ejercicios Prácticos

### Ejercicio 1: Biblioteca de Libros

Crea una aplicación que gestione una biblioteca:

**Clase a crear:**
```csharp
public class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Año { get; set; }
    public bool Prestado { get; set; }
    
    // Agrega constructor y métodos:
    // - Prestar()
    // - Devolver()
    // - ObtenerInfo()
}
```

**Formulario:**
- Campos para ingresar libro
- Botón para agregar
- Lista de libros
- Botones para prestar/devolver

### Ejercicio 2: Contador de Clics

Crea una clase `Contador` con:
- Propiedad `Valor` (int)
- Método `Incrementar()`
- Método `Decrementar()`
- Método `Reiniciar()`

Crea 3 contadores diferentes en el formulario con botones para cada uno.

### Ejercicio 3: Calculadora de Áreas

Crea una clase `Rectangulo` con:
- Propiedades: `Base`, `Altura`
- Métodos: `CalcularArea()`, `CalcularPerimetro()`

En el formulario, permite crear varios rectángulos y calcular sus áreas.

## 🎓 Resumen

### Lo que Aprendiste

✅ **Objeto**: Una instancia concreta de una clase
✅ **new**: Palabra clave para crear objetos
✅ **Múltiples objetos**: Puedes crear muchos de la misma clase
✅ **Independencia**: Cada objeto tiene sus propios valores
✅ **Referencias**: Los objetos se guardan por referencia
✅ **null**: Cuando una variable no apunta a ningún objeto
✅ **Métodos de objeto**: Funciones que operan sobre ese objeto específico

### Diagrama Final: Clase vs Objeto

```
╔═══════════════════════════════════════════════════════╗
║                    CLASE                              ║
║  ─────────────────────────────                        ║
║  • Es el MOLDE / PLANTILLA                            ║
║  • Define ESTRUCTURA (propiedades)                    ║
║  • Define COMPORTAMIENTO (métodos)                    ║
║  • Solo existe 1 en el código                         ║
║  • Se escribe con "class NombreClase"                 ║
╚═══════════════════════════════════════════════════════╝
                        │
                        │ new
                        ↓
╔═══════════════════════════════════════════════════════╗
║                   OBJETOS                             ║
║  ─────────────────────────────                        ║
║  • Son INSTANCIAS concretas de la clase               ║
║  • Cada uno tiene sus PROPIOS DATOS                   ║
║  • Se crean con "new NombreClase()"                   ║
║  • Puedes crear MUCHOS                                ║
║  • Existen en MEMORIA mientras el programa corre      ║
╚═══════════════════════════════════════════════════════╝

Ejemplo:
  Clase:   Estudiante (la definición)
  Objetos: est1, est2, est3 (estudiantes específicos)
```

## 🚀 Próximos Pasos

En la siguiente lección aprenderás sobre **Encapsulación**, que te permitirá:
- Proteger los datos de tus objetos
- Crear propiedades con validación
- Hacer código más seguro y robusto

---

**💡 Consejo Final:** Practica creando muchos objetos diferentes. La clave para entender POO es experimentar. ¡No tengas miedo de crear objetos y ver qué pasa!
