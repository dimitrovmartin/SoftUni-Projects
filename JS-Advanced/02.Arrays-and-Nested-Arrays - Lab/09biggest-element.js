function solve(matrix){

    biggestElement = Number.MIN_VALUE;

    matrix.forEach((x)=> x.forEach(function(y){
         if (y > biggestElement){
            biggestElement = y;
        }
    }))

    return biggestElement;
}

console.log(solve([[20, 50, 10],
    [8, 33, 145]]
   ));
