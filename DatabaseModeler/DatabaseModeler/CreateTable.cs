using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseModeler
{
    public partial class CreateTable : Form
    {
        int counter = 1;
        List<TextBox> tx = new List<TextBox>();
        List<ComboBox> cb = new List<ComboBox>();
        List<NumericUpDown> nup = new List<NumericUpDown>();
        List<CheckBox> checkBoxes = new List<CheckBox>();
        Form1 mainForm = null;
        DataSet dt1;
        public CreateTable(Form CallingForm, DataSet data1)
        {
            mainForm = CallingForm as Form1;
            dt1 = data1;
            InitializeComponent();
            tx.Add(ColumnText);
            cb.Add(ColumnType);
            nup.Add(ColumnSize);
            checkBoxes.Add(ColumnPK);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            tx.Add(new TextBox());
            tx[counter].Size = new Size(211, 20);
            tx[counter].Location = new Point(6,32 + 24*counter);
            cb.Add(new ComboBox());
            cb[counter].Location = new Point(223, 32 + 24 * counter);
            cb[counter].Size = new Size(121, 21);
            cb[counter].Tag = counter;
            cb[counter].SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            nup.Add(new NumericUpDown());
            nup[counter].Location = new Point(350,33 + 24*counter);
            nup[counter].Size = new Size(45,20);
            nup[counter].Maximum = 256;
            nup[counter].Value = 256;
            nup[counter].Enabled = false;
            checkBoxes.Add(new CheckBox());
            checkBoxes[counter].Location = new Point(425 ,32 + 24*counter);
            foreach (var item in ColumnType.Items)
            {
                cb[counter].Items.Add(item);
            }
            groupBox1.Controls.Add(tx[counter]);
            groupBox1.Controls.Add(cb[counter]);
            groupBox1.Controls.Add(nup[counter]);
            groupBox1.Controls.Add(checkBoxes[counter]);
            //groupBox1.Size = new Size(groupBox1.Size.Width, groupBox1.Size.Height + 24);
            //this.Size = new Size(this.Size.Width, this.Size.Height + 24);
            counter++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            DataTable table = dt1.Tables.Add(textBox1.Text);
            table.Columns.Add("Nazwa");
            table.Columns.Add("Typ");
            table.Columns.Add("Rozmiar");
            table.Columns.Add("Klucz");
            for (int i = 0; i < tx.Count; i++)
            {
                table.Rows.Add(tx[i].Text, cb[i].Text, nup[i].Value, checkBoxes[i].Checked);
            }
            string tmpSkrypt = "";
            foreach (DataTable t in dt1.Tables)
            {
                if (t.TableName == textBox1.Text)
                {
                    tmpSkrypt = "CREATE TABLE " + t.TableName + @" (
                    ";
                    int i = 0;
                    foreach (DataRow Row in t.Rows)
                    {
                            if (Row.ItemArray[1].ToString() == "TINYBLOB" || Row.ItemArray[1].ToString() == "TINETEXT" || Row.ItemArray[1].ToString() == "MEDIUMTEXT" || Row.ItemArray[1].ToString() == "MEDIUMBLOB" || Row.ItemArray[1].ToString() == "LONGTEXT" || Row.ItemArray[1].ToString() == "LONGTEXT" || Row.ItemArray[1].ToString() == "BOOL" || Row.ItemArray[1].ToString() == "BOOLEAN" || Row.ItemArray[1].ToString() == "DATE" || Row.ItemArray[1].ToString() == "INT") {
                                tmpSkrypt += Row.ItemArray[0] + " " + Row.ItemArray[1];
                                i++;
                            }
                            else
                            {
                                tmpSkrypt += Row.ItemArray[0] + " " + Row.ItemArray[1] + "(" + Row.ItemArray[2] + ")";
                                i++;
                            }
                            if (Row.ItemArray[3].ToString() == "True")
                                tmpSkrypt += " PRIMARY KEY";
                            tmpSkrypt += @",
                    ";
                    }
                    tmpSkrypt += @");
";
                    
                }
            }
            mainForm.drawTable(textBox1.Text,tx);
            mainForm.drawTables();
            mainForm.skrypt += tmpSkrypt;
            }
            catch (Exception)
            {
                MessageBox.Show("Tabela o nazwie " + textBox1.Text + " już istnieje.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (combo.SelectedItem.ToString() == "TINYBLOB" || combo.SelectedItem.ToString() == "TINETEXT" || combo.SelectedItem.ToString() == "MEDIUMTEXT" || combo.SelectedItem.ToString() == "MEDIUMBLOB" || combo.SelectedItem.ToString() == "LONGTEXT" || combo.SelectedItem.ToString() == "LONGTEXT" || combo.SelectedItem.ToString() == "BOOL" || combo.SelectedItem.ToString() == "BOOLEAN" || combo.SelectedItem.ToString() == "DATE" || combo.SelectedItem.ToString() == "INT")
            {
                nup[Convert.ToInt32(combo.Tag)].Enabled = false;
            }
            else
            {
                nup[Convert.ToInt32(combo.Tag)].Enabled = true;
            }
        }
    }
}
