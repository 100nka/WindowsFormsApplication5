using System;
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

namespace WindowsFormsApplication5
{
    public partial class FISGenerator : Form
    {
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
        private List<excel_out_data> excel_AF;
        private List<excel_out_data> excel_unused;
        private List<Pf_Alarm8> external_faults;
        private List<Single_fault> all_faults;
        private List<Single_fault> filtered_faults_MIF;
        private BindingSource _sourceFilteredFaults = new BindingSource();
        public bool l5xLoaded = false;
        public bool xLSCumstomLoaded = false;
        public bool xLSGeneralLoaded = false;
        public bool xLSDataSheetLoaded = false;
        //   public bool generatedfinished = false;
        public FISGenerator()
        {
            InitializeComponent();
            InitialMemArea();
            tbSavePath.Text = Properties.Settings.Default.SavePath.ToString();
            Genetatestatus(false);

            //  dataGridViewMAF.CellFormatting += dataGridViewMAF_CellFormatting;
            // dataGridViewMAF.CellClick = 
        }
        // private Regex filtr_PF_Alarm8 = new Regex(@"Pf_Alarm8\((?<FBI>.*?),(?<I1>\d+),(?<I2>\d+),(?<I3>\d+),(?<I4>\d+),(?<I5>\d+),(?<I6>\d+),(?<I7>\d+),(?<I8>\d+),(?<zVar>.*?),.*?\)", RegexOptions.Compiled);
        private Regex filtr_PF_Alarm8 = new Regex(Properties.Settings.Default.filtr_PF_Alarm8, RegexOptions.Compiled);
        # region load functions
        private void load_xml_Click(object sender, EventArgs e)
        {
            tbxmlname.Text = "";
            l5xLoaded = false;
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
                                tbcriteriasheetname.Text = file.SafeFileName;
                                Properties.Settings.Default.XLSM_designSheet = DirFromlink(file.FileName.ToString());
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
                ReadDataFromDesignCSheet(ds_excel_DesignCSheet, "AssetList", 1, 3, 4, 5);

                CreateAllDatatypes();
                CreatingExtFaults();
                CreatingIntFaults();

                dataGridView_AllFaults.DataSource = all_faults;
                dataGridView_AssetsList.DataSource = excelAssetlList;

                AddAssetsListBox();
                Genetatestatus(true);
            }
            else
            {
                MessageBox.Show("Necessary files for generate source are not loaded");
            }

        }


