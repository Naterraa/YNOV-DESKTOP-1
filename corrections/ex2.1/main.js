const { app, BrowserWindow, ipcMain } = require('electron');
const path = require('node:path');
const fs = require('node:fs');
const os = require('node:os');

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
    // ipcMain.handle écoute l'appel, effectue la logique
    // et retourne une réponse asynchrone
    ipcMain.handle('save-text', async (event, text) => {
        const desktopPath = path.join(os.homedir(), 'Desktop');
        const filePath = path.join(desktopPath, 'sauvegarde.txt');

        fs.writeFileSync(filePath, text, 'utf-8');
        return filePath;
    });

    createWindow();
});

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') app.quit();
});
