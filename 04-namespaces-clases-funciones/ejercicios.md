# 🧪 Ejercicios: Namespaces, Clases y Funciones

## 📋 Instrucciones Generales

1. **Estructura de proyectos**: Cada ejercicio debe estar en su propio namespace
2. **Nomenclatura**: Usa PascalCase para clases y métodos, camelCase para variables locales
3. **Documentación**: Agrega comentarios XML a tus métodos públicos
4. **Validación**: Incluye validación de entrada donde sea apropiado
5. **Organización**: Separa la lógica de negocio de la presentación

---

## 🔰 Ejercicios Básicos

### **Ejercicio 1: Mi Primera Clase**
**Dificultad:** ⭐
**Tiempo estimado:** 15 minutos

Crea una clase `Persona` dentro del namespace `MiPrimerProyecto.Personas` que contenga:

**Propiedades:**
- `Nombre` (string)
- `Edad` (int)
- `Ciudad` (string)

**Métodos:**
- `MostrarInformacion()`: Muestra toda la información de la persona
- `EsMayorDeEdad()`: Retorna true si la persona es mayor de 18 años
- `CumplirAnos()`: Incrementa la edad en 1

**Programa principal:**
- Crea 2 personas diferentes
- Muestra su información
- Haz que una de ellas cumpla años
- Verifica si son mayores de edad

```csharp
// Resultado esperado:
=== INFORMACIÓN DE PERSONAS ===
Nombre: Ana García
Edad: 17 años
Ciudad: Madrid
¿Es mayor de edad? No

Nombre: Carlos López
Edad: 25 años
Ciudad: Barcelona
¿Es mayor de edad? Sí

Ana cumple años...
Ana ahora tiene 18 años
¿Ana es ahora mayor de edad? Sí
```

---

### **Ejercicio 2: Calculadora de Utilidades**
**Dificultad:** ⭐⭐
**Tiempo estimado:** 25 minutos

Crea una clase `UtilidadesMatematicas` con métodos estáticos dentro del namespace `MiProyecto.Matematicas`:

**Métodos requeridos:**
1. `CalcularFactorial(int numero)`: Calcula el factorial de un número
2. `EsPrimo(int numero)`: Determina si un número es primo
3. `CalcularPotencia(double baseNum, int exponente)`: Calcula base^exponente
4. `ObtenerDigitos(int numero)`: Retorna un array con los dígitos del número
5. `EsPalindromo(int numero)`: Verifica si un número es palíndromo

**Validaciones:**
- El factorial solo para números positivos
- Números primos solo para números mayores a 1
- Manejar exponentes negativos en potencia

**Programa principal:**
- Crear un menú que permita usar todas las funciones
- Validar entrada del usuario
- Mostrar resultados formateados

---

### **Ejercicio 3: Sistema de Biblioteca Simple**
**Dificultad:** ⭐⭐
**Tiempo estimado:** 30 minutos

Crea un sistema básico de biblioteca con las siguientes clases:

#### Clase `Libro` (namespace `Biblioteca.Modelos`)
**Propiedades:**
- `Titulo` (string)
- `Autor` (string)
- `AnoPublicacion` (int)
- `Genero` (string)
- `NumeroPaginas` (int)

**Métodos:**
- `MostrarInformacion()`: Muestra todos los datos del libro
- `EsClasico()`: Retorna true si tiene más de 50 años
- `EsLargo()`: Retorna true si tiene más de 400 páginas

#### Clase `UtilidadesBiblioteca` (namespace `Biblioteca.Utilidades`)
**Métodos estáticos:**
- `BuscarPorAutor(Libro[] libros, string autor)`: Retorna libros del autor
- `LibrosClasicos(Libro[] libros)`: Retorna solo libros clásicos
- `PromedioAnos(Libro[] libros)`: Calcula el año promedio de publicación
- `LibroMasAntiguo(Libro[] libros)`: Encuentra el libro más antiguo
- `ContarPorGenero(Libro[] libros, string genero)`: Cuenta libros por género

**Programa principal:**
- Crear un array de al menos 5 libros
- Mostrar todos los libros
- Probar todas las funcionalidades de búsqueda y análisis

---

## 🚀 Ejercicios Intermedios

### **Ejercicio 4: Sistema de Gestión de Estudiantes**
**Dificultad:** ⭐⭐⭐
**Tiempo estimado:** 45 minutos

