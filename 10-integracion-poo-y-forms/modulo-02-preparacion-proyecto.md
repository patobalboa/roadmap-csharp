# 📘 Módulo 2: DataGridView y Múltiples Formularios

## 🎯 Objetivos del Módulo

- Trabajar con **DataGridView** para mostrar datos en tablas
- Crear y gestionar **múltiples formularios** (ventanas)
- Relacionar **dos clases** entre sí
- Usar **ComboBox** para seleccionar opciones
- Implementar un sistema de ventas básico

---

## 📚 Proyecto: Sistema de Productos y Ventas (Simplificado)

Crearemos un sistema básico con productos y ventas para que aprendas los conceptos que necesitarás en tu proyecto final.

```
PARTE 1: Gestión de Productos con DataGridView
   ↓
PARTE 2: Crear Menú Principal (múltiples ventanas)
   ↓
PARTE 3: Registrar Ventas (relacionar Producto con Venta)
   ↓
PARTE 4: Ver Historial de Ventas
```

---

## 📍 PARTE 1: Gestión de Productos con DataGridView

### 🎯 Objetivo
Aprender a usar DataGridView para mostrar y gestionar datos en forma de tabla.

### 📐 Paso 1.1: Crear el Proyecto

1. Abrir Visual Studio 2022
2. Crear nuevo proyecto → **Windows Forms App (.NET Framework)**
3. Nombre: `SistemaVentasBasico`
4. Presionar **Crear**

### 📐 Paso 1.2: Crear la Clase Producto

**Clic derecho en el proyecto → Agregar → Clase → Nombre: `Producto.cs`**

```csharp
public class Producto
{
    // Propiedades
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    
    // Constructor vacío
    public Producto()
    {
    }
    
    // Constructor con parámetros
    public Producto(int codigo, string nombre, decimal precio, int stock)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }
    
    // Método para convertir a texto (para archivo)
    public string ATexto()
    {
        return $"{Codigo}|{Nombre}|{Precio}|{Stock}";
    }
    
    // Método para crear desde texto
    public static Producto DesdeTexto(string linea)
    {
        string[] partes = linea.Split('|');
        return new Producto
        {
            Codigo = int.Parse(partes[0]),
            Nombre = partes[1],
            Precio = decimal.Parse(partes[2]),
            Stock = int.Parse(partes[3])
        };
    }
}
```

### 🖼️ Paso 1.3: Diseñar FormProductos

**Renombrar Form1 a `FormProductos`:**
1. En el Explorador de Soluciones, clic derecho en `Form1.cs`
2. Cambiar nombre a: `FormProductos.cs`

**Diseñar el formulario:**

```
┌────────────────────────────────────────────────┐
│  Gestión de Productos                          │
├────────────────────────────────────────────────┤
│                                                │
│  Código:  [txtCodigo ]  Precio:  [txtPrecio ] │
│  Nombre:  [txtNombre ]  Stock:   [txtStock  ] │
│                                                │
│  [btnAgregar] [btnModificar] [btnEliminar]     │
│  [btnLimpiar]                                  │
│                                                │
│  Lista de Productos:                           │
│  ┌──────────────────────────────────────────┐  │
│  │ DataGridView: dgvProductos               │  │
│  │ Código | Nombre | Precio | Stock         │  │
│  │   1    | Arroz  | $2.50  |  100          │  │
│  │   2    | Aceite | $3.80  |   50          │  │
│  └──────────────────────────────────────────┘  │
└────────────────────────────────────────────────┘
```

**Controles a crear:**
- `Label`: "Código:", "Nombre:", "Precio:", "Stock:"
- `TextBox`: `txtCodigo`, `txtNombre`, `txtPrecio`, `txtStock`
- `Button`: `btnAgregar` (Text: "Agregar"), `btnModificar` (Text: "Modificar")
- `Button`: `btnEliminar` (Text: "Eliminar"), `btnLimpiar` (Text: "Limpiar")
- `DataGridView`: `dgvProductos`

### 📐 Paso 1.4: Configurar el DataGridView

