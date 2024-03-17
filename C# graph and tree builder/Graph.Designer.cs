namespace NEA_graph_and_tree_builder
{
    partial class frm_graph
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
            this.rbAddNode = new System.Windows.Forms.RadioButton();
            this.rbAddundirected = new System.Windows.Forms.RadioButton();
            this.rbAddDirected = new System.Windows.Forms.RadioButton();
            this.bttn_exit = new System.Windows.Forms.Button();
            this.bttnclearnodes = new System.Windows.Forms.Button();
            this.rbdeletenode = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bttn_bfs = new System.Windows.Forms.Button();
            this.bttn_dfs = new System.Windows.Forms.Button();
            this.rb_dijkstras = new System.Windows.Forms.RadioButton();
            this.lb_stack = new System.Windows.Forms.ListBox();
            this.lb_output = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // rbAddNode
            // 
            this.rbAddNode.AutoSize = true;
            this.rbAddNode.Location = new System.Drawing.Point(12, 54);
            this.rbAddNode.Name = "rbAddNode";
            this.rbAddNode.Size = new System.Drawing.Size(73, 17);
            this.rbAddNode.TabIndex = 2;
            this.rbAddNode.TabStop = true;
            this.rbAddNode.Text = "Add Node";
            this.rbAddNode.UseVisualStyleBackColor = true;
            // 
            // rbAddundirected
            // 
            this.rbAddundirected.AutoSize = true;
            this.rbAddundirected.Location = new System.Drawing.Point(12, 77);
            this.rbAddundirected.Name = "rbAddundirected";
            this.rbAddundirected.Size = new System.Drawing.Size(126, 17);
            this.rbAddundirected.TabIndex = 3;
            this.rbAddundirected.TabStop = true;
            this.rbAddundirected.Text = "Add Undirected edge";
            this.rbAddundirected.UseVisualStyleBackColor = true;
            // 
            // rbAddDirected
            // 
            this.rbAddDirected.AutoSize = true;
            this.rbAddDirected.Location = new System.Drawing.Point(12, 100);
            this.rbAddDirected.Name = "rbAddDirected";
            this.rbAddDirected.Size = new System.Drawing.Size(112, 17);
            this.rbAddDirected.TabIndex = 4;
            this.rbAddDirected.TabStop = true;
            this.rbAddDirected.Text = "Add directed edge";
            this.rbAddDirected.UseVisualStyleBackColor = true;
            // 
            // bttn_exit
            // 
            this.bttn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_exit.Location = new System.Drawing.Point(12, 2);
            this.bttn_exit.Name = "bttn_exit";
            this.bttn_exit.Size = new System.Drawing.Size(73, 46);
            this.bttn_exit.TabIndex = 5;
            this.bttn_exit.Text = "Exit";
            this.bttn_exit.UseVisualStyleBackColor = true;
            this.bttn_exit.Click += new System.EventHandler(this.bttn_exit_Click);
            // 
            // bttnclearnodes
            // 
            this.bttnclearnodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnclearnodes.Location = new System.Drawing.Point(91, 2);
            this.bttnclearnodes.Name = "bttnclearnodes";
            this.bttnclearnodes.Size = new System.Drawing.Size(106, 46);
            this.bttnclearnodes.TabIndex = 6;
            this.bttnclearnodes.Text = "Clear nodes and edges";
            this.bttnclearnodes.UseVisualStyleBackColor = true;
            this.bttnclearnodes.Click += new System.EventHandler(this.bttnclearnodes_Click);
            // 
            // rbdeletenode
            // 
            this.rbdeletenode.AutoSize = true;
            this.rbdeletenode.Location = new System.Drawing.Point(12, 123);
            this.rbdeletenode.Name = "rbdeletenode";
            this.rbdeletenode.Size = new System.Drawing.Size(83, 17);
            this.rbdeletenode.TabIndex = 7;
            this.rbdeletenode.TabStop = true;
            this.rbdeletenode.Text = "Delete node";
            this.rbdeletenode.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bttn_bfs
            // 
            this.bttn_bfs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_bfs.Location = new System.Drawing.Point(203, 2);
            this.bttn_bfs.Name = "bttn_bfs";
            this.bttn_bfs.Size = new System.Drawing.Size(99, 46);
            this.bttn_bfs.TabIndex = 11;
            this.bttn_bfs.Text = "Breadth First search";
            this.bttn_bfs.UseVisualStyleBackColor = true;
            this.bttn_bfs.Click += new System.EventHandler(this.bttn_bfs_Click_1);
            // 
            // bttn_dfs
            // 
            this.bttn_dfs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_dfs.Location = new System.Drawing.Point(307, 2);
            this.bttn_dfs.Margin = new System.Windows.Forms.Padding(2);
            this.bttn_dfs.Name = "bttn_dfs";
            this.bttn_dfs.Size = new System.Drawing.Size(89, 46);
            this.bttn_dfs.TabIndex = 12;
            this.bttn_dfs.Text = "Depth First Search";
            this.bttn_dfs.UseVisualStyleBackColor = true;
            this.bttn_dfs.Click += new System.EventHandler(this.bttn_dfs_Click);
            // 
            // rb_dijkstras
            // 
            this.rb_dijkstras.AutoSize = true;
            this.rb_dijkstras.Location = new System.Drawing.Point(12, 145);
            this.rb_dijkstras.Margin = new System.Windows.Forms.Padding(2);
            this.rb_dijkstras.Name = "rb_dijkstras";
            this.rb_dijkstras.Size = new System.Drawing.Size(185, 17);
            this.rb_dijkstras.TabIndex = 13;
            this.rb_dijkstras.TabStop = true;
            this.rb_dijkstras.Text = "Find shortest path between nodes";
            this.rb_dijkstras.UseVisualStyleBackColor = true;
            // 
            // lb_stack
            // 
            this.lb_stack.FormattingEnabled = true;
            this.lb_stack.Location = new System.Drawing.Point(4, 167);
            this.lb_stack.Name = "lb_stack";
            this.lb_stack.ScrollAlwaysVisible = true;
            this.lb_stack.Size = new System.Drawing.Size(193, 420);
            this.lb_stack.TabIndex = 15;
            // 
            // lb_output
            // 
            this.lb_output.BackColor = System.Drawing.SystemColors.Control;
            this.lb_output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_output.Dock = System.Windows.Forms.DockStyle.Right;
            this.lb_output.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_output.FormattingEnabled = true;
            this.lb_output.HorizontalScrollbar = true;
            this.lb_output.ItemHeight = 16;
            this.lb_output.Location = new System.Drawing.Point(765, 0);
            this.lb_output.Name = "lb_output";
            this.lb_output.ScrollAlwaysVisible = true;
            this.lb_output.Size = new System.Drawing.Size(665, 590);
            this.lb_output.TabIndex = 16;
            // 
            // frm_graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1430, 590);
            this.Controls.Add(this.lb_output);
            this.Controls.Add(this.lb_stack);
            this.Controls.Add(this.rb_dijkstras);
            this.Controls.Add(this.bttn_dfs);
            this.Controls.Add(this.bttn_bfs);
            this.Controls.Add(this.rbdeletenode);
            this.Controls.Add(this.bttnclearnodes);
            this.Controls.Add(this.bttn_exit);
            this.Controls.Add(this.rbAddDirected);
            this.Controls.Add(this.rbAddundirected);
            this.Controls.Add(this.rbAddNode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_graph";
            this.Text = "                                                                                 " +
    "                       ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_graph_Load);
            this.Click += new System.EventHandler(this.Graph_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbAddNode;
        private System.Windows.Forms.RadioButton rbAddundirected;
        private System.Windows.Forms.RadioButton rbAddDirected;
        private System.Windows.Forms.Button bttn_exit;
        private System.Windows.Forms.Button bttnclearnodes;
        private System.Windows.Forms.RadioButton rbdeletenode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bttn_bfs;
        private System.Windows.Forms.Button bttn_dfs;
        private System.Windows.Forms.RadioButton rb_dijkstras;
        private System.Windows.Forms.ListBox lb_stack;
        private System.Windows.Forms.ListBox lb_output;
    }
}