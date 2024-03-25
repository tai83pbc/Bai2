namespace Bai2
{
    partial class Form1
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
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.add_Node = new System.Windows.Forms.ToolStripMenuItem();
            this.edit_Node = new System.Windows.Forms.ToolStripMenuItem();
            this.delete_Node = new System.Windows.Forms.ToolStripMenuItem();
            this.find_Node = new System.Windows.Forms.ToolStripMenuItem();
            this.save_Node = new System.Windows.Forms.ToolStripMenuItem();
            this.TV_xml = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(12, 13);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(474, 22);
            this.txt_Path.TabIndex = 0;
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(516, 10);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(84, 25);
            this.btn_Open.TabIndex = 1;
            this.btn_Open.Text = "Mở";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add_Node,
            this.edit_Node,
            this.delete_Node,
            this.find_Node,
            this.save_Node});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 124);
            // 
            // add_Node
            // 
            this.add_Node.Name = "add_Node";
            this.add_Node.Size = new System.Drawing.Size(156, 24);
            this.add_Node.Text = "Thêm Node";
            this.add_Node.Click += new System.EventHandler(this.add_Node_Click);
            // 
            // edit_Node
            // 
            this.edit_Node.Name = "edit_Node";
            this.edit_Node.Size = new System.Drawing.Size(156, 24);
            this.edit_Node.Text = "Sửa Node";
            this.edit_Node.Click += new System.EventHandler(this.edit_Node_Click);
            // 
            // delete_Node
            // 
            this.delete_Node.Name = "delete_Node";
            this.delete_Node.Size = new System.Drawing.Size(156, 24);
            this.delete_Node.Text = "Xoá Node";
            this.delete_Node.Click += new System.EventHandler(this.delete_Node_Click);
            // 
            // find_Node
            // 
            this.find_Node.Name = "find_Node";
            this.find_Node.Size = new System.Drawing.Size(156, 24);
            this.find_Node.Text = "Tìm Node";
            this.find_Node.Click += new System.EventHandler(this.find_Node_Click);
            // 
            // save_Node
            // 
            this.save_Node.Name = "save_Node";
            this.save_Node.Size = new System.Drawing.Size(156, 24);
            this.save_Node.Text = "Lưu";
            this.save_Node.Click += new System.EventHandler(this.save_Node_Click);
            // 
            // TV_xml
            // 
            this.TV_xml.Location = new System.Drawing.Point(12, 42);
            this.TV_xml.Name = "TV_xml";
            this.TV_xml.Size = new System.Drawing.Size(588, 374);
            this.TV_xml.TabIndex = 3;
            this.TV_xml.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TV_xml_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 439);
            this.Controls.Add(this.TV_xml);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.txt_Path);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem add_Node;
        private System.Windows.Forms.ToolStripMenuItem edit_Node;
        private System.Windows.Forms.ToolStripMenuItem delete_Node;
        private System.Windows.Forms.ToolStripMenuItem find_Node;
        private System.Windows.Forms.ToolStripMenuItem save_Node;
        private System.Windows.Forms.TreeView TV_xml;
    }
}

