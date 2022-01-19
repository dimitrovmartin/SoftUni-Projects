function solve(arr, rotates){
    
    for (let i = 0; i < rotates; i++) {
        
        let element = arr.pop();
        arr.unshift(element);
    }

    console.log(arr.join(' '));
}

solve(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15

)