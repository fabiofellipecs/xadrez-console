using System;
using System.Collections.Generic;
using Tabuleiro;
using Tabuleiro.Enums;
using Xadrez;

namespace Xadrez_Console
{
    class Tela
    {
        public Tela()
        {

        }

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCap(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            if (!partida.Terminada)
            {
                Console.WriteLine();
                Console.WriteLine("Aguardando Jogada: " + partida.JogadorAtual);
                if (partida.Xeque)
                {
                    Console.WriteLine();
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUE-MATE!");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }
            
        }

        public static void ImprimirPecasCap(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");

            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");

            foreach (Peca p in conjunto)
            {
                Console.Write(p + " ");
            }
            Console.WriteLine("]");
        }

        public static void ImprimirTabuleiro(TabuleiroClasse tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.peca(i, j));                     
                }

                Console.WriteLine();
            }
            
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(TabuleiroClasse tab, bool [,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i,j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.WriteLine();
                
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }

            }

            

        }
    }
}
