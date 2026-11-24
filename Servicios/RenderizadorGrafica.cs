using System.Drawing.Drawing2D;
using OrdenamientoBench.Modelos;

namespace OrdenamientoBench.Servicios;

public static class RenderizadorGrafica
{
    private static readonly Color[] Paleta =
    {
        Color.FromArgb(31, 119, 180),
        Color.FromArgb(214, 39, 40),
        Color.FromArgb(44, 160, 44),
        Color.FromArgb(255, 127, 14),
        Color.FromArgb(148, 103, 189),
        Color.FromArgb(23, 190, 207),
        Color.FromArgb(127, 127, 127)
    };

    private const int MargenIzquierdo = 80;
    private const int MargenDerecho = 180;
    private const int MargenSuperior = 45;
    private const int MargenInferior = 60;
    private const int TicksLineales = 5;

    public static void Dibujar(
        Graphics g,
        Rectangle area,
        IReadOnlyList<ResultadoMedicion> resultados,
        Condicion condicion,
        Metrica metrica,
        bool escalaLogaritmica)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(Color.White);

        var datos = resultados.Where(r => r.Condicion == condicion).ToList();
        if (datos.Count == 0)
        {
            DibujarMensajeCentrado(g, area, Mensajes.SinDatosGrafica);
            return;
        }

        var zona = new Rectangle(
            area.Left + MargenIzquierdo,
            area.Top + MargenSuperior,
            area.Width - MargenIzquierdo - MargenDerecho,
            area.Height - MargenSuperior - MargenInferior);
        if (zona.Width < 20 || zona.Height < 20)
        {
            return;
        }

        Func<ResultadoMedicion, double> valorDe = r => metrica == Metrica.CpuMs ? r.CpuMs : r.RelojMs;
        var tamanos = datos.Select(r => r.Tamano).Distinct().OrderBy(t => t).ToList();
        var algoritmos = datos.Select(r => r.Algoritmo).Distinct().ToList();

        var escala = new EscalaVertical(datos.Select(valorDe).ToList(), escalaLogaritmica);

        using var fuente = new Font(SystemFonts.DefaultFont.FontFamily, 9f);
        using var fuenteTitulo = new Font(SystemFonts.DefaultFont.FontFamily, 12f, FontStyle.Bold);

        DibujarEjes(g, zona, escala, tamanos, fuente);

        string titulo = string.Format(Mensajes.TituloGrafica, condicion.Descripcion());
        g.DrawString(titulo, fuenteTitulo, Brushes.Black, zona.Left, area.Top + 10);

