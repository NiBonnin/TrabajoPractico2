using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ejercicio4;

namespace Ejercicio4.Test
{
    [TestClass]
    public class ComplejoTest
    {
        Complejo t = new Complejo(5, 0);

        [TestMethod]
        public void EsRealTest()
        {
            Boolean mResultadoEsperado = true;
            Boolean mResultado;

            mResultado = t.EsReal();

            Assert.AreEqual(mResultadoEsperado, mResultado);
        }
    }
}
