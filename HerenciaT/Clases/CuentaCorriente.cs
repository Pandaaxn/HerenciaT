using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaT.Clases
{
    public class CuentaCorriente : CuentaBancaria
    {
        public decimal ComisionMensual { get; private set; }
        public decimal LimiteSobregiro { get; private set; }

        public CuentaCorriente(string numeroCuenta, string titular, decimal comisionMensual, decimal limiteSobregiro)
            : base(numeroCuenta, titular)
        {
            ComisionMensual = comisionMensual;
            LimiteSobregiro = limiteSobregiro;
        }

        public override void Retirar(decimal monto)
        {
            if (Saldo - monto >= -LimiteSobregiro)
            {
                Saldo -= monto;
                if (Saldo < 0)
                {
                    Saldo -= 20;
                    Console.WriteLine("Se aplicó una comisión de $20 por sobregiro.");
                }
            }
            else
            {
                Console.WriteLine("El monto excede el límite de sobregiro permitido.");
            }
        }

        public override decimal CalcularIntereses() => 0;
    }
}