**Seleccionar `dgvProductos` y en Propiedades:**
1. **AllowUserToAddRows**: False
2. **AllowUserToDeleteRows**: False
3. **SelectionMode**: FullRowSelect
4. **MultiSelect**: False
5. **ReadOnly**: True

**Agregar columnas al DataGridView:**
1. Clic en la flecha del DataGridView → **Editar columnas**
2. Agregar 4 columnas:
   - **Columna 1**: Name: `colCodigo`, HeaderText: "Código"
   - **Columna 2**: Name: `colNombre`, HeaderText: "Nombre"
   - **Columna 3**: Name: `colPrecio`, HeaderText: "Precio"
   - **Columna 4**: Name: `colStock`, HeaderText: "Stock"

### 💻 Paso 1.5: Programar FormProductos

**En FormProductos.cs, agregar:**

```csharp
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

public partial class FormProductos : Form
{
    // Lista de productos en memoria
    private List<Producto> listaProductos = new List<Producto>();
    private string archivoProductos = "productos.txt";
    private int indiceEditando = -1;
    
    public FormProductos()
    {
        InitializeComponent();
        CargarProductos();
    }
    
    // Cargar productos desde archivo
    private void CargarProductos()
    {
        listaProductos.Clear();
        
        if (File.Exists(archivoProductos))
        {
            string[] lineas = File.ReadAllLines(archivoProductos);
            foreach (string linea in lineas)
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    Producto p = Producto.DesdeTexto(linea);
                    listaProductos.Add(p);
                }
            }
        }
        
        ActualizarGrid();
    }
    
    // Guardar productos en archivo
    private void GuardarProductos()
    {
        List<string> lineas = new List<string>();
        foreach (Producto p in listaProductos)
        {
            lineas.Add(p.ATexto());
        }
        File.WriteAllLines(archivoProductos, lineas);
    }
    
    // Actualizar DataGridView
    private void ActualizarGrid()
    {
        dgvProductos.Rows.Clear();
        
        foreach (Producto p in listaProductos)
        {
            int index = dgvProductos.Rows.Add();
            dgvProductos.Rows[index].Cells["colCodigo"].Value = p.Codigo;
            dgvProductos.Rows[index].Cells["colNombre"].Value = p.Nombre;
            dgvProductos.Rows[index].Cells["colPrecio"].Value = p.Precio.ToString("C");
            dgvProductos.Rows[index].Cells["colStock"].Value = p.Stock;
        }
    }
    
    // Validar campos
    private bool ValidarCampos()
    {
        if (string.IsNullOrWhiteSpace(txtCodigo.Text))
        {
            MessageBox.Show("Ingrese un código", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MessageBox.Show("Ingrese un nombre", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
        {
            MessageBox.Show("Ingrese un precio válido mayor a 0", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
        {
            MessageBox.Show("Ingrese un stock válido", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        return true;
    }
    
    // Limpiar campos
    private void LimpiarCampos()
    {
        txtCodigo.Clear();
        txtNombre.Clear();
        txtPrecio.Clear();
        txtStock.Clear();
        txtCodigo.Focus();
        
        if (indiceEditando >= 0)
        {
            indiceEditando = -1;
            btnAgregar.Text = "Agregar";
        }
    }
}
```

### 💻 Paso 1.6: Programar Botones

**Doble clic en cada botón y agregar el código:**

**Botón Agregar:**
```csharp
private void btnAgregar_Click(object sender, EventArgs e)
{
    if (!ValidarCampos()) return;
    
    int codigo = int.Parse(txtCodigo.Text);
    
    if (indiceEditando >= 0)
    {
        // Modo edición
        listaProductos[indiceEditando].Codigo = codigo;
        listaProductos[indiceEditando].Nombre = txtNombre.Text;
        listaProductos[indiceEditando].Precio = decimal.Parse(txtPrecio.Text);
        listaProductos[indiceEditando].Stock = int.Parse(txtStock.Text);
        
        indiceEditando = -1;
        btnAgregar.Text = "Agregar";
    }
    else
    {
        // Verificar código duplicado
        foreach (Producto p in listaProductos)
        {
            if (p.Codigo == codigo)
            {
                MessageBox.Show("El código ya existe", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        
        // Modo agregar
        Producto nuevo = new Producto(
            codigo,
            txtNombre.Text,
            decimal.Parse(txtPrecio.Text),
            int.Parse(txtStock.Text)
        );
        
        listaProductos.Add(nuevo);
    }
    
    GuardarProductos();
    ActualizarGrid();
    LimpiarCampos();
}
```

