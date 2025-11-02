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

## 🎨 Ejemplo Completo: Sistema de Empleados

### Paso 1: Clase Base

```csharp
// Clase Padre - Empleado Base
public class Empleado
{
    // Propiedades comunes a TODOS los empleados
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Cedula { get; set; }
    public decimal SalarioBase { get; set; }
    
    // Constructor
    public Empleado()
    {
        Nombre = "";
        Apellido = "";
        Cedula = "";
        SalarioBase = 0;
    }
    
    public Empleado(string nombre, string apellido, string cedula, decimal salarioBase)
    {
        Nombre = nombre;
        Apellido = apellido;
        Cedula = cedula;
        SalarioBase = salarioBase;
    }
    
    // Método común
    public string ObtenerNombreCompleto()
    {
        return $"{Nombre} {Apellido}";
    }
    
    // Método virtual (puede ser sobreescrito)
    public virtual decimal CalcularSalario()
    {
        return SalarioBase;
    }
    
    public virtual string ObtenerInfo()
    {
        return $"Empleado: {ObtenerNombreCompleto()}\n" +
               $"Cédula: {Cedula}\n" +
               $"Salario Base: ${SalarioBase:N2}";
    }
}
```

### Paso 2: Clases Derivadas

```csharp
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// Clase Hija 1: Empleado por Hora
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
public class EmpleadoPorHora : Empleado
{
    // Propiedades adicionales
    public int HorasTrabajadas { get; set; }
    public decimal TarifaPorHora { get; set; }
    
    // Constructor sin parámetros
    public EmpleadoPorHora() : base()
    {
        HorasTrabajadas = 0;
        TarifaPorHora = 0;
    }
    
    // Constructor con parámetros
    public EmpleadoPorHora(string nombre, string apellido, string cedula, 
                           decimal salarioBase, decimal tarifaPorHora)
        : base(nombre, apellido, cedula, salarioBase)
    {
        TarifaPorHora = tarifaPorHora;
        HorasTrabajadas = 0;
    }
    
    // Sobreescribir método
    public override decimal CalcularSalario()
    {
        return SalarioBase + (HorasTrabajadas * TarifaPorHora);
    }
    
    public override string ObtenerInfo()
    {
        return base.ObtenerInfo() + 
               $"\nTipo: Empleado por Hora" +
               $"\nHoras trabajadas: {HorasTrabajadas}" +
               $"\nTarifa por hora: ${TarifaPorHora:N2}" +
               $"\nSalario Total: ${CalcularSalario():N2}";
    }
}

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// Clase Hija 2: Empleado con Comisión
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
public class EmpleadoComision : Empleado
{
    // Propiedades adicionales
    public decimal TotalVentas { get; set; }
    public decimal PorcentajeComision { get; set; }
    
    // Constructor
    public EmpleadoComision() : base()
    {
        TotalVentas = 0;
        PorcentajeComision = 0;
    }
    
    public EmpleadoComision(string nombre, string apellido, string cedula,
                           decimal salarioBase, decimal porcentajeComision)
        : base(nombre, apellido, cedula, salarioBase)
    {
        PorcentajeComision = porcentajeComision;
        TotalVentas = 0;
    }
    
    // Método propio
    public void RegistrarVenta(decimal monto)
    {
        TotalVentas += monto;
    }
    
    // Sobreescribir método
    public override decimal CalcularSalario()
    {
        return SalarioBase + (TotalVentas * PorcentajeComision / 100);
    }
    
    public override string ObtenerInfo()
    {
        return base.ObtenerInfo() + 
               $"\nTipo: Empleado con Comisión" +
               $"\nVentas totales: ${TotalVentas:N2}" +
               $"\nPorcentaje comisión: {PorcentajeComision}%" +
               $"\nSalario Total: ${CalcularSalario():N2}";
    }
}

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// Clase Hija 3: Gerente
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
public class Gerente : Empleado
{
    // Propiedades adicionales
    public string Departamento { get; set; }
    public decimal BonoGerencial { get; set; }
    
    // Constructor
    public Gerente() : base()
    {
        Departamento = "";
        BonoGerencial = 0;
    }
    
    public Gerente(string nombre, string apellido, string cedula,
                  decimal salarioBase, string departamento, decimal bonoGerencial)
        : base(nombre, apellido, cedula, salarioBase)
    {
        Departamento = departamento;
        BonoGerencial = bonoGerencial;
    }
    
    // Sobreescribir método
    public override decimal CalcularSalario()
    {
        return SalarioBase + BonoGerencial;
    }
    
    public override string ObtenerInfo()
    {
        return base.ObtenerInfo() + 
               $"\nTipo: Gerente" +
               $"\nDepartamento: {Departamento}" +
               $"\nBono gerencial: ${BonoGerencial:N2}" +
               $"\nSalario Total: ${CalcularSalario():N2}";
    }
}
```

