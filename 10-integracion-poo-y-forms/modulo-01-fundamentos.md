# 📘 Módulo 1: Fundamentos de Integración POO y Forms

## 🎯 Objetivos del Módulo

- Crear clases simples y trabajar con objetos
- Conectar clases con controles de Windows Forms
- Implementar operaciones básicas: Agregar, Mostrar, Limpiar
- Guardar y cargar datos desde archivos de texto
- Aprender de forma progresiva, paso a paso

## 📚 ¿Qué aprenderemos?

Este módulo trabajaremos con **UN SOLO PROYECTO** que iremos construyendo en **partes**. Cada parte agrega una nueva funcionalidad, ¡así aprendemos paso a paso!

```
PARTE 1: Crear la clase y el formulario básico
   ↓
PARTE 2: Agregar un objeto y mostrarlo en un Label
   ↓
PARTE 3: Usar un ListBox para mostrar varios objetos
   ↓
PARTE 4: Guardar en un archivo de texto
   ↓
PARTE 5: Cargar desde el archivo al iniciar
   ↓
PARTE 6: Modificar y Eliminar registros
```

---

## 🔷 Proyecto: Gestor de Contactos (Paso a Paso)

Vamos a crear una aplicación para guardar contactos. Empezaremos muy simple y cada parte agregará algo nuevo.

---

## 📍 PARTE 1: Crear la Clase y Formulario Básico

### 🎯 Objetivo

Entender cómo conectar una clase con un formulario.

### 📐 Paso 1.1: Crear el Proyecto

1. Abrir Visual Studio 2022
2. Crear nuevo proyecto → **Windows Forms App (.NET Framework)**
3. Nombre: `GestorContactos`
4. Presionar **Crear**

### 📐 Paso 1.2: Crear la Clase Contacto

**Clic derecho en el proyecto → Agregar → Clase → Nombre: `Contacto.cs`**

```csharp
public class Contacto
{
    // Propiedades
    public string Nombre { get; set; }
    public string Telefono { get; set; }
  
    // Constructor vacío
    public Contacto()
    {
    }
  
    // Constructor con parámetros
    public Contacto(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
    }
  
    // Método para mostrar información
    public string ObtenerInfo()
    {
        return $"Nombre: {Nombre}\nTeléfono: {Telefono}";
    }
}
```

### 🖼️ Paso 1.3: Diseñar el Formulario

**Abrir `Form1` en modo diseño y agregar estos controles:**

```
┌────────────────────────────────────┐
│  Gestor de Contactos               │
├────────────────────────────────────┤
│                                    │
│  Nombre:    [txtNombre         ]   │
│  Teléfono:  [txtTelefono       ]   │
│                                    │
│  [btnAgregar]  [btnLimpiar]        │
│                                    │
│  Información:                      │
│  ┌──────────────────────────────┐  │
│  │ lblInfo                      │  │
│  │ (vacío por ahora)            │  │
│  └──────────────────────────────┘  │
└────────────────────────────────────┘
```

**Controles a crear:**

- `Label`: "Nombre:"
- `TextBox`: `txtNombre`
- `Label`: "Teléfono:"
- `TextBox`: `txtTelefono`
- `Button`: `btnAgregar` → Text: "Agregar"
- `Button`: `btnLimpiar` → Text: "Limpiar"
- `Label`: "Información:"
- `Label`: `lblInfo` → AutoSize: False, Width: 300, Height: 60, BorderStyle: FixedSingle

### 💻 Paso 1.4: Programar el Botón "Agregar"

**Doble clic en el botón "Agregar" y escribe:**

```csharp
private void btnAgregar_Click(object sender, EventArgs e)
{
    // Crear un objeto Contacto con los datos del formulario
    Contacto nuevoContacto = new Contacto();
    nuevoContacto.Nombre = txtNombre.Text;
    nuevoContacto.Telefono = txtTelefono.Text;
  
    // Mostrar la información en el Label
    lblInfo.Text = nuevoContacto.ObtenerInfo();
}
```

### 💻 Paso 1.5: Programar el Botón "Limpiar"

