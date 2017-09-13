using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
   public class Complejo
    {
        private readonly double iReal, iImaginario=0;

        public Complejo (double pReal, double pImaginario)
        {
            this.iReal = pReal;
            this.iImaginario = pImaginario;
        }

        public double Real
        {
            get { return this.iReal; }
        }

        public double Imaginario
        {
            get { return this.iImaginario; }
        }

        public double ArgumentoEnRadianes
        {
            get { return Math.Atan2(this.iImaginario , this.iReal); }
        }

        public double ArgumentoEnGrados
        {
            get { return Math.Atan2(this.iImaginario, this.iReal) * 180; }
        }

        public Complejo Conjugado
        {
            get {return new Complejo (this.iReal , this.iImaginario * -1); }
        }

        public double Magnitud
        {
            get { return Math.Sqrt(Math.Pow(this.iReal, 2) + Math.Pow(this.iImaginario, 2)); }
        }

        public Boolean EsReal()
        {
            if (this.iImaginario == 0)
            {
                return true;
            }
            return false;
        }

        public Boolean EsImaginario()
        {
            if (this.iImaginario != 0)
            {
                return true;
            }
            return false;
        }

        public Boolean EsIgual(Complejo pN)
        {
            if ((pN.iReal == this.iReal)&(pN.iImaginario == this.iImaginario))
            {
                return true;
            }
            return false;
        }

        public Boolean EsIgual(double pReal , double pImaginario)
        {
            if ((pReal == this.iReal) & (pImaginario == this.iImaginario))
            {
                return true;
            }
            return false;
        }

        public Complejo Sumar (Complejo c)
        {
            Complejo c1 = new Complejo(this.iReal + c.iReal, this.iImaginario + c.iImaginario);
            return c1;
        }

        public Complejo Restar(Complejo c)
        {
            Complejo c1 = new Complejo(this.iReal - c.iReal, this.iImaginario - c.iImaginario);
            return c1;
        }

        public Complejo MultiplicarPor(Complejo c)
        {
            Complejo c1 = new Complejo((this.iReal * c.iReal) - (this.iImaginario * c.iImaginario), (this.iReal * c.iImaginario) + (this.iImaginario * c.iReal));
            return c1;
        }

        public Complejo DividirPor(Complejo c)
        {
            Complejo c1 = new Complejo(((this.iReal * c.iReal) + (this.iImaginario * c.iImaginario)) / (Math.Pow(c.iReal , 2) + Math.Pow(c.iImaginario, 2)), ((this.iImaginario * c.iReal) - (this.iReal * c.iImaginario)) / (Math.Pow(c.iReal, 2) + Math.Pow(c.iImaginario, 2)));
            return c1;
        }

    }
}