**Botón Modificar:**
```csharp
private void btnModificar_Click(object sender, EventArgs e)
{
    if (dgvProductos.SelectedRows.Count == 0)
    {
        MessageBox.Show("Seleccione un producto para modificar", "Aviso", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
    }
    
    indiceEditando = dgvProductos.SelectedRows[0].Index;
    Producto p = listaProductos[indiceEditando];
    
    txtCodigo.Text = p.Codigo.ToString();
    txtNombre.Text = p.Nombre;
    txtPrecio.Text = p.Precio.ToString();
    txtStock.Text = p.Stock.ToString();
    
    btnAgregar.Text = "Guardar Cambios";
    txtCodigo.Focus();
}
```

**Botón Eliminar:**
```csharp
private void btnEliminar_Click(object sender, EventArgs e)
{
    if (dgvProductos.SelectedRows.Count == 0)
    {
        MessageBox.Show("Seleccione un producto para eliminar", "Aviso", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
    }
    
    DialogResult resultado = MessageBox.Show(
        "¿Está seguro de eliminar este producto?",
        "Confirmar",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);
    
    if (resultado == DialogResult.Yes)
    {
        int indice = dgvProductos.SelectedRows[0].Index;
        listaProductos.RemoveAt(indice);
        
        GuardarProductos();
        ActualizarGrid();
        LimpiarCampos();
    }
}
```

**Botón Limpiar:**
```csharp
private void btnLimpiar_Click(object sender, EventArgs e)
{
    LimpiarCampos();
}
```

### ✅ Probar la Parte 1

1. Ejecutar el programa (F5)
2. Agregar varios productos
3. ¿Se muestran en el DataGridView?
4. Modificar un producto
5. Eliminar un producto
6. Cerrar y volver a abrir
7. ¿Los datos persisten?

### 🎓 Conceptos Aprendidos en Parte 1
- ✅ Configurar DataGridView con columnas
- ✅ Agregar filas programáticamente
- ✅ Seleccionar filas completas
- ✅ Obtener valores de celdas específicas
- ✅ Validar números (int.TryParse, decimal.TryParse)
- ✅ Verificar duplicados antes de agregar
- ✅ Formatear precios con ToString("C")

---

## 📍 PARTE 2: Menú Principal con Múltiples Formularios

### 🎯 Objetivo
Aprender a crear múltiples ventanas y navegar entre ellas.

### 📐 Paso 2.1: Crear FormPrincipal

**Agregar nuevo formulario:**
1. Clic derecho en el proyecto → Agregar → Formulario (Windows Forms)
2. Nombre: `FormPrincipal.cs`

**Diseñar FormPrincipal:**

```
┌────────────────────────────────────┐
│  Sistema de Ventas                 │
│  Menú Principal                    │
├────────────────────────────────────┤
│                                    │
│         🛍️  SISTEMA DE VENTAS      │
│                                    │
│  ┌──────────────────────────────┐  │
│  │  [Gestión de Productos]      │  │
│  └──────────────────────────────┘  │
│                                    │
│  ┌──────────────────────────────┐  │
│  │  [Registrar Venta]           │  │
│  └──────────────────────────────┘  │
│                                    │
│  ┌──────────────────────────────┐  │
│  │  [Ver Historial de Ventas]   │  │
│  └──────────────────────────────┘  │
│                                    │
│  ┌──────────────────────────────┐  │
│  │  [Salir]                     │  │
│  └──────────────────────────────┘  │
└────────────────────────────────────┘
```

