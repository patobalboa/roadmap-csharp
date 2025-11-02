# 📖 Teoría 04: Herencia en POO con Windows Forms

## 🎯 Objetivos de Aprendizaje
Al finalizar esta lección, podrás:
- Entender qué es la herencia y por qué es útil
- Crear clases que heredan de otras clases
- Usar la palabra clave `base` correctamente
- Aplicar herencia en aplicaciones Windows Forms
- Comprender el polimorfismo básico

## 🤔 ¿Qué es la Herencia?

### Analogía de la Vida Real

Imagina una **familia de vehículos**:

```
                    🚗 VEHÍCULO (Clase Padre)
                    ═══════════════════════
                    - Motor
                    - Ruedas
                    - Color
                    - Arrancar()
                    - Detener()
                          │
        ┌─────────────────┼─────────────────┐
        │                 │                 │
        ↓                 ↓                 ↓
    🚗 AUTO          🚚 CAMIÓN         🏍️ MOTO
    ════════         ═══════════       ═══════
    Hereda todo      Hereda todo       Hereda todo
    de Vehículo      de Vehículo       de Vehículo
    +                +                 +
    NumPuertas       Capacidad         TipoManillar
    AbrirMaletero()  Cargar()          HacerCaballito()
```

**La herencia permite:**
- ✅ **Reutilizar código** - No repetir propiedades comunes
- ✅ **Organizar mejor** - Crear jerarquías lógicas
- ✅ **Extender funcionalidad** - Agregar características específicas
- ✅ **Mantener más fácil** - Cambios en la clase padre afectan a todos

## 🏗️ Sintaxis Básica de Herencia

### Estructura General

```csharp
// CLASE PADRE (Base, Superclase)
public class ClasePadre
{
    // Propiedades y métodos comunes
}

// CLASE HIJA (Derivada, Subclase)
public class ClaseHija : ClasePadre
{
    // Hereda todo de ClasePadre
    // + puede agregar sus propias cosas
}
```

### Ejemplo Sencillo

```csharp
// Clase Padre
public class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    
    public string Saludar()
    {
        return $"Hola, soy {Nombre}";
    }
}

// Clase Hija
public class Estudiante : Persona
{
    // Estudiante HEREDA: Nombre, Edad, Saludar()
    // Y agrega:
    public string Matricula { get; set; }
    public double Promedio { get; set; }
    
    public string Estudiar()
    {
        return $"{Nombre} está estudiando";
    }
}
```

**Visual de la herencia:**
```
┌─────────────────────────────────────┐
│  👤 PERSONA (Clase Padre)           │
│  ═══════════════════════             │
│  + Nombre                           │
│  + Edad                             │
│  + Saludar()                        │
└─────────────────────────────────────┘
              │
              │ hereda
              ↓
┌─────────────────────────────────────┐
│  📚 ESTUDIANTE (Clase Hija)         │
│  ═══════════════════════             │
│  + Nombre         ← heredado        │
│  + Edad           ← heredado        │
│  + Saludar()      ← heredado        │
│  ─────────────────────────          │
│  + Matricula      ← nuevo           │
│  + Promedio       ← nuevo           │
│  + Estudiar()     ← nuevo           │
└─────────────────────────────────────┘
```

### Usar la Clase Hija

```csharp
// Crear un objeto Estudiante
Estudiante est = new Estudiante();

// Usar propiedades heredadas
est.Nombre = "Ana García";
est.Edad = 20;

// Usar propiedades propias
est.Matricula = "EST001";
est.Promedio = 8.5;

// Usar métodos heredados
string saludo = est.Saludar();  // "Hola, soy Ana García"

// Usar métodos propios
string accion = est.Estudiar();  // "Ana García está estudiando"
```

## 🎨 Ejemplo Completo Simplificado: Animales

### Paso 1: Clase Base

```csharp
// Clase Padre - Animal
public class Animal
{
    // Propiedades comunes a TODOS los animales
    public string Nombre { get; set; }
    public int Edad { get; set; }
    
    // Constructor
    public Animal()
    {
        Nombre = "";
        Edad = 0;
    }
    
    public Animal(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }
    
    // Método virtual (puede ser sobreescrito por hijos)
    public virtual string HacerSonido()
    {
        return "El animal hace un sonido";
    }
    
    public virtual string ObtenerInfo()
    {
        return $"Nombre: {Nombre}\nEdad: {Edad} años";
    }
}
```

