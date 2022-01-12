function solve(input){
    inputType = typeof input;
    
    if(inputType != 'number'){
        console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
    }
    else{
        area = Math.pow(input, 2) * Math.PI;

        console.log(area.toFixed(2));
    }
}

solve(5);