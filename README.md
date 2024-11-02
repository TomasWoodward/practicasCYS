# FileLockr

FileLockr es una aplicación de Windows Forms desarrollada en C# que permite a los usuarios cifrar y comprimir archivos, almacenarlos de manera segura, y desencriptarlos cuando sea necesario. La aplicación utiliza cifrado AES y RSA para proteger tanto los archivos como las claves de cifrado.

## Características

- **Cifrado AES y RSA**: Los archivos se cifran con AES y las claves AES se protegen con RSA.
- **Compresión de archivos**: Los archivos seleccionados se comprimen antes de ser cifrados.
- **Gestión de claves**: Las claves públicas y privadas se generan y almacenan para cada usuario. La clave privada se cifra utilizando una contraseña proporcionada por el usuario.
- **Interfaz gráfica**: Una interfaz intuitiva que permite a los usuarios seleccionar, cifrar y desencriptar archivos.

## Estructura de Carpetas

Al iniciar, la aplicación crea las siguientes carpetas para organizar los archivos y claves:

- `./Archivos_FileLockr/archivos/`: Carpeta para almacenar los archivos cifrados.
- `./Archivos_FileLockr/archivos_descomprimidos/`: Carpeta para almacenar los archivos desencriptados y descomprimidos.
- `./Archivos_FileLockr/claves/`: Carpeta para almacenar las claves públicas y privadas cifradas de cada usuario.

## Configuración y Uso

### Prerrequisitos

- .NET Framework 4.7.2 o superior
- Windows Forms (WinForms)

### Instalación

1. Clona el repositorio o descarga el archivo fuente.
2. Abre el proyecto en Visual Studio.
3. Compila y publica el proyecto.

### Instrucciones de Uso

1. **Registro de Usuario**:
   - Introduce tu nombre de usuario y contraseña. Si es la primera vez que accedes, se generarán automáticamente claves RSA.
   
2. **Cifrado de Archivos**:
   - Haz clic en el botón **Examinar** para seleccionar los archivos que deseas cifrar.
   - Después de seleccionar los archivos, pulsa **Confirmar** para comprimir y cifrar los archivos seleccionados.
   - La aplicación generará una clave AES y un IV aleatorios para cada archivo, que se cifrarán con la clave pública RSA del usuario y se almacenarán en `./Archivos_FileLockr/claves/<usuario>`.

3. **Desencriptado de Archivos**:
   - En el panel de archivos, selecciona el archivo cifrado que deseas desencriptar.
   - FileLockr buscará la clave correspondiente, la desencriptará con la clave privada del usuario y descomprimirá el archivo.

## Seguridad

- Las claves RSA se generan y guardan en el sistema, con la clave privada cifrada mediante la contraseña del usuario.
- La clave privada nunca se guarda en texto plano.
- Cada archivo cifrado se almacena con su clave de cifrado específica.

## Estructura del Código

- **FileLockr.cs**: La clase principal de la interfaz gráfica y manejo de archivos y claves.
- **compressAndEncrypt**: Una clase que contiene métodos para generar claves RSA, cifrar y descifrar con AES y RSA, comprimir archivos y descomprimir archivos cifrados.

## Créditos

Desarrollado por Alex Valdelvira Muñoz (scrum master), Carolina Sanchez Abad, Paula Ortuño Jurado, Tomas Woodward Marin.

---

**Nota**: Recuerda mantener tus claves y archivos en un lugar seguro y no compartir tu clave privada.
