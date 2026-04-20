const btnClose = document.getElementById('btn-close');

btnClose.addEventListener('click', () => {
    // Envoie la demande de fermeture au Main Process
    window.api.closeApp();
});
