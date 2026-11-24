using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using OrdenamientoBench.Algoritmos;
using OrdenamientoBench.Modelos;
using OrdenamientoBench.Servicios;

namespace OrdenamientoBench;

public partial class Form1 : Form
{
    private static readonly char[] SeparadoresEntrada = { ',', ';', ' ', '\t', '\r', '\n' };

    private readonly ConfiguracionBanco configuracion;
    private readonly List<IMetodoOrdenamiento> catalogo;
    private readonly BindingList<ResultadoMedicion> resultados = new();
    private CancellationTokenSource? cancelacion;

    public Form1()
    {
        InitializeComponent();

        string rutaConfiguracion = Path.Combine(AppContext.BaseDirectory, Mensajes.ArchivoConfiguracion);
        configuracion = ConfiguracionBanco.Cargar(rutaConfiguracion);
        catalogo = CatalogoMetodos.Crear(configuracion);

        Text = Mensajes.Titulo;
        PrepararControles();
    }

    private void PrepararControles()
    {
        // Algoritmos: se muestra la propiedad Nombre de cada método
        clbAlgoritmos.DisplayMember = nameof(IMetodoOrdenamiento.Nombre);
        cmbMetodoRapido.DisplayMember = nameof(IMetodoOrdenamiento.Nombre);
        foreach (var metodo in catalogo)
        {
            clbAlgoritmos.Items.Add(metodo, true);
            cmbMetodoRapido.Items.Add(metodo);
        }
        cmbMetodoRapido.SelectedIndex = 0;

        // Los tamaños vienen del archivo de configuración
        foreach (int tamano in configuracion.Tamanos.Where(t => t > 0).Distinct().OrderBy(t => t))
        {
            AgregarTamano(tamano);
        }

        foreach (var condicion in Enum.GetValues<Condicion>())
        {
            var elemento = new ElementoLista<Condicion>(condicion, condicion.Descripcion());
            clbCondiciones.Items.Add(elemento, true);
            cmbCondicionGrafica.Items.Add(elemento);
        }
        cmbCondicionGrafica.SelectedIndex = 0;

        cmbMetrica.Items.Add(new ElementoLista<Metrica>(Metrica.CpuMs, "Tiempo de CPU"));
        cmbMetrica.Items.Add(new ElementoLista<Metrica>(Metrica.RelojMs, "Tiempo de reloj"));
        cmbMetrica.SelectedIndex = 0;

        nudRepeticiones.Value = Math.Clamp(configuracion.Repeticiones, (int)nudRepeticiones.Minimum, (int)nudRepeticiones.Maximum);
        nudSemilla.Value = Math.Clamp(configuracion.Semilla, 0, (int)nudSemilla.Maximum);

        dgvResultados.DataSource = resultados;
        dgvResultados.Columns[nameof(ResultadoMedicion.CpuMs)].DefaultCellStyle.Format = "N2";
        dgvResultados.Columns[nameof(ResultadoMedicion.RelojMs)].DefaultCellStyle.Format = "N2";
        dgvResultados.Columns[nameof(ResultadoMedicion.Tamano)].DefaultCellStyle.Format = "N0";

        lblEstado.Text = Mensajes.EstadoListo;
    }

    private bool AgregarTamano(int tamano)
    {
        bool yaExiste = clbTamanos.Items.Cast<ElementoLista<int>>().Any(e => e.Valor == tamano);
        if (yaExiste)
        {
            return false;
        }

        var elemento = new ElementoLista<int>(tamano, tamano.ToString("N0", CultureInfo.CurrentCulture));
        clbTamanos.Items.Add(elemento, true);
        return true;
    }

