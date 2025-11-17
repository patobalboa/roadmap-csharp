# Proyecto Final: Sistema de Gestión con Windows Forms

## Información General

**Modalidad:** Trabajo en Grupo (3 a 4 integrantes)
**Plazo de Entrega:** 1 semana
**Presentación:** Exposición grupal explicando el proyecto

---

## Objetivo del Proyecto

Crear un **Sistema de Gestión completo** usando Windows Forms que integre todos los conceptos aprendidos en los módulos 1 y 2:

- Programación Orientada a Objetos (POO)
- Persistencia de datos en archivos TXT
- Múltiples formularios
- DataGridView
- CRUD completo (Crear, Leer, Actualizar, Eliminar)

---

## Temas Sugeridos para el Sistema

Elige **UNO** de los siguientes temas para tu proyecto:

### 1. Sistema de Biblioteca

- **Clases:** Libro, Préstamo, Usuario
- **Funcionalidades:** Gestionar libros, registrar préstamos, control de usuarios
- **Extras:** Libros disponibles/prestados, historial de préstamos

### 2. Sistema de Inventario

- **Clases:** Producto, Movimiento, Categoría
- **Funcionalidades:** Gestionar productos, registrar entradas/salidas, categorías
- **Extras:** Stock mínimo, alertas, productos por categoría

### 3. Sistema de Estudiantes

- **Clases:** Estudiante, Curso, Nota
- **Funcionalidades:** Gestionar estudiantes, registrar cursos, control de notas
- **Extras:** Promedio por estudiante, estadísticas por curso

### 4. Tema Libre

Puedes proponer tu propio tema (debe ser aprobado).

---

## Requisitos Mínimos del Proyecto

### Clases (Mínimo 3 clases)

Cada clase debe tener:

- Propiedades públicas con { get; set; }
- Constructor que inicialice las propiedades
- Método `ATexto()` para guardar en archivo
- Método `DesdeTexto()` para leer desde archivo

**Ejemplo:**

```csharp
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }

    public Producto(int id, string nombre, decimal precio, int stock)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }

    public string ATexto()
    {
        return $"{Id}|{Nombre}|{Precio}|{Stock}";
    }

    public static Producto DesdeTexto(string linea)
    {
        string[] datos = linea.Split('|');
        return new Producto(
            int.Parse(datos[0]),
            datos[1],
            decimal.Parse(datos[2]),
            int.Parse(datos[3])
        );
    }
}
```

---

### Formularios (Mínimo 4 formularios)

1. **FormPrincipal (Menú Principal)**

   - Botones para acceder a los otros formularios
   - Título del sistema
   - Botón para cerrar la aplicación
2. **Form de Gestión 1** (Ej: FormProductos)

   - CRUD completo para la primera clase
   - Usar **DataGridView** para mostrar datos
   - Botones: Agregar, Modificar, Eliminar
   - Guardar datos en archivo TXT
3. **Form de Gestión 2** (Ej: FormVentas)

   - CRUD completo para la segunda clase
   - Usar **DataGridView** o **ListBox**
   - Relacionar con la clase anterior (Ej: seleccionar producto para venta)
   - Usar **ComboBox** si es necesario
   - Guardar datos en archivo TXT
4. **Form de Reportes/Consultas**

   - Mostrar información procesada
   - Estadísticas o cálculos
   - Filtros o búsquedas
   - DataGridView con datos calculados

---

### Persistencia de Datos

- Todos los datos deben guardarse en **archivos TXT**
- Usar el delimitador `|` (pipe) para separar campos
- Un archivo por clase (Ej: `productos.txt`, `ventas.txt`)
- Cargar datos al abrir el formulario
- Guardar datos después de cada operación

**Ejemplo de archivo `productos.txt`:**

```
1|Laptop HP|599990|5
2|Mouse Logitech|15990|20
3|Teclado Mecánico|45990|10
```

---

### Funcionalidades Obligatorias

1. **IDs Consecutivos Automáticos**

   ```csharp
   private int GenerarNuevoId()
   {
       if (listaProductos.Count == 0)
           return 1;
       return listaProductos.Max(p => p.Id) + 1;
   }
   ```
2. **CRUD Completo en al menos 2 entidades**

   - Crear (Agregar)
   - Leer (Mostrar en DataGridView)
   - Actualizar (Modificar)
   - Eliminar
3. **Validaciones Básicas**

   - Campos no vacíos
   - Números válidos
   - Mensajes de error claros
4. **Relación entre Clases**

   - Al menos una clase debe relacionarse con otra
   - Ejemplo: Venta tiene una lista de Productos

---

## Funcionalidades Opcionales (Puntos Extra)

Si quieres obtener mejor calificación, puedes agregar:

- Búsqueda/Filtrado de datos
- Ordenamiento por columnas en DataGridView
- Alertas de stock bajo (inventario)
- Cálculo de totales y subtotales
- Interfaz visual atractiva y profesional
- Más de 4 formularios
- Exportar reportes a TXT

---

## Organización del Equipo

### Distribución de Tareas Sugerida:

**Integrante 1:**

- Crear las clases principales
- Implementar métodos `ATexto()` y `DesdeTexto()`
- Validar que la persistencia funcione

