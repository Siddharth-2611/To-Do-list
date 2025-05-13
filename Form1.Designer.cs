namespace ToDoListApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTask;
        private System.Windows.Forms.ListBox listTasks;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnMarkDone;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTask = new System.Windows.Forms.TextBox();
            this.listTasks = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnMarkDone = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "📝 To-Do List";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Size = new System.Drawing.Size(300, 40);
            // 
            // txtTask
            // 
            this.txtTask.Location = new System.Drawing.Point(15, 60);
            this.txtTask.Size = new System.Drawing.Size(300, 27);
            this.txtTask.Font = new System.Drawing.Font("Segoe UI", 10F);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(320, 60);
            this.btnAdd.Size = new System.Drawing.Size(100, 27);
            this.btnAdd.Text = "Add";
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listTasks
            // 
            this.listTasks.FormattingEnabled = true;
            this.listTasks.ItemHeight = 20;
            this.listTasks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listTasks.Location = new System.Drawing.Point(15, 100);
            this.listTasks.Size = new System.Drawing.Size(405, 200);
            // 
            // btnMarkDone
            // 
            this.btnMarkDone.Location = new System.Drawing.Point(15, 310);
            this.btnMarkDone.Size = new System.Drawing.Size(120, 30);
            this.btnMarkDone.Text = "Mark Done";
            this.btnMarkDone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMarkDone.Click += new System.EventHandler(this.btnMarkDone_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(150, 310);
            this.btnRemove.Size = new System.Drawing.Size(120, 30);
            this.btnRemove.Text = "Remove";
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(440, 360);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTask);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listTasks);
            this.Controls.Add(this.btnMarkDone);
            this.Controls.Add(this.btnRemove);
            this.Name = "Form1";
            this.Text = "To-Do List";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
