# 📖 Teoría 02: Trabajando con Objetos en Windows Forms

## 🎯 Objetivos de Aprendizaje
Al finalizar esta lección, podrás:
- Crear múltiples objetos e instancias de formularios
- Gestionar referencias entre formularios y objetos
- Diferenciar entre métodos estáticos y de instancia en contexto visual
- Manejar el ciclo de vida de objetos y formularios
- Crear aplicaciones con múltiples ventanas que intercambian datos

## 🏭 ¿Qué es un Objeto Visual?

### Analogía con Formularios
Si una **clase** es el diseño de un formulario en el diseñador, entonces un **objeto** es cada ventana que aparece en pantalla cuando ejecutas la aplicación. Puedes abrir múltiples ventanas (objetos) usando el mismo diseño (clase), pero cada una será independiente.

### Ejemplo Visual: Múltiples Ventanas de la Misma Clase
```csharp
// Clase base para ventana de calculadora
public partial class FormCalculadora : Form
{
    private double _resultado;
    private string _operacion;
    private double _numeroAnterior;
    
    public string Titulo { get; set; }
    public int NumeroInstancia { get; private set; }
    private static int _contadorInstancias = 0;
    
    public FormCalculadora()
    {
        InitializeComponent();
        _contadorInstancias++;
        NumeroInstancia = _contadorInstancias;
        Titulo = $"Calculadora #{NumeroInstancia}";
        this.Text = Titulo;
        InicializarCalculadora();
    }
    
    public FormCalculadora(string titulo) : this()
    {
        Titulo = titulo;
        this.Text = titulo;
    }
    
    private void InicializarCalculadora()
    {
        _resultado = 0;
        _operacion = "";
        _numeroAnterior = 0;
        txtDisplay.Text = "0";
        
        // Cambiar color de fondo según la instancia
        this.BackColor = ObtenerColorInstancia();
    }
    
    private Color ObtenerColorInstancia()
    {
        Color[] colores = { Color.LightBlue, Color.LightGreen, Color.LightPink, 
                           Color.LightYellow, Color.LightCyan };
        return colores[(NumeroInstancia - 1) % colores.Length];
    }
    
    public static int ObtenerNumeroInstancias()
    {
        return _contadorInstancias;
    }
}
```

## 🔧 Instanciación Visual de Objetos

