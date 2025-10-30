# 📖 Teoría 03: Encapsulación con Windows Forms

## 🎯 Objetivos de Aprendizaje
Al finalizar esta lección, podrás:
- Entender qué es la encapsulación y por qué es importante
- Proteger los datos de tus clases
- Usar validaciones visuales en Windows Forms
- Hacer que tu código sea más seguro

## 🔐 ¿Qué es la Encapsulación?

### Analogía Simple
Imagina una **caja fuerte**:
- Dentro tiene cosas valiosas (datos privados)
- Solo tú tienes la llave (métodos públicos)
- Nadie puede tocar lo de adentro directamente
- Para meter o sacar algo, usas la puerta (propiedades)

```
    ┌─────────────────────────┐
    │   CLASE PERSONA         │
    │ ┌─────────────────────┐ │
    │ │ 🔒 PRIVADO          │ │
    │ │ _edad = 25          │ │ ← Nadie puede tocar esto
    │ │ _saldo = 1000       │ │
    │ └─────────────────────┘ │
    │                         │
    │ 🚪 PÚBLICO (la puerta)  │
    │ SetEdad(int edad)       │ ← Solo por aquí se entra
    │ GetEdad()               │
    └─────────────────────────┘
```

### En Programación
**Encapsulación** = Esconder los datos y controlar cómo se accede a ellos

## 🏗️ Campos Privados vs Propiedades Públicas

### ❌ SIN Encapsulación (MALO):
```csharp
public class CuentaBancaria
{
    public decimal Saldo;  // ← ¡PELIGRO! Cualquiera puede cambiarlo
}

// En el formulario:
CuentaBancaria cuenta = new CuentaBancaria();
cuenta.Saldo = -5000;  // ← ¡NADIE LO IMPIDE! 💥
```

### ✅ CON Encapsulación (BUENO):
```csharp
public class CuentaBancaria
{
    // Campo privado (nadie puede tocarlo directamente)
    private decimal _saldo;
    
    // Propiedad pública (con validación)
    public decimal Saldo
    {
        get { return _saldo; }
        set
        {
            // ¡VALIDACIÓN! No permitir negativos
            if (value >= 0)
            {
                _saldo = value;
            }
            else
            {
                MessageBox.Show("El saldo no puede ser negativo");
            }
        }
    }
}
```

## 🎨 Ejemplo Práctico: Validación Visual

Vamos a crear una clase **Estudiante** con validación que se vea en el formulario:

### Paso 1: Crear la Clase con Encapsulación
```csharp
public class Estudiante
{
    // Campos privados (protegidos)
    private string _nombre;
    private int _edad;
    private double _nota;
    
    // Propiedad con validación
    public string Nombre
    {
        get { return _nombre; }
        set
        {
            // Validar que no esté vacío
            if (!string.IsNullOrWhiteSpace(value))
            {
                _nombre = value;
            }
        }
    }
    
    // Propiedad con validación de rango
    public int Edad
    {
        get { return _edad; }
        set
        {
            // Solo aceptar edades entre 15 y 100
            if (value >= 15 && value <= 100)
            {
                _edad = value;
            }
        }
    }
    
    // Propiedad con validación de nota
    public double Nota
    {
        get { return _nota; }
        set
        {
            // Solo notas entre 0 y 20
            if (value >= 0 && value <= 20)
            {
                _nota = value;
            }
        }
    }
    
    // Constructor
    public Estudiante()
    {
        _nombre = "";
        _edad = 18;
        _nota = 0;
    }
    
    // Método para saber si aprobó
    public bool EstaAprobado()
    {
        return _nota >= 10.5;
    }
}
```

