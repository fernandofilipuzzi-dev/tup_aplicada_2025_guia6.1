using Ejercicio8.Models;
using Ejercicio8_abm.DALs;
namespace Ejercicio8.DALs;

public class FigurasListDAL:IFigurasDAL
{
    List<FiguraModel> figuras = new List<FiguraModel>();

    async public Task<List<FiguraModel>> GetAll()
    {
        return await Task.FromResult(figuras);
    }

    async public Task<FiguraModel> GetById(int idFigura)
    {
        FiguraModel figura = (from f in figuras where f.Id == idFigura select f).FirstOrDefault<FiguraModel>();
        return await Task.FromResult(figura);
    }
    
    async public Task<FiguraModel> Add(FiguraModel nuevo)
    {
        return null;
    }

    async public Task<bool> Save(FiguraModel entidad)
    {
        return false;
    }

    async public Task<bool> Remove(int idFigura)
    {
        return false;
    }
}