### Crear Múltiples Formularios Dinámicamente
```csharp
public partial class FormPrincipal : Form
{
    private List<FormCalculadora> _calculadoras;
    private int _posicionX = 100;
    private int _posicionY = 100;
    
    public FormPrincipal()
    {
        InitializeComponent();
        _calculadoras = new List<FormCalculadora>();
        ConfigurarInterfaz();
    }
    
    private void ConfigurarInterfaz()
    {
        this.Text = "Gestor de Calculadoras - Demostración de Objetos";
        this.Size = new Size(400, 300);
        this.StartPosition = FormStartPosition.CenterScreen;
        
        Button btnNuevaCalculadora = new Button();
        btnNuevaCalculadora.Text = "Nueva Calculadora";
        btnNuevaCalculadora.Location = new Point(50, 50);
        btnNuevaCalculadora.Size = new Size(150, 30);
        btnNuevaCalculadora.Click += BtnNuevaCalculadora_Click;
        
        Button btnCalculadoraPersonalizada = new Button();
        btnCalculadoraPersonalizada.Text = "Calculadora Personal";
        btnCalculadoraPersonalizada.Location = new Point(50, 100);
        btnCalculadoraPersonalizada.Size = new Size(150, 30);
        btnCalculadoraPersonalizada.Click += BtnCalculadoraPersonalizada_Click;
        
        Button btnMostrarEstadisticas = new Button();
        btnMostrarEstadisticas.Text = "Ver Estadísticas";
        btnMostrarEstadisticas.Location = new Point(50, 150);
        btnMostrarEstadisticas.Size = new Size(150, 30);
        btnMostrarEstadisticas.Click += BtnMostrarEstadisticas_Click;
        
        Button btnCerrarTodas = new Button();
        btnCerrarTodas.Text = "Cerrar Todas";
        btnCerrarTodas.Location = new Point(50, 200);
        btnCerrarTodas.Size = new Size(150, 30);
        btnCerrarTodas.BackColor = Color.LightCoral;
        btnCerrarTodas.Click += BtnCerrarTodas_Click;
        
        this.Controls.AddRange(new Control[] { 
            btnNuevaCalculadora, btnCalculadoraPersonalizada, 
            btnMostrarEstadisticas, btnCerrarTodas 
        });
    }
    
    private void BtnNuevaCalculadora_Click(object sender, EventArgs e)
    {
        // Crear nueva instancia (objeto) de calculadora
        FormCalculadora nuevaCalculadora = new FormCalculadora();
        
        // Posicionar la ventana
        nuevaCalculadora.StartPosition = FormStartPosition.Manual;
        nuevaCalculadora.Location = new Point(_posicionX, _posicionY);
        
        // Actualizar posición para la siguiente ventana
        _posicionX += 30;
        _posicionY += 30;
        if (_posicionX > 600) _posicionX = 100;
        if (_posicionY > 400) _posicionY = 100;
        
        // Agregar a la lista de calculadoras activas
        _calculadoras.Add(nuevaCalculadora);
        
        // Configurar evento cuando se cierre
        nuevaCalculadora.FormClosed += (s, ev) => 
        {
            _calculadoras.Remove(nuevaCalculadora);
        };
        
        // Mostrar la ventana
        nuevaCalculadora.Show();
        
        // Mensaje visual
        this.Text = $"Gestor - {_calculadoras.Count} calculadoras activas";
    }
    
    private void BtnCalculadoraPersonalizada_Click(object sender, EventArgs e)
    {
        // Solicitar nombre personalizado
        string nombre = Microsoft.VisualBasic.Interaction.InputBox(
            "Ingresa un nombre para tu calculadora:", 
            "Calculadora Personalizada", 
            $"Mi Calculadora {DateTime.Now:HH:mm}");
        
        if (!string.IsNullOrEmpty(nombre))
        {
            // Crear objeto con constructor personalizado
            FormCalculadora calculadoraPersonal = new FormCalculadora(nombre);
            calculadoraPersonal.StartPosition = FormStartPosition.CenterScreen;
            
            _calculadoras.Add(calculadoraPersonal);
            calculadoraPersonal.FormClosed += (s, ev) => _calculadoras.Remove(calculadoraPersonal);
            calculadoraPersonal.Show();
            
            this.Text = $"Gestor - {_calculadoras.Count} calculadoras activas";
        }
    }
    
    private void BtnMostrarEstadisticas_Click(object sender, EventArgs e)
    {
        string estadisticas = $"📊 Estadísticas de Objetos:\n\n";
        estadisticas += $"🔢 Total de instancias creadas: {FormCalculadora.ObtenerNumeroInstancias()}\n";
        estadisticas += $"🖥️ Calculadoras activas: {_calculadoras.Count}\n";
        estadisticas += $"❌ Calculadoras cerradas: {FormCalculadora.ObtenerNumeroInstancias() - _calculadoras.Count}\n\n";
        
        if (_calculadoras.Count > 0)
        {
            estadisticas += "📋 Lista de calculadoras activas:\n";
            foreach (var calc in _calculadoras)
            {
                estadisticas += $"• {calc.Titulo}\n";
            }
        }
        
        MessageBox.Show(estadisticas, "Estadísticas de Objetos", 
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    
    private void BtnCerrarTodas_Click(object sender, EventArgs e)
    {
        if (_calculadoras.Count == 0)
        {
            MessageBox.Show("No hay calculadoras abiertas", "Información", 
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        
        DialogResult resultado = MessageBox.Show(
            $"¿Estás seguro de cerrar todas las {_calculadoras.Count} calculadoras?", 
            "Confirmar Cierre", 
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question);
        
        if (resultado == DialogResult.Yes)
        {
            // Crear copia de la lista para evitar modificación durante iteración
            var calculadorasACerrar = new List<FormCalculadora>(_calculadoras);
            
            foreach (var calculadora in calculadorasACerrar)
            {
                calculadora.Close();
            }
            
            this.Text = "Gestor de Calculadoras - Demostración de Objetos";
        }
    }
}
```

## 🔗 Referencias y Comunicación entre Objetos

