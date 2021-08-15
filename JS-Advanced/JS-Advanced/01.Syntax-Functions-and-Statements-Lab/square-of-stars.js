function solve(n = 5){
    let result = new Array(n);

    for(i = 0; i < n; i++){
        result[i] = '* '.repeat(n).trim();
    }

    console.log(result.join('\n'));
}