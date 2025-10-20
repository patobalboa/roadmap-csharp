# 📖 Teoría 01: Fundamentos de Clases con Windows Forms

## 🎯 Objetivos de Aprendizaje
Al finalizar esta lección, podrás:
- Entender qué es una clase usando ejemplos simples
- Crear tu primera clase que funcione con Windows Forms
- Usar propiedades y métodos básicos
- Hacer que los datos se muestren en la pantalla

## 🤔 ¿Qué es una Clase?

### Analogía Simple
Una **clase** es como un molde para hacer galletas:
- El molde define la forma (la clase)
- Cada galleta que haces es un objeto
- Todas tienen la misma forma, pero pueden tener diferentes sabores

```
    📋 CLASE PERSONA              👤 OBJETO PERSONA
    ===============              =================
    - Nombre                     - Nombre: "Ana"
    - Edad                       - Edad: 25
    - Saludar()                  - Saludar() → "¡Hola!"
```

### En Windows Forms
Piensa en un botón:
- La clase Button es el "molde"
- Cada botón que pones en tu formulario es un "objeto"

## 🏗️ Mi Primera Clase Simple

Vamos a crear una clase **Persona** paso a paso:

```csharp
// Paso 1: Definir la clase
public class Persona
{
    // Paso 2: Propiedades (características)
    public string Nombre { get; set; }
    public int Edad { get; set; }
    
    // Paso 3: Constructor (cómo crear una persona)
    public Persona()
    {
        Nombre = "Sin nombre";
        Edad = 0;
    }
    
    // Paso 4: Método (qué puede hacer)
    public string Saludar()
    {
        return "¡Hola! Soy " + Nombre;
    }
}
```

## 🖥️ Usando la Clase en Windows Forms

Ahora vamos a usar nuestra clase **Persona** en un formulario simple:

```csharp
public partial class Form1 : Form
{
    // Crear un objeto de la clase Persona
    private Persona miPersona;
    
    // Controles del formulario
    private TextBox txtNombre;
    private TextBox txtEdad;
    private Button btnCrear;
    private Button btnSaludar;
    private Label lblResultado;
    
    public Form1()
    {
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        // Configurar el formulario
        this.Text = "Mi Primera Clase - Persona";
        this.Size = new Size(400, 300);
        
        // Crear los controles
        Label lblNom = new Label();
        lblNom.Text = "Nombre:";
        lblNom.Location = new Point(20, 20);
        lblNom.Size = new Size(60, 20);
        
        txtNombre = new TextBox();
        txtNombre.Location = new Point(90, 20);
        txtNombre.Size = new Size(150, 20);
        
        Label lblEd = new Label();
        lblEd.Text = "Edad:";
        lblEd.Location = new Point(20, 60);
        lblEd.Size = new Size(60, 20);
        
        txtEdad = new TextBox();
        txtEdad.Location = new Point(90, 60);
        txtEdad.Size = new Size(80, 20);
        
        btnCrear = new Button();
        btnCrear.Text = "Crear Persona";
        btnCrear.Location = new Point(20, 100);
        btnCrear.Size = new Size(100, 30);
        btnCrear.Click += BtnCrear_Click;  // ← Conectar el evento
        
        btnSaludar = new Button();
        btnSaludar.Text = "Saludar";
        btnSaludar.Location = new Point(140, 100);
        btnSaludar.Size = new Size(100, 30);
        btnSaludar.Click += BtnSaludar_Click;  // ← Conectar el evento
        
        lblResultado = new Label();
        lblResultado.Location = new Point(20, 150);
        lblResultado.Size = new Size(300, 40);
        lblResultado.BorderStyle = BorderStyle.FixedSingle;
        lblResultado.Text = "Aquí aparecerá el resultado";
        
        // Agregar todos los controles al formulario
        this.Controls.Add(lblNom);
        this.Controls.Add(txtNombre);
        this.Controls.Add(lblEd);
        this.Controls.Add(txtEdad);
        this.Controls.Add(btnCrear);
        this.Controls.Add(btnSaludar);
        this.Controls.Add(lblResultado);
    }
    
    // Evento del botón "Crear Persona"
    private void BtnCrear_Click(object sender, EventArgs e)
    {
        // ¡Aquí usamos nuestra clase!
        miPersona = new Persona();  // ← Crear objeto
        miPersona.Nombre = txtNombre.Text;  // ← Asignar nombre
        miPersona.Edad = int.Parse(txtEdad.Text);  // ← Asignar edad
        
        lblResultado.Text = "Persona creada: " + miPersona.Nombre;
    }
    
    // Evento del botón "Saludar"
    private void BtnSaludar_Click(object sender, EventArgs e)
    {
        if (miPersona != null)
        {
            // ¡Usar el método de nuestra clase!
            string saludo = miPersona.Saludar();  // ← Llamar método
            lblResultado.Text = saludo;
        }
        else
        {
            lblResultado.Text = "Primero crea una persona";
        }
    }
}
```

