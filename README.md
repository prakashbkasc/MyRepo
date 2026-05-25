# Windows Application with Menu System

A C# Windows Forms application demonstrating a complete menu structure with a homepage.

## Features

### Menu System
- **File Menu**
  - New: Create a new file
  - Open: Open an existing file
  - Save: Save the current file
  - Exit: Close the application

- **Edit Menu**
  - Undo: Undo the last action
  - Redo: Redo the last undone action
  - Cut: Cut selected content
  - Copy: Copy selected content
  - Paste: Paste copied content

- **View Menu**
  - Refresh: Refresh the current view
  - Zoom: Adjust zoom level

- **Help Menu**
  - Help Topics: Access help documentation
  - About: View application information

### Homepage
- Welcome message with application title
- Information about available features
- Navigation button to dashboard
- Clean and user-friendly interface

## Prerequisites

- .NET Framework 4.7.2 or higher
- Visual Studio 2019 or later (or any C# IDE)
- Windows operating system

## How to Build and Run

1. **Build the Project:**
   ```bash
   dotnet build
   ```

2. **Run the Application:**
   ```bash
   dotnet run
   ```

   Or open `WindowsApplication.csproj` in Visual Studio and press `F5` to run.

## Project Structure

```
├── MainForm.cs              # Main application form with menu and homepage
├── Program.cs               # Application entry point
├── WindowsApplication.csproj # Project configuration file
├── App.config               # Application settings
└── README.md                # This file
```

## Menu Item Descriptions

### File Menu Operations
- **New**: Initializes a new document/project
- **Open**: Opens a file dialog to select and open files
- **Save**: Saves the current work
- **Exit**: Safely closes the application with confirmation

### Edit Menu Operations
- **Undo/Redo**: Navigate through action history
- **Cut/Copy/Paste**: Standard clipboard operations

### View Menu Operations
- **Refresh**: Reloads and updates the current view
- **Zoom**: Adjusts the display zoom level

### Help Menu Operations
- **Help Topics**: Provides user documentation
- **About**: Displays application version and information

## Customization

You can customize the application by:

1. **Changing the Title**: Modify `this.Text = "My Windows Application";` in `MainForm.cs`
2. **Adding New Menu Items**: Add `ToolStripMenuItem` objects to the respective menus
3. **Modifying Colors**: Change the `BackColor` and `ForeColor` properties
4. **Adding New Forms**: Create additional form classes and navigate to them from menu items
5. **Implementing Menu Logic**: Replace `MessageBox.Show()` calls with actual functionality

## Event Handlers

Each menu item has an associated event handler that responds to clicks. You can expand these handlers to implement actual functionality for your application.

## License

This project is provided as a sample application.

## Author

Created for prakashbkasc/MyRepo
