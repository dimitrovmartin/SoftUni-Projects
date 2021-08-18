function solve(arr){
    let orderedArr = [];
    
    for (const number of arr) {
        if (number >= 0) {
            orderedArr.push(number);
        }else{
            orderedArr.unshift(number);
        }
    }

    for (const number of orderedArr) {
        console.log(number);
    }
}

solve([7, -2, 8, 9]);