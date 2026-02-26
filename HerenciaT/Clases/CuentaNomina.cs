using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaT.Clases
{
    public class CuentaNomina : CuentaBancaria
    {
        public string Empresa { get; private set; }

        public CuentaNomina(string numeroCuenta, string titular, string empresa)
            : base(numeroCuenta, titular)
        {
            Empresa = empresa;
        }

        public override decimal CalcularIntereses() => Saldo * 0.01m;
    }
}
