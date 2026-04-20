const { app, BrowserWindow, ipcMain } = require('electron');
const path = require('node:path');
const sqlite3 = require('sqlite3');

const dbPath = path.join(__dirname, 'tasks.db');
const db = new sqlite3.Database(dbPath);

db.exec(`
  CREATE TABLE IF NOT EXISTS tasks (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
  )
`);

function getTasks() {
    return new Promise((resolve) => {
        db.all('SELECT id, name FROM tasks', [], (err, rows) => {
            if (err) {
                console.error('Error fetching tasks:', err);
                resolve([]);
            } else {
                resolve(rows);
            }
        });
    });
}

function addTask(name) {
    return new Promise((resolve) => {
        db.run('INSERT INTO tasks (name) VALUES (?)', [name], function(err) {
            if (err) {
                console.error('Error adding task:', err);
                resolve(null);
            } else {
                resolve({
                    id: this.lastID,
                    name: name
                });
            }
        });
    });
}

function deleteTask(id) {
    return new Promise((resolve) => {
        db.run('DELETE FROM tasks WHERE id = ?', [id], function(err) {
            if (err) {
                console.error('Error deleting task:', err);
                resolve(false);
            } else {
                resolve(true);
            }
        });
    });
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
    if (process.platform !== 'darwin') {
        app.quit();
    }
    db.close();
});
