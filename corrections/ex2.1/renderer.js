const btn = document.getElementById('save-btn');
const input = document.getElementById('text-input');
const statusText = document.getElementById('status-text');

btn.addEventListener('click', async () => {
    const text = input.value;

    // Attente de la réponse retournée par le processus principal (chemin du fichier)
    const filePath = await window.api.saveText(text);

    statusText.innerText = `Texte sauvegardé avec succès ! Emplacement : ${filePath}`;
});
