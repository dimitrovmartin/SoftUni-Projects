function solve(arr){
    let firstNum = Number(arr[0]);
    let lastNum = Number(arr[arr.length - 1]);

    sum = firstNum + lastNum;

    return sum;
}

console.log(solve(['20', '30', '40']))