**Doble clic en el botón "Limpiar" y escribe:**

```csharp
private void btnLimpiar_Click(object sender, EventArgs e)
{
    txtNombre.Clear();
    txtTelefono.Clear();
    lblInfo.Text = "";
}
```

### ✅ Probar la Parte 1

1. Presiona **F5** para ejecutar
2. Escribe un nombre y teléfono
3. Presiona "Agregar"
4. ¿Aparece la información en el Label?
5. Presiona "Limpiar"
6. ¿Se borró todo?

### 🎓 Conceptos Aprendidos en Parte 1

- ✅ Crear una clase con propiedades
- ✅ Crear objetos desde el formulario
- ✅ Asignar valores a las propiedades
- ✅ Llamar métodos de un objeto
- ✅ Mostrar información en un Label

### 🤔 Preguntas para Reflexionar

1. ¿Qué pasa si cierro el programa y lo vuelvo a abrir?
2. ¿Puedo agregar varios contactos?
3. ¿Dónde se está guardando el contacto?

**Respuesta:** ¡Por ahora NO se guarda nada! Solo existe mientras el programa está abierto.

---

## 📍 PARTE 2: Trabajar con Varios Contactos (Lista)

### 🎯 Objetivo

Guardar varios contactos en memoria usando una Lista.

### 🖼️ Paso 2.1: Agregar un ListBox al Formulario

**Modificar el diseño del formulario:**

```
┌────────────────────────────────────┐
│  Gestor de Contactos               │
├────────────────────────────────────┤
│                                    │
│  Nombre:    [txtNombre         ]   │
│  Teléfono:  [txtTelefono       ]   │
│                                    │
│  [btnAgregar]  [btnLimpiar]        │
│                                    │
│  Lista de Contactos:               │
│  ┌──────────────────────────────┐  │
│  │ lstContactos                 │  │
│  │                              │  │
│  │                              │  │
│  └──────────────────────────────┘  │
│                                    │
│  Información del Contacto:         │
│  ┌──────────────────────────────┐  │
│  │ lblInfo                      │  │
│  └──────────────────────────────┘  │
└────────────────────────────────────┘
```

**Agregar:**

- `Label`: "Lista de Contactos:"
- `ListBox`: `lstContactos` → Width: 300, Height: 100

### 💻 Paso 2.2: Declarar la Lista al Inicio de la Clase Form1

**En `Form1.cs`, ARRIBA de todos los métodos, escribe:**

```csharp
public partial class Form1 : Form
{
    // Lista para guardar todos los contactos en memoria
    private List<Contacto> listaContactos = new List<Contacto>();
  
    public Form1()
    {
        InitializeComponent();
    }
  
    // ... resto del código
}
```

### 💻 Paso 2.3: Crear un Método para Actualizar el ListBox

**Escribe este método en Form1:**

```csharp
private void ActualizarLista()
{
    // Limpiar el ListBox
    lstContactos.Items.Clear();
  
    // Agregar cada contacto al ListBox
    foreach (Contacto c in listaContactos)
    {
        lstContactos.Items.Add($"{c.Nombre} - {c.Telefono}");
    }
}
```

### 💻 Paso 2.4: Modificar el Botón "Agregar"

**Reemplaza el código del botón Agregar:**

```csharp
private void btnAgregar_Click(object sender, EventArgs e)
{
    // Validar que no estén vacíos
    if (string.IsNullOrWhiteSpace(txtNombre.Text))
    {
        MessageBox.Show("Ingrese un nombre", "Error", 
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }
  
    if (string.IsNullOrWhiteSpace(txtTelefono.Text))
    {
        MessageBox.Show("Ingrese un teléfono", "Error", 
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }
  
    // Crear el objeto
    Contacto nuevoContacto = new Contacto(txtNombre.Text, txtTelefono.Text);
  
    // Agregar a la lista
    listaContactos.Add(nuevoContacto);
  
    // Actualizar el ListBox
    ActualizarLista();
  
    // Limpiar campos
    txtNombre.Clear();
    txtTelefono.Clear();
    txtNombre.Focus();
}
```

