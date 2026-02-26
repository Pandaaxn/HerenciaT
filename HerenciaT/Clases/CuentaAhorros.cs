using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaT.Clases
{
    public class CuentaAhorros : CuentaBancaria
    {
        public decimal TasaInteres { get; private set; }

        public CuentaAhorros(string numeroCuenta, string titular, decimal tasaInteres)
            : base(numeroCuenta, titular)
        {
            TasaInteres = tasaInteres;
        }

        public override void Retirar(decimal monto)
        {
            if (Saldo - monto >= 500)
                base.Retirar(monto);
            else
                Console.WriteLine("No se puede retirar. El saldo mínimo de $500 debe mantenerse.");
        }

        public override decimal CalcularIntereses() => Saldo * TasaInteres;
    }
}
