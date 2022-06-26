using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoBancoNS
{
    /// <summary>
    /// Clase para trabajar en un banco
    /// <para>Se realizan retiradas de dinero</para>
    /// <papa>E ingresos</papa>
    /// </summary>
    public class Banco
    {
        /// <summary>
        /// Declaración de variables
        /// </summary>
        public const string CtaCongelada = "La cuenta está congelada";
        public const string CantidadMayorSaldo = "La cantidad que se quiere retirar es mayor que el saldo";
        public const string CantidadNegativa = "No se puede retirar una cantidad negativa";


        private string nombre;
        private double saldo;
        private bool congelada = false;

        public string Nombre { get => nombre; set => nombre = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public bool Congelada { get => congelada; set => congelada = value; }

        private Banco()
        {
        }
        public Banco(string nombre, double saldo)
        {
            this.nombre = nombre;
            this.saldo = saldo;
        }
        /// <summary>
        /// Método de retirada de dinero
        /// </summary>
        /// <param name="cantidadRetirada">La cantidad que se retira</param>
        /// <returns>Devuelve el saldo después de retirar una cantidad de dinero<see cref=">Saldo"/></returns>
        /// <exception cref="Exception">Salta una excepción si la cuenta está congelada</exception>
        /// <exception cref="ArgumentOutOfRangeException">Salta una excepción si la cantidad es mayor que el saldo</exception>
        /// <exception cref="ArgumentOutOfRangeException">Salta una excepción si la cantidad que se quiere retirar es negativa</exception>
        public void SacarDinero(double cantidadRetirada)
        {
            if (Congelada)
            {
                throw new Exception(CtaCongelada);
            }
            if (cantidadRetirada > Saldo)
            {
                throw new ArgumentOutOfRangeException(CantidadMayorSaldo);
            }
            if (cantidadRetirada < 0)
            {
                throw new ArgumentOutOfRangeException(CantidadNegativa);
            }
            Saldo -= cantidadRetirada; // intentionally incorrect code
        }
        public void Credit(double cantidadIngresada)
        {
            if (Congelada)
            {
                throw new Exception("Account frozen");
            }
            if (cantidadIngresada < 0)
            {
                throw new ArgumentOutOfRangeException("cantidadRetirada");
            }
            Saldo += cantidadIngresada;
        }
        public void CuentaCongelada()
        {
            Congelada = true;
        }
        public void CuentaLibre()
        {
            Congelada = false;
        }
        public static void Main()
        {
            Banco ba = new Banco("Mr. Bryan Walton", 11.99);
            ba.Credit(5.77);
            ba.SacarDinero(11.22);
            Console.WriteLine("Current saldo is ${0}", ba.Saldo);
        }
    }
}
