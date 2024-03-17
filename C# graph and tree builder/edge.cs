using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace NEA_graph_and_tree_builder
{
    class edge
    {
        private bool isDirected; //checks wether the edge is directed
        private Point startpoint; //identifies the start and endpoint of the edge
        private Point endpoint;
        private int edgelength;
        private Graphics graphicsobj;
        private List<edge> edgelist = new List<edge>(); //a list to contain the edges
        private static int i =0;
        private node connection1; //two connections to identify the nodes the edge is connected to
        private node connection2;
        private Label lblweight = new Label(); // a label to represnt the weight of a node




        public edge()
        {

            edgelist.Add(this); //adds the edge to the list of edges

        }

        public void setconnection(node n1 , node n2) //sets the connected nodes to the edge
        {
            connection1 = n1; 
            connection2 = n2;
        }

        public void delete(int a , node n) 
        {

            Pen p1 = new Pen(Color.White, 3);
            int x = endpoint.X - 25;
            int y = endpoint.Y;

            if (isDirected == false)
            {
                if (edgelist[a].connection1 == n || edgelist[a].connection2 == n)
                {
                    graphicsobj.DrawLine(p1, edgelist[a].startpoint, edgelist[a].endpoint); //deletes the edge
                    edgelist[a].lblweight.Hide();

                }

            }
            else
            {
                if (edgelist[a].connection1 == n || edgelist[a].connection2 == n)
                {
                    AdjustableArrowCap bigarrow = new AdjustableArrowCap(5, 5); 
                    p1.CustomEndCap = bigarrow;
                    graphicsobj.DrawLine(p1, edgelist[a].startpoint, new Point(x,y) );//deletes the edge
                    edgelist[a].lblweight.Text="";
                    
                   

                }

            }

        }


        public void createEdge(Point start, Point end, Form frm, bool directed) //creates a line betwenn the two nodes/points specified
        {
            
            startpoint = start;
            endpoint = end;
            int x = endpoint.X - 25;
            int y = endpoint.Y ;
            


            graphicsobj = frm.CreateGraphics();
            Pen p1 = new Pen(Color.Black, 3);

            if (directed == true) //checks if the edge is directed or not
            {
                AdjustableArrowCap bigarrow = new AdjustableArrowCap(5, 5);
                p1.CustomEndCap = bigarrow;
                graphicsobj.DrawLine(p1, startpoint, new Point(x, y)); //draws a directed edge
            }
            else
            {
                graphicsobj.DrawLine(p1, startpoint, endpoint); //draws an undirected edge

            }

            i++;

        }
        public void setedgedirected(bool inp)
        {
            isDirected = inp; //sets the edge to be directed/undirected
        
        }
        public int getedgelength()
        {
            return edgelength; //returns the edge weight
        
        }
        public void setedgelength(int x,PictureBox sender,Point a , Point b)
        {
            edgelength = x; // sets the edge weight

            
            Point lblpoint = new Point((((a.X + b.X) / 2)), (((a.Y + b.Y) / 2) - 30));
            lblweight.Location = lblpoint;
            lblweight.Tag = "weight";

            lblweight.Font = new Font("Arial", 14, FontStyle.Bold);
            lblweight.Text = x.ToString();
            (sender).FindForm().Controls.Add(lblweight); // adds the weight to a label on the form


        }

        
    }
}