### Formularios que se Comunican Entre Sí
```csharp
// Clase para datos compartidos
public class ContactoData
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public DateTime FechaCreacion { get; set; }
    
    public ContactoData()
    {
        FechaCreacion = DateTime.Now;
    }
    
    public override string ToString()
    {
        return $"{Nombre} - {Telefono}";
    }
}

// Formulario principal de contactos
public partial class FormContactos : Form
{
    private List<ContactoData> _contactos;
    private ListBox lstContactos;
    private FormDetalleContacto _formDetalle; // Referencia a formulario de detalle
    
    public FormContactos()
    {
        InitializeComponent();
        _contactos = new List<ContactoData>();
        InicializarDatosPrueba();
    }
    
    private void InitializeComponent()
    {
        this.Text = "Lista de Contactos";
        this.Size = new Size(400, 500);
        this.StartPosition = FormStartPosition.CenterScreen;
        
        Label lblTitulo = new Label();
        lblTitulo.Text = "📞 Gestión de Contactos";
        lblTitulo.Font = new Font("Arial", 14, FontStyle.Bold);
        lblTitulo.Location = new Point(20, 20);
        lblTitulo.Size = new Size(300, 30);
        
        lstContactos = new ListBox();
        lstContactos.Location = new Point(20, 60);
        lstContactos.Size = new Size(340, 250);
        lstContactos.SelectionMode = SelectionMode.One;
        
        Button btnNuevo = new Button();
        btnNuevo.Text = "➕ Nuevo Contacto";
        btnNuevo.Location = new Point(20, 330);
        btnNuevo.Size = new Size(120, 35);
        btnNuevo.BackColor = Color.LightGreen;
        btnNuevo.Click += BtnNuevo_Click;
        
        Button btnEditar = new Button();
        btnEditar.Text = "✏️ Editar";
        btnEditar.Location = new Point(150, 330);
        btnEditar.Size = new Size(100, 35);
        btnEditar.BackColor = Color.LightBlue;
        btnEditar.Click += BtnEditar_Click;
        
        Button btnEliminar = new Button();
        btnEliminar.Text = "🗑️ Eliminar";
        btnEliminar.Location = new Point(260, 330);
        btnEliminar.Size = new Size(100, 35);
        btnEliminar.BackColor = Color.LightCoral;
        btnEliminar.Click += BtnEliminar_Click;
        
        Button btnMostrarEstadisticas = new Button();
        btnMostrarEstadisticas.Text = "📊 Estadísticas";
        btnMostrarEstadisticas.Location = new Point(20, 380);
        btnMostrarEstadisticas.Size = new Size(340, 30);
        btnMostrarEstadisticas.BackColor = Color.LightYellow;
        btnMostrarEstadisticas.Click += BtnMostrarEstadisticas_Click;
        
        this.Controls.AddRange(new Control[] { 
            lblTitulo, lstContactos, btnNuevo, btnEditar, btnEliminar, btnMostrarEstadisticas 
        });
        
        // Doble clic para editar
        lstContactos.DoubleClick += BtnEditar_Click;
    }
    
    private void InicializarDatosPrueba()
    {
        _contactos.Add(new ContactoData { Nombre = "Ana García", Telefono = "555-0101", Email = "ana@email.com" });
        _contactos.Add(new ContactoData { Nombre = "Luis Martínez", Telefono = "555-0102", Email = "luis@email.com" });
        _contactos.Add(new ContactoData { Nombre = "María López", Telefono = "555-0103", Email = "maria@email.com" });
        ActualizarLista();
    }
    
    private void BtnNuevo_Click(object sender, EventArgs e)
    {
        // Crear nuevo objeto de contacto
        ContactoData nuevoContacto = new ContactoData();
        
        // Abrir formulario de detalle para edición
        AbrirFormularioDetalle(nuevoContacto, true);
    }
    
    private void BtnEditar_Click(object sender, EventArgs e)
    {
        if (lstContactos.SelectedItem == null)
        {
            MessageBox.Show("Selecciona un contacto para editar", "Advertencia", 
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        ContactoData contactoSeleccionado = (ContactoData)lstContactos.SelectedItem;
        AbrirFormularioDetalle(contactoSeleccionado, false);
    }
    
    private void AbrirFormularioDetalle(ContactoData contacto, bool esNuevo)
    {
        // Verificar si ya hay un formulario de detalle abierto
        if (_formDetalle != null && !_formDetalle.IsDisposed)
        {
            _formDetalle.Focus();
            MessageBox.Show("Ya hay un formulario de detalle abierto", "Información", 
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        
        // Crear nueva instancia del formulario de detalle
        _formDetalle = new FormDetalleContacto(contacto, esNuevo);
        
        // Configurar evento para cuando se guarde el contacto
        _formDetalle.ContactoGuardado += (contactoGuardado) =>
        {
            if (esNuevo)
            {
                _contactos.Add(contactoGuardado);
            }
            ActualizarLista();
        };
        
        // Mostrar formulario como modal
        _formDetalle.ShowDialog();
    }
    
    private void BtnEliminar_Click(object sender, EventArgs e)
    {
        if (lstContactos.SelectedItem == null)
        {
            MessageBox.Show("Selecciona un contacto para eliminar", "Advertencia", 
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        ContactoData contactoSeleccionado = (ContactoData)lstContactos.SelectedItem;
        
        DialogResult resultado = MessageBox.Show(
            $"¿Estás seguro de eliminar a {contactoSeleccionado.Nombre}?", 
            "Confirmar Eliminación", 
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question);
        
        if (resultado == DialogResult.Yes)
        {
            _contactos.Remove(contactoSeleccionado);
            ActualizarLista();
            MessageBox.Show("Contacto eliminado correctamente", "Éxito", 
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
    private void BtnMostrarEstadisticas_Click(object sender, EventArgs e)
    {
        MostrarEstadisticasVisuales();
    }
    
    private void MostrarEstadisticasVisuales()
    {
        FormEstadisticas formStats = new FormEstadisticas(_contactos);
        formStats.ShowDialog();
    }
    
    private void ActualizarLista()
    {
        lstContactos.Items.Clear();
        foreach (var contacto in _contactos.OrderBy(c => c.Nombre))
        {
            lstContactos.Items.Add(contacto);
        }
        
        // Actualizar título con contador
        this.Text = $"Lista de Contactos ({_contactos.Count})";
    }
}

// Formulario de detalle que recibe referencia a objeto
public partial class FormDetalleContacto : Form
{
    private ContactoData _contacto;
    private bool _esNuevo;
    private TextBox txtNombre, txtTelefono, txtEmail;
    private Label lblFecha;
    
    // Evento para comunicar cambios al formulario padre
    public event Action<ContactoData> ContactoGuardado;
    
    public FormDetalleContacto(ContactoData contacto, bool esNuevo)
    {
        _contacto = contacto;
        _esNuevo = esNuevo;
        InitializeComponent();
        CargarDatos();
    }
    
    private void InitializeComponent()
    {
        this.Text = _esNuevo ? "Nuevo Contacto" : "Editar Contacto";
        this.Size = new Size(400, 300);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        
        Label lblTitulo = new Label();
        lblTitulo.Text = _esNuevo ? "➕ Nuevo Contacto" : "✏️ Editar Contacto";
        lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
        lblTitulo.Location = new Point(20, 20);
        lblTitulo.Size = new Size(300, 25);
        
        Label lblNom = new Label() { Text = "Nombre:", Location = new Point(20, 60), Size = new Size(80, 20) };
        txtNombre = new TextBox() { Location = new Point(110, 60), Size = new Size(200, 20) };
        
        Label lblTel = new Label() { Text = "Teléfono:", Location = new Point(20, 100), Size = new Size(80, 20) };
        txtTelefono = new TextBox() { Location = new Point(110, 100), Size = new Size(200, 20) };
        
        Label lblEm = new Label() { Text = "Email:", Location = new Point(20, 140), Size = new Size(80, 20) };
        txtEmail = new TextBox() { Location = new Point(110, 140), Size = new Size(200, 20) };
        
        lblFecha = new Label();
        lblFecha.Location = new Point(20, 180);
        lblFecha.Size = new Size(300, 20);
        lblFecha.ForeColor = Color.Gray;
        
        Button btnGuardar = new Button();
        btnGuardar.Text = "💾 Guardar";
        btnGuardar.Location = new Point(120, 220);
        btnGuardar.Size = new Size(80, 30);
        btnGuardar.BackColor = Color.LightGreen;
        btnGuardar.Click += BtnGuardar_Click;
        
        Button btnCancelar = new Button();
        btnCancelar.Text = "❌ Cancelar";
        btnCancelar.Location = new Point(210, 220);
        btnCancelar.Size = new Size(80, 30);
        btnCancelar.BackColor = Color.LightCoral;
        btnCancelar.Click += (s, e) => this.Close();
        
        this.Controls.AddRange(new Control[] { 
            lblTitulo, lblNom, txtNombre, lblTel, txtTelefono, 
            lblEm, txtEmail, lblFecha, btnGuardar, btnCancelar 
        });
        
        // Configurar validación en tiempo real
        txtNombre.TextChanged += ValidarFormulario;
        txtTelefono.TextChanged += ValidarFormulario;
        txtEmail.TextChanged += ValidarFormulario;
    }
    
    private void CargarDatos()
    {
        txtNombre.Text = _contacto.Nombre ?? "";
        txtTelefono.Text = _contacto.Telefono ?? "";
        txtEmail.Text = _contacto.Email ?? "";
        
        if (_esNuevo)
        {
            lblFecha.Text = "Fecha: Se asignará al guardar";
        }
        else
        {
            lblFecha.Text = $"Creado: {_contacto.FechaCreacion:dd/MM/yyyy HH:mm}";
        }
    }
    
    private void ValidarFormulario(object sender, EventArgs e)
    {
        // Cambiar color de fondo según validación
        TextBox txt = sender as TextBox;
        if (string.IsNullOrWhiteSpace(txt.Text))
        {
            txt.BackColor = Color.LightPink;
        }
        else
        {
            txt.BackColor = Color.LightGreen;
        }
    }
    
    private void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (ValidarDatos())
        {
            // Modificar el objeto original (referencia)
            _contacto.Nombre = txtNombre.Text.Trim();
            _contacto.Telefono = txtTelefono.Text.Trim();
            _contacto.Email = txtEmail.Text.Trim();
            
            if (_esNuevo)
            {
                _contacto.FechaCreacion = DateTime.Now;
            }
            
            // Notificar al formulario padre
            ContactoGuardado?.Invoke(_contacto);
            
            MessageBox.Show("Contacto guardado correctamente", "Éxito", 
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            this.Close();
        }
    }
    
    private bool ValidarDatos()
    {
        List<string> errores = new List<string>();
        
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
            errores.Add("• El nombre es requerido");
            
        if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            errores.Add("• El teléfono es requerido");
            
        if (!string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(txtEmail.Text);
            }
            catch
            {
                errores.Add("• El formato del email es inválido");
            }
        }
        
        if (errores.Count > 0)
        {
            string mensaje = "Errores de validación:\n\n" + string.Join("\n", errores);
            MessageBox.Show(mensaje, "Errores de Validación", 
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        return true;
    }
}

// Formulario de estadísticas que recibe colección de objetos
public partial class FormEstadisticas : Form
{
    private List<ContactoData> _contactos;
    
    public FormEstadisticas(List<ContactoData> contactos)
    {
        _contactos = contactos;
        InitializeComponent();
        MostrarEstadisticas();
    }
    
    private void InitializeComponent()
    {
        this.Text = "📊 Estadísticas de Contactos";
        this.Size = new Size(500, 400);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        
        Button btnCerrar = new Button();
        btnCerrar.Text = "Cerrar";
        btnCerrar.Location = new Point(200, 320);
        btnCerrar.Size = new Size(100, 30);
        btnCerrar.Click += (s, e) => this.Close();
        
        this.Controls.Add(btnCerrar);
    }
    
    private void MostrarEstadisticas()
    {
        int yPos = 20;
        
        // Título
        Label lblTitulo = new Label();
        lblTitulo.Text = "📊 Análisis de Contactos";
        lblTitulo.Font = new Font("Arial", 14, FontStyle.Bold);
        lblTitulo.Location = new Point(20, yPos);
        lblTitulo.Size = new Size(400, 30);
        this.Controls.Add(lblTitulo);
        yPos += 40;
        
        // Estadísticas básicas
        Label lblTotal = new Label();
        lblTotal.Text = $"📱 Total de contactos: {_contactos.Count}";
        lblTotal.Location = new Point(20, yPos);
        lblTotal.Size = new Size(300, 20);
        this.Controls.Add(lblTotal);
        yPos += 30;
        
        // Contactos con email
        int conEmail = _contactos.Count(c => !string.IsNullOrWhiteSpace(c.Email));
        Label lblEmail = new Label();
        lblEmail.Text = $"📧 Con email: {conEmail} ({(conEmail * 100.0 / Math.Max(_contactos.Count, 1)):F1}%)";
        lblEmail.Location = new Point(20, yPos);
        lblEmail.Size = new Size(300, 20);
        this.Controls.Add(lblEmail);
        yPos += 30;
        
        // Contacto más reciente
        if (_contactos.Count > 0)
        {
            var masReciente = _contactos.OrderByDescending(c => c.FechaCreacion).First();
            Label lblReciente = new Label();
            lblReciente.Text = $"🆕 Más reciente: {masReciente.Nombre} ({masReciente.FechaCreacion:dd/MM/yyyy})";
            lblReciente.Location = new Point(20, yPos);
            lblReciente.Size = new Size(400, 20);
            this.Controls.Add(lblReciente);
            yPos += 30;
        }
        
        // Lista de contactos
        Label lblLista = new Label();
        lblLista.Text = "📋 Lista completa:";
        lblLista.Font = new Font("Arial", 10, FontStyle.Bold);
        lblLista.Location = new Point(20, yPos);
        lblLista.Size = new Size(200, 20);
        this.Controls.Add(lblLista);
        yPos += 25;
        
        ListBox lstDetalle = new ListBox();
        lstDetalle.Location = new Point(20, yPos);
        lstDetalle.Size = new Size(450, 150);
        
        foreach (var contacto in _contactos.OrderBy(c => c.Nombre))
        {
            string item = $"{contacto.Nombre} - {contacto.Telefono}";
            if (!string.IsNullOrWhiteSpace(contacto.Email))
                item += $" - {contacto.Email}";
            lstDetalle.Items.Add(item);
        }
        
        this.Controls.Add(lstDetalle);
    }
}
```

