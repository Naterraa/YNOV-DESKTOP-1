
// function getProducts() {
//     try {
//         const data = fs.readFileSync(dataFile, 'utf8');
//         return JSON.parse(data);
//     } catch (err) {
//         console.error('Error reading products:', err);
//         return [];
//     }
// }

// function saveProducts(products) {
//     try {
//         fs.writeFileSync(dataFile, JSON.stringify(products, null, 2));
//     } catch (err) {
//         console.error('Error saving products:', err);
//     }
// }