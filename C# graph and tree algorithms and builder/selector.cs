using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_graph_and_tree_builder
{
    public partial class frm_menu : Form
    {
        public frm_menu()
        {
            InitializeComponent();
        }

        private void bttn_graph_Click(object sender, EventArgs e) //opens the graph form
        {
            frm_graph frm = new frm_graph();
            this.Hide();
            frm.Show();
            
        }

        private void bttn_tree_Click(object sender, EventArgs e)//opens the tree form
        {
            Tree frmt = new Tree();
            this.Hide();
            frmt.Show();
        }
    }
}
