function solve(arr){
    let result = [];
    
    for (let index = 1; index < arr.length; index += 2) {
        const element = arr[index];
        
        result.push(element * 2);
    }

    result.reverse();

    return result.join(' ');
}