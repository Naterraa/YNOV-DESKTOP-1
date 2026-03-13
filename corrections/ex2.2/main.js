const { app, BrowserWindow, Notification } = require('electron');
const os = require('node:os');
const path = require('node:path');

let win;

function createWindow() {
    win = new BrowserWindow({
        width: 800,
        height: 600,
        webPreferences: {
            preload: path.join(__dirname, 'preload.js')
        }
    });

    win.loadFile('index.html');
}

app.whenReady().then(() => {
    createWindow();

    setInterval(() => {
        const totalMem = os.totalmem();
        const freeMem = os.freemem();
        const freePercent = (freeMem / totalMem) * 100;
        const usedPercent = 100 - freePercent;

        if (win) {
            // win.webContents.send() = envoie des données au renderer
            win.webContents.send('update-ram', {
                usedPercent: usedPercent,
                freePercent: freePercent
            });
        }

        // Notification native de l'OS lorsque la RAM dispo est < 20%
        if (freePercent < 20) {
            new Notification({
                title: 'Alerte RAM',
                body: 'Attention, la RAM libre est passée sous la barre des 20% !'
            }).show();
        }
    }, 1000);
});

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') app.quit();
});