### Visual de la Jerarquía

```
                    👔 EMPLEADO
                    ═══════════
                    - Nombre
                    - Apellido
                    - Cedula
                    - SalarioBase
                    - ObtenerNombreCompleto()
                    - CalcularSalario()
                    - ObtenerInfo()
                         │
        ┌────────────────┼────────────────┐
        │                │                │
        ↓                ↓                ↓
    ⏰ POR HORA      💰 COMISIÓN      👨‍💼 GERENTE
    ═══════════      ═══════════      ═══════════
    + Hereda todo    + Hereda todo    + Hereda todo
    + HorasTrabaj.   + TotalVentas    + Departamento
    + TarifaPorHora  + %Comision      + BonoGerencial
    + Override       + RegistrarVenta + Override
      CalcularSal.     + Override       CalcularSal.
                         CalcularSal.
```

## 💻 Aplicación Windows Forms

### Diseño del Formulario

```
┌──────────────────────────────────────────────────────┐
│  👔 Sistema de Gestión de Empleados                  │
├──────────────────────────────────────────────────────┤
│                                                      │
│  Datos Básicos:                                      │
│  ┌────────────────────────────────────────────────┐ │
│  │ Nombre:    [txtNombre        ]                 │ │
│  │ Apellido:  [txtApellido      ]                 │ │
│  │ Cédula:    [txtCedula        ]                 │ │
│  │ Salario Base: [txtSalarioBase]                 │ │
│  └────────────────────────────────────────────────┘ │
│                                                      │
│  Tipo de Empleado:                                   │
│  ( ) Por Hora    ( ) Comisión    ( ) Gerente        │
│                                                      │
│  ┌─ Datos Específicos ────────────────────────────┐ │
│  │                                                 │ │
│  │  [panelEspecifico]                             │ │
│  │  (Cambia según el tipo seleccionado)           │ │
│  │                                                 │ │
│  └─────────────────────────────────────────────────┘ │
│                                                      │
│  [btnAgregar]  [btnCalcularTodos]  [btnLimpiar]     │
│                                                      │
│  Lista de Empleados:                                 │
│  ┌────────────────────────────────────────────────┐ │
│  │ lstEmpleados                                   │ │
│  │                                                │ │
│  └────────────────────────────────────────────────┘ │
│                                                      │
│  Información Detallada:                              │
│  ┌────────────────────────────────────────────────┐ │
│  │ txtDetalles                                    │ │
│  │                                                │ │
│  │                                                │ │
│  └────────────────────────────────────────────────┘ │
└──────────────────────────────────────────────────────┘
```

### 🎨 Archivo: FormEmpleados.Designer.cs

**Este archivo contiene el DISEÑO VISUAL del formulario (lo genera Visual Studio)**

