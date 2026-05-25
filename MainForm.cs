using System;
using System.Windows.Forms;

namespace WindowsApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Form Properties
            this.Text = "My Windows Application";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = SystemIcons.Application;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // Create Menu Strip
            MenuStrip menuStrip = new MenuStrip();
            menuStrip.BackColor = System.Drawing.Color.LightGray;

            // File Menu
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("&File");
            ToolStripMenuItem newMenuItem = new ToolStripMenuItem("&New", null, NewMenuItem_Click);
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem("&Open", null, OpenMenuItem_Click);
            ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("&Save", null, SaveMenuItem_Click);
            fileMenu.DropDownItems.Add(newMenuItem);
            fileMenu.DropDownItems.Add(openMenuItem);
            fileMenu.DropDownItems.Add(saveMenuItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("E&xit", null, ExitMenuItem_Click);
            fileMenu.DropDownItems.Add(exitMenuItem);

            // Edit Menu
            ToolStripMenuItem editMenu = new ToolStripMenuItem("&Edit");
            ToolStripMenuItem undoMenuItem = new ToolStripMenuItem("&Undo", null, UndoMenuItem_Click);
            ToolStripMenuItem redoMenuItem = new ToolStripMenuItem("&Redo", null, RedoMenuItem_Click);
            editMenu.DropDownItems.Add(undoMenuItem);
            editMenu.DropDownItems.Add(redoMenuItem);
            editMenu.DropDownItems.Add(new ToolStripSeparator());
            ToolStripMenuItem cutMenuItem = new ToolStripMenuItem("Cu&t", null, CutMenuItem_Click);
            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("&Copy", null, CopyMenuItem_Click);
            ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("&Paste", null, PasteMenuItem_Click);
            editMenu.DropDownItems.Add(cutMenuItem);
            editMenu.DropDownItems.Add(copyMenuItem);
            editMenu.DropDownItems.Add(pasteMenuItem);

            // View Menu
            ToolStripMenuItem viewMenu = new ToolStripMenuItem("&View");
            ToolStripMenuItem refreshMenuItem = new ToolStripMenuItem("&Refresh", null, RefreshMenuItem_Click);
            ToolStripMenuItem zoomMenuItem = new ToolStripMenuItem("&Zoom");
            viewMenu.DropDownItems.Add(refreshMenuItem);
            viewMenu.DropDownItems.Add(new ToolStripSeparator());
            viewMenu.DropDownItems.Add(zoomMenuItem);

            // Help Menu
            ToolStripMenuItem helpMenu = new ToolStripMenuItem("&Help");
            ToolStripMenuItem aboutMenuItem = new ToolStripMenuItem("&About", null, AboutMenuItem_Click);
            ToolStripMenuItem helpTopicsMenuItem = new ToolStripMenuItem("&Help Topics", null, HelpTopicsMenuItem_Click);
            helpMenu.DropDownItems.Add(helpTopicsMenuItem);
            helpMenu.DropDownItems.Add(new ToolStripSeparator());
            helpMenu.DropDownItems.Add(aboutMenuItem);

            // Add menus to menu strip
            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(editMenu);
            menuStrip.Items.Add(viewMenu);
            menuStrip.Items.Add(helpMenu);

            // Create Homepage Content
            Label titleLabel = new Label();
            titleLabel.Text = "Welcome to My Windows Application";
            titleLabel.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold);
            titleLabel.Location = new System.Drawing.Point(50, 50);
            titleLabel.Size = new System.Drawing.Size(700, 40);
            titleLabel.ForeColor = System.Drawing.Color.DarkBlue;

            Label descriptionLabel = new Label();
            descriptionLabel.Text = "This is a sample Windows Forms application with a menu system.\n\n" +
                                   "Use the menu items above to navigate through different features.\n" +
                                   "• File: Create, Open, Save, and Exit operations\n" +
                                   "• Edit: Undo, Redo, Cut, Copy, and Paste operations\n" +
                                   "• View: View-related options like Refresh and Zoom\n" +
                                   "• Help: Access Help Topics and About information";
            descriptionLabel.Font = new System.Drawing.Font("Arial", 11);
            descriptionLabel.Location = new System.Drawing.Point(50, 120);
            descriptionLabel.Size = new System.Drawing.Size(700, 200);
            descriptionLabel.BackColor = System.Drawing.Color.White;
            descriptionLabel.BorderStyle = BorderStyle.FixedSingle;
            descriptionLabel.Padding = new Padding(10);

            // Add Button
            Button homeButton = new Button();
            homeButton.Text = "Go to Dashboard";
            homeButton.Location = new System.Drawing.Point(50, 350);
            homeButton.Size = new System.Drawing.Size(150, 40);
            homeButton.BackColor = System.Drawing.Color.LightBlue;
            homeButton.Click += HomeButton_Click;

            // Add controls to form
            this.Controls.Add(menuStrip);
            this.Controls.Add(titleLabel);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(homeButton);

            this.MainMenuStrip = menuStrip;
        }

        // File Menu Event Handlers
        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New file created.", "File Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Open file dialog would appear here.", "File Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("File saved successfully.", "File Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Edit Menu Event Handlers
        private void UndoMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Undo operation performed.", "Edit Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RedoMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Redo operation performed.", "Edit Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cut operation performed.", "Edit Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copy operation performed.", "Edit Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Paste operation performed.", "Edit Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // View Menu Event Handlers
        private void RefreshMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("View refreshed.", "View Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Help Menu Event Handlers
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My Windows Application v1.0\n\nA sample application demonstrating Windows Forms with menu system.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HelpTopicsMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help Topics:\n\n1. Getting Started\n2. Using the Menu\n3. Common Operations\n4. Troubleshooting", "Help Topics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Button Event Handler
        private void HomeButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigating to Dashboard...", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