### 💻 Paso 2.5: Programar Evento al Seleccionar del ListBox

**Doble clic en el `lstContactos` y escribe:**

```csharp
private void lstContactos_SelectedIndexChanged(object sender, EventArgs e)
{
    // Verificar que hay algo seleccionado
    if (lstContactos.SelectedIndex >= 0)
    {
        // Obtener el contacto seleccionado
        int indice = lstContactos.SelectedIndex;
        Contacto contactoSeleccionado = listaContactos[indice];
    
        // Mostrar información
        lblInfo.Text = contactoSeleccionado.ObtenerInfo();
    }
}
```

### ✅ Probar la Parte 2

1. Ejecutar el programa (F5)
2. Agregar varios contactos
3. ¿Aparecen en el ListBox?
4. Hacer clic en un contacto del ListBox
5. ¿Se muestra su información abajo?

### 🎓 Conceptos Aprendidos en Parte 2

- ✅ Usar `List<T>` para almacenar varios objetos
- ✅ Agregar elementos a una lista con `Add()`
- ✅ Recorrer una lista con `foreach`
- ✅ Mostrar lista de objetos en un ListBox
- ✅ Obtener el índice seleccionado con `SelectedIndex`
- ✅ Validar datos con `string.IsNullOrWhiteSpace()`
- ✅ Mostrar mensajes con `MessageBox.Show()`

### 🤔 Preguntas para Reflexionar

1. ¿Qué pasa si cierro el programa ahora?
2. ¿Los contactos siguen ahí cuando lo vuelvo a abrir?

**Respuesta:** NO, porque solo están en la memoria RAM. Necesitamos guardarlos en un archivo.

---

## 📍 PARTE 3: Guardar Contactos en un Archivo

### 🎯 Objetivo

Aprender a escribir datos en un archivo de texto.

### 📚 Paso 3.1: Agregar Métodos a la Clase Contacto

**En `Contacto.cs`, agregar estos métodos:**

```csharp
// Convertir el objeto a una línea de texto
public string ATexto()
{
    return $"{Nombre}|{Telefono}";
}

// Crear un objeto desde una línea de texto
public static Contacto DesdeTexto(string linea)
{
    string[] partes = linea.Split('|');
    return new Contacto(partes[0], partes[1]);
}
```

**¿Qué hacen estos métodos?**

- `ATexto()`: Convierte el contacto a: "Juan|555-1234"
- `DesdeTexto()`: Toma "Juan|555-1234" y crea un objeto Contacto
- El símbolo `|` (pipe) separa los datos

### 💻 Paso 3.2: Agregar using System.IO

**En `Form1.cs`, ARRIBA de todo, agregar:**

```csharp
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;  // ← AGREGAR ESTA LÍNEA
```

### 💻 Paso 3.3: Declarar la Ruta del Archivo

**En Form1, después de la declaración de la lista:**

```csharp
public partial class Form1 : Form
{
    private List<Contacto> listaContactos = new List<Contacto>();
    private string archivoContactos = "contactos.txt";  // ← AGREGAR
  
    // ... resto del código
}
```

### 💻 Paso 3.4: Crear Método para Guardar

**En Form1, agregar este método:**

```csharp
private void GuardarContactos()
{
    // Crear una lista de líneas de texto
    List<string> lineas = new List<string>();
  
    // Convertir cada contacto a texto
    foreach (Contacto c in listaContactos)
    {
        lineas.Add(c.ATexto());
    }
  
    // Escribir todas las líneas en el archivo
    File.WriteAllLines(archivoContactos, lineas);
  
    MessageBox.Show("Contactos guardados correctamente", "Éxito",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
}
```

### 🖼️ Paso 3.5: Agregar Botón "Guardar"

**En el diseñador, agregar:**

- `Button`: `btnGuardar` → Text: "Guardar"

**Doble clic en el botón y escribir:**

```csharp
private void btnGuardar_Click(object sender, EventArgs e)
{
    GuardarContactos();
}
```

### ✅ Probar la Parte 3

