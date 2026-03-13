const { app, BrowserWindow, ipcMain, Menu, Tray, nativeImage, dialog } = require('electron');
const path = require('node:path');

function createWindow() {
    const win = new BrowserWindow({
        width: 1000,
        height: 700,
        minHeight: 400,
        minWidth: 600,
        // frame: false,
        alwaysOnTop: true,
        backgroundColor: "#609edc",
        webPreferences: {
            preload: path.join(__dirname, 'preload.js')
        }
    })

    const templateMenu = [
        {
            label: 'Fichier',
            submenu: [
                {
                    label: 'Quitter',
                    accelerator: process.platform === 'darwin' ? 'Cmd+Q' : 'Ctrl+Q',
                    click: () => { app.quit() }
                }
            ]
        },
        {
            label: 'Aide',
            submenu: [
                {
                    label: 'A propos',
                    click: () => { console.log('Clic sur A Propos'); }
                }
            ]
        }
    ];

    const menu = Menu.buildFromTemplate(templateMenu);
    Menu.setApplicationMenu(menu);

    const contextMenu = Menu.buildFromTemplate([
        { label: 'Option 1', click: () => { console.log('Option 1 cliquée via clic droit'); } },
        { type: 'separator' },
        { role: 'reload', label: 'Recharger' }
    ]);

    win.webContents.on('context-menu', (event, params) => {
        contextMenu.popup({
            window: win,
            x: params.x,
            y: params.y
        });
    });

    win.loadFile('index.html');
}

app.whenReady().then(() => {

    const iconPath = path.join(__dirname, 'Capture.JPG');
    tray = new Tray(iconPath);

    ipcMain.on('message-to-main', (event, message) => {
        console.log(message);
    });
    createWindow();
    // afficherDialog();
    // choisirFichier();
    // saveFile();
});

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') app.quit();
});


async function afficherDialog() {
    const { response } = await dialog.showMessageBox({
        title: 'info',
        message: 'Ceci est un message',
        buttons: ['OK', 'Annuler']
    });
    console.log(response);
}

async function choisirFichier() {
    const { filePaths } = await dialog.showOpenDialog({
        title: 'Choisir un fichier',
        properties: ['openFile']
    });
    console.log(filePaths);
}

async function saveFile() {
    const { filePath } = await dialog.showSaveDialog({
        title: 'Enregistrer un fichier',
        properties: ['openFile']
    });
    console.log(filePath);
}