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
    public partial class addRelationship : Form
    {
        Form1 mainForm;
        DataTable parentTable;
        DataTable childTable;
        public addRelationship(Form CallingForm, DataTable parentT, DataTable childT)
        {
            mainForm = CallingForm as Form1;
            parentTable = parentT;
            childTable = childT;
            InitializeComponent();
            foreach(DataRow row in childTable.Rows)
            comboBox1.Items.Add(row[0].ToString() + ", " + row[1].ToString() + "(" + row[2].ToString() + ")");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableList parentList = mainForm.tableLists.Find(x => (x.name == parentTable.TableName));
            TableList childList = mainForm.tableLists.Find(x => (x.name == childTable.TableName));
            Point start = new Point(parentList.startPoints.X + 102, parentList.startPoints.Y + 20);
            Point end = new Point(childList.startPoints.X + 102, childList.startPoints.Y + 20);
            RelationList relation = new RelationList("onetomany", parentTable, childTable, start, end);
            relation.parentDirection = "down";
            relation.childDirection = "up";
            string[] key = comboBox1.SelectedItem.ToString().Split(',');
            relation.ForeignKey = key[0];
            mainForm.relationLists.Add(relation);
            mainForm.drawTables();
            mainForm.updateSkrypt();
            this.Close();
        }
    }
}
