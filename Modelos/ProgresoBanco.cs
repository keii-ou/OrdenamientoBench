namespace OrdenamientoBench.Modelos;

public record ProgresoBanco(int Completadas, int Total, string Descripcion, ResultadoMedicion? Nuevo = null);
