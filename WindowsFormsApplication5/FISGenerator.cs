﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using ExcelM = Microsoft.Office.Interop.Excel;
using MetroFramework.Forms;

namespace WFA_FISGenerator
{

    public partial class FISGenerator : Form
    {
        private static ExcelM.Workbook MyBook = null;
        private static ExcelM.Application MyApp = null;
        private static ExcelM.Worksheet MySheet_MI = null;
        private static ExcelM.Worksheet MySheet_MF = null;
        private Dictionary<int, ExcelData> excelFaultList;
        private List<AssetList> excelAssetlList;

        private DataSet ds_excel_custom;
        private DataSet ds_excel_General;
        private DataSet ds_excel_DesignCSheet;
        private XDocument projektL5x;
        private string l5filename;
        private List<XElement> all_rungs_networks_CV;
        private List<XElement> all_rungs_networks_FIS;
        private List<XElement> all_datatypes;
        private List<XElement> all_tags;
        private List<excel_out_data> excel_MI;
        private List<excel_out_data> excel_MF;
        private List<excel_out_data> excel_unused;
        private List<Pf_Alarm8> external_faults;
        private List<Single_fault> all_faults;
        private List<Single_fault> filtered_faults_MIF;
        private BindingSource _sourceFilteredFaults = new BindingSource();
        public int selRowsCount_MI = 0;
        public int selRowsCount_MF = 0;
        public int selRowsCount_Unused = 0;
        private string designssheetlink = "";
        public bool l5xLoaded = false;
        public bool xLSCumstomLoaded = false;
        public bool xLSGeneralLoaded = false;
        public bool xLSDataSheetLoaded = false;
        public string tagFISName = "";
        public FISGenerator()
        {
            InitializeComponent();
            InitialMemArea();
            initialSetings();

            Genetatestatus(false);
            _loadfiltrcfg(@"FiltrMI.cfg", lbMI);
            _loadfiltrcfg(@"FiltrDel.cfg", lbRem);

        }

        private void _writefiltrcfg(string filtrname, ListBox Lbox)
        {
            List<string> wlines = new List<string>();
            foreach (var item in Lbox.Items)
            {
                wlines.Add(item.ToString());
            }

            System.IO.File.WriteAllLines(filtrname, wlines);
        }

        private void _loadfiltrcfg(string filtrname, ListBox Lbox)
        {
            string[] lines = System.IO.File.ReadAllLines(filtrname);

            foreach (string str in lines)
            {
                Lbox.Items.Add(str);
            }
        }

