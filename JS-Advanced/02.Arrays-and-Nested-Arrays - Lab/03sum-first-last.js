function solve(arr){
    if (arr.length === 1){
        return arr[0];
    }

    result = Number(arr.shift()) + Number(arr.pop());

    return result;
}

console.log(solve(['20','30', '40']));