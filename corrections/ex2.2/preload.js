const { contextBridge, ipcRenderer } = require('electron');

contextBridge.exposeInMainWorld('api', {
    // Expose une fonction permettant au renderer de définir 
    // comment gérer l'événement 'update-ram' venant du main
    onUpdateRam: (callback) => ipcRenderer.on('update-ram', (event, data) => callback(data))
});
