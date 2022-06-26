using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BancoBancoNS;

namespace BancoPrueba
{
    [TestClass]
    public class UnitTest1
    {
       

        [TestMethod]
        public void PruebaRetiradaCorrecta()
        {
            Banco retirada = new Banco("Mr. Bryan Walton", 11.99);
            retirada.SacarDinero(11.22);
            double cantidadEsperada = 0.77;

            Assert.AreEqual(cantidadEsperada, retirada.Saldo, 0.001, "El valor no es el esperado");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), Banco.CtaCongelada)]
        public void PruebaCuentaCongelada()
        {
            Banco retirada = new Banco("Mr. Bryan Walton", 11.99);
            retirada.CuentaCongelada();
            retirada.SacarDinero(11.22);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),Banco.CantidadMayorSaldo)]
        public void PruebaRetiradaMayorSaldo()
        {
            Banco retirada = new Banco("Mr. Bryan Walton", 11.99);
            retirada.SacarDinero(20.22);
        }

        [TestMethod]
        public void CantidadNegativa()
        {
            Banco retirada = new Banco("Mr. Bryan Walton", 11.99);
            try
            {
                retirada.SacarDinero(-20.22);
            }
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, Banco.CantidadNegativa);
                return;
            }
            Assert.Fail("Error");
        }
    }
    
}
