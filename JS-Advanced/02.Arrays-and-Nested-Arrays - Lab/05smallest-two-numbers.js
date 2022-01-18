function solve(arr){
    arr = arr.sort((a, b) => a - b).slice(0, 2);
    console.log(arr.join(' '));
}

solve([30, 15, 50, 5])