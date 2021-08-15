function solve(arr){

    function aggregate(arr, initVal, func){
        let result = initVal;

        for(let i = 0; i < arr.length; i++){
            result = func(result, arr[i]);
        }

        return result;
    }

    let sum = aggregate(arr, 0, (a, b) => a + b);
    let inverseSum = aggregate(arr, 0, (a, b) => a + 1/b);
    let concat = aggregate(arr, '', (a, b) => a + b);

    console.log(sum);
    console.log(inverseSum);
    console.log(concat);
}