**Integrante 2:**

- Diseñar FormPrincipal
- Crear Form de Gestión 1 con DataGridView
- Implementar CRUD completo

**Integrante 3:**

- Crear Form de Gestión 2
- Implementar relaciones entre clases
- Usar ComboBox para selecciones

**Integrante 4 (opcional):**

- Crear Form de Reportes
- Implementar cálculos y estadísticas
- Mejorar interfaz visual

---

## Entregables

### 1. Carpeta del Proyecto

Comprimir en **ZIP** con el nombre: `Apellido1_Apellido2_Apellido3_ProyectoFinal.zip`

**Contenido:**

- Carpeta completa del proyecto Visual Studio
- Archivos TXT de prueba con datos
- Archivo `README.txt` con:
  - Nombres de los integrantes
  - Tema elegido
  - Breve descripción del sistema
  - Instrucciones para ejecutar

### 2. Exposición (10-15 minutos)

- Explicar el tema elegido
- Mostrar las clases creadas
- Demostración en vivo del sistema funcionando
- Explicar las funcionalidades implementadas
- Mostrar el código de una función importante
- Responder preguntas del profesor

---

## Evaluación

### Pauta de Evaluación del Trabajo (70%)

| Criterio                         | Puntaje           | Descripción                                                                           |
| -------------------------------- | ----------------- | -------------------------------------------------------------------------------------- |
| **Clases (POO)**           | 15 pts            | Mínimo 3 clases bien diseñadas con propiedades, constructor, ATexto() y DesdeTexto() |
| **Formularios**            | 15 pts            | Mínimo 4 formularios funcionando correctamente                                        |
| **CRUD Completo**          | 15 pts            | Crear, Leer, Actualizar, Eliminar en al menos 2 entidades                              |
| **Persistencia en TXT**    | 10 pts            | Guardar y cargar datos correctamente desde archivos                                    |
| **DataGridView**           | 10 pts            | Uso correcto de DataGridView para mostrar datos                                        |
| **Relación entre Clases** | 10 pts            | Al menos una relación funcional entre clases                                          |
| **Validaciones**           | 8 pts             | Validaciones básicas y mensajes de error                                              |
| **IDs Consecutivos**       | 5 pts             | Generación automática de IDs                                                         |
| **Funcionalidad General**  | 8 pts             | El sistema funciona sin errores críticos                                              |
| **Extras/Creatividad**     | 4 pts             | Funcionalidades adicionales o interfaz destacada                                       |
| **TOTAL TRABAJO**          | **100 pts** |                                                                                        |

---

### Rúbrica de Evaluación de la Exposición (30%)

| Criterio                           | Excelente (4 pts)                                  | Bueno (3 pts)                                              | Regular (2 pts)                                  | Insuficiente (1 pt)                      |
| ---------------------------------- | -------------------------------------------------- | ---------------------------------------------------------- | ------------------------------------------------ | ---------------------------------------- |
| **Dominio del Tema**         | Explica con seguridad y claridad todo el proyecto  | Explica la mayoría del proyecto con claridad              | Explica parcialmente, con algunas dudas          | No domina el tema o no puede explicar    |
| **Demostración**            | Muestra todas las funcionalidades sin errores      | Muestra la mayoría de funcionalidades, algún error menor | Muestra funcionalidades básicas, varios errores | No puede demostrar o sistema no funciona |
| **Explicación del Código** | Explica claramente la lógica del código mostrado | Explica el código con alguna dificultad                   | Explica superficialmente el código              | No puede explicar el código             |
| **Participación Grupal**    | Todos participan equitativamente                   | La mayoría participa, uno menos activo                    | Participación desigual del grupo                | Solo uno o dos exponen                   |
| **Tiempo y Organización**   | Exposición bien organizada y dentro del tiempo    | Buena organización, se excede o falta poco tiempo         | Desorganizada o mal manejo del tiempo            | Muy desorganizada o tiempo inadecuado    |
| **Respuesta a Preguntas**    | Responde correctamente todas las preguntas         | Responde la mayoría de preguntas                          | Responde pocas preguntas o con dificultad        | No puede responder preguntas             |

**TOTAL EXPOSICIÓN:** 24 puntos = 100%


---

## Advertencias Importantes

**Copia:** Si se detecta que copiaron código de otro grupo, **ambos grupos tendrán nota 1.0**

**No Funciona:** Si el sistema no se ejecuta o tiene errores críticos que impiden su uso, la nota máxima será 4.0

**Falta a la Exposición:** Si algún integrante falta sin justificación, ese integrante obtiene 1.0 en la exposición.

**Trabajo en Equipo:** Todos deben conocer y entender todo el código del proyecto

**Código Limpio:** Se valorará el uso de nombres claros, comentarios y buena organización del código

**Plagio:** No usar código de fuentes externas sin citar; se considerará plagio.

**Codificación:** El código debe ser mayoritariamente lo explicado en clase; uso excesivo de librerías externas o funciones avanzadas no vistas en clase puede afectar la evaluación.

---



## ¡Manos a la Obra!

Este proyecto es tu oportunidad para demostrar todo lo que has aprendido.

**¡Éxito en tu proyecto final!**

---
