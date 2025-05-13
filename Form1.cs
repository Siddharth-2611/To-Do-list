using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

class ToDoApp : Form
{
    TextBox txtTask;
    ListBox listTasks;
    Button btnAdd, btnRemove, btnMarkDone, btnEdit, btnClear, btnSave, btnLoad, btnSearch, btnToggleTheme;
    TextBox txtSearch;
    Label lblTitle;
    bool isDarkMode = false;
    string filePath = "tasks.txt";

    public ToDoApp()
    {
        this.Text = "Advanced To-Do List";
        this.Size = new Size(600, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Font = new Font("Segoe UI", 10);

        // Title
        lblTitle = new Label() { Text = "To-Do List", Font = new Font("Segoe UI", 18, FontStyle.Bold), AutoSize = true, Location = new Point(20, 10) };
        this.Controls.Add(lblTitle);

        txtTask = new TextBox() { Location = new Point(20, 60), Size = new Size(400, 30) };
        this.Controls.Add(txtTask);

        btnAdd = new Button() { Text = "Add Task", Location = new Point(430, 60), Size = new Size(120, 30) };
        btnAdd.Click += (s, e) => AddTask();
        this.Controls.Add(btnAdd);

        listTasks = new ListBox() { Location = new Point(20, 100), Size = new Size(530, 250) };
        this.Controls.Add(listTasks);

        // Buttons
        btnMarkDone = new Button() { Text = "Mark Done", Location = new Point(20, 370), Size = new Size(120, 30) };
        btnMarkDone.Click += (s, e) => MarkTaskDone();
        this.Controls.Add(btnMarkDone);

        btnEdit = new Button() { Text = "Edit Task", Location = new Point(150, 370), Size = new Size(120, 30) };
        btnEdit.Click += (s, e) => EditTask();
        this.Controls.Add(btnEdit);

        btnRemove = new Button() { Text = "Remove Task", Location = new Point(280, 370), Size = new Size(120, 30) };
        btnRemove.Click += (s, e) => RemoveTask();
        this.Controls.Add(btnRemove);

        btnClear = new Button() { Text = "Clear All", Location = new Point(410, 370), Size = new Size(120, 30) };
        btnClear.Click += (s, e) => ClearTasks();
        this.Controls.Add(btnClear);

        // Save/Load
        btnSave = new Button() { Text = "Save", Location = new Point(20, 420), Size = new Size(120, 30) };
        btnSave.Click += (s, e) => SaveTasks();
        this.Controls.Add(btnSave);

        btnLoad = new Button() { Text = "Load", Location = new Point(150, 420), Size = new Size(120, 30) };
        btnLoad.Click += (s, e) => LoadTasks();
        this.Controls.Add(btnLoad);

        // Search
        txtSearch = new TextBox() { Location = new Point(280, 420), Size = new Size(190, 30), PlaceholderText = "Search..." };
        this.Controls.Add(txtSearch);

        btnSearch = new Button() { Text = " ", Location = new Point(480, 420), Size = new Size(70, 30) };
        btnSearch.Click += (s, e) => SearchTasks();
        this.Controls.Add(btnSearch);

        // Theme
        btnToggleTheme = new Button() { Text = " Dark Mode", Location = new Point(20, 470), Size = new Size(530, 30) };
        btnToggleTheme.Click += (s, e) => ToggleTheme();
        this.Controls.Add(btnToggleTheme);

        LoadTasks();
    }

    void AddTask()
    {
        string task = txtTask.Text.Trim();
        if (!string.IsNullOrEmpty(task))
        {
            listTasks.Items.Add(task);
            txtTask.Clear();
        }
    }

    void RemoveTask()
    {
        while (listTasks.SelectedItems.Count > 0)
            listTasks.Items.Remove(listTasks.SelectedItems[0]);
    }

    void MarkTaskDone()
    {
        for (int i = 0; i < listTasks.SelectedIndices.Count; i++)
        {
            int index = listTasks.SelectedIndices[i];
            string item = listTasks.Items[index].ToString();
            if (!item.StartsWith(" "))
                listTasks.Items[index] = "  " + item;
        }
    }

    void EditTask()
    {
        if (listTasks.SelectedItem != null)
        {
            string current = listTasks.SelectedItem.ToString();
            string input = Microsoft.VisualBasic.Interaction.InputBox("Edit Task:", "Edit", current);
            if (!string.IsNullOrWhiteSpace(input))
            {
                int index = listTasks.SelectedIndex;
                listTasks.Items[index] = input.Trim();
            }
        }
    }

    void ClearTasks()
    {
        if (MessageBox.Show("Clear all tasks?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            listTasks.Items.Clear();
        }
    }

    void SaveTasks()
    {
        try
        {
            File.WriteAllLines(filePath, listTasks.Items.Cast<string>());
            MessageBox.Show("Tasks saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error saving tasks: " + ex.Message);
        }
    }

    void LoadTasks()
    {
        try
        {
            if (File.Exists(filePath))
            {
                listTasks.Items.Clear();
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    listTasks.Items.Add(line);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading tasks: " + ex.Message);
        }
    }

    void SearchTasks()
    {
        string query = txtSearch.Text.Trim().ToLower();
        for (int i = 0; i < listTasks.Items.Count; i++)
        {
            string item = listTasks.Items[i].ToString().ToLower();
            listTasks.SetSelected(i, item.Contains(query));
        }
    }

    void ToggleTheme()
    {
        Color bg, fg;
        if (!isDarkMode)
        {
            bg = Color.FromArgb(30, 30, 30);
            fg = Color.White;
            btnToggleTheme.Text = " Light Mode";
        }
        else
        {
            bg = SystemColors.Control;
            fg = Color.Black;
            btnToggleTheme.Text = " Dark Mode";
        }

        this.BackColor = bg;
        foreach (Control c in this.Controls)
        {
            c.BackColor = bg;
            c.ForeColor = fg;
        }

        isDarkMode = !isDarkMode;
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new ToDoApp());
    }
}