        for (int a = 0; a < algoritmos.Count; a++)
        {
            Color color = Paleta[a % Paleta.Length];
            var puntos = new List<PointF>();

            foreach (var r in datos.Where(d => d.Algoritmo == algoritmos[a]).OrderBy(d => d.Tamano))
            {
                int indice = tamanos.IndexOf(r.Tamano);
                float x = PosicionX(zona, indice, tamanos.Count);
                float y = zona.Bottom - (float)(escala.Normalizar(valorDe(r)) * zona.Height);
                puntos.Add(new PointF(x, y));
            }

            using var lapiz = new Pen(color, 2.2f);
            using var pincel = new SolidBrush(color);
            if (puntos.Count > 1)
            {
                g.DrawLines(lapiz, puntos.ToArray());
            }
            foreach (var p in puntos)
            {
                g.FillEllipse(pincel, p.X - 4, p.Y - 4, 8, 8);
            }

            // Leyenda a la derecha de la zona de dibujo
            float yLeyenda = zona.Top + a * 22;
            g.FillRectangle(pincel, zona.Right + 20, yLeyenda + 3, 14, 10);
            g.DrawString(algoritmos[a], fuente, Brushes.Black, zona.Right + 40, yLeyenda);
        }
    }

    private static void DibujarEjes(Graphics g, Rectangle zona, EscalaVertical escala, List<int> tamanos, Font fuente)
    {
        using var lapizEje = new Pen(Color.Black, 1.5f);
        using var lapizRejilla = new Pen(Color.Gainsboro, 1f);

        foreach (double marca in escala.Marcas(TicksLineales))
        {
            float y = zona.Bottom - (float)(escala.Normalizar(marca) * zona.Height);
            g.DrawLine(lapizRejilla, zona.Left, y, zona.Right, y);

            string texto = marca >= 100 ? marca.ToString("N0") : marca.ToString("0.##");
            var medida = g.MeasureString(texto, fuente);
            g.DrawString(texto, fuente, Brushes.Black, zona.Left - medida.Width - 6, y - medida.Height / 2);
        }

        g.DrawLine(lapizEje, zona.Left, zona.Top, zona.Left, zona.Bottom);
        g.DrawLine(lapizEje, zona.Left, zona.Bottom, zona.Right, zona.Bottom);

        for (int i = 0; i < tamanos.Count; i++)
        {
            float x = PosicionX(zona, i, tamanos.Count);
            string texto = tamanos[i].ToString("N0");
            var medida = g.MeasureString(texto, fuente);
            g.DrawLine(lapizEje, x, zona.Bottom, x, zona.Bottom + 5);
            g.DrawString(texto, fuente, Brushes.Black, x - medida.Width / 2, zona.Bottom + 8);
        }

        var etiquetaX = g.MeasureString(Mensajes.EtiquetaEjeX, fuente);
        g.DrawString(Mensajes.EtiquetaEjeX, fuente, Brushes.Black, zona.Left + (zona.Width - etiquetaX.Width) / 2, zona.Bottom + 32);

        var estado = g.Save();
        g.TranslateTransform(zona.Left - 62, zona.Top + zona.Height / 2f);
        g.RotateTransform(-90);
        var etiquetaY = g.MeasureString(Mensajes.EtiquetaEjeY, fuente);
        g.DrawString(Mensajes.EtiquetaEjeY, fuente, Brushes.Black, -etiquetaY.Width / 2, 0);
        g.Restore(estado);
    }

    private static float PosicionX(Rectangle zona, int indice, int total)
    {
        return zona.Left + zona.Width * (indice + 0.5f) / total;
    }

    private static void DibujarMensajeCentrado(Graphics g, Rectangle area, string mensaje)
    {
        using var formato = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        g.DrawString(mensaje, SystemFonts.DefaultFont, Brushes.Gray, area, formato);
    }

    // Convierte valores en tiempo a una posición entre 0 y 1, en escala lineal o logarítmica
    private sealed class EscalaVertical
    {
        private readonly bool logaritmica;
        private readonly double minimo;
        private readonly double maximo;

        public EscalaVertical(IReadOnlyList<double> valores, bool logaritmica)
        {
            this.logaritmica = logaritmica;
            double mayor = valores.Max();

            if (logaritmica)
            {
                double menorPositivo = valores.Where(v => v > 0).DefaultIfEmpty(1).Min();
                minimo = Math.Floor(Math.Log10(menorPositivo));
                maximo = Math.Ceiling(Math.Log10(Math.Max(mayor, menorPositivo)));
                if (maximo <= minimo)
                {
                    maximo = minimo + 1;
                }
            }
            else
            {
                minimo = 0;
                maximo = mayor > 0 ? mayor * 1.1 : 1;
            }
        }

        public double Normalizar(double valor)
        {
            if (!logaritmica)
            {
                return (valor - minimo) / (maximo - minimo);
            }

            // Los ceros no tienen logaritmo, se pintan en la base del eje
            double exponente = valor > 0 ? Math.Log10(valor) : minimo;
            return Math.Clamp((exponente - minimo) / (maximo - minimo), 0, 1);
        }

        public IEnumerable<double> Marcas(int cantidadLineal)
        {
            if (logaritmica)
            {
                for (double e = minimo; e <= maximo; e++)
                {
                    yield return Math.Pow(10, e);
                }
            }
            else
            {
                for (int i = 0; i <= cantidadLineal; i++)
                {
                    yield return maximo * i / cantidadLineal;
                }
            }
        }
    }
}
