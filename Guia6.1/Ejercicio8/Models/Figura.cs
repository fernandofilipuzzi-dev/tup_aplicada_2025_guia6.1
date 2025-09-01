namespace Ejercicio8.Models;

abstract public class Figura
{
    public int? Id { get; set; }
    public double? Area { get; set; }

    public Figura()
    { }

    public Figura(int? id, double? area)
    { 
        Id = id;
        Area = area;
    }
}
