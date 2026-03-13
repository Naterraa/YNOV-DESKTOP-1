const { app, BrowserWindow, ipcMain } = require('electron');
const path = require('node:path');
const Database = require('better-sqlite3');

// Initialisation de la base de données
const dbPath = path.join(__dirname, 'database.db');
const db = new Database(dbPath);

// Création de la table products si elle n'existe pas
db.exec(`
  CREATE TABLE IF NOT EXISTS products (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
  )
`);

function getProducts() {
    try {
        const stmt = db.prepare('SELECT id, name FROM products');
        return stmt.all();
    } catch (err) {
        console.error('Error fetching products from DB:', err);
        return [];
    }
}

function addProduct(name) {
    try {
        const stmt = db.prepare('INSERT INTO products (name) VALUES (?)');
        const info = stmt.run(name);
        return {
            id: info.lastInsertRowid,
            name: name
        };
    } catch (err) {
        console.error('Error adding product to DB:', err);
        return null; // Return null on error
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
        return addProduct(name);
    });

    createWindow();

    app.on('activate', () => {
        if (BrowserWindow.getAllWindows().length === 0) {
            createWindow();
        }
    });
});

app.on('window-all-closed', () => {
    db.close(); // fermer la connexion à la db
    if (process.platform !== 'darwin') {
        app.quit();
    }
});
