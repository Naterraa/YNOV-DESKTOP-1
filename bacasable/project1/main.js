const { app, BrowserWindow, ipcMain } = require('electron');
const path = require('node:path');

function createWindow() {
    const win = new BrowserWindow({
        width: 1000,
        height: 700,
        minHeight: 400,
        minWidth: 600,
        backgroundColor: "#609edcff",
        webPreferences: {
            preload: path.join(__dirname, 'preload.js')
        }
    })
    win.loadFile('index.html');
}
app.whenReady().then(() => {
    ipcMain.on('message-to-main', (event, message) => {
        console.log(message);
    });
    createWindow();
});

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') app.quit();
});