**Controles:**
- `Label`: "SISTEMA DE VENTAS" (Font: Bold, Size: 16)
- `Button`: `btnProductos` (Text: "Gestión de Productos", Size: 250x40)
- `Button`: `btnVentas` (Text: "Registrar Venta", Size: 250x40)
- `Button`: `btnHistorial` (Text: "Ver Historial de Ventas", Size: 250x40)
- `Button`: `btnSalir` (Text: "Salir", Size: 250x40)

### 💻 Paso 2.2: Programar FormPrincipal

**En FormPrincipal.cs:**

```csharp
using System;
using System.Windows.Forms;

public partial class FormPrincipal : Form
{
    public FormPrincipal()
    {
        InitializeComponent();
    }
    
    private void btnProductos_Click(object sender, EventArgs e)
    {
        FormProductos formProductos = new FormProductos();
        formProductos.ShowDialog(); // Ventana modal (bloquea la principal)
    }
    
    private void btnVentas_Click(object sender, EventArgs e)
    {
        // Lo programaremos en la Parte 3
        MessageBox.Show("Próximamente: Registrar Venta", "Información");
    }
    
    private void btnHistorial_Click(object sender, EventArgs e)
    {
        // Lo programaremos en la Parte 4
        MessageBox.Show("Próximamente: Historial de Ventas", "Información");
    }
    
    private void btnSalir_Click(object sender, EventArgs e)
    {
        DialogResult resultado = MessageBox.Show(
            "¿Está seguro de salir?",
            "Confirmar Salida",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        
        if (resultado == DialogResult.Yes)
        {
            Application.Exit();
        }
    }
}
```

### 📐 Paso 2.3: Cambiar el Formulario de Inicio

**En Program.cs, cambiar:**

```csharp
static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new FormPrincipal()); // ← Cambiar a FormPrincipal
    }
}
```

### ✅ Probar la Parte 2

1. Ejecutar el programa
2. ¿Se ve el menú principal?
3. Presionar "Gestión de Productos"
4. ¿Se abre la ventana de productos?
5. ¿Puedes agregar/modificar productos?
6. Cerrar ventana de productos
7. ¿Vuelves al menú?
8. Presionar "Salir"
9. ¿Te pregunta confirmación?

### 🎓 Conceptos Aprendidos en Parte 2
- ✅ Crear múltiples formularios
- ✅ Usar `ShowDialog()` para ventanas modales
- ✅ Instanciar y abrir formularios
- ✅ Cambiar el formulario de inicio en Program.cs
- ✅ Usar `Application.Exit()` para cerrar la aplicación

---

## 📍 PARTE 3: Registrar Ventas (Relacionar Clases)

### 🎯 Objetivo
Aprender a relacionar dos clases: Producto con Venta.

### 📐 Paso 3.1: Crear la Clase Venta

**Agregar nueva clase: `Venta.cs`**

```csharp
using System;

public class Venta
{
    public int NumeroVenta { get; set; }
    public int CodigoProducto { get; set; }  // Relaciona con Producto
    public string NombreProducto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Total { get; set; }
    public DateTime Fecha { get; set; }
    
    public Venta()
    {
    }
    
    public Venta(int numeroVenta, int codigoProducto, string nombreProducto, 
                 int cantidad, decimal precioUnitario)
    {
        NumeroVenta = numeroVenta;
        CodigoProducto = codigoProducto;
        NombreProducto = nombreProducto;
        Cantidad = cantidad;
        PrecioUnitario = precioUnitario;
        Total = cantidad * precioUnitario;
        Fecha = DateTime.Now;
    }
    
    public string ATexto()
    {
        return $"{NumeroVenta}|{CodigoProducto}|{NombreProducto}|{Cantidad}|" +
               $"{PrecioUnitario}|{Total}|{Fecha:yyyy-MM-dd HH:mm:ss}";
    }
    
    public static Venta DesdeTexto(string linea)
    {
        string[] partes = linea.Split('|');
        return new Venta
        {
            NumeroVenta = int.Parse(partes[0]),
            CodigoProducto = int.Parse(partes[1]),
            NombreProducto = partes[2],
            Cantidad = int.Parse(partes[3]),
            PrecioUnitario = decimal.Parse(partes[4]),
            Total = decimal.Parse(partes[5]),
            Fecha = DateTime.Parse(partes[6])
        };
    }
}
```

