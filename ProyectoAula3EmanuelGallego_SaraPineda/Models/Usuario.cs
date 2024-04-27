using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula3EmanuelGallego_SaraPineda.Models
{
    public class Usuario
    {
        private string cedula;
        private string nombre;
        private string apellido;
        private int periodoConsumo;
        private int estrato;
        private int MetaAhorroEnergia;
        private int ConsumoEnergia;
        private int PromedioConsumoAgua;
        private int ConsumoAgua;

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int PeriodoConsumo { get => periodoConsumo; set => periodoConsumo = value; }
        public int Estrato { get => estrato; set => estrato = value; }
        public int MetaAhorroEnergia1 { get => MetaAhorroEnergia; set => MetaAhorroEnergia = value; }
        public int ConsumoEnergia1 { get => ConsumoEnergia; set => ConsumoEnergia = value; }
        public int PromedioConsumoAgua1 { get => PromedioConsumoAgua; set => PromedioConsumoAgua = value; }
        public int ConsumoAgua1 { get => ConsumoAgua; set => ConsumoAgua = value; }


        public Usuario(string cedula, string nombre, string apellido, int periodoConsumo, int estrato, int MetaAhorroEnergia, int ConsumoEnergia, int PromedioConsumoAgua, int ConsumoAgua)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.PeriodoConsumo = periodoConsumo;
            this.Estrato = estrato;
            this.MetaAhorroEnergia1 = MetaAhorroEnergia;
            this.ConsumoEnergia1 = ConsumoEnergia;
            this.PromedioConsumoAgua1 = PromedioConsumoAgua;
            this.ConsumoAgua1 = ConsumoAgua;
        }

    }
}