    private void btnAgregarTamano_Click(object sender, EventArgs e)
    {
        if (!AgregarTamano((int)nudTamanoExtra.Value))
        {
            MessageBox.Show(Mensajes.TamanoDuplicado, Mensajes.Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private async void btnEjecutar_Click(object sender, EventArgs e)
    {
        var metodos = clbAlgoritmos.CheckedItems.Cast<IMetodoOrdenamiento>().ToList();
        var tamanos = clbTamanos.CheckedItems.Cast<ElementoLista<int>>().Select(t => t.Valor).OrderBy(t => t).ToList();
        var condiciones = clbCondiciones.CheckedItems.Cast<ElementoLista<Condicion>>().Select(c => c.Valor).ToList();

        if (metodos.Count == 0 || tamanos.Count == 0 || condiciones.Count == 0)
        {
            MessageBox.Show(Mensajes.SeleccionIncompleta, Mensajes.Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        configuracion.Repeticiones = (int)nudRepeticiones.Value;
        configuracion.Semilla = (int)nudSemilla.Value;

        resultados.Clear();
        pbGrafica.Invalidate();
        AlternarEjecucion(enCurso: true);
        cancelacion = new CancellationTokenSource();

        var banco = new BancoDePruebas(configuracion);
        var progreso = new Progress<ProgresoBanco>(RecibirProgreso);
        var token = cancelacion.Token;

        try
        {
            // El banco corre en otro hilo para que la ventana no se congele con Burbuja y 100,000 datos
            await Task.Run(() => banco.Ejecutar(metodos, tamanos, condiciones, progreso, token));
            lblEstado.Text = Mensajes.EstadoTerminado;
        }
        catch (OperationCanceledException)
        {
            lblEstado.Text = Mensajes.EstadoCancelado;
        }
        finally
        {
            cancelacion.Dispose();
            cancelacion = null;
            AlternarEjecucion(enCurso: false);
            pbGrafica.Invalidate();
        }
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        cancelacion?.Cancel();
    }

    private void RecibirProgreso(ProgresoBanco progreso)
    {
        barraProgreso.Maximum = progreso.Total;
        barraProgreso.Value = Math.Min(progreso.Completadas, progreso.Total);
        lblEstado.Text = string.Format(Mensajes.EstadoProgreso, progreso.Completadas, progreso.Total, progreso.Descripcion);

        if (progreso.Nuevo is not null)
        {
            resultados.Add(progreso.Nuevo);
            pbGrafica.Invalidate();
        }
    }

    private void AlternarEjecucion(bool enCurso)
    {
        // Durante la ejecución solo queda activo el botón de cancelar
        foreach (Control control in grupoConfiguracion.Controls)
        {
            control.Enabled = enCurso ? control == btnCancelar : control != btnCancelar;
        }
    }

    private void OpcionesGraficaCambiaron(object? sender, EventArgs e)
    {
        pbGrafica.Invalidate();
    }

    private void pbGrafica_Resize(object? sender, EventArgs e)
    {
        pbGrafica.Invalidate();
    }

    private void pbGrafica_Paint(object? sender, PaintEventArgs e)
    {
        if (!TryLeerOpcionesGrafica(out var condicion, out var metrica))
        {
            return;
        }

        RenderizadorGrafica.Dibujar(e.Graphics, pbGrafica.ClientRectangle, resultados.ToList(), condicion, metrica, chkEscalaLog.Checked);
    }

    private bool TryLeerOpcionesGrafica(out Condicion condicion, out Metrica metrica)
    {
        condicion = default;
        metrica = default;

        if (cmbCondicionGrafica.SelectedItem is not ElementoLista<Condicion> condicionElegida ||
            cmbMetrica.SelectedItem is not ElementoLista<Metrica> metricaElegida)
        {
            return false;
        }

        condicion = condicionElegida.Valor;
        metrica = metricaElegida.Valor;
        return true;
    }

    private void btnExportarCsv_Click(object sender, EventArgs e)
    {
        if (resultados.Count == 0)
        {
            MessageBox.Show(Mensajes.SinResultados, Mensajes.Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (dlgGuardarCsv.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            ExportadorResultados.GuardarCsv(dlgGuardarCsv.FileName, resultados);
        }
        catch (IOException ex)
        {
            MessageBox.Show(string.Format(Mensajes.ErrorGuardar, ex.Message), Mensajes.Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnExportarPng_Click(object sender, EventArgs e)
    {
        if (resultados.Count == 0 || !TryLeerOpcionesGrafica(out var condicion, out var metrica))
        {
            MessageBox.Show(Mensajes.SinResultados, Mensajes.Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (dlgGuardarPng.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            using var imagen = new Bitmap(configuracion.AnchoImagen, configuracion.AltoImagen);
            using var lienzo = Graphics.FromImage(imagen);
            var area = new Rectangle(0, 0, imagen.Width, imagen.Height);
            RenderizadorGrafica.Dibujar(lienzo, area, resultados.ToList(), condicion, metrica, chkEscalaLog.Checked);
            imagen.Save(dlgGuardarPng.FileName, ImageFormat.Png);
        }
        catch (Exception ex) when (ex is IOException or System.Runtime.InteropServices.ExternalException)
        {
            MessageBox.Show(string.Format(Mensajes.ErrorGuardar, ex.Message), Mensajes.Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnOrdenarRapido_Click(object sender, EventArgs e)
    {
        if (cmbMetodoRapido.SelectedItem is not IMetodoOrdenamiento metodo)
        {
            return;
        }

        var numeros = new List<int>();
        foreach (string parte in txtEntrada.Text.Split(SeparadoresEntrada, StringSplitOptions.RemoveEmptyEntries))
        {
            if (!int.TryParse(parte, out int numero))
            {
                MessageBox.Show(string.Format(Mensajes.NumeroInvalido, parte), Mensajes.Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            numeros.Add(numero);
        }

        int[] arreglo = numeros.ToArray();
        var reloj = Stopwatch.StartNew();
        metodo.Ordenar(arreglo);
        reloj.Stop();

        txtSalida.Text = string.Join(", ", arreglo);
        lblTiempoRapido.Text = string.Format(Mensajes.TiempoRapido, reloj.Elapsed.TotalMilliseconds);
    }
}
