using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab3.TehPrelucrareDb
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            comboBox1 = new ComboBox();
            previousBtn = new Button();
            nextBtn = new Button();
            currentRecordCount = new Label();
            dataFieldsPanel = new FlowLayoutPanel();
            adventureWorksDataAccessBindingSource = new BindingSource(components);
            updateBtn = new Button();
            deleteBtn = new Button();
            insertBtn = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lastPageBtn = new Button();
            firstPageBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)adventureWorksDataAccessBindingSource).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(23, 16);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(401, 28);
            comboBox1.TabIndex = 0;
            comboBox1.Click += ComboBox1_SelectedIndexChanged;
            // 
            // previousBtn
            // 
            previousBtn.Location = new Point(207, 4);
            previousBtn.Margin = new Padding(3, 4, 3, 4);
            previousBtn.Name = "previousBtn";
            previousBtn.Size = new Size(86, 31);
            previousBtn.TabIndex = 1;
            previousBtn.Text = "Previous";
            previousBtn.UseVisualStyleBackColor = true;
            previousBtn.Click += previousButton_Click;
            // 
            // nextBtn
            // 
            nextBtn.Location = new Point(333, 4);
            nextBtn.Margin = new Padding(3, 4, 3, 4);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(86, 31);
            nextBtn.TabIndex = 2;
            nextBtn.Text = "Next";
            nextBtn.UseVisualStyleBackColor = true;
            nextBtn.Click += nextButton_Click;
            // 
            // currentRecordCount
            // 
            currentRecordCount.AutoSize = true;
            currentRecordCount.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            currentRecordCount.Location = new Point(299, 0);
            currentRecordCount.Name = "currentRecordCount";
            currentRecordCount.Size = new Size(28, 35);
            currentRecordCount.TabIndex = 3;
            currentRecordCount.Text = "0";
            // 
            // dataFieldsPanel
            // 
            dataFieldsPanel.AutoScroll = true;
            dataFieldsPanel.DataBindings.Add(new Binding("FlowDirection", adventureWorksDataAccessBindingSource, "DataTable", true, DataSourceUpdateMode.OnPropertyChanged));
            dataFieldsPanel.Location = new Point(23, 80);
            dataFieldsPanel.Margin = new Padding(3, 4, 3, 4);
            dataFieldsPanel.Name = "dataFieldsPanel";
            dataFieldsPanel.Size = new Size(878, 504);
            dataFieldsPanel.TabIndex = 4;
            // 
            // adventureWorksDataAccessBindingSource
            // 
            adventureWorksDataAccessBindingSource.DataSource = typeof(AdventureWorksDataAccess);
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(23, 616);
            updateBtn.Margin = new Padding(3, 4, 3, 4);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(86, 31);
            updateBtn.TabIndex = 5;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(129, 616);
            deleteBtn.Margin = new Padding(3, 4, 3, 4);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(86, 31);
            deleteBtn.TabIndex = 6;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // insertBtn
            // 
            insertBtn.Location = new Point(232, 616);
            insertBtn.Margin = new Padding(3, 4, 3, 4);
            insertBtn.Name = "insertBtn";
            insertBtn.Size = new Size(86, 31);
            insertBtn.TabIndex = 7;
            insertBtn.Text = "Insert";
            insertBtn.UseVisualStyleBackColor = true;
            insertBtn.Click += insertBtn_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lastPageBtn);
            flowLayoutPanel1.Controls.Add(nextBtn);
            flowLayoutPanel1.Controls.Add(currentRecordCount);
            flowLayoutPanel1.Controls.Add(previousBtn);
            flowLayoutPanel1.Controls.Add(firstPageBtn);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.ImeMode = ImeMode.NoControl;
            flowLayoutPanel1.Location = new Point(430, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(471, 39);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // lastPageBtn
            // 
            lastPageBtn.Location = new Point(425, 3);
            lastPageBtn.Name = "lastPageBtn";
            lastPageBtn.Size = new Size(43, 31);
            lastPageBtn.TabIndex = 4;
            lastPageBtn.Text = ">>";
            lastPageBtn.UseVisualStyleBackColor = true;
            lastPageBtn.Click += lastPageButton_Click;
            // 
            // firstPageBtn
            // 
            firstPageBtn.Location = new Point(163, 3);
            firstPageBtn.Name = "firstPageBtn";
            firstPageBtn.Size = new Size(38, 32);
            firstPageBtn.TabIndex = 5;
            firstPageBtn.Text = "<<";
            firstPageBtn.UseVisualStyleBackColor = true;
            firstPageBtn.Click += firstPageButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 663);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(insertBtn);
            Controls.Add(deleteBtn);
            Controls.Add(updateBtn);
            Controls.Add(dataFieldsPanel);
            Controls.Add(comboBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)adventureWorksDataAccessBindingSource).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private Button previousBtn;
        private Button nextBtn;
        private Label currentRecordCount;
        private FlowLayoutPanel dataFieldsPanel;
        private Button updateBtn;
        private Button deleteBtn;
        private Button insertBtn;
        private FlowLayoutPanel flowLayoutPanel1;
        private BindingSource adventureWorksDataAccessBindingSource;
        private Button lastPageBtn;
        private Button firstPageBtn;
    }
}