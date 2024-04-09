using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula3EmanuelGallego_SaraPineda
{
    public class Modificacion
    {
        private Epm epm;

        public Epm Epm { get => epm; set => epm = value; }

        public Modificacion()
        {
            this.Epm = new Epm();
        }

        public void modificarNombre(Usuario usuario, string nuevoNombre)
        {
            usuario.Nombre = nuevoNombre;
        }

        public void modificarApellido(Usuario usuario, string nuevoApellido)
        {
            usuario.Apellido = nuevoApellido;
        }

        public void modificarPeriodoConsumo(Usuario usuario, int nuevoPeriodoConsumo)
        {
            usuario.PeriodoConsumo = nuevoPeriodoConsumo;
        }

        public void modificarEstrato(Usuario usuario, int nuevoEstrato)
        {
            usuario.Estrato = nuevoEstrato;
        }

        public void modificarMetaAhorroEnergia(Usuario usuario, int nuevaMetaAhorroEnergia)
        {
            usuario.MetaAhorroEnergia1 = nuevaMetaAhorroEnergia;
        }

        public void modificarConsumoEnergia(Usuario usuario, int nuevoConsumoEnergia)
        {
            usuario.ConsumoEnergia1 = nuevoConsumoEnergia;
        }

        public void modificarPromedioConsumoAgua(Usuario usuario, int nuevoPromedioConsumoAgua)
        {
            usuario.PromedioConsumoAgua1 = nuevoPromedioConsumoAgua;
        }

        public void modificarConsumoAgua(Usuario usuario, int nuevoConsumoAgua)
        {
            usuario.ConsumoAgua1 = nuevoConsumoAgua;
        }
    }
}
