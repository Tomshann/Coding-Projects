using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Drawing.Drawing2D;

namespace NEA_graph_and_tree_builder
{
    public class node
    {
        //private
       
        private int radius;
        protected PictureBox nodes = new PictureBox();
        protected string name = "";
        private static int next = 0;
        protected static bool rbdeleteselected = false;
        protected static bool rbundirected = false;
        protected static bool rbdijkstras = false;
        protected static int clickcount = 0;
        protected static int z = -1;
        protected PaintEventArgs e;
        protected static Point a;
        protected static Point b;
        protected Graphics graphicsobj;
        private static List<edge> edges = new List<edge>();
        protected static bool rbdirected = false;
        protected static int nodecounter = 0;
        protected static bool rbBF = false;
        protected static bool done = false;
        protected int weight;
        private static int temp = 0;
        static protected int click1;
        static  protected int click2;
        protected PictureBox rootnode;
        protected Label nodename = new Label();
        protected node clickednode;
        protected node clickednode2;
        protected static int[,] adjmatrix = new int[10000,10000];
        protected int nodenumber = 0;
        protected static List<node> nodearr = new List<node>();
        protected static int y = 0;
        protected List<Label> edgelengths = new List<Label>();
        frm_graph frmg;
       

        
       


        public node(frm_graph fr)
        {

            frmg = fr; //sets the frmg to the form passed in to the nodes instantiation

            nodearr.Add(this);

        }

        

        public void setizero() 
        {
            nodecounter = 0;
        }
        public void clearadjmatrix() //clears adjacenct matrix
        {
            Array.Clear(adjmatrix,0,adjmatrix.Length);

        }
        public void setnextzero()
        {
            next = 0;
        }

            
        


        public void createnode(int size, Point location, Form frm) //creates a picturebox at the loaction passed in to the function 
        {



            if (nodecounter < next)
            {
                

                radius = size;

                nodes.BackColor = Color.Red;
                nodes.Size = new Size(radius, radius);

                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, nodes.Width, nodes.Height);
                nodes.Region = new Region(path);

                nodes.Location = location;


                nodes.Click += nodes_click;

                nodes.Name = ("Node" + nodecounter);


                nodenumber = nodecounter;




                frm.Controls.Add(nodes);
                writeonimage(nodes);
                nodecounter = next;
            }



            else

            {
                radius = size;

                nodes.BackColor = Color.Red;
                nodes.Size = new Size(radius, radius);

                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, nodes.Width, nodes.Height);
                nodes.Region = new Region(path);

                nodes.Location = location;


                nodes.Click += nodes_click;

                nodes.Name = ("Node" + nodecounter);


                nodenumber = nodecounter;

               


