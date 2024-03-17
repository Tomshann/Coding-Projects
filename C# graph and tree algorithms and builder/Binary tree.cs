using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace NEA_graph_and_tree_builder
{
    class Binary_tree
    {

        private static tree_node root; //defines the root of the tree


        private static List<edge> edges = new List<edge>(); //a container for all the edges
        private static Tree frm; //an instance of the form that the tree will be displayed on

        public static List<int> result = new List<int>(); // a container for the result of the searc algorithms
        public Binary_tree()
        {

        }


        public PictureBox returnnodepic(int i)
        {
            return root.returnpicarrayitem(i); //returns a specific node in the tree
        }
        public List<PictureBox> returnpicarray()
        {
            return root.returnpicarray(); // returns the whole array of tree nodes
        }

        public void Reset() //clears and resets the tree
        {
            root = null;
            edges.Clear();
            result.Clear();
        
        }

        public bool add(int data, Tree t)
        {
            frm = t;
            tree_node before = null;   //inserts root into binary tree
            tree_node after = root;
            while (after != null)
            {
                before = after;
                if (data < after.returnval())
                {
                    after = after.returnleft();   

                }
                else if (data > after.returnval())
                {
                    after = after.returnright();
                }
                else
                {
                    return false;
                }
            }
            tree_node newnode = new tree_node(t, data, this);

            if (root == null)
            {
                root = newnode;    //sets the first created node as root
                root.creategraphics(t, data); //creates a physical image of the node
            }
            else
            {
                if (data < before.returnval()) //places node to the left if its data is less than the previous
                {
                    before.setleft(newnode); //sets the left of the previous node to the newly created node
                    before.returnleft().creategraphicsleft(t, data, before);

                    Point a = new Point(before.getpic().Location.X + 30, before.getpic().Location.Y + 30);
                    Point b = new Point(before.returnleft().getpic().Location.X + 30, before.returnleft().getpic().Location.Y + 30);
                    edge e1 = new edge();
                    edges.Add(e1); 
                    e1.createEdge(a, b, t, false); //creates an edge and adds it to the form
                    e1.setedgedirected(false);
                }
                else
                {
                    before.setright(newnode); //places node to the right if its data is more than the previous node
                    before.returnright().creategraphicsright(t, data, before); // creates a physical image to the right of the created node

                    Point a = new Point(before.getpic().Location.X + 30, before.getpic().Location.Y + 30);
                    Point b = new Point(before.returnright().getpic().Location.X + 30, before.returnright().getpic().Location.Y + 30);
                    edge e1 = new edge();
                    edges.Add(e1);
                    e1.createEdge(a, b, t, false);//adds the edge to the form 
                    e1.setedgedirected(false); 
                }
            }

            return true;
        }
        public tree_node returnroot()
        {
            return root; 
        }
        public void preorder(tree_node parent, ListBox lb)
        {

            if (parent != null)                          //performs an preorder traversal around the nodes in the tree
            {

                result.Add(parent.returnval()); //adds the root to the result
                lb.Items.Add("Found:" + parent.returnval());

                parent.setGreen();
                MessageBox.Show("press ok to continue");

                lb.Items.Add("checking the left subtree");
                preorder(parent.returnleft(), lb); //recursively traverses the left subtree adding each node to the result
                lb.Items.Add("checking the right subtree");
                preorder(parent.returnright(), lb); //recursively traverses the right subtree adding each node to the result
            }
            else
            {
                lb.Items.Add("no more sub trees,traversing to the previous node");
            }


        }
        public void inorder(tree_node parent, ListBox lb)  //performs an inorder traversal around the nodes in the tree
        {

            if (parent != null)
            {
                lb.Items.Add("checking the left subtree");
                inorder(parent.returnleft(), lb); //recursively traverses the left subtree adding each node to the result
                result.Add(parent.returnval()); // adds the root to the result
                lb.Items.Add("Found:" + parent.returnval());
                parent.setGreen();
                MessageBox.Show("press ok to continue");
                lb.Items.Add("checking the right subtree");
                inorder(parent.returnright(), lb); // recursively traverses the right subtree adding each node to the result
            }
            else
            {
                lb.Items.Add("no more sub trees,traversing to the previous node");
            }
        }

        public void postorder(tree_node parent, ListBox lb)  //performs an postorder traversal around the nodes in the tree
        {

            if (parent != null)
            {
                lb.Items.Add("checking the left subtree");
                postorder(parent.returnleft(), lb);  //recursively checks the left subtree adding each node to the result
                lb.Items.Add("checking the right subtree");
                postorder(parent.returnright(), lb); // recursively checks the right subtree adding each node to the result
                result.Add(parent.returnval());
                lb.Items.Add("Found:" + parent.returnval()); // adds the root to the result
                parent.setGreen();
                MessageBox.Show("press ok to continue");
            }
            else
            {
                lb.Items.Add("no more sub trees,traversing to the previous node");
            }

        }













    }  

}