### Paso 2: Formulario con Validación Visual
```csharp
public partial class FormEstudiante : Form
{
    // Nuestro objeto estudiante
    private Estudiante miEstudiante;
    
    // Controles del formulario
    private TextBox txtNombre;
    private TextBox txtEdad;
    private TextBox txtNota;
    private Button btnGuardar;
    private Button btnVerificar;
    private Label lblResultado;
    private Label lblErrorNombre;
    private Label lblErrorEdad;
    private Label lblErrorNota;
    
    public FormEstudiante()
    {
        InitializeComponent();
        miEstudiante = new Estudiante();
    }
    
    private void InitializeComponent()
    {
        this.Text = "Registro de Estudiante";
        this.Size = new Size(400, 350);
        
        // Nombre
        Label lblNom = new Label();
        lblNom.Text = "Nombre:";
        lblNom.Location = new Point(20, 20);
        lblNom.Size = new Size(80, 20);
        
        txtNombre = new TextBox();
        txtNombre.Location = new Point(110, 20);
        txtNombre.Size = new Size(200, 20);
        // ← Validar al escribir
        txtNombre.TextChanged += TxtNombre_TextChanged;
        
        // Label de error para nombre
        lblErrorNombre = new Label();
        lblErrorNombre.Location = new Point(110, 45);
        lblErrorNombre.Size = new Size(200, 20);
        lblErrorNombre.ForeColor = Color.Red;
        lblErrorNombre.Text = "";
        lblErrorNombre.Font = new Font("Arial", 8);
        
        // Edad
        Label lblEd = new Label();
        lblEd.Text = "Edad:";
        lblEd.Location = new Point(20, 75);
        lblEd.Size = new Size(80, 20);
        
        txtEdad = new TextBox();
        txtEdad.Location = new Point(110, 75);
        txtEdad.Size = new Size(80, 20);
        txtEdad.TextChanged += TxtEdad_TextChanged;
        
        lblErrorEdad = new Label();
        lblErrorEdad.Location = new Point(110, 100);
        lblErrorEdad.Size = new Size(200, 20);
        lblErrorEdad.ForeColor = Color.Red;
        lblErrorEdad.Text = "";
        lblErrorEdad.Font = new Font("Arial", 8);
        
        // Nota
        Label lblNot = new Label();
        lblNot.Text = "Nota (0-20):";
        lblNot.Location = new Point(20, 130);
        lblNot.Size = new Size(80, 20);
        
        txtNota = new TextBox();
        txtNota.Location = new Point(110, 130);
        txtNota.Size = new Size(80, 20);
        txtNota.TextChanged += TxtNota_TextChanged;
        
        lblErrorNota = new Label();
        lblErrorNota.Location = new Point(110, 155);
        lblErrorNota.Size = new Size(200, 20);
        lblErrorNota.ForeColor = Color.Red;
        lblErrorNota.Text = "";
        lblErrorNota.Font = new Font("Arial", 8);
        
        // Botones
        btnGuardar = new Button();
        btnGuardar.Text = "Guardar";
        btnGuardar.Location = new Point(20, 190);
        btnGuardar.Size = new Size(100, 30);
        btnGuardar.Click += BtnGuardar_Click;
        
        btnVerificar = new Button();
        btnVerificar.Text = "Verificar Nota";
        btnVerificar.Location = new Point(130, 190);
        btnVerificar.Size = new Size(100, 30);
        btnVerificar.Click += BtnVerificar_Click;
        
        // Resultado
        lblResultado = new Label();
        lblResultado.Location = new Point(20, 240);
        lblResultado.Size = new Size(350, 50);
        lblResultado.BorderStyle = BorderStyle.FixedSingle;
        lblResultado.Text = "";
        lblResultado.Font = new Font("Arial", 10, FontStyle.Bold);
        
        // Agregar todo al formulario
        this.Controls.Add(lblNom);
        this.Controls.Add(txtNombre);
        this.Controls.Add(lblErrorNombre);
        this.Controls.Add(lblEd);
        this.Controls.Add(txtEdad);
        this.Controls.Add(lblErrorEdad);
        this.Controls.Add(lblNot);
        this.Controls.Add(txtNota);
        this.Controls.Add(lblErrorNota);
        this.Controls.Add(btnGuardar);
        this.Controls.Add(btnVerificar);
        this.Controls.Add(lblResultado);
    }
    
    // Validar nombre al escribir
    private void TxtNombre_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            // ❌ Error: cambiar a rojo
            txtNombre.BackColor = Color.LightPink;
            lblErrorNombre.Text = "El nombre es requerido";
        }
        else
        {
            // ✅ Correcto: cambiar a verde
            txtNombre.BackColor = Color.LightGreen;
            lblErrorNombre.Text = "";
        }
    }
    
    // Validar edad al escribir
    private void TxtEdad_TextChanged(object sender, EventArgs e)
    {
        if (int.TryParse(txtEdad.Text, out int edad))
        {
            if (edad >= 15 && edad <= 100)
            {
                // ✅ Edad válida
                txtEdad.BackColor = Color.LightGreen;
                lblErrorEdad.Text = "";
            }
            else
            {
                // ❌ Edad fuera de rango
                txtEdad.BackColor = Color.LightPink;
                lblErrorEdad.Text = "Edad debe estar entre 15 y 100";
            }
        }
        else if (!string.IsNullOrEmpty(txtEdad.Text))
        {
            // ❌ No es un número
            txtEdad.BackColor = Color.LightPink;
            lblErrorEdad.Text = "Debe ser un número";
        }
    }
    
    // Validar nota al escribir
    private void TxtNota_TextChanged(object sender, EventArgs e)
    {
        if (double.TryParse(txtNota.Text, out double nota))
        {
            if (nota >= 0 && nota <= 20)
            {
                // ✅ Nota válida
                txtNota.BackColor = Color.LightGreen;
                lblErrorNota.Text = "";
            }
            else
            {
                // ❌ Nota fuera de rango
                txtNota.BackColor = Color.LightPink;
                lblErrorNota.Text = "Nota debe estar entre 0 y 20";
            }
        }
        else if (!string.IsNullOrEmpty(txtNota.Text))
        {
            // ❌ No es un número
            txtNota.BackColor = Color.LightPink;
            lblErrorNota.Text = "Debe ser un número";
        }
    }
    
    // Guardar estudiante
    private void BtnGuardar_Click(object sender, EventArgs e)
    {
        // Validar todo antes de guardar
        bool nombreValido = !string.IsNullOrWhiteSpace(txtNombre.Text);
        bool edadValida = int.TryParse(txtEdad.Text, out int edad) && edad >= 15 && edad <= 100;
        bool notaValida = double.TryParse(txtNota.Text, out double nota) && nota >= 0 && nota <= 20;
        
        if (nombreValido && edadValida && notaValida)
        {
            // Todo válido: guardar en el objeto
            miEstudiante.Nombre = txtNombre.Text;
            miEstudiante.Edad = edad;
            miEstudiante.Nota = nota;
            
            lblResultado.Text = "✅ Estudiante guardado correctamente";
            lblResultado.ForeColor = Color.Green;
        }
        else
        {
            lblResultado.Text = "❌ Corrige los errores antes de guardar";
            lblResultado.ForeColor = Color.Red;
        }
    }
    
    // Verificar si aprobó
    private void BtnVerificar_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(miEstudiante.Nombre))
        {
            if (miEstudiante.EstaAprobado())
            {
                lblResultado.Text = $"🎉 {miEstudiante.Nombre} APROBÓ con {miEstudiante.Nota}";
                lblResultado.ForeColor = Color.Green;
            }
            else
            {
                lblResultado.Text = $"😞 {miEstudiante.Nombre} no aprobó. Nota: {miEstudiante.Nota}";
                lblResultado.ForeColor = Color.Red;
            }
        }
        else
        {
            lblResultado.Text = "Primero guarda un estudiante";
            lblResultado.ForeColor = Color.Orange;
        }
    }
}
```

