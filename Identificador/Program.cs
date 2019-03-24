using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identificador.Classes;

namespace Identificador
{
    class Program
    {
        //Programa Principal
        public static void Main(string[] args)
        {
            Funcoes f = new Funcoes();

            //Criação das Listas

            //Indivíduos
            List<Individuo> individuos = new List<Individuo>(); 

            //Flores
            List<Individuo> ListSet = new List<Individuo>();
            List<Individuo> ListVer = new List<Individuo>();
            List<Individuo> ListVir = new List<Individuo>();

            //Zs
            List<Individuo> Z1 = new List<Individuo>();
            List<Individuo> Z2 = new List<Individuo>();
            List<Individuo> Z3 = new List<Individuo>();

            //Resultados
            List<Indicadores> ResultadoTestes = new List<Indicadores>();

            //Chamar a função para carregar a base de dados e alimentar a database
            string[] database = f.CarregarDataBase();

            //Indivíduo
            individuos = f.SeparadorDeAtributos(database); //Chamar a função para tratar os dados
            int quantidadeIndividuos = individuos.Count(); //Definir a quantidade de indivíduos

            //Auxiliar
            int k = 33;

            string opcao;
            do
            {
                Console.WriteLine();

                opcao = Console.ReadLine();

                if (opcao=="1")
                {

                }

                if (opcao == "2")
                {

                }

            } while (opcao != "0");

            for (int i = 1; i <= 30; i++) //Quantidade de Repetição dos Testes
            {
                //Zerar Indicadores
                int acertos = 0, erros = 0;
                double taxaDeAcerto = 0;

                //Alimentar as Listas das Flores
                foreach (var indv in individuos)
                {
                    if (indv.classe == "Iris-setosa")
                    {
                        ListSet.Add(indv);
                        continue;
                    }
                    if (indv.classe == "Iris-virginica")
                    {
                        ListVir.Add(indv);
                        continue;
                    }
                    if (indv.classe == "Iris-versicolor")
                    {
                        ListVer.Add(indv);
                        continue;
                    }
                }

                //Dividir os Zs
                Random randNum = new Random();
                Individuo AuxAdd;

                //Setosa
                //Add 25% no Z1
                while (Z1.Count() < 13) 
                {
                    AuxAdd = ListSet.ElementAt(randNum.Next(ListSet.Count() - 1));
                    if (!AuxAdd.usado)
                    {
                        AuxAdd.usado = true;
                        Z1.Add(AuxAdd);
                    }
                }
                //Add 25% no Z2
                while (Z2.Count() < 13)
                {

                    AuxAdd = ListSet.ElementAt(randNum.Next(ListSet.Count() - 1));
                    if (!AuxAdd.usado)
                    {
                        AuxAdd.usado = true;
                        Z2.Add(AuxAdd);
                    }
                }
                //Add 50% no Z3
                while (Z3.Count() < 24)
                {
                    AuxAdd = ListSet.Where(c => c.usado == false).First();
                    AuxAdd.usado = true;
                    Z3.Add(AuxAdd);
                }

                //Versicolor
                //Add 25% no Z1
                while (Z1.Count() < 26)
                {
                    AuxAdd = ListVer.ElementAt(randNum.Next(ListVer.Count() - 1));
                    if (!AuxAdd.usado)
                    {
                        AuxAdd.usado = true;
                        Z1.Add(AuxAdd);
                    }
                }
                //Add 25% no Z2
                while (Z2.Count() < 26)
                {
                    AuxAdd = ListVer.ElementAt(randNum.Next(ListVer.Count() - 1));
                    if (!AuxAdd.usado)
                    {
                        AuxAdd.usado = true;
                        Z2.Add(AuxAdd);
                    }
                }
                //Add 50% no Z3
                while (Z3.Count() < 48)
                {
                    AuxAdd = ListVer.Where(c => c.usado == false).First();
                    AuxAdd.usado = true;
                    Z3.Add(AuxAdd);
                }

                //Virginica
                //Add 25% no Z1
                while (Z1.Count() < 38)
                {
                    AuxAdd = ListVir.ElementAt(randNum.Next(ListVir.Count() - 1));
                    if (!AuxAdd.usado)
                    {
                        AuxAdd.usado = true;
                        Z1.Add(AuxAdd);
                    }
                }
                //Add 25% no Z2
                while (Z2.Count() < 38)
                {
                    AuxAdd = ListVir.ElementAt(randNum.Next(ListVir.Count() - 1));
                    if (!AuxAdd.usado)
                    {
                        AuxAdd.usado = true;
                        Z2.Add(AuxAdd);
                    }
                }
                //Add 50% no Z3
                while (Z3.Count() < 74)
                {
                    AuxAdd = ListVir.Where(c => c.usado == false).First();
                    AuxAdd.usado = true;
                    Z3.Add(AuxAdd);
                }

                //Puxar Dados para iniciar o Treino
                string[] classeObtida = f.ClassificadorDeAmostras(Z1, Z2, k);
                int j = 0;
                Individuo auxTroca = null, auxTroca2 = null;

                //Verifica os erros do Z1
                foreach (var metricaAcertos in Z1)
                {
                    if (metricaAcertos.classe != classeObtida[j])
                    {
                        metricaAcertos.errado = true;
                    }
                    //indicador de posição da classe - Ou seja, auxiliar do Foreach
                    j++;
                }

                //Faz a troca dos erros por uma outra variável com a mesma classe
                while (Z1.Any(e => e.errado == true))
                {
                    auxTroca = Z1.Where(e => e.errado == true).First();
                    auxTroca2 = Z2.Where(c => c.classe == auxTroca.classe).First();
                    Z1.Remove(auxTroca);
                    Z2.Remove(auxTroca2);
                    auxTroca.trocado = true;
                    auxTroca.errado = false;
                    auxTroca2.trocado = true;
                    Z1.Add(auxTroca2);
                    Z2.Add(auxTroca);
                }

                //Limpar as Variáveis
                foreach (var limpZ1 in Z1)
                {
                    limpZ1.trocado = false;
                    limpZ1.usado = false;
                }
                foreach (var limpZ2 in Z2)
                {
                    limpZ2.trocado = false;
                    limpZ2.usado = false;
                }

                //Validar Z3 com Z2 e retorna os resultados.
                classeObtida = f.ClassificadorDeAmostras(Z3, Z2, k);

                //Verifica os acertos em Z3
                j = 0;
                foreach (var metricaAcertos in Z3)
                {
                    if (metricaAcertos.classe == classeObtida[j])
                    {
                        acertos++;
                    }
                    else
                    {
                        erros++;
                    }
                    j++; //auxiliar
                }

                //Salvar os Resultados dos Testes
                taxaDeAcerto = (acertos * 100) / Z3.Count();
                Indicadores indicador = new Indicadores(acertos, erros, taxaDeAcerto);
                ResultadoTestes.Add(indicador);

                //Informação do Console
                Console.WriteLine("Rodada nº" + i + "...\n" + "Taxa de Acerto: " + taxaDeAcerto + "% " + "K:" + k);

                k--; //Diminuir o contador
            }

            //Calcular o Resultado Final
            double soma = 0, media, desvioPadrao;
            foreach (var baseDeCalculo in ResultadoTestes)
            {
                soma += baseDeCalculo.taxaDeAcerto;
            }
            media = soma / ResultadoTestes.Count();
            soma = 0;
            foreach (var baseDeCalculo in ResultadoTestes)
            {
                soma += Math.Pow((baseDeCalculo.taxaDeAcerto - media), 2);
            }
            desvioPadrao = Math.Sqrt(soma / ResultadoTestes.Count());

            //Mostrar o Resultado Final
            Console.WriteLine("");
            Console.WriteLine("+------------------------------------------+");
            Console.WriteLine("Média:" + media);
            Console.WriteLine("Desvio Padrão:" + desvioPadrao);
            Console.WriteLine("+------------------------------------------+");
            Console.ReadKey();
        }
    }
}
