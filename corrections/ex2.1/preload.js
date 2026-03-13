const { contextBridge, ipcRenderer } = require('electron');

contextBridge.exposeInMainWorld('api', {
    // ipcRenderer.invoke envoie le texte au main process et attend une réponse de sa part
    saveText: (text) => ipcRenderer.invoke('save-text', text)
});