1. Ejecutar el programa
2. Agregar 2 o 3 contactos
3. Presionar "Guardar"
4. ¿Aparece el mensaje de éxito?
5. Cerrar el programa
6. Ir a la carpeta del proyecto → bin → Debug
7. ¿Existe el archivo `contactos.txt`?
8. Abrirlo con Notepad
9. ¿Están los contactos guardados?

### 🎓 Conceptos Aprendidos en Parte 3

- ✅ Usar `System.IO` para trabajar con archivos
- ✅ Convertir objetos a texto (serialización simple)
- ✅ Usar `File.WriteAllLines()` para escribir archivos
- ✅ Separar campos con un delimitador (|)

### 🤔 Pregunta para Reflexionar

Si cierro el programa y lo vuelvo a abrir, ¿puedo ver los contactos que guardé?

**Respuesta:** NO todavía, porque no los estamos CARGANDO al iniciar.

---

## 📍 PARTE 4: Cargar Contactos al Iniciar

### 🎯 Objetivo

Leer el archivo cuando abrimos el programa.

### 💻 Paso 4.1: Crear Método para Cargar

**En Form1, agregar:**

```csharp
private void CargarContactos()
{
    // Limpiar la lista actual
    listaContactos.Clear();
  
    // Verificar si existe el archivo
    if (File.Exists(archivoContactos))
    {
        // Leer todas las líneas del archivo
        string[] lineas = File.ReadAllLines(archivoContactos);
    
        // Convertir cada línea en un objeto Contacto
        foreach (string linea in lineas)
        {
            if (!string.IsNullOrWhiteSpace(linea))
            {
                Contacto c = Contacto.DesdeTexto(linea);
                listaContactos.Add(c);
            }
        }
    }
  
    // Actualizar el ListBox
    ActualizarLista();
}
```

### 💻 Paso 4.2: Llamar al Método al Iniciar el Form

**Modificar el constructor de Form1:**

```csharp
public Form1()
{
    InitializeComponent();
    CargarContactos();  // ← AGREGAR ESTA LÍNEA
}
```

### 💻 Paso 4.3: Guardar Automáticamente al Agregar

**Modificar el método btnAgregar_Click al final:**

```csharp
private void btnAgregar_Click(object sender, EventArgs e)
{
    // ... código de validación ...
  
    // Crear el objeto
    Contacto nuevoContacto = new Contacto(txtNombre.Text, txtTelefono.Text);
  
    // Agregar a la lista
    listaContactos.Add(nuevoContacto);
  
    // Guardar automáticamente (SIN mostrar mensaje)
    List<string> lineas = new List<string>();
    foreach (Contacto c in listaContactos)
    {
        lineas.Add(c.ATexto());
    }
    File.WriteAllLines(archivoContactos, lineas);
  
    // Actualizar el ListBox
    ActualizarLista();
  
    // Limpiar campos
    txtNombre.Clear();
    txtTelefono.Clear();
    txtNombre.Focus();
}
```

**Nota:** Ahora el botón "Guardar" puede ser opcional, o lo dejamos para guardar manualmente.

### ✅ Probar la Parte 4

1. Ejecutar el programa
2. Si hay contactos del archivo, ¿se cargan automáticamente?
3. Agregar un nuevo contacto
4. Cerrar el programa
5. Volver a abrirlo
6. ¿Sigue estando el contacto nuevo?

### 🎓 Conceptos Aprendidos en Parte 4

- ✅ Usar `File.Exists()` para verificar si existe un archivo
- ✅ Leer archivos con `File.ReadAllLines()`
- ✅ Convertir texto a objetos (deserialización simple)
- ✅ Cargar datos al iniciar el programa
- ✅ Guardar automáticamente después de agregar

### 🎉 ¡Éxito!

Ahora tenemos un programa que:

- Guarda contactos
- Los carga automáticamente
- Persiste la información entre sesiones

---

## 📍 PARTE 5: Eliminar Contactos

### 🎯 Objetivo

Permitir borrar un contacto seleccionado.

### 🖼️ Paso 5.1: Agregar Botón Eliminar

**En el diseñador:**

- `Button`: `btnEliminar` → Text: "Eliminar"

