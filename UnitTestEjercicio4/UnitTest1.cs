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
        public void RealTest()
        {
            double mResultadoEsperado = 5;
            double mResultado;

            mResultado = t.Real;

            Assert.AreEqual(mResultadoEsperado, mResultado);
        }

        [TestMethod]
        public void ImaginarioTest()
        {
            double mResultadoEsperado = 0;
            double mResultado;

            mResultado = t.Imaginario;

            Assert.AreEqual(mResultadoEsperado, mResultado);
        }

        [TestMethod]
        public void ArgumentoEnRadianesTest()
        {
            double mResultadoEsperado = 0;
            double mResultado;

            mResultado = t.ArgumentoEnRadianes;

            Assert.AreEqual(mResultadoEsperado, mResultado);
        }

        [TestMethod]
        public void ArgumentoEnGradosTest()
        {
            double mResultadoEsperado = 0;
            double mResultado;

            mResultado = t.ArgumentoEnGrados;

            Assert.AreEqual(mResultadoEsperado, mResultado);
        }

        [TestMethod]
        public void ConjugadoTest()
        {
            Complejo p = new Complejo(5, 0);
            Complejo mResultadoEsperado = p;
            Complejo mResultado;

            mResultado = t.Conjugado;

            Assert.IsTrue((t.Real == p.Real) & (t.Imaginario == p.Imaginario));
        }

        [TestMethod]
        public void MagnitudTest()
        {
            double mResultadoEsperado = 5;
            double mResultado;

            mResultado = t.Magnitud;

            Assert.AreEqual(mResultadoEsperado, mResultado);
        }

        [TestMethod]
        public void EsRealTest()
        {
            Boolean mResultadoEsperado = true;
            Boolean mResultado;

            mResultado = t.EsReal();

            Assert.AreEqual(mResultadoEsperado, mResultado);
        }

        [TestMethod]
        public void EsImaginarioTest()
        {
            Boolean mResultadoEsperado = false;
            Boolean mResultado;

            mResultado = t.EsImaginario();

            Assert.AreEqual(mResultadoEsperado, mResultado);
        }

        [TestMethod]
        public void EsIgualTest1()
        {
            double pReal = 5;
            double pImaginario = 3;
            Boolean mResultadoEsperado = false;
            Boolean mResultado;

            mResultado = t.EsIgual(pReal,pImaginario);

            Assert.AreEqual(mResultadoEsperado, mResultado);
        }

        [TestMethod]
        public void EsIgualTest2()
        {
            Complejo p = new Complejo(5, 0);
            Boolean mResultadoEsperado = true;
            Boolean mResultado;

            mResultado = t.EsIgual(p);

            Assert.AreEqual(mResultadoEsperado, mResultado);
        }

        [TestMethod]
        public void SumarTest()
        {
            Complejo p = new Complejo(4, 5);
            Complejo p1 = new Complejo(9, 5);
            Complejo mResultadoEsperado = p1;
            Complejo mResultado;

            mResultado = t.Sumar(p);

            Assert.IsTrue(mResultadoEsperado.Imaginario == mResultado.Imaginario);
            Assert.IsTrue(mResultadoEsperado.Real == mResultado.Real);
        }

        [TestMethod]
        public void RestarTest()
        {
            Complejo p = new Complejo(4, 5);
            Complejo p1 = new Complejo(1, -5);
            Complejo mResultadoEsperado = p1;
            Complejo mResultado;

            mResultado = t.Restar(p);

            Assert.IsTrue(mResultadoEsperado.Imaginario == mResultado.Imaginario);
            Assert.IsTrue(mResultadoEsperado.Real == mResultado.Real);
        }

        [TestMethod]
        public void DividirPorTest()
        {
            Complejo p = new Complejo(0, 0);
            Complejo p1 = new Complejo(20/41 , -25/41);
            Complejo mResultadoEsperado = p1;
            Complejo mResultado;

            mResultado = t.DividirPor(p);

            Assert.IsTrue(mResultadoEsperado.Imaginario == mResultado.Imaginario);
            Assert.IsTrue(mResultadoEsperado.Real == mResultado.Real);
        }

        [TestMethod]
        public void MultiplicarPorTest()
        {
            Complejo p = new Complejo(4, 5);
            Complejo p1 = new Complejo(20,25);
            Complejo mResultadoEsperado = p1;
            Complejo mResultado;

            mResultado = t.MultiplicarPor(p);

            Assert.IsTrue(mResultadoEsperado.Imaginario == mResultado.Imaginario);
            Assert.IsTrue(mResultadoEsperado.Real == mResultado.Real);
        }

    }
}
