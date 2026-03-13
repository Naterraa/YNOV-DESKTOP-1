const progressBar = document.getElementById('ram-progress');
const statusText = document.getElementById('status-text');

// Le callback appelé à chaque fois que le renderer reçoit un événement depuis le Main
window.api.onUpdateRam((data) => {
    progressBar.value = data.usedPercent;
    statusText.innerText = `RAM utilisée : ${Math.round(data.usedPercent)}% (Libre : ${Math.round(data.freePercent)}%)`;
});
