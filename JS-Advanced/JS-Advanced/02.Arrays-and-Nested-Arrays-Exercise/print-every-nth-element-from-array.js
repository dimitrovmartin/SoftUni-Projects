function solve(arr, n){
    let filteredArr = arr.filter((number,index) => index % n == 0);

    return filteredArr;
}