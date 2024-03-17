
namespace NEA_graph_and_tree_builder
{
    partial class Tree
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lb_output = new System.Windows.Forms.ListBox();
            this.bttnclearnodes = new System.Windows.Forms.Button();
            this.bttn_exit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bttn_preorder = new System.Windows.Forms.Button();
            this.bttn_addnode = new System.Windows.Forms.Button();
            this.bttn_postordertraversal = new System.Windows.Forms.Button();
            this.bttn_inordertraversal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_output
            // 
            this.lb_output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_output.Dock = System.Windows.Forms.DockStyle.Right;
            this.lb_output.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_output.FormattingEnabled = true;
            this.lb_output.HorizontalScrollbar = true;
            this.lb_output.ItemHeight = 16;
            this.lb_output.Location = new System.Drawing.Point(673, 0);
            this.lb_output.Name = "lb_output";
            this.lb_output.ScrollAlwaysVisible = true;
            this.lb_output.Size = new System.Drawing.Size(619, 560);
            this.lb_output.TabIndex = 17;
            // 
            // bttnclearnodes
            // 
            this.bttnclearnodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnclearnodes.Location = new System.Drawing.Point(182, 12);
            this.bttnclearnodes.Name = "bttnclearnodes";
            this.bttnclearnodes.Size = new System.Drawing.Size(106, 46);
            this.bttnclearnodes.TabIndex = 21;
            this.bttnclearnodes.Text = "Clear nodes and edges";
            this.bttnclearnodes.UseVisualStyleBackColor = true;
            this.bttnclearnodes.Click += new System.EventHandler(this.bttnclearnodes_Click);
            // 
            // bttn_exit
            // 
            this.bttn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_exit.Location = new System.Drawing.Point(12, 12);
            this.bttn_exit.Name = "bttn_exit";
            this.bttn_exit.Size = new System.Drawing.Size(73, 46);
            this.bttn_exit.TabIndex = 20;
            this.bttn_exit.Text = "Exit";
            this.bttn_exit.UseVisualStyleBackColor = true;
            this.bttn_exit.Click += new System.EventHandler(this.bttn_exit_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // bttn_preorder
            // 
            this.bttn_preorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_preorder.Location = new System.Drawing.Point(294, 12);
            this.bttn_preorder.Name = "bttn_preorder";
            this.bttn_preorder.Size = new System.Drawing.Size(97, 46);
            this.bttn_preorder.TabIndex = 23;
            this.bttn_preorder.Text = "Pre Order Traversal";
            this.bttn_preorder.UseVisualStyleBackColor = true;
            this.bttn_preorder.Click += new System.EventHandler(this.bttn_preorder_Click);
            // 
            // bttn_addnode
            // 
            this.bttn_addnode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_addnode.Location = new System.Drawing.Point(91, 12);
            this.bttn_addnode.Name = "bttn_addnode";
            this.bttn_addnode.Size = new System.Drawing.Size(85, 46);
            this.bttn_addnode.TabIndex = 24;
            this.bttn_addnode.Text = "Add Node";
            this.bttn_addnode.UseVisualStyleBackColor = true;
            this.bttn_addnode.Click += new System.EventHandler(this.bttn_addnode_Click);
            // 
            // bttn_postordertraversal
            // 
            this.bttn_postordertraversal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_postordertraversal.Location = new System.Drawing.Point(500, 12);
            this.bttn_postordertraversal.Name = "bttn_postordertraversal";
            this.bttn_postordertraversal.Size = new System.Drawing.Size(97, 46);
            this.bttn_postordertraversal.TabIndex = 25;
            this.bttn_postordertraversal.Text = "Post Order Traversal";
            this.bttn_postordertraversal.UseVisualStyleBackColor = true;
            this.bttn_postordertraversal.Click += new System.EventHandler(this.bttn_postordertraversal_Click);
            // 
            // bttn_inordertraversal
            // 
            this.bttn_inordertraversal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_inordertraversal.Location = new System.Drawing.Point(397, 12);
            this.bttn_inordertraversal.Name = "bttn_inordertraversal";
            this.bttn_inordertraversal.Size = new System.Drawing.Size(97, 46);
            this.bttn_inordertraversal.TabIndex = 26;
            this.bttn_inordertraversal.Text = "In Order Traversal";
            this.bttn_inordertraversal.UseVisualStyleBackColor = true;
            this.bttn_inordertraversal.Click += new System.EventHandler(this.bttn_inordertraversal_Click);
            // 
            // Tree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 560);
            this.Controls.Add(this.bttn_inordertraversal);
            this.Controls.Add(this.bttn_postordertraversal);
            this.Controls.Add(this.bttn_addnode);
            this.Controls.Add(this.bttn_preorder);
            this.Controls.Add(this.bttnclearnodes);
            this.Controls.Add(this.bttn_exit);
            this.Controls.Add(this.lb_output);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Tree";
            this.Text = "Tree";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_output;
        private System.Windows.Forms.Button bttnclearnodes;
        private System.Windows.Forms.Button bttn_exit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bttn_preorder;
        private System.Windows.Forms.Button bttn_addnode;
        private System.Windows.Forms.Button bttn_postordertraversal;
        private System.Windows.Forms.Button bttn_inordertraversal;
    }
}