### 📝 Así se ve en pantalla:
```
┌─────────────────────────────────────┐
│  Mi Primera Clase - Persona    [X]  │
├─────────────────────────────────────┤
│  Nombre: [Ana García          ]     │
│  Edad:   [25]                       │
│                                     │
│  [Crear Persona] [Saludar]          │
│                                     │
│  ┌─────────────────────────────────┐ │
│  │ ¡Hola! Soy Ana García           │ │
│  └─────────────────────────────────┘ │
└─────────────────────────────────────┘
```

## 🔧 Partes de una Clase (Explicación Simple)

### 1. Propiedades (Los Datos)
```csharp
public class Estudiante
{
    // Estas son las "características" del estudiante
    public string Nombre { get; set; }    // ← Su nombre
    public int Edad { get; set; }         // ← Su edad
    public double Nota { get; set; }      // ← Su nota
}
```

### 2. Constructor (Cómo se Crea)
```csharp
public class Estudiante
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public double Nota { get; set; }
    
    // Constructor - se ejecuta cuando haces "new Estudiante()"
    public Estudiante()
    {
        Nombre = "Nuevo Estudiante";  // ← Valores por defecto
        Edad = 18;
        Nota = 0.0;
    }
}
```

### 3. Métodos (Lo Que Puede Hacer)
```csharp
public class Estudiante
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public double Nota { get; set; }
    
    public Estudiante()
    {
        Nombre = "Nuevo Estudiante";
        Edad = 18;
        Nota = 0.0;
    }
    
    // Método - una acción que puede hacer el estudiante
    public string EstadoAprobacion()
    {
        if (Nota >= 10.5)
        {
            return "APROBADO ✅";
        }
        else
        {
            return "REPROBADO ❌";
        }
    }
    
    // Otro método
    public void CumplirAnios()
    {
        Edad = Edad + 1;  // ← Aumentar la edad
    }
}
```

## � Ejemplo Práctico: Calculadora Simple

Vamos a crear una clase **Calculadora** y usarla en un formulario:

### Paso 1: Crear la Clase Calculadora
```csharp
public class Calculadora
{
    // Propiedades (datos que guarda)
    public double NumeroActual { get; set; }
    public double Resultado { get; set; }
    
    // Constructor
    public Calculadora()
    {
        NumeroActual = 0;
        Resultado = 0;
    }
    
    // Métodos (lo que puede hacer)
    public double Sumar(double numero)
    {
        Resultado = NumeroActual + numero;
        return Resultado;
    }
    
    public double Restar(double numero)
    {
        Resultado = NumeroActual - numero;
        return Resultado;
    }
    
    public void Limpiar()
    {
        NumeroActual = 0;
        Resultado = 0;
    }
}
```

