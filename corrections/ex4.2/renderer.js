const taskInput = document.getElementById('taskInput');
const addBtn = document.getElementById('addBtn');
const taskList = document.getElementById('taskList');

// Charger les tâches au démarrage
async function loadTasks() {
    const tasks = await window.api.getTasks();
    renderTasks(tasks);
}

function renderTasks(tasks) {
    taskList.innerHTML = '';
    tasks.forEach(task => {
        const li = document.createElement('li');
        li.textContent = task.name;
        
        const deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Supprimer';
        deleteBtn.className = 'delete-btn';
        deleteBtn.onclick = async () => {
            const success = await window.api.deleteTask(task.id);
            if (success) {
                loadTasks();
            }
        };

        li.appendChild(deleteBtn);
        taskList.appendChild(li);
    });
}

addBtn.addEventListener('click', async () => {
    const text = taskInput.value.trim();
    if (text) {
        const newTask = await window.api.addTask(text);
        if (newTask) {
            taskInput.value = '';
            loadTasks();
        }
    }
});

taskInput.addEventListener('keypress', (e) => {
    if (e.key === 'Enter') {
        addBtn.click();
    }
});

// Appel initial
loadTasks();
