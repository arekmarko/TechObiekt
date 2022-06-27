using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseModeler
{
    public partial class Form1 : Form
    {
        int tableW = 0;
        int tableH = 0;
        private string relationType;
        public string createTable;
        public static String connectionString = @"Data Source=LAPTOP-7FSNEQAP;Initial Catalog=Rozproszone;Integrated Security=True";
        private SqlConnection dbConnection;
        public List<TableList> tableLists;
        public List<RelationList> relationLists;
        public Rectangle selectedRec;
        Rectangle movingTable;
        public DataSet dt1 = new DataSet();
        public DataTable selectedTable = null;
        public DataTable clickedTable = null;
        public Form1()
        {
            InitializeComponent();
            tableLists = new List<TableList>();
            relationLists = new List<RelationList>();
            selectedRec = new Rectangle();
        }

        public string skrypt
        {
            get { return createTable;  }
            set { createTable = value; }
        }
        private void AddTable_Click(object sender, EventArgs e)
        {
            CreateTable ct = new CreateTable(this, dt1);
            ct.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textArea ta = new textArea(skrypt);
            ta.Show();
            
        }

        private void ExecuteScript_Click(object sender, EventArgs e)
        {
            try {
                dbConnection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(skrypt, dbConnection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Pomyślnie dodano tabelę do bazy danych.");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        public void drawTable(string table, List<TextBox> pola)
        {
            if (tableW*230 + 205 > panel2.Width)
            {
                tableW = 0;
                tableH++;
            }
            
            TableList tmpTableList = new TableList();
            tmpTableList.name = table;
            tmpTableList.startPoints = new Point(tableW * 230 + 20, tableH * 125 + 20);
            tmpTableList.endPoints = new Point( tableW * 230 + 20 + 205, tableH * 125 + 40 + ( 20 * pola.Count) );
            tableLists.Add(tmpTableList);
            tableW++;
        }

        public void drawTables()
        {
            int rowTables = 0;
            int colTables = 0;
            PaintEventArgs pe = new PaintEventArgs(panel2.CreateGraphics(), new Rectangle());
            Pen pen = new Pen(Color.Black, 1);
            SolidBrush br = new SolidBrush(Color.Black);
            pe.Graphics.Clear(Color.White);
            foreach (DataTable t in dt1.Tables)
            {
                var tab = tableLists.Find(x => x.name == t.TableName);
                pe.Graphics.DrawRectangle(pen, tab.startPoints.X, tab.startPoints.Y, 205, 20);
                pe.Graphics.DrawString(t.TableName.ToUpper(), new Font("consolas", 11), br, new Point(tab.startPoints.X, tab.startPoints.Y));
                int i = 1;
                foreach (DataRow row in t.Rows)
                {
                    if (row.ItemArray[3].ToString() == "True")
                    {
                        pe.Graphics.DrawString("*", new Font("consolas", 9), br, new Point(tab.startPoints.X, tab.startPoints.Y + 20 * i));
                        pe.Graphics.DrawString(row.ItemArray[0].ToString(), new Font("consolas", 9), br, new Point(tab.startPoints.X + 5, tab.startPoints.Y + 20 * i));
                    }
                    else
                    {
                        pe.Graphics.DrawString(row.ItemArray[0].ToString(), new Font("consolas", 9), br, new Point(tab.startPoints.X, tab.startPoints.Y + 20 * i));
                    }
                    pe.Graphics.DrawString(row.ItemArray[1].ToString() + "(" + row.ItemArray[2] + ")", new Font("consolas", 9), br, new Point(tab.startPoints.X + 100, tab.startPoints.Y + 20 * i));
                    pe.Graphics.DrawRectangle(pen, tab.startPoints.X, tab.startPoints.Y + 20 * i, 205, 20);
                    i++;
                }
                pe.Graphics.DrawLine(pen, new Point(tab.startPoints.X + 95, tab.startPoints.Y + 20), new Point(tab.startPoints.X + 95, tab.startPoints.Y + 20 * i));

                rowTables++;
                if (rowTables * 230 + 205 > panel2.Width)
                {
                    rowTables = 0;
                    colTables++;
                }
            }
            foreach (RelationList relation in relationLists)
            {
                if (relation.relationName == "onetoone")
                {
                    if (relation.parentDirection == "down")
                    {
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2, relation.endPoint.X, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2, relation.endPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2);
                    }
                    else if (relation.parentDirection == "up")
                    {
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2, relation.endPoint.X, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2, relation.endPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2);
                    }
                    else if (relation.parentDirection == "left") //naprawic
                    {
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y, relation.startPoint.X - Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.startPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X - Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.endPoint.Y, relation.endPoint.X, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X - Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.startPoint.Y, relation.startPoint.X - Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.endPoint.Y);
                    }
                    else if (relation.parentDirection == "right")
                    {
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y, relation.startPoint.X + Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.startPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X + Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.endPoint.Y, relation.endPoint.X, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X + Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.startPoint.Y, relation.startPoint.X + Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.endPoint.Y);
                    }
                }
                else if (relation.relationName == "onetomany")
                {
                    //pe.Graphics.DrawLine(pen, relation.startPoint, relation.endPoint);
                    if (relation.parentDirection == "down")
                    {
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y)/2);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2, relation.endPoint.X, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2, relation.endPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y + 30, relation.startPoint.X + 15, relation.startPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y + 30, relation.startPoint.X - 15, relation.startPoint.Y);
                    } 
                    else if (relation.parentDirection == "up")
                    {
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y)/2);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2, relation.endPoint.X, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2, relation.endPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y - 30, relation.startPoint.X + 15, relation.startPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y - 30, relation.startPoint.X - 15, relation.startPoint.Y);
                    }
                    else if (relation.parentDirection == "left") //naprawic
                    {
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y, relation.startPoint.X - Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.startPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X - Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.endPoint.Y, relation.endPoint.X, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X - Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.startPoint.Y, relation.startPoint.X - Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X - 30, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y + 15);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X - 30, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y - 15);
                    }
                    else if (relation.parentDirection == "right")
                    {
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y, relation.startPoint.X + Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.startPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X + Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.endPoint.Y, relation.endPoint.X, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X + Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.startPoint.Y, relation.startPoint.X + Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X + 30, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y + 15);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X + 30, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y - 15);
                    }
                }
                else if (relation.relationName == "manytomany")
                {
                    if (relation.parentDirection == "down")
                    {
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2, relation.endPoint.X, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2, relation.endPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y + 30, relation.startPoint.X + 15, relation.startPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y + 30, relation.startPoint.X - 15, relation.startPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X, relation.endPoint.Y - 30, relation.endPoint.X - 15, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X, relation.endPoint.Y - 30, relation.endPoint.X + 15, relation.endPoint.Y);
                    }
                    else if (relation.parentDirection == "up")
                    {
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2, relation.endPoint.X, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2, relation.endPoint.X, relation.startPoint.Y + (relation.endPoint.Y - relation.startPoint.Y) / 2);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y - 30, relation.startPoint.X + 15, relation.startPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y - 30, relation.startPoint.X - 15, relation.startPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X, relation.endPoint.Y + 30, relation.endPoint.X - 15, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X, relation.endPoint.Y + 30, relation.endPoint.X + 15, relation.endPoint.Y);
                    }
                    else if (relation.parentDirection == "left") //naprawic
                    {
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y, relation.startPoint.X - Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.startPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X - Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.endPoint.Y, relation.endPoint.X, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X - Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.startPoint.Y, relation.startPoint.X - Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X - 30, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y + 15);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X - 30, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y - 15);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X + 30, relation.endPoint.Y, relation.endPoint.X, relation.endPoint.Y - 15);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X + 30, relation.endPoint.Y, relation.endPoint.X, relation.endPoint.Y + 15);
                    }
                    else if (relation.parentDirection == "right")
                    {
                        pe.Graphics.DrawLine(pen, relation.startPoint.X, relation.startPoint.Y, relation.startPoint.X + Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.startPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X + Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.endPoint.Y, relation.endPoint.X, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X + Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.startPoint.Y, relation.startPoint.X + Math.Abs(relation.startPoint.X - relation.endPoint.X) / 2, relation.endPoint.Y);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X + 30, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y + 15);
                        pe.Graphics.DrawLine(pen, relation.startPoint.X + 30, relation.startPoint.Y, relation.startPoint.X, relation.startPoint.Y - 15);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X - 30, relation.endPoint.Y, relation.endPoint.X, relation.endPoint.Y - 15);
                        pe.Graphics.DrawLine(pen, relation.endPoint.X - 30, relation.endPoint.Y, relation.endPoint.X, relation.endPoint.Y + 15);
                    }
                }
            }
        }

        private void DeleteTable_Click(object sender, EventArgs e)
        {
            if (selectedRec.Location.X != 0 && selectedRec.Location.Y != 0)
            {
                dt1.Tables.Remove(label1.Text);
                tableLists.RemoveAll(x => (x.name == selectedTable.TableName));
                relationLists.RemoveAll(x => (x.parentTable.TableName == selectedTable.TableName || x.childTable.TableName == selectedTable.TableName));
                selectedRec = new Rectangle(0, 0, 0, 0);
                movingTable = new Rectangle(0, 0, 0, 0);
                selectedTable = null;
                clickedTable = null;
                drawTables();
            }
            else
            {
                MessageBox.Show("Nie zaznaczono tabeli");
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            PaintEventArgs pe = new PaintEventArgs(panel2.CreateGraphics(), new Rectangle());
            movingTable = new Rectangle(0, 0, 0, 0);
            switch (relationType) {
                case "onetoone":
                    label1.Text = "onetoone";
                    foreach (var t in tableLists)
                    {
                        if (e.X > t.startPoints.X && e.Y > t.startPoints.Y && e.X < t.endPoints.X && e.Y < t.endPoints.Y)
                        {
                            if (dt1.Tables[t.name] == clickedTable)
                            {
                                label1.Text = "Nie mozna";
                            }
                            else
                            {
                                bool isRelated = false;
                                foreach (RelationList rel in relationLists)
                                {

                                    if ((clickedTable == rel.parentTable && selectedTable == rel.childTable) || (clickedTable == rel.childTable && selectedTable == rel.parentTable))
                                    {
                                        isRelated = true;
                                    }
                                }
                                if (!isRelated)
                                {
                                    Point start = new Point(selectedRec.X + 102, selectedRec.Y + 20);
                                    Point end = new Point(t.startPoints.X + 102, t.startPoints.Y + 20);
                                    RelationList relation = new RelationList("onetoone", clickedTable, selectedTable, start, end);
                                    relationLists.Add(relation);
                                }
                                else
                                {
                                    label1.Text = "Relacja już istnieje";
                                }
                            }
                        }
                    }
                    relationType = null;
                    break;
                case "onetomany":
                    label1.Text = "onetomany";
                    foreach (var t in tableLists)
                    {
                        if (e.X > t.startPoints.X && e.Y > t.startPoints.Y && e.X < t.endPoints.X && e.Y < t.endPoints.Y)
                        {
                            if (dt1.Tables[t.name] == clickedTable)
                            {
                                label1.Text = "Nie mozna";
                            }
                            else
                            {
                                bool isRelated = false;
                                foreach (RelationList rel in relationLists)
                                {

                                    if ((clickedTable == rel.parentTable && selectedTable == rel.childTable) || (clickedTable == rel.childTable && selectedTable == rel.parentTable))
                                    {
                                        isRelated = true;
                                    }
                                }
                                if (!isRelated)
                                {
                                    addRelationship addRel = new addRelationship(this, clickedTable, selectedTable);
                                    addRel.Show();
                                }
                                else
                                {
                                    label1.Text = "Relacja już istnieje";
                                }
                            }
                        }
                    }
                    relationType = null;
                    break;
                case "manytoone":
                    label1.Text = "manytoone";
                    foreach (var t in tableLists)
                    {
                        if (e.X > t.startPoints.X && e.Y > t.startPoints.Y && e.X < t.endPoints.X && e.Y < t.endPoints.Y)
                        {
                            if (dt1.Tables[t.name] == clickedTable)
                            {
                                label1.Text = "Nie mozna";
                            }
                            else
                            {
                                bool isRelated = false;
                                foreach (RelationList rel in relationLists)
                                {

                                    if ((clickedTable == rel.parentTable && selectedTable == rel.childTable) || (clickedTable == rel.childTable && selectedTable == rel.parentTable))
                                    {
                                        isRelated = true;
                                    }
                                }
                                if (!isRelated)
                                {
                                    addRelationship addRel = new addRelationship(this, selectedTable, clickedTable);
                                    addRel.Show();
                                }
                                else
                                {
                                    label1.Text = "Relacja już istnieje";
                                }
                            }
                        }
                    }
                    relationType = null;
                    break;
                case "manytomany":
                    label1.Text = "manytomany";
                    foreach (var t in tableLists)
                    {
                        if (e.X > t.startPoints.X && e.Y > t.startPoints.Y && e.X < t.endPoints.X && e.Y < t.endPoints.Y)
                        {
                            if (dt1.Tables[t.name] == clickedTable)
                            {
                                label1.Text = "Nie mozna";
                            }
                            else
                            {
                                bool isRelated = false;
                                Point start = new Point(selectedRec.X + 102, selectedRec.Y + 20);
                                Point end = new Point(t.startPoints.X + 102, t.startPoints.Y + 20);
                                RelationList relation = new RelationList("manytomany", clickedTable, selectedTable, start, end);
                                foreach (RelationList rel in relationLists)
                                {

                                    if ((relation.parentTable == rel.parentTable && relation.childTable == rel.childTable) || (relation.parentTable == rel.childTable && relation.childTable == rel.parentTable))
                                    {
                                        isRelated = true;
                                    }
                                }
                                if (!isRelated)
                                {
                                    relationLists.Add(relation);
                                    pe.Graphics.DrawLine(new Pen(Color.Black), start.X, start.Y, end.X, start.Y);
                                    pe.Graphics.DrawLine(new Pen(Color.Black), end.X, start.Y, end.X, end.Y);
                                }
                                else
                                {
                                    label1.Text = "Relacja już istnieje";
                                }
                            }
                        }
                    }
                    relationType = null;
                    break;
                default:
                selectedRec = new Rectangle(0,0,0,0);
                label1.Text = e.X + "," + e.Y;
                foreach (var t in tableLists)
                {
                    if (e.X > t.startPoints.X && e.Y > t.startPoints.Y && e.X < t.endPoints.X && e.Y < t.endPoints.Y)
                    {
                        selectedTable = dt1.Tables[t.name];
                        label1.Text = selectedTable.TableName;
                        selectedRec = new Rectangle(t.startPoints.X, t.startPoints.Y, t.endPoints.X - t.startPoints.X, t.endPoints.Y - t.startPoints.Y);
                        pe.Graphics.DrawRectangle(new Pen(Color.Red), selectedRec);
                    }
                }
                    break;
            }
            updateSkrypt();
        }

        private void Export_Click(object sender, EventArgs e)
        {
            //drawTables();
            //updateSkrypt();
        }

        private void OneToOne_Click(object sender, EventArgs e)
        {
            if (selectedTable!= null)
            {
                label1.Text = "kliknij w kolejna tabele";
                relationType = "onetoone";
                clickedTable = selectedTable;
            }
            else
            {
                MessageBox.Show("Nie zaznaczono tabeli");
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingTable.X != 0 && movingTable.Y != 0)
            {
                foreach(var t in tableLists)
                {
                    if (t.name == selectedTable.TableName)
                    {
                        t.endPoints.X = t.endPoints.X - t.startPoints.X + e.X;
                        t.endPoints.Y = t.endPoints.Y - t.startPoints.Y + e.Y;
                        t.startPoints.X = e.X;
                        t.startPoints.Y = e.Y;
                    }
                }
                foreach (RelationList relation in relationLists)
                {
                    if (relation.parentTable.TableName == selectedTable.TableName)
                    {
                        if ((Math.Abs(relation.startPoint.X - relation.endPoint.X) >= Math.Abs(relation.startPoint.Y - relation.endPoint.Y)) && (relation.startPoint.X - relation.endPoint.X >= 0))
                        {
                            relation.startPoint = new Point(e.X, e.Y + 20);  //lewa
                            relation.parentDirection = "left";
                            relation.childDirection = "right";
                            TableList childtable = tableLists.Find(x => ( x.name == relation.childTable.TableName ));
                            relation.endPoint = new Point(childtable.startPoints.X + 205, childtable.startPoints.Y + 20);
                        }
                        else if ((Math.Abs(relation.startPoint.X - relation.endPoint.X) >= Math.Abs(relation.startPoint.Y - relation.endPoint.Y)) && (relation.startPoint.X - relation.endPoint.X < 0))
                        {
                            relation.startPoint = new Point(e.X + 205, e.Y + 20);  //prawa
                            relation.parentDirection = "right";
                            relation.childDirection = "left";
                            TableList childtable = tableLists.Find(x => (x.name == relation.childTable.TableName));
                            relation.endPoint = new Point(childtable.startPoints.X, childtable.startPoints.Y + 20);
                        }
                        else if ((Math.Abs(relation.startPoint.X - relation.endPoint.X) < Math.Abs(relation.startPoint.Y - relation.endPoint.Y)) && (relation.startPoint.Y - relation.endPoint.Y < 0))
                        {
                            relation.startPoint = new Point(e.X + 102, e.Y + 20 + relation.parentTable.Rows.Count * 20);  //dół
                            relation.parentDirection = "down";
                            relation.childDirection = "up";
                            TableList childtable = tableLists.Find(x => (x.name == relation.childTable.TableName));
                            relation.endPoint = new Point(childtable.startPoints.X + 102, childtable.startPoints.Y);
                        }
                        else if ((Math.Abs(relation.startPoint.X - relation.endPoint.X) < Math.Abs(relation.startPoint.Y - relation.endPoint.Y)) && (relation.startPoint.Y - relation.endPoint.Y >= 0))
                        {
                            relation.startPoint = new Point(e.X + 102, e.Y);  //góra
                            relation.parentDirection = "up";
                            relation.childDirection = "down";
                            TableList childtable = tableLists.Find(x => (x.name == relation.childTable.TableName));
                            relation.endPoint = new Point(childtable.startPoints.X + 102, childtable.startPoints.Y + 20 + relation.childTable.Rows.Count * 20);
                        }
                    }
                    if (relation.childTable.TableName == selectedTable.TableName)
                    {
                        if ((Math.Abs(relation.endPoint.X - relation.startPoint.X) >= Math.Abs(relation.endPoint.Y - relation.startPoint.Y)) && (relation.endPoint.X - relation.startPoint.X >= 0))
                        {
                            relation.endPoint = new Point(e.X, e.Y + 20);  //lewa
                            relation.childDirection = "left";
                            relation.parentDirection = "right";
                            TableList parenttable = tableLists.Find(x => (x.name == relation.parentTable.TableName));
                            relation.startPoint = new Point(parenttable.startPoints.X + 205, parenttable.startPoints.Y + 20);
                        }
                        else if ((Math.Abs(relation.endPoint.X - relation.startPoint.X) >= Math.Abs(relation.endPoint.Y - relation.startPoint.Y)) && (relation.endPoint.X - relation.startPoint.X < 0))
                        {
                            relation.endPoint = new Point(e.X + 205, e.Y + 20);  //prawa
                            relation.childDirection = "right";
                            relation.parentDirection = "left";
                            TableList parenttable = tableLists.Find(x => (x.name == relation.parentTable.TableName));
                            relation.startPoint = new Point(parenttable.startPoints.X, parenttable.startPoints.Y + 20);
                        }
                        else if ((Math.Abs(relation.endPoint.X - relation.startPoint.X) < Math.Abs(relation.endPoint.Y - relation.startPoint.Y)) && (relation.endPoint.Y - relation.startPoint.Y < 0))
                        {
                            relation.endPoint = new Point(e.X + 102, e.Y + 20 + relation.childTable.Rows.Count * 20);  //dół
                            relation.childDirection = "down";
                            relation.parentDirection = "up";
                            TableList parenttable = tableLists.Find(x => (x.name == relation.parentTable.TableName));
                            relation.startPoint = new Point(parenttable.startPoints.X + 102, parenttable.startPoints.Y);
                        }
                        else if ((Math.Abs(relation.endPoint.X - relation.startPoint.X) < Math.Abs(relation.endPoint.Y - relation.startPoint.Y)) && (relation.endPoint.Y - relation.startPoint.Y >= 0))
                        {
                            relation.endPoint = new Point(e.X + 102, e.Y);  //góra
                            relation.childDirection = "up";
                            relation.parentDirection = "down";
                            TableList parenttable = tableLists.Find(x => (x.name == relation.parentTable.TableName));
                            relation.startPoint = new Point(parenttable.startPoints.X + 102, parenttable.startPoints.Y + 20 + relation.parentTable.Rows.Count * 20);
                        }
                    }
                }
                drawTables();
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            PaintEventArgs pe = new PaintEventArgs(panel2.CreateGraphics(), new Rectangle());
            pe.Graphics.DrawRectangle(new Pen(Color.Black), selectedRec);
            foreach (var t in tableLists)
            {
                if (e.X > t.startPoints.X && e.Y > t.startPoints.Y && e.X < t.endPoints.X && e.Y < t.endPoints.Y)
                {
                    selectedTable = dt1.Tables[t.name];
                    movingTable = new Rectangle(t.startPoints.X, t.startPoints.Y, t.endPoints.X - t.startPoints.X, t.endPoints.Y - t.startPoints.Y);
                }
            }
        }

        private void OneToMany_Click(object sender, EventArgs e)
        {
            if (selectedTable != null)
            {
                label1.Text = "kliknij w kolejna tabele";
                relationType = "onetomany";
                clickedTable = selectedTable;
            }
            else
            {
                MessageBox.Show("Nie zaznaczono tabeli");
            }
        }

        private void ManyToMany_Click(object sender, EventArgs e)
        {
            if (selectedTable != null)
            {
                label1.Text = "kliknij w kolejna tabele";
                relationType = "manytomany";
                clickedTable = selectedTable;
            }
            else
            {
                MessageBox.Show("Nie zaznaczono tabeli");
            }
        }

        private void ManyToOne_Click(object sender, EventArgs e)
        {
            if (selectedTable != null)
            {
                label1.Text = "kliknij w kolejna tabele";
                relationType = "manytoone";
                clickedTable = selectedTable;
            }
            else
            {
                MessageBox.Show("Nie zaznaczono tabeli");
            }
        }
        public void updateSkrypt()
        {
            string tmpSkrypt = "";
            foreach (DataTable t in dt1.Tables)
            {
                    tmpSkrypt += "CREATE TABLE " + t.TableName + @" (
                    ";
                    int i = 0;
                    foreach (DataRow Row in t.Rows)
                    {
                        if (Row.ItemArray[1].ToString() == "TINYBLOB" || Row.ItemArray[1].ToString() == "TINETEXT" || Row.ItemArray[1].ToString() == "MEDIUMTEXT" || Row.ItemArray[1].ToString() == "MEDIUMBLOB" || Row.ItemArray[1].ToString() == "LONGTEXT" || Row.ItemArray[1].ToString() == "LONGTEXT" || Row.ItemArray[1].ToString() == "BOOL" || Row.ItemArray[1].ToString() == "BOOLEAN" || Row.ItemArray[1].ToString() == "DATE" || Row.ItemArray[1].ToString() == "INT")
                        {
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
            foreach(RelationList relation in relationLists)
            {
                tmpSkrypt += @"

";
                if (relation.relationName == "onetoone")
                {
                    tmpSkrypt += "ALTER TABLE " + relation.parentTable.TableName + @"
";
                    tmpSkrypt += "ADD FOREIGN KEY (" + relation.parentTable.Rows[0][0] + ") REFERENCES " + relation.childTable.TableName + "(" + relation.childTable.Rows[0][0] + @");
"; 
                    tmpSkrypt += "ALTER TABLE " + relation.childTable.TableName + @"
";
                    tmpSkrypt += "ADD FOREIGN KEY (" + relation.childTable.Rows[0][0] + ") REFERENCES " + relation.parentTable.TableName + "(" + relation.parentTable.Rows[0][0] + @");
";
                }
                else if (relation.relationName == "manytomany")
                {
                    tmpSkrypt += "CREATE TABLE " + relation.parentTable.TableName + "_" + relation.childTable.TableName + @"
                    ";
                    tmpSkrypt += relation.parentTable.TableName + relation.parentTable.Rows[0][0] + " " + relation.parentTable.Rows[0][1] + @" PRIMARY KEY,
                    ";
                    tmpSkrypt += relation.childTable.TableName + relation.childTable.Rows[0][0] + " " + relation.childTable.Rows[0][1] + @" PRIMARY KEY
);
";


                    tmpSkrypt += "ALTER TABLE " + relation.parentTable.TableName + "_" + relation.childTable.TableName + @"
";
                    tmpSkrypt += "ADD FOREIGN KEY (" + relation.parentTable.TableName + relation.parentTable.Rows[0][0] + ") REFERENCES " + relation.parentTable.TableName + "(" + relation.parentTable.Rows[0][0] + @");
";
                    tmpSkrypt += "ALTER TABLE " + relation.parentTable.TableName + "_" + relation.childTable.TableName + @"
";
                    tmpSkrypt += "ADD FOREIGN KEY (" + relation.childTable.TableName + relation.childTable.Rows[0][0] + ") REFERENCES " + relation.childTable.TableName + "(" + relation.childTable.Rows[0][0] + @");
";
                }
                else
                {
                tmpSkrypt += "ALTER TABLE " + relation.childTable.TableName + @"
";
                tmpSkrypt += "ADD FOREIGN KEY (" + relation.ForeignKey + ") REFERENCES " + relation.parentTable.TableName + "(" + relation.parentTable.Rows[0][0] + @");
";
                }
            }
            skrypt = tmpSkrypt;
        }
    }
    public class TableList
    {
        public string name;
        public Point startPoints;
        public Point endPoints;

    };
    public class RelationList
    {
        public string relationName;
        public DataTable parentTable;
        public DataTable childTable;
        public Point startPoint;
        public Point endPoint;
        public string parentDirection;
        public string childDirection;
        public string ForeignKey;
        public RelationList(string name, DataTable parent, DataTable child, Point start, Point end)
        {
            relationName = name;
            parentTable = parent;
            childTable = child;
            startPoint = start;
            endPoint = end;
        }
    }
}