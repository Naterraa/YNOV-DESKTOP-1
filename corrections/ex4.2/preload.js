const { contextBridge, ipcRenderer } = require('electron');

contextBridge.exposeInMainWorld('api', {
    getTasks: () => ipcRenderer.invoke('get-tasks'),
    addTask: (name) => ipcRenderer.invoke('add-task', name),
    deleteTask: (id) => ipcRenderer.invoke('delete-task', id)
});