### 💻 Paso 5.2: Programar el Botón Eliminar

**Doble clic en btnEliminar:**

```csharp
private void btnEliminar_Click(object sender, EventArgs e)
{
    // Verificar que hay algo seleccionado
    if (lstContactos.SelectedIndex < 0)
    {
        MessageBox.Show("Seleccione un contacto para eliminar", "Aviso",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
    }
  
    // Confirmar eliminación
    DialogResult resultado = MessageBox.Show(
        "¿Está seguro de eliminar este contacto?",
        "Confirmar",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);
  
    if (resultado == DialogResult.Yes)
    {
        // Obtener el índice
        int indice = lstContactos.SelectedIndex;
    
        // Eliminar de la lista
        listaContactos.RemoveAt(indice);
    
        // Guardar cambios
        List<string> lineas = new List<string>();
        foreach (Contacto c in listaContactos)
        {
            lineas.Add(c.ATexto());
        }
        File.WriteAllLines(archivoContactos, lineas);
    
        // Actualizar ListBox
        ActualizarLista();
    
        // Limpiar información
        lblInfo.Text = "";
    }
}
```

### ✅ Probar la Parte 5

1. Ejecutar el programa
2. Seleccionar un contacto
3. Presionar "Eliminar"
4. ¿Aparece confirmación?
5. Confirmar
6. ¿Se eliminó del ListBox?
7. Cerrar y volver a abrir
8. ¿Sigue eliminado?

### 🎓 Conceptos Aprendidos en Parte 5

- ✅ Eliminar elementos con `RemoveAt(indice)`
- ✅ Confirmar acciones con `MessageBox` y `DialogResult`
- ✅ Verificar selección antes de operar

---

## 📍 PARTE 6: Modificar Contactos

### 🎯 Objetivo

Editar un contacto existente.

### 💻 Paso 6.1: Variable para Controlar el Modo de Edición

**En Form1, agregar variable:**

```csharp
public partial class Form1 : Form
{
    private List<Contacto> listaContactos = new List<Contacto>();
    private string archivoContactos = "contactos.txt";
    private int indiceEditando = -1;  // ← AGREGAR (-1 = no estamos editando)
  
    // ... resto del código
}
```

### 🖼️ Paso 6.2: Agregar Botón Modificar

**En el diseñador:**

- `Button`: `btnModificar` → Text: "Modificar"

### 💻 Paso 6.3: Programar Botón Modificar (Cargar Datos)

**Doble clic en btnModificar:**

```csharp
private void btnModificar_Click(object sender, EventArgs e)
{
    // Verificar que hay algo seleccionado
    if (lstContactos.SelectedIndex < 0)
    {
        MessageBox.Show("Seleccione un contacto para modificar", "Aviso",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
    }
  
    // Guardar el índice que estamos editando
    indiceEditando = lstContactos.SelectedIndex;
  
    // Obtener el contacto
    Contacto c = listaContactos[indiceEditando];
  
    // Cargar datos en los TextBox
    txtNombre.Text = c.Nombre;
    txtTelefono.Text = c.Telefono;
  
    // Cambiar el texto del botón Agregar
    btnAgregar.Text = "Guardar Cambios";
  
    // Enfocar el primer campo
    txtNombre.Focus();
}
```

### 💻 Paso 6.4: Modificar el Botón Agregar para Soportar Edición

**Reemplazar el código completo de btnAgregar_Click:**