                frm.Controls.Add(nodes);
                writeonimage(nodes);
                nodecounter++;
            }



        }
        private void writeonimage(PictureBox node)//writes the value of the node onto the picturebox
        {
            var image = new Bitmap(node.Height, node.Width);
            var font = new Font("TimesNewRoman", 20, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(this.nodenumber.ToString(),font,Brushes.Black,new Point(16,13));
            node.Image = image;
        }
  
       
        public void setrbdijkstrastrue()
        {
            rbdijkstras = true;
        }
        public void setrbdijkstrasfalse()
        {
            rbdijkstras = false;
        }
        public void setrbdirectedtrue()
        {
            rbdirected = true;
        }
        public void setrbdirectedfalse()
        {
            rbdirected = false;
        }

        public void setrbdeleteselected()
        {
            rbdeleteselected = true;
        }
        public void setrbundirected()
        {
            rbundirected = true;
        }
        public void setrbdeleteselectedfalse()
        {
            rbdeleteselected = false;
        }
        public void setrbundirectedfalse()
        {
            rbundirected = false;
        }
        public void setAdjZero(int a)//account for nodes that are deleted without being connected as they dont reset counter variable? account for directed edges
        {
            bool connected = false;
            next = nodecounter;

            while (connected == false)
            {
                for (int x = 0; x < adjmatrix.GetLength(0); x++)
                {
                    if (returnadjmatrix(a, x) > 0)
                    {
                        connected = true;
                    }
                }
                break;
            }
            temp = nodearr[a].getnumber();
            nodecounter = temp;

            if (connected == true)
            {

                for (int i = 0; i < adjmatrix.GetLength(0); i++)
                {
                    adjmatrix[a, i] = 0;
                    adjmatrix[i, a] = 0;


                }
                for (int z = 0; z < edges.Count(); z++)
                {


                    for (int i = 0; i < nodearr.Count(); i++)
                    {


                        try
                        {

                            temp = nodearr[a].getnumber();
                            nodecounter = temp;

                            edges[z].delete(i, nodearr[a]);
                            for (int x = 0; x < adjmatrix.Length; i++)
                            {
                                adjmatrix[a, i] = 0;
                                adjmatrix[i, a] = 0;

                            }







                        }
                        catch
                        {

                        }


                    }
                }
            }
            
        }
        private void nodes_click(object sender, EventArgs e) //main event handler for when a nodes is clicked on the form
        {
            if (rbdeleteselected == true)  //deletes the selected node
            {
                for (int i = 0; i < nodearr.Count(); i++)
                {
                    if (((PictureBox)sender) == nodearr[i].nodes)
                    {
                        ((PictureBox)sender).Dispose();

                         
                            
                         nodearr[i].setAdjZero(i);
                            
                        
                        
                    }
                }

               
               

            }
            if (rbundirected == true) //takes in two clicked nodes and calls create edge function to draw an edge between then
            {
                clickcount++;

                if (clickcount == 1)
                {
                    a = ((PictureBox)sender).Location;

                    click1 = this.nodenumber;
                    
                    







                }
                if (clickcount == 2)
                {
                    b = ((PictureBox)sender).Location;

                    click2 = this.nodenumber;



                    if (click1 == click2)
                    {

                        clickcount = 0;
                    }
                    else
                    {

                        Point newA = new Point(a.X + 30, a.Y + 30);
                        Point newB = new Point(b.X + 30, b.Y + 30);

                        if (((PictureBox)sender).FindForm() == frmg)
                        {

                            if (adjmatrix[click1, click2] == 0 && adjmatrix[click2, click1] == 0)
                            {
                                edge e1 = new edge();
                                edges.Add(e1);
                                e1.createEdge(newA, newB, ((PictureBox)sender).FindForm(), false);
                                e1.setconnection(nodearr[click1], nodearr[click2]);
                                e1.setedgedirected(false);



                                var inweight = (Interaction.InputBox("What is the weight between these two nodes?"));
                                bool parse = int.TryParse(inweight, out weight);



                                while (parse != true) //checks to ensure the input is an integer
                                {

                                    MessageBox.Show("input value was not an integer");
                                    inweight = (Interaction.InputBox("What is the weight between these two nodes?"));
                                    parse = int.TryParse(inweight, out weight);
                                }



                                e1.setedgelength(weight,((PictureBox)sender),a,b);


                                adjmatrix[click1, click2] = weight;
                                adjmatrix[click2, click1] = weight;


                                

                                clickcount = 0;
                            
                            }
                            else
                            {
                                MessageBox.Show("these two nodes are already connected");
                                clickcount = 0;

                            }
                        }
                        else
                        {
                            edge e1 = new edge();
                            edges.Add(e1);
                            e1.createEdge(newA, newB, ((PictureBox)sender).FindForm(), false); //creates the edge between two nodes
                            e1.setedgedirected(false);



                            
                            

                           
                            


                            clickcount = 0;
                            

                        }


                    }



                }
            }


            if (rbdirected == true) //creates an edge with direction using similar code the function above
            {
                clickcount++;

                if (clickcount == 1)
                {
                    a = ((PictureBox)sender).Location;
                    click1 = this.nodenumber;

                    //adding the connected node to the wrong node

                }
                if (clickcount == 2)
                {
                    b = ((PictureBox)sender).Location;

                    click2 = this.nodenumber;



                    if (click1 == click2)
                    {
                        clickcount = 0;
                    }

                    else
                    {
                        Point newA = new Point(a.X + 30, a.Y + 30);
                        Point newB = new Point(b.X + 30, b.Y + 30);
                        if (adjmatrix[click1, click2] == 0 && adjmatrix[click2, click1] == 0)
                        {





                            edge e1 = new edge();
                            edges.Add(e1);
                            e1.createEdge(newA, newB, ((PictureBox)sender).FindForm(), true);
                            e1.setedgedirected(true);



                            var inweight = (Interaction.InputBox("What is the weight between these two nodes?"));
                            bool parse = int.TryParse(inweight, out weight);




                            while (parse != true)
                            {

                                MessageBox.Show("input value was not an integer");
                                inweight = (Interaction.InputBox("What is the weight between these two nodes?"));
                                parse = int.TryParse(inweight, out weight);
                            }

                            e1.setedgelength(weight,((PictureBox)sender),a,b);



                            adjmatrix[click1, click2] = weight;




                            Label lblweigth = new Label();
                            Point lblpoint = new Point((((a.X + b.X) / 2)), (((a.Y + b.Y) / 2) - 30));
                            lblweigth.Location = lblpoint;
                            lblweigth.Tag = "weight" ;
                            lblweigth.Font = new Font("Arial", 14, FontStyle.Bold);
                            lblweigth.Text = weight.ToString();
                            ((PictureBox)sender).FindForm().Controls.Add(lblweigth);
                            edgelengths.Add(lblweigth);
                            clickcount = 0;
                            
                        }

                        else
                        {
                            MessageBox.Show("these nodes are already connected ");
                            clickcount = 0;


                        }

                    }

                }
            }




                
                if (rbdijkstras == true) //takes in the two clicked nodes and calls the dijkstras function to find the shortest path between the two nodes
                {
                    
                    clickcount++;
                    if (clickcount == 1)
                    {
                        a = ((PictureBox)sender).Location;

                        click1 = this.nodenumber;








                    }
                    if (clickcount == 2)
                    {
                        b = ((PictureBox)sender).Location;

                        click2 = this.nodenumber;



                        if (click1 == click2)
                        {

                            clickcount = 0;
                        }
                        else
                        {

                            frmg.dijkstras(click1, click2, adjmatrix);

                        }

                        clickcount = 0;
                    }

                }
            

        }
        public Graphics getGraphicsobj()
        {
            return graphicsobj;


        }
        public void setGreen() //sets a node green
        {
           
            nodename.BackColor = Color.LimeGreen;
            nodes.BackColor = Color.LimeGreen;        }
        public void setRed() //sets a node red
        {
            
            nodename.BackColor = Color.Red;
            nodes.BackColor = Color.Red;
        }

        public int getnumber()
        {
            return nodenumber;
        
        
        }
        public int returnadjmatrix(int i, int j)
        {
            return adjmatrix[i, j];     
        
        }

        public void deletenode(Form frm)
        {

            frm.Controls.Remove(nodes);

        }
        
       public string getname()
       {
            return nodes.Name;
       }
        


        


    }
}