Desarrolla un sistema completo de gestión de estudiantes:

#### Clase `Estudiante` (namespace `SistemaEducativo.Modelos`)
**Propiedades:**
- `Nombre` (string)
- `Matricula` (string)
- `Carrera` (string)
- `Semestre` (int)

**Campos privados:**
- Lista de calificaciones (double[])

**Métodos:**
- `AgregarCalificacion(double calificacion)`: Agrega una calificación (0-10)
- `CalcularPromedio()`: Calcula el promedio de calificaciones
- `ObtenerCalificaciones()`: Retorna copia del array de calificaciones
- `EstaAprobado()`: True si promedio >= 6.0
- `MostrarReporte()`: Muestra información completa del estudiante

#### Clase `GestorEstudiantes` (namespace `SistemaEducativo.Gestores`)
**Métodos estáticos:**
- `DeterminarNivel(double promedio)`: Retorna "Excelente", "Bueno", "Regular", "Insuficiente"
- `EstudiantesAprobados(Estudiante[] estudiantes)`: Retorna array de aprobados
- `PromedioGeneral(Estudiante[] estudiantes)`: Promedio de todos los estudiantes
- `MejorEstudiante(Estudiante[] estudiantes)`: Estudiante con mejor promedio
- `EstudiantesPorCarrera(Estudiante[] estudiantes, string carrera)`: Filtra por carrera
- `GenerarReporteGeneral(Estudiante[] estudiantes)`: Muestra estadísticas completas

**Funcionalidades del programa:**
1. Registrar estudiantes
2. Agregar calificaciones
3. Ver reporte individual
4. Ver estadísticas generales
5. Buscar por carrera
6. Listar aprobados/reprobados

---

### **Ejercicio 5: Conversor de Unidades**
**Dificultad:** ⭐⭐⭐
**Tiempo estimado:** 35 minutos

Crea un sistema completo de conversión de unidades:

#### Clase `ConversorTemperatura` (namespace `Conversores.Temperatura`)
**Métodos estáticos:**
- `CelsiusAFahrenheit(double celsius)`
- `FahrenheitACelsius(double fahrenheit)`
- `CelsiusAKelvin(double celsius)`
- `KelvinACelsius(double kelvin)`
- `FahrenheitAKelvin(double fahrenheit)`
- `KelvinAFahrenheit(double kelvin)`

#### Clase `ConversorLongitud` (namespace `Conversores.Longitud`)
**Métodos estáticos:**
- `MetrosAPies(double metros)`
- `PiesAMetros(double pies)`
- `KilometrosAMillas(double kilometros)`
- `MillasAKilometros(double millas)`
- `CentimetrosAPulgadas(double centimetros)`
- `PulgadasACentimetros(double pulgadas)`

#### Clase `ConversorPeso` (namespace `Conversores.Peso`)
**Métodos estáticos:**
- `KilogramosALibras(double kilogramos)`
- `LibrasAKilogramos(double libras)`
- `GramosAOnzas(double gramos)`
- `OnzasAGramos(double onzas)`

#### Clase `UtilidadesConversion` (namespace `Conversores.Utilidades`)
**Métodos estáticos:**
- `ValidarTemperatura(double temp, string escala)`: Valida rangos físicamente posibles
- `RedondearResultado(double valor, int decimales)`: Redondea a decimales específicos
- `FormatearResultado(double valor, string unidadOrigen, string unidadDestino)`: Formato legible

**Programa principal:**
- Menú con todas las categorías de conversión
- Validación de entrada
- Manejo de valores inválidos
- Opción de realizar múltiples conversiones

---

## 🏆 Ejercicios Avanzados

### **Ejercicio 6: Sistema de Inventario**
**Dificultad:** ⭐⭐⭐⭐
**Tiempo estimado:** 60 minutos

Desarrolla un sistema completo de inventario:

#### Clase `Producto` (namespace `Inventario.Modelos`)
**Propiedades:**
- `Codigo` (string, único)
- `Nombre` (string)
- `Categoria` (string)
- `Precio` (decimal)
- `Stock` (int)
- `StockMinimo` (int)

**Métodos:**
- `AgregarStock(int cantidad)`: Incrementa el stock
- `RetirarStock(int cantidad)`: Decrementa stock (validar disponibilidad)
- `NecesitaReposicion()`: True si stock < stockMinimo
- `CalcularValorTotal()`: precio * stock
- `MostrarInformacion()`: Información completa del producto

