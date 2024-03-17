namespace NEA_graph_and_tree_builder
{
    partial class frm_menu
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
            this.lbl_title = new System.Windows.Forms.Label();
            this.bttn_graph = new System.Windows.Forms.Button();
            this.bttn_tree = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(67, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(543, 55);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Graph and Tree builder";
            // 
            // bttn_graph
            // 
            this.bttn_graph.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_graph.Location = new System.Drawing.Point(5, 105);
            this.bttn_graph.Name = "bttn_graph";
            this.bttn_graph.Size = new System.Drawing.Size(334, 265);
            this.bttn_graph.TabIndex = 2;
            this.bttn_graph.Text = "Create a Graph";
            this.bttn_graph.UseVisualStyleBackColor = true;
            this.bttn_graph.Click += new System.EventHandler(this.bttn_graph_Click);
            // 
            // bttn_tree
            // 
            this.bttn_tree.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_tree.Location = new System.Drawing.Point(345, 105);
            this.bttn_tree.Name = "bttn_tree";
            this.bttn_tree.Size = new System.Drawing.Size(334, 265);
            this.bttn_tree.TabIndex = 3;
            this.bttn_tree.Text = "Create a Tree";
            this.bttn_tree.UseVisualStyleBackColor = true;
            this.bttn_tree.Click += new System.EventHandler(this.bttn_tree_Click);
            // 
            // frm_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 370);
            this.Controls.Add(this.bttn_tree);
            this.Controls.Add(this.bttn_graph);
            this.Controls.Add(this.lbl_title);
            this.Name = "frm_menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button bttn_graph;
        private System.Windows.Forms.Button bttn_tree;
    }
}

