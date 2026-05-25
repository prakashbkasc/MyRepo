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
            newMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem("&Open", null, OpenMenuItem_Click);
            openMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("&Save", null, SaveMenuItem_Click);
            saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            ToolStripMenuItem saveAsMenuItem = new ToolStripMenuItem("Save &As", null, SaveAsMenuItem_Click);
            fileMenu.DropDownItems.Add(newMenuItem);
            fileMenu.DropDownItems.Add(openMenuItem);
            fileMenu.DropDownItems.Add(saveMenuItem);
            fileMenu.DropDownItems.Add(saveAsMenuItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("E&xit", null, ExitMenuItem_Click);
            exitMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            fileMenu.DropDownItems.Add(exitMenuItem);

            // Edit Menu
            ToolStripMenuItem editMenu = new ToolStripMenuItem("&Edit");
            ToolStripMenuItem undoMenuItem = new ToolStripMenuItem("&Undo", null, UndoMenuItem_Click);
            undoMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            ToolStripMenuItem redoMenuItem = new ToolStripMenuItem("&Redo", null, RedoMenuItem_Click);
            redoMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            editMenu.DropDownItems.Add(undoMenuItem);
            editMenu.DropDownItems.Add(redoMenuItem);
            editMenu.DropDownItems.Add(new ToolStripSeparator());
            ToolStripMenuItem cutMenuItem = new ToolStripMenuItem("Cu&t", null, CutMenuItem_Click);
            cutMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("&Copy", null, CopyMenuItem_Click);
            copyMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("&Paste", null, PasteMenuItem_Click);
            pasteMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            ToolStripMenuItem selectAllMenuItem = new ToolStripMenuItem("Select &All", null, SelectAllMenuItem_Click);
            selectAllMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            editMenu.DropDownItems.Add(cutMenuItem);
            editMenu.DropDownItems.Add(copyMenuItem);
            editMenu.DropDownItems.Add(pasteMenuItem);
            editMenu.DropDownItems.Add(new ToolStripSeparator());
            editMenu.DropDownItems.Add(selectAllMenuItem);

            // View Menu
            ToolStripMenuItem viewMenu = new ToolStripMenuItem("&View");
            ToolStripMenuItem refreshMenuItem = new ToolStripMenuItem("&Refresh", null, RefreshMenuItem_Click);
            refreshMenuItem.ShortcutKeys = Keys.F5;
            ToolStripMenuItem zoomMenuItem = new ToolStripMenuItem("&Zoom");
            ToolStripMenuItem zoomInMenuItem = new ToolStripMenuItem("Zoom &In", null, ZoomInMenuItem_Click);
            zoomInMenuItem.ShortcutKeys = Keys.Control | Keys.Add;
            ToolStripMenuItem zoomOutMenuItem = new ToolStripMenuItem("Zoom &Out", null, ZoomOutMenuItem_Click);
            zoomOutMenuItem.ShortcutKeys = Keys.Control | Keys.Subtract;
            ToolStripMenuItem zoomResetMenuItem = new ToolStripMenuItem("&Reset Zoom", null, ZoomResetMenuItem_Click);
            zoomResetMenuItem.ShortcutKeys = Keys.Control | Keys.D0;
            zoomMenuItem.DropDownItems.Add(zoomInMenuItem);
            zoomMenuItem.DropDownItems.Add(zoomOutMenuItem);
            zoomMenuItem.DropDownItems.Add(zoomResetMenuItem);
            viewMenu.DropDownItems.Add(refreshMenuItem);
            viewMenu.DropDownItems.Add(new ToolStripSeparator());
            viewMenu.DropDownItems.Add(zoomMenuItem);

            // Help Menu
            ToolStripMenuItem helpMenu = new ToolStripMenuItem("&Help");
            ToolStripMenuItem helpTopicsMenuItem = new ToolStripMenuItem("&Help Topics", null, HelpTopicsMenuItem_Click);
            helpTopicsMenuItem.ShortcutKeys = Keys.F1;
            ToolStripMenuItem aboutMenuItem = new ToolStripMenuItem("&About", null, AboutMenuItem_Click);
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
            descriptionLabel.Text = "This is a sample Windows Forms application with an enhanced menu system.\n\n" +
                                   "Use the menu items above to navigate through different features.\n" +
                                   "• File: Create, Open, Save, Save As, and Exit operations\n" +
                                   "• Edit: Undo, Redo, Cut, Copy, Paste, and Select All operations\n" +
                                   "• View: View-related options with Zoom In, Out, and Reset\n" +
                                   "• Help: Access Help Topics and About information\n\n" +
                                   "💡 Tip: Use keyboard shortcuts for faster navigation!";
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
            MessageBox.Show("New file created (Ctrl+N).", "File Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Open file dialog would appear here (Ctrl+O).", "File Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("File saved successfully (Ctrl+S).", "File Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save As dialog would appear here.", "File Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MessageBox.Show("Undo operation performed (Ctrl+Z).", "Edit Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RedoMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Redo operation performed (Ctrl+Y).", "Edit Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cut operation performed (Ctrl+X).", "Edit Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copy operation performed (Ctrl+C).", "Edit Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Paste operation performed (Ctrl+V).", "Edit Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SelectAllMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select All operation performed (Ctrl+A).", "Edit Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // View Menu Event Handlers
        private void RefreshMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("View refreshed (F5).", "View Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ZoomInMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zoomed In (Ctrl++).", "View Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ZoomOutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zoomed Out (Ctrl+-).", "View Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ZoomResetMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zoom reset to 100% (Ctrl+0).", "View Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Help Menu Event Handlers
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My Windows Application v2.0\n\nA sample application demonstrating Windows Forms with an enhanced menu system.\n\nVersion: 2.0\nAuthor: Your Name\n© 2026", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HelpTopicsMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help Topics (F1):\n\n1. Getting Started\n2. Using the Menu System\n3. Keyboard Shortcuts\n4. Common Operations\n5. Troubleshooting\n6. Contact Support", "Help Topics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Button Event Handler
        private void HomeButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigating to Dashboard...", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
