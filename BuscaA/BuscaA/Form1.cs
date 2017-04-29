using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BuscaA
{
    public partial class Form1 : Form
    {
        //Define as estruturas básicas
        private static Stack<No> pilha;//Construir os passos da solução
        private static Queue<No> adicionar;//Estados a serem visitados
        private static Queue<No> visitados;//Estados a serem visitados
        private static LinkedList<No> fila_heuristica;//Estados a serem visitados
        private static int[,] correto;//Estado correto para comparação
        private static string combobox = "";//Estado correto para comparação
        DateTime dt;//Hora para o cronômetro 

        /// <summary>
        /// Construtor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carrega o formulário
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            progressBar1.Visible = false;
            progressBar1.Maximum = 530;
            adicionar = new Queue<No>();
            fila_heuristica = new LinkedList<No>();
            visitados = new Queue<No>();
            pilha = new Stack<No>();
            comboBox1.SelectedIndex = comboBox1.FindStringExact("H3");
            correto = EstadoCorreto();
            No root = Inicializa();
            visitados.Enqueue(root);
            fila_heuristica.AddFirst(root);
        }

        /// <summary>
        /// A cada 1000 ms atualiza as configurações de tempo e de controles 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Se alcançou a data selecionada
            if (dt <= DateTime.Now)
            {
                //timer1.Enabled = false;
                //if (MessageBox.Show("Solução não encontrada no tempo definido.", "8-puzzle", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                //{
                //    Application.Exit();
                //}
            }
            //Se não alcançou, atualiza os labels
            else
            {
                TimeSpan tsTempoRestante = dt.Subtract(DateTime.Now);
                lbl_Tempo.Text = tsTempoRestante.Minutes.ToString() + ":" + tsTempoRestante.Seconds.ToString() + ":" + tsTempoRestante.Milliseconds.ToString();
                if (progressBar1.Maximum > progressBar1.Value)
                {
                    progressBar1.Value++;
                }
            }
        }

        /// <summary>
        /// Método que controla o botão iniciar/stop/próximo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Iniciar_Click(object sender, EventArgs e)
        {
            Thread trd = new Thread(BuscaA, 20971520);
            if (Iniciar.Text == "Iniciar")
            {
                dt = DateTime.Now.AddMinutes(1);
                timer1.Start();
                trd.IsBackground = true;
                trd.IsBackground = true;
                progressBar1.Visible = true;
                trd.Start();
                Iniciar.Text = "Stop";
                comboBox1.Enabled = false;
                combobox = comboBox1.SelectedItem.ToString();
            }
            else if (Iniciar.Text == "Stop")
            {
                trd.Abort();
                Iniciar.Visible = false;
                progressBar1.Visible = false;
                timer1.Stop();
            }
            else
            {
                No no = pilha.Pop();
                p1.ImageLocation = @"C:\puzzle\1_" + no.Data[0, 0] + ".jpg";
                p2.ImageLocation = @"C:\puzzle\1_" + no.Data[0, 1] + ".jpg";
                p3.ImageLocation = @"C:\puzzle\1_" + no.Data[0, 2] + ".jpg";

                p4.ImageLocation = @"C:\puzzle\1_" + no.Data[1, 0] + ".jpg";
                p5.ImageLocation = @"C:\puzzle\1_" + no.Data[1, 1] + ".jpg";
                p6.ImageLocation = @"C:\puzzle\1_" + no.Data[1, 2] + ".jpg";

                p7.ImageLocation = @"C:\puzzle\1_" + no.Data[2, 0] + ".jpg";
                p8.ImageLocation = @"C:\puzzle\1_" + no.Data[2, 1] + ".jpg";
                p9.ImageLocation = @"C:\puzzle\1_" + no.Data[2, 2] + ".jpg";

                if (pilha.Count == 0)
                {
                    Iniciar.Visible = false;
                }
            }
        }

        /// <summary>
        /// Gera um estado aleatório
        /// </summary>
        /// <returns></returns>
        private static dynamic Inicializa()
        {
            int[,] dt = new int[3, 3];
            int x = 0;
            int y = 0;

            List<int> numeros = new List<int>();
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    int numero;
                    do
                    {
                        numero = new Random().Next(0, 9);
                    } while (numeros.Contains(numero));
                    numeros.Add(numero);
                    dt[i, j] = numero;
                    if (numero == 0)
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            var no = new No(dt);
            no.EmptyX = x;
            no.EmptyY = y;
            return no;
        }

        /// <summary>
        /// Comparador - Retorna falso caso existe diferença entre os estados
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        private static Boolean Sucesso(int[,] dt1, int[,] dt2)
        {
            int[] all1 = dt1.Cast<int>().ToArray();
            int[] all2 = dt2.Cast<int>().ToArray();
            return all1.SequenceEqual(all2);
        }

        /// <summary>
        /// Inicializa o estado correto
        /// </summary>
        /// <returns></returns>
        private static int[,] EstadoCorreto()
        {
            int[,] dt = new int[3, 3];
            dt[0, 0] = (int)Configuracao.Posicao.Zero;
            dt[0, 1] = (int)Configuracao.Posicao.Um;
            dt[0, 2] = (int)Configuracao.Posicao.Dois;

            dt[1, 0] = (int)Configuracao.Posicao.Tres;
            dt[1, 1] = (int)Configuracao.Posicao.Quatro;
            dt[1, 2] = (int)Configuracao.Posicao.Cinco;

            dt[2, 0] = (int)Configuracao.Posicao.Seis;
            dt[2, 1] = (int)Configuracao.Posicao.Sete;
            dt[2, 2] = (int)Configuracao.Posicao.Oito;

            return dt;
        }

        /// <summary>
        /// Método que controla a lógia de expansão do quebra-cabeça
        /// </summary>
        /// <param name="pai"></param>
        private static void Expandir(No pai)
        {
            #region Caso 2(2 novos filhos)
            if (pai.EmptyX == 0 && pai.EmptyY == 0)
            {
                int[,] dt = pai.Data.Clone() as int[,];
                int[,] dt1 = pai.Data.Clone() as int[,];
                dt[0, 0] = dt[0, 1];
                dt[0, 1] = 0;

                dt1[0, 0] = dt1[1, 0];
                dt1[1, 0] = 0;

                Adiciona(pai, dt, 0, 1);
                Adiciona(pai, dt1, 1, 0);
            }
            else if (pai.EmptyX == 0 && pai.EmptyY == 2)
            {
                int[,] dt = pai.Data.Clone() as int[,];
                int[,] dt1 = pai.Data.Clone() as int[,];

                dt[0, 2] = dt[0, 1];
                dt[0, 1] = 0;

                dt1[0, 2] = dt1[1, 2];
                dt1[1, 2] = 0;

                Adiciona(pai, dt, 0, 1);
                Adiciona(pai, dt1, 1, 2);
            }
            else if (pai.EmptyX == 2 && pai.EmptyY == 0)
            {
                int[,] dt = pai.Data.Clone() as int[,];
                int[,] dt1 = pai.Data.Clone() as int[,];

                dt[2, 0] = dt[1, 0];
                dt[1, 0] = 0;

                dt1[2, 0] = dt1[2, 1];
                dt1[2, 1] = 0;

                Adiciona(pai, dt1, 2, 1);
                Adiciona(pai, dt, 1, 0);
            }
            else if (pai.EmptyX == 2 && pai.EmptyY == 2)
            {
                int[,] dt = pai.Data.Clone() as int[,];
                int[,] dt1 = pai.Data.Clone() as int[,];

                dt[2, 2] = dt[2, 1];
                dt[2, 1] = 0;

                dt1[2, 2] = dt1[1, 2];
                dt1[1, 2] = 0;

                Adiciona(pai, dt, 2, 1);
                Adiciona(pai, dt1, 1, 2);
            }
            #endregion
            #region Caso 3(3 novos filhos)
            else if (pai.EmptyX == 0 && pai.EmptyY == 1)
            {
                int[,] dt = pai.Data.Clone() as int[,];
                int[,] dt1 = pai.Data.Clone() as int[,];
                int[,] dt2 = pai.Data.Clone() as int[,];

                dt[0, 1] = dt[0, 0];
                dt[0, 0] = 0;

                dt1[0, 1] = dt1[1, 1];
                dt1[1, 1] = 0;

                dt2[0, 1] = dt2[0, 2];
                dt2[0, 2] = 0;

                Adiciona(pai, dt, 0, 0);
                Adiciona(pai, dt2, 0, 2);
                Adiciona(pai, dt1, 1, 1);
            }
            else if (pai.EmptyX == 1 && pai.EmptyY == 0)
            {
                int[,] dt = pai.Data.Clone() as int[,];
                int[,] dt1 = pai.Data.Clone() as int[,];
                int[,] dt2 = pai.Data.Clone() as int[,];
                dt[1, 0] = dt[0, 0];
                dt[0, 0] = 0;

                dt1[1, 0] = dt1[1, 1];
                dt1[1, 1] = 0;

                dt2[1, 0] = dt2[2, 0];
                dt2[2, 0] = 0;

                Adiciona(pai, dt1, 1, 1);
                Adiciona(pai, dt, 0, 0);
                Adiciona(pai, dt2, 2, 0);
            }
            else if (pai.EmptyX == 1 && pai.EmptyY == 2)
            {
                int[,] dt = pai.Data.Clone() as int[,];
                int[,] dt1 = pai.Data.Clone() as int[,];
                int[,] dt2 = pai.Data.Clone() as int[,];
                dt[1, 2] = dt[0, 2];
                dt[0, 2] = 0;

                dt1[1, 2] = dt1[1, 1];
                dt1[1, 1] = 0;

                dt2[1, 2] = dt2[2, 2];
                dt2[2, 2] = 0;

                Adiciona(pai, dt1, 1, 1);
                Adiciona(pai, dt, 0, 2);
                Adiciona(pai, dt2, 2, 2);
            }
            else if (pai.EmptyX == 2 && pai.EmptyY == 1)
            {
                int[,] dt = pai.Data.Clone() as int[,];
                int[,] dt1 = pai.Data.Clone() as int[,];
                int[,] dt2 = pai.Data.Clone() as int[,];
                dt[2, 1] = dt[2, 0];
                dt[2, 0] = 0;

                dt1[2, 1] = dt1[1, 1];
                dt1[1, 1] = 0;

                dt2[2, 1] = dt2[2, 2];
                dt2[2, 2] = 0;

                Adiciona(pai, dt, 2, 0);
                Adiciona(pai, dt2, 2, 2);
                Adiciona(pai, dt1, 1, 1);
            }
            #endregion
            #region Caso 4(4 novos filhos)
            else if (pai.EmptyX == 1 && pai.EmptyY == 1)
            {
                int[,] dt = pai.Data.Clone() as int[,];
                int[,] dt1 = pai.Data.Clone() as int[,];
                int[,] dt2 = pai.Data.Clone() as int[,];
                int[,] dt3 = pai.Data.Clone() as int[,];
                dt[1, 1] = dt[1, 0];
                dt[1, 0] = 0;

                dt1[1, 1] = dt1[0, 1];
                dt1[0, 1] = 0;

                dt2[1, 1] = dt2[1, 2];
                dt2[1, 2] = 0;

                dt3[1, 1] = dt3[2, 1];
                dt3[2, 1] = 0;

                Adiciona(pai, dt, 1, 0);
                Adiciona(pai, dt2, 1, 2);
                Adiciona(pai, dt1, 0, 1);
                Adiciona(pai, dt3, 2, 1);
            }
            #endregion

            Ordena_Heuristica();
        }

        /// <summary>
        /// Aplica a busca em largura
        /// </summary>
        public void BuscaA()
        {
            No estado = fila_heuristica.First();
            fila_heuristica.RemoveFirst();
            //if (
            //   (estado.Data[0, 0] == 4) &&
            //   (estado.Data[0, 1] == 2) &&
            //   (estado.Data[0, 2] == 3) &&

            //   (estado.Data[1, 0] == 1) &&
            //   (estado.Data[1, 1] == 0) &&
            //   (estado.Data[1, 2] == 8) &&

            //   (estado.Data[2, 0] == 6) &&
            //   (estado.Data[2, 1] == 7) &&
            //   (estado.Data[2, 2] == 5)
            //    )
            //{
            //    string t = string.Empty;
            //}
            if (Sucesso(estado.Data, correto))
            {
                Solucao(estado);
                progressBar1.Visible = false;
                Iniciar.Text = "Próximo";
                while (lbl_Tempo.Text == "" || lbl_Tempo.Text == String.Empty)
                {

                }
                timer1.Stop();

                No no = pilha.Pop();
                p1.ImageLocation = @"C:\puzzle\1_" + no.Data[0, 0] + ".jpg";
                p2.ImageLocation = @"C:\puzzle\1_" + no.Data[0, 1] + ".jpg";
                p3.ImageLocation = @"C:\puzzle\1_" + no.Data[0, 2] + ".jpg";

                p4.ImageLocation = @"C:\puzzle\1_" + no.Data[1, 0] + ".jpg";
                p5.ImageLocation = @"C:\puzzle\1_" + no.Data[1, 1] + ".jpg";
                p6.ImageLocation = @"C:\puzzle\1_" + no.Data[1, 2] + ".jpg";

                p7.ImageLocation = @"C:\puzzle\1_" + no.Data[2, 0] + ".jpg";
                p8.ImageLocation = @"C:\puzzle\1_" + no.Data[2, 1] + ".jpg";
                p9.ImageLocation = @"C:\puzzle\1_" + no.Data[2, 2] + ".jpg";
            }
            else
            {
                Expandir(estado);
                BuscaA();
            }
        }

        /// <summary>
        /// Adiciona a pilha os passos necessários para resolver o problema
        /// </summary>
        /// <param name="no"></param>
        private static void Solucao(No no)
        {
            do
            {
                pilha.Push(no);
                no = no.Parent;
            } while (no != null);
        }

        /// <summary>
        /// Método que adiciona novos estados a serem explorados, mas desde que não sejam repetidos
        /// </summary>
        /// <param name="pai"></param>
        /// <param name="novo"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void Adiciona(No pai, int[,] novo, int x, int y)
        {
            Boolean check = false;
            foreach (No dt in visitados)
            {
                if (Sucesso(novo, dt.Data))
                {
                    check = true;
                    break;
                }
            }

            if (check == false)
            {
                No no = pai.AddChild(novo, x, y);
                no = Heuristica(no);
                adicionar.Enqueue(no);
            }
        }

        /// <summary>
        /// Defina a ordem na fila_heuristica
        /// </summary>
        private static void Ordena_Heuristica()
        {
            if (fila_heuristica.Count == 0 && adicionar.Count > 0)
            {
                fila_heuristica.AddFirst(adicionar.Dequeue());
            }

            foreach (No dt in adicionar)
            {
                LinkedListNode<No> item = fila_heuristica.First;
                bool adicionado = false;
                for (int i = 0; i < fila_heuristica.Count; i++)
                {
                    if (
                        (dt.H_L < item.Value.H_L) ||
                        ((dt.H_L == item.Value.H_L) && (dt.id < item.Value.id))
                      )
                    {
                        fila_heuristica.AddBefore(item, dt);
                        adicionado = true;
                        break;
                    }
                    item = item.Next;
                }
                if (!adicionado)
                {
                    fila_heuristica.AddLast(dt);
                }
                visitados.Enqueue(dt);
            }
            adicionar.Clear();
        }

        /// <summary>
        /// Seleciona a heurística a ser utilizada de acordo com a definição do usuário
        /// </summary>
        /// <param name="childNode"></param>
        /// <returns></returns>
        private static No Heuristica(No childNode)
        {
            #region H1 - Tiles out-of place
            if (combobox == "H1" && childNode.IsRoot == false)
            {
                childNode.H += (childNode.Data[0, 0] != (int)Configuracao.Posicao.Zero) ? 1 : 0;
                childNode.H += (childNode.Data[0, 1] != (int)Configuracao.Posicao.Um) ? 1 : 0;
                childNode.H += (childNode.Data[0, 2] != (int)Configuracao.Posicao.Dois) ? 1 : 0;

                childNode.H += (childNode.Data[1, 0] != (int)Configuracao.Posicao.Tres) ? 1 : 0;
                childNode.H += (childNode.Data[1, 1] != (int)Configuracao.Posicao.Quatro) ? 1 : 0;
                childNode.H += (childNode.Data[1, 2] != (int)Configuracao.Posicao.Cinco) ? 1 : 0;

                childNode.H += (childNode.Data[2, 0] != (int)Configuracao.Posicao.Seis) ? 1 : 0;
                childNode.H += (childNode.Data[2, 1] != (int)Configuracao.Posicao.Sete) ? 1 : 0;
                childNode.H += (childNode.Data[2, 2] != (int)Configuracao.Posicao.Oito) ? 1 : 0;
                childNode.H_L = childNode.H + childNode.Level;
            }
            #endregion
            #region H2 - Euclidean distance
            else if (combobox == "H2" && childNode.IsRoot == false)
            {
                childNode.posicaoX = new int[9];
                childNode.posicaoY = new int[9];

                int[] x = new int[9] { 2, 0, 0, 0, 1, 1, 1, 2, 2 };
                int[] y = new int[9] { 2, 0, 1, 2, 0, 1, 2, 0, 1 };


                for (int i = 0; i < 3; i++)
                {
                    for (int k = 0; k < 3; k++)
                    {

                        childNode.posicaoX[childNode.Data[i, k]] = i;
                        childNode.posicaoY[childNode.Data[i, k]] = k;
                    }
                }

                for (int i = 0; i < 9; i++)
                {
                    childNode.H += (int)Math.Sqrt(Math.Pow(childNode.posicaoX[i] - x[i], 2) + Math.Pow(childNode.posicaoY[i] - y[i], 2));
                }

                childNode.H_L = childNode.H + childNode.Level;
            }
            #endregion
            #region H3 - Manhattan distance
            else if (combobox == "H3" && childNode.IsRoot == false)
            {
                childNode.posicaoX = new int[9];
                childNode.posicaoY = new int[9];

                int[] x = new int[9] { 2, 0, 0, 0, 1, 1, 1, 2, 2 };
                int[] y = new int[9] { 2, 0, 1, 2, 0, 1, 2, 0, 1 };


                for (int i = 0; i < 3; i++)
                {
                    for (int k = 0; k < 3; k++)
                    {

                        childNode.posicaoX[childNode.Data[i, k]] = i;
                        childNode.posicaoY[childNode.Data[i, k]] = k;
                    }
                }

                for (int i = 1; i < 9; i++)
                {
                    childNode.H += Math.Abs(childNode.posicaoX[i] - x[i]) + Math.Abs(childNode.posicaoY[i] - y[i]);
                }

                childNode.H_L = childNode.H;
            }
            #endregion
            return childNode;
        }
    }
}
