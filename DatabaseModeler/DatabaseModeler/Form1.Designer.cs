
namespace DatabaseModeler
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AddTable = new System.Windows.Forms.Button();
            this.DeleteTable = new System.Windows.Forms.Button();
            this.SaveFile = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ExecuteScript = new System.Windows.Forms.Button();
            this.Inheritance = new System.Windows.Forms.Button();
            this.ManyToMany = new System.Windows.Forms.Button();
            this.ManyToOne = new System.Windows.Forms.Button();
            this.OneToMany = new System.Windows.Forms.Button();
            this.OneToOne = new System.Windows.Forms.Button();
            this.dataSet1 = new DatabaseModeler.DataSet1();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // AddTable
            // 
            this.AddTable.Location = new System.Drawing.Point(3, 3);
            this.AddTable.Name = "AddTable";
            this.AddTable.Size = new System.Drawing.Size(194, 44);
            this.AddTable.TabIndex = 0;
            this.AddTable.Text = "Dodaj tabelę";
            this.AddTable.UseVisualStyleBackColor = true;
            this.AddTable.Click += new System.EventHandler(this.AddTable_Click);
            // 
            // DeleteTable
            // 
            this.DeleteTable.Location = new System.Drawing.Point(3, 53);
            this.DeleteTable.Name = "DeleteTable";
            this.DeleteTable.Size = new System.Drawing.Size(194, 43);
            this.DeleteTable.TabIndex = 1;
            this.DeleteTable.Text = "Usuń tabelę";
            this.DeleteTable.UseVisualStyleBackColor = true;
            this.DeleteTable.Click += new System.EventHandler(this.DeleteTable_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.Location = new System.Drawing.Point(3, 102);
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(194, 43);
            this.SaveFile.TabIndex = 2;
            this.SaveFile.Text = "Zapisz plik";
            this.SaveFile.UseVisualStyleBackColor = true;
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(3, 151);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(194, 43);
            this.OpenFile.TabIndex = 3;
            this.OpenFile.Text = "Otwórz plik";
            this.OpenFile.UseVisualStyleBackColor = true;
            // 
            // Export
            // 
            this.Export.AutoSize = true;
            this.Export.Location = new System.Drawing.Point(3, 200);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(194, 43);
            this.Export.TabIndex = 4;
            this.Export.Text = "Wyeksportuj";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.AddTable);
            this.panel1.Controls.Add(this.Export);
            this.panel1.Controls.Add(this.DeleteTable);
            this.panel1.Controls.Add(this.OpenFile);
            this.panel1.Controls.Add(this.SaveFile);
            this.panel1.Location = new System.Drawing.Point(12, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 518);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(3, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "Pokaż skrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Location = new System.Drawing.Point(215, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(707, 518);
            this.panel2.TabIndex = 6;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.ExecuteScript);
            this.panel3.Controls.Add(this.Inheritance);
            this.panel3.Controls.Add(this.ManyToMany);
            this.panel3.Controls.Add(this.ManyToOne);
            this.panel3.Controls.Add(this.OneToMany);
            this.panel3.Controls.Add(this.OneToOne);
            this.panel3.Location = new System.Drawing.Point(215, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(707, 63);
            this.panel3.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(496, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // ExecuteScript
            // 
            this.ExecuteScript.AutoSize = true;
            this.ExecuteScript.Location = new System.Drawing.Point(344, 3);
            this.ExecuteScript.Name = "ExecuteScript";
            this.ExecuteScript.Size = new System.Drawing.Size(114, 57);
            this.ExecuteScript.TabIndex = 5;
            this.ExecuteScript.Text = "Uruchom skrypt";
            this.ExecuteScript.UseVisualStyleBackColor = true;
            this.ExecuteScript.Click += new System.EventHandler(this.ExecuteScript_Click);
            // 
            // Inheritance
            // 
            this.Inheritance.Location = new System.Drawing.Point(255, 3);
            this.Inheritance.Name = "Inheritance";
            this.Inheritance.Size = new System.Drawing.Size(83, 57);
            this.Inheritance.TabIndex = 4;
            this.Inheritance.Text = "Dziedziczenie";
            this.Inheritance.UseVisualStyleBackColor = true;
            // 
            // ManyToMany
            // 
            this.ManyToMany.Location = new System.Drawing.Point(192, 3);
            this.ManyToMany.Name = "ManyToMany";
            this.ManyToMany.Size = new System.Drawing.Size(57, 57);
            this.ManyToMany.TabIndex = 3;
            this.ManyToMany.Text = "N:N";
            this.ManyToMany.UseVisualStyleBackColor = true;
            this.ManyToMany.Click += new System.EventHandler(this.ManyToMany_Click);
            // 
            // ManyToOne
            // 
            this.ManyToOne.Location = new System.Drawing.Point(129, 3);
            this.ManyToOne.Name = "ManyToOne";
            this.ManyToOne.Size = new System.Drawing.Size(57, 57);
            this.ManyToOne.TabIndex = 2;
            this.ManyToOne.Text = "N:1";
            this.ManyToOne.UseVisualStyleBackColor = true;
            this.ManyToOne.Click += new System.EventHandler(this.ManyToOne_Click);
            // 
            // OneToMany
            // 
            this.OneToMany.Location = new System.Drawing.Point(66, 3);
            this.OneToMany.Name = "OneToMany";
            this.OneToMany.Size = new System.Drawing.Size(57, 57);
            this.OneToMany.TabIndex = 1;
            this.OneToMany.Text = "1:N";
            this.OneToMany.UseVisualStyleBackColor = true;
            this.OneToMany.Click += new System.EventHandler(this.OneToMany_Click);
            // 
            // OneToOne
            // 
            this.OneToOne.Location = new System.Drawing.Point(3, 3);
            this.OneToOne.Name = "OneToOne";
            this.OneToOne.Size = new System.Drawing.Size(57, 57);
            this.OneToOne.TabIndex = 0;
            this.OneToOne.Text = "1:1";
            this.OneToOne.UseVisualStyleBackColor = true;
            this.OneToOne.Click += new System.EventHandler(this.OneToOne_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(929, 600);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddTable;
        private System.Windows.Forms.Button DeleteTable;
        private System.Windows.Forms.Button SaveFile;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button ExecuteScript;
        private System.Windows.Forms.Button Inheritance;
        private System.Windows.Forms.Button ManyToMany;
        private System.Windows.Forms.Button ManyToOne;
        private System.Windows.Forms.Button OneToMany;
        private System.Windows.Forms.Button OneToOne;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private DataSet1 dataSet1;
        public System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}