```csharp
namespace SistemaEmpleados
{
    partial class FormEmpleados
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador.
        /// No se puede modificar el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpDatosBasicos = new System.Windows.Forms.GroupBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtSalarioBase = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblSalarioBase = new System.Windows.Forms.Label();
            
            this.grpTipoEmpleado = new System.Windows.Forms.GroupBox();
            this.rdoPorHora = new System.Windows.Forms.RadioButton();
            this.rdoComision = new System.Windows.Forms.RadioButton();
            this.rdoGerente = new System.Windows.Forms.RadioButton();
            
            this.panelEspecifico = new System.Windows.Forms.Panel();
            
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCalcularTodos = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            
            this.lstEmpleados = new System.Windows.Forms.ListBox();
            this.txtDetalles = new System.Windows.Forms.TextBox();
            
            this.grpDatosBasicos.SuspendLayout();
            this.grpTipoEmpleado.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // grpDatosBasicos
            // 
            this.grpDatosBasicos.Controls.Add(this.lblNombre);
            this.grpDatosBasicos.Controls.Add(this.txtNombre);
            this.grpDatosBasicos.Controls.Add(this.lblApellido);
            this.grpDatosBasicos.Controls.Add(this.txtApellido);
            this.grpDatosBasicos.Controls.Add(this.lblCedula);
            this.grpDatosBasicos.Controls.Add(this.txtCedula);
            this.grpDatosBasicos.Controls.Add(this.lblSalarioBase);
            this.grpDatosBasicos.Controls.Add(this.txtSalarioBase);
            this.grpDatosBasicos.Location = new System.Drawing.Point(12, 12);
            this.grpDatosBasicos.Name = "grpDatosBasicos";
            this.grpDatosBasicos.Size = new System.Drawing.Size(760, 100);
            this.grpDatosBasicos.TabIndex = 0;
            this.grpDatosBasicos.TabStop = false;
            this.grpDatosBasicos.Text = "Datos Básicos";
            
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(100, 27);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 1;
            
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(320, 30);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(50, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(400, 27);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(200, 20);
            this.txtApellido.TabIndex = 3;
            
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Location = new System.Drawing.Point(20, 60);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(43, 13);
            this.lblCedula.TabIndex = 4;
            this.lblCedula.Text = "Cédula:";
            
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(100, 57);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(200, 20);
            this.txtCedula.TabIndex = 5;
            
            // 
            // lblSalarioBase
            // 
            this.lblSalarioBase.AutoSize = true;
            this.lblSalarioBase.Location = new System.Drawing.Point(320, 60);
            this.lblSalarioBase.Name = "lblSalarioBase";
            this.lblSalarioBase.Size = new System.Drawing.Size(70, 13);
            this.lblSalarioBase.TabIndex = 6;
            this.lblSalarioBase.Text = "Salario Base:";
            
            // 
            // txtSalarioBase
            // 
            this.txtSalarioBase.Location = new System.Drawing.Point(400, 57);
            this.txtSalarioBase.Name = "txtSalarioBase";
            this.txtSalarioBase.Size = new System.Drawing.Size(200, 20);
            this.txtSalarioBase.TabIndex = 7;
            
            // 
            // grpTipoEmpleado
            // 
            this.grpTipoEmpleado.Controls.Add(this.rdoPorHora);
            this.grpTipoEmpleado.Controls.Add(this.rdoComision);
            this.grpTipoEmpleado.Controls.Add(this.rdoGerente);
            this.grpTipoEmpleado.Location = new System.Drawing.Point(12, 118);
            this.grpTipoEmpleado.Name = "grpTipoEmpleado";
            this.grpTipoEmpleado.Size = new System.Drawing.Size(760, 60);
            this.grpTipoEmpleado.TabIndex = 1;
            this.grpTipoEmpleado.TabStop = false;
            this.grpTipoEmpleado.Text = "Tipo de Empleado";
            
            // 
            // rdoPorHora
            // 
            this.rdoPorHora.AutoSize = true;
            this.rdoPorHora.Location = new System.Drawing.Point(50, 25);
            this.rdoPorHora.Name = "rdoPorHora";
            this.rdoPorHora.Size = new System.Drawing.Size(70, 17);
            this.rdoPorHora.TabIndex = 0;
            this.rdoPorHora.TabStop = true;
            this.rdoPorHora.Text = "Por Hora";
            this.rdoPorHora.UseVisualStyleBackColor = true;
            
            // 
            // rdoComision
            // 
            this.rdoComision.AutoSize = true;
            this.rdoComision.Location = new System.Drawing.Point(250, 25);
            this.rdoComision.Name = "rdoComision";
            this.rdoComision.Size = new System.Drawing.Size(68, 17);
            this.rdoComision.TabIndex = 1;
            this.rdoComision.Text = "Comisión";
            this.rdoComision.UseVisualStyleBackColor = true;
            
            // 
            // rdoGerente
            // 
            this.rdoGerente.AutoSize = true;
            this.rdoGerente.Location = new System.Drawing.Point(450, 25);
            this.rdoGerente.Name = "rdoGerente";
            this.rdoGerente.Size = new System.Drawing.Size(62, 17);
            this.rdoGerente.TabIndex = 2;
            this.rdoGerente.Text = "Gerente";
            this.rdoGerente.UseVisualStyleBackColor = true;
            
            // 
            // panelEspecifico
            // 
            this.panelEspecifico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEspecifico.Location = new System.Drawing.Point(12, 184);
            this.panelEspecifico.Name = "panelEspecifico";
            this.panelEspecifico.Size = new System.Drawing.Size(760, 80);
            this.panelEspecifico.TabIndex = 2;
            
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 280);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(150, 35);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar Empleado";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            
            // 
            // btnCalcularTodos
            // 
            this.btnCalcularTodos.Location = new System.Drawing.Point(312, 280);
            this.btnCalcularTodos.Name = "btnCalcularTodos";
            this.btnCalcularTodos.Size = new System.Drawing.Size(150, 35);
            this.btnCalcularTodos.TabIndex = 4;
            this.btnCalcularTodos.Text = "Calcular Nómina";
            this.btnCalcularTodos.UseVisualStyleBackColor = true;
            this.btnCalcularTodos.Click += new System.EventHandler(this.btnCalcularTodos_Click);
            
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(622, 280);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 35);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            
            // 
            // lstEmpleados
            // 
            this.lstEmpleados.FormattingEnabled = true;
            this.lstEmpleados.Location = new System.Drawing.Point(12, 330);
            this.lstEmpleados.Name = "lstEmpleados";
            this.lstEmpleados.Size = new System.Drawing.Size(760, 120);
            this.lstEmpleados.TabIndex = 6;
            this.lstEmpleados.SelectedIndexChanged += new System.EventHandler(this.lstEmpleados_SelectedIndexChanged);
            
            // 
            // txtDetalles
            // 
            this.txtDetalles.Location = new System.Drawing.Point(12, 460);
            this.txtDetalles.Multiline = true;
            this.txtDetalles.Name = "txtDetalles";
            this.txtDetalles.ReadOnly = true;
            this.txtDetalles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalles.Size = new System.Drawing.Size(760, 120);
            this.txtDetalles.TabIndex = 7;
            
            // 
            // FormEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 592);
            this.Controls.Add(this.txtDetalles);
            this.Controls.Add(this.lstEmpleados);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCalcularTodos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.panelEspecifico);
            this.Controls.Add(this.grpTipoEmpleado);
            this.Controls.Add(this.grpDatosBasicos);
            this.Name = "FormEmpleados";
            this.Text = "Sistema de Gestión de Empleados";
            this.grpDatosBasicos.ResumeLayout(false);
            this.grpDatosBasicos.PerformLayout();
            this.grpTipoEmpleado.ResumeLayout(false);
            this.grpTipoEmpleado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Declaración de controles (Visual Studio los genera automáticamente)
        private System.Windows.Forms.GroupBox grpDatosBasicos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblSalarioBase;
        private System.Windows.Forms.TextBox txtSalarioBase;
        
        private System.Windows.Forms.GroupBox grpTipoEmpleado;
        private System.Windows.Forms.RadioButton rdoPorHora;
        private System.Windows.Forms.RadioButton rdoComision;
        private System.Windows.Forms.RadioButton rdoGerente;
        
        private System.Windows.Forms.Panel panelEspecifico;
        
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCalcularTodos;
        private System.Windows.Forms.Button btnLimpiar;
        
        private System.Windows.Forms.ListBox lstEmpleados;
        private System.Windows.Forms.TextBox txtDetalles;
    }
}
```

