# 📖 Teoría 01: Fundamentos de Clases Aplicadas a Windows Forms

## 🎯 Objetivos de Aprendizaje
Al finalizar esta lección, podrás:
- Entender qué es una clase usando controles de Windows Forms como ejemplo
- Identificar los componentes básicos de una clase aplicados a formularios
- Crear clases que interactúan con la interfaz gráfica
- Usar constructores para inicializar objetos que manejan datos de formularios
- Visualizar conceptos abstractos a través de elementos gráficos concretos

## 🤔 ¿Qué es una Clase? (Perspectiva Visual)

### Analogía del Mundo Real con Controles
Piensa en un **botón** de Windows Forms:
- **Características visibles**: Text, BackColor, Size, Location, Enabled
- **Acciones que puede realizar**: Click, MouseEnter, MouseLeave
- **Datos internos**: estado presionado/no presionado, eventos asociados

En POO, una **clase** es como el diseño de ese botón que define:
- **Propiedades**: qué características visuales puede tener
- **Métodos**: qué acciones puede realizar
- **Eventos**: cómo responde a la interacción del usuario

### De Python a C# con Interfaz Visual
```python
# Python con tkinter - Concepto básico
import tkinter as tk

class CalculadoraSimple:
    def __init__(self):
        self.ventana = tk.Tk()
        self.resultado = 0
        self.crear_interfaz()
    
    def sumar(self, a, b):
        self.resultado = a + b
        return self.resultado
```

```csharp
// C# con Windows Forms - Implementación visual
using System;
using System.Windows.Forms;

public partial class CalculadoraSimple : Form
{
    // Campos (datos internos de la clase)
    private double _resultado;
    private double _numeroActual;
    
    // Controles (elementos visuales)
    private TextBox txtDisplay;
    private Button btnSumar;
    private Button btnIgual;
    
    // Constructor (inicializa la interfaz)
    public CalculadoraSimple()
    {
        InitializeComponent();
        _resultado = 0;
        _numeroActual = 0;
    }
    
    // Método (acción que puede realizar)
    public double Sumar(double a, double b)
    {
        _resultado = a + b;
        ActualizarDisplay();
        return _resultado;
    }
    
    // Método privado para actualizar la interfaz
    private void ActualizarDisplay()
    {
        txtDisplay.Text = _resultado.ToString();
    }
}
```

## 🏗️ Anatomía de una Clase aplicada a Windows Forms

### Ejemplo Práctico: Clase Producto con Interfaz Visual

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

public partial class FormProducto : Form
{
    // 1. CAMPOS PRIVADOS (datos internos)
    private Producto _productoActual;
    
    // 2. CONTROLES (elementos visuales)
    private TextBox txtNombre;
    private TextBox txtPrecio;
    private TextBox txtStock;
    private Label lblTotal;
    private Button btnGuardar;
    private Button btnCalcular;
    
    // 3. CONSTRUCTOR (inicialización)
    public FormProducto()
    {
        InitializeComponent();
        _productoActual = new Producto();
        ConfigurarEventos();
    }
    
    // 4. MÉTODOS PRIVADOS (lógica interna)
    private void ConfigurarEventos()
    {
        btnGuardar.Click += BtnGuardar_Click;
        btnCalcular.Click += BtnCalcular_Click;
        
        // Validación en tiempo real
        txtPrecio.KeyPress += ValidarNumeros;
        txtStock.KeyPress += ValidarNumeros;
    }
    
    private void ValidarNumeros(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        {
            e.Handled = true;
        }
    }
    
    // 5. EVENTOS (respuesta a acciones del usuario)
    private void BtnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            _productoActual.Nombre = txtNombre.Text;
            _productoActual.Precio = decimal.Parse(txtPrecio.Text);
            _productoActual.Stock = int.Parse(txtStock.Text);
            