### Paso 2: Usar la Clase en el Formulario
```csharp
public partial class FormCalculadora : Form
{
    // Crear objeto de nuestra clase
    private Calculadora miCalculadora;
    
    // Controles del formulario
    private TextBox txtNumero1;
    private TextBox txtNumero2;
    private Button btnSumar;
    private Button btnRestar;
    private Button btnLimpiar;
    private Label lblResultado;
    
    public FormCalculadora()
    {
        InitializeComponent();
        
        // ¡Crear la calculadora!
        miCalculadora = new Calculadora();
    }
    
    private void InitializeComponent()
    {
        this.Text = "Mi Calculadora con Clases";
        this.Size = new Size(350, 250);
        
        // Número 1
        Label lbl1 = new Label();
        lbl1.Text = "Número 1:";
        lbl1.Location = new Point(20, 20);
        lbl1.Size = new Size(80, 20);
        
        txtNumero1 = new TextBox();
        txtNumero1.Location = new Point(110, 20);
        txtNumero1.Size = new Size(100, 20);
        
        // Número 2
        Label lbl2 = new Label();
        lbl2.Text = "Número 2:";
        lbl2.Location = new Point(20, 60);
        lbl2.Size = new Size(80, 20);
        
        txtNumero2 = new TextBox();
        txtNumero2.Location = new Point(110, 60);
        txtNumero2.Size = new Size(100, 20);
        
        // Botones
        btnSumar = new Button();
        btnSumar.Text = "Sumar";
        btnSumar.Location = new Point(20, 100);
        btnSumar.Size = new Size(60, 30);
        btnSumar.Click += BtnSumar_Click;
        
        btnRestar = new Button();
        btnRestar.Text = "Restar";
        btnRestar.Location = new Point(90, 100);
        btnRestar.Size = new Size(60, 30);
        btnRestar.Click += BtnRestar_Click;
        
        btnLimpiar = new Button();
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.Location = new Point(160, 100);
        btnLimpiar.Size = new Size(60, 30);
        btnLimpiar.Click += BtnLimpiar_Click;
        
        // Resultado
        Label lblRes = new Label();
        lblRes.Text = "Resultado:";
        lblRes.Location = new Point(20, 150);
        lblRes.Size = new Size(80, 20);
        
        lblResultado = new Label();
        lblResultado.Location = new Point(110, 150);
        lblResultado.Size = new Size(150, 30);
        lblResultado.BorderStyle = BorderStyle.FixedSingle;
        lblResultado.Text = "0";
        lblResultado.Font = new Font("Arial", 12, FontStyle.Bold);
        
        // Agregar todo al formulario
        this.Controls.Add(lbl1);
        this.Controls.Add(txtNumero1);
        this.Controls.Add(lbl2);
        this.Controls.Add(txtNumero2);
        this.Controls.Add(btnSumar);
        this.Controls.Add(btnRestar);
        this.Controls.Add(btnLimpiar);
        this.Controls.Add(lblRes);
        this.Controls.Add(lblResultado);
    }
    
    // Evento del botón Sumar
    private void BtnSumar_Click(object sender, EventArgs e)
    {
        // Obtener números de las cajas de texto
        double num1 = double.Parse(txtNumero1.Text);
        double num2 = double.Parse(txtNumero2.Text);
        
        // Usar nuestra clase Calculadora
        miCalculadora.NumeroActual = num1;
        double resultado = miCalculadora.Sumar(num2);
        
        // Mostrar resultado
        lblResultado.Text = resultado.ToString();
    }
    
    // Evento del botón Restar
    private void BtnRestar_Click(object sender, EventArgs e)
    {
        double num1 = double.Parse(txtNumero1.Text);
        double num2 = double.Parse(txtNumero2.Text);
        
        miCalculadora.NumeroActual = num1;
        double resultado = miCalculadora.Restar(num2);
        
        lblResultado.Text = resultado.ToString();
    }
    
    // Evento del botón Limpiar
    private void BtnLimpiar_Click(object sender, EventArgs e)
    {
        miCalculadora.Limpiar();
        txtNumero1.Text = "";
        txtNumero2.Text = "";
        lblResultado.Text = "0";
    }
}
```