```csharp
private void btnAgregar_Click(object sender, EventArgs e)
{
    // Validaciones
    if (string.IsNullOrWhiteSpace(txtNombre.Text))
    {
        MessageBox.Show("Ingrese un nombre", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }
  
    if (string.IsNullOrWhiteSpace(txtTelefono.Text))
    {
        MessageBox.Show("Ingrese un teléfono", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }
  
    // Verificar si estamos editando o agregando
    if (indiceEditando >= 0)
    {
        // MODO EDICIÓN: Modificar el contacto existente
        listaContactos[indiceEditando].Nombre = txtNombre.Text;
        listaContactos[indiceEditando].Telefono = txtTelefono.Text;
    
        // Resetear índice
        indiceEditando = -1;
    
        // Cambiar texto del botón
        btnAgregar.Text = "Agregar";
    }
    else
    {
        // MODO AGREGAR: Crear nuevo contacto
        Contacto nuevoContacto = new Contacto(txtNombre.Text, txtTelefono.Text);
        listaContactos.Add(nuevoContacto);
    }
  
    // Guardar cambios en archivo
    List<string> lineas = new List<string>();
    foreach (Contacto c in listaContactos)
    {
        lineas.Add(c.ATexto());
    }
    File.WriteAllLines(archivoContactos, lineas);
  
    // Actualizar ListBox
    ActualizarLista();
  
    // Limpiar campos
    txtNombre.Clear();
    txtTelefono.Clear();
    lblInfo.Text = "";
    txtNombre.Focus();
}
```

### 💻 Paso 6.5: Actualizar Botón Limpiar

**Modificar btnLimpiar_Click:**

```csharp
private void btnLimpiar_Click(object sender, EventArgs e)
{
    txtNombre.Clear();
    txtTelefono.Clear();
    lblInfo.Text = "";
  
    // Cancelar modo edición si está activo
    if (indiceEditando >= 0)
    {
        indiceEditando = -1;
        btnAgregar.Text = "Agregar";
    }
  
    txtNombre.Focus();
}
```

### ✅ Probar la Parte 6

1. Ejecutar el programa
2. Seleccionar un contacto
3. Presionar "Modificar"
4. ¿Se cargan los datos en los TextBox?
5. ¿El botón dice "Guardar Cambios"?
6. Modificar los datos
7. Presionar "Guardar Cambios"
8. ¿Se actualizó en el ListBox?
9. Cerrar y reabrir
10. ¿Los cambios persisten?

### 🎓 Conceptos Aprendidos en Parte 6

- ✅ Usar una variable de control para el modo de edición
- ✅ Reutilizar el mismo botón para agregar y modificar
- ✅ Modificar objetos en una lista por índice
- ✅ Cambiar el texto de botones dinámicamente

---

## 🎉 ¡PROYECTO COMPLETO!

### ✅ Lo que hemos logrado:

- ✅ Crear una clase Contacto
- ✅ Agregar contactos desde un formulario
- ✅ Mostrar lista de contactos
- ✅ Guardar en archivo de texto
- ✅ Cargar desde archivo al iniciar
- ✅ Eliminar contactos con confirmación
- ✅ Modificar contactos existentes
- ✅ Validaciones de datos
- ✅ Persistencia de datos entre sesiones

### 📂 Estructura Final del Proyecto:

```
GestorContactos/
├── Contacto.cs          (Clase)
├── Form1.cs             (Lógica)
├── Form1.Designer.cs    (Diseño)
└── bin/Debug/
    └── contactos.txt    (Datos)
```

---

## 💪 Ejercicios de Práctica

Ahora que completaste el proyecto guiado, ¡es hora de practicar por tu cuenta!

### 🔷 Ejercicio Individual 1: Agregar Email

**Modificar el proyecto existente para agregar un campo Email:**

1. Agregar propiedad `Email` a la clase `Contacto`
2. Agregar `TextBox` en el formulario: `txtEmail`
3. Modificar método `ObtenerInfo()` para incluir el email
4. Modificar `ATexto()`: `Nombre|Telefono|Email`
5. Modificar `DesdeTexto()` para leer 3 campos
6. Actualizar el ListBox para mostrar: "Nombre - Teléfono - Email"

**Nota:** Tendrás que borrar el archivo `contactos.txt` existente o convertir los datos viejos.

### 🔷 Ejercicio Individual 2: Gestor de Productos

**Crear un nuevo proyecto similar pero para productos:**

**Clase Producto:**

- Código (string)
- Nombre (string)
- Precio (decimal)

**Funcionalidades:**

- Agregar productos
- Guardar en `productos.txt`
- Cargar al iniciar
- Modificar productos
- Eliminar productos
- Mostrar información: "Código: XX, Nombre: YY, Precio: $ZZ"

