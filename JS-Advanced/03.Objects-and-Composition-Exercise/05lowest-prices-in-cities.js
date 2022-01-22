function solve(productsData){
    let cheapestProducts = {};

    for (const productData of productsData) {
        let [town, product, price] = productData.split(' | ');
        price = Number(price);
        
        if (Object.keys(cheapestProducts).includes(product)){
            if (cheapestProducts[product]['price'] > price){
                cheapestProducts[product]['price'] = price;
                cheapestProducts[product]['town'] = town;
            }
        } else{
            cheapestProducts[product] = {town, price}
        }
    }
    
    for (const key in cheapestProducts) {
        console.log(`${key} -> ${cheapestProducts[key]['price']} (${cheapestProducts[key]['town']})`)
    }
}
console.log(solve(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
));