### Paso 2: Clases Derivadas

```csharp
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// Clase Hija 1: Perro
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
public class Perro : Animal
{
    // Propiedad adicional
    public string Raza { get; set; }
    
    // Constructor
    public Perro() : base()
    {
        Raza = "";
    }
    
    public Perro(string nombre, int edad, string raza) : base(nombre, edad)
    {
        Raza = raza;
    }
    
    // Sobreescribir método del padre
    public override string HacerSonido()
    {
        return "Guau Guau! 🐕";
    }
    
    public override string ObtenerInfo()
    {
        return base.ObtenerInfo() + 
               $"\nTipo: Perro" +
               $"\nRaza: {Raza}" +
               $"\nSonido: {HacerSonido()}";
    }
}

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// Clase Hija 2: Gato
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
public class Gato : Animal
{
    // Propiedad adicional
    public string Color { get; set; }
    
    // Constructor
    public Gato() : base()
    {
        Color = "";
    }
    
    public Gato(string nombre, int edad, string color) : base(nombre, edad)
    {
        Color = color;
    }
    
    // Sobreescribir método del padre
    public override string HacerSonido()
    {
        return "Miau Miau! 🐱";
    }
    
    public override string ObtenerInfo()
    {
        return base.ObtenerInfo() + 
               $"\nTipo: Gato" +
               $"\nColor: {Color}" +
               $"\nSonido: {HacerSonido()}";
    }
}

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// Clase Hija 3: Pajaro
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
public class Pajaro : Animal
{
    // Propiedad adicional
    public bool PuedeVolar { get; set; }
    
    // Constructor
    public Pajaro() : base()
    {
        PuedeVolar = true;
    }
    
    public Pajaro(string nombre, int edad, bool puedeVolar) : base(nombre, edad)
    {
        PuedeVolar = puedeVolar;
    }
    
    // Sobreescribir método del padre
    public override string HacerSonido()
    {
        return "Pío Pío! 🐦";
    }
    
    public override string ObtenerInfo()
    {
        string volar = PuedeVolar ? "Sí" : "No";
        return base.ObtenerInfo() + 
               $"\nTipo: Pájaro" +
               $"\nPuede volar: {volar}" +
               $"\nSonido: {HacerSonido()}";
    }
}
```

### Visual de la Jerarquía

```
                    � ANIMAL (Clase Padre)
                    ═══════════════════════
                    - Nombre
                    - Edad
                    - HacerSonido()
                    - ObtenerInfo()
                         │
        ┌────────────────┼────────────────┐
        │                │                │
        ↓                ↓                ↓
    🐕 PERRO         � GATO         � PAJARO
    ═════════        ═════════        ══════════
    + Hereda todo    + Hereda todo    + Hereda todo
    + Raza           + Color          + PuedeVolar
    + Override       + Override       + Override
      HacerSonido()    HacerSonido()    HacerSonido()
```

## 💻 Aplicación Windows Forms

### Diseño del Formulario

```
┌──────────────────────────────────────────────────┐
│  � Registro de Animales                         │
├──────────────────────────────────────────────────┤
│                                                  │
│  Nombre: [txtNombre          ]                   │
│  Edad:   [txtEdad            ]                   │
│                                                  │
│  Tipo de Animal:                                 │
│  ( ) Perro    ( ) Gato    ( ) Pájaro            │
│                                                  │
│  Dato específico: [txtDatoEspecifico]           │
│                                                  │
│  [btnAgregar]        [btnHacerSonidos]          │
│                                                  │
│  Lista de Animales:                              │
│  ┌────────────────────────────────────────────┐ │
│  │ lstAnimales                                │ │
│  │                                            │ │
│  └────────────────────────────────────────────┘ │
│                                                  │
│  Información:                                    │
│  ┌────────────────────────────────────────────┐ │
│  │ txtInfo                                    │ │
│  │                                            │ │
│  └────────────────────────────────────────────┘ │
└──────────────────────────────────────────────────┘
```

### 🎨 Archivo: FormAnimales.Designer.cs

**Este archivo contiene el DISEÑO VISUAL del formulario (lo genera Visual Studio)**

