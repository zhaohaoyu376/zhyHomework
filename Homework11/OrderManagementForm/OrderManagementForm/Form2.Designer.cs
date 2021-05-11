namespace OrderManagementForm
{
    partial class Form2
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prodc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblOdId = new System.Windows.Forms.Label();
            this.txtOdId = new System.Windows.Forms.TextBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnModiItem = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.Prodc,
            this.Num,
            this.ItemPrice});
            this.dataGridView2.DataSource = this.orderItemBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(35, 187);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 57;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(443, 156);
            this.dataGridView2.TabIndex = 5;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "明细项编号";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 7;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 130;
            // 
            // Prodc
            // 
            this.Prodc.DataPropertyName = "Prodc";
            this.Prodc.HeaderText = "商品";
            this.Prodc.MinimumWidth = 7;
            this.Prodc.Name = "Prodc";
            this.Prodc.ReadOnly = true;
            this.Prodc.Width = 70;
            // 
            // Num
            // 
            this.Num.DataPropertyName = "Num";
            this.Num.HeaderText = "数量";
            this.Num.MinimumWidth = 7;
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.Width = 70;
            // 
            // ItemPrice
            // 
            this.ItemPrice.DataPropertyName = "ItemPrice";
            this.ItemPrice.HeaderText = "总价";
            this.ItemPrice.MinimumWidth = 7;
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.ReadOnly = true;
            this.ItemPrice.Width = 70;
            // 
            // orderItemBindingSource
            // 
            this.orderItemBindingSource.DataSource = typeof(OrderManagement.OrderItem);
            // 
            // lblOdId
            // 
            this.lblOdId.AutoSize = true;
            this.lblOdId.Location = new System.Drawing.Point(26, 33);
            this.lblOdId.Name = "lblOdId";
            this.lblOdId.Size = new System.Drawing.Size(76, 17);
            this.lblOdId.TabIndex = 6;
            this.lblOdId.Text = "订单号：";
            // 
            // txtOdId
            // 
            this.txtOdId.Location = new System.Drawing.Point(99, 30);
            this.txtOdId.Name = "txtOdId";
            this.txtOdId.Size = new System.Drawing.Size(100, 27);
            this.txtOdId.TabIndex = 7;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(26, 79);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(59, 17);
            this.lblClient.TabIndex = 8;
            this.lblClient.Text = "客户：";
            // 
            // cmbClient
            // 
            this.cmbClient.AutoCompleteCustomSource.AddRange(new string[] {
            "c1"});
            this.cmbClient.DataSource = this.clientBindingSource;
            this.cmbClient.DisplayMember = "Id";
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(99, 76);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(121, 25);
            this.cmbClient.TabIndex = 9;
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(OrderManagement.Client);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(29, 121);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(59, 17);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "地址：";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(99, 121);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 27);
            this.txtAddress.TabIndex = 11;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(32, 167);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(93, 17);
            this.lblItem.TabIndex = 12;
            this.lblItem.Text = "订单明细项";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(3, 3);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(137, 28);
            this.btnAddItem.TabIndex = 13;
            this.btnAddItem.Text = "添加明细项";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnModiItem
            // 
            this.btnModiItem.Location = new System.Drawing.Point(146, 3);
            this.btnModiItem.Name = "btnModiItem";
            this.btnModiItem.Size = new System.Drawing.Size(142, 28);
            this.btnModiItem.TabIndex = 14;
            this.btnModiItem.Text = "修改明细项";
            this.btnModiItem.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddItem);
            this.flowLayoutPanel1.Controls.Add(this.btnModiItem);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteItem);
            this.flowLayoutPanel1.Controls.Add(this.btnFinish);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(35, 349);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(443, 90);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Location = new System.Drawing.Point(294, 3);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(142, 28);
            this.btnDeleteItem.TabIndex = 15;
            this.btnDeleteItem.Text = "删除明细项";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            // 
            // btnFinish
            // 
            this.btnFinish.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFinish.Location = new System.Drawing.Point(3, 44);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(433, 34);
            this.btnFinish.TabIndex = 16;
            this.btnFinish.Text = "完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(OrderManagement.Order);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 449);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.txtOdId);
            this.Controls.Add(this.lblOdId);
            this.Controls.Add(this.dataGridView2);
            this.Name = "Form2";
            this.Text = "添加订单";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblOdId;
        private System.Windows.Forms.TextBox txtOdId;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnModiItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prodc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.BindingSource orderItemBindingSource;
        private System.Windows.Forms.BindingSource orderBindingSource;
    }
}