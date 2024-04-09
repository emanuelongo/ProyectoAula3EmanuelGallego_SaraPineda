using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula3EmanuelGallego_SaraPineda
{
    public class Verificacion
    {
        private Epm epm;

        public Epm Epm { get => epm; set => epm = value; }

        public Verificacion()
        {
            this.Epm = new Epm();
        }

        public bool verificarExistenciaId(String id)
        {
            foreach (Usuario usuario in Epm.DatosDeUsuarios)
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
