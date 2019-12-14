using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            TrackerListBox.Items.Clear();
            List<TrackerInfo> trackers = Tracker.GetTrackerList();
            foreach (TrackerInfo tracker in trackers)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();
                item.SubItems[0].Text = tracker.trackerurl;
                item.SubItems.Add(tracker.status);
                TrackerListBox.Items.Add(item);
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
            List<TrackerInfo> trackers = Tracker.GetAvailibleTrackers();
            TrackerListOutput.Text = "";
            int n = 0;
            for (int i = 0; i < Tracker.GetAvailibleNum(); i++)
            {
                tracker = trackers[i];

                if (tracker.useable || checkBox1.Checked)
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
            MessageBox.Show("输出完成,一共:" + n.ToString());

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = checkBox5.Checked;
            checkBox4.Checked = checkBox5.Checked;
        }
    }
}
