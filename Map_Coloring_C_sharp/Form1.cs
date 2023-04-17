using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Map_Coloring_C_sharp
{
    public partial class Form1 : Form
    {

        bool active = false;
        Color color;
        List<Label> m = new List<Label>();
        List<Label> neighbour = new List<Label>();

        private bool checkdrw()
        {
            if (active == false)
            {
                MessageBox.Show("PLS Active Color....");
                m.Remove(m[m.Count - 1]);
                return false;
            }
            for (int i = 0; i < m.Count; i++)
            {
                for (int j = i + 1; j < m.Count; j++)
                {
                    if (m[i] == m[j])
                    {

                        m.Remove(m[i]);
                        return false;
                    }
                }
            }

            checkwin();
            return true;
        }

        private void checkwin()
        {
            if (m.Count == 12)
            {
                MessageBox.Show("OOoow You Win .....");

            }

        }

        private bool chickneighbors(List<Label> mo, Label pic)
        {
            for (int i = 0; i < mo.Count; i++)
            {
                if (pic.BackColor == mo[i].BackColor)
                {
                    MessageBox.Show("You Are Loser ......");
                    clearalldata();
                    return false;
                }
            }
            return true;
        }


        private void clearalldata()
        {
            foreach (var item in m)
            {
                item.BackColor = Color.Empty;
                color = Color.Empty;
                Active_color.BackColor = Color.Empty;
            }
            m.Clear();
            active = false;
        }





        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Random rnd = new Random();
            List<Label> memo = new List<Label>();
            List<Moo> em = new List<Moo>();
            List<Moo> assignment = new List<Moo>();
            Color[] Domain = new Color[3] { Color.Red, Color.Blue, Color.Green };

            Moo c1 = new Moo(label1, Color.Empty);
            Moo c2 = new Moo(label2, Color.Empty);
            Moo c3 = new Moo(label3, Color.Empty);
            Moo c4 = new Moo(label4, Color.Empty);
            Moo c5 = new Moo(label5, Color.Empty);
            Moo c6 = new Moo(label6, Color.Empty);
            Moo c7 = new Moo(label7, Color.Empty);
            Moo c8 = new Moo(label8, Color.Empty);
            Moo c9 = new Moo(label9, Color.Empty);
            Moo c10 = new Moo(label10, Color.Empty);
            Moo c11 = new Moo(label11, Color.Empty);
            Moo c12 = new Moo(label12, Color.Empty);

            c1.neighbor = new Moo[] { c2, c3 };
            c2.neighbor = new Moo[] { c1, c4};
            c3.neighbor = new Moo[] { c1, c5, c4 };
            c4.neighbor = new Moo[] { c2, c3 };
            c5.neighbor = new Moo[] { c3, c6 };
            c6.neighbor = new Moo[] {  c5, c7, c8 };
            c7.neighbor = new Moo[] {  c6, c8, c9 };
            c8.neighbor = new Moo[] { c6, c7, c10 };
            c9.neighbor = new Moo[] { c7, c10,c11,c12 };
            c10.neighbor = new Moo[] { c8, c9, c12 };
            c11.neighbor = new Moo[] { c9 };
            c12.neighbor = new Moo[] { c9, c10 };

            em.Add(c1);
            em.Add(c2);
            em.Add(c3);
            em.Add(c4);
            em.Add(c5);
            em.Add(c6);
            em.Add(c7);
            em.Add(c8);
            em.Add(c9);
            em.Add(c10);
            em.Add(c11);
            em.Add(c12);


            //---------------------------------Dfs----------------------------//

            /*
                    Stack BfsFringe = new Stack();

                    //1. Add initial node to fringe
                    BfsFringe.Push(c1);

                    //2. Repeat until fringe.count==0
                    while (BfsFringe.Count != 0)
                    {
                        //2.1 Extract current node from fringe
                        Moo currentNode = (Moo)BfsFringe.Pop();
                        //2.2. check if current node color
                        if (currentNode.color == Color.Empty)
                        {

                            while (!currentNode.CheckColor(currentNode))
                            {
                                int h = rnd.Next(0, Domain.Length);
                                currentNode.color = Domain[h];
                            }

                            currentNode.id.BackColor = currentNode.color;
                             MessageBox.Show(assignment.Count+"   ---  "+currentNode.id.Text+"  ---   "+BfsFringe.Count);
                        }

                        //2.3 add its child to fringe
                        Moo[] child = currentNode.neighbor;
                        //Add child to fringe
                        for (int i = child.Length-1 ; i >= 0; i--)
                        {
                            BfsFringe.Push(child[i]);
                        }
                    }     


                    */

            /*
            Queue BfsFringe = new Queue();
            //1. Add initial node to fringe
            BfsFringe.Enqueue(c1);
            while (BfsFringe.Count != 0)
            {
                //2.1 Extract current node from fringe
                Moo currentNode = (Moo)BfsFringe.Dequeue();
                if (currentNode.color == Color.Empty)
                {
                    //2.2. check  current node color
                    while (!currentNode.CheckColor(currentNode))
                    {
                        int h = rnd.Next(0, Domain.Length);
                        currentNode.color = Domain[h];
                    }
                    assignment.Add(currentNode);
                    currentNode.id.BackColor = currentNode.color;
                    //  MessageBox.Show("   ---  "+currentNode.id.Text+"  ---   "+BfsFringe.Count);
                    Moo[] child = currentNode.neighbor;
                    //Add child to fringe
                    for (int i = 0; i < child.Length; i++)
                    {
                        BfsFringe.Enqueue(child[i]);
                    }
                    //  lbl13.BackColor = Color.Yellow;
                }
            }

            */




            for (int g = 0; g < em.Count; g++)
            {
                while (assignment.Count <= g)
                {
                    int h = rnd.Next(0, Domain.Length);
                    em[g].color = Domain[h];
                    if (em[g].CheckColor(em[g]))
                    {
                        em[g].id.BackColor = Domain[h];
                        assignment.Add(em[g]);
                    }
                }
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {
            m.Add(label1);
            if (checkdrw())
            {
                neighbour.Add(label2);
                neighbour.Add(label3);
                label1.BackColor = color;
                chickneighbors(neighbour, label1);
                neighbour.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            m.Add(label2);
            if (checkdrw())
            {
                neighbour.Add(label1);
                neighbour.Add(label4);
                label2.BackColor = color;
                chickneighbors(neighbour, label2);
                neighbour.Clear();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            m.Add(label3);
            if (checkdrw())
            {
                neighbour.Add(label1);
                neighbour.Add(label4);
                neighbour.Add(label5);
                label3.BackColor = color;
                chickneighbors(neighbour, label3);
                neighbour.Clear();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            m.Add(label4);
            if (checkdrw())
            {
                neighbour.Add(label2);
                neighbour.Add(label3);
                label4.BackColor = color;
                chickneighbors(neighbour, label4);
                neighbour.Clear();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            m.Add(label5);
            if (checkdrw())
            {
                neighbour.Add(label3);
                neighbour.Add(label6);
                label5.BackColor = color;
                chickneighbors(neighbour, label5);
                neighbour.Clear();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            m.Add(label6);
            if (checkdrw())
            {
                neighbour.Add(label7);
                neighbour.Add(label8);
                neighbour.Add(label5);
                label6.BackColor = color;
                chickneighbors(neighbour, label6);
                neighbour.Clear();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            m.Add(label7);
            if (checkdrw())
            {
                neighbour.Add(label6);
                neighbour.Add(label9);
                neighbour.Add(label8);
                label7.BackColor = color;
                chickneighbors(neighbour, label7);
                neighbour.Clear();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            m.Add(label8);
            if (checkdrw())
            {
                neighbour.Add(label6);
                neighbour.Add(label7);
                neighbour.Add(label10);
                label8.BackColor = color;
                chickneighbors(neighbour, label8);
                neighbour.Clear();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            m.Add(label9);
            if (checkdrw())
            {
                neighbour.Add(label7);
                neighbour.Add(label10);
                neighbour.Add(label11);
                neighbour.Add(label12);
                label9.BackColor = color;
                chickneighbors(neighbour, label9);
                neighbour.Clear();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            m.Add(label10);
            if (checkdrw())
            {
                neighbour.Add(label8);
                neighbour.Add(label9);
                neighbour.Add(label12);
                label10.BackColor = color;
                chickneighbors(neighbour, label10);
                neighbour.Clear();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            m.Add(label12);
            if (checkdrw())
            {
                neighbour.Add(label9);
                neighbour.Add(label10);
                label12.BackColor = color;
                chickneighbors(neighbour, label12);
                neighbour.Clear();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            m.Add(label11);
            if (checkdrw())
            {
                neighbour.Add(label9);
                label11.BackColor = color;
                chickneighbors(neighbour, label11);
                neighbour.Clear();
            }
        }

        private void RED_Click(object sender, EventArgs e)
        {
            color = RED.BackColor;
            Active_color.BackColor = color;
            active = true;
        }

        private void GREEN_Click(object sender, EventArgs e)
        {
            color = GREEN.BackColor;
            Active_color.BackColor = color;
            active = true;
        }

        private void BLUE_Click(object sender, EventArgs e)
        {
            color = BLUE.BackColor;
            Active_color.BackColor = color;
            active = true;
        }
    }
}
