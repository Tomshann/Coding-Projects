
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
using Priority_Queue;

namespace NEA_graph_and_tree_builder
{
   
    
    public partial class frm_graph : Form
    {

        
        
        bool next = false; 



        List<node> nodes = new List<node>(); // creates a list of nodes
        public frm_graph()
        {
            InitializeComponent();

            
            
            

        }
       

       


        private void Graph_Click(object sender, EventArgs e)
        {
            
           

            if (rbAddNode.Checked == true) // checks if the addnode button is selected and if it is then calls a function to create a node where the cursor clicks
            {
                
                
                node node1 = new node(this);

                int x = MousePosition.X;
                int y = MousePosition.Y;

                Point p1 = new Point(x - 10, y - 25); //The point on the form where the node will be created based on the cursor position 

                node1.createnode(50, p1, this); //creates the node at the point



                bool res = false;
                 
                    
                                                   
                
              for (int i = 0; i < nodes.Count(); i++)
              {
                   if (nodes[i].getnumber() == node1.getnumber()) //replaces the node if it already exists
                   {
                     nodes[i] = node1;
                        
                     res = true;
                   }
              }

                if (res == false)
                {
                    nodes.Add(node1); //if not identical to another node then add to the list
                    
                    res = true;
                }


            }




        }

        private void bttn_exit_Click(object sender, EventArgs e) //when exit button clicked hides the form and returns to the menu form
        {
            try
            {
                nodes[0].setcounterzero();            //calls these functions to reset the counter variables when the exit button is clicked
                nodes[0].setnextzero();

            }
            catch { }

            
            
            this.Hide();
            
            frm_menu frm = new frm_menu(); //opens the menu form
            frm.Show();
            
        }

        private void bttnclearnodes_Click(object sender, EventArgs e) // clears all nodes and edges on the form and empties the adjacency matrix to avoid errors
        {
            for (int i = 0; i < nodes.Count(); i++) //clears all data structures containing the nodes and gets rid of their associated pictureboxes
            {
                nodes[i].deletenode(this);
                nodes[i].clearadjmatrix();
                nodes[i].setcounterzero();

            }

            this.Invalidate(); //removes the edges from the form

            for (int i = 0; i < nodes.Count; i++)
            {
                foreach (Control ctrl in this.Controls.OfType<Label>().Where(x => x.Tag == "weight")) //removes the weights of the edges
                {
                    this.Controls.Remove(ctrl);
                }
            }
        }

        private void frm_graph_Load(object sender, EventArgs e)
        {

        }
        

