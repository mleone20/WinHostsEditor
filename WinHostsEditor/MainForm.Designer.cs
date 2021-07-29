
namespace WinHostsEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.contextListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApplica = new System.Windows.Forms.Button();
            this.contextListMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainList
            // 
            this.MainList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.MainList.ContextMenuStrip = this.contextListMenu;
            this.MainList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainList.FullRowSelect = true;
            this.MainList.GridLines = true;
            this.MainList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MainList.HideSelection = false;
            this.MainList.Location = new System.Drawing.Point(0, 0);
            this.MainList.Name = "MainList";
            this.MainList.Size = new System.Drawing.Size(834, 369);
            this.MainList.TabIndex = 0;
            this.MainList.UseCompatibleStateImageBehavior = false;
            this.MainList.View = System.Windows.Forms.View.Details;
            this.MainList.DoubleClick += new System.EventHandler(this.MainList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Abilitato";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Host";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ip";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Commento";
            this.columnHeader4.Width = 400;
            // 
            // contextListMenu
            // 
            this.contextListMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdd,
            this.tsmRemove,
            this.tsmEdit});
            this.contextListMenu.Name = "contextMenuStrip1";
            this.contextListMenu.Size = new System.Drawing.Size(205, 76);
            this.contextListMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextListMenu_Opening);
            this.contextListMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextListMenu_ItemClicked);
            // 
            // tsmAdd
            // 
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(204, 24);
            this.tsmAdd.Text = "Aggiungi nuovo";
            // 
            // tsmRemove
            // 
            this.tsmRemove.Name = "tsmRemove";
            this.tsmRemove.Size = new System.Drawing.Size(204, 24);
            this.tsmRemove.Text = "Rimuovi elemento";
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(204, 24);
            this.tsmEdit.Text = "Modifica elemento";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnApplica);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 369);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 66);
            this.panel1.TabIndex = 1;
            // 
            // btnApplica
            // 
            this.btnApplica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplica.Location = new System.Drawing.Point(659, 18);
            this.btnApplica.Name = "btnApplica";
            this.btnApplica.Size = new System.Drawing.Size(163, 36);
            this.btnApplica.TabIndex = 0;
            this.btnApplica.Text = "Applica";
            this.btnApplica.UseVisualStyleBackColor = true;
            this.btnApplica.Click += new System.EventHandler(this.btnApplica_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 435);
            this.Controls.Add(this.MainList);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Gestore file di host di Window";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextListMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView MainList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnApplica;
        private System.Windows.Forms.ContextMenuStrip contextListMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmRemove;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}

