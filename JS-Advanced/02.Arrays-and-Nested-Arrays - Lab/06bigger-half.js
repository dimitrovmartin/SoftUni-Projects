function solve(arr){
    arr = arr.sort((a,b) => a-b).slice(Math.trunc(arr.length/2));

    return arr;
}

console.log(solve([4, 7, 2, 5]));