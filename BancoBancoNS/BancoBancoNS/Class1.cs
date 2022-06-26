﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoBancoNS
{
    public class Banco
    {
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
        public void SacarDinero(double cantidadRetirada)
        {
            if (Congelada)
            {
                throw new Exception("Account frozen");
            }
            if (cantidadRetirada > Saldo)
            {
                throw new ArgumentOutOfRangeException("cantidadRetirada");
            }
            if (cantidadRetirada < 0)
            {
                throw new ArgumentOutOfRangeException("cantidadRetirada");
            }
            Saldo += cantidadRetirada; // intentionally incorrect code
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
