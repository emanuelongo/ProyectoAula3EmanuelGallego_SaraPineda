using ProyectoAula3EmanuelGallego_SaraPineda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula3EmanuelGallego_SaraPineda
{
    public class Modificacion
    {
        List<Usuario> DatosDeUsuarios = Epm.datosDeUsuarios;

        public Usuario modificarNombre(string cedula, string nuevoNombre)
        {
            Usuario usuarioMencionado = null;
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.Cedula == cedula)
                {
                    usuario.Nombre = nuevoNombre;
                    usuarioMencionado = usuario;
                }
            }
            return usuarioMencionado;
        }

        public Usuario modificarApellido(string cedula, string nuevoApellido)
        {
            Usuario usuarioMencionado = null;
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.Cedula == cedula)
                {
                    usuario.Apellido = nuevoApellido;
                    usuarioMencionado = usuario;
                }
            }
            return usuarioMencionado;
        }

        public Usuario modificarPeriodoConsumo(string cedula, int nuevoPeriodoConsumo)
        {
            Usuario usuarioMencionado = null;
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.Cedula == cedula)
                {
                    usuario.PeriodoConsumo = nuevoPeriodoConsumo;
                    usuarioMencionado = usuario;
                }
            }
            return usuarioMencionado;
        }

        public Usuario modificarEstrato(string cedula, int nuevoEstrato)
        {
            Usuario usuarioMencionado = null;
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.Cedula == cedula)
                {
                    usuario.Estrato = nuevoEstrato;
                    usuarioMencionado = usuario;
                }
            }
            return usuarioMencionado;
        }

        public Usuario modificarMetaAhorroEnergia(string cedula, int nuevaMetaAhorroEnergia)
        {
            Usuario usuarioMencionado = null;
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.Cedula == cedula)
                {
                    usuario.MetaAhorroEnergia1 = nuevaMetaAhorroEnergia;
                    usuarioMencionado = usuario;
                }
            }
            return usuarioMencionado;
        }

        public Usuario modificarConsumoEnergia(string cedula, int nuevoConsumoEnergia)
        {
            Usuario usuarioMencionado = null;
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.Cedula == cedula)
                {
                    usuario.ConsumoEnergia1 = nuevoConsumoEnergia;
                    usuarioMencionado = usuario;
                }
            }
            return usuarioMencionado;
        }

        public Usuario modificarPromedioConsumoAgua(string cedula, int nuevoPromedioConsumoAgua)
        {
            Usuario usuarioMencionado = null;
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.Cedula == cedula)
                {
                    usuario.PromedioConsumoAgua1 = nuevoPromedioConsumoAgua;
                    usuarioMencionado = usuario;
                }
            }
            return usuarioMencionado;
        }

        public Usuario modificarConsumoAgua(string cedula, int nuevoConsumoAgua)
        {
            Usuario usuarioMencionado = null;
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.Cedula == cedula)
                {
                    usuario.ConsumoAgua1 = nuevoConsumoAgua;
                    usuarioMencionado = usuario;
                }
            }
            return usuarioMencionado;
        }
    }
}
