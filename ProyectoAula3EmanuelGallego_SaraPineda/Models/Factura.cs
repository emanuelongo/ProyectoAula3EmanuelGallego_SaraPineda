﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula3EmanuelGallego_SaraPineda
{
    public class Factura
    {
        private double valor_kilovatio;
        private double valor_mt3;

        public double Valor_kilovatio { get => valor_kilovatio; set => valor_kilovatio = value; }
        public double Valor_mt3 { get => valor_mt3; set => valor_mt3 = value; }

        public Factura()
        {
            this.Valor_kilovatio = 850;
            this.Valor_mt3 = 4600;
        }
        public double CalcularValorParcialEnergia(double kilovatios_consumidos)
        {
            double valor_parcial_energia = kilovatios_consumidos * Valor_kilovatio;
            return valor_parcial_energia;
        }

        public double CalcularValorIncentivoEnergia(double meta_energia, double kilovatios_consumidos)
        {
            double valor_incentivo = (meta_energia - kilovatios_consumidos) * Valor_kilovatio;
            return valor_incentivo;
        }

        public double CalcularValorAPagarEnergia(Usuario usuario)
        {
            double valor_parcial = CalcularValorParcialEnergia(usuario.ConsumoEnergia1);
            double valor_incentivo = CalcularValorIncentivoEnergia(usuario.MetaAhorroEnergia1, usuario.ConsumoEnergia1);

            double valor_total_a_pagar = valor_parcial - valor_incentivo;
            return valor_total_a_pagar;
        }

        public double CalcularValorParcialAgua(double mt3_consumidos, double promedio_consumo_agua)
        {
            double valor_parcial_agua = 0;
            if (mt3_consumidos > promedio_consumo_agua)
            {
                valor_parcial_agua += promedio_consumo_agua * Valor_mt3;
            }
            else
            {
                valor_parcial_agua += mt3_consumidos * Valor_mt3;
            }
            return valor_parcial_agua;
        }

        public double CalcularValorExcesoAgua(double mt3_consumidos, double promedio_consumo_agua)
        {
            double valor_exceso_agua = 0;
            if (mt3_consumidos > promedio_consumo_agua)
            {
                valor_exceso_agua += (mt3_consumidos - promedio_consumo_agua) * (2 * Valor_mt3);
            }
            return valor_exceso_agua;
        }

        public double CalcularValorAPagarAgua(Usuario usuario)
        {
            double valor_parcial = CalcularValorParcialAgua(usuario.ConsumoAgua1, usuario.PromedioConsumoAgua1);
            double valor_exceso = CalcularValorExcesoAgua(usuario.ConsumoAgua1, usuario.PromedioConsumoAgua1);

            double valor_total_a_pagar = valor_parcial + valor_exceso;
            return valor_total_a_pagar;
        }

        public double CalcularValorTotalAPagar(Usuario usuario)
        {
            double valor_total = CalcularValorAPagarEnergia(usuario) + CalcularValorAPagarAgua(usuario);
            return valor_total;
        }
    }
}
