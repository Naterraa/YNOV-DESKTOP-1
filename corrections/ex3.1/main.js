const { app, BrowserWindow, ipcMain } = require('electron');
const path = require('node:path');

function createWindow() {
    const win = new BrowserWindow({
        width: 300,
        height: 200,
        frame: false,
        alwaysOnTop: true,
        transparent: true,
        webPreferences: {
            preload: path.join(__dirname, 'preload.js')
        }
    });

    win.loadFile('index.html');

    // Écoute de l'événement de fermeture provenant du renderer
    ipcMain.on('close-app', () => {
        win.close(); // Ferme spécifiquement la fenêtre
    });
}

app.whenReady().then(() => {
    createWindow();
});

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') app.quit();
});
