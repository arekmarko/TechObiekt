
namespace DatabaseModeler
{
    partial class CreateTable
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ColumnPK = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ColumnSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ColumnType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ColumnText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnSize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 169);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.ColumnPK);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ColumnSize);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ColumnType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ColumnText);
            this.groupBox1.Location = new System.Drawing.Point(6, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 128);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kolumny";
            // 
            // ColumnPK
            // 
            this.ColumnPK.AutoSize = true;
            this.ColumnPK.Location = new System.Drawing.Point(425, 35);
            this.ColumnPK.Name = "ColumnPK";
            this.ColumnPK.Size = new System.Drawing.Size(15, 14);
            this.ColumnPK.TabIndex = 10;
            this.ColumnPK.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(401, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Klucz główny:";
            // 
            // ColumnSize
            // 
            this.ColumnSize.Enabled = false;
            this.ColumnSize.Location = new System.Drawing.Point(350, 33);
            this.ColumnSize.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.ColumnSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ColumnSize.Name = "ColumnSize";
            this.ColumnSize.Size = new System.Drawing.Size(45, 20);
            this.ColumnSize.TabIndex = 8;
            this.ColumnSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnSize.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rozmiar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nazwa tabeli:";
            // 
            // ColumnType
            // 
            this.ColumnType.FormattingEnabled = true;
            this.ColumnType.Items.AddRange(new object[] {
            "CHAR",
            "VARCHAR",
            "BINARY",
            "VARBINARY",
            "TINYBLOB",
            "TINYTEXT",
            "TEXT",
            "BLOB",
            "MEDIUMTEXT",
            "MEDIUMBLOB",
            "LONGTEXT",
            "LONGBLOB",
            "BIT",
            "BOOL",
            "BOOLEAN",
            "TINYINT",
            "SMALLINT",
            "MEDIUMINT",
            "INT",
            "INTEGER",
            "BIGINT",
            "FLOAT",
            "DOUBLE",
            "DECIMAL",
            "DATE"});
            this.ColumnType.Location = new System.Drawing.Point(223, 32);
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.Size = new System.Drawing.Size(121, 21);
            this.ColumnType.TabIndex = 2;
            this.ColumnType.Tag = "0";
            this.ColumnType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Typ:";
            // 
            // ColumnText
            // 
            this.ColumnText.Location = new System.Drawing.Point(6, 32);
            this.ColumnText.Name = "ColumnText";
            this.ColumnText.Size = new System.Drawing.Size(211, 20);
            this.ColumnText.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nazwa tabeli:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(355, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(0, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(486, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dodaj nowe pole";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(0, 200);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(486, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Utwórz tabelę";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CreateTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(486, 227);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "CreateTable";
            this.Text = "CreateTable";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ColumnType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ColumnText;
        private System.Windows.Forms.NumericUpDown ColumnSize;
        private System.Windows.Forms.CheckBox ColumnPK;
        private System.Windows.Forms.Label label5;
    }
}