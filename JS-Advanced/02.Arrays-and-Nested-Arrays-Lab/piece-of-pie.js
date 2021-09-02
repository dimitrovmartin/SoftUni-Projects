function solve(arr, start, end){
    let startIndex = arr.indexOf(start);
    let endIndex = arr.indexOf(end);

    return arr.slice(startIndex, endIndex + 1);
}