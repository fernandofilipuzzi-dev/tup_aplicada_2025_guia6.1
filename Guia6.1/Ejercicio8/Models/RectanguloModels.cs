namespace Ejercicio8.Models;

public class RectanguloModels:FiguraModel
{
    public double? Ancho { get; set; }
    public double? Largo { get; set; }

    public RectanguloModels() { }

    public RectanguloModels(int? id, double? area, double? ancho, double? largo):base(id, area)
    {
        this.Ancho = ancho;
        this.Largo = largo;
    }
}