```csharp
namespace MisAnimales
{
    partial class FormAnimales
    {
        private System.ComponentModel.IContainer components = null;
        
        // Limpiar recursos
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Método para crear los controles
        private void InitializeComponent()
        {
            // Crear todos los controles
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            
            this.rdoPerro = new System.Windows.Forms.RadioButton();
            this.rdoGato = new System.Windows.Forms.RadioButton();
            this.rdoPajaro = new System.Windows.Forms.RadioButton();
            
            this.lblDatoEspecifico = new System.Windows.Forms.Label();
            this.txtDatoEspecifico = new System.Windows.Forms.TextBox();
            
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnHacerSonidos = new System.Windows.Forms.Button();
            
            this.lstAnimales = new System.Windows.Forms.ListBox();
            this.txtInfo = new System.Windows.Forms.TextBox();
            
            // Configurar lblNombre
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(20, 20);
            
            // Configurar txtNombre
            this.txtNombre.Location = new System.Drawing.Point(120, 20);
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            
            // Configurar lblEdad
            this.lblEdad.Text = "Edad:";
            this.lblEdad.Location = new System.Drawing.Point(20, 50);
            
            // Configurar txtEdad
            this.txtEdad.Location = new System.Drawing.Point(120, 50);
            this.txtEdad.Size = new System.Drawing.Size(200, 20);
            
            // Configurar radio buttons
            this.rdoPerro.Text = "Perro";
            this.rdoPerro.Location = new System.Drawing.Point(20, 90);
            this.rdoPerro.Checked = true;
            
            this.rdoGato.Text = "Gato";
            this.rdoGato.Location = new System.Drawing.Point(120, 90);
            
            this.rdoPajaro.Text = "Pájaro";
            this.rdoPajaro.Location = new System.Drawing.Point(220, 90);
            
            // Configurar dato específico
            this.lblDatoEspecifico.Text = "Raza:";
            this.lblDatoEspecifico.Location = new System.Drawing.Point(20, 130);
            
            this.txtDatoEspecifico.Location = new System.Drawing.Point(120, 130);
            this.txtDatoEspecifico.Size = new System.Drawing.Size(200, 20);
            
            // Configurar botones
            this.btnAgregar.Text = "Agregar Animal";
            this.btnAgregar.Location = new System.Drawing.Point(20, 170);
            this.btnAgregar.Size = new System.Drawing.Size(120, 30);
            
            this.btnHacerSonidos.Text = "Hacer Sonidos";
            this.btnHacerSonidos.Location = new System.Drawing.Point(200, 170);
            this.btnHacerSonidos.Size = new System.Drawing.Size(120, 30);
            
            // Configurar lista
            this.lstAnimales.Location = new System.Drawing.Point(20, 220);
            this.lstAnimales.Size = new System.Drawing.Size(460, 100);
            
            // Configurar cuadro de información
            this.txtInfo.Multiline = true;
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Location = new System.Drawing.Point(20, 340);
            this.txtInfo.Size = new System.Drawing.Size(460, 120);
            
            // Configurar formulario
            this.ClientSize = new System.Drawing.Size(500, 480);
            this.Text = "Registro de Animales";
            
            // Agregar controles al formulario
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.rdoPerro);
            this.Controls.Add(this.rdoGato);
            this.Controls.Add(this.rdoPajaro);
            this.Controls.Add(this.lblDatoEspecifico);
            this.Controls.Add(this.txtDatoEspecifico);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnHacerSonidos);
            this.Controls.Add(this.lstAnimales);
            this.Controls.Add(this.txtInfo);
        }

        // Declaración de controles
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TextBox txtEdad;
        
        private System.Windows.Forms.RadioButton rdoPerro;
        private System.Windows.Forms.RadioButton rdoGato;
        private System.Windows.Forms.RadioButton rdoPajaro;
        
        private System.Windows.Forms.Label lblDatoEspecifico;
        private System.Windows.Forms.TextBox txtDatoEspecifico;
        
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnHacerSonidos;
        
        private System.Windows.Forms.ListBox lstAnimales;
        private System.Windows.Forms.TextBox txtInfo;
    }
}
```

### 💻 Archivo: FormAnimales.cs

**Este archivo contiene la LÓGICA del formulario (aquí escribes tu código)**

