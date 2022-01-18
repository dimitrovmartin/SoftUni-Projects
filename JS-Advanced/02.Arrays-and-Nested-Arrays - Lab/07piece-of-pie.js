function solve(arr, firstTarget, secondTarget){
    firstIndex = arr.indexOf(firstTarget);
    secondIndex = arr.indexOf(secondTarget);

    arr = arr.slice(firstIndex, secondIndex + 1);

    return arr;
}

console.log(solve(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
));