### 💻 Archivo: FormEmpleados.cs

**Este archivo contiene la LÓGICA del formulario (aquí escribes tu código)**

```csharp
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaEmpleados
{
    public partial class FormEmpleados : Form
    {
        // ═══════════════════════════════════════════════════
        // VARIABLES DE CLASE
        // ═══════════════════════════════════════════════════
        
        // Lista que puede contener cualquier tipo de Empleado (¡Polimorfismo!)
        private List<Empleado> empleados;
        
        // ═══════════════════════════════════════════════════
        // CONSTRUCTOR
        // ═══════════════════════════════════════════════════
        
        public FormEmpleados()
        {
            InitializeComponent();  // Inicializa los controles del Designer
            empleados = new List<Empleado>();
            ConfigurarFormulario();
        }
        
        // ═══════════════════════════════════════════════════
        // CONFIGURACIÓN INICIAL
        // ═══════════════════════════════════════════════════
        
        private void ConfigurarFormulario()
        {
            // Conectar eventos de los radio buttons
            rdoPorHora.CheckedChanged += TipoEmpleado_CheckedChanged;
            rdoComision.CheckedChanged += TipoEmpleado_CheckedChanged;
            rdoGerente.CheckedChanged += TipoEmpleado_CheckedChanged;
            
            // Seleccionar "Por Hora" por defecto
            rdoPorHora.Checked = true;
        }
        
        // ═══════════════════════════════════════════════════
        // EVENTOS DE CONTROLES
        // ═══════════════════════════════════════════════════
        
        // Evento cuando cambia el tipo de empleado seleccionado
        private void TipoEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            // Limpiar el panel de campos específicos
            panelEspecifico.Controls.Clear();
            
            // Mostrar los campos correspondientes al tipo seleccionado
            if (rdoPorHora.Checked)
            {
                MostrarCamposPorHora();
            }
            else if (rdoComision.Checked)
            {
                MostrarCamposComision();
            }
            else if (rdoGerente.Checked)
            {
                MostrarCamposGerente();
            }
        }
        
        // Evento cuando se selecciona un empleado de la lista
        private void lstEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEmpleados.SelectedIndex < 0) return;
            
            // Obtener el empleado seleccionado
            Empleado empSeleccionado = empleados[lstEmpleados.SelectedIndex];
            
            // Polimorfismo: cada objeto usa su propia versión de ObtenerInfo()
            txtDetalles.Text = empSeleccionado.ObtenerInfo();
        }
        
        // ═══════════════════════════════════════════════════
        // MÉTODOS PARA MOSTRAR CAMPOS ESPECÍFICOS
        // ═══════════════════════════════════════════════════
        
        // Mostrar campos para empleado por hora
        private void MostrarCamposPorHora()
        {
            // Crear controles dinámicamente
            Label lblTarifa = new Label 
            { 
                Text = "Tarifa por Hora:", 
                Left = 10, 
                Top = 10, 
                Width = 120 
            };
            TextBox txtTarifa = new TextBox 
            { 
                Name = "txtTarifa", 
                Left = 140, 
                Top = 10, 
                Width = 150 
            };
            
            Label lblHoras = new Label 
            { 
                Text = "Horas Trabajadas:", 
                Left = 10, 
                Top = 40, 
                Width = 120 
            };
            TextBox txtHoras = new TextBox 
            { 
                Name = "txtHoras", 
                Left = 140, 
                Top = 40, 
                Width = 150 
            };
            
            // Agregar controles al panel
            panelEspecifico.Controls.AddRange(new Control[] { lblTarifa, txtTarifa, lblHoras, txtHoras });
        }
        
        // Mostrar campos para empleado con comisión
        private void MostrarCamposComision()
        {
            Label lblPorcentaje = new Label 
            { 
                Text = "% Comisión:", 
                Left = 10, 
                Top = 10, 
                Width = 120 
            };
            TextBox txtPorcentaje = new TextBox 
            { 
                Name = "txtPorcentaje", 
                Left = 140, 
                Top = 10, 
                Width = 150 
            };
            
            Label lblVentas = new Label 
            { 
                Text = "Total Ventas:", 
                Left = 10, 
                Top = 40, 
                Width = 120 
            };
            TextBox txtVentas = new TextBox 
            { 
                Name = "txtVentas", 
                Left = 140, 
                Top = 40, 
                Width = 150 
            };
            
            panelEspecifico.Controls.AddRange(new Control[] { lblPorcentaje, txtPorcentaje, lblVentas, txtVentas });
        }
        
        // Mostrar campos para gerente
        private void MostrarCamposGerente()
        {
            Label lblDepartamento = new Label 
            { 
                Text = "Departamento:", 
                Left = 10, 
                Top = 10, 
                Width = 120 
            };
            TextBox txtDepartamento = new TextBox 
            { 
                Name = "txtDepartamento", 
                Left = 140, 
                Top = 10, 
                Width = 150 
            };
            
            Label lblBono = new Label 
            { 
                Text = "Bono Gerencial:", 
                Left = 10, 
                Top = 40, 
                Width = 120 
            };
            TextBox txtBono = new TextBox 
            { 
                Name = "txtBono", 
                Left = 140, 
                Top = 40, 
                Width = 150 
            };
            
            panelEspecifico.Controls.AddRange(new Control[] { lblDepartamento, txtDepartamento, lblBono, txtBono });
        }
        
        // ═══════════════════════════════════════════════════
        // EVENTOS DE BOTONES
        // ═══════════════════════════════════════════════════
        
        // Botón: Agregar empleado
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos básicos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || 
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtCedula.Text))
                {
                    MessageBox.Show("Complete todos los campos básicos", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Obtener datos comunes
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string cedula = txtCedula.Text;
                decimal salarioBase = decimal.Parse(txtSalarioBase.Text);
                
                Empleado nuevoEmpleado = null;
                
                // Crear el tipo correcto de empleado según la selección
                // ¡Aquí aplicamos HERENCIA Y POLIMORFISMO!
                
                if (rdoPorHora.Checked)
                {
                    // Obtener controles específicos del panel
                    TextBox txtTarifa = panelEspecifico.Controls["txtTarifa"] as TextBox;
                    TextBox txtHoras = panelEspecifico.Controls["txtHoras"] as TextBox;
                    
                    decimal tarifa = decimal.Parse(txtTarifa.Text);
                    int horas = int.Parse(txtHoras.Text);
                    
                    // Crear objeto EmpleadoPorHora
                    EmpleadoPorHora emp = new EmpleadoPorHora(nombre, apellido, cedula, salarioBase, tarifa);
                    emp.HorasTrabajadas = horas;
                    nuevoEmpleado = emp;  // Polimorfismo: EmpleadoPorHora ES UN Empleado
                }
                else if (rdoComision.Checked)
                {
                    TextBox txtPorcentaje = panelEspecifico.Controls["txtPorcentaje"] as TextBox;
                    TextBox txtVentas = panelEspecifico.Controls["txtVentas"] as TextBox;
                    
                    decimal porcentaje = decimal.Parse(txtPorcentaje.Text);
                    decimal ventas = decimal.Parse(txtVentas.Text);
                    
                    // Crear objeto EmpleadoComision
                    EmpleadoComision emp = new EmpleadoComision(nombre, apellido, cedula, salarioBase, porcentaje);
                    emp.TotalVentas = ventas;
                    nuevoEmpleado = emp;  // Polimorfismo: EmpleadoComision ES UN Empleado
                }
                else if (rdoGerente.Checked)
                {
                    TextBox txtDepartamento = panelEspecifico.Controls["txtDepartamento"] as TextBox;
                    TextBox txtBono = panelEspecifico.Controls["txtBono"] as TextBox;
                    
                    string departamento = txtDepartamento.Text;
                    decimal bono = decimal.Parse(txtBono.Text);
                    
                    // Crear objeto Gerente
                    nuevoEmpleado = new Gerente(nombre, apellido, cedula, salarioBase, departamento, bono);
                    // Polimorfismo: Gerente ES UN Empleado
                }
                
                // Agregar a la lista (¡Polimorfismo en acción!)
                // La lista puede contener diferentes tipos de empleados
                empleados.Add(nuevoEmpleado);
                
                // Actualizar interfaz
                ActualizarLista();
                LimpiarCampos();
                
                MessageBox.Show("Empleado agregado exitosamente", "Éxito", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese valores numéricos válidos", "Error de Formato", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // Botón: Calcular nómina total
        private void btnCalcularTodos_Click(object sender, EventArgs e)
        {
            if (empleados.Count == 0)
            {
                MessageBox.Show("No hay empleados registrados", "Información",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            decimal totalNomina = 0;
            string reporte = "═══════════════════════════════════\n";
            reporte += "   REPORTE DE NÓMINA\n";
            reporte += "═══════════════════════════════════\n\n";
            
            // Polimorfismo: cada empleado calcula su salario de forma diferente
            foreach (Empleado emp in empleados)
            {
                decimal salario = emp.CalcularSalario();  // ¡Polimorfismo!
                totalNomina += salario;
                
                reporte += $"{emp.ObtenerNombreCompleto()}\n";
                reporte += $"Salario: ${salario:N2}\n";
                reporte += "───────────────────────────────────\n";
            }
            
            reporte += $"\nTOTAL NÓMINA: ${totalNomina:N2}";
            
            txtDetalles.Text = reporte;
        }
        
        // Botón: Limpiar campos
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        
        // ═══════════════════════════════════════════════════
        // MÉTODOS AUXILIARES
        // ═══════════════════════════════════════════════════
        
        // Actualizar la lista de empleados mostrada
        private void ActualizarLista()
        {
            lstEmpleados.Items.Clear();
            
            foreach (Empleado emp in empleados)
            {
                // Usar operador 'is' para determinar el tipo de empleado
                string tipo = "";
                if (emp is EmpleadoPorHora)
                    tipo = "⏰";
                else if (emp is EmpleadoComision)
                    tipo = "💰";
                else if (emp is Gerente)
                    tipo = "👨‍💼";
                
                // Polimorfismo: cada objeto usa su propia versión de CalcularSalario()
                decimal salario = emp.CalcularSalario();
                
                lstEmpleados.Items.Add($"{tipo} {emp.ObtenerNombreCompleto()} - ${salario:N2}");
            }
        }
        
        // Limpiar todos los campos del formulario
        private void LimpiarCampos()
        {
            // Limpiar campos básicos
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtSalarioBase.Clear();
            
            // Limpiar campos del panel específico
            foreach (Control control in panelEspecifico.Controls)
            {
                if (control is TextBox)
                    ((TextBox)control).Clear();
            }
            
            // Limpiar detalles
            txtDetalles.Clear();
            
            // Establecer foco en el primer campo
            txtNombre.Focus();
        }
    }  // Fin de la clase FormEmpleados
}  // Fin del namespace
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

## 🎯 Ejemplo Práctico: Formas Geométricas

### Las Clases

```csharp
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// CLASE BASE
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
public abstract class Forma
{
    public string Color { get; set; }
    
