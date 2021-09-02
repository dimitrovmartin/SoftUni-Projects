function solve(matrix){
    let firstDiagonalSum = 0;
    let secondDiagonalSum = 0;
    let secondDiagonalIndex = matrix[0].length - 1;

    for(i = 0; i < matrix.length; i++){
        firstDiagonalSum += matrix[i][i];
        secondDiagonalSum += matrix[i][secondDiagonalIndex];

        secondDiagonalIndex--;
    }

    return firstDiagonalSum + ' ' + secondDiagonalSum;
}