**Pista:** Usa `decimal.Parse()` para convertir el precio desde texto.

### 🔷 Ejercicio Individual 3: Agregar Búsqueda

**Modificar GestorContactos para agregar búsqueda:**

1. Agregar `TextBox txtBuscar` y `Button btnBuscar`
2. Crear método `BuscarContacto(string nombre)`
3. El método debe buscar contactos que contengan el texto (usar `.Contains()`)
4. Mostrar resultados en el ListBox (solo los que coincidan)
5. Agregar botón "Mostrar Todos" para volver a ver todos

### 🔷 Ejercicio Individual 4: Validar Duplicados

**Mejorar GestorContactos para evitar duplicados:**

1. Crear método `ExisteContacto(string nombre)` que retorne `bool`
2. Antes de agregar un contacto, verificar si ya existe
3. Si existe, mostrar mensaje: "Este contacto ya existe"
4. No permitir agregar duplicados

### 🔷 Ejercicio Individual 5: Contador de Contactos

**Agregar estadísticas al formulario:**

1. Agregar `Label lblTotal` → Text: "Total: 0"
2. Crear método `ActualizarContador()`
3. Mostrar cantidad de contactos: `lblTotal.Text = $"Total: {listaContactos.Count}";`
4. Llamar este método después de agregar, modificar o eliminar

---

## 📚 Conceptos de System.IO Aprendidos

### Métodos Usados:

```csharp
// Verificar si existe un archivo
if (File.Exists("archivo.txt"))

// Leer todas las líneas
string[] lineas = File.ReadAllLines("archivo.txt");

// Escribir todas las líneas
File.WriteAllLines("archivo.txt", lineas);

// Separar una cadena
string[] partes = "Juan|555-1234".Split('|');
// partes[0] = "Juan"
// partes[1] = "555-1234"
```

### Conversiones de Tipos:

```csharp
// String a entero
int numero = int.Parse("123");

// String a decimal
decimal precio = decimal.Parse("99.99");

// String a bool
bool valor = bool.Parse("true");

// A string (cualquier tipo)
string texto = numero.ToString();
```

---

## 🎯 Autoevaluación

Marca las habilidades que ya dominas:

### Clase y Objetos:

- [ ] Crear una clase con propiedades
- [ ] Crear constructores (vacío y con parámetros)
- [ ] Crear métodos en una clase
- [ ] Instanciar objetos
- [ ] Asignar valores a propiedades
- [ ] Llamar métodos de objetos

### Listas:

- [ ] Declarar una `List<T>`
- [ ] Agregar elementos con `Add()`
- [ ] Eliminar elementos con `RemoveAt()`
- [ ] Recorrer con `foreach`
- [ ] Acceder por índice `lista[i]`
- [ ] Obtener cantidad con `.Count`

### Windows Forms:

- [ ] Crear controles (TextBox, Button, Label, ListBox)
- [ ] Programar eventos (Click, SelectedIndexChanged)
- [ ] Obtener texto de TextBox
- [ ] Limpiar TextBox con `.Clear()`
- [ ] Agregar elementos a ListBox
- [ ] Obtener índice seleccionado
- [ ] Mostrar MessageBox
- [ ] Validar campos vacíos

### Archivos:

- [ ] Usar `using System.IO`
- [ ] Verificar existencia con `File.Exists()`
- [ ] Leer archivo con `File.ReadAllLines()`
- [ ] Escribir archivo con `File.WriteAllLines()`
- [ ] Convertir objeto a texto
- [ ] Convertir texto a objeto
- [ ] Usar `Split()` para separar campos

### Lógica de Aplicación:

- [ ] Validar datos de entrada
- [ ] Implementar modo agregar/modificar
- [ ] Confirmar antes de eliminar
- [ ] Persistir datos entre sesiones
- [ ] Sincronizar lista y archivo

---

## 📝 Preguntas de Repaso

1. **¿Qué pasa si no uso `File.Exists()` y el archivo no existe?**

- El programa lanzará una excepción al intentar leer un archivo inexistente, lo que puede causar que la aplicación falle.

