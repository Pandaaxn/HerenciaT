using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaT.Clases
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
}
