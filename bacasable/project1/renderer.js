const btn = document.getElementById('action-btn');
const statusText = document.getElementById('status-text');

btn.addEventListener('click', () => {
    statusText.innerText = "Message envoyé ! Regardez le terminal du processus principal.";
    window.toto.sendMessage("Bonjour depuis le moteur de rendu !");
});
