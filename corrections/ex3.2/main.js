const { app, BrowserWindow, Tray, Menu } = require('electron');
const path = require('node:path');

let win;
let tray = null;

function createWindow() {
    win = new BrowserWindow({
        width: 400,
        height: 400,
    });

    win.loadFile('index.html');

    win.on('close', (event) => {
        event.preventDefault();
        win.hide();
    });
}

function createTray() {
    tray = new Tray(path.join(__dirname, 'Capture.JPG'));
    tray.setToolTip('Mon appli cachée !');
    const contextMenu = Menu.buildFromTemplate([
        {
            label: 'Afficher le Widget',
            click: () => {
                win.show();
            }
        },
        { type: 'separator' },
        {
            label: 'Quitter définitivement',
            click: () => {
                // Pour quitter, il faut détruire l'instance Tray et dire à l'app de quitter de force
                tray.destroy();
                app.exit();
            }
        }
    ]);

    tray.setContextMenu(contextMenu);

    // Au clic gauche sur l'icône du Tray (surtout utile sur Windows)
    tray.on('click', () => {
        if (win.isVisible()) {
            win.hide();
        } else {
            win.show();
        }
    });
}

app.whenReady().then(() => {
    createWindow();
    createTray();
});

// Avec ce fonctionnement de Tray, on ignore cet évènement puisqu'on veut survivre sans fenêtre
// app.on('window-all-closed', () => { ... }) n'est plus utile ici.
