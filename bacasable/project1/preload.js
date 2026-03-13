const { contextBridge, ipcRenderer } = require('electron');

contextBridge.exposeInMainWorld('toto', {
    sendMessage: (message) => ipcRenderer.send('message-to-main', message)
});