#### Clase `GestorInventario` (namespace `Inventario.Gestores`)
**Métodos estáticos:**
- `BuscarPorCodigo(Producto[] productos, string codigo)`: Busca producto específico
- `ProductosPorCategoria(Producto[] productos, string categoria)`: Filtra por categoría
- `ProductosConBajoStock(Producto[] productos)`: Productos que necesitan reposición
- `ValorTotalInventario(Producto[] productos)`: Suma de todos los valores
- `ProductoMasCaro(Producto[] productos)`: Producto con mayor precio
- `ProductoMasBarato(Producto[] productos)`: Producto con menor precio
- `PromedioPrecios(Producto[] productos)`: Precio promedio
- `GenerarReporteCompleto(Producto[] productos)`: Reporte detallado

#### Clase `ValidadorInventario` (namespace `Inventario.Validadores`)
**Métodos estáticos:**
- `ValidarCodigo(string codigo)`: Verifica formato de código
- `ValidarPrecio(decimal precio)`: Precio debe ser positivo
- `ValidarStock(int stock)`: Stock no puede ser negativo
- `ValidarCategoria(string categoria)`: Categoría no puede estar vacía

**Funcionalidades del programa:**
1. Registrar productos
2. Actualizar stock (entrada/salida)
3. Buscar productos (por código, categoría)
4. Ver productos con bajo stock
5. Generar reportes financieros
6. Mostrar estadísticas del inventario

---

### **Ejercicio 7: Calculadora Científica**
**Dificultad:** ⭐⭐⭐⭐
**Tiempo estimado:** 50 minutos

Crea una calculadora científica completa:

#### Clase `OperacionesBasicas` (namespace `Calculadora.Basicas`)
- Suma, resta, multiplicación, división
- Validación de división por cero

#### Clase `OperacionesCientificas` (namespace `Calculadora.Cientificas`)
- Potencias, raíces, logaritmos
- Funciones trigonométricas (sin, cos, tan)
- Conversión de grados a radianes

#### Clase `OperacionesEstadisticas` (namespace `Calculadora.Estadisticas`)
- Media, mediana, moda
- Desviación estándar
- Varianza

#### Clase `UtilidadesCalculadora` (namespace `Calculadora.Utilidades`)
- Historial de operaciones
- Formateo de resultados
- Validación de entrada

**Programa principal:**
- Interfaz de menú completa
- Historial de cálculos
- Manejo de errores matemáticos
- Opción de limpiar historial

---

## 🎯 Criterios de Evaluación

### **Funcionalidad (40%)**
- [ ] Todas las clases implementadas correctamente
- [ ] Métodos funcionan según especificaciones
- [ ] Validaciones implementadas
- [ ] Programa principal funciona sin errores

### **Organización del Código (25%)**
- [ ] Namespaces utilizados correctamente
- [ ] Separación adecuada de responsabilidades
- [ ] Nombres descriptivos y consistentes
- [ ] Estructura lógica del código

### **Buenas Prácticas (20%)**
- [ ] Modificadores de acceso apropiados
- [ ] Métodos estáticos usados correctamente
- [ ] Validación de entrada
- [ ] Manejo básico de errores

### **Documentación (15%)**
- [ ] Comentarios XML en métodos públicos
- [ ] Comentarios explicativos en lógica compleja
- [ ] Código legible y bien formateado
- [ ] Variables con nombres significativos

---

## 💡 Consejos para el Desarrollo

### **Planificación:**
1. Lee todo el ejercicio antes de empezar
2. Identifica las clases y métodos necesarios
3. Decide qué debe ser estático y qué no
4. Planifica la estructura de namespaces

### **Implementación:**
1. Empieza con las clases más simples
2. Implementa y prueba método por método
3. Agrega validaciones progresivamente
4. Prueba cada funcionalidad antes de continuar

### **Debugging:**
1. Usa Console.WriteLine para verificar valores
2. Prueba casos extremos (números negativos, strings vacíos)
3. Verifica que las validaciones funcionen
4. Asegúrate de que el programa no falle

### **Mejores Prácticas:**
1. Un método debe hacer una sola cosa
2. Usa nombres descriptivos para todo
3. Valida parámetros de entrada
4. Mantén los métodos cortos y legibles
5. Separa lógica de presentación

¡Buena suerte con los ejercicios! 🚀