### 📝 Así se ve la calculadora:
```
┌─────────────────────────────────┐
│  Mi Calculadora con Clases [X]  │
├─────────────────────────────────┤
│  Número 1: [5        ]          │
│  Número 2: [3        ]          │
│                                 │
│  [Sumar] [Restar] [Limpiar]     │
│                                 │
│  Resultado: ┌─────────────────┐  │
│             │       8         │  │
│             └─────────────────┘  │
└─────────────────────────────────┘
```

## 🎮 ¡Tú Hazlo! - Ejercicio Paso a Paso

### Crea una clase "Contador"

1. **Crea la clase:**
```csharp
public class Contador
{
    // Tu código aquí:
    // - Una propiedad llamada "Valor" (tipo int)
    // - Un constructor que ponga Valor = 0
    // - Un método "Incrementar()" que sume 1 al valor
    // - Un método "Decrementar()" que reste 1 al valor
    // - Un método "Reiniciar()" que ponga el valor en 0
}
```

2. **Úsala en un formulario:**
```csharp
public partial class FormContador : Form
{
    private Contador miContador;  // ← Tu objeto contador
    private Label lblNumero;      // ← Para mostrar el número
    private Button btnMas;        // ← Botón +
    private Button btnMenos;      // ← Botón -
    private Button btnReinicio;   // ← Botón reiniciar
    
    // Completa el resto...
}
```

3. **El resultado debe verse así:**
```
┌─────────────────────┐
│  Contador      [X]  │
├─────────────────────┤
│        ┌───┐        │
│        │ 5 │        │
│        └───┘        │
│                     │
│   [+]  [-]  [🔄]    │
└─────────────────────┘
```

## 💡 Puntos Importantes (Para Recordar)

### ✅ Lo que SÍ debes hacer:
```csharp
// 1. Siempre crear el objeto antes de usarlo
miPersona = new Persona();  // ← ¡Crear primero!
miPersona.Nombre = "Ana";   // ← Luego usar

// 2. Usar nombres claros
public class Estudiante  // ← Claro y descriptivo
{
    public string Nombre { get; set; }  // ← Se entiende qué es
}

// 3. Inicializar en el constructor
public Persona()
{
    Nombre = "Sin nombre";  // ← Siempre dar valores iniciales
    Edad = 0;
}
```

### ❌ Lo que NO debes hacer:
```csharp
// 1. NO usar un objeto sin crearlo
miPersona.Nombre = "Ana";  // ← ¡ERROR! miPersona es null

// 2. NO usar nombres confusos
public class X  // ← ¿Qué es X?
{
    public string A { get; set; }  // ← ¿Qué es A?
}

// 3. NO dejar propiedades sin inicializar
public Persona()
{
    // Vacío = ¡MALO!
}
```

## 🎯 Resumen en 3 Pasos

1. **Crear la clase** (el molde):
```csharp
public class MiClase
{
    public string Propiedad { get; set; }
    public MiClase() { /* inicializar */ }
    public void Metodo() { /* hacer algo */ }
}
```

2. **Crear el objeto** (usar el molde):
```csharp
MiClase miObjeto = new MiClase();
```

3. **Usar el objeto** (interactuar):
```csharp
miObjeto.Propiedad = "valor";
miObjeto.Metodo();
```

## � Resumen

- Una **clase** es como un molde de galletas
- Un **objeto** es cada galleta que haces
- Las **propiedades** son las características (sabor, forma)
- Los **métodos** son las acciones (hornear, decorar)
- ¡Y lo puedes ver funcionando en Windows Forms!

## ➡️ Siguiente: [Teoría 02: Trabajando con Objetos en Windows Forms](Teoria-02-Objetos-WinForms.md)