## 🔄 Métodos Estáticos vs de Instancia en Contexto Visual

### Utilitarios Estáticos para Formularios
```csharp
public static class UtilFormularios
{
    // Método estático - no necesita instancia de formulario
    public static void CentrarFormulario(Form formulario, Form padre = null)
    {
        if (padre != null)
        {
            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point(
                padre.Location.X + (padre.Width - formulario.Width) / 2,
                padre.Location.Y + (padre.Height - formulario.Height) / 2
            );
        }
        else
        {
            formulario.StartPosition = FormStartPosition.CenterScreen;
        }
    }
    
    public static void AplicarTemaOscuro(Form formulario)
    {
        formulario.BackColor = Color.FromArgb(45, 45, 48);
        formulario.ForeColor = Color.White;
        
        foreach (Control control in formulario.Controls)
        {
            AplicarTemaOscuroControl(control);
        }
    }
    
    private static void AplicarTemaOscuroControl(Control control)
    {
        if (control is Button btn)
        {
            btn.BackColor = Color.FromArgb(62, 62, 66);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
        }
        else if (control is TextBox txt)
        {
            txt.BackColor = Color.FromArgb(51, 51, 55);
            txt.ForeColor = Color.White;
        }
        else if (control is Label lbl)
        {
            lbl.ForeColor = Color.White;
        }
        
        // Aplicar recursivamente a controles hijos
        foreach (Control hijo in control.Controls)
        {
            AplicarTemaOscuroControl(hijo);
        }
    }
    
    public static DialogResult MostrarMensajePersonalizado(string mensaje, string titulo, 
                                                          MessageBoxIcon icono = MessageBoxIcon.Information)
    {
        return MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
    }
    
    // Método estático para validación común
    public static bool ValidarCamposRequeridos(params TextBox[] campos)
    {
        bool todosValidos = true;
        
        foreach (var campo in campos)
        {
            if (string.IsNullOrWhiteSpace(campo.Text))
            {
                campo.BackColor = Color.LightPink;
                todosValidos = false;
            }
            else
            {
                campo.BackColor = Color.LightGreen;
            }
        }
        
        return todosValidos;
    }
}

// Formulario que usa métodos estáticos
public partial class FormEjemploMetodos : Form
{
    private TextBox txtNombre, txtEmail;
    private Button btnValidar, btnTemaOscuro, btnCentrar;
    
    public FormEjemploMetodos()
    {
        InitializeComponent();
        ConfigurarEventos();
    }
    
    private void ConfigurarEventos()
    {
        // Usar método estático para validación
        btnValidar.Click += (s, e) => 
        {
            bool esValido = UtilFormularios.ValidarCamposRequeridos(txtNombre, txtEmail);
            
            if (esValido)
            {
                UtilFormularios.MostrarMensajePersonalizado(
                    "✅ Todos los campos son válidos", 
                    "Validación Exitosa", 
                    MessageBoxIcon.Information);
            }
            else
            {
                UtilFormularios.MostrarMensajePersonalizado(
                    "❌ Por favor completa todos los campos", 
                    "Campos Requeridos", 
                    MessageBoxIcon.Warning);
            }
        };
        
        // Usar método estático para tema
        btnTemaOscuro.Click += (s, e) => 
        {
            UtilFormularios.AplicarTemaOscuro(this);
        };
        
        // Usar método estático para centrar
        btnCentrar.Click += (s, e) => 
        {
            UtilFormularios.CentrarFormulario(this);
        };
    }
    
    // Método de instancia - específico de este formulario
    public void MostrarDatosFormulario()
    {
        string info = $"Formulario: {this.Text}\n";
        info += $"Tamaño: {this.Size}\n";
        info += $"Posición: {this.Location}\n";
        info += $"Campos: Nombre='{txtNombre.Text}', Email='{txtEmail.Text}'";
        
        MessageBox.Show(info, "Información del Formulario");
    }
}
```

