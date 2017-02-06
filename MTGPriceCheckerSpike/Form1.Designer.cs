namespace MTGPriceCheckerSpike
{
    partial class Form1
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
            this.button7 = new System.Windows.Forms.Button();
            this.lstCardResults = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSupplierAll = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnWatchListAdd = new System.Windows.Forms.Button();
            this.btnWatchListRemove = new System.Windows.Forms.Button();
            this.btnWatchListCheck = new System.Windows.Forms.Button();
            this.btnWatchListView = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSupplierSingle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(52, 651);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(356, 48);
            this.button7.TabIndex = 17;
            this.button7.Text = "SCG";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // lstCardResults
            // 
            this.lstCardResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCardResults.Location = new System.Drawing.Point(43, 110);
            this.lstCardResults.Margin = new System.Windows.Forms.Padding(4);
            this.lstCardResults.Name = "lstCardResults";
            this.lstCardResults.Size = new System.Drawing.Size(1013, 147);
            this.lstCardResults.TabIndex = 12;
            this.lstCardResults.UseCompatibleStateImageBehavior = false;
            this.lstCardResults.View = System.Windows.Forms.View.List;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(43, 30);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(364, 22);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "ancestral-mask";
            // 
            // btnSupplierAll
            // 
            this.btnSupplierAll.Location = new System.Drawing.Point(43, 265);
            this.btnSupplierAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupplierAll.Name = "btnSupplierAll";
            this.btnSupplierAll.Size = new System.Drawing.Size(497, 48);
            this.btnSupplierAll.TabIndex = 19;
            this.btnSupplierAll.Text = "Check All Suppliers";
            this.btnSupplierAll.UseVisualStyleBackColor = true;
            this.btnSupplierAll.Click += new System.EventHandler(this.btnSupplierAll_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(43, 320);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1013, 284);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnWatchListAdd
            // 
            this.btnWatchListAdd.Location = new System.Drawing.Point(415, 27);
            this.btnWatchListAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnWatchListAdd.Name = "btnWatchListAdd";
            this.btnWatchListAdd.Size = new System.Drawing.Size(144, 28);
            this.btnWatchListAdd.TabIndex = 22;
            this.btnWatchListAdd.Text = "Add to WatchList";
            this.btnWatchListAdd.UseVisualStyleBackColor = true;
            this.btnWatchListAdd.Click += new System.EventHandler(this.btnWatchListAdd_Click);
            // 
            // btnWatchListRemove
            // 
            this.btnWatchListRemove.Location = new System.Drawing.Point(567, 27);
            this.btnWatchListRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnWatchListRemove.Name = "btnWatchListRemove";
            this.btnWatchListRemove.Size = new System.Drawing.Size(171, 28);
            this.btnWatchListRemove.TabIndex = 23;
            this.btnWatchListRemove.Text = "Remove from WatchList";
            this.btnWatchListRemove.UseVisualStyleBackColor = true;
            this.btnWatchListRemove.Click += new System.EventHandler(this.btnWatchListRemove_Click);
            // 
            // btnWatchListCheck
            // 
            this.btnWatchListCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWatchListCheck.Location = new System.Drawing.Point(580, 265);
            this.btnWatchListCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnWatchListCheck.Name = "btnWatchListCheck";
            this.btnWatchListCheck.Size = new System.Drawing.Size(477, 48);
            this.btnWatchListCheck.TabIndex = 24;
            this.btnWatchListCheck.Text = "Check WatchList";
            this.btnWatchListCheck.UseVisualStyleBackColor = true;
            this.btnWatchListCheck.Click += new System.EventHandler(this.btnWatchListCheck_Click);
            // 
            // btnWatchListView
            // 
            this.btnWatchListView.Location = new System.Drawing.Point(746, 27);
            this.btnWatchListView.Margin = new System.Windows.Forms.Padding(4);
            this.btnWatchListView.Name = "btnWatchListView";
            this.btnWatchListView.Size = new System.Drawing.Size(171, 28);
            this.btnWatchListView.TabIndex = 25;
            this.btnWatchListView.Text = "View WatchList";
            this.btnWatchListView.UseVisualStyleBackColor = true;
            this.btnWatchListView.Click += new System.EventHandler(this.btnWatchListView_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Dracoti",
            "Sad Robot",
            "Top Deck",
            "Deck and Dice",
            "Scry",
            "Luck Shack",
            "Underworld Connections",
            "CardBox",
            "Battle Wizards"});
            this.comboBox1.Location = new System.Drawing.Point(43, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(251, 24);
            this.comboBox1.TabIndex = 26;
            // 
            // btnSupplierSingle
            // 
            this.btnSupplierSingle.Location = new System.Drawing.Point(315, 74);
            this.btnSupplierSingle.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupplierSingle.Name = "btnSupplierSingle";
            this.btnSupplierSingle.Size = new System.Drawing.Size(144, 28);
            this.btnSupplierSingle.TabIndex = 27;
            this.btnSupplierSingle.Text = "Check Supplier";
            this.btnSupplierSingle.UseVisualStyleBackColor = true;
            this.btnSupplierSingle.Click += new System.EventHandler(this.btnSupplierSingle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Choose Supplier:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Card Name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 645);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSupplierSingle);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnWatchListView);
            this.Controls.Add(this.btnWatchListCheck);
            this.Controls.Add(this.btnWatchListRemove);
            this.Controls.Add(this.btnWatchListAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSupplierAll);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.lstCardResults);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ListView lstCardResults;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSupplierAll;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnWatchListAdd;
        private System.Windows.Forms.Button btnWatchListRemove;
        private System.Windows.Forms.Button btnWatchListCheck;
        private System.Windows.Forms.Button btnWatchListView;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSupplierSingle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}

