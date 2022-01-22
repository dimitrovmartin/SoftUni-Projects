function solve(arr){
    
    let productsByCalories = {};

    for (i = 0; i < arr.length; i += 2){

        let product = arr[i];
        let calories = Number(arr[i + 1]);

        productsByCalories[product] = calories;
    }

    console.log(productsByCalories);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52'])