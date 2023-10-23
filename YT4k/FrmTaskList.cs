﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YT4k
{
    public partial class FrmTaskList : Form
    {
        public FrmTaskList()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.yt4kicon;
            Text = "待下载任务管理";

            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;

            tsbDeleteTask.Visible = false;
            tsbDeleteList.Visible = false;

            foreach (string listName in FrmMain.DownloadTaskList.Keys)
            {
                lbVList.Items.Add(listName);
            }
            lbVList.SelectedIndexChanged += LbVList_SelectedIndexChanged;
            if (lbVList.Items.Count > 0)
            {
                lbVList.SelectedIndex = 0;
            }

            lvTaskList.SelectedIndexChanged += LvTaskList_SelectedIndexChanged;
            lvTaskList.View = System.Windows.Forms.View.List;

            this.FormClosed += FrmTaskList_FormClosed;
        }

        private void FrmTaskList_Load(object sender, EventArgs e)
        {
            changeMonitorStatus(true);
        }

        private void FrmTaskList_FormClosed(object? sender, FormClosedEventArgs e)
        {
            changeMonitorStatus(false);
            if (taskListChanged)
            {
                FrmMain.saveDownloadTaskList(selectedListName, selectedList);
            }
        }

        private void LvTaskList_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lvTaskList.SelectedIndices.Count == 0)
            {
                tsbDeleteTask.Visible = false;
            }
            else
            {
                tsbDeleteTask.Visible = true;
            }
        }

        string selectedListName;
        private void LbVList_SelectedIndexChanged(object? sender, EventArgs e)
        {
            tsbDeleteTask.Visible = false;

            if (taskListChanged)
            {
                FrmMain.saveDownloadTaskList(selectedListName, selectedList); 
                taskListChanged = false;
            }
            if (lbVList.SelectedItem != null)
            {
                selectedListName = lbVList.SelectedItem.ToString();
                selectedList = FrmMain.DownloadTaskList[selectedListName];
                lvTaskList.Items.Clear();
                foreach (string vID in selectedList)
                {
                    lvTaskList.Items.Add(vID);
                }

                if (lbVList.SelectedItem.ToString() == FrmMain.defaultListName)
                {
                    tsbDeleteList.Visible = false;
                }
                else
                {
                    tsbDeleteList.Visible = true;
                }
            }
            else
            {
                taskListChanged = false;

                tsbDeleteList.Visible = false;
            }
        }

        bool taskListChanged = false;
        List<string> selectedList;
        private void addOneTask(string vUri)
        {
            string vID = vUri.Split("=")[1];
            if (selectedList != null && !selectedList.Contains(vID))
            {
                selectedList.Add(vID);
                lvTaskList.Items.Add(vID);
                taskListChanged = true;
            }
        }

        private void tsbAddList_Click(object sender, EventArgs e)
        {
            FrmAddList fal = new FrmAddList();
            if (fal.ShowDialog() == DialogResult.OK)
            {
                string newListName = fal.getInputText();
                if (!lbVList.Items.Contains(newListName))
                {
                    lbVList.Items.Add(newListName);
                    FrmMain.DownloadTaskList.Add(newListName, new List<string>());

                }
                lbVList.SelectedItem = newListName;
            }
        }

        private void tsbDeleteList_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    "删除列表：" + lbVList.SelectedItem.ToString() + "\n删除？",
                    "删除确认",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    ) == DialogResult.Yes
                    )
            {
                taskListChanged = true;
                selectedList = new List<string>(); //触发删除操作

                string delListName = lbVList.SelectedItem.ToString();
                lbVList.Items.Remove(delListName);
                FrmMain.DownloadTaskList.Remove(delListName);
            }
        }

        private void tsbDeleteTask_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    "删除选择的任务\n删除？",
                    "删除确认",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    ) == DialogResult.Yes
                    )
            {
                taskListChanged = true;

                foreach(ListViewItem taskName in lvTaskList.SelectedItems)
                {
                    lvTaskList.Items.Remove(taskName);
                    selectedList.Remove(taskName.Text);
                }
            }
        }

        #region 监视剪贴板

        bool InClipboardMonitor = true;

        ClipboardMonitor cm;
        protected override void WndProc(ref Message m)
        {
            if (InClipboardMonitor && cm != null)
            {
                if (!cm.WndProc(ref m))
                {
                    base.WndProc(ref m);
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void changeMonitorStatus(bool inClipboardMonitor)
        {
            if (cm == null)
            {
                cm = new ClipboardMonitor();
                cm.ClipboardMsgHandler += ClipboardText_get;
            }
            InClipboardMonitor = inClipboardMonitor;
            cm.changeMonitorStatus(InClipboardMonitor, Handle);
        }
        private void ClipboardText_get(object sender, EventArgs e)
        {
            if (!InClipboardMonitor)
            {
                return;
            }
            changeMonitorStatus(false);
            string ClipboardString = ((ClipboardMonitor)sender).ClipboardString;
            if (FrmMain.checkYoutubeUri(ClipboardString))
            {
                addOneTask(ClipboardString);
            }
            changeMonitorStatus(true);
        }
        #endregion
    }
}