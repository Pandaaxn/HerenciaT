using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaT.Banco
{
    
    public class CuentaBancaria
    {
        public string NumeroCuenta { get; private set; }
        public string Titular { get; private set; }
        public decimal Saldo { get; protected set; }

        public CuentaBancaria(string numeroCuenta, string titular)
        {
            NumeroCuenta = numeroCuenta;
            Titular = titular;
            Saldo = 0;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Cuenta: {NumeroCuenta} | Titular: {Titular} | Saldo: {Saldo:C}");
        }

        public void Depositar(decimal monto)
        {
            if (monto > 0)
            {
                Saldo += monto;
                Console.WriteLine($"Depósito de {monto:C} realizado. Nuevo saldo: {Saldo:C}");
            }
            else
            {
                Console.WriteLine("El monto a depositar debe ser positivo.");
            }
        }

        public virtual void Retirar(decimal monto)
        {
            if (monto <= Saldo)
            {
                Saldo -= monto;
                Console.WriteLine($"Retiro de {monto:C} realizado. Nuevo saldo: {Saldo:C}");
            }
            else
            {
                Console.WriteLine("Fondos insuficientes.");
            }
        }

        public virtual decimal CalcularIntereses()
        {
            return 0;
        }
    }

    

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
            {
                base.Retirar(monto);
            }
            else
            {
                Console.WriteLine("No se puede retirar. El saldo mínimo de $500 debe mantenerse.");
            }
        }

        public override decimal CalcularIntereses()
        {
            return Saldo * TasaInteres;
        }
    }

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
                Console.WriteLine($"Retiro de {monto:C} realizado. Nuevo saldo: {Saldo:C}");

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

        public override decimal CalcularIntereses()
        {
            return 0; 
        }
    }

    public class CuentaNomina : CuentaBancaria
    {
        public string Empresa { get; private set; }

        public CuentaNomina(string numeroCuenta, string titular, string empresa)
            : base(numeroCuenta, titular)
        {
            Empresa = empresa;
        }

        public override decimal CalcularIntereses()
        {
            return Saldo * 0.01m; // 1% mensual
        }

        
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            // Crear cuentas
            CuentaAhorros ahorro = new CuentaAhorros("AH123", "Diana López", 0.05m);
            CuentaCorriente corriente = new CuentaCorriente("CC456", "Carlos Pérez", 50m, 1000m);
            CuentaNomina nomina = new CuentaNomina("CN789", "María Gómez", "TechCorp");

            // Operaciones
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
