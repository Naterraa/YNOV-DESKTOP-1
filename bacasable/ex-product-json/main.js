const { app, BrowserWindow, ipcMain } = require('electron');
const path = require('node:path');
const fs = require('node:fs');

const dataFile = path.join(__dirname, 'products.json');

// Si le json n'existe pas on le crée
if (!fs.existsSync(dataFile)) {
    fs.writeFileSync(dataFile, JSON.stringify([], null, 2));
}

function getProducts() {
    try {
        const data = fs.readFileSync(dataFile, 'utf8');
        return JSON.parse(data);
    } catch (err) {
        console.error('Error reading products:', err);
        return [];
    }
}

function saveProducts(products) {
    try {
        fs.writeFileSync(dataFile, JSON.stringify(products, null, 2));
    } catch (err) {
        console.error('Error saving products:', err);
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

    ipcMain.handle('get-products', () => {
        return getProducts();
    });

    ipcMain.handle('add-product', (event, name) => {
        const products = getProducts();
        const newProduct = {
            id: Date.now(), // pour l'id
            name: name
        };
        products.push(newProduct);
        saveProducts(products);
        return newProduct;
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