        private void initialSetings()
        {
            tbSavePath.Text = Properties.Settings.Default.SavePath.ToString();
            cbCreateL5Xout.Checked = Properties.Settings.Default.cbCreateL5Xout;
            cbcreateNew.Checked = Properties.Settings.Default.cbcreateNew;
            cbCreateTxTout.Checked = Properties.Settings.Default.cbCreateTxTout;
            cbupdateactualDesignSheet.Checked = Properties.Settings.Default.cbupdateactualDesignSheet;
            bts_custom.BackColor = Color.Red;
            bts_design.BackColor = Color.Red;
            bts_general.BackColor = Color.Red;
            bts_l5x.BackColor = Color.Red;




        }
        // private Regex filtr_PF_Alarm8 = new Regex(@"Pf_Alarm8\((?<FBI>.*?),(?<I1>\d+),(?<I2>\d+),(?<I3>\d+),(?<I4>\d+),(?<I5>\d+),(?<I6>\d+),(?<I7>\d+),(?<I8>\d+),(?<zVar>.*?),.*?\)", RegexOptions.Compiled);
        private Regex filtr_PF_Alarm8 = new Regex(Properties.Settings.Default.filtr_PF_Alarm8, RegexOptions.Compiled);
        # region load functions
        private void load_xml_Click(object sender, EventArgs e)
        {
            tbxmlname.Text = "";
            l5xLoaded = false;
            bts_l5x.BackColor = Color.Red;
            l5filename = string.Empty;
            var file = new OpenFileDialog();
            file.InitialDirectory = Properties.Settings.Default.L5X_file_dir.ToString();     //Environment.CurrentDirectory;
            file.Filter = "ALL|*.*|L5X|*.L5X";
            file.FilterIndex = 2;
            file.Multiselect = false;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(file.FileName))
                {
                    Genetatestatus(false);
                    l5filename = file.SafeFileName;

                    projektL5x = XDocument.Load(file.FileName);
                    if (projektL5x.Root.Name.ToString() == "RSLogix5000Content")
                    {
                        lcontrolerName.Text = projektL5x.Root.Element("Controller").Attribute("Name").Value.ToString();

                        all_rungs_networks_CV = projektL5x.Root.Element("Controller").Element("Programs").Descendants("Routine").Descendants("Text").ToList();
                        all_rungs_networks_FIS = projektL5x.Root.Element("Controller").Element("Programs").Descendants("Rung").ToList();
                        all_tags = projektL5x.Root.Element("Controller").Element("Tags").Elements("Tag").ToList();
                        tbxmlname.Text = file.SafeFileName;
                        l5xLoaded = true;
                        bts_l5x.BackColor = Color.Green;
                        Properties.Settings.Default.L5X_file_dir = DirFromlink(file.FileName.ToString());
                        Properties.Settings.Default.Save();

                        //=========all_rungs_networks_FIS
                        var temp = from dt in projektL5x.Root.Element("Controller").Element("Programs").Descendants("Rung")
                                   where dt.Parent.Parent.Attribute("Name").Value.Contains("B_S0")
                                   select dt;
                        all_rungs_networks_FIS = temp.ToList();
                    }
                    else
                    {
                        MessageBox.Show("File: " + l5filename + " incorrect, no RSlogix source file.");
                    }
                }
            }
        }
        private void loadcutomXls_Click(object sender, EventArgs e)
        {

            xLSCumstomLoaded = false;
            bts_custom.BackColor = Color.Red;
            tbxlsmname.Text = "";
            var file = new OpenFileDialog();
            file.InitialDirectory = Properties.Settings.Default.XLSM_cust_file_dir; //Environment.CurrentDirectory;
            file.Filter = "ALL|*.*|XLSM|*.XLSM";
            file.FilterIndex = 2;
            file.Multiselect = false;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(file.FileName))
                {
                    Genetatestatus(false);
                    try
                    {
                        using (FileStream fs = File.Open(file.FileName, FileMode.Open))
                        {
                            Excel.IExcelDataReader edr = Excel.ExcelReaderFactory.CreateOpenXmlReader(fs);
                            ds_excel_custom = edr.AsDataSet();

                            if (ds_excel_custom.Tables[2].TableName.Contains("A_Faults"))
                            {
                                xLSCumstomLoaded = true;
                                bts_custom.BackColor = Color.Green;
                                tbxlsmname.Text = file.SafeFileName;
                                Properties.Settings.Default.XLSM_cust_file_dir = DirFromlink(file.FileName.ToString());
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                MessageBox.Show("File: " + file.SafeFileName + " incorrect, no Customer Text file");
                            }
                            edr.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("File: " + file.SafeFileName + " incorrect, no Customer Text file \r\n" + ex.Message);
                    }
                }
            }

        }
        private void loadGeneralXls_Click(object sender, EventArgs e)
        {

            var file = new OpenFileDialog();
            file.InitialDirectory = Properties.Settings.Default.XLSM_General_dir; //Environment.CurrentDirectory;
            file.Filter = "ALL|*.*|XLSM|*.XLSM";
            file.FilterIndex = 2;
            file.Multiselect = false;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(file.FileName))
                {
                    try
                    {
                        Genetatestatus(false);
                        using (FileStream fs = File.Open(file.FileName, FileMode.Open))
                        {
                            Excel.IExcelDataReader edr = Excel.ExcelReaderFactory.CreateOpenXmlReader(fs);
                            ds_excel_General = edr.AsDataSet();
                            if (ds_excel_General.Tables[2].TableName.Contains("A_Faults"))
                            {
                                xLSGeneralLoaded = true;
                                bts_general.BackColor = Color.Green;
                                tbxlsgenmname.Text = file.SafeFileName;
                                Properties.Settings.Default.XLSM_General_dir = DirFromlink(file.FileName.ToString());
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                MessageBox.Show("File: " + file.SafeFileName + " incorrect, no Customer Text file");
                            }
                            edr.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("File: " + file.SafeFileName + " incorrect, no General Text file \r\n" + ex.Message);
                    }
                }
            }

        }
        private void loadFisDesignSheetXls_Click(object sender, EventArgs e)
        {
            xLSDataSheetLoaded = false;
            cbDontUseDesignCrit.Checked = false;
            bts_design.BackColor = Color.Red;
            var file = new OpenFileDialog();
            file.InitialDirectory = Properties.Settings.Default.XLSM_designSheet; //Environment.CurrentDirectory;
            file.Filter = "ALL|*.*|XLSM|*.XLSM";
            file.FilterIndex = 2;
            file.Multiselect = false;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(file.FileName))
                {
                    Genetatestatus(false);
                    try
                    {
                        using (FileStream fs = File.Open(file.FileName, FileMode.Open))
                        {
                            Excel.IExcelDataReader edr = Excel.ExcelReaderFactory.CreateOpenXmlReader(fs);
                            ds_excel_DesignCSheet = edr.AsDataSet();
                            if (ds_excel_DesignCSheet.Tables[1].TableName.Contains("AssetList"))
                            {
                                xLSDataSheetLoaded = true;
                                bts_design.BackColor = Color.Green;
                                tbcriteriasheetname.Text = file.SafeFileName;
                                Properties.Settings.Default.XLSM_designSheet = DirFromlink(file.FileName.ToString());
                                designssheetlink = file.FileName.ToString();
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                MessageBox.Show("File: " + file.SafeFileName + " incorrect, no Design Criteria Sheet Text file");
                            }




                            edr.Close();

                            //         ds_excel_DesignCSheet.WriteXml(fs);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("File: " + file.SafeFileName + " incorrect, no Design Criteria Sheet Text file \r\n" + ex.Message);
                    }
                }
            }

        }
        # endregion

        private void bt_startGen(object sender, EventArgs e)
        {
            if (l5xLoaded && xLSCumstomLoaded && xLSGeneralLoaded && xLSDataSheetLoaded)
            {
                //excelAssetlList.Clear();
                //all_faults.Clear();
                //all_datatypes.Clear();
                //excelFaultList.Clear();
                InitialMemArea();
                ReadDataFromFaultsExcels(ds_excel_custom, "A_Faults", 1, 4);
                ReadDataFromFaultsExcels(ds_excel_General, "A_Faults", 1, 5);
                if (cbDontUseDesignCrit.Checked == false)
                {
                    ReadDataFromDesignCSheet(ds_excel_DesignCSheet, "AssetList", 1, 3, 4, 5);
                }
                else
                {
                    excelAssetlList.Clear();
                    for (int i = 1; i < 26; i++)
                    {
                        var item = new AssetList(_createassetnr(i) + "FIS", "Asset", "0.0.0.0", _createassetnr(i) + "FIS");
                        excelAssetlList.Add(item);
                    }
                }

                CreateAllDatatypes();
                CreatingExtFaults();
                CreatingIntFaults();

                _formatingDataGridAllFaults(dataGridView_AllFaults);  // dodanie wszystkich bledow dla grida 
                dataGridView_AssetsList.DataSource = excelAssetlList;  // lista z assetami pobrana z excela .
                AddAssetsListBox();



                //========================= new table ======================================
                //foreach (var fault in all_faults)
                //{
                //    _MiFilterSet(fault);
                //}

                //dataGridViewhehe.DataSource = all_faults;

                //(cMenustriphehe.Items[0] as ToolStripMenuItem).DropDownItems.Clear();
                //foreach (var assetname in excelAssetlList)
                //{
                //    (cMenustriphehe.Items[0] as ToolStripMenuItem).DropDownItems.Add(assetname.ToString(), null, AssingToAsset_allFaults);
                //}

                //_formatingDataGridNEW(dataGridViewhehe);
                Genetatestatus(true);
            }
            else
            {
                MessageBox.Show("Necessary files for generate source are not loaded");
            }

        }

        private void _formatingDataGridNEW(DataGridView dg)
        {
            dg.Columns[0].FillWeight = 2;
            dg.Columns[1].FillWeight = 2;
            dg.Columns[2].FillWeight = 2;
            dg.Columns[3].FillWeight = 2;
            dg.Columns[4].FillWeight = 3;
            dg.Columns[5].FillWeight = 20;
            dg.Columns[6].FillWeight = 17;
            dg.Columns[7].FillWeight = 20;
            dg.Columns[0].Visible = false;
            dg.Columns[1].Visible = false;
            dg.Columns[2].Visible = false;
            dg.Columns[3].Visible = false;
            dg.Columns[4].Visible = false;
            dg.Columns[5].Visible = true;
            dg.Columns[6].Visible = true;
            dg.Columns[7].Visible = true;
            _setColorForDataGrid(dg);
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg.Refresh();
            dg.Show();
        }

        private void AssingToAsset_allFaults(object sender, EventArgs e)
        {
            string assetname = sender.ToString();


            //foreach (DataGridViewRow selrow in dataGridViewhehe.SelectedRows)
            //{
            //    selrow.Cells[7].Value = assetname;
            //}
        }

        private void AssingToAsset_FilteredList(object sender, EventArgs e)
        {
            string assetname = sender.ToString();

            foreach (DataGridViewRow selrow in dataGridViewMAF.SelectedRows)
            {
                selrow.Cells[7].Value = assetname;
            }
        }

        private string _createassetnr(int i)
        {
            if (i < 10)
            {
                return "S00" + i.ToString();
            }
            else
            {
                return "S0" + i.ToString();
            }
        }

        private void _formatingDataGridAllFaults(DataGridView dg)
        {
            dg.DataSource = all_faults;
        }


        private void AddAssetsListBox()
        {

            //AssetStruct assetsobj = new AssetStruct();

            lbAssetslist.Items.Clear();
            foreach (var assetname in excelAssetlList)
            {
                lbAssetslist.Items.Add(assetname); // przepisanie listy assetow do lisboxa 
                //        assetlistobj.Add(assetname);
            }

            if (this.lbAssetslist.ContextMenuStrip == null)
            {
                this.lbAssetslist.ContextMenuStrip = this.cmstripassetsname; // podpiecie contexmenu dla groupname
            }


            (cMenuStrip.Items[2] as ToolStripMenuItem).DropDownItems.Clear();
            foreach (var assetname in excelAssetlList)
            {
                (cMenuStrip.Items[2] as ToolStripMenuItem).DropDownItems.Add(assetname.ToString(), null, AssingToAsset_FilteredList);
            }

            //if (this.panel5.ContextMenuStrip == null)
            //{
            //    this.panel5.ContextMenuStrip = this.cmstripassetsname;     // podpiecie contexmenu dla dolnego paska
            //}
        }



        private void _AddDevicesListBoxGroupnames()
        {
            lbgroupnames.Items.Clear();
            dataGridViewMAF.Rows.Clear();
            tagFISName = "";

            Refrescounterdgridinfo();
            foreach (var tagname in excelAssetlList)
            {
                if (lbAssetslist.SelectedItem.ToString().Contains(tagname.TagName))
                {
                    tagFISName = tagname.TagName;
                }
            }
            string name = "";
            foreach (var groupname in all_faults)  // tworzenie grupy urzadzen (redukcja do jednej groupname )
            {
                if (name != groupname.GroupName.ToString())
                {
                    name = groupname.GroupName.ToString();
                    lbgroupnames.Items.Add(name);  // przepisanie tylko jednego wywolania grupy do lboxa
                    //     lbgroupnames.DrawMode
                    //       lbgroupnames.BackColor = Color.Blue;
                    //    lbgroupnames.Items.Add("bslslele", "dd");
                    //     lbgroupnames.Items.Add(new MyListBoxItem(Color.Green, "Validated data successfully"));
                }
            }
            //}
            if (this.lbgroupnames.ContextMenuStrip == null)
            {
                this.lbgroupnames.ContextMenuStrip = this.cmStripGroupnames;
            }
            //if (this.panel6.ContextMenuStrip == null)
            //{
            //    this.panel6.ContextMenuStrip = this.cmStripGroupnames;
            //}


            var aa = (AssetList)lbAssetslist.SelectedItem;
            if (aa.Selected != null)
            {
                foreach (int item in aa.Selected)
                {
                    lbgroupnames.SetSelected(item, true);
                }
            }
        }


        private void CreatingIntFaults()
        {
            var x = projektL5x.Root.Element("Controller").Element("Tags").Elements("Tag");
            var lista_struktur_av = (from t in x.Descendants("StructureMember")
                                     where t.HasAttributes && t.Attribute("Name") != null && t.Attribute("Name").Value.Contains("AV") && t.Attribute("DataType").Value != "ud_PfAlarm8_AV"
                                     select t).ToList();
            foreach (var av in lista_struktur_av)
            {
                var groupname = WyciongNazwe(av);

                if (groupname == null)
                {
                    continue;
                }
                var av_name = av.Attribute("Name").Value;

                var tags = av.Elements("DataValueMember");
                foreach (var tag in tags)
                {
                    string name = tag.Attribute("Name").Value;
                    int magicnumber = int.Parse(name.Substring(1, 4));

                    all_faults.Add(new Single_fault() { AVName = av_name, GroupName = groupname, MagicNumber = magicnumber, Name = name, FaultFISMember = 0 });
                }
            }
            Single_fault.excelFaultList = excelFaultList;
        }

        private void CreatingExtFaults()
        {
            var externals = (from dupa in all_rungs_networks_CV where dupa.Value.Contains("Pf_Alarm8") select dupa).ToList();
            foreach (var external in externals)
            {
                var m = filtr_PF_Alarm8.Match(external.Value);
                if (m.Success)
                {
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I1"].Value), Name = "A7261_ExtFlt1", FaultFISMember = 0 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I2"].Value), Name = "A7262_ExtFlt2", FaultFISMember = 0 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I3"].Value), Name = "A7263_ExtFlt3", FaultFISMember = 0 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I4"].Value), Name = "A7264_ExtFlt4", FaultFISMember = 0 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I5"].Value), Name = "A7265_ExtFlt5", FaultFISMember = 0 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I6"].Value), Name = "A7266_ExtFlt6", FaultFISMember = 0 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I7"].Value), Name = "A7267_ExtFlt7", FaultFISMember = 0 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I8"].Value), Name = "A7268_ExtFlt8", FaultFISMember = 0 });
                }
            }
        }

        private void CreateAllDatatypes()
        {
            var temp = projektL5x.Root.Element("Controller").Element("DataTypes").Elements("DataType").Descendants("Member");
            var temp2 = from dt in temp
                        where dt.Parent.Parent.Attribute("Name").Value.Contains("_AV") && dt.Attribute("Hidden").Value == "false"
                        select dt;
            foreach (var item in temp2.ToList())
            {
                System.Diagnostics.Debug.WriteLine("{0}.{1}", item.Parent.Parent.Attribute("Name").Value, item.Attribute("Name").Value);
                all_datatypes.Add(item);
            }
        }

        private string WyciongNazwe(XElement avstructure)
        {
            var parent_tag = avstructure.Parent.Parent.Parent;
            if (parent_tag.Name != "Tag") { System.Diagnostics.Debug.WriteLine("3 parent to nie tag!"); return null; }
            return parent_tag.Attribute("Name").Value;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Close the window?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {

                e.Cancel = true;
            }
            else
            {
                _writefiltrcfg(@"filtrMI.cfg", lbMI);
                _writefiltrcfg(@"FiltrDel.cfg", lbRem);
            }

        }

        private void dataGridViewMAF_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;
            var row = dgv.Rows[e.RowIndex];
            FormatRow(row);
        }
        private void FormatRow(DataGridViewRow row)
        {
            if ((int)row.Cells[4].Value > 0)
            {
                var r = new Random((int)row.Cells["duplicate"].Value);
                row.Cells[3].Style.BackColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
                row.Cells[3].ToolTipText = "same alias name";
            }
            else
            {
                row.Cells[3].Style.BackColor = Color.White;
                row.Cells[3].ToolTipText = string.Empty;
            }

            if ((int)row.Cells["diffname"].Value > 0)
            {
                row.Cells[1].Style.BackColor = Color.Orange;
                row.Cells[1].ToolTipText = "different alias names between excel and current software";
            }
            else
            {
                row.Cells[1].Style.BackColor = Color.White;
                row.Cells[1].ToolTipText = string.Empty;
            }

            if ((int)row.Cells["flags"].Value > 0)
            {
                row.Cells[0].Style.BackColor = Color.LightBlue;
                row.Cells[0].ToolTipText = "mismatch between alias name and comment 'spare'";
            }
            else
            {
                row.Cells[0].Style.BackColor = Color.White;
                row.Cells[0].ToolTipText = string.Empty;
            }
        }

        private string DirFromlink(string p)
        {
            var temp1 = p.LastIndexOf(@"\");
            var temp2 = p.Remove(temp1 + 1, (p.Length - temp1 - 1));
            return temp2;
        }

        private void ReadDataFromFaultsExcels(DataSet data, string tableName, int fault_pos, int desc_en_pos)
        {
            var dt = data.Tables[tableName];
            for (int i = 5; i < dt.Rows.Count; i++)
            {
                var item = new ExcelData(dt.Rows[i][fault_pos].ToString(), dt.Rows[i][desc_en_pos].ToString());
                if (!item.Valid) continue;
                var int_nr = int.Parse(item.fault_nr.Substring(1));
                if (excelFaultList.ContainsKey(int_nr))
                {
                    continue;
                }
                excelFaultList.Add(int_nr, item);
            }
        }
        private void ReadDataFromDesignCSheet(DataSet data, string tableName, int linecolumn, int asetnamecolumn, int ipcolumn, int tagnamecolumn)
        {
            var dt = data.Tables[tableName];
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                var item = new AssetList(dt.Rows[i][linecolumn].ToString(), dt.Rows[i][asetnamecolumn].ToString(), dt.Rows[i][ipcolumn].ToString(), dt.Rows[i][tagnamecolumn].ToString());
                if (!item.Valid) continue;
                excelAssetlList.Add(item);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dataGridViewMAF.SelectedCells)
            {
                if (oneCell.Selected)
                    dataGridViewMAF.Rows.RemoveAt(oneCell.RowIndex);
            }
        }

        private void bSavePath_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Please chose destination for save the xml file... ";
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                var savedir = (fbd.SelectedPath.ToString() + @"\");
                tbSavePath.Text = savedir;
                Properties.Settings.Default.SavePath = savedir;
                Properties.Settings.Default.Save();
            }
        }

        #region utilities
        public void InitialMemArea()
        {
            excelFaultList = new Dictionary<int, ExcelData>();
            excelAssetlList = new List<AssetList>();
            external_faults = new List<Pf_Alarm8>();
            all_faults = new List<Single_fault>();
            filtered_faults_MIF = new List<Single_fault>();
            all_datatypes = new List<XElement>();
            excel_MF = new List<excel_out_data>();
            excel_MI = new List<excel_out_data>();
            excel_unused = new List<excel_out_data>();
            lbAssetslist.Items.Clear();
            lbgroupnames.Items.Clear();
            dataGridViewMAF.Rows.Clear();
        }
        public void Genetatestatus(bool gen)
        {
            if (gen)
            {
                btstargen.BackColor = Color.Green;
                btstargen.Text = "Files loaded";
            }
            else
            {
                btstargen.BackColor = Color.Red;
                btstargen.Text = "Start";
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Find newwindow = new Find();
            newwindow.ShowDialog();
        }

        private void lbgroupnames_SelectedIndexChanged(object sender, EventArgs e)
        {
            selRowsCount_MI = 0;
            selRowsCount_MF = 0;
            selRowsCount_Unused = 0;
            Refrescounterdgridinfo();
            dataGridViewMAF.DataSource = null;
            filtered_faults_MIF = new List<Single_fault>();
            if (lbgroupnames.SelectedItem != null)
            {
                var item = lbgroupnames.SelectedItem.ToString();
                foreach (var selecteditems in lbgroupnames.SelectedItems)
                {
                    var selname = selecteditems.ToString();
                    foreach (var fault in all_faults)
                    {
                        if (fault.GroupName == selname)
                        {
                            _MiFilterSet(fault);
                            filtered_faults_MIF.Add(fault);
                        }

                    }
                }
                _searchexceptions();
                var aa = (AssetList)lbAssetslist.SelectedItem;
                List<int> selected = new List<int>();
                foreach (int index in lbgroupnames.SelectedIndices)
                {
                    selected.Add(index);
                }
                aa.Selected = selected;
                _sourceFilteredFaults.DataSource = filtered_faults_MIF;
                dataGridViewMAF.DataSource = _sourceFilteredFaults;
                DataggridMIFformating(dataGridViewMAF);
            }

        }

        private void _searchexceptions()
        {
            foreach (var fault in all_faults)
            {
                if (fault.Exception != null)
                {
                    if (lbAssetslist.SelectedItem.ToString() == fault.Exception)
                    {
                        _MiFilterSet(fault);
                        filtered_faults_MIF.Add(fault);
                    }
                }
            }
        }

        private void _MiFilterSet(Single_fault fault)
        {
            //       if     fault.FaultTextEn     
            if (fault.FaultTextEn != null)
            {
                foreach (var item in lbMI.Items)
                {
                    // if (fault.FaultTextEn.Contains(item.ToString()))
                    if (Regex.IsMatch(fault.FaultTextEn, item.ToString(), RegexOptions.IgnoreCase))
                    {
                        fault.FaultFISMember = 2;
                        break;
                    }
                    else
                    {
                        fault.FaultFISMember = 1;
                    }
                }
                foreach (var item in lbRem.Items)
                {
                    //  if (fault.FaultTextEn.Contains(item.ToString()))
                    if (Regex.IsMatch(fault.FaultTextEn, item.ToString(), RegexOptions.IgnoreCase))
                    {
                        fault.FaultFISMember = 3;
                        break;
                    }
                }
            }
            else
            {
                if (cboxAddFaultswithSpareDesc.Checked == true)
                {
                    fault.FaultFISMember = 1;
                }
                else
                {
                    fault.FaultFISMember = 3;
                }
            }

        }


        private void DataggridMIFformating(DataGridView dg)
        {
            dg.Columns[0].FillWeight = 1;
            dg.Columns[1].FillWeight = 1;
            dg.Columns[2].FillWeight = 1;
            dg.Columns[3].FillWeight = 1;
            dg.Columns[4].FillWeight = 1;
            dg.Columns[5].FillWeight = 10;
            dg.Columns[6].FillWeight = 50;
            dg.Columns[6].FillWeight = 15;
            dg.Columns[0].Visible = false;
            dg.Columns[1].Visible = false;
            dg.Columns[2].Visible = false;
            dg.Columns[3].Visible = false;
            dg.Columns[4].Visible = false;
            dg.Columns[5].Visible = true;
            dg.Columns[6].Visible = true;
            dg.Columns[7].Visible = true;
            _setColorForDataGrid(dg);
            dg.AutoResizeColumns();
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dg.Refresh();
            Refrescounterdgridinfo();
        }

        private void _setColorForDataGrid(DataGridView dg)
        {
            selRowsCount_MI = 0;
            selRowsCount_MF = 0;
            selRowsCount_Unused = 0;
            foreach (DataGridViewRow irow in dg.Rows)
            {
                int value = Convert.ToInt16(irow.Cells[0].Value);
                switch (value)
                {
                    case 1:
                        irow.DefaultCellStyle.ForeColor = Color.Blue;
                        selRowsCount_MF++;
                        break;
                    case 2:
                        irow.DefaultCellStyle.ForeColor = Color.Green;
                        selRowsCount_MI++;
                        break;
                    case 3:
                        irow.DefaultCellStyle.ForeColor = Color.Orange;
                        selRowsCount_Unused++;
                        break;
                    default:
                        irow.DefaultCellStyle.ForeColor = Color.Gray;
                        break;
                }
            }
        }

        private void Refrescounterdgridinfo()
        {
            l_MF_count.Text = (selRowsCount_MF.ToString() + " Machine Fault");
            l_MI_count.Text = (selRowsCount_MI.ToString() + " Manual Int Fault");
            l_Noused.Text = (selRowsCount_Unused.ToString() + " Not Used");

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            lbAssetslist.Enabled = true;
            toolStripMenuItem5.Enabled = true;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            lbAssetslist.Enabled = false;
            toolStripMenuItem5.Enabled = false;
        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbgroupnames.Enabled = true;
            unselectAllToolStripMenuItem.Enabled = true;
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbgroupnames.Enabled = false;
            unselectAllToolStripMenuItem.Enabled = false;
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbgroupnames.ClearSelected();
        }

        private void lbAssetslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            _AddDevicesListBoxGroupnames();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            lbAssetslist.ClearSelected();
            lbgroupnames.Items.Clear();
            //  dataGridView_AllFaults.Rows.Clear();
            dataGridViewMAF.SuspendLayout();
            dataGridViewMAF.Rows.Clear();
            dataGridViewMAF.ResumeLayout();
        }

        private void deleteRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selectedrow in dataGridViewMAF.SelectedRows)
            {

                dataGridViewMAF.Rows.RemoveAt(selectedrow.Index);
            }
            Refrescounterdgridinfo();
        }

        private void machineFaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selrow in dataGridViewMAF.SelectedRows)
            {
                selrow.DefaultCellStyle.ForeColor = Color.Blue;
            }
        }

        private void manualIntFaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selrow in dataGridViewMAF.SelectedRows)
            {
                selrow.DefaultCellStyle.ForeColor = Color.Green;

                if (selrow.Cells[6].Value != null)
                {
                    lbMI.Items.Add(selrow.Cells[6].Value);
                }
                else
                {
                    MessageBox.Show(" For a fault: " + selrow.Cells[5].Value + " missing text, item not added to filter");
                }
                //  selrow.Cells[0].Value = 2;
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            DataggridMIFformating(dataGridViewMAF);
        }

        private void saveDataToXLSMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CreateXLSTable();

                if (cbcreateNew.Checked == true)
                {
                    _writeExternalExcelMiMF();
                }
                if (cbupdateactualDesignSheet.Checked == true)
                {
                    _CleanDastaSheetExcelMIMF();
                    _writeDastaSheetExcelMIMF();
                }
                if (cbCreateTxTout.Checked == true)
                {
                    _writeExternalExcelRoutineTXT();
                }
                if (cbCreateL5Xout.Checked == true)
                {
                    _writeExternalL5XRoutineMFMI();
                }
                MessageBox.Show("All Neccessary files are generated");
            }
            catch (Exception ex)
            {

                var sb = new StringBuilder();
                sb.Append("INTERRUPTED GENERATION OF FILES");
                sb.AppendLine(); // which is equal to Append(Environment.NewLine);
                sb.Append("Details: " + ex.ToString());
                //    return sb.ToString();
                //         MessageBox.Show("interrupted generation of files" + ex.ToString());
                MessageBox.Show(sb.ToString());
            }

        }

        private void _writeExternalL5XRoutineMFMI()
        {
            string outfilename = lbAssetslist.GetItemText(lbAssetslist.SelectedItem);
            string outfilename_sep = outfilename.Replace("/", ".");
            #region MF
            if (excel_MF.Count > 0)
            {
                int TargetCount = excel_MF.Count;
                string ExportDate = "True " + String.Format("{0:ddd MMM d HH:mm:ss yyyy}", System.DateTime.Now);  // "Sun, Mar 9, 2008" //"True Fri Jul 31 15:44:38 2015"; //System.DateTime.Now(); 
                string FILE_PATH = Properties.Settings.Default.SavePath + outfilename_sep + "_MF.L5X";
                string ExportOptions = "References DecoratedData Context RoutineLabels AliasExtras IOTags NoStringData ForceProtectedEncoding AllProjDocTrans";
                string PLCName = lcontrolerName.Text;
                string RoutineName = "B_" + outfilename.Substring(0, 4);
                XDocument xDoc = new XDocument(
                new XElement("RSLogix5000Content",
                                new XAttribute("SchemaRevision", "1.0"),
                                new XAttribute("SoftwareRevision", "20.01"),
                                new XAttribute("TargetName", RoutineName + "Faults_MF"),
                                new XAttribute("TargetType", "Routine"),
                                new XAttribute("TargetSubType", "RLL"),
                                new XAttribute("TargetClass", "Standard"),
                    //       new XAttribute("TargetCount", TargetCount.ToString()),
                                new XAttribute("ContainsContext", "true"),
                                new XAttribute("Owner", "Logix, Durr"),
                                new XAttribute("ExportDate", ExportDate),
                                new XAttribute("ExportOptions", ExportOptions),
              new XElement("Controller",
                                new XAttribute("Use", "Context"),
                                new XAttribute("Name", PLCName),
              new XElement("Programs",
                                new XAttribute("Use", "Context"),
              new XElement("Program",
                                new XAttribute("Use", "Context"),
                                new XAttribute("Name", "FIS"),
                                new XAttribute("Class", "Standard"),
              new XElement("Routines",
                                new XAttribute("Use", "Context"),
              new XElement("Routine",
                                new XAttribute("Use", "Target"),
                                new XAttribute("Name", RoutineName + "Faults_MF"),
                                new XAttribute("Type", "RLL"),
              new XElement("RLLContent")
                    //  new XAttribute("Use", "Context")
                                )))))));
                foreach (var item in excel_MF)
                {
                    xDoc.Root.Element("Controller").Element("Programs").Element("Program").Element("Routines").Element("Routine").Element("RLLContent").Add(
                    new XElement("Rung",
                        //    new XAttribute("Use", "Target"),
                              new XAttribute("Number", (item.Trigger - 1).ToString()),
                              new XAttribute("Type", "N"),
                              new XElement("Comment",
                              new XCData(item.FaultDescription)),
                              new XElement("Text",
                              new XCData("XIC(" + item.AddressPLC + ")OTE(" + item.AddressFIS + ");")
                              )));

                }


                xDoc.Save(FILE_PATH);
            }
            #endregion
            #region MI
            if (excel_MI.Count > 0)
            {
                int TargetCount = excel_MI.Count;
                string ExportDate = "Fri Jul 31 15:44:38 2015"; //System.DateTime.Now(); 
                string FILE_PATH = Properties.Settings.Default.SavePath + outfilename_sep + "_MI.L5X";
                string ExportOptions = "References DecoratedData Context RoutineLabels AliasExtras IOTags NoStringData ForceProtectedEncoding AllProjDocTrans";
                string PLCName = lcontrolerName.Text;
                string RoutineName = "B_" + outfilename.Substring(0, 4);
                XDocument xDoc = new XDocument(
        new XElement("RSLogix5000Content",
                        new XAttribute("SchemaRevision", "1.0"),
                        new XAttribute("SoftwareRevision", "20.01"),
                        new XAttribute("TargetName", RoutineName + "Faults_MF"),
                        new XAttribute("TargetType", "Routine"),
                        new XAttribute("TargetSubType", "RLL"),
                        new XAttribute("TargetClass", "Standard"),
                    //       new XAttribute("TargetCount", TargetCount.ToString()),
                        new XAttribute("ContainsContext", "true"),
                        new XAttribute("Owner", "Logix, Durr"),
                        new XAttribute("ExportDate", ExportDate),
                        new XAttribute("ExportOptions", ExportOptions),
      new XElement("Controller",
                        new XAttribute("Use", "Context"),
                        new XAttribute("Name", PLCName),
      new XElement("Programs",
                        new XAttribute("Use", "Context"),
      new XElement("Program",
                        new XAttribute("Use", "Context"),
                        new XAttribute("Name", "FIS"),
                        new XAttribute("Class", "Standard"),
      new XElement("Routines",
                        new XAttribute("Use", "Context"),
      new XElement("Routine",
                        new XAttribute("Use", "Target"),
                        new XAttribute("Name", RoutineName + "Faults_MI"),
                        new XAttribute("Type", "RLL"),
      new XElement("RLLContent")
                    //  new XAttribute("Use", "Context")
                        )))))));
                foreach (var item in excel_MI)
                {
                    xDoc.Root.Element("Controller").Element("Programs").Element("Program").Element("Routines").Element("Routine").Element("RLLContent").Add(
                    new XElement("Rung",
                        //    new XAttribute("Use", "Target"),
                              new XAttribute("Number", (item.Trigger - 1).ToString()),
                              new XAttribute("Type", "N"),
                              new XElement("Comment",
                              new XCData(item.FaultDescription)),
                    new XElement("Text",
                        new XCData("XIC(" + item.AddressPLC + ")OTE(" + item.AddressFIS + ");")
                              )));
                }
                xDoc.Save(FILE_PATH);
            }
            #endregion

        }
        private void _writeExternalExcelMiMF()
        {
            string outfilename = lbAssetslist.GetItemText(lbAssetslist.SelectedItem);
            string outfilename_sep = outfilename.Replace("/", ".");
            if (excel_MF.Count > 0)
            {
                File.WriteAllLines(Properties.Settings.Default.SavePath + outfilename_sep + "_MF.xls", excel_MF.Select(p => p.ToString()).ToArray());
            }
            if (excel_MI.Count > 0)
            {
                File.WriteAllLines(Properties.Settings.Default.SavePath + outfilename_sep + "_MI.xls", excel_MI.Select(p => p.ToString()).ToArray());
            }
            if (excel_unused.Count > 0)
            {
                File.WriteAllLines(Properties.Settings.Default.SavePath + outfilename_sep + "_Unnused.xls", excel_unused.Select(p => p.ToString()).ToArray());
            }
            MessageBox.Show(string.Format("{0}{1}{2}", " New Files for Asset: ", outfilename, "are generated!"));
        }
        private void _CleanDastaSheetExcelMIMF()
        {
            var filepath = designssheetlink;
            MyApp = new ExcelM.Application();
            MyApp.Visible = false;
            MyBook = MyApp.Workbooks.Open(filepath);
            #region Update MI
            MySheet_MI = (ExcelM.Worksheet)MyBook.Sheets[tagFISName + " MI"]; // Explicit cast is not required here
            //            ExcelM.Range cell_MI = MySheet_MI.Range[MySheet_MI.Cells[3, 1], MySheet_MI.Cells[excel_MI.Count + 2, 3]];
            ExcelM.Range cell_MI = MySheet_MI.Range[MySheet_MI.Cells[3, 1], MySheet_MI.Cells[500 + 2, 3]];

            foreach (ExcelM.Range item in cell_MI)
            {
                switch (item.Column)
                {
                    case 1:
                        //      item.Value = excel_MI.ElementAt(item.Row - 3).AddressFIS;
                        item.Value = "  ";
                        break;
                    case 2:
                        //             item.Value = excel_MI.ElementAt(item.Row - 3).Trigger;
                        item.Value = "  ";
                        break;
                    case 3:
                        //    item.Value = excel_MI.ElementAt(item.Row - 3).FaultDescription;
                        item.Value = "  ";
                        break;
                    default:
                        break;
                }
            }

            #endregion
            # region update MF

            MySheet_MF = (ExcelM.Worksheet)MyBook.Sheets[tagFISName + " MF"]; // Explicit cast is not required here
            //       ExcelM.Range cell_MF = MySheet_MF.Range[MySheet_MF.Cells[3, 1], MySheet_MF.Cells[excel_MF.Count + 2, 3]];
            ExcelM.Range cell_MF = MySheet_MF.Range[MySheet_MF.Cells[3, 1], MySheet_MF.Cells[500 + 2, 3]];

            foreach (ExcelM.Range item in cell_MF)
            {
                //   item.Value = string.Format("row:{0:D2} col:{1:D2}", item.Row, item.Column);
                //   item.Value = excel_MI.ElementAt(1).Address;
                switch (item.Column)
                {
                    case 1:
                        //                 item.Value = excel_MF.ElementAt(item.Row - 3).AddressFIS;
                        item.Value = "  ";
                        break;
                    case 2:
                        //              item.Value = excel_MF.ElementAt(item.Row - 3).Trigger;
                        item.Value = "  ";
                        break;
                    case 3:
                        //                item.Value = excel_MF.ElementAt(item.Row - 3).FaultDescription;
                        item.Value = "  ";
                        break;
                    default:
                        break;
                }
            }

            #endregion
            //          try
            //         {
            MyBook.SaveAs(Filename: filepath);
            MyBook.Close();
            //         }
            //          catch (Exception ex)
            //         {
            //             MessageBox.Show(ex.ToString());
            //         }


        }

        private void _writeDastaSheetExcelMIMF()
        {
            var filepath = designssheetlink;
            MyApp = new ExcelM.Application();
            MyApp.Visible = false;
            MyBook = MyApp.Workbooks.Open(filepath);
            #region Update MI
            MySheet_MI = (ExcelM.Worksheet)MyBook.Sheets[tagFISName + " MI"]; // Explicit cast is not required here
            ExcelM.Range cell_MI = MySheet_MI.Range[MySheet_MI.Cells[3, 1], MySheet_MI.Cells[excel_MI.Count + 2, 3]];
            if (excel_MI.Count > 0)
            {
                foreach (ExcelM.Range item in cell_MI)
                {
                    switch (item.Column)
                    {
                        case 1:
                            item.Value = excel_MI.ElementAt(item.Row - 3).AddressFIS;
                            break;
                        case 2:
                            item.Value = excel_MI.ElementAt(item.Row - 3).Trigger;
                            break;
                        case 3:
                            item.Value = excel_MI.ElementAt(item.Row - 3).FaultDescription;
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion
            # region update MF

            MySheet_MF = (ExcelM.Worksheet)MyBook.Sheets[tagFISName + " MF"]; // Explicit cast is not required here
            ExcelM.Range cell_MF = MySheet_MF.Range[MySheet_MF.Cells[3, 1], MySheet_MF.Cells[excel_MF.Count + 2, 3]];
            if (excel_MF.Count > 0)
            {
                foreach (ExcelM.Range item in cell_MF)
                {
                    //   item.Value = string.Format("row:{0:D2} col:{1:D2}", item.Row, item.Column);
                    //   item.Value = excel_MI.ElementAt(1).Address;
                    switch (item.Column)
                    {
                        case 1:
                            item.Value = excel_MF.ElementAt(item.Row - 3).AddressFIS;
                            break;
                        case 2:
                            item.Value = excel_MF.ElementAt(item.Row - 3).Trigger;
                            break;
                        case 3:
                            item.Value = excel_MF.ElementAt(item.Row - 3).FaultDescription;
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion
            //          try
            //         {
            MyBook.SaveAs(Filename: filepath);
            MyBook.Close();
            //         }
            //          catch (Exception ex)
            //         {
            //             MessageBox.Show(ex.ToString());
            //         }


        }
        private void _writeExternalExcelRoutineTXT()
        {
            string outfilename = lbAssetslist.GetItemText(lbAssetslist.SelectedItem);
            string outfilename_sep = outfilename.Replace("/", ".");
            if (excel_MF.Count > 0)
            {
                // XIC(CD01_OC0402_OC0402.AV.A1000_FMP)OTE(S001FIS.M.MachFlt[0].5);
                var temp = new List<string>();
                foreach (var item in excel_MF)
                {
                    temp.Add("XIC(" + item.AddressPLC + ")OTE(" + item.AddressFIS + ");");
                }
                File.WriteAllLines(Properties.Settings.Default.SavePath + outfilename_sep + "_routineMF.txt", temp.ToArray());
            }

            if (excel_MI.Count > 0)
            {
                var temp = new List<string>();
                foreach (var item in excel_MI)
                {
                    temp.Add("XIC(" + item.AddressPLC + ")OTE(" + item.AddressFIS + ");");
                }
                File.WriteAllLines(Properties.Settings.Default.SavePath + outfilename_sep + "_routineMI.txt", temp.ToArray());
            }
        }


        //   " New Files are generated!");

        private string addroutine(List<excel_out_data> aa)
        {
            string dupa = "";
            foreach (var item in excel_MI)
            {
                dupa = (item.AddressFIS + item.AddressPLC);
            }
            return dupa;
        }


        private void CreateXLSTable()
        {
            int miTrigger = 1;
            int afTrigger = 1;
            excel_MF.Clear();
            excel_MI.Clear();
            excel_unused.Clear();
            foreach (DataGridViewRow irow in dataGridViewMAF.Rows)
            {

                var value = irow.DefaultCellStyle.ForeColor.ToString();
                var exceptionname = irow.Cells[7].Value;                      // exception name. przechowywanie wartosci by ewentualnie nie dodawac do listy
                string faultDescription = (irow.Cells[5].Value + "_Spare");  // 1. tworze na wstepie blad nawet jesli to spare  ( 5 - full tag)

                string addressPLC = (irow.Cells[5].Value + "");              //3. pobieram rzeczywista wartosc taga 
                if (irow.Cells[6].Value != null)                              // sprawdzenie czy istnieje description
                    if (exceptionname != null)
                    {
                        if (lbAssetslist.SelectedItem.ToString() != exceptionname)
                        {
                            value = "Color [Orange]";
                        }
                    }
                {
                    if (irow.Cells[6].Value == null)  // 6 -text en
                    {
                        //   faultDescription = (irow.Cells[3].Value.ToString());
                        if (cb_removeDescNoName.Checked == true)                      // 2. jesli ma byc to sprawdzane usuwam go ;]
                        {
                            faultDescription = "  ";
                        }
                    }
                    else
                    {
                        faultDescription = (irow.Cells[3].Value.ToString()) + "-" + (irow.Cells[6].Value.ToString());  // 3 -group name + 6 - text desc en
                    }
                    //      irow.Cells[5].Value = new string 
                }
                switch (value)
                {
                    case "Color [Green]":
                        var dupa = irow.Cells[0].Value.ToString();
                        excel_MI.Add(new excel_out_data() { AddressFIS = CountFISBit(tagFISName, 2, miTrigger), AddressPLC = addressPLC, Trigger = miTrigger, FaultDescription = faultDescription });
                        miTrigger++;
                        break;
                    case "Color [Blue]":
                        excel_MF.Add(new excel_out_data() { AddressFIS = CountFISBit(tagFISName, 1, afTrigger), AddressPLC = addressPLC, Trigger = afTrigger, FaultDescription = faultDescription });
                        afTrigger++;
                        break;
                    case "Color [Orange]":
                        excel_unused.Add(new excel_out_data() { AddressFIS = tagFISName + "Unnused tag", AddressPLC = addressPLC, Trigger = 1, FaultDescription = faultDescription });
                        break;
                    default:
                        if (irow.Index == (dataGridViewMAF.Rows.Count - 1))
                        {
                            break;
                        }
                        MessageBox.Show("Missed fault: " + faultDescription);
                        break;
                }
            }

        }

        private string CountFISBit(string tag, int type, int pos)
        {
            string value = "";
            string parttype = "";
            int dint = pos / 32;
            int bit = pos % 32;

            switch (type)
            {
                case 1:
                    parttype = ".M.MachFlt";
                    break;
                case 2:
                    parttype = ".M.ManualInt";
                    break;
                default:
                    break;
            }

            value = tag + parttype + "[" + dint + "]." + bit;
            //  S001FIS.M.MachFlt[0].5
            //  S001FIS.M.ManualInt[0].5
            return value;
        }

        private void cbupdateactualDesignSheet_CheckedChanged(object sender, EventArgs e)
        {
            if (cbcreateNew.Checked == false)
            {
                cbDontUseDesignCrit.Checked = false;
                xLSDataSheetLoaded = false;
                bts_design.BackColor = Color.Red;
            }
            Properties.Settings.Default.cbCreateL5Xout = cbCreateL5Xout.Checked;
            Properties.Settings.Default.cbcreateNew = cbcreateNew.Checked;
            Properties.Settings.Default.cbCreateTxTout = cbCreateTxTout.Checked;
            Properties.Settings.Default.cbupdateactualDesignSheet = cbupdateactualDesignSheet.Checked;
            Properties.Settings.Default.Save();
        }

        private void unusedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selrow in dataGridViewMAF.SelectedRows)
            {
                selrow.DefaultCellStyle.ForeColor = Color.Orange;
                if ((selrow.Cells[6].Value) != null)
                {
                    lbRem.Items.Add(selrow.Cells[6].Value);
                }
                else
                {
                    MessageBox.Show(" For a fault: " + selrow.Cells[5].Value + " missing text, item not added to filter");
                }

            }
        }

        private void btRemMIItem_Click(object sender, EventArgs e)
        {
            while (lbMI.SelectedItems.Count > 0)
            {
                lbMI.Items.Remove(lbMI.SelectedItems[0]);
            }
        }

        private void btAddMIItem_Click(object sender, EventArgs e)
        {
            lbMI.Items.Add(tbMIAddItem.Text);
        }
        private void useFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    dasdadadwawda
        }

        private void copyDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell selcell in dataGridView_AllFaults.SelectedCells)
            {
                if (selcell.Value != null)
                {
                    Clipboard.SetText(selcell.Value.ToString());
                }
            }
        }

        private void misisingNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridView_AllFaults.Rows)
            {
                if (row.Cells[2].Value == null)
                {
                    row.DefaultCellStyle.ForeColor = Color.Purple;
                    count++;
                }

                if (row.Cells[2].Value != null)
                {
                    if (Convert.ToString(row.Cells[2].Value) == "0")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Purple;
                        count++;
                    }
                }

            }
            if (count > 0)
            {
                MessageBox.Show("Found " + count.ToString() + " Misising Numbers");
            }
            else
            {
                MessageBox.Show("No Misising Numbers");
            }
        }

        private void missingDescriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridView_AllFaults.Rows)
            {

                if (row.Cells[2].Value != null & row.Cells[6].Value == null)
                {

                    if (Convert.ToString(row.Cells[2].Value) != "0")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                MessageBox.Show("Found " + count.ToString() + " Missing Descriptions");
            }
            else
            {
                MessageBox.Show("No Missing Descriptions");
            }
        }

        private void unselectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_AllFaults.Rows)
            {
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void btAddRemItem_Click(object sender, EventArgs e)
        {
            lbRem.Items.Add(tbRemAddItem.Text);
        }

        private void tbDelRemItem_Click(object sender, EventArgs e)
        {
            while (lbRem.SelectedItems.Count > 0)
            {
                lbRem.Items.Remove(lbRem.SelectedItems[0]);
            }
        }

        private void cbDontUseDesignCrit_MouseLeave(object sender, EventArgs e)
        {

        }

        private void cbDontUseDesignCrit_Click(object sender, EventArgs e)
        {
            if (cbDontUseDesignCrit.Checked == true)
            {
                xLSDataSheetLoaded = true;
                bts_design.BackColor = Color.Green;
                cbcreateNew.Checked = true;
                cbupdateactualDesignSheet.Checked = false;
            }
            else
            {
                xLSDataSheetLoaded = false;
                bts_design.BackColor = Color.Red;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void removeAssignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string assetname = "";


            //foreach (DataGridViewRow selrow in dataGridViewhehe.SelectedRows)
            //{
            //    selrow.Cells[7].Value = assetname;
            //}
        }

        private void removeExceptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string assetname = null;

            foreach (DataGridViewRow selrow in dataGridViewMAF.SelectedRows)
            {
                selrow.Cells[7].Value = assetname;
            }
        }

        private void findDescToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
    #region classes
    class ExcelData
    {
        internal string fault_nr;   // field
        internal string comment_en;

        public ExcelData(string fault_nr, string comment_en)
        {
            this.fault_nr = fault_nr;
            this.comment_en = comment_en;
        }
        public bool Valid { get { return (!string.IsNullOrWhiteSpace(fault_nr) && !string.IsNullOrWhiteSpace(comment_en)); } }  //propertis
        public string Fault_nr { get { return fault_nr; } }
        public string Coment_en { get { return comment_en; } }
    }

    /// <summary>
    /// 
    /// </summary>
    class AssetList
    {
        internal string line;
        internal string assetname;
        internal string tagname;
        internal string ipaddress;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}-{1}", tagname, assetname);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="assetname"></param>
        /// <param name="ipaddress"></param>
        /// <param name="tagname"></param>
        public AssetList(string line, string assetname, string ipaddress, string tagname)
        {
            this.line = line;
            this.assetname = assetname;
            this.tagname = tagname;
            this.ipaddress = ipaddress;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Valid { get { return (!string.IsNullOrWhiteSpace(assetname) && !string.IsNullOrWhiteSpace(tagname)); } }  //propertis
        public string Line { get { return line; } }
        public string AssetName { get { return assetname; } }
        public string TagName { get { return tagname; } }
        public string IPAdress { get { return ipaddress; } }
        public List<int> Selected { get; set; }
        /// <summary>
        /// Fault Filtered List w huj opis
        /// </summary>
        public List<Single_fault> FaultfiltList { get; set; }
    }
    class TagAndDiscView
    {
        internal string fulltagname;
        internal string comment_en;
        public TagAndDiscView(string fulltagname, string comment_en)
        {
            this.fulltagname = fulltagname;
            this.comment_en = comment_en;
        }
        public string Fulltagname { get { return fulltagname; } }
        public string Comment_en { get { return comment_en; } }
    }

    class Pf_Alarm8
    {
        public static Dictionary<int, ExcelData> excelCustomerlist;
        public string Name { get; set; }
        public int Text1AB, Text2AB, Text3AB, Text4AB, Text5AB, Text6AB, Text7AB, Text8AB;
        public string Al1 { get { return Name + ".AV.A7261_ExtFlt1"; } }
        public string Al2 { get { return Name + ".AV.A7262_ExtFlt2"; } }
        public string Al3 { get { return Name + ".AV.A7263_ExtFlt3"; } }
        public string Al4 { get { return Name + ".AV.A7264_ExtFlt4"; } }
        public string Al5 { get { return Name + ".AV.A7265_ExtFlt5"; } }
        public string Al6 { get { return Name + ".AV.A7266_ExtFlt6"; } }
        public string Al7 { get { return Name + ".AV.A7267_ExtFlt7"; } }
        public string Al8 { get { return Name + ".AV.A7268_ExtFlt8"; } }
        public string TX1 { get { return GetTextFromInt(Text1AB); } }
        public string TX2 { get { return GetTextFromInt(Text2AB); } }
        public string TX3 { get { return GetTextFromInt(Text3AB); } }
        public string TX4 { get { return GetTextFromInt(Text4AB); } }
        public string TX5 { get { return GetTextFromInt(Text5AB); } }
        public string TX6 { get { return GetTextFromInt(Text6AB); } }
        public string TX7 { get { return GetTextFromInt(Text7AB); } }
        public string TX8 { get { return GetTextFromInt(Text8AB); } }


        private string GetTextFromInt(int magicnumber)
        {
            if (excelCustomerlist != null)
            {
                if (excelCustomerlist.ContainsKey(magicnumber))
                {
                    return excelCustomerlist[magicnumber].comment_en;
                }
            }
            return null;
        }

    }
    // hehehe
    class Single_fault
    {
        public static Dictionary<int, ExcelData> excelFaultList;
        public int FaultFISMember { get; set; }
        public string Name { get; set; }
        public int MagicNumber { get; set; }
        public string GroupName { get; set; }
        public string AVName { get; set; }
        public string Fulltag { get { return string.Format("{0}.{1}.{2}", GroupName, AVName, Name); } }
        public string FaultTextEn { get { return GetTextFromInt(MagicNumber); } }
        public string Exception { get; set; }

        private string GetTextFromInt(int magicnumber)
        {
            if (excelFaultList != null)
            {
                if (excelFaultList.ContainsKey(magicnumber))
                {
                    return excelFaultList[magicnumber].comment_en;
                }
            }
            return null;
        }



        public override string ToString()
        {
            return string.Format("{0}{7}{1}{7}{2}{7}{3}{7}{4}{7}{5}{7}{6}{7}", Name, MagicNumber, GroupName, AVName, Fulltag, FaultTextEn, FaultFISMember, "\t");
        }

    }

    public class MyListBoxItem
    {
        public MyListBoxItem(Color c, string m)
        {
            ItemColor = c;
            Message = m;
        }
        public Color ItemColor { get; set; }
        public string Message { get; set; }
    }
    //public class AssetStruct 
    //{
    //    public string AssetName { get; set; }
    //    public List<string> groupConnction { get; set; }
    //    public List<Single_fault> aaa { get; set; }
    //}

    class excel_out_data
    {
        public string AddressFIS { get; set; }
        public string AddressPLC { get; set; }
        public int Trigger { get; set; }
        public string FaultDescription { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{4}{1}{4}{2}{4}{3}", AddressFIS, AddressPLC, Trigger, FaultDescription, "\t");
        }
    }
    # endregion
}