### 📝 Así se ve el formulario con validación:
```
┌────────────────────────────────────────┐
│  Registro de Estudiante          [X]   │
├────────────────────────────────────────┤
│  Nombre: [Ana García           ]  ✅   │
│                                        │
│  Edad:   [25]  ✅                      │
│                                        │
│  Nota:   [15.5]  ✅                    │
│          (0-20)                        │
│                                        │
│  [Guardar]  [Verificar Nota]           │
│                                        │
│  ┌────────────────────────────────┐   │
│  │ ✅ Estudiante guardado          │   │
│  └────────────────────────────────┘   │
└────────────────────────────────────────┘

// Si hay error:
┌────────────────────────────────────────┐
│  Nombre: [        ]  ❌ (rojo)         │
│          El nombre es requerido        │
│                                        │
│  Edad:   [150]  ❌ (rojo)              │
│          Edad debe estar entre 15-100  │
└────────────────────────────────────────┘
```

## 🔒 Niveles de Acceso (Modificadores)

### public (Público)
```csharp
public string Nombre { get; set; }  // ← Todos pueden verlo y modificarlo
```

### private (Privado)
```csharp
private decimal _saldo;  // ← Solo esta clase puede verlo
```

### Ejemplo Visual de Modificadores:
```csharp
public class CuentaBancaria
{
    // PRIVADO - Solo esta clase lo usa
    private decimal _saldo;
    private string _numeroCuenta;
    
    // PÚBLICO - Todos pueden acceder
    public string TitularNombre { get; set; }
    
    // Constructor público
    public CuentaBancaria(string titular)
    {
        TitularNombre = titular;
        _saldo = 0;
        _numeroCuenta = GenerarNumeroCuenta();  // ← Método privado
    }
    
    // Método público - todos pueden usarlo
    public void Depositar(decimal monto)
    {
        if (ValidarMonto(monto))  // ← Usa método privado
        {
            _saldo += monto;
        }
    }
    
    // Método público
    public decimal ConsultarSaldo()
    {
        return _saldo;
    }
    
    // Método privado - solo para uso interno
    private bool ValidarMonto(decimal monto)
    {
        return monto > 0;
    }
    
    // Método privado
    private string GenerarNumeroCuenta()
    {
        Random rnd = new Random();
        return rnd.Next(1000, 9999).ToString();
    }
}
```

