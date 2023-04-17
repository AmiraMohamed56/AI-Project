using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace Map_Coloring_C_sharp
{
    class Moo
    {
        public Label id;
        public Color color;
        public Moo[] neighbor;



        public Moo(Label id, Color color)
        {
            this.color = color;
            this.id = id;


        }


        public bool CheckColor(Moo c1)
        {
            foreach (Moo item in c1.neighbor)
            {
                if (c1.color == item.color)
                    return false;
            }
            return true;
        }
    }
}
