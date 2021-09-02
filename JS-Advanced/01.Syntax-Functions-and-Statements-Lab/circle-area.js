function solve(number){
    let type = typeof(number);
    let result;

    if(type === 'number'){
        result = Math.pow(number, 2) * Math.PI;

        console.log(result.toFixed(2));
    }else{
        console.log(`We can not calculate the circle area, because we receive a ${type}.`);
    }
}