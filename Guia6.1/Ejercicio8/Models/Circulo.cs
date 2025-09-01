namespace Ejercicio8.Models;

public class Circulo:Figura
{
    public double? Radio { get; set; }

    public Circulo() { }
    public Circulo(int? id, double? area, double radio) : base(id, area)
    { 
        this.Radio = radio;
    }
}