```csharp
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MisAnimales
{
    public partial class FormAnimales : Form
    {
        // ═══════════════════════════════════════════════════
        // VARIABLE PRINCIPAL
        // ═══════════════════════════════════════════════════
        
        // Lista que puede guardar cualquier tipo de Animal
        // ¡Aquí vemos el POLIMORFISMO en acción!
        private List<Animal> animales;
        
        // ═══════════════════════════════════════════════════
        // CONSTRUCTOR
        // ═══════════════════════════════════════════════════
        
        public FormAnimales()
        {
            InitializeComponent();  // Crea todos los controles del Designer
            animales = new List<Animal>();  // Inicializar la lista
            ConfigurarEventos();
        }
        
        // ═══════════════════════════════════════════════════
        // CONFIGURACIÓN
        // ═══════════════════════════════════════════════════
        
        private void ConfigurarEventos()
        {
            // Conectar eventos de los botones
            btnAgregar.Click += btnAgregar_Click;
            btnHacerSonidos.Click += btnHacerSonidos_Click;
            
            // Conectar evento de la lista
            lstAnimales.SelectedIndexChanged += lstAnimales_SelectedIndexChanged;
            
            // Conectar eventos de radio buttons para cambiar la etiqueta
            rdoPerro.CheckedChanged += TipoAnimal_CheckedChanged;
            rdoGato.CheckedChanged += TipoAnimal_CheckedChanged;
            rdoPajaro.CheckedChanged += TipoAnimal_CheckedChanged;
        }
        
        // ═══════════════════════════════════════════════════
        // EVENTOS
        // ═══════════════════════════════════════════════════
        
        // Cambiar la etiqueta del campo específico según el tipo
        private void TipoAnimal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPerro.Checked)
            {
                lblDatoEspecifico.Text = "Raza:";
            }
            else if (rdoGato.Checked)
            {
                lblDatoEspecifico.Text = "Color:";
            }
            else if (rdoPajaro.Checked)
            {
                lblDatoEspecifico.Text = "¿Puede volar? (si/no):";
            }
            txtDatoEspecifico.Clear();
        }
        
        // Botón: Agregar Animal
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Por favor ingrese el nombre", "Validación");
                    return;
                }
                
                // 2. Obtener los datos comunes
                string nombre = txtNombre.Text;
                int edad = int.Parse(txtEdad.Text);
                string datoEspecifico = txtDatoEspecifico.Text;
                
                Animal nuevoAnimal = null;
                
                // 3. Crear el tipo correcto de animal según la selección
                // ¡AQUÍ USAMOS HERENCIA!
                
                if (rdoPerro.Checked)
                {
                    // Crear un Perro
                    nuevoAnimal = new Perro(nombre, edad, datoEspecifico);
                }
                else if (rdoGato.Checked)
                {
                    // Crear un Gato
                    nuevoAnimal = new Gato(nombre, edad, datoEspecifico);
                }
                else if (rdoPajaro.Checked)
                {
                    // Crear un Pájaro
                    bool puedeVolar = datoEspecifico.ToLower() == "si";
                    nuevoAnimal = new Pajaro(nombre, edad, puedeVolar);
                }
                
                // 4. Agregar a la lista (¡POLIMORFISMO!)
                // La lista de tipo Animal puede guardar Perros, Gatos y Pájaros
                animales.Add(nuevoAnimal);
                
                // 5. Actualizar la interfaz
                ActualizarLista();
                LimpiarCampos();
                
                MessageBox.Show("Animal agregado exitosamente", "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }
        
        // Botón: Hacer que todos los animales hagan su sonido
        private void btnHacerSonidos_Click(object sender, EventArgs e)
        {
            if (animales.Count == 0)
            {
                MessageBox.Show("No hay animales registrados", "Información");
                return;
            }
            
            string sonidos = "🔊 SONIDOS DE LOS ANIMALES:\n\n";
            
            // ¡POLIMORFISMO EN ACCIÓN!
            // Cada animal hace su propio sonido
            foreach (Animal animal in animales)
            {
                // Aunque todos son de tipo Animal, cada uno ejecuta
                // su propia versión de HacerSonido()
                sonidos += animal.Nombre + ": " + animal.HacerSonido() + "\n";
            }
            
            txtInfo.Text = sonidos;
        }
        
        // Evento: Cuando se selecciona un animal de la lista
        private void lstAnimales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAnimales.SelectedIndex < 0) return;
            
            // Obtener el animal seleccionado
            Animal animalSeleccionado = animales[lstAnimales.SelectedIndex];
            
            // ¡POLIMORFISMO!
            // Cada tipo de animal muestra su propia información
            txtInfo.Text = animalSeleccionado.ObtenerInfo();
        }
        
        // ═══════════════════════════════════════════════════
        // MÉTODOS AUXILIARES
        // ═══════════════════════════════════════════════════
        
        // Actualizar la lista de animales
        private void ActualizarLista()
        {
            lstAnimales.Items.Clear();
            
            foreach (Animal animal in animales)
            {
                // Usar 'is' para saber qué tipo de animal es
                string icono = "";
                if (animal is Perro)
                    icono = "🐕";
                else if (animal is Gato)
                    icono = "�";
                else if (animal is Pajaro)
                    icono = "�";
                
                lstAnimales.Items.Add($"{icono} {animal.Nombre} ({animal.Edad} años)");
            }
        }
        
        // Limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtEdad.Clear();
            txtDatoEspecifico.Clear();
            txtNombre.Focus();
        }
    }
}
```

