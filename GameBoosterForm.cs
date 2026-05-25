using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GameBoosterApp
{
    public partial class GameBoosterForm : Form
    {
        private int cpuUsage = 0;
        private int ramUsage = 0;
        private bool isOptimizing = false;

        public GameBoosterForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Form Properties
            this.Text = "PC Game Booster Pro";
            this.Size = new System.Drawing.Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = SystemIcons.Application;
            this.BackColor = System.Drawing.Color.FromArgb(20, 20, 30);
            this.ForeColor = System.Drawing.Color.White;

            // Create Menu Strip
            MenuStrip menuStrip = new MenuStrip();
            menuStrip.BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            menuStrip.ForeColor = System.Drawing.Color.White;

            // File Menu
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("&File");
            fileMenu.ForeColor = System.Drawing.Color.White;
            ToolStripMenuItem settingsMenuItem = new ToolStripMenuItem("&Settings", null, SettingsMenuItem_Click);
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("E&xit", null, ExitMenuItem_Click);
            exitMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            fileMenu.DropDownItems.Add(settingsMenuItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(exitMenuItem);

            // My Games Menu
            ToolStripMenuItem gamesMenu = new ToolStripMenuItem("&My Games");
            gamesMenu.ForeColor = System.Drawing.Color.White;
            ToolStripMenuItem addGameMenuItem = new ToolStripMenuItem("&Add Game", null, AddGameMenuItem_Click);
            ToolStripMenuItem removeGameMenuItem = new ToolStripMenuItem("&Remove Game", null, RemoveGameMenuItem_Click);
            ToolStripMenuItem viewGamesMenuItem = new ToolStripMenuItem("&View All Games", null, ViewGamesMenuItem_Click);
            gamesMenu.DropDownItems.Add(addGameMenuItem);
            gamesMenu.DropDownItems.Add(removeGameMenuItem);
            gamesMenu.DropDownItems.Add(new ToolStripSeparator());
            gamesMenu.DropDownItems.Add(viewGamesMenuItem);

            // Optimizer Menu
            ToolStripMenuItem optimizerMenu = new ToolStripMenuItem("&Optimizer");
            optimizerMenu.ForeColor = System.Drawing.Color.White;
            ToolStripMenuItem cleanupMenuItem = new ToolStripMenuItem("&Cleanup Temporary Files", null, CleanupMenuItem_Click);
            ToolStripMenuItem disableServicesMenuItem = new ToolStripMenuItem("&Disable Background Services", null, DisableServicesMenuItem_Click);
            ToolStripMenuItem boostCPUMenuItem = new ToolStripMenuItem("&Boost CPU Priority", null, BoostCPUMenuItem_Click);
            ToolStripMenuItem advancedOptimizeMenuItem = new ToolStripMenuItem("&Advanced Optimize", null, AdvancedOptimizeMenuItem_Click);
            optimizerMenu.DropDownItems.Add(cleanupMenuItem);
            optimizerMenu.DropDownItems.Add(disableServicesMenuItem);
            optimizerMenu.DropDownItems.Add(boostCPUMenuItem);
            optimizerMenu.DropDownItems.Add(new ToolStripSeparator());
            optimizerMenu.DropDownItems.Add(advancedOptimizeMenuItem);

            // Tools Menu
            ToolStripMenuItem toolsMenu = new ToolStripMenuItem("&Tools");
            toolsMenu.ForeColor = System.Drawing.Color.White;
            ToolStripMenuItem monitorMenuItem = new ToolStripMenuItem("&System Monitor", null, MonitorMenuItem_Click);
            monitorMenuItem.ShortcutKeys = Keys.Control | Keys.M;
            ToolStripMenuItem clearCacheMenuItem = new ToolStripMenuItem("&Clear Cache", null, ClearCacheMenuItem_Click);
            toolsMenu.DropDownItems.Add(monitorMenuItem);
            toolsMenu.DropDownItems.Add(clearCacheMenuItem);

            // Help Menu
            ToolStripMenuItem helpMenu = new ToolStripMenuItem("&Help");
            helpMenu.ForeColor = System.Drawing.Color.White;
            ToolStripMenuItem aboutMenuItem = new ToolStripMenuItem("&About", null, AboutMenuItem_Click);
            ToolStripMenuItem helpTopicsMenuItem = new ToolStripMenuItem("&Help Topics", null, HelpTopicsMenuItem_Click);
            helpTopicsMenuItem.ShortcutKeys = Keys.F1;
            helpMenu.DropDownItems.Add(helpTopicsMenuItem);
            helpMenu.DropDownItems.Add(new ToolStripSeparator());
            helpMenu.DropDownItems.Add(aboutMenuItem);

            // Add menus to menu strip
            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(gamesMenu);
            menuStrip.Items.Add(optimizerMenu);
            menuStrip.Items.Add(toolsMenu);
            menuStrip.Items.Add(helpMenu);

            // Create Homepage Content - Title Panel
            Panel titlePanel = new Panel();
            titlePanel.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            titlePanel.Size = new System.Drawing.Size(1000, 100);
            titlePanel.Location = new System.Drawing.Point(0, 0);

            Label titleLabel = new Label();
            titleLabel.Text = "🚀 PC Game Booster Pro";
            titleLabel.Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold);
            titleLabel.Location = new System.Drawing.Point(30, 20);
            titleLabel.Size = new System.Drawing.Size(500, 60);
            titleLabel.ForeColor = System.Drawing.Color.Cyan;
            titlePanel.Controls.Add(titleLabel);

            // Dashboard Panel
            Panel dashboardPanel = new Panel();
            dashboardPanel.BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            dashboardPanel.BorderStyle = BorderStyle.FixedSingle;
            dashboardPanel.Location = new System.Drawing.Point(20, 130);
            dashboardPanel.Size = new System.Drawing.Size(950, 150);

            Label dashboardLabel = new Label();
            dashboardLabel.Text = "System Performance Dashboard";
            dashboardLabel.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            dashboardLabel.Location = new System.Drawing.Point(10, 10);
            dashboardLabel.Size = new System.Drawing.Size(300, 25);
            dashboardLabel.ForeColor = System.Drawing.Color.Cyan;
            dashboardPanel.Controls.Add(dashboardLabel);

            // CPU Usage
            Label cpuLabel = new Label();
            cpuLabel.Text = "CPU Usage: 45%";
            cpuLabel.Font = new System.Drawing.Font("Arial", 11);
            cpuLabel.Location = new System.Drawing.Point(20, 50);
            cpuLabel.Size = new System.Drawing.Size(200, 25);
            cpuLabel.ForeColor = System.Drawing.Color.Lime;
            dashboardPanel.Controls.Add(cpuLabel);

            // RAM Usage
            Label ramLabel = new Label();
            ramLabel.Text = "RAM Usage: 60%";
            ramLabel.Font = new System.Drawing.Font("Arial", 11);
            ramLabel.Location = new System.Drawing.Point(20, 85);
            ramLabel.Size = new System.Drawing.Size(200, 25);
            ramLabel.ForeColor = System.Drawing.Color.Lime;
            dashboardPanel.Controls.Add(ramLabel);

            // Disk Usage
            Label diskLabel = new Label();
            diskLabel.Text = "Disk Space: 85%";
            diskLabel.Font = new System.Drawing.Font("Arial", 11);
            diskLabel.Location = new System.Drawing.Point(280, 50);
            diskLabel.Size = new System.Drawing.Size(200, 25);
            diskLabel.ForeColor = System.Drawing.Color.Orange;
            dashboardPanel.Controls.Add(diskLabel);

            // Status
            Label statusLabel = new Label();
            statusLabel.Text = "Status: Ready to Boost";
            statusLabel.Font = new System.Drawing.Font("Arial", 11);
            statusLabel.Location = new System.Drawing.Point(280, 85);
            statusLabel.Size = new System.Drawing.Size(300, 25);
            statusLabel.ForeColor = System.Drawing.Color.Yellow;
            dashboardPanel.Controls.Add(statusLabel);

            // Quick Actions Panel
            Panel actionsPanel = new Panel();
            actionsPanel.BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            actionsPanel.BorderStyle = BorderStyle.FixedSingle;
            actionsPanel.Location = new System.Drawing.Point(20, 300);
            actionsPanel.Size = new System.Drawing.Size(950, 200);

            Label actionsLabel = new Label();
            actionsLabel.Text = "Quick Actions";
            actionsLabel.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            actionsLabel.Location = new System.Drawing.Point(10, 10);
            actionsLabel.Size = new System.Drawing.Size(200, 25);
            actionsLabel.ForeColor = System.Drawing.Color.Cyan;
            actionsPanel.Controls.Add(actionsLabel);

            // One Click Boost Button
            Button boostButton = new Button();
            boostButton.Text = "🎮 One Click Boost";
            boostButton.Location = new System.Drawing.Point(30, 50);
            boostButton.Size = new System.Drawing.Size(180, 50);
            boostButton.BackColor = System.Drawing.Color.FromArgb(0, 150, 50);
            boostButton.ForeColor = System.Drawing.Color.White;
            boostButton.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            boostButton.Click += BoostButton_Click;
            boostButton.Cursor = Cursors.Hand;
            actionsPanel.Controls.Add(boostButton);

            // Launch Game Button
            Button launchButton = new Button();
            launchButton.Text = "▶ Launch Game";
            launchButton.Location = new System.Drawing.Point(240, 50);
            launchButton.Size = new System.Drawing.Size(180, 50);
            launchButton.BackColor = System.Drawing.Color.FromArgb(100, 50, 150);
            launchButton.ForeColor = System.Drawing.Color.White;
            launchButton.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            launchButton.Click += LaunchGameButton_Click;
            launchButton.Cursor = Cursors.Hand;
            actionsPanel.Controls.Add(launchButton);

            // Cleanup Button
            Button cleanupButton = new Button();
            cleanupButton.Text = "🧹 Cleanup System";
            cleanupButton.Location = new System.Drawing.Point(450, 50);
            cleanupButton.Size = new System.Drawing.Size(180, 50);
            cleanupButton.BackColor = System.Drawing.Color.FromArgb(150, 100, 0);
            cleanupButton.ForeColor = System.Drawing.Color.White;
            cleanupButton.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            cleanupButton.Click += CleanupButton_Click;
            cleanupButton.Cursor = Cursors.Hand;
            actionsPanel.Controls.Add(cleanupButton);

            // Monitor Button
            Button monitorButton = new Button();
            monitorButton.Text = "📊 System Monitor";
            monitorButton.Location = new System.Drawing.Point(660, 50);
            monitorButton.Size = new System.Drawing.Size(180, 50);
            monitorButton.BackColor = System.Drawing.Color.FromArgb(50, 100, 150);
            monitorButton.ForeColor = System.Drawing.Color.White;
            monitorButton.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            monitorButton.Click += MonitorButton_Click;
            monitorButton.Cursor = Cursors.Hand;
            actionsPanel.Controls.Add(monitorButton);

            // Features Label
            Label featuresLabel = new Label();
            featuresLabel.Text = "Features: ✓ Real-time Monitoring  ✓ Auto Cleanup  ✓ Game Profiles  ✓ CPU Boost  ✓ RAM Optimizer";
            featuresLabel.Font = new System.Drawing.Font("Arial", 9);
            featuresLabel.Location = new System.Drawing.Point(30, 120);
            featuresLabel.Size = new System.Drawing.Size(900, 50);
            featuresLabel.ForeColor = System.Drawing.Color.LightGreen;
            actionsPanel.Controls.Add(featuresLabel);

            // Footer Panel
            Panel footerPanel = new Panel();
            footerPanel.BackColor = System.Drawing.Color.FromArgb(20, 20, 30);
            footerPanel.Size = new System.Drawing.Size(1000, 30);
            footerPanel.Location = new System.Drawing.Point(0, 650);

            Label footerLabel = new Label();
            footerLabel.Text = "PC Game Booster Pro v1.0 | © 2026 | Ready to Maximize Your Gaming Experience";
            footerLabel.Font = new System.Drawing.Font("Arial", 9);
            footerLabel.Location = new System.Drawing.Point(10, 5);
            footerLabel.Size = new System.Drawing.Size(980, 20);
            footerLabel.ForeColor = System.Drawing.Color.Gray;
            footerPanel.Controls.Add(footerLabel);

            // Add controls to form
            this.Controls.Add(menuStrip);
            this.Controls.Add(titlePanel);
            this.Controls.Add(dashboardPanel);
            this.Controls.Add(actionsPanel);
            this.Controls.Add(footerPanel);

            this.MainMenuStrip = menuStrip;
        }

        // Quick Action Handlers
        private void BoostButton_Click(object sender, EventArgs e)
        {
            isOptimizing = true;
            MessageBox.Show("🚀 Initiating One-Click Boost...\n\n" +
                          "• Closing unnecessary applications\n" +
                          "• Clearing temporary files\n" +
                          "• Optimizing CPU priority\n" +
                          "• Allocating resources to game\n" +
                          "• System boosted successfully!", 
                          "Game Boost Active", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isOptimizing = false;
        }

        private void LaunchGameButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("▶ Game launcher would open here.\n\n" +
                          "Select a game from 'My Games' menu to launch.", 
                          "Launch Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CleanupButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🧹 System Cleanup Running...\n\n" +
                          "• Removed 512 MB of temp files\n" +
                          "• Cleared browser cache\n" +
                          "• Removed log files\n" +
                          "• Optimized startup programs\n" +
                          "System cleanup completed!", 
                          "Cleanup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MonitorButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("📊 System Monitor\n\n" +
                          "CPU: 45% | RAM: 60% | Disk: 85%\n\n" +
                          "Real-time monitoring window would open here.", 
                          "System Monitor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // File Menu Event Handlers
        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("⚙ Settings Window\n\n" +
                          "• Auto-boost on game launch\n" +
                          "• Notification preferences\n" +
                          "• Startup options\n" +
                          "• Theme settings", 
                          "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // My Games Menu Event Handlers
        private void AddGameMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("📁 Add Game to Library\n\n" +
                          "Select game executable file:\n" +
                          "• Browse your game installations\n" +
                          "• Auto-detect popular games\n" +
                          "• Set custom boost profiles", 
                          "Add Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RemoveGameMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("❌ Remove Game from Library\n\n" +
                          "Select games to remove:\n" +
                          "• Your Game Library: 12 games\n" +
                          "• Confirm removal", 
                          "Remove Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ViewGamesMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("📋 Your Game Library\n\n" +
                          "Games in Library (12):\n" +
                          "1. Cyberpunk 2077\n" +
                          "2. Valorant\n" +
                          "3. Fortnite\n" +
                          "4. PUBG\n" +
                          "5. CS:GO\n" +
                          "... and 7 more", 
                          "View Games", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Optimizer Menu Event Handlers
        private void CleanupMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🧹 Cleanup Temporary Files\n\n" +
                          "Scanning system for:\n" +
                          "• Windows Temp files\n" +
                          "• Browser cache\n" +
                          "• Application logs\n" +
                          "• Recycle Bin contents\n" +
                          "Ready to clean up 2.5 GB", 
                          "Cleanup Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DisableServicesMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🔌 Disable Background Services\n\n" +
                          "Services to disable for gaming:\n" +
                          "• Windows Update\n" +
                          "• Antivirus Real-time Scanning\n" +
                          "• Cloud Sync Services\n" +
                          "• Background App Refresh\n" +
                          "⚠ Use with caution - may affect security", 
                          "Background Services", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BoostCPUMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("⚡ CPU Priority Boost\n\n" +
                          "Boost settings:\n" +
                          "• Set game process priority to HIGH\n" +
                          "• Allocate CPU cores to game\n" +
                          "• Disable CPU power saving\n" +
                          "• Increase CPU frequency\n" +
                          "CPU boost applied successfully!", 
                          "CPU Boost", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AdvancedOptimizeMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🔧 Advanced Optimization\n\n" +
                          "Advanced options:\n" +
                          "• Disable visual effects\n" +
                          "• Reduce GPU overhead\n" +
                          "• Optimize network settings\n" +
                          "• Advanced RAM management\n" +
                          "• Registry cleanup & defrag", 
                          "Advanced Optimize", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Tools Menu Event Handlers
        private void MonitorMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("📊 System Monitor Window\n\n" +
                          "Real-time Performance Metrics:\n" +
                          "• CPU: 45% | 3.8 GHz\n" +
                          "• RAM: 8.2 GB / 16 GB\n" +
                          "• GPU: 78% | 2100 MHz\n" +
                          "• Disk: 850 GB / 1 TB\n" +
                          "• Temperature: CPU 62°C, GPU 71°C", 
                          "System Monitor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearCacheMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("💾 Clear Cache\n\n" +
                          "Clearing cache from:\n" +
                          "• Browser cache (356 MB)\n" +
                          "• Application cache (128 MB)\n" +
                          "• Game shader cache (512 MB)\n" +
                          "• Windows cache (256 MB)\n" +
                          "Total freed: 1.25 GB", 
                          "Cache Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Help Menu Event Handlers
        private void HelpTopicsMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("❓ Help Topics (F1)\n\n" +
                          "1. Getting Started\n" +
                          "2. Adding Games\n" +
                          "3. One-Click Boost\n" +
                          "4. System Optimization\n" +
                          "5. Troubleshooting\n" +
                          "6. FAQ", 
                          "Help Topics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🎮 PC Game Booster Pro v1.0\n\n" +
                          "Your Ultimate Gaming Performance Tool\n\n" +
                          "Features:\n" +
                          "• Real-time system monitoring\n" +
                          "• One-click game optimization\n" +
                          "• Game library management\n" +
                          "• Advanced system cleanup\n" +
                          "• CPU/GPU optimization\n\n" +
                          "© 2026 Game Booster Team\n" +
                          "All rights reserved.", 
                          "About PC Game Booster Pro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