2. **¿Por qué usamos el símbolo `|` en lugar de coma?**

- El símbolo `|` es menos común en datos y reduce la probabilidad de conflictos con los valores reales, como nombres o direcciones que pueden contener comas, en el día a día el delimitador puede ser cualquiera que no se espere en los datos.

3. **¿Qué significa `SelectedIndex = -1`?**

- Significa que no hay ningún elemento seleccionado en el ListBox o control similar.

4. **¿Cuál es la diferencia entre `Clear()` y `Items.Clear()`?**

- `Clear()` se usa para limpiar el contenido de un TextBox, mientras que `Items.Clear()` se usa para eliminar todos los elementos de un ListBox.

5. **¿Por qué necesitamos el método `ATexto()` y `DesdeTexto()`?**

- Estos métodos permiten convertir objetos a una representación de texto para guardarlos en archivos y viceversa, facilitando la persistencia de datos.

6. **¿Qué hace `string.IsNullOrWhiteSpace()`?**

- Verifica si una cadena es nula, vacía o contiene solo espacios en blanco, ayudando a validar entradas de usuario.

7. **¿Cuándo se ejecuta el constructor del Form?**

- El constructor del Form se ejecuta cuando se crea una instancia del formulario, generalmente al iniciar la aplicación o al abrir el formulario.

8. **¿Para qué sirve la variable `indiceEditando`?**

- Sirve para controlar si estamos en modo edición y para saber qué contacto se está modificando en la lista.

---

## 🚀 Próximos Pasos

### Cuando domines todo esto:

1. **Módulo 2**: Trabajar con múltiples clases relacionadas
2. **Más adelante**: Usar bases de datos en lugar de archivos
3. **Más adelante**: Crear sistemas más complejos (POS, inventarios, etc.)

---

## 💡 Consejos y Buenas Prácticas

### ✅ Buenas Prácticas:

- Siempre validar antes de guardar
- Confirmar antes de eliminar
- Usar nombres descriptivos para variables
- Comentar el código complejo
- Probar después de cada cambio

### ❌ Errores Comunes:

- Olvidar guardar después de modificar
- No verificar si existe selección antes de usar `SelectedIndex`
- No verificar si el archivo existe antes de leer
- Olvidar agregar `using System.IO`
- No actualizar el ListBox después de cambios

### 🎓 Cómo Aprender Mejor:

1. Escribe el código tú mismo (no copies y pegues)
2. Experimenta: cambia cosas y ve qué pasa
3. Lee los mensajes de error con calma
4. Practica los ejercicios individuales
5. Intenta explicarle a alguien más lo que aprendiste

---

## 📖 Glosario

**Clase**: Plantilla para crear objetos, tambien la podemos llamar Entidad o Modelo.
**Objeto**: Elemento creado a partir de una clase.
**Propiedad o Atributo**: Variable dentro de una clase.
**Función oMétodo**: Bloque de código que realiza una tarea que podemos reutilizar. En C# estas pueden retornar valores (string, int, bool, etc.) o no (void).
**Persistencia**: Guardar datos para que sobrevivan al cierre del programa.
**CRUD**: Create, Read, Update, Delete (operaciones básicas)
**Delimitador**: Carácter usado para separar campos (ej: |).
**Arreglo o Lista (Array)**: Conjunto de elementos del mismo tipo de dato almacenados en posiciones consecutivas de memoria. Ejemplo: int[] notas = new int[5];
**Polimorfismo**: Permite que un mismo método tenga diferentes comportamientos según el objeto que lo llame.

---

## 🎉 ¡Felicitaciones!

Si llegaste hasta aquí y completaste todas las partes, ¡ahora puedes:

✅ Crear aplicaciones con persistencia de datos
✅ Trabajar con clases y objetos
✅ Manejar archivos de texto
✅ Crear interfaces funcionales
✅ Implementar CRUD completo
✅ Validar y confirmar operaciones

**¡Estás listo para proyectos más complejos!**

---

**Recuerda:** La programación se aprende PRACTICANDO. No te desanimes si algo no funciona la primera vez. ¡Sigue intentando!