            MessageBox.Show("Producto guardado correctamente", "Éxito", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", 
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void BtnCalcular_Click(object sender, EventArgs e)
    {
        if (_productoActual != null)
        {
            decimal valorTotal = _productoActual.CalcularValorInventario();
            lblTotal.Text = $"Valor Total: ${valorTotal:F2}";
            lblTotal.ForeColor = valorTotal > 1000 ? Color.Green : Color.Orange;
        }
    }
    
    private void LimpiarFormulario()
    {
        txtNombre.Clear();
        txtPrecio.Clear();
        txtStock.Clear();
        lblTotal.Text = "Valor Total: $0.00";
        txtNombre.Focus();
    }
}

// Clase de datos (modelo)
public class Producto
{
    // Campos privados
    private string _nombre;
    private decimal _precio;
    private int _stock;
    
    // Propiedades con validación visual
    public string Nombre
    {
        get { return _nombre; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre no puede estar vacío");
            _nombre = value.Trim();
        }
    }
    
    public decimal Precio
    {
        get { return _precio; }
        set
        {
            if (value < 0)
                throw new ArgumentException("El precio no puede ser negativo");
            _precio = value;
        }
    }
    
    public int Stock
    {
        get { return _stock; }
        set
        {
            if (value < 0)
                throw new ArgumentException("El stock no puede ser negativo");
            _stock = value;
        }
    }
    
    // Propiedad calculada
    public decimal ValorInventario
    {
        get { return _precio * _stock; }
    }
    
    // Constructor
    public Producto()
    {
        _nombre = "";
        _precio = 0;
        _stock = 0;
    }
    
    public Producto(string nombre, decimal precio, int stock)
    {
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }
    
    // Métodos
    public decimal CalcularValorInventario()
    {
        return Precio * Stock;
    }
    
    public bool VenderProducto(int cantidad)
    {
        if (cantidad <= 0 || cantidad > _stock)
            return false;
            
        _stock -= cantidad;
        return true;
    }
    
    public override string ToString()
    {
        return $"{_nombre} - ${_precio:F2} ({_stock} unidades)";
    }
}
```

## 🎨 Diseño Visual del Formulario

### InitializeComponent() - Diseño de la Interfaz
```csharp
private void InitializeComponent()
{
    // Configuración del formulario principal
    this.Text = "Gestión de Productos";
    this.Size = new Size(400, 300);
    this.StartPosition = FormStartPosition.CenterScreen;
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.MaximizeBox = false;
    
    // TextBox para nombre
    txtNombre = new TextBox();
    txtNombre.Location = new Point(120, 30);
    txtNombre.Size = new Size(200, 20);
    
    // TextBox para precio
    txtPrecio = new TextBox();
    txtPrecio.Location = new Point(120, 70);
    txtPrecio.Size = new Size(100, 20);
    
    // TextBox para stock
    txtStock = new TextBox();
    txtStock.Location = new Point(120, 110);
    txtStock.Size = new Size(100, 20);
    
    // Label para mostrar total
    lblTotal = new Label();
    lblTotal.Location = new Point(120, 150);
    lblTotal.Size = new Size(200, 20);
    lblTotal.Text = "Valor Total: $0.00";
    lblTotal.Font = new Font("Arial", 10, FontStyle.Bold);
    
    // Botón guardar
    btnGuardar = new Button();
    btnGuardar.Location = new Point(50, 200);
    btnGuardar.Size = new Size(100, 30);
    btnGuardar.Text = "Guardar";
    btnGuardar.BackColor = Color.LightBlue;
    
    // Botón calcular
    btnCalcular = new Button();
    btnCalcular.Location = new Point(200, 200);
    btnCalcular.Size = new Size(100, 30);
    btnCalcular.Text = "Calcular Total";
    btnCalcular.BackColor = Color.LightGreen;
    
    // Labels descriptivos
    Label lblNombre = new Label() { Text = "Nombre:", Location = new Point(50, 30), Size = new Size(60, 20) };
    Label lblPrecio = new Label() { Text = "Precio:", Location = new Point(50, 70), Size = new Size(60, 20) };
    Label lblStock = new Label() { Text = "Stock:", Location = new Point(50, 110), Size = new Size(60, 20) };
    
    // Agregar controles al formulario
    this.Controls.Add(lblNombre);
    this.Controls.Add(txtNombre);
    this.Controls.Add(lblPrecio);
    this.Controls.Add(txtPrecio);
    this.Controls.Add(lblStock);
    this.Controls.Add(txtStock);
    this.Controls.Add(lblTotal);
    this.Controls.Add(btnGuardar);
    this.Controls.Add(btnCalcular);
}
```

## 🔧 Componentes de una Clase Visualizados

### 1. Campos vs Propiedades (Demostración Visual)
```csharp
public partial class FormEjemplo : Form
{
    // CAMPO PRIVADO - no visible directamente en la interfaz
    private string _datosInternos = "Datos ocultos";
    
