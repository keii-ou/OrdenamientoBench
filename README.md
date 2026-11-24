# OrdenamientoBench

Banco de pruebas de algoritmos de ordenamiento (Unidad 5, tarea 5.2).
Windows Forms, C#, .NET 10.

## Algoritmos
- Internos: Burbuja, Quicksort, ShellSort, Radix
- Externos: Intercalación, Mezcla Directa, Mezcla Natural

## Cómo abrirlo
1. Instalar Visual Studio con la carga de trabajo "Desarrollo de escritorio con .NET" y el SDK de .NET 10.
2. Abrir `OrdenamientoBench.csproj`.
3. Ejecutar con F5. Form1 se puede editar en el diseñador.

## Configuración
`banco.config.json` (se copia junto al ejecutable) define las cantidades de registros, la semilla,
las repeticiones, el tamaño de bloque de la Intercalación y el tamaño de la imagen exportada.

## Estructura
- `Algoritmos/`  un archivo por método y utilidades de archivos binarios para los externos
- `Modelos/`     condiciones, resultados, progreso y elementos de lista
- `Servicios/`   banco de pruebas, generador de datos, configuración, graficador, exportador y textos

## Subir a GitHub
```
git init
git add .
git commit -m "Banco de pruebas de ordenamiento"
git branch -M main
git remote add origin <url-del-repositorio>
git push -u origin main
```
