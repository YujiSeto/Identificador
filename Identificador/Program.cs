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
            //Parâmetros
            Funcoes f = new Funcoes();

            //Criação das Listas

            //Indivíduos
            List<Individuo> individuos = new List<Individuo>(); 

            //Flores
            List<Individuo> ListSet = new List<Individuo>();
            List<Individuo> ListVir = new List<Individuo>();
            List<Individuo> ListVer = new List<Individuo>();

            //Balança
            List<Individuo> ListB = new List<Individuo>();
            List<Individuo> ListL = new List<Individuo>();
            List<Individuo> ListR = new List<Individuo>();

            //
            List<Individuo> List1 = new List<Individuo>();
            List<Individuo> List3 = new List<Individuo>();
            List<Individuo> List2 = new List<Individuo>();

            //Zs
            List<Individuo> Z1 = new List<Individuo>();
            List<Individuo> Z2 = new List<Individuo>();
            List<Individuo> Z3 = new List<Individuo>();

            //Resultados
            List<Indicadores> ResultadoTestes = new List<Indicadores>();

            //Auxiliar
            int k = 33;
            string opcao;
            string opcao2;

            do
            {
                Console.Clear();
                Console.WriteLine("+--------------------------------------+");
                Console.WriteLine("|       Select an option               |");
                Console.WriteLine("|  1  - Import Iris Dataset            |");
                Console.WriteLine("|  2  - Import Balance Dataset         |");
                Console.WriteLine("|  3  - Import Hayes-Roth Dataset      |");
                Console.WriteLine("|  0  - Quit Program                   |");
                Console.WriteLine("+--------------------------------------+");

                opcao = Console.ReadLine();

                //Importar Base de Dados Iris
                if (opcao == "1")
                {
                    string[] database = f.CarregarDataBase(); //Chamar a função para carregar a base de dados e alimentar a database

                    individuos = f.SeparadorDeAtributos(database); //Chamar a função para tratar os dados
                    int quantidadeIndividuos = individuos.Count(); //Definir a quantidade de indivíduos

                    Console.Clear();
                    Console.WriteLine("+--------------------------------------+");
                    Console.WriteLine("|       Select an option               |");
                    Console.WriteLine("|  1  - Automatic K Value              |");
                    Console.WriteLine("|  2  - Manual K Value                 |");
                    Console.WriteLine("| Any - Return to Previous Menu        |");
                    Console.WriteLine("+--------------------------------------+");
                    Console.WriteLine("");
  
                    opcao2 = Console.ReadLine();

                    if (opcao2 == "1")
                    {
                        Console.Clear();
                        k = 33;
                        for (int i = 1; i <= 30; i++) //Quantidade de Repetição dos Testes
                        {
                            //Zerar Indicadores
                            int acertos = 0, erros = 0;
                            double percAcerto = 0;

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
                            Random randNumero = new Random();
                            Individuo AuxAdd;

                            //Setosa
                            //Add 25% no Z1
                            while (Z1.Count() < 13)
                            {
                                AuxAdd = ListSet.ElementAt(randNumero.Next(ListSet.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z1.Add(AuxAdd);
                                }
                            }
                            //Add 25% no Z2
                            while (Z2.Count() < 13)
                            {

                                AuxAdd = ListSet.ElementAt(randNumero.Next(ListSet.Count() - 1));
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
                                AuxAdd = ListVer.ElementAt(randNumero.Next(ListVer.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z1.Add(AuxAdd);
                                }
                            }
                            //Add 25% no Z2
                            while (Z2.Count() < 26)
                            {
                                AuxAdd = ListVer.ElementAt(randNumero.Next(ListVer.Count() - 1));
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
                                AuxAdd = ListVir.ElementAt(randNumero.Next(ListVir.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z1.Add(AuxAdd);
                                }
                            }
                            //Add 25% no Z2
                            while (Z2.Count() < 38)
                            {
                                AuxAdd = ListVir.ElementAt(randNumero.Next(ListVir.Count() - 1));
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
                            percAcerto = (acertos * 100) / Z3.Count();
                            Indicadores indicador = new Indicadores(acertos, erros, percAcerto);
                            ResultadoTestes.Add(indicador);

                            //Informação do Console
                            if (i < 10)
                            {
                                Console.WriteLine("Test no.0" + i + " - " + percAcerto + "% (correct: "+acertos+", wrong:"+erros + ") K:" + k);
                            }
                            else
                            {
                                Console.WriteLine("Test no." + i + " - " + percAcerto + "% (correct: " + acertos + ", wrong:" + erros + ") K:" + k);
                            }
                            k--; //Diminuir o contador
                        }

                        Console.WriteLine("");

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
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("FINAL RESULTS");
                        Console.WriteLine("Média        : " + media);
                        Console.WriteLine("Desvio Padrão: " + desvioPadrao);
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to return to menu or 0 to exit");
                        Console.ReadKey();
                    }
        
                    if (opcao2 == "2")
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Insert K Value:");
                            k = Convert.ToInt32(Console.ReadLine());
                            if (k > 38 || k < 0)
                            {
                                Console.WriteLine("Insert a Value Between 0 and 38");
                                Console.ReadKey();
                            }
                        } while (k > 38 || k < 0);

                        for (int i = 1; i <= 30; i++) //Quantidade de Repetição dos Testes
                        {
                            //Zerar Indicadores
                            int acertos = 0, erros = 0;
                            double percAcerto = 0;

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
                            Random randNumero = new Random();
                            Individuo AuxAdd;

                            //Setosa
                            //Add 25% no Z1
                            while (Z1.Count() < 13)
                            {
                                AuxAdd = ListSet.ElementAt(randNumero.Next(ListSet.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z1.Add(AuxAdd);
                                }
                            }
                            //Add 25% no Z2
                            while (Z2.Count() < 13)
                            {

                                AuxAdd = ListSet.ElementAt(randNumero.Next(ListSet.Count() - 1));
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
                                AuxAdd = ListVer.ElementAt(randNumero.Next(ListVer.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z1.Add(AuxAdd);
                                }
                            }
                            //Add 25% no Z2
                            while (Z2.Count() < 26)
                            {
                                AuxAdd = ListVer.ElementAt(randNumero.Next(ListVer.Count() - 1));
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
                                AuxAdd = ListVir.ElementAt(randNumero.Next(ListVir.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z1.Add(AuxAdd);
                                }
                            }
                            //Add 25% no Z2
                            while (Z2.Count() < 38)
                            {
                                AuxAdd = ListVir.ElementAt(randNumero.Next(ListVir.Count() - 1));
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
                            percAcerto = (acertos * 100) / Z3.Count();
                            Indicadores indicador = new Indicadores(acertos, erros, percAcerto);
                            ResultadoTestes.Add(indicador);

                            //Informação do Console
                            if (i < 10)
                            {
                                Console.WriteLine("Test no.0" + i + " - " + percAcerto + "% (correct: " + acertos + ", wrong:" + erros + ") K:" + k);
                            }
                            else
                            {
                                Console.WriteLine("Test no." + i + " - " + percAcerto + "% (correct: " + acertos + ", wrong:" + erros + ") K:" + k);
                            }
                        }

                        Console.WriteLine("");

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
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("FINAL RESULTS");
                        Console.WriteLine("Média        : " + media);
                        Console.WriteLine("Desvio Padrão: " + desvioPadrao);
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to return to menu or 0 to exit");
                        Console.ReadKey();
                    }
                }

                //Importar Base de Dados Balance
                if (opcao == "2")
                {
                    {
                        string[] database2 = f.CarregarDataBase2(); //Chamar a função para carregar a base de dados e alimentar a database
                        individuos = f.SeparadorDeAtributos2(database2); //Chamar a função para tratar os dados
                        int quantidadeIndividuos = individuos.Count(); //Definir a quantidade de indivíduos

                        Console.Clear();
                        Console.WriteLine("+--------------------------------------+");
                        Console.WriteLine("|       Select an option               |");
                        Console.WriteLine("|  1  - Automatic K Value              |");
                        Console.WriteLine("|  2  - Manual K Value                 |");
                        Console.WriteLine("| Any - Return to Previous Menu        |");
                        Console.WriteLine("+--------------------------------------+");
                        opcao2 = Console.ReadLine();

                        if (opcao2 == "1")
                        {
                            Console.Clear();
                            k = 33;
                            for (int i = 1; i <= 30; i++) //Quantidade de Repetição dos Testes
                            {
                                //Zerar Indicadores
                                int acertos = 0, erros = 0;
                                double percAcerto = 0;

                                //Alimentar as Listas das Balanças
                                foreach (var indv in individuos)
                                {
                                    if (indv.classe == "L")
                                    {
                                        ListL.Add(indv);
                                        continue;
                                    }
                                    if (indv.classe == "R")
                                    {
                                        ListR.Add(indv);
                                        continue;
                                    }
                                    if (indv.classe == "B")
                                    {
                                        ListB.Add(indv);
                                        continue;
                                    }
                                }

                                //Dividir os Zs
                                Random randNum = new Random();
                                Individuo AuxAdd;

                                //L
                                //Add 25% no Z1
                                while (Z1.Count() < 72)
                                {
                                    AuxAdd = ListL.ElementAt(randNum.Next(ListL.Count() - 1));
                                    if (!AuxAdd.usado)
                                    {
                                        AuxAdd.usado = true;
                                        Z1.Add(AuxAdd);
                                    }
                                }
                                //Add 25% no Z2
                                while (Z2.Count() < 72)
                                {

                                    AuxAdd = ListL.ElementAt(randNum.Next(ListL.Count() - 1));
                                    if (!AuxAdd.usado)
                                    {
                                        AuxAdd.usado = true;
                                        Z2.Add(AuxAdd);
                                    }
                                }
                                //Add 50% no Z3
                                while (Z3.Count() < 144)
                                {
                                    AuxAdd = ListL.Where(c => c.usado == false).First();
                                    AuxAdd.usado = true;
                                    Z3.Add(AuxAdd);
                                }

                                //B
                                //Add 25% no Z1
                                while (Z1.Count() < 84)
                                {
                                    AuxAdd = ListB.ElementAt(randNum.Next(ListB.Count() - 1));
                                    if (!AuxAdd.usado)
                                    {
                                        AuxAdd.usado = true;
                                        Z1.Add(AuxAdd);
                                    }
                                }
                                //Add 25% no Z2
                                while (Z2.Count() < 84)
                                {
                                    AuxAdd = ListB.ElementAt(randNum.Next(ListB.Count() - 1));
                                    if (!AuxAdd.usado)
                                    {
                                        AuxAdd.usado = true;
                                        Z2.Add(AuxAdd);
                                    }
                                }
                                //Add 50% no Z3
                                while (Z3.Count() < 169)
                                {
                                    AuxAdd = ListB.Where(c => c.usado == false).First();
                                    AuxAdd.usado = true;
                                    Z3.Add(AuxAdd);
                                }

                                //R
                                //Add 25% no Z1
                                while (Z1.Count() < 156)
                                {
                                    AuxAdd = ListR.ElementAt(randNum.Next(ListR.Count() - 1));
                                    if (!AuxAdd.usado)
                                    {
                                        AuxAdd.usado = true;
                                        Z1.Add(AuxAdd);
                                    }
                                }
                                //Add 25% no Z2
                                while (Z2.Count() < 156)
                                {
                                    AuxAdd = ListR.ElementAt(randNum.Next(ListR.Count() - 1));
                                    if (!AuxAdd.usado)
                                    {
                                        AuxAdd.usado = true;
                                        Z2.Add(AuxAdd);
                                    }
                                }
                                //Add 50% no Z3
                                while (Z3.Count() < 313)
                                {
                                    AuxAdd = ListR.Where(c => c.usado == false).First();
                                    AuxAdd.usado = true;
                                    Z3.Add(AuxAdd);
                                }

                                //Puxar Dados para iniciar o Treino
                                string[] classeObtida = f.ClassificadorDeAmostras2(Z1, Z2, k);
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
                                classeObtida = f.ClassificadorDeAmostras2(Z3, Z2, k);

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
                                percAcerto = (acertos * 100) / Z3.Count();
                                Indicadores indicador = new Indicadores(acertos, erros, percAcerto);
                                ResultadoTestes.Add(indicador);

                                //Informação do Console
                                if (i < 10)
                                {
                                    Console.WriteLine("Test no.0" + i + " - " + percAcerto + "% (correct: " + acertos + ", wrong:" + erros + ") K:" + k);
                                }
                                else
                                {
                                    Console.WriteLine("Test no." + i + " - " + percAcerto + "% (correct: " + acertos + ", wrong:" + erros + ") K:" + k);
                                }
                                k--; //Diminuir o contador
                            }

                            Console.WriteLine("");

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
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("FINAL RESULTS");
                            Console.WriteLine("Média        : " + media);
                            Console.WriteLine("Desvio Padrão: " + desvioPadrao);
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to return to menu or 0 to exit");
                            Console.ReadKey();
                        }
                        
                        if (opcao2 == "2")
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Insert K Value:");
                                k = Convert.ToInt32(Console.ReadLine());
                                if(k > 156 || k < 0) 
                                {
                                    Console.WriteLine("Insert a Value Between 0 and 156");
                                    Console.ReadKey();
                                }
                            } while (k > 156 || k < 0);

                            for (int i = 1; i <= 30; i++) //Quantidade de Repetição dos Testes
                            {
                                //Zerar Indicadores
                                int acertos = 0, erros = 0;
                                double percAcerto = 0;

                                //Alimentar as Listas das Balanças
                                foreach (var indv in individuos)
                                {
                                    if (indv.classe == "L")
                                    {
                                        ListL.Add(indv);
                                        continue;
                                    }
                                    if (indv.classe == "R")
                                    {
                                        ListR.Add(indv);
                                        continue;
                                    }
                                    if (indv.classe == "B")
                                    {
                                        ListB.Add(indv);
                                        continue;
                                    }
                                }

                                //Dividir os Zs
                                Random randNum = new Random();
                                Individuo AuxAdd;

                                //L
                                //Add 25% no Z1
                                while (Z1.Count() < 72)
                                {
                                    AuxAdd = ListL.ElementAt(randNum.Next(ListL.Count() - 1));
                                    if (!AuxAdd.usado)
                                    {
                                        AuxAdd.usado = true;
                                        Z1.Add(AuxAdd);
                                    }
                                }
                                //Add 25% no Z2
                                while (Z2.Count() < 72)
                                {

                                    AuxAdd = ListL.ElementAt(randNum.Next(ListL.Count() - 1));
                                    if (!AuxAdd.usado)
                                    {
                                        AuxAdd.usado = true;
                                        Z2.Add(AuxAdd);
                                    }
                                }
                                //Add 50% no Z3
                                while (Z3.Count() < 144)
                                {
                                    AuxAdd = ListL.Where(c => c.usado == false).First();
                                    AuxAdd.usado = true;
                                    Z3.Add(AuxAdd);
                                }

                                //B
                                //Add 25% no Z1
                                while (Z1.Count() < 84)
                                {
                                    AuxAdd = ListB.ElementAt(randNum.Next(ListB.Count() - 1));
                                    if (!AuxAdd.usado)
                                    {
                                        AuxAdd.usado = true;
                                        Z1.Add(AuxAdd);
                                    }
                                }
                                //Add 25% no Z2
                                while (Z2.Count() < 84)
                                {
                                    AuxAdd = ListB.ElementAt(randNum.Next(ListB.Count() - 1));
                                    if (!AuxAdd.usado)
                                    {
                                        AuxAdd.usado = true;
                                        Z2.Add(AuxAdd);
                                    }
                                }
                                //Add 50% no Z3
                                while (Z3.Count() < 169)
                                {
                                    AuxAdd = ListB.Where(c => c.usado == false).First();
                                    AuxAdd.usado = true;
                                    Z3.Add(AuxAdd);
                                }

                                //R
                                //Add 25% no Z1
                                while (Z1.Count() < 156)
                                {
                                    AuxAdd = ListR.ElementAt(randNum.Next(ListR.Count() - 1));
                                    if (!AuxAdd.usado)
                                    {
                                        AuxAdd.usado = true;
                                        Z1.Add(AuxAdd);
                                    }
                                }
                                //Add 25% no Z2
                                while (Z2.Count() < 156)
                                {
                                    AuxAdd = ListR.ElementAt(randNum.Next(ListR.Count() - 1));
                                    if (!AuxAdd.usado)
                                    {
                                        AuxAdd.usado = true;
                                        Z2.Add(AuxAdd);
                                    }
                                }
                                //Add 50% no Z3
                                while (Z3.Count() < 313)
                                {
                                    AuxAdd = ListR.Where(c => c.usado == false).First();
                                    AuxAdd.usado = true;
                                    Z3.Add(AuxAdd);
                                }

                                //Puxar Dados para iniciar o Treino
                                string[] classeObtida = f.ClassificadorDeAmostras2(Z1, Z2, k);
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
                                classeObtida = f.ClassificadorDeAmostras2(Z3, Z2, k);

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
                                percAcerto = (acertos * 100) / Z3.Count();
                                Indicadores indicador = new Indicadores(acertos, erros, percAcerto);
                                ResultadoTestes.Add(indicador);

                                //Informação do Console
                                if (i < 10)
                                {
                                    Console.WriteLine("Test no.0" + i + " - " + percAcerto + "% (correct: " + acertos + ", wrong:" + erros + ") K:" + k);
                                }
                                else
                                {
                                    Console.WriteLine("Test no." + i + " - " + percAcerto + "% (correct: " + acertos + ", wrong:" + erros + ") K:" + k);
                                }
                            }

                            Console.WriteLine("");

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
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("FINAL RESULTS");
                            Console.WriteLine("Média        : " + media);
                            Console.WriteLine("Desvio Padrão: " + desvioPadrao);
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to return to menu or 0 to exit");
                            Console.ReadKey();
                        }
                    }
                }

                //Importar Base de Dados Hayes-Roth
                if (opcao == "3")
                {
                    string[] database3 = f.CarregarDataBase3(); //Chamar a função para carregar a base de dados e alimentar a database

                    individuos = f.SeparadorDeAtributos3(database3); //Chamar a função para tratar os dados
                    int quantidadeIndividuos = individuos.Count(); //Definir a quantidade de indivíduos

                    Console.Clear();
                    Console.WriteLine("+--------------------------------------+");
                    Console.WriteLine("|       Select an option               |");
                    Console.WriteLine("|  1  - Automatic K Value              |");
                    Console.WriteLine("|  2  - Manual K Value                 |");
                    Console.WriteLine("| Any - Return to Previous Menu        |");
                    Console.WriteLine("+--------------------------------------+");
                    Console.WriteLine("");

                    opcao2 = Console.ReadLine();

                    if (opcao2 == "1")
                    {
                        Console.Clear();
                        k = 33;
                        for (int i = 1; i <= 30; i++) //Quantidade de Repetição dos Testes
                        {
                            //Zerar Indicadores
                            int acertos = 0, erros = 0;
                            double percAcerto = 0;

                            //Alimentar as Listas Hayes-Roth
                            foreach (var indv in individuos)
                            {
                                if (indv.classe == "1")
                                {
                                    List1.Add(indv);
                                    continue;
                                }
                                if (indv.classe == "2")
                                {
                                    List2.Add(indv);
                                    continue;
                                }
                                if (indv.classe == "3")
                                {
                                    List3.Add(indv);
                                    continue;
                                }
                            }

                            //Dividir os Zs
                            Random randNumero = new Random();
                            Individuo AuxAdd;

                            //1
                            //Add 25% no Z1
                            while (Z1.Count() < 13)
                            {
                                AuxAdd = List1.ElementAt(randNumero.Next(List1.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z1.Add(AuxAdd);
                                }
                            }
                            //Add 25% no Z2
                            while (Z2.Count() < 13)
                            {

                                AuxAdd = List1.ElementAt(randNumero.Next(List1.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z2.Add(AuxAdd);
                                }
                            }
                            //Add 50% no Z3
                            while (Z3.Count() < 25)
                            {
                                AuxAdd = List1.Where(c => c.usado == false).First();
                                AuxAdd.usado = true;
                                Z3.Add(AuxAdd);
                            }

                            //3
                            //Add 25% no Z1
                            while (Z1.Count() < 20)
                            {
                                AuxAdd = List3.ElementAt(randNumero.Next(List3.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z1.Add(AuxAdd);
                                }
                            }
                            //Add 25% no Z2
                            while (Z2.Count() < 20)
                            {
                                AuxAdd = List3.ElementAt(randNumero.Next(List3.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z2.Add(AuxAdd);
                                }
                            }
                            //Add 50% no Z3
                            while (Z3.Count() < 41)
                            {
                                AuxAdd = List3.Where(c => c.usado == false).First();
                                AuxAdd.usado = true;
                                Z3.Add(AuxAdd);
                            }


                            //2
                            //Add 25% no Z1
                            while (Z1.Count() < 33)
                            {
                                AuxAdd = List2.ElementAt(randNumero.Next(List2.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z1.Add(AuxAdd);
                                }
                            }
                            //Add 25% no Z2
                            while (Z2.Count() < 33)
                            {
                                AuxAdd = List2.ElementAt(randNumero.Next(List2.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z2.Add(AuxAdd);
                                }
                            }
                            //Add 50% no Z3
                            while (Z3.Count() < 66)
                            {
                                AuxAdd = List2.Where(c => c.usado == false).First();
                                AuxAdd.usado = true;
                                Z3.Add(AuxAdd);
                            }

                            //Puxar Dados para iniciar o Treino
                            string[] classeObtida = f.ClassificadorDeAmostras3(Z1, Z2, k);
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
                            classeObtida = f.ClassificadorDeAmostras3(Z3, Z2, k);

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
                            percAcerto = (acertos * 100) / Z3.Count();
                            Indicadores indicador = new Indicadores(acertos, erros, percAcerto);
                            ResultadoTestes.Add(indicador);

                            //Informação do Console
                            if (i < 10)
                            {
                                Console.WriteLine("Test no.0" + i + " - " + percAcerto + "% (correct: " + acertos + ", wrong:" + erros + ") K:" + k);
                            }
                            else
                            {
                                Console.WriteLine("Test no." + i + " - " + percAcerto + "% (correct: " + acertos + ", wrong:" + erros + ") K:" + k);
                            }
                            k--; //Diminuir o contador
                        }

                        Console.WriteLine("");

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
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("FINAL RESULTS");
                        Console.WriteLine("Média        : " + media);
                        Console.WriteLine("Desvio Padrão: " + desvioPadrao);
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to return to menu or 0 to exit");
                        Console.ReadKey();
                    }

                    if (opcao2 == "2")
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Insert K Value:");
                            k = Convert.ToInt32(Console.ReadLine());
                            if (k > 33 || k < 0)
                            {
                                Console.WriteLine("Insert a Value Between 0 and 33");
                                Console.ReadKey();
                            }
                        } while (k > 33 || k < 0);

                        for (int i = 1; i <= 30; i++) //Quantidade de Repetição dos Testes
                        {
                            //Zerar Indicadores
                            int acertos = 0, erros = 0;
                            double percAcerto = 0;

                            //Alimentar as Listas Hayes-Roth
                            foreach (var indv in individuos)
                            {
                                if (indv.classe == "1")
                                {
                                    List1.Add(indv);
                                    continue;
                                }
                                if (indv.classe == "2")
                                {
                                    List2.Add(indv);
                                    continue;
                                }
                                if (indv.classe == "3")
                                {
                                    List3.Add(indv);
                                    continue;
                                }
                            }

                            //Dividir os Zs
                            Random randNumero = new Random();
                            Individuo AuxAdd;

                            //1
                            //Add 25% no Z1
                            while (Z1.Count() < 13)
                            {
                                AuxAdd = List1.ElementAt(randNumero.Next(List1.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z1.Add(AuxAdd);
                                }
                            }
                            //Add 25% no Z2
                            while (Z2.Count() < 13)
                            {

                                AuxAdd = List1.ElementAt(randNumero.Next(List1.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z2.Add(AuxAdd);
                                }
                            }
                            //Add 50% no Z3
                            while (Z3.Count() < 25)
                            {
                                AuxAdd = List1.Where(c => c.usado == false).First();
                                AuxAdd.usado = true;
                                Z3.Add(AuxAdd);
                            }

                            //3
                            //Add 25% no Z1
                            while (Z1.Count() < 20)
                            {
                                AuxAdd = List3.ElementAt(randNumero.Next(List3.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z1.Add(AuxAdd);
                                }
                            }
                            //Add 25% no Z2
                            while (Z2.Count() < 20)
                            {
                                AuxAdd = List3.ElementAt(randNumero.Next(List3.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z2.Add(AuxAdd);
                                }
                            }
                            //Add 50% no Z3
                            while (Z3.Count() < 41)
                            {
                                AuxAdd = List3.Where(c => c.usado == false).First();
                                AuxAdd.usado = true;
                                Z3.Add(AuxAdd);
                            }


                            //2
                            //Add 25% no Z1
                            while (Z1.Count() < 33)
                            {
                                AuxAdd = List2.ElementAt(randNumero.Next(List2.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z1.Add(AuxAdd);
                                }
                            }
                            //Add 25% no Z2
                            while (Z2.Count() < 33)
                            {
                                AuxAdd = List2.ElementAt(randNumero.Next(List2.Count() - 1));
                                if (!AuxAdd.usado)
                                {
                                    AuxAdd.usado = true;
                                    Z2.Add(AuxAdd);
                                }
                            }
                            //Add 50% no Z3
                            while (Z3.Count() < 66)
                            {
                                AuxAdd = List2.Where(c => c.usado == false).First();
                                AuxAdd.usado = true;
                                Z3.Add(AuxAdd);
                            }

                            //Puxar Dados para iniciar o Treino
                            string[] classeObtida = f.ClassificadorDeAmostras3(Z1, Z2, k);
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
                            classeObtida = f.ClassificadorDeAmostras3(Z3, Z2, k);

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
                            percAcerto = (acertos * 100) / Z3.Count();
                            Indicadores indicador = new Indicadores(acertos, erros, percAcerto);
                            ResultadoTestes.Add(indicador);

                            //Informação do Console
                            if (i < 10)
                            {
                                Console.WriteLine("Test no.0" + i + " - " + percAcerto + "% (correct: " + acertos + ", wrong:" + erros + ") K:" + k);
                            }
                            else
                            {
                                Console.WriteLine("Test no." + i + " - " + percAcerto + "% (correct: " + acertos + ", wrong:" + erros + ") K:" + k);
                            }
                        }

                        Console.WriteLine("");

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
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("FINAL RESULTS");
                        Console.WriteLine("Média        :" + media);
                        Console.WriteLine("Desvio Padrão:" + desvioPadrao);
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to return to menu or 0 to exit");
                        Console.ReadKey();
                    }
                }

                //Limpar Todas As Listas
                individuos.Clear();
                ListSet.Clear();
                ListVir.Clear();
                ListVer.Clear();
                ListB.Clear();
                ListR.Clear();
                ListL.Clear();
                List1.Clear();
                List3.Clear();
                List2.Clear();
                Z1.Clear();
                Z2.Clear();
                Z3.Clear();

            } while (opcao != "0"); //Sair
        }
    }
}