---

## 📝 Notas Importantes sobre la Separación de Archivos

### 🎯 ¿Por Qué Dos Archivos?

```
FormEmpleados.Designer.cs       FormEmpleados.cs
        ↓                              ↓
    DISEÑO VISUAL                    LÓGICA
    ═════════════                  ═══════════
    - InitializeComponent()        - Eventos de botones
    - Posiciones (Left, Top)       - Métodos auxiliares
    - Tamaños (Width, Height)      - Lógica de negocio
    - Declaración de controles     - Operaciones con datos
    
    ¡NO MODIFICAR A MANO!          ¡AQUÍ PROGRAMAS TÚ!
    (Visual Studio lo genera)      (Tu código personalizado)
```

### ✅ Ventajas de Esta Separación

1. **Organización**: Código más limpio y fácil de mantener
2. **Protección**: El Designer no sobrescribe tu lógica
3. **Colaboración**: Varios programadores pueden trabajar sin conflictos
4. **Profesionalismo**: Así trabajan los proyectos reales

### 🔍 ¿Qué Va en Cada Archivo?

**FormEmpleados.Designer.cs:**
- Creación de controles (new Button(), new TextBox(), etc.)
- Propiedades visuales (tamaño, posición, color, fuente)
- Método InitializeComponent()
- Declaración de variables de controles

**FormEmpleados.cs:**
- Lógica de negocio
- Eventos (_Click, _Changed, etc.)
- Métodos auxiliares
- Validaciones
- Operaciones con datos

### Visual del Polimorfismo en Acción

```
┌───────────────────────────────────────────────────────┐
│  Lista: List<Empleado> empleados                      │
│  ═══════════════════════════════════                  │
│                                                       │
│  [0] ──→ 📦 EmpleadoPorHora                           │
│           (ES UN Empleado)                            │
│           CalcularSalario() → Base + (Horas * Tarifa)│
│                                                       │
│  [1] ──→ 📦 EmpleadoComision                          │
│           (ES UN Empleado)                            │
│           CalcularSalario() → Base + (Ventas * %)    │
│                                                       │
│  [2] ──→ 📦 Gerente                                   │
│           (ES UN Empleado)                            │
│           CalcularSalario() → Base + Bono            │
│                                                       │
└───────────────────────────────────────────────────────┘

Cuando haces: empleado.CalcularSalario()

El programa AUTOMÁTICAMENTE sabe qué versión usar
según el tipo REAL del objeto (Polimorfismo)
```

## 🔑 Palabras Clave Importantes

### 1. La palabra `base`

```csharp
public class Hijo : Padre
{
    public Hijo(string parametro) : base(parametro)
    {
        // base() llama al constructor del padre
    }
    
    public override string Metodo()
    {
        // base.Metodo() llama a la versión del padre
        string resultadoPadre = base.Metodo();
        return resultadoPadre + " + algo más";
    }
}
```

**Visual:**
```
┌─────────────────────────────────┐
│  PADRE                          │
│  ══════                         │
│  Constructor(string p)          │
│  Metodo() → "Hola"              │
└─────────────────────────────────┘
              ↑
              │ base
              │
┌─────────────────────────────────┐
│  HIJO                           │
│  ═════                          │
│  Constructor(string p)          │
│    : base(p)  ← llama al padre  │
│                                 │
│  Metodo()                       │
│    base.Metodo() + "Mundo"     │
│    Resultado: "Hola Mundo"     │
└─────────────────────────────────┘
```

### 2. La palabra `virtual` y `override`