    public Forma(string color)
    {
        Color = color;
    }
    
    // Métodos abstractos (DEBEN ser implementados)
    public abstract double CalcularArea();
    public abstract double CalcularPerimetro();
    
    // Método normal
    public virtual string ObtenerInfo()
    {
        return $"Forma de color {Color}";
    }
}

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// RECTANGULO
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
public class Rectangulo : Forma
{
    public double Base { get; set; }
    public double Altura { get; set; }
    
    public Rectangulo(string color, double baseRect, double altura) 
        : base(color)
    {
        Base = baseRect;
        Altura = altura;
    }
    
    public override double CalcularArea()
    {
        return Base * Altura;
    }
    
    public override double CalcularPerimetro()
    {
        return 2 * (Base + Altura);
    }
    
    public override string ObtenerInfo()
    {
        return base.ObtenerInfo() + 
               $"\nTipo: Rectángulo" +
               $"\nBase: {Base}" +
               $"\nAltura: {Altura}" +
               $"\nÁrea: {CalcularArea():N2}" +
               $"\nPerímetro: {CalcularPerimetro():N2}";
    }
}

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// CIRCULO
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
public class Circulo : Forma
{
    public double Radio { get; set; }
    
    public Circulo(string color, double radio) : base(color)
    {
        Radio = radio;
    }
    