        private void timer1_Tick(object sender, EventArgs e) //timer is ticking to recognise when a radiobutton has it state changed to checked to then tell the nodes to perform a function
        {
           
           
            if (rbdeletenode.Checked == true)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].setrbdeleteselected();
                }
            }
            if (rbAddundirected.Checked == true)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].setrbundirected();
                    
                }
                
                
            }
            if (rbdeletenode.Checked == false)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].setrbdeleteselectedfalse();
                }
            }
            if (rbAddundirected.Checked == false)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].setrbundirectedfalse();
                }
            }
            if (rbAddDirected.Checked == true)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].setrbdirectedtrue();

                }


            }
            if (rbAddDirected.Checked == false)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].setrbdirectedfalse();

                }





            }
            if (rb_dijkstras.Checked == true)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    
                    nodes[i].setrbdijkstrastrue();
                  
                }


            }
            if(rb_dijkstras.Checked == false)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].setrbdijkstrasfalse();

                }





            }

        }
      

        public void dijkstras(int startnodenumber, int targetnodenumber, int[,] adjmatrix) //finds the shortest path between two selected nodes
                                                                                         
        {
            node start = nodes[startnodenumber];  //identifies the start and end nodes
            node end  = nodes[targetnodenumber];
            lb_stack.Items.Add("Priority queue:");
            node x;
            int z = int.MaxValue;
            bool[] visited = new bool[nodes.Count()]; //creates an array which will contain wether a node has been visited or not
            SimplePriorityQueue<node> queue = new SimplePriorityQueue<node>(); //creates a priority queue for the nodes to be inserted into
            List<node> result = new List<node>(); //creates a list of the resulting node path
            queue.Enqueue(start, 0); //enqueues the root with zero priority
            int[] dist = new int[nodes.Count()];
            dist[start.getnumber()] = 0;
            int alt = 0;

            for (int i = 0; i < nodes.Count(); i++) //loops through the rest of the nodes and enqueue them with infinite priority
            {
                if (i != start.getnumber())
                {
                    dist[i] = z;
                    
                
                }
                queue.Enqueue(nodes[i], dist[i]);
                lb_stack.Items.Add(nodes[i].getname() + " " + dist[i]);
                
            }
            lb_output.Items.Add("Enqueuing all nodes with infinite distance and root node with distance of 0");
            MessageBox.Show("press OK to continue");
            while (queue.Count() != 0)
            {

                
                   x = queue.Dequeue(); //dequeues the node with lowest priority
                if (!result.Contains(x))
                {
                    result.Add(x); //adds the node to the result
                }
                if (!lb_output.Items.Contains("dequeing node " + x.getnumber().ToString()))
                {
                    lb_output.Items.Add("dequeing node " + x.getnumber().ToString());
                    lb_output.Items.Add("Checking nodes connected to node:" + x.getnumber().ToString());
                }
                else
                {
                    lb_output.Items.Add("checking for other nodes connected to node " + x.getnumber().ToString());
                }
                lb_stack.Items.Remove(x.getname() + " " + dist[x.getnumber()]);
                
                MessageBox.Show("Press OK to continue");
               
                x.setGreen();
                visited[x.getnumber()] = true; //marks the node as visited


                for (int a = 0; a < nodes.Count(); a++)
                {
                    if (x.returnadjmatrix(x.getnumber(), a) > 0 && visited[a] == false) //loops through the rest of the nodes connected to the dequeued node and checks to see if they have been visited
                    {
                        if (!visited[a])
                        {
                            lb_output.Items.Add("Found node:" + a);
                            lb_output.Items.Add("distance from previous node = " + x.returnadjmatrix(x.getnumber(), a));
                        }
                        else
                        {
                            lb_output.Items.Add("no other nodes found progressing to next node");
                        }
                        
                        alt = dist[x.getnumber()] + x.returnadjmatrix(x.getnumber(), a); //gets the distance between the two nodes and assigns this to a temporary variable
                        if (alt < dist[a] && alt > 0 ) //checks the temporary distance against the current distance to see if it is shorter
                        {


                            dist[a] = alt; //replaces the distance
                            lb_output.Items.Add("updating the distance of node:" + nodes[a].getnumber().ToString() + " in the queue");
                            lb_stack.Items.Remove(nodes[a].getname() + " " + dist[a]);
                            lb_stack.Items.Remove(nodes[a].getname() + " " + int.MaxValue);
                            queue.Enqueue(nodes[a], dist[a]); //equeues this node as the new node
                            lb_stack.Items.Add(nodes[a].getname() + " " + dist[a]);

                            visited[a] = true; // marks the node as visited
                        }
                        
                    }

                    
                }
            }

            lb_output.Items.Add("The shortest distance between the two nodes is: "+(dist[end.getnumber()].ToString()));


            lb_output.Items.Add("The order in which the nodes were cheked was:");

            
            for (int i = 0; i < result.Count(); i++)
            {
                
                lb_output.Items.Add(result[i].getname()) ; //outputs the result
            }
            for (int i = 0; i < nodes.Count(); i++)
            {
                nodes[i].setRed();
            }

            MessageBox.Show("press OK to finsih algorithm");

            lb_stack.Items.Clear(); 
            lb_output.Items.Clear();

        }

        
        private void bttn_bfs_Click_1(object sender, EventArgs e)  //breadth first search starting from the root of the graph
        {
            List<string> output = new List<string>(); // creates a list for the output
            MessageBox.Show("This algorithm will show the order in which nodes would be checked in a breadth first search ");
            bool[] visited = new bool[nodes.Count()]; // creates an array to check if a node has been visited
            Queue<node> q = new Queue<node>(); //creates a queue
            node s = nodes[0]; //identifies the start node
            visited[s.getnumber()] = true; //marks the node as visited
            q.Enqueue(s); //eqnueues the node
            lb_stack.Items.Add("queue:");
            lb_stack.Items.Add(s.getname());

            while (q.Count() != 0)
            {
                s = q.Dequeue(); //dequeues the node
                lb_stack.Items.Remove(s.getname());
                lb_output.Items.Add("removing " + s.getname() + " from queue");
                output.Add(s.getname()); //adds it to the output list
                MessageBox.Show("press OK to continue");
                s.setGreen();
                lb_output.Items.Add("checking nodes connected to: " + s.getname());

                for (int i = 0; i < nodes.Count; i++)
                {
                    if (!visited[i] && s.returnadjmatrix(s.getnumber(), i) > 0) //checks if any other nodes are connected
                    {
                        visited[i] = true; //mark it as visited 
                        q.Enqueue(nodes[i]);//enqueue the node
                        lb_output.Items.Add("adding " + nodes[i].getname() + " to the queue");
                        lb_stack.Items.Add(nodes[i].getname());
                        nodes[i].setGreen();
                        MessageBox.Show("press OK to continue");

                    }
                }



            }
            lb_output.Items.Add("algorithm complete");
            lb_output.Items.Add("The order of visited nodes:");
            lb_stack.Items.Clear();
            for (int i = 0; i < output.Count(); i++)
            {
                lb_output.Items.Add(output[i]);     //outputs the result
                nodes[i].setRed();
            }
            MessageBox.Show("Press OK to finsih");

            lb_output.Items.Clear();
        }

        private void bttn_dfs_Click(object sender, EventArgs e)  //depth first search starting from the root node
        {
            MessageBox.Show("This algorithm will show the order in which nodes would be checked in a depth first search ");
            bool[] visited = new bool[nodes.Count()]; //creates an array to determine if a node has been visited
            string output = "";
            node node1 = nodes[0]; //marks the start nbode
            node current;
            

            Stack<node> s = new Stack<node>(); //creates a stack to store the nodes
            s.Push(node1); //pushes the start node onto the stack
            lb_stack.Items.Add("Stack:");

            while (s.Count()>0) //while the stack is not empty
            {
                
                current = s.Pop(); //pop the node off the top of the stack
                lb_stack.Items.Remove(current.getnumber());
                 if (!visited[current.getnumber()]) //if the node has not been visited 
                 {
                    
                    MessageBox.Show("press OK to continue");
                    

                        lb_output.Items.Add("checking nodes connected to: " + current.getname());


                        current.setGreen();
                    
                    output += current.getname() + ","; //adds the node to the output

                        
                
                
                 }

                for (int i = 0; i < nodes.Count(); i++)
                {
                    if (current.returnadjmatrix(current.getnumber(), i) > 0 && visited[i] == false ) //checks for connected nodes

                    {
                        s.Push(current); //push the node onto the stack
                        visited[current.getnumber()] = true; // mark the node as visited
                        visited[i] = true;
                        lb_output.Items.Add("Found: " + nodes[i].getname()+ " checking nodes connected to it");
                        MessageBox.Show("press OK to continue");
                        output += nodes[i].getname() +","; //add the node to output
                        nodes[i].setGreen();
                        current = nodes[i];
                        lb_stack.Items.Add(s.Peek().getnumber());
                    }
                     

                
                }



                
                lb_output.Items.Add("stepping back to previous node to check for other connected nodes");
                MessageBox.Show("press OK to continue");

                next = false;



            }
            lb_output.Items.Add("all nodes checked. Algorithm complete.");
            lb_output.Items.Add("The order of the nodes in which they have been checked is: " + output); //outputs the result
            MessageBox.Show("press OK to continue");
            for (int i = 0; i < nodes.Count(); i++)
            {
                nodes[i].setRed();

            }
            lb_output.Items.Clear();
            lb_stack.Items.Clear();
        }

        

      
    }
}