    // PROPIEDAD PÚBLICA - conectada a control visual
    public string DatosVisibles 
    { 
        get { return txtDisplay.Text; }
        set { txtDisplay.Text = value; }
    }
    
    private TextBox txtDisplay;
    private Button btnMostrarCampo;
    private Button btnCambiarPropiedad;
    
    public FormEjemplo()
    {
        InitializeComponent();
        ConfigurarEventos();
    }
    
    private void ConfigurarEventos()
    {
        // El botón muestra la diferencia entre campo y propiedad
        btnMostrarCampo.Click += (s, e) => 
        {
            MessageBox.Show($"Campo privado: {_datosInternos}\nPropiedad visible: {DatosVisibles}");
        };
        
        btnCambiarPropiedad.Click += (s, e) =>
        {
            DatosVisibles = DateTime.Now.ToString();
        };
    }
}
```

### 2. Constructores Aplicados a Formularios
```csharp
public partial class FormContacto : Form
{
    private Contacto _contacto;
    
    // Constructor por defecto - formulario vacío
    public FormContacto()
    {
        InitializeComponent();
        _contacto = new Contacto();
        ConfigurarFormularioVacio();
    }
    
    // Constructor con datos - formulario prellenado
    public FormContacto(Contacto contactoExistente)
    {
        InitializeComponent();
        _contacto = contactoExistente;
        CargarDatosEnFormulario();
    }
    
    // Constructor para modo solo lectura
    public FormContacto(Contacto contacto, bool soloLectura)
    {
        InitializeComponent();
        _contacto = contacto;
        CargarDatosEnFormulario();
        
        if (soloLectura)
        {
            HabilitarModoLectura();
        }
    }
    
    private void ConfigurarFormularioVacio()
    {
        txtNombre.Text = "";
        txtTelefono.Text = "";
        txtEmail.Text = "";
        txtNombre.Focus();
    }
    
    private void CargarDatosEnFormulario()
    {
        txtNombre.Text = _contacto.Nombre;
        txtTelefono.Text = _contacto.Telefono;
        txtEmail.Text = _contacto.Email;
    }
    
    private void HabilitarModoLectura()
    {
        txtNombre.ReadOnly = true;
        txtTelefono.ReadOnly = true;
        txtEmail.ReadOnly = true;
        btnGuardar.Enabled = false;
        
        // Cambiar colores para indicar modo lectura
        txtNombre.BackColor = Color.LightGray;
        txtTelefono.BackColor = Color.LightGray;
        txtEmail.BackColor = Color.LightGray;
    }
}
```

### 3. Métodos con Retroalimentación Visual
```csharp
public class ValidadorFormulario
{
    // Método estático que proporciona validación visual
    public static bool ValidarCampo(TextBox campo, Label labelError, string nombreCampo)
    {
        if (string.IsNullOrWhiteSpace(campo.Text))
        {
            // Retroalimentación visual de error
            campo.BackColor = Color.LightPink;
            labelError.Text = $"{nombreCampo} es requerido";
            labelError.ForeColor = Color.Red;
            labelError.Visible = true;
            return false;
        }
        else
        {
            // Retroalimentación visual de éxito
            campo.BackColor = Color.LightGreen;
            labelError.Visible = false;
            return true;
        }
    }
    
