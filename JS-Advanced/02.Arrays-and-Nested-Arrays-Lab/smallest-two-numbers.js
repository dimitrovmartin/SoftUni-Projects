function solve(arr){
    arr.sort((a,b) => a - b);

    return arr.slice(0,2).join(' ');
}