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
            this.button6 = new System.Windows.Forms.Button();
            this.btstargen = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bSavePath = new System.Windows.Forms.Button();
            this.tbSavePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btLoadDesignCt = new System.Windows.Forms.Button();
            this.tbcriteriasheetname = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btdelsel = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewMIF = new System.Windows.Forms.DataGridView();
            this.dataGridViewMAF = new System.Windows.Forms.DataGridView();
            this.lbgroupnames = new System.Windows.Forms.ListBox();
            this.lbAssetslist = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgalletlist = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.machineFaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualIntFaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveDataToXLSMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataToL5XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMIF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMAF)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgalletlist)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cMenuStrip.SuspendLayout();
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1302, 21);
            this.panel1.TabIndex = 12;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1302, 591);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.btstargen);
            this.tabPage1.Controls.Add(this.button4);
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
            this.tabPage1.Size = new System.Drawing.Size(1294, 565);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sources";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(701, 153);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(153, 42);
            this.button6.TabIndex = 15;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btstargen
            // 
            this.btstargen.Location = new System.Drawing.Point(701, 21);
            this.btstargen.Name = "btstargen";
            this.btstargen.Size = new System.Drawing.Size(153, 42);
            this.btstargen.TabIndex = 14;
            this.btstargen.Text = "Generate list";
            this.btstargen.UseVisualStyleBackColor = true;
            this.btstargen.Click += new System.EventHandler(this.bt_startGen);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(701, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(153, 42);
            this.button4.TabIndex = 13;
            this.button4.Text = "Save config";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btSaveas_Click);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.btdelsel);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1294, 565);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(155, 535);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2.TabIndex = 18;
            this.checkBox2.Text = "Enable Edit";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 535);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Enable Edit";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btdelsel
            // 
            this.btdelsel.Location = new System.Drawing.Point(826, 535);
            this.btdelsel.Name = "btdelsel";
            this.btdelsel.Size = new System.Drawing.Size(146, 22);
            this.btdelsel.TabIndex = 16;
            this.btdelsel.Text = "Delete selected";
            this.btdelsel.UseVisualStyleBackColor = true;
            this.btdelsel.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridViewMIF);
            this.panel4.Controls.Add(this.dataGridViewMAF);
            this.panel4.Controls.Add(this.lbgroupnames);
            this.panel4.Controls.Add(this.lbAssetslist);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1288, 526);
            this.panel4.TabIndex = 15;
            // 
            // dataGridViewMIF
            // 
            this.dataGridViewMIF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridViewMIF.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewMIF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMIF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMIF.Location = new System.Drawing.Point(823, 0);
            this.dataGridViewMIF.Name = "dataGridViewMIF";
            this.dataGridViewMIF.Size = new System.Drawing.Size(465, 526);
            this.dataGridViewMIF.TabIndex = 4;
            // 
            // dataGridViewMAF
            // 
            this.dataGridViewMAF.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewMAF.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewMAF.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewMAF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMAF.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewMAF.Location = new System.Drawing.Point(339, 0);
            this.dataGridViewMAF.Name = "dataGridViewMAF";
            this.dataGridViewMAF.Size = new System.Drawing.Size(484, 526);
            this.dataGridViewMAF.TabIndex = 3;
            // 
            // lbgroupnames
            // 
            this.lbgroupnames.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbgroupnames.FormattingEnabled = true;
            this.lbgroupnames.Location = new System.Drawing.Point(146, 0);
            this.lbgroupnames.Name = "lbgroupnames";
            this.lbgroupnames.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbgroupnames.Size = new System.Drawing.Size(193, 526);
            this.lbgroupnames.Sorted = true;
            this.lbgroupnames.TabIndex = 1;
            this.lbgroupnames.SelectedIndexChanged += new System.EventHandler(this.lbgroupnames_SelectedIndexChanged);
            // 
            // lbAssetslist
            // 
            this.lbAssetslist.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbAssetslist.Location = new System.Drawing.Point(0, 0);
            this.lbAssetslist.Name = "lbAssetslist";
            this.lbAssetslist.Size = new System.Drawing.Size(146, 526);
            this.lbAssetslist.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(342, 540);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 22);
            this.button3.TabIndex = 14;
            this.button3.Text = "Save as";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgalletlist);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1294, 565);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Assets List";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgalletlist
            // 
            this.dgalletlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgalletlist.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgalletlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgalletlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgalletlist.Location = new System.Drawing.Point(3, 3);
            this.dgalletlist.Name = "dgalletlist";
            this.dgalletlist.Size = new System.Drawing.Size(1288, 559);
            this.dgalletlist.TabIndex = 10;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dataGridView1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1294, 565);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "All faults list";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1288, 559);
            this.dataGridView1.TabIndex = 8;
            // 
            // cMenuStrip
            // 
            this.cMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveDataToXLSMToolStripMenuItem,
            this.saveDataToL5XToolStripMenuItem,
            this.toolStripSeparator3,
            this.deleteRowsToolStripMenuItem});
            this.cMenuStrip.Name = "cMenuStrip";
            this.cMenuStrip.Size = new System.Drawing.Size(172, 132);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.machineFaultToolStripMenuItem,
            this.manualIntFaultToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem1.Text = "Select ";
            // 
            // machineFaultToolStripMenuItem
            // 
            this.machineFaultToolStripMenuItem.Image = global::WindowsFormsApplication5.Properties.Resources.pic_machinefault;
            this.machineFaultToolStripMenuItem.Name = "machineFaultToolStripMenuItem";
            this.machineFaultToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.machineFaultToolStripMenuItem.Text = "Machine Fault";
            // 
            // manualIntFaultToolStripMenuItem
            // 
            this.manualIntFaultToolStripMenuItem.Image = global::WindowsFormsApplication5.Properties.Resources.pic_manualfault;
            this.manualIntFaultToolStripMenuItem.Name = "manualIntFaultToolStripMenuItem";
            this.manualIntFaultToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.manualIntFaultToolStripMenuItem.Text = "Manual Int Fault";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteToolStripMenuItem.Text = "Deselect";
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
            this.deleteRowsToolStripMenuItem.Name = "deleteRowsToolStripMenuItem";
            this.deleteRowsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteRowsToolStripMenuItem.Text = "Delete Rows";
            // 
            // FISGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 612);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FISGenerator";
            this.Text = "FIS Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMIF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMAF)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgalletlist)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bSavePath;
        private System.Windows.Forms.TextBox tbSavePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btLoadDesignCt;
        private System.Windows.Forms.TextBox tbcriteriasheetname;
        private System.Windows.Forms.DataGridView dgalletlist;
        private System.Windows.Forms.ListBox lbAssetslist;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridViewMAF;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btstargen;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btdelsel;
        private System.Windows.Forms.DataGridView dataGridViewMIF;
        private System.Windows.Forms.ContextMenuStrip cMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem machineFaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualIntFaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveDataToXLSMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataToL5XToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem deleteRowsToolStripMenuItem;
    }
}

