using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula3EmanuelGallego_SaraPineda
{
    public class Epm
    {
        private List<Usuario> DatosDeUsuario;
        private Factura factura;

        public List<Usuario> DatosDeUsuarios { get => DatosDeUsuario; set => DatosDeUsuario = value; }
        public Factura Factura { get => factura; set => factura = value; }

        public Epm()
        {
            this.DatosDeUsuario = new List<Usuario>();
        }

        public void AgregarCliente(Usuario usuario)
        {
            DatosDeUsuario.Add(usuario);
        }

        public void EliminarCliente(Usuario usuario)
        {
            DatosDeUsuario.Remove(usuario);
        }

        public double CacularPromedioConsumoDeEnergia()
        {
            double sumatoria = 0;

            for (int i = 0; i < DatosDeUsuario.Count; i++)
            {
                sumatoria = sumatoria + DatosDeUsuario[i].ConsumoEnergia1;
            }

            double promedio = sumatoria / DatosDeUsuario.Count;
            return promedio;
        }

        public double CalcularTotalDescuentosPorIncentivoDeEnergia()
        {
            double descuento_total_incentivo = 0;
            foreach (Usuario usuario in DatosDeUsuario)
            {
                if (usuario.MetaAhorroEnergia1 > usuario.ConsumoEnergia1)
                {
                    descuento_total_incentivo += factura.CalcularValorIncentivoEnergia(usuario.MetaAhorroEnergia1, usuario.ConsumoEnergia1);
                }

            }

            return descuento_total_incentivo;
        }

        public double CalcularTotalM3AguaEncimaPromedio()
        {
            double m3_agua_encima_promedio = 0;

            foreach (Usuario usuario in DatosDeUsuario)
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

            foreach (Usuario usuario in DatosDeUsuario)
            {
                if (usuario.ConsumoAgua1 > usuario.PromedioConsumoAgua1)
                {
                    clientes_consumo_agua_encima_promedio += 1;
                }

            }
            return clientes_consumo_agua_encima_promedio;
        }

        public double ConusltarPorcentajeConsumoAguaPorEstrato(int estrato)
        {
            double suma_total_exceso_agua_ = CalcularTotalM3AguaEncimaPromedio();
            double suma_exceso_agua_por_estrato = 0;

            foreach (Usuario usuario in DatosDeUsuario)
            {
                if (usuario.Estrato == estrato)
                {
                    suma_exceso_agua_por_estrato += factura.CalcularValorExcesoAgua(usuario.ConsumoAgua1, usuario.PromedioConsumoAgua1);
                }

            }

            return (suma_total_exceso_agua_ / suma_exceso_agua_por_estrato) * 100;
        }

        public Usuario MostrarDatosClienteConMayorDesfaseEnergia()
        {
            Usuario UsuarioMayorDesfase = null;
            int DesfaseEnergia = 0;
            foreach (Usuario usuario in DatosDeUsuario)
            {
                if (usuario.ConsumoEnergia1 - usuario.MetaAhorroEnergia1 > DesfaseEnergia)
                {
                    UsuarioMayorDesfase = usuario;
                    DesfaseEnergia = usuario.ConsumoEnergia1 - usuario.MetaAhorroEnergia1;
                }
            }
            return UsuarioMayorDesfase;
        }

        public int MostrarEstratoConMayorAhorroAgua()
        {
            int EstratoMayorAhorrador = 0;
            int AhorroAgua = 0;
            foreach (Usuario usuario in DatosDeUsuario)
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
            foreach (Usuario usuario in DatosDeUsuario)
            {
                if (usuario.ConsumoEnergia1 - usuario.MetaAhorroEnergia1 > MayorGastoEnergia)
                {
                    EstratoMayorConsumidor = usuario.Estrato;
                    MayorGastoEnergia = usuario.ConsumoEnergia1 - usuario.MetaAhorroEnergia1;
                }
            }
            return EstratoMayorConsumidor;
        }

        public int MostrarEstratoConMenorConsumoEnergia()
        {
            int EstratoMenorConsumidor = 0;
            int MenorGastoEnergia = 1000;
            foreach (Usuario usuario in DatosDeUsuario)
            {
                if (usuario.ConsumoEnergia1 - usuario.MetaAhorroEnergia1 > MenorGastoEnergia && usuario.ConsumoEnergia1 - usuario.MetaAhorroEnergia1 > 0)
                {
                    EstratoMenorConsumidor = usuario.Estrato;
                    MenorGastoEnergia = usuario.ConsumoEnergia1 - usuario.MetaAhorroEnergia1;
                }
            }
            return EstratoMenorConsumidor;
        }

        public double CalcularTotalPagadoEmpresaPorConsumoTotal()
        {
            double TotalPagadoAcumulado = 0;
            foreach (Usuario usuario in DatosDeUsuario)
            {
                TotalPagadoAcumulado += factura.CalcularValorAPagarEnergia(usuario) + factura.CalcularValorAPagarAgua(usuario);
            }
            return TotalPagadoAcumulado;
        }
        public Usuario CalcularClienteMayorConsumoAgua(int periodoConsumo)
        {
            Usuario UsuarioMayorConsumo = null;
            int ConsumoMayorAgua = 0;
            foreach (Usuario usuario in DatosDeUsuario)
            {
                if (periodoConsumo == usuario.PeriodoConsumo)
                {
                    if (usuario.ConsumoAgua1 > ConsumoMayorAgua)
                    {
                        UsuarioMayorConsumo = usuario;
                        ConsumoMayorAgua = usuario.ConsumoAgua1;
                    }
                }
            }
            return UsuarioMayorConsumo;
        }
    }
}