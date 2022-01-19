function solve(arr){
    
    let resultArr = [];

    for(let i=0; i<arr.length; i++){
        
        if (arr[i] == 'add'){
            resultArr.push(i + 1);
        } else{
            resultArr.pop();
        }
    }

    if (resultArr.length == 0){
        console.log('Empty');
    } else{
        console.log(resultArr.join('\n'));
    }
}