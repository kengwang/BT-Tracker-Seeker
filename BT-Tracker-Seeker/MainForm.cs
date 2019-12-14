using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BT_Tracker_Seeker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void GetTrackerList_Click(object sender, EventArgs e)
        {
            Tracker.CleanTrackers();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    //MessageBox.Show(checkedListBox1.GetItemText(checkedListBox1.Items[i])); //弹出选中值
                    Status.Text = "正在获取 " + checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    if (Tracker.GetTracker(i))
                    {
                        Status.Text = "获取 " + checkedListBox1.GetItemText(checkedListBox1.Items[i]) + " 成功";
                    }
                    else
                    {
                        Status.Text = "获取 " + checkedListBox1.GetItemText(checkedListBox1.Items[i]) + " 失败";
                        MessageBox.Show("获取 " + checkedListBox1.GetItemText(checkedListBox1.Items[i]) + " 失败");
                    }
                }
            }
            MessageBox.Show("获取成功,共获取到" + Tracker.GetTrackerCount(), "个");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tracker.TrackerDistinct();
            MessageBox.Show("去重成功,现有" + Tracker.GetTrackerCount() + "个");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = TrackerListBox.Items.IndexOf(TrackerListBox.FocusedItem);
            TrackerListBox.Items.Clear();
            List<TrackerInfo> trackers = Tracker.GetTrackerList();
            foreach (TrackerInfo tracker in trackers)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();
                item.SubItems[0].Text = tracker.trackerurl;
                item.SubItems.Add(tracker.status);
                if (tracker.status == "可用")
                {
                    item.ForeColor = Color.White;
                    item.BackColor = Color.Green;
                }
                else if (tracker.status != "未检测")
                {
                    item.ForeColor = Color.White;
                    item.BackColor = Color.Red;
                }
                TrackerListBox.Items.Add(item);
            }
            if (a != -1)
            {
                TrackerListBox.Items[a].Selected = true;
                TrackerListBox.EnsureVisible(a);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Tracker.checking)
            {
                MessageBox.Show("正在检测中 请不要重复点击 当前检测到" + Tracker.GetAvailibleNum().ToString() + "个可用");
                return;
            }
            MessageBox.Show("该操作可能会耗时许久,请耐心等待,不要关闭程序");
            Status.Text = "正在检测可用性,可能会耗时许久";
            //采用多线程的方法 不阻塞主线程导致无响应
            Thread thread = new Thread(new ThreadStart(Tracker.CheckTrackers));
            thread.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TrackerInfo tracker = new TrackerInfo();

            TrackerListOutput.Text = "";
            int n = 0;
            if (!checkBox1.Checked)
            {
                List<TrackerInfo> trackers = Tracker.GetAvalibleTrackers();
                for (int i = 0; i < Tracker.GetTotalNum(); i++)
                {
                    tracker = trackers[i];

                    if (tracker.status == "可用")
                    {
                        n++;
                        if (checkBox2.Checked)
                        {
                            TrackerListOutput.Text += tracker.trackerurl + ",";
                        }
                        else
                        {
                            TrackerListOutput.Text += tracker.trackerurl + "\r\n";
                        }

                    }

                }
            }
            else
            {
                List<TrackerInfo> trackers = Tracker.GetAvalibleTrackers();
                for (int i = 0; i < Tracker.GetTotalNum(); i++)
                {
                    tracker = trackers[i];
                    n++;
                    if (checkBox2.Checked)
                    {
                        TrackerListOutput.Text += tracker.trackerurl + ",";
                    }
                    else
                    {
                        TrackerListOutput.Text += tracker.trackerurl + "\r\n";
                    }
                }
            }

            MessageBox.Show("输出完成,一共:" + n.ToString());

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int n = 0;
            string[] trackers = TrackerListOutput.Text.Split(new Char[] { '\r', '\n' }, StringSplitOptions.None);
            foreach (string tracker in trackers)
            {
                if (Tracker.AddRegularTracker(tracker))
                {
                    n++;
                }

            }
            MessageBox.Show("成功添加 " + n.ToString() + "个");
        }
    }
}
