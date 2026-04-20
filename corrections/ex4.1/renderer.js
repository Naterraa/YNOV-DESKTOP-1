let tasks = [];

const taskInput = document.getElementById('taskInput');
const addBtn = document.getElementById('addBtn');
const taskList = document.getElementById('taskList');
const saveBtn = document.getElementById('saveBtn');
const statusMsg = document.getElementById('statusMsg');

// Charger les tâches au démarrage
async function loadTasks() {
    tasks = await window.api.getTasks();
    renderTasks();
}

function renderTasks() {
    taskList.innerHTML = '';
    tasks.forEach((task, index) => {
        const li = document.createElement('li');
        li.textContent = task;
        
        const deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Supprimer';
        deleteBtn.className = 'delete-btn';
        deleteBtn.onclick = () => {
            tasks.splice(index, 1);
            renderTasks();
        };

        li.appendChild(deleteBtn);
        taskList.appendChild(li);
    });
}

addBtn.addEventListener('click', () => {
    const text = taskInput.value.trim();
    if (text) {
        tasks.push(text);
        taskInput.value = '';
        renderTasks();
    }
});

// Permet d'ajouter une tâche avec la touche Entrée
taskInput.addEventListener('keypress', (e) => {
    if (e.key === 'Enter') {
        addBtn.click();
    }
});

saveBtn.addEventListener('click', async () => {
    const success = await window.api.saveTasks(tasks);
    if (success) {
        statusMsg.textContent = 'Tâches sauvegardées !';
        statusMsg.style.color = '#28a745';
        setTimeout(() => {
            statusMsg.textContent = '';
        }, 2000);
    } else {
        statusMsg.textContent = 'Erreur lors de la sauvegarde.';
        statusMsg.style.color = '#dc3545';
    }
});

// Appel initial
loadTasks();
