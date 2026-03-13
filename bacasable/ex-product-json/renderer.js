const productList = document.getElementById('product-list');
const productNameInput = document.getElementById('product-name');
const addBtn = document.getElementById('add-btn');

// charger les produits
async function loadProducts() {
    productList.innerHTML = '';
    const products = await window.api.getProducts();

    products.forEach(product => {
        const li = document.createElement('li');
        li.textContent = `[ID: ${product.id}] ${product.name}`;
        productList.appendChild(li);
    });
}

// ajouter un produit
addBtn.addEventListener('click', async () => {
    const name = productNameInput.value.trim();
    if (name) {
        await window.api.addProduct(name);
        productNameInput.value = ''; // clear input
        loadProducts(); // refresh list
    }
});

// Chargement initial des produits
loadProducts();
