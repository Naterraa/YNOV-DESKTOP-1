const { app, BrowserWindow, ipcMain } = require('electron');
const path = require('node:path');
const Database = require('better-sqlite3');

const dbPath = path.join(__dirname, 'tasks.db');
const db = new Database(dbPath);

db.exec(`
  CREATE TABLE IF NOT EXISTS tasks (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
  )
`);

function getTasks() {
    try {
        const stmt = db.prepare('SELECT id, name FROM tasks');
        return stmt.all();
    } catch (err) {
        console.error('Error fetching tasks:', err);
        return [];
    }
}

function addTask(name) {
    try {
        const stmt = db.prepare('INSERT INTO tasks (name) VALUES (?)');
        const info = stmt.run(name);
        return {
            id: info.lastInsertRowid,
            name: name
        };
    } catch (err) {
        console.error('Error adding task:', err);
        return null;
    }
}

function deleteTask(id) {
    try {
        const stmt = db.prepare('DELETE FROM tasks WHERE id = ?');
        stmt.run(id);
        return true;
    } catch (err) {
        console.error('Error deleting task:', err);
        return false;
    }
}

function createWindow() {
    const win = new BrowserWindow({
        width: 800,
        height: 600,
        webPreferences: {
            preload: path.join(__dirname, 'preload.js')
        }
    });

    win.loadFile('index.html');
}

app.whenReady().then(() => {

    ipcMain.handle('get-tasks', () => {
        return getTasks();
    });

    ipcMain.handle('add-task', (event, name) => {
        return addTask(name);
    });

    ipcMain.handle('delete-task', (event, id) => {
        return deleteTask(id);
    });

    createWindow();

    app.on('activate', () => {
        if (BrowserWindow.getAllWindows().length === 0) {
            createWindow();
        }
    });
});

app.on('window-all-closed', () => {
    db.close();
    if (process.platform !== 'darwin') {
        app.quit();
    }
});
