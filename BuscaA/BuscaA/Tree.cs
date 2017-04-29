using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BuscaA
{
    public class No
    {
        public int[,] Data { get; set; }//Campo para guardar uma estrutura de dados genérica
        public int EmptyX { get; set; }//Guarda a coordenada da posição vazia do estado inicial
        public int EmptyY { get; set; }
        public int[] posicaoX { get; set; }
        public int[] posicaoY { get; set; }
        public DateTime id { get; set; }
        public int H { get; set; }
        public int H_L { get; set; }
        public No Parent { get; set; }//Pai

        /// <summary>
        /// Verifica se é a raiz
        /// </summary>
        public Boolean IsRoot
        {
            get { return Parent == null; }
        }

        /// <summary>
        /// Retorna o nível do estado
        /// </summary>
        public int Level
        {
            get
            {
                if (this.IsRoot)
                    return 0;
                return Parent.Level + 1;
            }
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="data"></param>
        public No(int[,] data)
        {
            this.Data = data;
            this.H = 0;
            this.H_L = 0;
            this.id = DateTime.Now;
        }

        /// <summary>
        /// Adiciona um estado filho
        /// </summary>
        /// <param name="child"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public No AddChild(int[,] child, int x, int y)
        {
            No childNode = new No(child)
            {
                Parent = this,
                EmptyX = x,
                EmptyY = y
            };
            GC.Collect();
            return childNode;
        }
    }
}