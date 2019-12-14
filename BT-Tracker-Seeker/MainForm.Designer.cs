namespace BT_Tracker_Seeker
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GetTrackerList = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.TrackerListOutput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TrackerListBox = new System.Windows.Forms.ListView();
            this.TrackerURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TrackerStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "[Inner List From 百度贴吧]",
            "TrackersListCollection - all",
            "TrackersListCollection - best",
            "trackerslist - all",
            "trackerslist - best",
            "trackerslist - ip",
            "NewTrackon",
            "OpenTracker"});
            this.checkedListBox1.Location = new System.Drawing.Point(18, 36);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(201, 196);
            this.checkedListBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tracker源";
            // 
            // GetTrackerList
            // 
            this.GetTrackerList.Location = new System.Drawing.Point(13, 246);
            this.GetTrackerList.Name = "GetTrackerList";
            this.GetTrackerList.Size = new System.Drawing.Size(199, 42);
            this.GetTrackerList.TabIndex = 2;
            this.GetTrackerList.Text = "获取Tracker列表";
            this.GetTrackerList.UseVisualStyleBackColor = true;
            this.GetTrackerList.Click += new System.EventHandler(this.GetTrackerList_Click);
            // 
            // Status
            // 
            this.Status.Font = new System.Drawing.Font("宋体", 15F);
            this.Status.Location = new System.Drawing.Point(18, 564);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(732, 23);
            this.Status.TabIndex = 4;
            this.Status.Text = "当前状态 - 等待获取";
            this.Status.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // TrackerListOutput
            // 
            this.TrackerListOutput.Location = new System.Drawing.Point(233, 246);
            this.TrackerListOutput.Multiline = true;
            this.TrackerListOutput.Name = "TrackerListOutput";
            this.TrackerListOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TrackerListOutput.Size = new System.Drawing.Size(517, 290);
            this.TrackerListOutput.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Tracker去重";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(193, 39);
            this.button2.TabIndex = 7;
            this.button2.Text = "显示到表格";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TrackerListBox
            // 
            this.TrackerListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TrackerURL,
            this.TrackerStatus});
            this.TrackerListBox.FullRowSelect = true;
            this.TrackerListBox.GridLines = true;
            this.TrackerListBox.HideSelection = false;
            this.TrackerListBox.Location = new System.Drawing.Point(233, 34);
            this.TrackerListBox.MultiSelect = false;
            this.TrackerListBox.Name = "TrackerListBox";
            this.TrackerListBox.Size = new System.Drawing.Size(516, 197);
            this.TrackerListBox.TabIndex = 8;
            this.TrackerListBox.UseCompatibleStateImageBehavior = false;
            this.TrackerListBox.View = System.Windows.Forms.View.Details;
            // 
            // TrackerURL
            // 
            this.TrackerURL.Text = "Tracker";
            this.TrackerURL.Width = 402;
            // 
            // TrackerStatus
            // 
            this.TrackerStatus.Text = "Tracker状态";
            this.TrackerStatus.Width = 94;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(20, 401);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(189, 40);
            this.button3.TabIndex = 9;
            this.button3.Text = "Tracker可用性检测";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(21, 450);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 54);
            this.button4.TabIndex = 10;
            this.button4.Text = "输出tracker";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(20, 520);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "输出不可用";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(131, 520);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(78, 16);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "转为aria2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(135, 450);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(84, 16);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.Text = "http/https";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(135, 470);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(42, 16);
            this.checkBox4.TabIndex = 14;
            this.checkBox4.Text = "udp";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(135, 488);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(72, 16);
            this.checkBox5.TabIndex = 15;
            this.checkBox5.Text = "其他协议";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(128, 445);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 58);
            this.label3.TabIndex = 16;
            this.label3.Text = "该标签下方功能建设中!";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 611);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.TrackerListBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TrackerListOutput);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.GetTrackerList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "BT Tracker Seeker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GetTrackerList;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.TextBox TrackerListOutput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView TrackerListBox;
        private System.Windows.Forms.ColumnHeader TrackerURL;
        private System.Windows.Forms.ColumnHeader TrackerStatus;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label3;
    }
}