    public override double CalcularArea()
    {
        return Math.PI * Radio * Radio;
    }
    
    public override double CalcularPerimetro()
    {
        return 2 * Math.PI * Radio;
    }
    
    public override string ObtenerInfo()
    {
        return base.ObtenerInfo() + 
               $"\nTipo: Círculo" +
               $"\nRadio: {Radio}" +
               $"\nÁrea: {CalcularArea():N2}" +
               $"\nPerímetro: {CalcularPerimetro():N2}";
    }
}

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// TRIANGULO
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
public class Triangulo : Forma
{
    public double Base { get; set; }
    public double Altura { get; set; }
    public double Lado1 { get; set; }
    public double Lado2 { get; set; }
    public double Lado3 { get; set; }
    
    public Triangulo(string color, double baseT, double altura, 
                    double lado1, double lado2, double lado3) 
        : base(color)
    {
        Base = baseT;
        Altura = altura;
        Lado1 = lado1;
        Lado2 = lado2;
        Lado3 = lado3;
    }
    
    public override double CalcularArea()
    {
        return (Base * Altura) / 2;
    }
    
    public override double CalcularPerimetro()
    {
        return Lado1 + Lado2 + Lado3;
    }
    
    public override string ObtenerInfo()
    {
        return base.ObtenerInfo() + 
               $"\nTipo: Triángulo" +
               $"\nBase: {Base}" +
               $"\nAltura: {Altura}" +
               $"\nÁrea: {CalcularArea():N2}" +
               $"\nPerímetro: {CalcularPerimetro():N2}";
    }
}
```

### Jerarquía Visual

```
                    🔷 FORMA (Abstracta)
                    ════════════════════
                    + Color
                    + CalcularArea() [abstracto]
                    + CalcularPerimetro() [abstracto]
                    + ObtenerInfo() [virtual]
                          │
        ┌─────────────────┼─────────────────┐
        │                 │                 │
        ↓                 ↓                 ↓
    📐 RECTANGULO      ⭕ CIRCULO        🔺 TRIANGULO
    ═════════════      ═══════════      ══════════════
    + Base             + Radio          + Base
    + Altura                            + Altura
                                        + Lado1, 2, 3
    Override:          Override:        Override:
    - CalcularArea()   - CalcularArea() - CalcularArea()
    - CalcularPerim()  - CalcularPerim()- CalcularPerim()
    - ObtenerInfo()    - ObtenerInfo()  - ObtenerInfo()
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