```csharp
// En la clase PADRE
public virtual string Metodo()
{
    return "Versión del padre";
}

// En la clase HIJA
public override string Metodo()
{
    return "Versión del hijo";
}
```

- **`virtual`**: "Este método PUEDE ser sobrescrito por las clases hijas"
- **`override`**: "Voy a sobrescribir el método del padre"

### 3. El operador `is`

```csharp
Empleado emp = empleados[0];

if (emp is EmpleadoPorHora)
{
    MessageBox.Show("Este empleado es por hora");
}
else if (emp is Gerente)
{
    MessageBox.Show("Este empleado es gerente");
}
```

### 4. El operador `as`

```csharp
Empleado emp = empleados[0];

// Intentar convertir a EmpleadoPorHora
EmpleadoPorHora empHora = emp as EmpleadoPorHora;

if (empHora != null)
{
    // Sí es EmpleadoPorHora, usar propiedades específicas
    MessageBox.Show($"Horas: {empHora.HorasTrabajadas}");
}
```

## 🎯 Ejemplo Práctico para Practicar: Vehículos

### Ejercicio: Sistema de Vehículos

Crea tu propio sistema de herencia con vehículos:

```csharp
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// CLASE BASE - Vehiculo
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
public class Vehiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Año { get; set; }
    
    public Vehiculo(string marca, string modelo, int año)
    {
        Marca = marca;
        Modelo = modelo;
        Año = año;
    }
    
    public virtual string Acelerar()
    {
        return "El vehículo está acelerando";
    }
    
    public virtual string ObtenerInfo()
    {
        return $"Marca: {Marca}\nModelo: {Modelo}\nAño: {Año}";
    }
}

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// CLASE HIJA - Auto
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
public class Auto : Vehiculo
{
    public int NumeroPuertas { get; set; }
    
    public Auto(string marca, string modelo, int año, int puertas) 
        : base(marca, modelo, año)
    {
        NumeroPuertas = puertas;
    }
    
    public override string Acelerar()
    {
        return "El auto acelera suavemente 🚗";
    }
    
    public override string ObtenerInfo()
    {
        return base.ObtenerInfo() + 
               $"\nTipo: Auto" +
               $"\nPuertas: {NumeroPuertas}";
    }
}

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// CLASE HIJA - Moto
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
public class Moto : Vehiculo
{
    public int Cilindrada { get; set; }
    
    public Moto(string marca, string modelo, int año, int cilindrada) 
        : base(marca, modelo, año)
    {
        Cilindrada = cilindrada;
    }
    
    public override string Acelerar()
    {
        return "La moto acelera rápidamente 🏍️";
    }
    
    public override string ObtenerInfo()
    {
        return base.ObtenerInfo() + 
               $"\nTipo: Moto" +
               $"\nCilindrada: {Cilindrada}cc";
    }
}
```

### Visual de Vehículos

```
                    � VEHICULO
                    ═══════════
                    - Marca
                    - Modelo
                    - Año
                    - Acelerar()
                    - ObtenerInfo()
                         │
        ┌────────────────┴────────────────┐
        │                                 │
        ↓                                 ↓
    � AUTO                           🏍️ MOTO
    ════════                          ═══════
    + Hereda todo                     + Hereda todo
    + NumeroPuertas                   + Cilindrada
    + Override Acelerar()             + Override Acelerar()
    + Override ObtenerInfo()          + Override ObtenerInfo()
```

## 📊 Ventajas de la Herencia

```
┌────────────────────────────────────────────────────────┐
│  ✅ VENTAJAS DE LA HERENCIA                            │
│  ══════════════════════════                            │
│                                                        │
│  1️⃣  REUTILIZACIÓN DE CÓDIGO                          │
│      No repetir propiedades y métodos comunes         │
│                                                        │
│  2️⃣  ORGANIZACIÓN                                      │
│      Estructura lógica y jerarquías claras            │
│                                                        │
│  3️⃣  MANTENIMIENTO                                     │
│      Cambios en la clase padre afectan a todas        │
│                                                        │
│  4️⃣  POLIMORFISMO                                      │
│      Tratar objetos diferentes de manera uniforme     │
│                                                        │
│  5️⃣  EXTENSIBILIDAD                                    │
│      Fácil agregar nuevos tipos sin cambiar existente │
│                                                        │
└────────────────────────────────────────────────────────┘
```

