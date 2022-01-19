function solve(matrix){

    let magicSum = matrix[0].reduce(
        (acc, current) => acc + current);

    for (let i = 0; i < matrix.length; i++){

        let rowSum = matrix[i].reduce(
            (acc, current) => acc + current);
        
        let colSum = 0;

        for (let j = 0; j < matrix.length; j++) {
            
            colSum += matrix[j][i];    
        }

        if (rowSum !== magicSum || colSum !== magicSum){
            console.log(false);
            return;
        }
    }

    console.log(true);
}

solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   );