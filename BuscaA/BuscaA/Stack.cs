using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaA
{
    public class Pilha<T> : IEnumerable<T>
    {
        public int Count;//Contador

        LinkedList<T> list = new LinkedList<T>();

        /// <summary>
        /// Construtor
        /// </summary>
        public Pilha()
        {
            Count = 0;
        }

        /// <summary>
        /// Método push
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            Count++;
            list.AddFirst(value);
            GC.Collect();
        }

        /// <summary>
        /// Método pop
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("The Stack is empty");
            }
            T value = list.First.Value;
            list.RemoveFirst();
            Count--;
            return value;
            GC.Collect();
        }

        /// <summary>
        /// Método para percorrer pilha
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
