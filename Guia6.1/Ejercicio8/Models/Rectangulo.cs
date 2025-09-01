namespace Ejercicio8.Models;

public class Rectangulo:Figura
{
    public double? Ancho { get; set; }
    public double? Largo { get; set; }

    public Rectangulo() { }

    public Rectangulo(int? id, double? area, double? ancho, double? largo):base(id, area)
    {
        this.Ancho = ancho;
        this.Largo = largo;
    }
}