## ♻️ Ciclo de Vida Visual de Objetos

### Demostración del Ciclo de Vida con Formularios
```csharp
public partial class FormCicloVida : Form
{
    private static int _contadorFormularios = 0;
    private int _idFormulario;
    private DateTime _fechaCreacion;
    private Timer _timerVida;
    private Label _lblTiempoVida;
    
    public FormCicloVida()
    {
        // Fase 1: Creación
        _contadorFormularios++;
        _idFormulario = _contadorFormularios;
        _fechaCreacion = DateTime.Now;
        
        InitializeComponent();
        IniciarCicloVida();
        
        Console.WriteLine($"✅ Formulario #{_idFormulario} creado a las {_fechaCreacion:HH:mm:ss}");
    }
    
    private void InitializeComponent()
    {
        this.Text = $"Ciclo de Vida #{_idFormulario}";
        this.Size = new Size(400, 300);
        this.StartPosition = FormStartPosition.CenterScreen;
        
        _lblTiempoVida = new Label();
        _lblTiempoVida.Location = new Point(50, 50);
        _lblTiempoVida.Size = new Size(300, 30);
        _lblTiempoVida.Font = new Font("Arial", 12, FontStyle.Bold);
        _lblTiempoVida.ForeColor = Color.Blue;
        
        Label lblInfo = new Label();
        lblInfo.Text = $"Formulario creado: {_fechaCreacion:dd/MM/yyyy HH:mm:ss}";
        lblInfo.Location = new Point(50, 100);
        lblInfo.Size = new Size(300, 20);
        
        Button btnSimularTrabajo = new Button();
        btnSimularTrabajo.Text = "🔧 Simular Trabajo";
        btnSimularTrabajo.Location = new Point(50, 150);
        btnSimularTrabajo.Size = new Size(120, 30);
        btnSimularTrabajo.Click += SimularTrabajo;
        
        Button btnCerrar = new Button();
        btnCerrar.Text = "❌ Cerrar";
        btnCerrar.Location = new Point(200, 150);
        btnCerrar.Size = new Size(100, 30);
        btnCerrar.BackColor = Color.LightCoral;
        btnCerrar.Click += (s, e) => this.Close();
        
        this.Controls.AddRange(new Control[] { _lblTiempoVida, lblInfo, btnSimularTrabajo, btnCerrar });
        
        // Configurar eventos del ciclo de vida
        this.Load += FormCicloVida_Load;
        this.Activated += FormCicloVida_Activated;
        this.Deactivate += FormCicloVida_Deactivate;
        this.FormClosing += FormCicloVida_FormClosing;
        this.FormClosed += FormCicloVida_FormClosed;
    }
    
    private void IniciarCicloVida()
    {
        // Fase 2: Uso activo - Timer para mostrar tiempo de vida
        _timerVida = new Timer();
        _timerVida.Interval = 1000; // 1 segundo
        _timerVida.Tick += ActualizarTiempoVida;
        _timerVida.Start();
    }
    
    private void ActualizarTiempoVida(object sender, EventArgs e)
    {
        TimeSpan tiempoVida = DateTime.Now - _fechaCreacion;
        _lblTiempoVida.Text = $"⏱️ Tiempo de vida: {tiempoVida:hh\\:mm\\:ss}";
        
        // Cambiar color según el tiempo de vida
        if (tiempoVida.TotalSeconds > 30)
            _lblTiempoVida.ForeColor = Color.Red;
        else if (tiempoVida.TotalSeconds > 15)
            _lblTiempoVida.ForeColor = Color.Orange;
    }
    
    private void SimularTrabajo(object sender, EventArgs e)
    {
        // Simular trabajo del objeto
        Button btn = sender as Button;
        btn.Text = "⚙️ Trabajando...";
        btn.Enabled = false;
        
        // Usar Task para no bloquear la UI
        Task.Run(() =>
        {
            System.Threading.Thread.Sleep(2000); // Simular trabajo de 2 segundos
            
            this.Invoke((Action)(() =>
            {
                btn.Text = "✅ Trabajo Completado";
                btn.BackColor = Color.LightGreen;
                Task.Delay(1000).ContinueWith(t =>
                {
                    this.Invoke((Action)(() =>
                    {
                        btn.Text = "🔧 Simular Trabajo";
                        btn.BackColor = SystemColors.Control;
                        btn.Enabled = true;
                    }));
                });
            }));
        });
        
        Console.WriteLine($"🔧 Formulario #{_idFormulario} realizando trabajo...");
    }
    
    // Eventos del ciclo de vida
    private void FormCicloVida_Load(object sender, EventArgs e)
    {
        Console.WriteLine($"📥 Formulario #{_idFormulario} cargado completamente");
    }
    
    private void FormCicloVida_Activated(object sender, EventArgs e)
    {
        this.BackColor = Color.LightGreen;
        Console.WriteLine($"🎯 Formulario #{_idFormulario} activado (enfocado)");
    }
    
    private void FormCicloVida_Deactivate(object sender, EventArgs e)
    {
        this.BackColor = SystemColors.Control;
        Console.WriteLine($"😴 Formulario #{_idFormulario} desactivado");
    }
    
    private void FormCicloVida_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult resultado = MessageBox.Show(
            $"¿Estás seguro de cerrar el formulario #{_idFormulario}?", 
            "Confirmar Cierre", 
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question);
        
        if (resultado == DialogResult.No)
        {
            e.Cancel = true; // Cancelar el cierre
            Console.WriteLine($"❌ Cierre del formulario #{_idFormulario} cancelado");
        }
        else
        {
            Console.WriteLine($"🚪 Formulario #{_idFormulario} cerrándose...");
        }
    }
    
    private void FormCicloVida_FormClosed(object sender, FormClosedEventArgs e)
    {
        // Fase 3: Limpieza
        _timerVida?.Stop();
        _timerVida?.Dispose();
        
        TimeSpan tiempoTotal = DateTime.Now - _fechaCreacion;
        Console.WriteLine($"💀 Formulario #{_idFormulario} cerrado después de {tiempoTotal:hh\\:mm\\:ss}");
    }
    
    // Finalizer - se ejecuta durante la recolección de basura
    ~FormCicloVida()
    {
        Console.WriteLine($"🗑️ Formulario #{_idFormulario} siendo recolectado por GC");
    }
    
    public static int ObtenerContadorFormularios()
    {
        return _contadorFormularios;
    }
}

// Formulario principal para demostrar múltiples ciclos de vida
public partial class FormDemostradorCicloVida : Form
{
    private List<FormCicloVida> _formulariosActivos;
    
    public FormDemostradorCicloVida()
    {
        InitializeComponent();
        _formulariosActivos = new List<FormCicloVida>();
    }
    
    private void InitializeComponent()
    {
        this.Text = "Demostrador de Ciclo de Vida de Objetos";
        this.Size = new Size(500, 400);
        this.StartPosition = FormStartPosition.CenterScreen;
        
        Label lblTitulo = new Label();
        lblTitulo.Text = "🔄 Ciclo de Vida de Objetos Visuales";
        lblTitulo.Font = new Font("Arial", 14, FontStyle.Bold);
        lblTitulo.Location = new Point(50, 30);
        lblTitulo.Size = new Size(400, 30);
        
        Button btnNuevoFormulario = new Button();
        btnNuevoFormulario.Text = "➕ Crear Nuevo Formulario";
        btnNuevoFormulario.Location = new Point(50, 80);
        btnNuevoFormulario.Size = new Size(180, 35);
        btnNuevoFormulario.BackColor = Color.LightBlue;
        btnNuevoFormulario.Click += BtnNuevoFormulario_Click;
        
        Button btnMostrarEstadisticas = new Button();
        btnMostrarEstadisticas.Text = "📊 Ver Estadísticas";
        btnMostrarEstadisticas.Location = new Point(250, 80);
        btnMostrarEstadisticas.Size = new Size(150, 35);
        btnMostrarEstadisticas.BackColor = Color.LightGreen;
        btnMostrarEstadisticas.Click += BtnMostrarEstadisticas_Click;
        
        Button btnForzarGC = new Button();
        btnForzarGC.Text = "🗑️ Forzar Recolección de Basura";
        btnForzarGC.Location = new Point(50, 130);
        btnForzarGC.Size = new Size(200, 35);
        btnForzarGC.BackColor = Color.LightYellow;
        btnForzarGC.Click += BtnForzarGC_Click;
        
        Button btnCerrarTodos = new Button();
        btnCerrarTodos.Text = "❌ Cerrar Todos";
        btnCerrarTodos.Location = new Point(270, 130);
        btnCerrarTodos.Size = new Size(130, 35);
        btnCerrarTodos.BackColor = Color.LightCoral;
        btnCerrarTodos.Click += BtnCerrarTodos_Click;
        
        TextBox txtConsola = new TextBox();
        txtConsola.Multiline = true;
        txtConsola.ScrollBars = ScrollBars.Vertical;
        txtConsola.ReadOnly = true;
        txtConsola.Location = new Point(50, 180);
        txtConsola.Size = new Size(400, 150);
        txtConsola.BackColor = Color.Black;
        txtConsola.ForeColor = Color.Green;
        txtConsola.Font = new Font("Consolas", 9);
        
        // Redirigir Console.WriteLine a TextBox
        Console.SetOut(new TextBoxWriter(txtConsola));
        
        this.Controls.AddRange(new Control[] { 
            lblTitulo, btnNuevoFormulario, btnMostrarEstadisticas, 
            btnForzarGC, btnCerrarTodos, txtConsola 
        });
    }
    
    private void BtnNuevoFormulario_Click(object sender, EventArgs e)
    {
        FormCicloVida nuevoForm = new FormCicloVida();
        _formulariosActivos.Add(nuevoForm);
        
        nuevoForm.FormClosed += (s, ev) => _formulariosActivos.Remove(nuevoForm);
        nuevoForm.Show();
    }
    
    private void BtnMostrarEstadisticas_Click(object sender, EventArgs e)
    {
        string stats = $"📊 Estadísticas de Objetos:\n\n";
        stats += $"• Total formularios creados: {FormCicloVida.ObtenerContadorFormularios()}\n";
        stats += $"• Formularios activos: {_formulariosActivos.Count}\n";
        stats += $"• Formularios destruidos: {FormCicloVida.ObtenerContadorFormularios() - _formulariosActivos.Count}\n";
        stats += $"• Memoria usada: {GC.GetTotalMemory(false) / 1024:N0} KB\n";
        
        MessageBox.Show(stats, "Estadísticas de Ciclo de Vida", 
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    
    private void BtnForzarGC_Click(object sender, EventArgs e)
    {
        long memoriaAntes = GC.GetTotalMemory(false);
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        long memoriaDespues = GC.GetTotalMemory(true);
        
        Console.WriteLine($"🗑️ Recolección de basura ejecutada");
        Console.WriteLine($"   Memoria antes: {memoriaAntes / 1024:N0} KB");
        Console.WriteLine($"   Memoria después: {memoriaDespues / 1024:N0} KB");
        Console.WriteLine($"   Memoria liberada: {(memoriaAntes - memoriaDespues) / 1024:N0} KB");
    }
    
    private void BtnCerrarTodos_Click(object sender, EventArgs e)
    {
        var formulariosACerrar = new List<FormCicloVida>(_formulariosActivos);
        foreach (var form in formulariosACerrar)
        {
            form.Close();
        }
    }
}

// Clase auxiliar para redirigir Console.WriteLine a TextBox
public class TextBoxWriter : System.IO.TextWriter
{
    private TextBox _textBox;
    
    public TextBoxWriter(TextBox textBox)
    {
        _textBox = textBox;
    }
    
    public override void WriteLine(string value)
    {
        if (_textBox.InvokeRequired)
        {
            _textBox.Invoke((Action)(() => {
                _textBox.AppendText($"{DateTime.Now:HH:mm:ss} - {value}\r\n");
                _textBox.SelectionStart = _textBox.Text.Length;
                _textBox.ScrollToCaret();
            }));
        }
        else
        {
            _textBox.AppendText($"{DateTime.Now:HH:mm:ss} - {value}\r\n");
            _textBox.SelectionStart = _textBox.Text.Length;
            _textBox.ScrollToCaret();
        }
    }
    
    public override System.Text.Encoding Encoding => System.Text.Encoding.UTF8;
}
```