## 🎯 Ejemplo Completo Simple: Contador con Límites

Vamos a crear un contador que NO permita números negativos ni mayores a 100:

```csharp
// Clase con encapsulación
public class ContadorLimitado
{
    // Campo privado (protegido)
    private int _valor;
    
    // Propiedad pública con validación
    public int Valor
    {
        get { return _valor; }
        private set  // ← Solo la clase puede cambiar directamente
        {
            if (value >= 0 && value <= 100)
            {
                _valor = value;
            }
        }
    }
    
    // Constructor
    public ContadorLimitado()
    {
        _valor = 0;
    }
    
    // Métodos públicos (la única forma de cambiar el valor)
    public bool Incrementar()
    {
        if (_valor < 100)
        {
            _valor++;
            return true;  // ← Éxito
        }
        return false;  // ← No se pudo (llegó al límite)
    }
    
    public bool Decrementar()
    {
        if (_valor > 0)
        {
            _valor--;
            return true;
        }
        return false;
    }
    
    public void Reiniciar()
    {
        _valor = 0;
    }
}

// Formulario
public partial class FormContador : Form
{
    private ContadorLimitado miContador;
    private Label lblNumero;
    private Label lblLimite;
    private Button btnMas;
    private Button btnMenos;
    private Button btnReiniciar;
    
    public FormContador()
    {
        InitializeComponent();
        miContador = new ContadorLimitado();
        ActualizarDisplay();
    }
    
    private void InitializeComponent()
    {
        this.Text = "Contador con Límites";
        this.Size = new Size(300, 250);
        
        // Número grande
        lblNumero = new Label();
        lblNumero.Text = "0";
        lblNumero.Location = new Point(100, 40);
        lblNumero.Size = new Size(100, 50);
        lblNumero.Font = new Font("Arial", 32, FontStyle.Bold);
        lblNumero.TextAlign = ContentAlignment.MiddleCenter;
        
        // Límite
        lblLimite = new Label();
        lblLimite.Text = "Límite: 0 - 100";
        lblLimite.Location = new Point(80, 100);
        lblLimite.Size = new Size(140, 20);
        lblLimite.TextAlign = ContentAlignment.MiddleCenter;
        
        // Botón +
        btnMas = new Button();
        btnMas.Text = "+";
        btnMas.Location = new Point(50, 140);
        btnMas.Size = new Size(50, 40);
        btnMas.Font = new Font("Arial", 16, FontStyle.Bold);
        btnMas.Click += BtnMas_Click;
        
        // Botón -
        btnMenos = new Button();
        btnMenos.Text = "-";
        btnMenos.Location = new Point(110, 140);
        btnMenos.Size = new Size(50, 40);
        btnMenos.Font = new Font("Arial", 16, FontStyle.Bold);
        btnMenos.Click += BtnMenos_Click;
        
        // Botón reiniciar
        btnReiniciar = new Button();
        btnReiniciar.Text = "Reiniciar";
        btnReiniciar.Location = new Point(170, 140);
        btnReiniciar.Size = new Size(80, 40);
        btnReiniciar.Click += BtnReiniciar_Click;
        
        this.Controls.Add(lblNumero);
        this.Controls.Add(lblLimite);
        this.Controls.Add(btnMas);
        this.Controls.Add(btnMenos);
        this.Controls.Add(btnReiniciar);
    }
    
    private void BtnMas_Click(object sender, EventArgs e)
    {
        if (miContador.Incrementar())
        {
            // ✅ Se pudo incrementar
            ActualizarDisplay();
        }
        else
        {
            // ❌ Llegó al límite
            MessageBox.Show("¡Llegaste al máximo! (100)", "Límite alcanzado");
        }
    }
    
    private void BtnMenos_Click(object sender, EventArgs e)
    {
        if (miContador.Decrementar())
        {
            ActualizarDisplay();
        }
        else
        {
            MessageBox.Show("¡Ya estás en cero!", "Límite alcanzado");
        }
    }
    
    private void BtnReiniciar_Click(object sender, EventArgs e)
    {
        miContador.Reiniciar();
        ActualizarDisplay();
    }
    
    private void ActualizarDisplay()
    {
        lblNumero.Text = miContador.Valor.ToString();
        
        // Cambiar color según el valor
        if (miContador.Valor == 0)
        {
            lblNumero.ForeColor = Color.Gray;
        }
        else if (miContador.Valor >= 90)
        {
            lblNumero.ForeColor = Color.Red;  // ← Cerca del límite
        }
        else if (miContador.Valor >= 50)
        {
            lblNumero.ForeColor = Color.Orange;
        }
        else
        {
            lblNumero.ForeColor = Color.Green;
        }
    }
}
```

