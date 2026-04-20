const { contextBridge, ipcRenderer } = require('electron');

contextBridge.exposeInMainWorld('api', {
    // Permet au renderer de demander la fermeture
    closeApp: () => ipcRenderer.send('close-app')
});