### 📐 Paso 3.2: Crear FormVentas

**Agregar nuevo formulario: `FormVentas.cs`**

**Diseñar:**

```
┌────────────────────────────────────────────────┐
│  Registrar Venta                               │
├────────────────────────────────────────────────┤
│                                                │
│  Número de Venta: [lblNumeroVenta: 0001]      │
│                                                │
│  Producto:  [cmbProducto ▼]                    │
│  Precio:    [lblPrecio: $0.00]                 │
│  Stock:     [lblStock: 0]                      │
│                                                │
│  Cantidad:  [txtCantidad]                      │
│                                                │
│  Total:     [lblTotal: $0.00]                  │
│                                                │
│  [btnRegistrar] [btnCancelar]                  │
└────────────────────────────────────────────────┘
```

**Controles:**
- `Label`: "Número de Venta:", "Producto:", "Precio:", "Stock:", "Cantidad:", "Total:"
- `Label`: `lblNumeroVenta`, `lblPrecio`, `lblStock`, `lblTotal`
- `ComboBox`: `cmbProducto` (DropDownStyle: DropDownList)
- `TextBox`: `txtCantidad`
- `Button`: `btnRegistrar` (Text: "Registrar Venta"), `btnCancelar` (Text: "Cancelar")

### 💻 Paso 3.3: Programar FormVentas

```csharp
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

public partial class FormVentas : Form
{
    private List<Producto> listaProductos = new List<Producto>();
    private List<Venta> listaVentas = new List<Venta>();
    private string archivoProductos = "productos.txt";
    private string archivoVentas = "ventas.txt";
    
    public FormVentas()
    {
        InitializeComponent();
        CargarProductos();
        CargarVentas();
        GenerarNumeroVenta();
    }
    
    private void CargarProductos()
    {
        listaProductos.Clear();
        cmbProducto.Items.Clear();
        
        if (File.Exists(archivoProductos))
        {
            string[] lineas = File.ReadAllLines(archivoProductos);
            foreach (string linea in lineas)
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    Producto p = Producto.DesdeTexto(linea);
                    listaProductos.Add(p);
                    cmbProducto.Items.Add($"{p.Codigo} - {p.Nombre}");
                }
            }
        }
        
        if (cmbProducto.Items.Count > 0)
        {
            cmbProducto.SelectedIndex = 0;
        }
    }
    
    private void CargarVentas()
    {
        listaVentas.Clear();
        
        if (File.Exists(archivoVentas))
        {
            string[] lineas = File.ReadAllLines(archivoVentas);
            foreach (string linea in lineas)
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    Venta v = Venta.DesdeTexto(linea);
                    listaVentas.Add(v);
                }
            }
        }
    }
    
    private void GenerarNumeroVenta()
    {
        int ultimoNumero = 0;
        
        foreach (Venta v in listaVentas)
        {
            if (v.NumeroVenta > ultimoNumero)
            {
                ultimoNumero = v.NumeroVenta;
            }
        }
        
        lblNumeroVenta.Text = (ultimoNumero + 1).ToString("D4"); // 0001, 0002, etc.
    }
    
    private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbProducto.SelectedIndex >= 0)
        {
            Producto p = listaProductos[cmbProducto.SelectedIndex];
            lblPrecio.Text = p.Precio.ToString("C");
            lblStock.Text = p.Stock.ToString();
            CalcularTotal();
        }
    }
    
    private void txtCantidad_TextChanged(object sender, EventArgs e)
    {
        CalcularTotal();
    }
    
    private void CalcularTotal()
    {
        if (cmbProducto.SelectedIndex >= 0 && int.TryParse(txtCantidad.Text, out int cantidad))
        {
            Producto p = listaProductos[cmbProducto.SelectedIndex];
            decimal total = cantidad * p.Precio;
            lblTotal.Text = total.ToString("C");
        }
        else
        {
            lblTotal.Text = "$0.00";
        }
    }
    
    private void btnRegistrar_Click(object sender, EventArgs e)
    {
        // Validaciones
        if (cmbProducto.SelectedIndex < 0)
        {
            MessageBox.Show("Seleccione un producto", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
        {
            MessageBox.Show("Ingrese una cantidad válida", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        Producto productoSeleccionado = listaProductos[cmbProducto.SelectedIndex];
        
        if (cantidad > productoSeleccionado.Stock)
        {
            MessageBox.Show($"Stock insuficiente. Stock disponible: {productoSeleccionado.Stock}", 
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        // Crear venta
        int numeroVenta = int.Parse(lblNumeroVenta.Text);
        Venta nuevaVenta = new Venta(
            numeroVenta,
            productoSeleccionado.Codigo,
            productoSeleccionado.Nombre,
            cantidad,
            productoSeleccionado.Precio
        );
        
        // Actualizar stock del producto
        productoSeleccionado.Stock -= cantidad;
        
        // Guardar venta
        listaVentas.Add(nuevaVenta);
        List<string> lineasVentas = new List<string>();
        foreach (Venta v in listaVentas)
        {
            lineasVentas.Add(v.ATexto());
        }
        File.WriteAllLines(archivoVentas, lineasVentas);
        
        // Guardar productos actualizados
        List<string> lineasProductos = new List<string>();
        foreach (Producto p in listaProductos)
        {
            lineasProductos.Add(p.ATexto());
        }
        File.WriteAllLines(archivoProductos, lineasProductos);
        
        MessageBox.Show($"Venta #{numeroVenta} registrada exitosamente\nTotal: {nuevaVenta.Total:C}", 
            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        // Limpiar y preparar para nueva venta
        txtCantidad.Clear();
        CargarProductos(); // Recargar para actualizar stock
        GenerarNumeroVenta();
    }
    
    private void btnCancelar_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
```

