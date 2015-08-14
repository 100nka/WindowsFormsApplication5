namespace WindowsFormsApplication5
{
    partial class FISGenerator
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
            this.load_xml = new System.Windows.Forms.Button();
            this.loadcustomXls = new System.Windows.Forms.Button();
            this.tbxmlname = new System.Windows.Forms.TextBox();
            this.tbxlsmname = new System.Windows.Forms.TextBox();
            this.tbxlsgenmname = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btstargen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bSavePath = new System.Windows.Forms.Button();
            this.tbSavePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btLoadDesignCt = new System.Windows.Forms.Button();
            this.tbcriteriasheetname = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridView_AssetsList = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridView_AllFaults = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lrowslicz = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewMAF = new System.Windows.Forms.DataGridView();
            this.lbgroupnames = new System.Windows.Forms.ListBox();
            this.lbAssetslist = new System.Windows.Forms.ListBox();
            this.cMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.machineFaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualIntFaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveDataToXLSMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataToL5XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmStripGroupnames = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmstripassetsname = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lcontrolerName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AssetsList)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AllFaults)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMAF)).BeginInit();
            this.cMenuStrip.SuspendLayout();
            this.cmStripGroupnames.SuspendLayout();
            this.cmstripassetsname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // load_xml
            // 
            this.load_xml.Location = new System.Drawing.Point(21, 35);
            this.load_xml.Name = "load_xml";
            this.load_xml.Size = new System.Drawing.Size(109, 23);
            this.load_xml.TabIndex = 0;
            this.load_xml.Text = "L5X xml";
            this.load_xml.UseVisualStyleBackColor = true;
            this.load_xml.Click += new System.EventHandler(this.load_xml_Click);
            // 
            // loadcustomXls
            // 
            this.loadcustomXls.Location = new System.Drawing.Point(22, 74);
            this.loadcustomXls.Name = "loadcustomXls";
            this.loadcustomXls.Size = new System.Drawing.Size(109, 23);
            this.loadcustomXls.TabIndex = 1;
            this.loadcustomXls.Text = "Custom xlsm";
            this.loadcustomXls.UseVisualStyleBackColor = true;
            this.loadcustomXls.Click += new System.EventHandler(this.loadcutomXls_Click);
            // 
            // tbxmlname
            // 
            this.tbxmlname.Cursor = System.Windows.Forms.Cursors.No;
            this.tbxmlname.Location = new System.Drawing.Point(140, 38);
            this.tbxmlname.Name = "tbxmlname";
            this.tbxmlname.ReadOnly = true;
            this.tbxmlname.Size = new System.Drawing.Size(512, 20);
            this.tbxmlname.TabIndex = 2;
            this.tbxmlname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxlsmname
            // 
            this.tbxlsmname.Cursor = System.Windows.Forms.Cursors.No;
            this.tbxlsmname.Location = new System.Drawing.Point(140, 75);
            this.tbxlsmname.Name = "tbxlsmname";
            this.tbxlsmname.ReadOnly = true;
            this.tbxlsmname.Size = new System.Drawing.Size(512, 20);
            this.tbxlsmname.TabIndex = 4;
            this.tbxlsmname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxlsgenmname
            // 
            this.tbxlsgenmname.Cursor = System.Windows.Forms.Cursors.No;
            this.tbxlsgenmname.Location = new System.Drawing.Point(139, 117);
            this.tbxlsgenmname.Name = "tbxlsgenmname";
            this.tbxlsgenmname.ReadOnly = true;
            this.tbxlsgenmname.Size = new System.Drawing.Size(513, 20);
            this.tbxlsgenmname.TabIndex = 6;
            this.tbxlsgenmname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "General xlsm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.loadGeneralXls_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lcontrolerName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 21);
            this.panel1.TabIndex = 12;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(986, 656);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btstargen);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.load_xml);
            this.tabPage1.Controls.Add(this.loadcustomXls);
            this.tabPage1.Controls.Add(this.tbxmlname);
            this.tabPage1.Controls.Add(this.tbxlsmname);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.tbxlsgenmname);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(978, 630);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sources";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btstargen
            // 
            this.btstargen.Location = new System.Drawing.Point(692, 21);
            this.btstargen.Name = "btstargen";
            this.btstargen.Size = new System.Drawing.Size(266, 178);
            this.btstargen.TabIndex = 14;
            this.btstargen.Text = "Generate list";
            this.btstargen.UseVisualStyleBackColor = true;
            this.btstargen.Click += new System.EventHandler(this.bt_startGen);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(324, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Save";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.bSavePath);
            this.panel3.Controls.Add(this.tbSavePath);
            this.panel3.Location = new System.Drawing.Point(12, 233);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(666, 159);
            this.panel3.TabIndex = 12;
            // 
            // bSavePath
            // 
            this.bSavePath.Location = new System.Drawing.Point(8, 25);
            this.bSavePath.Name = "bSavePath";
            this.bSavePath.Size = new System.Drawing.Size(109, 23);
            this.bSavePath.TabIndex = 8;
            this.bSavePath.Text = "Save path";
            this.bSavePath.UseVisualStyleBackColor = true;
            this.bSavePath.Click += new System.EventHandler(this.bSavePath_Click);
            // 
            // tbSavePath
            // 
            this.tbSavePath.Cursor = System.Windows.Forms.Cursors.No;
            this.tbSavePath.Location = new System.Drawing.Point(125, 25);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.ReadOnly = true;
            this.tbSavePath.Size = new System.Drawing.Size(513, 20);
            this.tbSavePath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(324, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Load ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btLoadDesignCt);
            this.panel2.Controls.Add(this.tbcriteriasheetname);
            this.panel2.Location = new System.Drawing.Point(12, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(666, 178);
            this.panel2.TabIndex = 10;
            // 
            // btLoadDesignCt
            // 
            this.btLoadDesignCt.Location = new System.Drawing.Point(8, 131);
            this.btLoadDesignCt.Name = "btLoadDesignCt";
            this.btLoadDesignCt.Size = new System.Drawing.Size(109, 23);
            this.btLoadDesignCt.TabIndex = 13;
            this.btLoadDesignCt.Text = "Design Crit xlsm";
            this.btLoadDesignCt.UseVisualStyleBackColor = true;
            this.btLoadDesignCt.Click += new System.EventHandler(this.loadFisDesignSheetXls_Click);
            // 
            // tbcriteriasheetname
            // 
            this.tbcriteriasheetname.Cursor = System.Windows.Forms.Cursors.No;
            this.tbcriteriasheetname.Location = new System.Drawing.Point(126, 133);
            this.tbcriteriasheetname.Name = "tbcriteriasheetname";
            this.tbcriteriasheetname.ReadOnly = true;
            this.tbcriteriasheetname.Size = new System.Drawing.Size(513, 20);
            this.tbcriteriasheetname.TabIndex = 14;
            this.tbcriteriasheetname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridView_AssetsList);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(978, 630);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Assets List";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView_AssetsList
            // 
            this.dataGridView_AssetsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_AssetsList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_AssetsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_AssetsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_AssetsList.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_AssetsList.Name = "dataGridView_AssetsList";
            this.dataGridView_AssetsList.Size = new System.Drawing.Size(972, 624);
            this.dataGridView_AssetsList.TabIndex = 10;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dataGridView_AllFaults);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(978, 630);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "All faults list";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridView_AllFaults
            // 
            this.dataGridView_AllFaults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView_AllFaults.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_AllFaults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_AllFaults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_AllFaults.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_AllFaults.Name = "dataGridView_AllFaults";
            this.dataGridView_AllFaults.Size = new System.Drawing.Size(972, 624);
            this.dataGridView_AllFaults.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(978, 630);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Assets log Build";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lrowslicz
            // 
            this.lrowslicz.AutoSize = true;
            this.lrowslicz.Location = new System.Drawing.Point(417, 6);
            this.lrowslicz.Name = "lrowslicz";
            this.lrowslicz.Size = new System.Drawing.Size(10, 13);
            this.lrowslicz.TabIndex = 20;
            this.lrowslicz.Text = "-";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pictureBox2);
            this.panel7.Controls.Add(this.lrowslicz);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Location = new System.Drawing.Point(431, 597);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(527, 26);
            this.panel7.TabIndex = 19;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(239, 597);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(187, 26);
            this.panel6.TabIndex = 18;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(8, 597);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(225, 26);
            this.panel5.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridViewMAF);
            this.panel4.Controls.Add(this.lbgroupnames);
            this.panel4.Controls.Add(this.lbAssetslist);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(972, 593);
            this.panel4.TabIndex = 15;
            // 
            // dataGridViewMAF
            // 
            this.dataGridViewMAF.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewMAF.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewMAF.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewMAF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMAF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewMAF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMAF.Location = new System.Drawing.Point(428, 0);
            this.dataGridViewMAF.Name = "dataGridViewMAF";
            this.dataGridViewMAF.Size = new System.Drawing.Size(544, 593);
            this.dataGridViewMAF.TabIndex = 3;
            // 
            // lbgroupnames
            // 
            this.lbgroupnames.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbgroupnames.FormattingEnabled = true;
            this.lbgroupnames.Location = new System.Drawing.Point(235, 0);
            this.lbgroupnames.Name = "lbgroupnames";
            this.lbgroupnames.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbgroupnames.Size = new System.Drawing.Size(193, 593);
            this.lbgroupnames.Sorted = true;
            this.lbgroupnames.TabIndex = 1;
            this.lbgroupnames.SelectedIndexChanged += new System.EventHandler(this.lbgroupnames_SelectedIndexChanged);
            // 
            // lbAssetslist
            // 
            this.lbAssetslist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAssetslist.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbAssetslist.Location = new System.Drawing.Point(0, 0);
            this.lbAssetslist.Name = "lbAssetslist";
            this.lbAssetslist.Size = new System.Drawing.Size(235, 593);
            this.lbAssetslist.TabIndex = 2;
            this.lbAssetslist.SelectedIndexChanged += new System.EventHandler(this.lbAssetslist_SelectedIndexChanged);
            // 
            // cMenuStrip
            // 
            this.cMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.toolStripMenuItem6,
            this.toolStripSeparator2,
            this.saveDataToXLSMToolStripMenuItem,
            this.saveDataToL5XToolStripMenuItem,
            this.toolStripSeparator3,
            this.deleteToolStripMenuItem,
            this.deleteRowsToolStripMenuItem});
            this.cMenuStrip.Name = "cMenuStrip";
            this.cMenuStrip.Size = new System.Drawing.Size(172, 176);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.machineFaultToolStripMenuItem,
            this.manualIntFaultToolStripMenuItem});
            this.toolStripMenuItem1.Image = global::WindowsFormsApplication5.Properties.Resources.edit_enable;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem1.Text = "Mark Selected";
            // 
            // machineFaultToolStripMenuItem
            // 
            this.machineFaultToolStripMenuItem.Image = global::WindowsFormsApplication5.Properties.Resources.pic_machinefault;
            this.machineFaultToolStripMenuItem.Name = "machineFaultToolStripMenuItem";
            this.machineFaultToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.machineFaultToolStripMenuItem.Text = "Machine Fault";
            this.machineFaultToolStripMenuItem.Click += new System.EventHandler(this.machineFaultToolStripMenuItem_Click);
            // 
            // manualIntFaultToolStripMenuItem
            // 
            this.manualIntFaultToolStripMenuItem.Image = global::WindowsFormsApplication5.Properties.Resources.pic_manualfault;
            this.manualIntFaultToolStripMenuItem.Name = "manualIntFaultToolStripMenuItem";
            this.manualIntFaultToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.manualIntFaultToolStripMenuItem.Text = "Manual Int Fault";
            this.manualIntFaultToolStripMenuItem.Click += new System.EventHandler(this.manualIntFaultToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::WindowsFormsApplication5.Properties.Resources.edit_enable_deselectted;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteToolStripMenuItem.Text = "Deselect";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Image = global::WindowsFormsApplication5.Properties.Resources.editenableselected;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem6.Text = "Return Default";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(168, 6);
            // 
            // saveDataToXLSMToolStripMenuItem
            // 
            this.saveDataToXLSMToolStripMenuItem.Image = global::WindowsFormsApplication5.Properties.Resources.excelSave;
            this.saveDataToXLSMToolStripMenuItem.Name = "saveDataToXLSMToolStripMenuItem";
            this.saveDataToXLSMToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.saveDataToXLSMToolStripMenuItem.Text = "Save data to XLSM";
            this.saveDataToXLSMToolStripMenuItem.Click += new System.EventHandler(this.saveDataToXLSMToolStripMenuItem_Click);
            // 
            // saveDataToL5XToolStripMenuItem
            // 
            this.saveDataToL5XToolStripMenuItem.Image = global::WindowsFormsApplication5.Properties.Resources.pic_routine;
            this.saveDataToL5XToolStripMenuItem.Name = "saveDataToL5XToolStripMenuItem";
            this.saveDataToL5XToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.saveDataToL5XToolStripMenuItem.Text = "Save data  to L5X";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(168, 6);
            // 
            // deleteRowsToolStripMenuItem
            // 
            this.deleteRowsToolStripMenuItem.Image = global::WindowsFormsApplication5.Properties.Resources.unselect_all;
            this.deleteRowsToolStripMenuItem.Name = "deleteRowsToolStripMenuItem";
            this.deleteRowsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteRowsToolStripMenuItem.Text = "Delete Rows";
            this.deleteRowsToolStripMenuItem.Click += new System.EventHandler(this.deleteRowsToolStripMenuItem_Click);
            // 
            // cmStripGroupnames
            // 
            this.cmStripGroupnames.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2,
            this.editToolStripMenuItem,
            this.toolStripSeparator5,
            this.unselectAllToolStripMenuItem});
            this.cmStripGroupnames.Name = "cmStripGroupnames";
            this.cmStripGroupnames.Size = new System.Drawing.Size(161, 79);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.ReadOnly = true;
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox2.Text = "Devices list";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem,
            this.disableToolStripMenuItem});
            this.editToolStripMenuItem.Image = global::WindowsFormsApplication5.Properties.Resources.edit_enable;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Image = global::WindowsFormsApplication5.Properties.Resources.editenableselected;
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.enableToolStripMenuItem.Text = "Enable";
            this.enableToolStripMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Image = global::WindowsFormsApplication5.Properties.Resources.edit_enable_deselectted;
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.disableToolStripMenuItem.Text = "Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(157, 6);
            // 
            // unselectAllToolStripMenuItem
            // 
            this.unselectAllToolStripMenuItem.Image = global::WindowsFormsApplication5.Properties.Resources.unselect_all;
            this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            this.unselectAllToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.unselectAllToolStripMenuItem.Text = "Unselect All";
            this.unselectAllToolStripMenuItem.Click += new System.EventHandler(this.unselectAllToolStripMenuItem_Click);
            // 
            // cmstripassetsname
            // 
            this.cmstripassetsname.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripMenuItem2,
            this.toolStripSeparator4,
            this.toolStripMenuItem5});
            this.cmstripassetsname.Name = "cmStripGroupnames";
            this.cmstripassetsname.Size = new System.Drawing.Size(161, 79);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "Assets list";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.toolStripMenuItem2.Image = global::WindowsFormsApplication5.Properties.Resources.edit_enable;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem2.Text = "Edit";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::WindowsFormsApplication5.Properties.Resources.editenableselected;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItem3.Text = "Enable";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::WindowsFormsApplication5.Properties.Resources.edit_enable_deselectted;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItem4.Text = "Disable";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::WindowsFormsApplication5.Properties.Resources.unselect_all;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem5.Text = "Unselect All";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication5.Properties.Resources.pic_machinefault;
            this.pictureBox1.Location = new System.Drawing.Point(24, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 16);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(70, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Machine Fault";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(210, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Manual Int Fault";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApplication5.Properties.Resources.pic_manualfault;
            this.pictureBox2.Location = new System.Drawing.Point(163, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 16);
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // lcontrolerName
            // 
            this.lcontrolerName.AutoSize = true;
            this.lcontrolerName.Location = new System.Drawing.Point(910, 5);
            this.lcontrolerName.Name = "lcontrolerName";
            this.lcontrolerName.Size = new System.Drawing.Size(10, 13);
            this.lcontrolerName.TabIndex = 22;
            this.lcontrolerName.Text = "-";
            // 
            // FISGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 677);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FISGenerator";
            this.Text = "FIS Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AssetsList)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AllFaults)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMAF)).EndInit();
            this.cMenuStrip.ResumeLayout(false);
            this.cmStripGroupnames.ResumeLayout(false);
            this.cmStripGroupnames.PerformLayout();
            this.cmstripassetsname.ResumeLayout(false);
            this.cmstripassetsname.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button load_xml;
        private System.Windows.Forms.Button loadcustomXls;
        private System.Windows.Forms.TextBox tbxmlname;
        private System.Windows.Forms.TextBox tbxlsmname;
        private System.Windows.Forms.TextBox tbxlsgenmname;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lbgroupnames;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridView_AllFaults;
        private System.Windows.Forms.Button bSavePath;
        private System.Windows.Forms.TextBox tbSavePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btLoadDesignCt;
        private System.Windows.Forms.TextBox tbcriteriasheetname;
        private System.Windows.Forms.DataGridView dataGridView_AssetsList;
        private System.Windows.Forms.ListBox lbAssetslist;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridViewMAF;
        private System.Windows.Forms.Button btstargen;
        private System.Windows.Forms.ContextMenuStrip cMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem machineFaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualIntFaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveDataToXLSMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataToL5XToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem deleteRowsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmStripGroupnames;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unselectAllToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmstripassetsname;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lrowslicz;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lcontrolerName;
    }
}

