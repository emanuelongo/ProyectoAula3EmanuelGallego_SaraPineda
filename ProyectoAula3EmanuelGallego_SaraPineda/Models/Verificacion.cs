using ProyectoAula3EmanuelGallego_SaraPineda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula3EmanuelGallego_SaraPineda
{
    public class Verificacion
    {
        List<Usuario> DatosDeUsuarios = Epm.datosDeUsuarios;
        public bool verificarExistenciaId(string id)
        {
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.Cedula == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
