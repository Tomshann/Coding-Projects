using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Priority_Queue;

namespace NEA_graph_and_tree_builder
{
    
    public partial class Tree : Form
    {
        Binary_tree tree = null;
        
        public Tree()
        {
            InitializeComponent();
            
        }
    
        private void bttn_exit_Click(object sender, EventArgs e)//hides the tree form and opens the selection form
        {
            this.Hide();
            frm_menu frm = new frm_menu();
            frm.Show();
        }
        private void bttn_addnode_Click(object sender, EventArgs e) //checks to see if the input is an integer then adss the value to the node and calls the addnode function
        {
            if (tree == null)
            {
                tree = new Binary_tree(); //creates an instance of the binary tree class if there is no current existing tree
            }
            int value;
            var inweight = (Interaction.InputBox("What is the value of the node?"));
            bool parse = int.TryParse(inweight, out value); // takes in an input weight for the node




            while (parse != true) //checks to ensure the input is an integer
            {

                MessageBox.Show("input value was not an integer");
                inweight = (Interaction.InputBox("What is the weight between these two nodes?"));  
                parse = int.TryParse(inweight, out value);
            }





            tree.add(value, this); //calls the add function to the tree




        }

        private void bttn_preorder_Click(object sender, EventArgs e) //calls the preorder traversal function and then outputs the result
        {

            tree.preorder(tree.returnroot(),lb_output); //calls preorder traversal method on the tree
            lb_output.Items.Add("The order of the visited nodes:");
            for (int i = 0; i < Binary_tree.result.Count(); i++)
            {
               lb_output.Items.Add(Binary_tree.result[i]); //outputs the result
            }
            MessageBox.Show("press OK to continue");
            lb_output.Items.Clear();

            Binary_tree.result.Clear(); //clears the result array in the binary tree class

            for (int i = 0; i < tree_node.nodepics.Count(); i++)
            {
                tree_node.nodepics[i].BackColor = Color.Red;
            }
        }

        private void bttn_inordertraversal_Click(object sender, EventArgs e)//calls the inorder traversal function and then outputs the result
        {
            tree.inorder(tree.returnroot(),lb_output); //calls the inorder traversal method on the tree
            lb_output.Items.Add("The order of the visited nodes:");
            for (int i = 0; i < Binary_tree.result.Count(); i++)
            {
                lb_output.Items.Add(Binary_tree.result[i]); //outputs the result
            }
            MessageBox.Show("press OK to continue");
            lb_output.Items.Clear();

            Binary_tree.result.Clear(); //clears the result array
            for (int i = 0; i < tree_node.nodepics.Count(); i++)
            {
                tree_node.nodepics[i].BackColor = Color.Red;
            }
        }

        private void bttn_postordertraversal_Click(object sender, EventArgs e)//calls the postorder traversal function and then outputs the result
        {
            tree.postorder(tree.returnroot(),lb_output);//calls the postorder traversal method on the tree
            lb_output.Items.Add("The order of the visited nodes:");
            for (int i = 0; i < Binary_tree.result.Count(); i++)
            {
                lb_output.Items.Add(Binary_tree.result[i]); //outputs the result
            }
            MessageBox.Show("press OK to continue");
            lb_output.Items.Clear();

            Binary_tree.result.Clear(); //clears the result of the array
            for (int i = 0; i < tree_node.nodepics.Count(); i++)
            {
                tree_node.nodepics[i].BackColor = Color.Red;
            }
        }

        private void bttnclearnodes_Click(object sender, EventArgs e)//Find a way to clear the node pointers
        {
            this.Invalidate(); //removes the edges of the nodes

            for (int i = 0; i < tree.returnpicarray().Count(); i++)
            {
                this.Controls.Remove(tree.returnnodepic(i)); //calls the remove function on the tree to empty the data structures
            }
            tree.Reset();//calls the reset function to delete the pictureboxes

            
        }
    }
}
