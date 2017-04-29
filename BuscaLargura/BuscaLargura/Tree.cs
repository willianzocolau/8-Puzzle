using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BuscaLargura
{
    public class No<T>
    {
        public T Data { get; set; }//Campo para guardar uma estrutura de dados genérica
        public int EmptyX { get; set; }//Guarda a coordenada da posição vazia do estado inicial
        public int EmptyY { get; set; }
        public No<T> Parent { get; set; }//Pai

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
        public No(T data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Adiciona um estado filho
        /// </summary>
        /// <param name="child"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public No<T> AddChild(T child, int x, int y)
        {
            No<T> childNode = new No<T>(child)
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
