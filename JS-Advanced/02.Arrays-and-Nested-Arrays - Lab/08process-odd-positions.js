function solve(arr){
    arr = arr.filter((x, i) => i % 2 != 0).map((x)=> x * 2).reverse();

    return arr.join(' ');
}

console.log(solve([10, 15, 20, 25]))