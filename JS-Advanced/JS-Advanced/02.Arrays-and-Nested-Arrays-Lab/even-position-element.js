function solve(arr){
    let result = '';

    for (let index = 0; index < arr.length; index += 2) {
        const element = arr[index];
        
        result += element + " ";
    }

    return result;
}

console.log(solve(['20', '30', '40', '50', '60']));