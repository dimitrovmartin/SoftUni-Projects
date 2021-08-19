function solve(arr){
    arr.sort((a,b) => {
        return a - b
    });
    let newArr = [];

    while (arr.length > 0) {
        newArr.push(arr.shift());
        
        if (arr.length > 0) {
            newArr.push(arr.pop());
        }
    }

    return newArr;
}