## 🔍 Preguntas Frecuentes

### ❓ ¿Cuándo usar herencia?

Usa herencia cuando tengas una relación **"ES UN"**:
- Un Perro **ES UN** Animal ✅
- Un Auto **ES UN** Vehículo ✅
- Un Estudiante **ES UNA** Persona ✅

NO uses herencia cuando sea **"TIENE UN"**:
- Un Auto **TIENE UN** Motor ❌ (mejor usar composición)

### ❓ ¿Puedo heredar de múltiples clases?

**NO** en C#. Solo puedes heredar de UNA clase padre:

```csharp
// ❌ ESTO NO FUNCIONA
public class Perro : Animal, Mascota  // ERROR

// ✅ ESTO SÍ FUNCIONA
public class Perro : Animal  // OK
```

### ❓ ¿Qué es `base`?

`base` se usa para llamar al constructor o métodos de la clase padre:

```csharp
public class Hijo : Padre
{
    // Llamar al constructor del padre
    public Hijo(string dato) : base(dato)
    {
        // Tu código
    }
    
    // Llamar a un método del padre
    public override string Metodo()
    {
        return base.Metodo() + " más cosas";
    }
}
```

## 📝 Ejercicios Prácticos

### Ejercicio 1: Frutas (Fácil) ⭐

Crea:
- Clase base: `Fruta` (nombre, color, precio)
- Clases hijas: `Manzana`, `Naranja`, `Platano`
- Cada una con una propiedad especial (dulzura, vitamina C, largo)
- Método `ObtenerInfo()` que muestre toda la información

### Ejercicio 2: Instrumentos Musicales (Medio) ⭐⭐

Implementa:
- Clase base: `Instrumento` (nombre, marca)
- Clases derivadas: `Guitarra` (numCuerdas), `Piano` (numTeclas), `Tambor` (tamaño)
- Método `TocarSonido()` diferente para cada uno
- Formulario Windows Forms para agregar y hacer sonar instrumentos

### Ejercicio 3: Tienda de Productos (Avanzado) ⭐⭐⭐

Crea un sistema completo:
- Clase base: `Producto` (nombre, precio)
- Derivadas: `ProductoFisico` (peso), `ProductoDigital` (tamaño MB)
- Método `CalcularEnvio()` (físicos pagan por peso, digitales gratis)
- Formulario con lista de productos y cálculo total con envío

## 🎯 Resumen Final

### Conceptos Clave

```
╔═══════════════════════════════════════════════════════╗
║  📚 LO QUE APRENDISTE HOY                             ║
╠═══════════════════════════════════════════════════════╣
║                                                       ║
║  ✅ QUÉ ES LA HERENCIA                                ║
║     • Reutilizar código de una clase padre           ║
║     • class Hijo : Padre                             ║
║                                                       ║
║  ✅ PALABRAS IMPORTANTES                              ║
║     • virtual   → El hijo puede cambiar este método  ║
║     • override  → Cambiar método del padre           ║
║     • base      → Llamar al padre                    ║
║     • is        → Verificar el tipo                  ║
║                                                       ║
║  ✅ POLIMORFISMO                                      ║
║     • Una lista de Animal puede tener                ║
║       Perros, Gatos y Pájaros                        ║
║     • Cada uno hace su propio sonido                 ║
║                                                       ║
╚═══════════════════════════════════════════════════════╝
```

### Diagrama Simple

```
                    � ANIMAL
                    Nombre, Edad
                    HacerSonido()
                          │
        ┌─────────────────┼─────────────────┐
        ↓                 ↓                 ↓
    🐕 Perro          🐱 Gato          🐦 Pájaro
    + Raza           + Color          + PuedeVolar
    Guau Guau!       Miau Miau!       Pío Pío!
```

## 🎯 Para Practicar

1. **Haz el ejercicio de Frutas** - Es el más fácil y te ayudará a entender
2. **Modifica el ejemplo de Animales** - Agrega más animales (Conejo, Pez, etc.)
3. **Crea tu propio sistema** - Piensa en algo que te guste (videojuegos, deportes, etc.)

---

**💡 Recuerda:** 
- Herencia = **"ES UN"** (Perro ES UN Animal)
- Use herencia para no repetir código
- Cada hijo puede tener su propia versión de los métodos

**🎯 Siguiente paso:** Practica con los ejercicios y luego avanzaremos a temas más interesantes!