## ✅ Resumen de Conceptos Visualizados

### 🎯 **Objetos Múltiples**
- Cada formulario abierto es un **objeto independiente** de la misma clase
- Los objetos pueden tener **estados diferentes** (diferentes valores en sus campos)
- Las **referencias** permiten que los formularios se comuniquen entre sí

### 🔗 **Referencias Visuales**
- Los formularios pueden **pasar objetos** entre sí
- Las modificaciones a un objeto se **reflejan en todos los formularios** que lo referencian
- Los **eventos** permiten comunicación entre objetos

### ⚡ **Métodos Estáticos vs Instancia**
- Métodos **estáticos**: utilidades que no dependen de objetos específicos
- Métodos **de instancia**: acciones específicas de cada formulario/objeto
- Los métodos estáticos son ideales para **validaciones** y **utilidades** comunes

### ♻️ **Ciclo de Vida Visual**
- **Creación**: `new`, constructor, `InitializeComponent()`
- **Uso**: eventos, interacción del usuario, actualización de datos
- **Destrucción**: `Close()`, `Dispose()`, recolección de basura
- Los **eventos** del formulario muestran cada fase del ciclo

### 🎨 **Beneficios del Aprendizaje Visual**
- **Ver** cómo los objetos nacen, viven y mueren
- **Interactuar** con múltiples instancias simultáneamente
- **Experimentar** con referencias y comunicación entre objetos
- **Observar** el impacto inmediato de los cambios

## 🔚 Resumen

- Un **objeto** es una instancia concreta de una clase, como cada formulario abierto
- Múltiples objetos pueden existir simultáneamente con **estados independientes**
- Las **referencias** permiten que los objetos se comuniquen y compartan datos
- Los **métodos estáticos** son utilidades globales, los **de instancia** son específicos de cada objeto
- El **ciclo de vida** incluye creación, uso activo y destrucción
- Windows Forms hace visible y tangible el comportamiento de los objetos

## ➡️ Siguiente: [Teoría 03: Encapsulación Visual](Teoria-03-Encapsulacion-WinForms.md)