        private void AddAssetsListBox()
        {
            lbAssetslist.Items.Clear();
            foreach (var assetname in excelAssetlList)
            {
                lbAssetslist.Items.Add(assetname.TagName.ToString() + "-" + assetname.assetname.ToString());
            }

            if (this.lbAssetslist.ContextMenuStrip == null)
            {
                this.lbAssetslist.ContextMenuStrip = this.cmstripassetsname;
            }
            if (this.panel5.ContextMenuStrip == null)
            {
                this.panel5.ContextMenuStrip = this.cmstripassetsname;
            }
        }
        private void AddDevicesListBox()
        {
            //for (int i = 0; i < lbgroupnames.Items.Count; i++)
            //{
            lbgroupnames.Items.Clear();
            dataGridViewMAF.Rows.Clear();
            //}
            string name = "";
            foreach (var groupname in all_faults)
            {
                if (name != groupname.GroupName.ToString())
                {
                    name = groupname.GroupName.ToString();
                    lbgroupnames.Items.Add(name);
                }
            }

            if (this.lbgroupnames.ContextMenuStrip == null)
            {
                this.lbgroupnames.ContextMenuStrip = this.cmStripGroupnames;
            }
            if (this.panel6.ContextMenuStrip == null)
            {
                this.panel6.ContextMenuStrip = this.cmStripGroupnames;
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

                    all_faults.Add(new Single_fault() { AVName = av_name, GroupName = groupname, MagicNumber = magicnumber, Name = name, FaultFISMember = 1 });
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
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I1"].Value), Name = "A7261_ExtFlt1", FaultFISMember = 2 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I2"].Value), Name = "A7262_ExtFlt2", FaultFISMember = 2 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I3"].Value), Name = "A7263_ExtFlt3", FaultFISMember = 2 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I4"].Value), Name = "A7264_ExtFlt4", FaultFISMember = 2 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I5"].Value), Name = "A7265_ExtFlt5", FaultFISMember = 2 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I6"].Value), Name = "A7266_ExtFlt6", FaultFISMember = 2 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I7"].Value), Name = "A7267_ExtFlt7", FaultFISMember = 2 });
                    all_faults.Add(new Single_fault() { AVName = "AV", GroupName = m.Groups["zVar"].Value, MagicNumber = int.Parse(m.Groups["I8"].Value), Name = "A7268_ExtFlt8", FaultFISMember = 2 });
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
        }

        private object Find_AV(XElement av_tag)
        {
            var temp_av = av_tag.Descendants("StructureMember").Attributes("Name");
            av_tag.Descendants("StructureMember").Attributes("Name");
            return temp_av;
        }

        private bool is_AV(XElement dupa)
        {
            var temp = dupa.Descendants("StructureMember");
            var temp2 = from temp3 in temp where temp3.HasAttributes && temp3.Attribute("Name") != null && temp3.Attribute("Name").Value.Contains("AV") select temp3;
            if (temp2.Count() > 0)
            {
                return true;
            }
            return false;
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
        private void btSaveas_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(Properties.Settings.Default.SavePath + "dupaaa.xls", all_faults.Select(p => p.ToString()).ToArray());
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
            excel_AF = new List<excel_out_data>();
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
            }
            else
            {
                btstargen.BackColor = Color.Red;
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 newwindow = new Form1();
            newwindow.ShowDialog();
        }

        private void lbgroupnames_SelectedIndexChanged(object sender, EventArgs e)
        {

            dataGridViewMAF.DataSource = null;
            filtered_faults_MIF = new List<Single_fault>();
            if (lbgroupnames.SelectedItem != null)
            {
                var item = lbgroupnames.SelectedItem.ToString();
                foreach (var selecteditems in lbgroupnames.SelectedItems)
                {
                    var selname = selecteditems.ToString();
                    string[] saLvwItem = new string[2];
                    foreach (var fault in all_faults)
                    {
                        if (fault.GroupName == selname)
                        {
                            filtered_faults_MIF.Add(fault);
                        }
                    }

                }

                DataggridMIFformating();


            }

        }

        private void DataggridMIFformating()
        {
            _sourceFilteredFaults.DataSource = filtered_faults_MIF;
            dataGridViewMAF.DataSource = _sourceFilteredFaults;
            dataGridViewMAF.Columns[0].FillWeight = 100;
            dataGridViewMAF.Columns[1].FillWeight = 100;
            dataGridViewMAF.Columns[2].FillWeight = 100;
            dataGridViewMAF.Columns[3].FillWeight = 100;
            dataGridViewMAF.Columns[4].FillWeight = 100;
            dataGridViewMAF.Columns[5].FillWeight = 80;
            dataGridViewMAF.Columns[5].FillWeight = 100;
            dataGridViewMAF.Columns[0].Visible = false;
            dataGridViewMAF.Columns[1].Visible = false;
            dataGridViewMAF.Columns[2].Visible = false;
            dataGridViewMAF.Columns[3].Visible = false;
            dataGridViewMAF.Columns[4].Visible = false;
            dataGridViewMAF.Columns[5].Visible = true;
            dataGridViewMAF.Columns[6].Visible = true;

            foreach (DataGridViewRow irow in dataGridViewMAF.Rows)
            {
                int value = Convert.ToInt16(irow.Cells[0].Value);
                switch (value)
                {
                    case 1:
                        irow.DefaultCellStyle.ForeColor = Color.Blue;
                        break;
                    case 2:
                        irow.DefaultCellStyle.ForeColor = Color.Green;
                        break;
                    default:
                        irow.DefaultCellStyle.ForeColor = Color.Gray;
                        break;
                }
            }
            dataGridViewMAF.AutoResizeColumns();
            dataGridViewMAF.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMAF.Refresh();
            Refrescounterdgridinfo();


            if (this.dataGridViewMAF.ContextMenuStrip == null)
            {
                this.dataGridViewMAF.ContextMenuStrip = this.cMenuStrip;
            }
        }

        private void Refrescounterdgridinfo()
        {
            lrowslicz.Text = (Convert.ToString(dataGridViewMAF.Rows.Count - 1) + " Rows");
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
            AddDevicesListBox();
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
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selrow in dataGridViewMAF.SelectedRows)
            {
                selrow.DefaultCellStyle.ForeColor = Color.Orange;
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            DataggridMIFformating();
        }

        private void saveDataToXLSMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateXLSTable();
            string outfilename = lbAssetslist.GetItemText(lbAssetslist.SelectedItem);
            string outfilename_sep = outfilename.Replace("/", ".");
            File.WriteAllLines(Properties.Settings.Default.SavePath + outfilename_sep + "_AF.xls", excel_AF.Select(p => p.ToString()).ToArray());
            File.WriteAllLines(Properties.Settings.Default.SavePath + outfilename_sep + "_MI.xls", excel_MI.Select(p => p.ToString()).ToArray());
            if (excel_unused.Count > 0)
            {
            File.WriteAllLines(Properties.Settings.Default.SavePath + outfilename_sep + "_Unnused.xls", excel_unused.Select(p => p.ToString()).ToArray());
                
            }
            //  File.WriteAllLines(Properties.Settings.Default.SavePath + "dupaaa.xls", all_faults.Select(p => p.ToString()).ToArray());    
            MessageBox.Show(string.Format("{0}{1}{2}", "Files for Asset: ", outfilename, "are generated!"));
        }

        private void CreateXLSTable()
        {
            int miTrigger = 1;
            int afTrigger = 1;
            excel_AF.Clear();
            excel_MI.Clear();
            foreach (DataGridViewRow irow in dataGridViewMAF.Rows)
            {

                var value = irow.DefaultCellStyle.ForeColor.ToString();
                string faultDescription = (irow.Cells[3].Value + "_Spare");
                if (irow.Cells[6].Value != null)
                {
                    faultDescription = (irow.Cells[3].Value.ToString()) + "-" + (irow.Cells[6].Value.ToString());
                    //      irow.Cells[5].Value = new string 
                }
                switch (value)
                {
                    case "Color [Green]":
                        var dupa = irow.Cells[0].Value.ToString();
                        excel_MI.Add(new excel_out_data() { Address = CountFISBit("S001FIS", 2, miTrigger), Trigger = miTrigger, FaultDescription = faultDescription });
                        miTrigger++;
                        break;
                    case "Color [Blue]":
                        excel_AF.Add(new excel_out_data() { Address = CountFISBit("S001FIS", 1, afTrigger), Trigger = afTrigger, FaultDescription = faultDescription });
                        afTrigger++;
                        break;
                    case "Color [Orange]":
                        excel_unused.Add(new excel_out_data() { Address = "Unnused tag", Trigger = 1, FaultDescription = faultDescription });
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
                    parttype = "M.ManualInt";
                    break;
                default:
                    break;
            }

            value = tag + parttype + "[" + dint + "]." + bit;

            //  S001FIS.M.MachFlt[0].5
            //  S001FIS.M.ManualInt[0].5
            return value;
        }
        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow oneRow in dataGridViewMAF.Rows)
            {
                oneRow.Cells[6].Value = "bleble";
            }

            //foreach (DataGridViewRow selrow in dataGridViewMAF.Rows)
            //{
            //    selrow.Cells[6].Value = "Spare Fault";
            //   // selrow.DefaultCellStyle.ForeColor = Color.Green;
            //}
            //      dataGridViewMAF.Refresh();
        }


        //private void listView1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (Keys.Delete == e.KeyCode)
        //    {
        //        for (int i = lbfaults.SelectedIndices.Count - 1; i >= 0; i--)
        //        {
        //            lbfaults.Items.RemoveAt(lbfaults.SelectedIndices[i]);
        //        }
        //    }
        //}
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

    class AssetList
    {
        internal string line;
        internal string assetname;
        internal string tagname;
        internal string ipaddress;

        public AssetList(string line, string assetname, string ipaddress, string tagname)
        {
            this.line = line;
            this.assetname = assetname;
            this.tagname = tagname;
            this.ipaddress = ipaddress;
        }
        public bool Valid { get { return (!string.IsNullOrWhiteSpace(assetname) && !string.IsNullOrWhiteSpace(tagname)); } }  //propertis
        public string Line { get { return line; } }
        public string AssetName { get { return assetname; } }
        public string TagName { get { return tagname; } }
        public string IPAdress { get { return ipaddress; } }

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

    class excel_out_data
    {
        public string Address { get; set; }
        public int Trigger { get; set; }
        public string FaultDescription { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{3}{1}{3}{2}", Address, Trigger, FaultDescription, "\t");
        }

    }
    # endregion
}
