using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerenciaT.Clases;

namespace HerenciaT.Banco
{
    /// <summary>
    /// DEGH 26/02/2026
    /// Este programa implementa un sistema de gestión de cuentas bancarias
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {

            CuentaAhorros ahorro = new CuentaAhorros("AH123", "Diana López", 0.05m);
            CuentaCorriente corriente = new CuentaCorriente("CC456", "Carlos Pérez", 50m, 1000m);
            CuentaNomina nomina = new CuentaNomina("CN789", "María Gómez", "TechCorp");


            ahorro.Depositar(2000);
            ahorro.Retirar(1700);
            ahorro.Retirar(1000);
            Console.WriteLine($"Intereses generados: {ahorro.CalcularIntereses():C}");
            ahorro.MostrarInformacion();

            Console.WriteLine();

            corriente.Depositar(500);
            corriente.Retirar(600);
            corriente.Retirar(2000);
            Console.WriteLine($"Intereses generados: {corriente.CalcularIntereses():C}");
            corriente.MostrarInformacion();

            Console.WriteLine();

            nomina.Depositar(3000);
            nomina.Retirar(1000); // Sin comisión
            Console.WriteLine($"Intereses generados: {nomina.CalcularIntereses():C}");
            nomina.MostrarInformacion();
        }
    }
}