### 📐 Paso 3.4: Conectar desde FormPrincipal

**En FormPrincipal.cs, modificar:**

```csharp
private void btnVentas_Click(object sender, EventArgs e)
{
    FormVentas formVentas = new FormVentas();
    formVentas.ShowDialog();
}
```

### ✅ Probar la Parte 3

1. Ejecutar el programa
2. Ir a "Gestión de Productos" y agregar algunos productos con stock
3. Volver al menú principal
4. Ir a "Registrar Venta"
5. ¿Aparecen los productos en el ComboBox?
6. Seleccionar un producto
7. ¿Se muestra precio y stock?
8. Ingresar cantidad
9. ¿Se calcula el total?
10. Registrar venta
11. ¿Se actualizó el stock del producto?

### 🎓 Conceptos Aprendidos en Parte 3
- ✅ Usar ComboBox para seleccionar opciones
- ✅ Relacionar dos clases (Producto y Venta)
- ✅ Guardar IDs para relacionar objetos
- ✅ Actualizar datos de una clase desde otra
- ✅ Generar números consecutivos automáticamente
- ✅ Formatear números con ToString("D4")
- ✅ Trabajar con fechas (DateTime.Now)
- ✅ Validar stock antes de vender

---

## 📍 PARTE 4: Historial de Ventas

### 🎯 Objetivo
Mostrar todas las ventas registradas en un DataGridView.

### 📐 Paso 4.1: Crear FormHistorialVentas

**Agregar nuevo formulario: `FormHistorialVentas.cs`**

**Diseñar:**

