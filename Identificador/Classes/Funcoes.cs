﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identificador;

namespace Identificador.Classes
{
    public class Funcoes
    {
        //Importar Base de Dados
        public string[] CarregarDataBase()
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Iris.txt");
            return lines;
        }
        public string[] CarregarDataBase2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Balance.txt");
            return lines;
        }
        public string[] CarregarDataBase3()
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Hayes-Roth.txt");
            return lines;
        }

        //Classificação das Amostras para Treino Iris
        public string[] ClassificadorDeAmostras(List<Individuo> C1, List<Individuo> C2, int k)
        {
            if (k % 2 == 0) //Evitar que o k seja par, para que não haja empates de distâncias
            {
                k--;
                k = k <= 0 ? 1 : k;
            }

            var tam = C1.Count();
            string[] classesC1 = new string[tam];
            int posicao = 0;
            foreach (var elemento1 in C1)
            {
                var distanciaIndividuos = new List<KeyValuePair<double, Individuo>>();
                foreach (var elemento2 in C2)
                {
                    double distancia = obterDistanciaEuclidiana(elemento1, elemento2);
                    distanciaIndividuos.Add(new KeyValuePair<double, Individuo>(distancia, elemento2));
                }
                distanciaIndividuos.Sort((x, y) => x.Key.CompareTo(y.Key));

                int contador1 = 0, contador2 = 0, contador3 = 0;
                for (int i = 0; i < k; i++)
                {
                    string classe = distanciaIndividuos[i].Value.classe;

                    if (classe == "Iris-setosa")
                        contador1++;
                    if (classe == "Iris-versicolor")
                        contador3++;
                    if (classe == "Iris-virginica")
                        contador2++;
                }
                string classeClassificacao;
                if (contador1 >= contador3 && contador1 >= contador2)
                    classeClassificacao = "Iris-setosa";
                else if (contador3 >= contador1 && contador3 >= contador2)
                    classeClassificacao = "Iris-versicolor";
                else
                    classeClassificacao = "Iris-virginica";
                classesC1[posicao] = classeClassificacao;
                posicao++;
                distanciaIndividuos = null;
            }
            return classesC1;
        }

        //Classificação das Amostras para Treino Balance
        public string[] ClassificadorDeAmostras2(List<Individuo> C1, List<Individuo> C2, int k)
        {
            if (k % 2 == 0) //Evitar que o k seja par, para que não haja empates de distâncias
            {
                k--;
                k = k <= 0 ? 1 : k;
            }

            var tam = C1.Count();
            string[] classesC1 = new string[tam];
            int posicao = 0;
            foreach (var elemento1 in C1)
            {
                var distanciaIndividuos = new List<KeyValuePair<double, Individuo>>();
                foreach (var elemento2 in C2)
                {
                    double distancia = obterDistanciaEuclidiana(elemento1, elemento2);
                    distanciaIndividuos.Add(new KeyValuePair<double, Individuo>(distancia, elemento2));
                }
                distanciaIndividuos.Sort((x, y) => x.Key.CompareTo(y.Key));

                int contadorSet = 0, contadorVir = 0, contadorVer = 0;
                for (int i = 0; i < k; i++)
                {
                    string classe = distanciaIndividuos[i].Value.classe;

                    if (classe == "B")
                        contadorSet++;
                    if (classe == "L")
                        contadorVer++;
                    if (classe == "R")
                        contadorVir++;
                }
                string classeClassificacao;
                if (contadorSet >= contadorVer && contadorSet >= contadorVir)
                    classeClassificacao = "B";
                else if (contadorVer >= contadorSet && contadorVer >= contadorVir)
                    classeClassificacao = "L";
                else
                    classeClassificacao = "R";
                classesC1[posicao] = classeClassificacao;
                posicao++;
                distanciaIndividuos = null;
            }
            return classesC1;
        }

        //Classificação das Amostras para Treino Hayes-Roth
        public string[] ClassificadorDeAmostras3(List<Individuo> C1, List<Individuo> C2, int k)
        {
            if (k % 2 == 0) //Evitar que o k seja par, para que não haja empates de distâncias
            {
                k--;
                k = k <= 0 ? 1 : k;
            }

            var tam = C1.Count();
            string[] classesC1 = new string[tam];
            int posicao = 0;
            foreach (var elemento1 in C1)
            {
                var distanciaIndividuos = new List<KeyValuePair<double, Individuo>>();
                foreach (var elemento2 in C2)
                {
                    double distancia = obterDistanciaEuclidiana(elemento1, elemento2);
                    distanciaIndividuos.Add(new KeyValuePair<double, Individuo>(distancia, elemento2));
                }
                distanciaIndividuos.Sort((x, y) => x.Key.CompareTo(y.Key));

                int contador1 = 0, contador2 = 0, contador3 = 0;
                for (int i = 0; i < k; i++)
                {
                    string classe = distanciaIndividuos[i].Value.classe;

                    if (classe == "1")
                        contador1++;
                    if (classe == "2")
                        contador3++;
                    if (classe == "3")
                        contador2++;
                }
                string classeClassificacao;
                if (contador1 >= contador3 && contador1 >= contador2)
                    classeClassificacao = "1";
                else if (contador3 >= contador1 && contador3 >= contador2)
                    classeClassificacao = "2";
                else
                    classeClassificacao = "3";
                classesC1[posicao] = classeClassificacao;
                posicao++;
                distanciaIndividuos = null;
            }
            return classesC1;
        }

        //Calculo de Distância
        public static double obterDistanciaEuclidiana(Individuo ind1, Individuo ind2)
        {
            double soma = Math.Pow((ind1.a - ind2.a), 2)
                        + Math.Pow((ind1.b - ind2.b), 2)
                        + Math.Pow((ind1.c - ind2.c), 2)
                        + Math.Pow((ind1.d - ind2.d), 2)
                        + Math.Pow((ind1.e - ind2.e), 2);
                   return Math.Sqrt(soma);
        }

        //Tratar os dados Importados Iris
        public List<Individuo> SeparadorDeAtributos(string[] dataBase)
        {
            List<Individuo> individuos = new List<Individuo>();

            foreach (var dados in dataBase)
            {
                string[] colunas = dados.Split(',');
                string classe = colunas[4];
                double a = Convert.ToDouble(colunas[0]), b = Convert.ToDouble(colunas[1]), c = Convert.ToDouble(colunas[2]), d = Convert.ToDouble(colunas[3]), e = 0;

                Individuo individuo = new Individuo(classe, a, b, c, d, e);
                individuos.Add(individuo);
            }
            return individuos;
        }

        //Tratar os dados Importados Balance
        public List<Individuo> SeparadorDeAtributos2(string[] dataBase)
        {
            List<Individuo> individuos = new List<Individuo>();

            foreach (var dados in dataBase)
            {
                string[] colunas = dados.Split(',');
                string classe = colunas[0];
                double a = Convert.ToDouble(colunas[1]), b = Convert.ToDouble(colunas[2]), c = Convert.ToDouble(colunas[3]), d = Convert.ToDouble(colunas[4]), e=0;

                Individuo individuo = new Individuo(classe, a, b, c, d,e);
                individuos.Add(individuo);
            }
            return individuos;
        }

        //Tratar os dados Importados Hayes-Roth
        public List<Individuo> SeparadorDeAtributos3(string[] dataBase)
        {
            List<Individuo> individuos = new List<Individuo>();

            foreach (var dados in dataBase)
            {
                string[] colunas = dados.Split(',');
                string classe = colunas[5];
                double a = Convert.ToDouble(colunas[0]), b = Convert.ToDouble(colunas[1]), c = Convert.ToDouble(colunas[2]), d = Convert.ToDouble(colunas[3]), e = Convert.ToDouble(colunas[4]);

                Individuo individuo = new Individuo(classe, a, b, c, d, e);
                individuos.Add(individuo);
            }
            return individuos;
        }
    }
}