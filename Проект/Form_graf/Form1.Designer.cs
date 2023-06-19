namespace Form_graf
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Scene = new System.Windows.Forms.PictureBox();
            this.Table = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.create = new System.Windows.Forms.ToolStripButton();
            this.conect = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.open = new System.Windows.Forms.ToolStripButton();
            this.Cleare = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.plus = new System.Windows.Forms.ToolStripButton();
            this.minus = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.T = new System.Windows.Forms.TextBox();
            this.S = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Scene)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scene
            // 
            this.Scene.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Scene.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Scene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Scene.Location = new System.Drawing.Point(3, 3);
            this.Scene.Name = "Scene";
            this.Scene.Size = new System.Drawing.Size(660, 372);
            this.Scene.TabIndex = 0;
            this.Scene.TabStop = false;
            this.Scene.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.Scene.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.Scene.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToDeleteRows = false;
            this.Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.ColumnHeadersVisible = false;
            this.Table.Location = new System.Drawing.Point(0, 33);
            this.Table.Name = "Table";
            this.Table.RowHeadersVisible = false;
            this.Table.Size = new System.Drawing.Size(660, 342);
            this.Table.TabIndex = 5;
            this.Table.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Table_MouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, -5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(674, 408);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.Scene);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(666, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Граф";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.create,
            this.conect,
            this.delete,
            this.save,
            this.open,
            this.Cleare});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(660, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // create
            // 
            this.create.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.create.Image = ((System.Drawing.Image)(resources.GetObject("create.Image")));
            this.create.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(54, 22);
            this.create.Text = "Создать";
            this.create.ToolTipText = "Создать\r\n";
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // conect
            // 
            this.conect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.conect.Image = ((System.Drawing.Image)(resources.GetObject("conect.Image")));
            this.conect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.conect.Name = "conect";
            this.conect.Size = new System.Drawing.Size(70, 22);
            this.conect.Text = "Соединить";
            this.conect.Click += new System.EventHandler(this.conect_Click);
            // 
            // delete
            // 
            this.delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.delete.Image = ((System.Drawing.Image)(resources.GetObject("delete.Image")));
            this.delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(55, 22);
            this.delete.Text = "Удалить";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // save
            // 
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.save.Image = ((System.Drawing.Image)(resources.GetObject("save.Image")));
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(69, 22);
            this.save.Text = "Сохранить";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // open
            // 
            this.open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.open.Image = ((System.Drawing.Image)(resources.GetObject("open.Image")));
            this.open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(58, 22);
            this.open.Text = "Открыть";
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // Cleare
            // 
            this.Cleare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Cleare.Image = ((System.Drawing.Image)(resources.GetObject("Cleare.Image")));
            this.Cleare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cleare.Name = "Cleare";
            this.Cleare.Size = new System.Drawing.Size(63, 22);
            this.Cleare.Text = "Очистить";
            this.Cleare.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.toolStrip2);
            this.tabPage2.Controls.Add(this.Table);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(666, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Матрица";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plus,
            this.minus});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(660, 28);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // plus
            // 
            this.plus.BackColor = System.Drawing.Color.Transparent;
            this.plus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.plus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plus.Image = ((System.Drawing.Image)(resources.GetObject("plus.Image")));
            this.plus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(41, 25);
            this.plus.Text = "  +  ";
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // minus
            // 
            this.minus.BackColor = System.Drawing.Color.Transparent;
            this.minus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.minus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.minus.Image = ((System.Drawing.Image)(resources.GetObject("minus.Image")));
            this.minus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(36, 25);
            this.minus.Text = "  -  ";
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.Result);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(666, 378);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Алгоритм";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Результат";
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(8, 136);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Result.Size = new System.Drawing.Size(649, 239);
            this.Result.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.T);
            this.groupBox1.Controls.Add(this.S);
            this.groupBox1.Controls.Add(this.start);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 100);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите алгоритм";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(371, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "В";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(271, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Из";
            // 
            // T
            // 
            this.T.Location = new System.Drawing.Point(375, 39);
            this.T.Name = "T";
            this.T.Size = new System.Drawing.Size(66, 26);
            this.T.TabIndex = 22;
            // 
            // S
            // 
            this.S.Location = new System.Drawing.Point(275, 39);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(66, 26);
            this.S.TabIndex = 21;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(525, 38);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(124, 27);
            this.start.TabIndex = 20;
            this.start.Text = "Вычислить";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Алгоритм Форда — Фалкерсона",
            "Алгоритм Эдмондса — Карпа",
            "Алгоритм Диница",
            "Алгоритм проталкивания предпотока",
            "Алгоритм Дейкстры",
            "Алгоритм Форда-Беллмана"});
            this.comboBox2.Location = new System.Drawing.Point(17, 37);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(227, 28);
            this.comboBox2.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 403);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Paint Tool Graf";
            ((System.ComponentModel.ISupportInitialize)(this.Scene)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox Scene;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton create;
        private System.Windows.Forms.ToolStripButton conect;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton plus;
        private System.Windows.Forms.ToolStripButton minus;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripButton open;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.ToolStripButton Cleare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox T;
        private System.Windows.Forms.TextBox S;
    }
}

