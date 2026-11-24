using System.Diagnostics;
using OrdenamientoBench.Algoritmos;
using OrdenamientoBench.Modelos;

namespace OrdenamientoBench.Servicios;

public class BancoDePruebas
{
    private readonly ConfiguracionBanco configuracion;

    public BancoDePruebas(ConfiguracionBanco configuracion)
    {
        this.configuracion = configuracion;
    }

    public void Ejecutar(
        IReadOnlyList<IMetodoOrdenamiento> metodos,
        IReadOnlyList<int> tamanos,
        IReadOnlyList<Condicion> condiciones,
        IProgress<ProgresoBanco> progreso,
        CancellationToken cancelacion)
    {
        int total = metodos.Count * tamanos.Count * condiciones.Count;
        int hechas = 0;

        CalentarMetodos(metodos);

        foreach (int tamano in tamanos)
        {
            int[] aleatorio = GeneradorDatos.CrearAleatorio(tamano, configuracion.ValorMaximo, configuracion.Semilla);

            // El resultado correcto se calcula una sola vez por tamaño para validar a todos los métodos
            int[] esperado = (int[])aleatorio.Clone();
            Array.Sort(esperado);

            foreach (var condicion in condiciones)
            {
                int[] entrada = GeneradorDatos.Preparar(aleatorio, condicion);

                foreach (var metodo in metodos)
                {
                    cancelacion.ThrowIfCancellationRequested();

                    string descripcion = string.Format(Mensajes.DescripcionPrueba, metodo.Nombre, tamano, condicion.Descripcion());
                    progreso.Report(new ProgresoBanco(hechas, total, descripcion));

                    var resultado = Medir(metodo, entrada, esperado, condicion);
                    hechas++;
                    progreso.Report(new ProgresoBanco(hechas, total, descripcion, resultado));
                }
            }
        }
    }

    // Una corrida previa con pocos datos evita que la compilación JIT cuente en la primera medición
    private void CalentarMetodos(IReadOnlyList<IMetodoOrdenamiento> metodos)
    {
        int[] muestra = GeneradorDatos.CrearAleatorio(configuracion.TamanoCalentamiento, configuracion.ValorMaximo, configuracion.Semilla);
        foreach (var metodo in metodos)
        {
            metodo.Ordenar((int[])muestra.Clone());
        }
    }

    private ResultadoMedicion Medir(IMetodoOrdenamiento metodo, int[] entrada, int[] esperado, Condicion condicion)
    {
        int repeticiones = Math.Max(1, configuracion.Repeticiones);
        double relojTotal = 0;
        double cpuTotal = 0;
        bool correcto = true;

        for (int i = 0; i < repeticiones; i++)
        {
            int[] copia = (int[])entrada.Clone();

            // Se limpia la memoria antes de medir para que el recolector no entre a mitad de la prueba
            GC.Collect();
            GC.WaitForPendingFinalizers();

            TimeSpan cpuInicial = LeerTiempoCpu();
            var reloj = Stopwatch.StartNew();
            metodo.Ordenar(copia);
            reloj.Stop();
            TimeSpan cpuFinal = LeerTiempoCpu();

            relojTotal += reloj.Elapsed.TotalMilliseconds;
            cpuTotal += (cpuFinal - cpuInicial).TotalMilliseconds;
            correcto &= copia.AsSpan().SequenceEqual(esperado);
        }

        return new ResultadoMedicion
        {
            Algoritmo = metodo.Nombre,
            Tipo = metodo.Tipo,
            Tamano = entrada.Length,
            Condicion = condicion,
            CpuMs = cpuTotal / repeticiones,
            RelojMs = relojTotal / repeticiones,
            Correcto = correcto
        };
    }

    private static TimeSpan LeerTiempoCpu()
    {
        using var proceso = Process.GetCurrentProcess();
        return proceso.TotalProcessorTime;
    }
}
