﻿using Tabuleiro;
using Tabuleiro.Enums;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(TabuleiroClasse tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "T ";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            // ACIMA
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);

            while (Tab.PosicaoValida(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.Linha = pos.Linha - 1;
            }

            // ABAIXO
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.Linha = pos.Linha + 1;
            }

            // DIRETA
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.Coluna = pos.Coluna + 1;
            }

            // ESQUERDA
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.Coluna = pos.Coluna - 1;
            }

            
            return mat;

        }
    }
}