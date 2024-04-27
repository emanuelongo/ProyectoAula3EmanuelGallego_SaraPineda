using ProyectoAula3EmanuelGallego_SaraPineda.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula3EmanuelGallego_SaraPineda.Models
{
    public class Epm
    {
        private Factura factura = new Factura();

        public static List<Usuario> datosDeUsuarios = new List<Usuario>();

        public Factura Factura { get => factura; set => factura = value; }
        public List<Usuario> DatosDeUsuarios { get => datosDeUsuarios; set => datosDeUsuarios = value; }

        public Epm()
        {
            this.Factura = factura;
            this.DatosDeUsuarios = datosDeUsuarios;
        }

        public void AgregarCliente(Usuario usuario)
        {
            DatosDeUsuarios.Add(usuario);
        }

        public Usuario EliminarCliente(Usuario usuario)
        {
            DatosDeUsuarios.Remove(usuario);

            return usuario;
        }

        public double CacularPromedioConsumoDeEnergia()
        {
            double sumatoria = 0;

            for (int i = 0; i < DatosDeUsuarios.Count; i++)
            {
                sumatoria = sumatoria + DatosDeUsuarios[i].ConsumoEnergia1;
            }

            double promedio = sumatoria / DatosDeUsuarios.Count;
            return promedio;
        }

        public double CalcularTotalDescuentosPorIncentivoDeEnergia()
        {
            double descuento_total_incentivo = 0;
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.MetaAhorroEnergia1 > usuario.ConsumoEnergia1)
                {
                    descuento_total_incentivo += Factura.CalcularValorIncentivoEnergia(usuario.MetaAhorroEnergia1, usuario.ConsumoEnergia1);
                }

            }

            return descuento_total_incentivo;
        }

        public double CalcularTotalM3AguaEncimaPromedio()
        {
            double m3_agua_encima_promedio = 0;

            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.ConsumoAgua1 > usuario.PromedioConsumoAgua1)
                {
                    m3_agua_encima_promedio += usuario.ConsumoAgua1 - usuario.PromedioConsumoAgua1;
                }

            }
            return m3_agua_encima_promedio;
        }

        public double CalcularClientesConConsumoAguaMayorAlPromedio()
        {
            double clientes_consumo_agua_encima_promedio = 0;

            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.ConsumoAgua1 > usuario.PromedioConsumoAgua1)
                {
                    clientes_consumo_agua_encima_promedio += 1;
                }

            }
            return clientes_consumo_agua_encima_promedio;
        }

        public string ConusltarPorcentajeConsumoAguaPorEstrato()
        {
            string porcentajes = "";
            var excesoPorEstrato = DatosDeUsuarios
            .GroupBy(c => c.Estrato)
            .Select(g => new
            {
                Estrato = g.Key,
                PorcentajeExceso = g.Count(c => (c.PromedioConsumoAgua1 - c.ConsumoAgua1) > 0) * 0.1 / g.Count()
            });

            foreach (var item in excesoPorEstrato)
            {
                porcentajes += "Estrato: " + item.Estrato + ", Porcentaje de consumo excesivo de agua: " + item.PorcentajeExceso + "% " ;
            }
            return porcentajes;
        }

        public string MostrarDatosClienteConMayorDesfaseEnergia()
        {
            string UsuarioMayorDesfase = null;
            int DesfaseEnergia = 0;
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.ConsumoEnergia1 - usuario.MetaAhorroEnergia1 > DesfaseEnergia)
                {
                    UsuarioMayorDesfase = usuario.Cedula;
                    DesfaseEnergia = usuario.ConsumoEnergia1 - usuario.MetaAhorroEnergia1;
                }
            }
            return UsuarioMayorDesfase;
        }

        public int MostrarEstratoConMayorAhorroAgua()
        {
            int EstratoMayorAhorrador = 0;
            int AhorroAgua = 0;
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.PromedioConsumoAgua1 - usuario.ConsumoAgua1 > AhorroAgua)
                {
                    EstratoMayorAhorrador = usuario.Estrato;
                    AhorroAgua = usuario.PromedioConsumoAgua1 - usuario.ConsumoAgua1;
                }
            }
            return EstratoMayorAhorrador;
        }

        public int MostrarEstratoConMayorConsumoEnergia()
        {
            int EstratoMayorConsumidor = 0;
            int MayorGastoEnergia = 0;
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.ConsumoEnergia1 > MayorGastoEnergia)
                {
                    EstratoMayorConsumidor = usuario.Estrato;
                    MayorGastoEnergia = usuario.ConsumoEnergia1;
                }
            }
            return EstratoMayorConsumidor;
        }

        public int MostrarEstratoConMenorConsumoEnergia()
        {
            int EstratoMenorConsumidor = 0;
            int MenorGastoEnergia = 1000;
            foreach (Usuario usuario in DatosDeUsuarios)
            {
                if (usuario.ConsumoEnergia1 < MenorGastoEnergia)
                {
                    EstratoMenorConsumidor = usuario.Estrato;
                    MenorGastoEnergia = usuario.ConsumoEnergia1;
                }
            }
            return EstratoMenorConsumidor;
        }

        public string CalcularClienteMayorConsumoAgua()
        {
            string clientes = "";

            var clienteConMayorConsumo = DatosDeUsuarios
            .GroupBy(c => c.PeriodoConsumo)
            .Select(g => new
            {
                periodoConsumo = g.Key,
                ClienteConMayorConsumo = g.OrderByDescending(c => c.ConsumoAgua1).First()
            });

            foreach (var item in clienteConMayorConsumo)
            {
                clientes += "Mes: " + item.periodoConsumo + ", Cliente con mayor consumo: " + item.ClienteConMayorConsumo.Cedula + " ";
            }
            return clientes;
        }
    }
}