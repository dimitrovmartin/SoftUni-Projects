function solve(matrix) {
    let areRowsEqual = matrix.map(row => row.reduce((a, b) => a + b))
    .every((element, index,arr) => element === arr[0]);
    
    let areColsEqual = matrix.reduce((a, b) => a.map((element, index) => element + b[index]))
    .every((element, index,arr) => element === arr[0]);

    return areRowsEqual && areColsEqual;
}