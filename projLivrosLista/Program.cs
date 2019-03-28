using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista
{
    class Program
    {
        static Livros livros = new Livros();

        static void Main(string[] args)
        {
            string op = "";
            do
            {
                /*
                --------------------------------------
                | 0. Sair                            |
                | 1. Adicionar livro                 |
                | 2. Pesquisar livro (sintético)*    |
                | 3. Pesquisar livro (analítico)**   |
                | 4. Adicionar exemplar              |
                | 5. Registrar empréstimo            |
                | 6. Registrar devolução             |
                --------------------------------------
                */

                Console.Clear();

                Console.SetCursorPosition(40, 10); Console.Write("--------------- MENU ----------------");
                Console.SetCursorPosition(40, 11); Console.Write("| 0. Sair                           |");
                Console.SetCursorPosition(40, 12); Console.Write("| 1. Adicionar livro                |");
                Console.SetCursorPosition(40, 13); Console.Write("| 2. Pesquisar livro (sintético)*   |");
                Console.SetCursorPosition(40, 14); Console.Write("| 3. Pesquisar livro (analítico)**  |");
                Console.SetCursorPosition(40, 15); Console.Write("| 4. Adicionar exemplar             |");
                Console.SetCursorPosition(40, 16); Console.Write("| 5. Registrar empréstimo           |");
                Console.SetCursorPosition(40, 17); Console.Write("| 6. Registrar devolução            |");
                Console.SetCursorPosition(40, 18); Console.Write("-------------------------------------");

                Console.SetCursorPosition(40, 19); Console.Write("Digite uma opção: ");
                Console.SetCursorPosition(40, 20); Console.Write("-------------------------------------");
                try
                {
                    Console.SetCursorPosition(60, 19); op = Console.ReadLine();

                    switch (op)
                    {
                        case "0": break;
                        case "1": adicionarLivro(); break;
                        case "2": pesquisarLivroSintetico(); break;
                        case "3": pesquisarLivroAnalitico(); break;
                        case "4": adicionarExemplar(); break;
                        case "5": registrarEmprestimo(); break;
                        case "6": registrarDevolucao(); break;
                        default: Console.WriteLine("Opção inválida."); break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            } while (op != "0");

            System.Environment.Exit(0);
        }

        static void adicionarLivro()
        {
            Console.Clear();

            Console.SetCursorPosition(40, 10); Console.Write("-------------------------------------");
            Console.SetCursorPosition(40, 12); Console.Write("-------------------------------------");
            Console.SetCursorPosition(40, 11); Console.Write("Digite o ISBN:                       ");
            Console.SetCursorPosition(60, 11); int isbn = Int32.Parse(Console.ReadLine());
            if (livros.pesquisar(new Livro(isbn)) != null)
            {
                Console.SetCursorPosition(40, 13); throw new Exception("Já existe um livro com esse ISBN");
            }

            Console.SetCursorPosition(40, 12); Console.Write("Digite o título:                     ");
            Console.SetCursorPosition(40, 13); Console.Write("-------------------------------------");
            Console.SetCursorPosition(60, 12); string titulo = Console.ReadLine();
            Console.SetCursorPosition(40, 13); Console.Write("Digite o autor:                      ");
            Console.SetCursorPosition(40, 14); Console.Write("-------------------------------------");
            Console.SetCursorPosition(60, 13); string autor = Console.ReadLine();
            Console.SetCursorPosition(40, 14); Console.Write("Digite a editora:                    ");
            Console.SetCursorPosition(40, 15); Console.Write("-------------------------------------");
            Console.SetCursorPosition(60, 14); string editora = Console.ReadLine();

            livros.adicionar(new Livro(isbn, titulo, autor, editora));
            Console.SetCursorPosition(40, 16); Console.WriteLine("Exemplar cadastrado com sucesso!");
            Console.ReadKey();
        }

        static void pesquisarLivroSintetico()
        {
            Console.Clear();

            Console.SetCursorPosition(40, 10); Console.Write("-------------------------------------");
            Console.SetCursorPosition(40, 12); Console.Write("-------------------------------------");
            Console.SetCursorPosition(40, 11); Console.Write("Digite o ISBN:                       ");
            Console.SetCursorPosition(60, 11); int isbn = Int32.Parse(Console.ReadLine());
            Livro livro = livros.pesquisar(new Livro(isbn));
            if (livro == null)
            {
                Console.SetCursorPosition(40, 13); throw new Exception("Livro não encontrado.");
            }
            Console.SetCursorPosition(40, 13); Console.Write("Total de exemplares: " + livro.qtdeExemplares());
            Console.SetCursorPosition(40, 14); Console.Write("Total de exemplares disponíveis: " + livro.qtdeDisponiveis());
            Console.SetCursorPosition(40, 15); Console.Write("Total de empréstimos: " + livro.qtdeEmprestimos());
            Console.SetCursorPosition(40, 16); Console.Write("Percentual de disponibilidade: " + livro.percDisponibilidade().ToString("0.00") + "%");
            Console.SetCursorPosition(40, 17); Console.Write("-------------------------------------");

            Console.ReadKey();
        }

        static void pesquisarLivroAnalitico()
        {

            Console.Clear();

            Console.SetCursorPosition(40, 10); Console.Write("-------------------------------------");
            Console.SetCursorPosition(40, 12); Console.Write("-------------------------------------");
            Console.SetCursorPosition(40, 11); Console.Write("Digite o ISBN:                       ");
            Console.SetCursorPosition(60, 11); int isbn = Int32.Parse(Console.ReadLine());
            Livro livro = livros.pesquisar(new Livro(isbn));
            if (livro == null)
            {
                Console.SetCursorPosition(40, 13); throw new Exception("Livro não encontrado.");
            }

            Console.SetCursorPosition(40, 13); Console.Write("Total de exemplares: " + livro.qtdeExemplares());
            Console.SetCursorPosition(40, 14); Console.Write("Total de exemplares disponíveis: " + livro.qtdeDisponiveis());
            Console.SetCursorPosition(40, 15); Console.Write("Total de empréstimos: " + livro.qtdeEmprestimos());
            Console.SetCursorPosition(40, 16); Console.Write("Percentual de disponibilidade: " + livro.percDisponibilidade().ToString("0.00") + "%");
            Console.SetCursorPosition(40, 17); Console.Write("-------------------------------------\n");

            int cont=0;

            livro.Exemplares.ForEach(i => {
                Console.SetCursorPosition(40, (18+cont)); Console.Write("Tombo: " + i.Tombo);
                cont++;
                i.Emprestimos.ForEach(j => {
                    String devolucao = (j.DtDevolucao != DateTime.MinValue) ? j.DtDevolucao.ToString() : "-------------------";
                    Console.SetCursorPosition(40, (18 + cont)); Console.Write("Data Empréstimo: " + j.DtEmprestimo); cont++;
                    Console.SetCursorPosition(40, (18 + cont)); Console.Write("Data Devolução:  " + devolucao); cont++;
                });
            });
            Console.SetCursorPosition(40, (19 + (cont-1))); Console.Write("-------------------------------------");

            Console.ReadKey();
        }

        static void adicionarExemplar()
        {

            Console.Clear();

            Console.SetCursorPosition(40, 10); Console.Write("-------------------------------------");
            Console.SetCursorPosition(40, 12); Console.Write("-------------------------------------");
            Console.SetCursorPosition(40, 11); Console.Write("Digite o ISBN:                       ");
            Console.SetCursorPosition(60, 11); int isbn = Int32.Parse(Console.ReadLine());

            Livro livro = livros.pesquisar(new Livro(isbn));
            if (livro == null)
            {
                Console.SetCursorPosition(40, 13); throw new Exception("Livro não encontrado.");
            }

            Console.SetCursorPosition(40, 13); Console.Write("Digite o Tombo: ");
            int tombo = Int32.Parse(Console.ReadLine());
            livro.adicionarExemplar(new Exemplar(tombo));
            Console.SetCursorPosition(40, 14); Console.Write("-------------------------------------");
            Console.SetCursorPosition(40, 15); Console.Write("Exemplar cadastrado com sucesso!");
            Console.ReadKey();
        }

        static void registrarEmprestimo()
        {
            Console.Clear();

            Console.SetCursorPosition(40, 10); Console.Write("-------------------------------------");
            Console.SetCursorPosition(40, 12); Console.Write("-------------------------------------");
            Console.SetCursorPosition(40, 11); Console.Write("Digite o ISBN:                       ");
            Console.SetCursorPosition(60, 11); int isbn = Int32.Parse(Console.ReadLine());

            Livro livro = livros.pesquisar(new Livro(isbn));
            if (livro == null)
            {
                Console.SetCursorPosition(40, 13); throw new Exception("Livro não encontrado.");
            }

            Exemplar exemplar = livro.Exemplares.FirstOrDefault(i => i.emprestar());
            if (exemplar != null)
            {
                Console.SetCursorPosition(40, 13); Console.WriteLine("Exemplar " + exemplar.Tombo + " emprestado com sucesso!");
            }
            else
            {
                Console.SetCursorPosition(40, 13); throw new Exception("Não há exemplares disponíveis.");
            }
        }

        static void registrarDevolucao()
        {
            Console.Clear();

            Console.SetCursorPosition(40, 10); Console.Write("-------------------------------------");
            Console.SetCursorPosition(40, 12); Console.Write("-------------------------------------");
            Console.SetCursorPosition(40, 11); Console.Write("Digite o ISBN:                       ");
            int isbn = Int32.Parse(Console.ReadLine());

            Livro livro = livros.pesquisar(new Livro(isbn));
            if (livro == null)
            {
                Console.SetCursorPosition(40, 13); throw new Exception("Livro não encontrado.");
            }

            Exemplar exemplar = livro.Exemplares.FirstOrDefault(i => i.devolver());
            if (exemplar != null)
            {
                Console.SetCursorPosition(40, 13); Console.Write("Exemplar " + exemplar.Tombo + " devolvido com sucesso!");
            }
            else
            {
                Console.SetCursorPosition(40, 13); Console.WriteLine("Não há exemplares emprestados.");
            }
            Console.ReadKey();
        }
    }
}