## 🎓 Conceptos Avanzados

### Clase Abstracta vs Clase Normal

```csharp
// CLASE ABSTRACTA (no se puede instanciar)
public abstract class Animal
{
    public abstract string HacerSonido();  // Método abstracto
}

// NO PUEDES HACER:
// Animal a = new Animal();  ❌ ERROR

// CLASE NORMAL
public class Perro : Animal
{
    public override string HacerSonido()
    {
        return "Guau";
    }
}

// SÍ PUEDES HACER:
Perro p = new Perro();  ✅ OK
```

### Herencia Multinivel

```csharp
public class Ser { }
public class SerVivo : Ser { }
public class Animal : SerVivo { }
public class Mamifero : Animal { }
public class Perro : Mamifero { }
```

**Visual:**
```
    🌍 Ser
     │
     └─► 🦠 SerVivo
          │
          └─► 🐾 Animal
               │
               └─► 🐕 Mamífero
                    │
                    └─► 🐶 Perro
```

## 📝 Ejercicios Prácticos

### Ejercicio 1: Sistema de Vehículos

Crea una jerarquía de vehículos:
- Clase base: `Vehiculo` (marca, modelo, año)
- Clases derivadas: `Auto`, `Moto`, `Camion`
- Cada uno con sus propiedades específicas
- Método `CalcularImpuesto()` diferente para cada uno

