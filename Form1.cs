using System;
using System.Windows.Forms;

namespace ToDoListApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string task = txtTask.Text.Trim();
            if (!string.IsNullOrEmpty(task))
            {
                listTasks.Items.Add(task);
                txtTask.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a task.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            while (listTasks.SelectedItems.Count > 0)
            {
                listTasks.Items.Remove(listTasks.SelectedItems[0]);
            }
        }

        private void btnMarkDone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listTasks.SelectedIndices.Count; i++)
            {
                int index = listTasks.SelectedIndices[i];
                string item = listTasks.Items[index].ToString();
                if (!item.StartsWith("✔️ "))
                {
                    listTasks.Items[index] = "✔️ " + item;
                }
            }
        }
    }
}
