const productList = document.getElementById('product-list');
const productNameInput = document.getElementById('product-name');
const addBtn = document.getElementById('add-btn');

async function loadProducts() {
    productList.innerHTML = '';
    const products = await window.api.getProducts();

    products.forEach(product => {
        const li = document.createElement('li');
        li.textContent = `[ID: ${product.id}] ${product.name}`;
        productList.appendChild(li);
    });
}

addBtn.addEventListener('click', async () => {
    const name = productNameInput.value.trim();
    if (name) {
        const result = await window.api.addProduct(name);
        if (result) {
            productNameInput.value = '';
            loadProducts();
        } else {
            alert('Error adding product');
        }
    }
});

loadProducts();
