using Ejercicio8.DALs;

namespace Ejercicio8_abm.DALs;

static public class FigurasDALFactory
{
    static public IFigurasDAL CrearDao(TipoDAL tipo)
    {
        switch (tipo)
        { 
            case TipoDAL.MSQL:
                return new FigurasMSQLDAL();

            case TipoDAL.List:
                return new FigurasListDAL();
        }
        return null;
    }


}


