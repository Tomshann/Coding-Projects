using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NEA_graph_and_tree_builder
{
    class tree_node
    {
        private int value; //represents the value of the node
        private tree_node right; //represents the right and left node
        private tree_node left;
        private static Binary_tree tree;
        private int number;
        private Tree frmt = new Tree();
        private PictureBox node = new PictureBox();
        public static List<PictureBox> nodepics = new List<PictureBox>(); //creates a list of pictureboxes
        private static int i;
        private static int b = 0;
        private int nodenumber;
        private static int g = 300;
        


        public tree_node(Tree frm, int val, Binary_tree tr) //sets the frmt vartiable to the tree form and adds the value to the node, also sets the tree variable to the binary tree.
        {
            frmt = frm;
            this.value = val;
            number = b;
            b++;
            tree = tr;
        }

        public List<PictureBox> returnpicarray()
        {
            return nodepics; //returns the array of pictureboxes
        }
        public PictureBox returnpicarrayitem(int z)
        {
            return nodepics[z]; //returns a specific node picturebox
        }
        



        public PictureBox getpic()
        {
            return node; //returns the picturebox of the associated node
        }
        public void setnodenumber(int z)
        {
            nodenumber = z; //sets the nodenumber

        }

        public int returnval()
        { 
            return value; //returns the node value
        }
        public tree_node returnleft()
        {
            return left; //returns the node to the left of the specified node
        }
        public tree_node returnright()
        {
            return right;//returns the node to ther right of the specified node
        }
        public void setleft(tree_node node)
        {
            left = node; //sets the node that is to the left of the specified node 
        }
        public void setright(tree_node node)
        {
            right= node; //sets the node that is to the right of the specified node
        }
        public void setGreen()
        {
            node.BackColor = Color.Green;
        }
        public void setRed()
        {
            node.BackColor = Color.Red;
        }


        
        public void creategraphicsleft(Tree frm,int value, tree_node nodes) //creates a node picturebox to the left of the previous node 
        {
            
            node.BackColor = Color.Red;
            node.Size = new Size(50, 50);

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, node.Width, node.Height);
            node.Region = new Region(path);
            if (nodes == tree.returnroot())
            {
                Point z = new Point(nodepics[nodes.number].Location.X - 60-g, nodepics[nodes.number].Location.Y + 80); //identifies the location to the left for the picturebox based on the previous node
                node.Location = z;
            }
            else
            {
                Point z = new Point(nodepics[nodes.number].Location.X - 60, nodepics[nodes.number].Location.Y + 80);
                node.Location = z;
            }



            node.Name = ("Node" + i);//sets the nodename


            nodenumber = i; //sets the nodenumber

            


            frm.Controls.Add(node);
            writeonimage(node,value);
            nodepics.Add(node);//adds the node to the form


           
            i++;
            

        }
        public void creategraphicsright(Tree frm, int value, tree_node nodes) //creates the node picturebox to the right of the previous node
        {
            
           

            node.BackColor = Color.Red;
            node.Size = new Size(50, 50);

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, node.Width, node.Height);
            node.Region = new Region(path);


            if (nodes == tree.returnroot())
            {

                Point z = new Point(nodepics[nodes.number].Location.X + 60 + g, nodepics[nodes.number].Location.Y + 80); //sets the node locations to the right of the previous node
                node.Location = z;

            }
            else
            {
                Point z = new Point(nodepics[nodes.number].Location.X + 60 , nodepics[nodes.number].Location.Y + 80);
                node.Location = z;
            }
            



            node.Name = ("Node" + i); //sets the name of the node


            nodenumber = i; //sets the nodenumber

            



            frm.Controls.Add(node);
            writeonimage(node,value);
            nodepics.Add(node); //creates the node on the form



            i++;
           
        }
        public void creategraphics(Tree frm, int value) //creates the root node  picturebox
        {
            


            node.BackColor = Color.Red;
            node.Size = new Size(50, 50);

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, node.Width, node.Height);
            node.Region = new Region(path);

            Point z = new Point( 700, 80); //sets the location of the root node
            node.Location = z;



            node.Name = ("Node" + i); //names the root node


            nodenumber = i; //sets the node number 




            frm.Controls.Add(node);
            writeonimage(node, value);
            nodepics.Add(node); //adds the node to the form



            i++;

        }
        private void writeonimage(PictureBox node,int value) // writes the value of the node onto the picturebox
        {
            var image = new Bitmap(node.Height, node.Width);
            var font = new Font("TimesNewRoman", 20, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(value.ToString(), font, Brushes.Black, new Point(16, 13));
            node.Image = image;
        }

    }
}
