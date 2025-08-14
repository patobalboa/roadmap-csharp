# Guía de Instalación: Visual Studio Community 2022

## 🎯 Objetivo
Configurar correctamente Visual Studio Community 2022 con .NET 8 para desarrollo de aplicaciones de consola en C#.

## 📋 Prerrequisitos
- Windows 10/11 (64 bits)
- 16 GB de RAM recomendados (mínimo 8 GB)
- 10 GB de espacio libre en disco
- Conexión a internet estable

## 🔧 Paso 1: Descargar Visual Studio Community 2022

1. **Ir al sitio oficial**:
   - Navega a: https://visualstudio.microsoft.com/es/vs/community/
   - Hacer clic en **"Descargar Visual Studio Community 2022"**

2. **Ejecutar el instalador**:
   - Localizar el archivo descargado: `vs_community.exe`
   - Hacer clic derecho → **"Ejecutar como administrador"**
   - Aceptar los términos de licencia

## 🛠️ Paso 2: Seleccionar Cargas de Trabajo

### Carga de trabajo principal:
✅ **Desarrollo de escritorio de .NET**
   - Esta carga incluye:
     - .NET Framework 4.8
     - .NET 8 (LTS)
     - Herramientas de MSBuild
     - Depurador de Visual Studio
     - IntelliSense para C#

### Componentes adicionales recomendados:
- ✅ Git para Windows
- ✅ GitHub Extension for Visual Studio
- ✅ .NET Profiling Tools

### Configuración de instalación:
```
Cargas de trabajo seleccionadas:
├─ Desarrollo de escritorio de .NET ✅
├─ Herramientas de código de ASP.NET y web (opcional) ⚪
└─ Desarrollo multiplataforma de .NET (opcional) ⚪

Componentes individuales:
├─ .NET 8.0 Runtime ✅
├─ .NET 8.0 SDK ✅
├─ Git para Windows ✅
└─ Depurador Just-In-Time ✅
```

## 🚀 Paso 3: Iniciar la Instalación

1. **Revisar selecciones**:
   - Verificar que "Desarrollo de escritorio de .NET" esté marcado
   - Confirmar que .NET 8 aparece en los componentes

2. **Configurar ubicación** (opcional):
   - Ubicación por defecto: `C:\Program Files\Microsoft Visual Studio\2022\Community`
   - Ubicación de caché: `C:\ProgramData\Microsoft\VisualStudio\Packages`

3. **Instalar**:
   - Hacer clic en **"Instalar"**
   - Tiempo estimado: 30-60 minutos (depende de la conexión)

## ✅ Paso 4: Verificar la Instalación

### Primera ejecución:
1. **Abrir Visual Studio 2022**
2. **Configurar cuenta** (opcional pero recomendado):
   - Iniciar sesión con cuenta Microsoft/GitHub
   - Configurar preferencias de desarrollo: **"Visual C#"**

### Verificar .NET 8:
1. **Crear proyecto de prueba**:
   - Archivo → Nuevo → Proyecto
   - Buscar: **"Console App"**
   - Verificar que aparezca **.NET 8.0** en el framework

### Verificar herramientas:
```cmd
# Verificar desde Command Prompt
dotnet --version
# Debería mostrar: 8.0.x o superior
```

## 🎨 Paso 5: Configuración Recomendada

### Tema y apariencia:
- **Herramientas** → **Opciones** → **Entorno** → **General**
- Tema de color: **"Azul"** o **"Claro"** (mejor para principiantes)
- Fuente: **Consolas 11pt** o **Courier New 10pt**

### Configuración del editor:
- **Herramientas** → **Opciones** → **Editor de texto** → **C#**
- ✅ Mostrar números de línea
- ✅ Sangría automática
- ✅ IntelliSense activado
- ✅ Formato automático al escribir

### Configuración de depuración:
- **Herramientas** → **Opciones** → **Depuración** → **General**
- ✅ Mostrar valores de variables en editor
- ✅ Habilitar editar y continuar

## 🐛 Solución de Problemas Comunes

### Error: ".NET 8 no disponible"
**Solución**:
1. Ir a **Visual Studio Installer**
2. Modificar instalación
3. Pestaña **"Componentes individuales"**
4. Buscar y marcar: **".NET 8.0 Runtime"** y **".NET 8.0 SDK"**

### Error: "No se puede crear proyecto de consola"
**Solución**:
1. Verificar que la carga **"Desarrollo de escritorio de .NET"** esté instalada
2. Reiniciar Visual Studio
3. Crear proyecto con plantilla **"Console App (.NET Core)"**

### Rendimiento lento
**Solución**:
1. **Herramientas** → **Opciones** → **Proyectos y soluciones**
2. ✅ Activar "Compilación paralela"
3. Aumentar número de compilaciones paralelas a 4-8

## 📝 Lista de Verificación Final

Antes de continuar al siguiente módulo, verificar:

- [ ] Visual Studio Community 2022 instalado correctamente
- [ ] .NET 8 SDK disponible (`dotnet --version`)
- [ ] Puede crear un nuevo "Console App"
- [ ] IntelliSense funciona (aparecen sugerencias al escribir)
- [ ] Puede ejecutar un programa simple con F5
- [ ] El depurador se detiene en breakpoints
- [ ] Console.WriteLine funciona correctamente

## 🎯 Siguiente Paso

Una vez completada la instalación:
👉 **Continúa con**: [`primer-proyecto-console.md`](primer-proyecto-console.md)

---

## 💡 Tips Adicionales

### Atajos de teclado útiles:
- `F5` - Ejecutar con depuración
- `Ctrl + F5` - Ejecutar sin depuración
- `F9` - Toggle breakpoint
- `Ctrl + K, Ctrl + C` - Comentar líneas
- `Ctrl + K, Ctrl + U` - Descomentar líneas

### Extensiones recomendadas:
- **CodeMaid** - Limpieza y organización de código
- **Productivity Power Tools** - Mejoras de productividad
- **GitLens** - Mejor integración con Git

---

*¿Problemas con la instalación? Consulta la [documentación oficial de Microsoft](https://docs.microsoft.com/es-es/visualstudio/install/) o pregunta a tu instructor.*
