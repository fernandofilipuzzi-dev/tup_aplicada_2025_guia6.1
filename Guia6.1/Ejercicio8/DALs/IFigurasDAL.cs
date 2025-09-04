using Ejercicio8.Models;

namespace Ejercicio8_abm.DALs;

public interface IFigurasDAL
{
    public Task<List<FiguraModel>> GetAll();
    
    public Task<FiguraModel> GetById(int idFigura);

    public Task<FiguraModel> Add(FiguraModel nuevo);
    
    public Task<bool> Save(FiguraModel entidad);

    public Task<bool> Remove(int idFigura);
}
