function solve(products){
    let catalogue = {};

    for (const productData of products) {
        let [productName, productPrice] = productData.split(' : ');
        let firstLetter = productName[0];
        productPrice = Number(productPrice);

        if (!Object.keys(catalogue).includes(firstLetter)){
            catalogue[firstLetter] = [];
        }

        catalogue[firstLetter].push({
            name: productName,
            price: productPrice,
        });
    }

    for (const letter of Object.entries(catalogue).sort((a,b)=> a[0].localeCompare(b[0]))) {
        console.log(letter[0]);
        letter[1].sort((a,b)=> a.name.localeCompare(b.name)).forEach(element => {
            console.log(` ${element.name}: ${element.price}`);
        });
    }
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
)