```
┌────────────────────────────────────────────────┐
│  Historial de Ventas                           │
├────────────────────────────────────────────────┤
│                                                │
│  ┌──────────────────────────────────────────┐  │
│  │ DataGridView: dgvHistorial               │  │
│  │ N° Venta | Producto | Cant | P.Unit | .. │  │
│  │   0001   | Arroz    |  5   | $2.50  | .. │  │
│  │   0002   | Aceite   |  2   | $3.80  | .. │  │
│  └──────────────────────────────────────────┘  │
│                                                │
│  Total Ventas: [lblTotalVentas: 0]            │
│  Monto Total:  [lblMontoTotal: $0.00]          │
│                                                │
│  [btnCerrar]                                   │
└────────────────────────────────────────────────┘
```

**Controles:**
- `DataGridView`: `dgvHistorial`
- `Label`: "Total Ventas:", "Monto Total:"
- `Label`: `lblTotalVentas`, `lblMontoTotal`
- `Button`: `btnCerrar` (Text: "Cerrar")

**Configurar DataGridView (dgvHistorial):**
- Agregar columnas:
  1. `colNumero`: "N° Venta"
  2. `colProducto`: "Producto"
  3. `colCantidad`: "Cantidad"
  4. `colPrecioUnit`: "P. Unitario"
  5. `colTotal`: "Total"
  6. `colFecha`: "Fecha"

### 💻 Paso 4.2: Programar FormHistorialVentas

```csharp
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

public partial class FormHistorialVentas : Form
{
    private List<Venta> listaVentas = new List<Venta>();
    private string archivoVentas = "ventas.txt";
    
    public FormHistorialVentas()
    {
        InitializeComponent();
        CargarVentas();
    }
    
    private void CargarVentas()
    {
        listaVentas.Clear();
        dgvHistorial.Rows.Clear();
        
        if (File.Exists(archivoVentas))
        {
            string[] lineas = File.ReadAllLines(archivoVentas);
            foreach (string linea in lineas)
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    Venta v = Venta.DesdeTexto(linea);
                    listaVentas.Add(v);
                }
            }
        }
        
        ActualizarGrid();
        CalcularTotales();
    }
    
    private void ActualizarGrid()
    {
        foreach (Venta v in listaVentas)
        {
            int index = dgvHistorial.Rows.Add();
            dgvHistorial.Rows[index].Cells["colNumero"].Value = v.NumeroVenta.ToString("D4");
            dgvHistorial.Rows[index].Cells["colProducto"].Value = v.NombreProducto;
            dgvHistorial.Rows[index].Cells["colCantidad"].Value = v.Cantidad;
            dgvHistorial.Rows[index].Cells["colPrecioUnit"].Value = v.PrecioUnitario.ToString("C");
            dgvHistorial.Rows[index].Cells["colTotal"].Value = v.Total.ToString("C");
            dgvHistorial.Rows[index].Cells["colFecha"].Value = v.Fecha.ToString("dd/MM/yyyy HH:mm");
        }
    }
    
    private void CalcularTotales()
    {
        decimal montoTotal = 0;
        
        foreach (Venta v in listaVentas)
        {
            montoTotal += v.Total;
        }
        
        lblTotalVentas.Text = listaVentas.Count.ToString();
        lblMontoTotal.Text = montoTotal.ToString("C");
    }
    
    private void btnCerrar_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
```

### 📐 Paso 4.3: Conectar desde FormPrincipal

**En FormPrincipal.cs, modificar:**

```csharp
private void btnHistorial_Click(object sender, EventArgs e)
{
    FormHistorialVentas formHistorial = new FormHistorialVentas();
    formHistorial.ShowDialog();
}
```

### ✅ Probar la Parte 4

1. Ejecutar el programa
2. Registrar varias ventas
3. Ir a "Ver Historial de Ventas"
4. ¿Se muestran todas las ventas?
5. ¿Se calcula el total de ventas?
6. ¿Se muestra el monto total?
7. ¿Las fechas se muestran correctamente?

### 🎓 Conceptos Aprendidos en Parte 4
- ✅ Leer datos relacionados entre clases
- ✅ Mostrar datos históricos
- ✅ Calcular totales y estadísticas
- ✅ Formatear fechas con ToString()
- ✅ Sumar valores de una lista

---

## 🎉 ¡SISTEMA COMPLETO!

