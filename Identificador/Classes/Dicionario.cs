using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identificador;

namespace Identificador.Classes
{
    //Declarar Indivíduos
    public class Individuo
    {
        private string classe1;
        private double a1, b1, c1, d1, e1;
        private bool trocado1;
        private bool usado1;
        private bool errado1;

        public Individuo(string classe, double a, double b, double c, double d, double e)
        {
            a1 = a;
            b1 = b;
            c1 = c;
            d1 = d;
            e1 = e;
            classe1 = classe;
            trocado1 = false;
        }
        public double a
        {
            get
            {
                return a1;
            }
            set
            {
                a1 = value;
            }
        }
        public double b
        {
            get
            {
                return b1;
            }
            set
            {
                b1 = value;
            }
        }
        public double c
        {
            get
            {
                return c1;
            }
            set
            {
                c1 = value;
            }
        }
        public double d
        {
            get
            {
                return d1;
            }
            set
            {
                d1 = value;
            }
        }
        public double e
        {
            get
            {
                return e1;
            }
            set
            {
                e1 = value;
            }
        }
        public string classe
        {
            get
            {
                return classe1;
            }
            set
            {
                classe1 = value;
            }
        }
        public bool trocado
        {
            get
            {
                return trocado1;
            }
            set
            {
                trocado1 = value;
            }
        }
        public bool usado
        {
            get
            {
                return usado1;
            }
            set
            {
                usado1 = value;
            }
        }
        public bool errado
        {
            get
            {
                return errado1;
            }
            set
            {
                errado1 = value;
            }
        }
    }

    //Declarar Indicadores
    public class Indicadores
    {
        private int acertos1;
        private int erros1;
        private double taxaDeAcerto1;

        public int acertos
        {
            get
            {
                return acertos1;
            }
            set
            {
                acertos1 = value;
            }
        }
        public int erros
        {
            get
            {
                return erros1;
            }
            set
            {
                erros1 = value;
            }
        }
        public double taxaDeAcerto
        {
            get
            {
                return taxaDeAcerto1;
            }
            set
            {
                taxaDeAcerto1 = value;
            }
        }

        public Indicadores(int acertos, int erros, double taxaDeAcerto)
        {
            acertos1 = acertos;
            erros1 = erros;
            taxaDeAcerto1 = taxaDeAcerto;
        }
    }
}