    public static bool ValidarEmail(TextBox campoEmail, Label labelError)
    {
        try
        {
            var direccion = new System.Net.Mail.MailAddress(campoEmail.Text);
            campoEmail.BackColor = Color.LightGreen;
            labelError.Visible = false;
            return true;
        }
        catch
        {
            campoEmail.BackColor = Color.LightPink;
            labelError.Text = "Formato de email inválido";
            labelError.ForeColor = Color.Red;
            labelError.Visible = true;
            return false;
        }
    }
}

// Uso en el formulario
public partial class FormRegistro : Form
{
    private void btnValidar_Click(object sender, EventArgs e)
    {
        bool nombreValido = ValidadorFormulario.ValidarCampo(txtNombre, lblErrorNombre, "Nombre");
        bool emailValido = ValidadorFormulario.ValidarEmail(txtEmail, lblErrorEmail);
        
        if (nombreValido && emailValido)
        {
            MessageBox.Show("✅ Todos los campos son válidos", "Validación Exitosa", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("❌ Por favor corrige los errores", "Errores de Validación", 
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
```

## 🎯 Ejemplo Completo: Sistema de Biblioteca Visual

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

// Clase de datos - Libro
public class Libro
{
    public string ISBN { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public bool EstaPrestado { get; private set; }
    public DateTime FechaPrestamo { get; private set; }
    
    public Libro(string isbn, string titulo, string autor)
    {
        ISBN = isbn;
        Titulo = titulo;
        Autor = autor;
        EstaPrestado = false;
    }
    
    public bool Prestar()
    {
        if (!EstaPrestado)
        {
            EstaPrestado = true;
            FechaPrestamo = DateTime.Now;
            return true;
        }
        return false;
    }
    
    public void Devolver()
    {
        EstaPrestado = false;
        FechaPrestamo = DateTime.MinValue;
    }
    
    public override string ToString()
    {
        string estado = EstaPrestado ? "PRESTADO" : "DISPONIBLE";
        return $"{Titulo} - {Autor} [{estado}]";
    }
}

// Formulario principal de la biblioteca
public partial class FormBiblioteca : Form
{
    private List<Libro> _libros;
    private ListBox lstLibros;
    private TextBox txtISBN, txtTitulo, txtAutor;
    private Button btnAgregar, btnPrestar, btnDevolver;
    private Label lblEstado, lblTotal, lblDisponibles, lblPrestados;
    
    public FormBiblioteca()
    {
        InitializeComponent();
        _libros = new List<Libro>();
        InicializarDatosPrueba();
        ActualizarEstadisticas();
    }
    
    private void InitializeComponent()
    {
        // Configuración del formulario
        this.Text = "Sistema de Biblioteca - POO Visual";
        this.Size = new Size(600, 500);
        this.StartPosition = FormStartPosition.CenterScreen;
        
        // Panel de entrada de datos
        GroupBox gbDatos = new GroupBox();
        gbDatos.Text = "Datos del Libro";
        gbDatos.Location = new Point(20, 20);
        gbDatos.Size = new Size(250, 150);
        
        Label lblISBN = new Label() { Text = "ISBN:", Location = new Point(10, 30), Size = new Size(50, 20) };
        txtISBN = new TextBox() { Location = new Point(70, 30), Size = new Size(150, 20) };
        
        Label lblTit = new Label() { Text = "Título:", Location = new Point(10, 60), Size = new Size(50, 20) };
        txtTitulo = new TextBox() { Location = new Point(70, 60), Size = new Size(150, 20) };
        
        Label lblAut = new Label() { Text = "Autor:", Location = new Point(10, 90), Size = new Size(50, 20) };
        txtAutor = new TextBox() { Location = new Point(70, 90), Size = new Size(150, 20) };
        
        btnAgregar = new Button() { Text = "Agregar Libro", Location = new Point(70, 120), Size = new Size(100, 25), BackColor = Color.LightBlue };
        
        gbDatos.Controls.AddRange(new Control[] { lblISBN, txtISBN, lblTit, txtTitulo, lblAut, txtAutor, btnAgregar });
        
        // Lista de libros
        GroupBox gbLista = new GroupBox();
        gbLista.Text = "Inventario de Libros";
        gbLista.Location = new Point(290, 20);
        gbLista.Size = new Size(280, 300);
        
        lstLibros = new ListBox();
        lstLibros.Location = new Point(10, 30);
        lstLibros.Size = new Size(260, 200);
        lstLibros.SelectionMode = SelectionMode.One;
        
        btnPrestar = new Button() { Text = "Prestar", Location = new Point(10, 240), Size = new Size(80, 30), BackColor = Color.LightGreen };
        btnDevolver = new Button() { Text = "Devolver", Location = new Point(100, 240), Size = new Size(80, 30), BackColor = Color.LightCoral };
        
        gbLista.Controls.AddRange(new Control[] { lstLibros, btnPrestar, btnDevolver });
        
        // Panel de estadísticas
        GroupBox gbEstadisticas = new GroupBox();
        gbEstadisticas.Text = "Estadísticas";
        gbEstadisticas.Location = new Point(20, 180);
        gbEstadisticas.Size = new Size(250, 140);
        
        lblTotal = new Label() { Location = new Point(10, 30), Size = new Size(200, 20), Font = new Font("Arial", 9, FontStyle.Bold) };
        lblDisponibles = new Label() { Location = new Point(10, 55), Size = new Size(200, 20), ForeColor = Color.Green };
        lblPrestados = new Label() { Location = new Point(10, 80), Size = new Size(200, 20), ForeColor = Color.Red };
        lblEstado = new Label() { Location = new Point(10, 105), Size = new Size(230, 20), ForeColor = Color.Blue };
        
        gbEstadisticas.Controls.AddRange(new Control[] { lblTotal, lblDisponibles, lblPrestados, lblEstado });
        
        // Agregar todos los controles al formulario
        this.Controls.AddRange(new Control[] { gbDatos, gbLista, gbEstadisticas });
        
        // Configurar eventos
        btnAgregar.Click += BtnAgregar_Click;
        btnPrestar.Click += BtnPrestar_Click;
        btnDevolver.Click += BtnDevolver_Click;
        lstLibros.SelectedIndexChanged += LstLibros_SelectedIndexChanged;
    }
    
    private void InicializarDatosPrueba()
    {
        _libros.Add(new Libro("978-84-376-0494-7", "1984", "George Orwell"));
        _libros.Add(new Libro("978-84-376-0495-4", "Cien años de soledad", "Gabriel García Márquez"));
        _libros.Add(new Libro("978-84-376-0496-1", "El Quijote", "Miguel de Cervantes"));
        ActualizarListaLibros();
    }
    
    private void BtnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text) || 
                string.IsNullOrWhiteSpace(txtTitulo.Text) || 
                string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                MessageBox.Show("Todos los campos son requeridos", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Verificar ISBN único
            if (_libros.Any(l => l.ISBN == txtISBN.Text))
            {
                MessageBox.Show("Ya existe un libro con este ISBN", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            Libro nuevoLibro = new Libro(txtISBN.Text, txtTitulo.Text, txtAutor.Text);
            _libros.Add(nuevoLibro);
            
            ActualizarListaLibros();
            ActualizarEstadisticas();
            LimpiarFormulario();
            
            MessageBox.Show("Libro agregado correctamente", "Éxito", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al agregar libro: {ex.Message}", "Error", 
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void BtnPrestar_Click(object sender, EventArgs e)
    {
        if (lstLibros.SelectedItem == null)
        {
            MessageBox.Show("Selecciona un libro de la lista", "Advertencia", 
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        Libro libroSeleccionado = (Libro)lstLibros.SelectedItem;
        
        if (libroSeleccionado.Prestar())
        {
            ActualizarListaLibros();
            ActualizarEstadisticas();
            MessageBox.Show($"Libro '{libroSeleccionado.Titulo}' prestado correctamente", "Préstamo Exitoso", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Este libro ya está prestado", "Error", 
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    
    private void BtnDevolver_Click(object sender, EventArgs e)
    {
        if (lstLibros.SelectedItem == null)
        {
            MessageBox.Show("Selecciona un libro de la lista", "Advertencia", 
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        Libro libroSeleccionado = (Libro)lstLibros.SelectedItem;
        
        if (libroSeleccionado.EstaPrestado)
        {
            libroSeleccionado.Devolver();
            ActualizarListaLibros();
            ActualizarEstadisticas();
            MessageBox.Show($"Libro '{libroSeleccionado.Titulo}' devuelto correctamente", "Devolución Exitosa", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Este libro no está prestado", "Error", 
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    
    private void LstLibros_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstLibros.SelectedItem != null)
        {
            Libro libroSeleccionado = (Libro)lstLibros.SelectedItem;
            lblEstado.Text = libroSeleccionado.EstaPrestado 
                ? $"Estado: PRESTADO desde {libroSeleccionado.FechaPrestamo:dd/MM/yyyy}"
                : "Estado: DISPONIBLE";
            
            btnPrestar.Enabled = !libroSeleccionado.EstaPrestado;
            btnDevolver.Enabled = libroSeleccionado.EstaPrestado;
        }
    }
    
    private void ActualizarListaLibros()
    {
        lstLibros.Items.Clear();
        foreach (var libro in _libros.OrderBy(l => l.Titulo))
        {
            lstLibros.Items.Add(libro);
        }
    }
    
    private void ActualizarEstadisticas()
    {
        int total = _libros.Count;
        int disponibles = _libros.Count(l => !l.EstaPrestado);
        int prestados = _libros.Count(l => l.EstaPrestado);
        
        lblTotal.Text = $"📚 Total de libros: {total}";
        lblDisponibles.Text = $"✅ Disponibles: {disponibles}";
        lblPrestados.Text = $"📤 Prestados: {prestados}";
        
        // Cambiar color según disponibilidad
        if (disponibles == 0 && total > 0)
        {
            lblDisponibles.ForeColor = Color.Red;
        }
        else
        {
            lblDisponibles.ForeColor = Color.Green;
        }
    }
    
    private void LimpiarFormulario()
    {
        txtISBN.Clear();
        txtTitulo.Clear();
        txtAutor.Clear();
        txtISBN.Focus();
    }
}

// Programa principal
public partial class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new FormBiblioteca());
    }
}
```

## ✅ Beneficios del Aprendizaje Visual de POO

### 1. **Conceptos Tangibles**
- Los **campos** se ven como datos en controles
- Las **propiedades** se visualizan como valores que cambian en la interfaz
- Los **métodos** producen cambios visibles inmediatos

### 2. **Retroalimentación Inmediata**
- Validaciones que cambian colores de controles
- Mensajes visuales de éxito o error
- Estados que se reflejan en la interfaz

### 3. **Interactividad**
- Los estudiantes pueden "tocar" y manipular los objetos
- Ver causa y efecto de manera inmediata
- Experimentar con diferentes valores y ver resultados

### 4. **Motivación Aumentada**
- Crear aplicaciones "reales" desde el primer día
- Ver resultados profesionales rápidamente
- Conectar teoría con aplicaciones prácticas

## 🔚 Resumen

- Las **clases** son moldes que definen características y comportamientos visibles
- Los **campos** almacenan datos internos, las **propiedades** los exponen controladamente
- Los **constructores** inicializan tanto datos como interfaz visual
- Los **métodos** realizan acciones que se reflejan visualmente
- La **validación** se puede implementar con retroalimentación visual inmediata
- Windows Forms hace que conceptos abstractos se vuelvan tangibles y manipulables

## ➡️ Siguiente: [Teoría 02: Trabajando con Objetos en Windows Forms](Teoria-02-Objetos-WinForms.md)