### Ejercicio 2: Cuentas Bancarias

Implementa:
- Clase base: `CuentaBancaria` (numero, titular, saldo)
- Derivadas: `CuentaAhorro`, `CuentaCorriente`, `CuentaNomina`
- Método `CalcularInteres()` específico para cada tipo
- Formulario para gestionar múltiples cuentas

### Ejercicio 3: Sistema de Figuras 3D

Extiende el ejemplo de formas geométricas:
- Clase base: `Forma3D`
- Derivadas: `Cubo`, `Esfera`, `Cilindro`
- Métodos: `CalcularVolumen()`, `CalcularSuperficie()`

## 🎯 Resumen Final

### Conceptos Clave

```
╔═══════════════════════════════════════════════════════╗
║  🎓 RESUMEN DE HERENCIA                               ║
╠═══════════════════════════════════════════════════════╣
║                                                       ║
║  HERENCIA                                             ║
║  ─────────                                            ║
║  • Permite reutilizar código                          ║
║  • Crea jerarquías de clases                          ║
║  • Sintaxis: class Hijo : Padre                       ║
║                                                       ║
║  PALABRAS CLAVE                                       ║
║  ───────────────                                      ║
║  • base      → Acceder a la clase padre              ║
║  • virtual   → Método que PUEDE sobrescribirse        ║
║  • override  → Sobrescribir método del padre          ║
║  • abstract  → Método que DEBE implementarse          ║
║  • is        → Verificar tipo de objeto               ║
║  • as        → Convertir tipo de objeto               ║
║                                                       ║
║  POLIMORFISMO                                         ║
║  ─────────────                                        ║
║  • Objetos de diferentes tipos responden igual        ║
║  • Una variable del padre puede contener hijos        ║
║  • Cada hijo ejecuta su propia versión                ║
║                                                       ║
╚═══════════════════════════════════════════════════════╝
```

### Diagrama Completo

```
                    📋 CLASE BASE
                    ═════════════
                    Propiedades comunes
                    Métodos comunes
                    Métodos virtuales
                          │
                          │ hereda
                          ↓
        ┌─────────────────┼─────────────────┐
        │                 │                 │
        ↓                 ↓                 ↓
    HIJO 1           HIJO 2           HIJO 3
    ══════           ══════           ══════
    + Hereda todo    + Hereda todo    + Hereda todo
    + Agrega props   + Agrega props   + Agrega props
    + Override mtds  + Override mtds  + Override mtds
        │                 │                 │
        └─────────────────┴─────────────────┘
                          │
                          ↓
              🎭 POLIMORFISMO
              Lista<Base> puede contener
              todos los tipos de hijos
```

## 🚀 Próximos Pasos

Has completado los fundamentos de POO. Ahora estás listo para:
- ✅ Interfaces
- ✅ Clases abstractas avanzadas
- ✅ Patrones de diseño
- ✅ Proyectos más complejos

---

**💡 Recuerda:** La herencia es una herramienta poderosa. Úsala cuando tengas una relación **"ES UN"**. Por ejemplo: Un Perro **ES UN** Animal, Un Auto **ES UN** Vehículo.

**🎯 Practica mucho:** Crea jerarquías, experimenta con polimorfismo, y verás cómo tu código se vuelve más organizado y reutilizable.