## 🎮 ¡Tú Hazlo! - Ejercicio Guiado

### Crea una clase "ProductoTienda"

```csharp
public class ProductoTienda
{
    // 1. Crea campos privados:
    //    - _nombre (string)
    //    - _precio (decimal)
    //    - _stock (int)
    
    // 2. Crea propiedades públicas con validación:
    //    - Nombre: no puede estar vacío
    //    - Precio: debe ser mayor a 0
    //    - Stock: debe ser mayor o igual a 0
    
    // 3. Crea un constructor que inicialice todo en valores seguros
    
    // 4. Crea un método "Vender(int cantidad)" que:
    //    - Verifique que haya suficiente stock
    //    - Reste la cantidad del stock
    //    - Retorne true si se pudo vender, false si no
}
```

### El formulario debe verse así:
```
┌───────────────────────────────┐
│  Tienda - Producto       [X]  │
├───────────────────────────────┤
│  Nombre:  [Laptop    ]        │
│  Precio:  [1200      ]        │
│  Stock:   [10        ]        │
│                               │
│  [Guardar Producto]           │
│                               │
│  Cantidad a vender: [3]       │
│  [Vender]                     │
│                               │
│  Stock restante: 7            │
└───────────────────────────────┘
```

## 💡 Puntos Importantes para Recordar

### ✅ Ventajas de la Encapsulación:

1. **Seguridad**: Los datos están protegidos
```csharp
private decimal _saldo;  // ← Nadie lo toca sin permiso
```

2. **Validación**: Controlas qué valores son válidos
```csharp
public int Edad
{
    set
    {
        if (value >= 0 && value <= 120)  // ← Validación
            _edad = value;
    }
}
```

3. **Cambios Fáciles**: Puedes cambiar la lógica interna sin afectar el resto
```csharp
// Puedes cambiar cómo se guarda, pero la interfaz pública no cambia
private decimal _saldo;  // Antes: variable simple
private List<decimal> _historial;  // Después: con historial
```

### ❌ Errores Comunes:

1. **NO hacer todo público**:
```csharp
// ❌ MALO
public class Persona
{
    public int Edad;  // ← Peligro: cualquiera lo cambia
}

// ✅ BUENO
public class Persona
{
    private int _edad;  // ← Protegido
    public int Edad
    {
        get { return _edad; }
        set { if (value > 0) _edad = value; }  // ← Con validación
    }
}
```

2. **NO olvidar validar**:
```csharp
// ❌ MALO
public decimal Precio
{
    get { return _precio; }
    set { _precio = value; }  // ← Sin validación
}

// ✅ BUENO
public decimal Precio
{
    get { return _precio; }
    set
    {
        if (value > 0)  // ← Con validación
            _precio = value;
    }
}
```

## 🔚 Resumen

- **Encapsulación** = Proteger los datos y controlar el acceso
- Usa **campos privados** (`private`) para guardar datos
- Usa **propiedades públicas** (`public`) para dar acceso controlado
- Siempre **valida** los datos antes de guardarlos
- Los **métodos públicos** son la única forma segura de modificar datos privados
- La validación visual ayuda al usuario a ver los errores inmediatamente
- Cambiar el color de los controles (rojo/verde) es una forma fácil de validar

### Regla de Oro:
> **"Si es importante, hazlo privado y controla el acceso"**

## ➡️ Siguiente: [Teoría 04: Herencia con Windows Forms](Teoria-04-Herencia-WinForms.md)
