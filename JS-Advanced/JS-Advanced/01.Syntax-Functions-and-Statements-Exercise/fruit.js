function solve(fruit, grams, money){
    let weight = grams / 1000;
    let moneyNeeded = weight * money;

    console.log(`I need $${moneyNeeded.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}

solve('apple', 1563, 2.35);