### ✅ Lo que hemos logrado:

**Gestión de Productos:**
- ✅ CRUD completo con DataGridView
- ✅ Validación de duplicados
- ✅ Persistencia en archivo

**Navegación:**
- ✅ Menú principal
- ✅ Múltiples ventanas
- ✅ Navegación entre formularios

**Ventas:**
- ✅ Selección de productos con ComboBox
- ✅ Cálculo automático de totales
- ✅ Actualización de stock
- ✅ Generación de números consecutivos
- ✅ Relación entre Producto y Venta

**Reportes:**
- ✅ Historial completo de ventas
- ✅ Estadísticas (cantidad y monto)
- ✅ Formato de datos profesional

---

## 📚 Resumen de Conceptos del Módulo 2

### DataGridView:
```csharp
// Agregar fila
int index = dgv.Rows.Add();
dgv.Rows[index].Cells["nombreColumna"].Value = valor;

// Obtener fila seleccionada
if (dgv.SelectedRows.Count > 0)
{
    int indice = dgv.SelectedRows[0].Index;
}

// Limpiar
dgv.Rows.Clear();
```

### ComboBox:
```csharp
// Agregar items
cmbProducto.Items.Add("Item 1");

// Obtener seleccionado
int indice = cmbProducto.SelectedIndex;
string texto = cmbProducto.SelectedItem.ToString();
```

### Múltiples Forms:
```csharp
// Abrir ventana modal
FormVentas form = new FormVentas();
form.ShowDialog(); // Bloquea la ventana principal

// Abrir ventana no modal
form.Show(); // No bloquea
```

### Relaciones entre Clases:
```csharp
// Usar IDs para relacionar
public class Venta
{
    public int ProductoID { get; set; } // Relaciona con Producto
}

// Buscar objeto relacionado
Producto p = listaProductos.Find(x => x.Codigo == venta.ProductoID);
```

---

## 🎯 Checklist de Preparación

Antes de empezar tu proyecto, asegúrate de dominar:

### DataGridView:
- [ ] Configurar columnas
- [ ] Agregar filas programáticamente
- [ ] Seleccionar y obtener datos
- [ ] Limpiar el grid

### Múltiples Formularios:
- [ ] Crear nuevos Forms
- [ ] Abrir con ShowDialog()
- [ ] Pasar datos entre formularios
- [ ] Cambiar formulario de inicio

### Relaciones:
- [ ] Usar IDs para relacionar objetos
- [ ] ComboBox con datos de otra clase
- [ ] Actualizar objetos relacionados
- [ ] Guardar en múltiples archivos

### Validaciones:
- [ ] Campos obligatorios
- [ ] Validar números
- [ ] Verificar duplicados
- [ ] Validar stock/disponibilidad

### Persistencia:
- [ ] Guardar múltiples clases
- [ ] Cargar datos relacionados
- [ ] Mantener integridad entre archivos

---

## 📝 Preguntas de Repaso

1. ¿Cuál es la diferencia entre `ShowDialog()` y `Show()`?
2. ¿Cómo se relacionan dos clases usando IDs?
3. ¿Cómo se agrega una fila al DataGridView programáticamente?
4. ¿Qué propiedad del ComboBox indica el índice seleccionado?
5. ¿Cómo se valida que un producto tenga stock suficiente?
6. ¿Cómo se genera un número consecutivo automático?
7. ¿Cómo se formatea una fecha como "dd/MM/yyyy"?
8. ¿Cómo se cambia el formulario de inicio del programa?

---

## 🎓 Resumen del Módulo

Has completado el **Módulo 2** y ahora dominas:

✅ Trabajar con múltiples ventanas  
✅ Usar DataGridView profesionalmente  
✅ Relacionar clases entre sí  
✅ Crear sistemas de gestión completos  
✅ Implementar ComboBox para selección de datos  
✅ Generar números consecutivos automáticos  
✅ Calcular totales y estadísticas

---

**Continúa practicando** estos conceptos para consolidar tu aprendizaje.
