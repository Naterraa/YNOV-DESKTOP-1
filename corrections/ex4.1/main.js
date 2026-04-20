const { app, BrowserWindow, ipcMain } = require('electron');
const path = require('node:path');
const fs = require('node:fs/promises');

const dataFile = path.join(__dirname, 'data.json');

// Assure que le fichier existe, sinon on le crée avec un tableau vide
async function initDataFile() {
    try {
        await fs.access(dataFile);
    } catch (e) {
        await fs.writeFile(dataFile, '[]', 'utf8');
    }
}

async function getTasks() {
    try {
        const data = await fs.readFile(dataFile, 'utf8');
        return JSON.parse(data);
    } catch (err) {
        console.error('Error reading data.json:', err);
        return [];
    }
}

async function saveTasks(tasks) {
    try {
        await fs.writeFile(dataFile, JSON.stringify(tasks, null, 2), 'utf8');
        return true;
    } catch (err) {
        console.error('Error writing data.json:', err);
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

app.whenReady().then(async () => {
    await initDataFile();

    ipcMain.handle('get-tasks', async () => {
        return await getTasks();
    });

    ipcMain.handle('save-tasks', async (event, tasks) => {
        return await saveTasks(tasks);
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
});
