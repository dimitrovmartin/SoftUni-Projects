function solve(n,k){
    let arr = [1];

    for (let i = 1; i < n; i++) {
        const element = i;
        
        let sum = 0;

        for (let j = 1; j <= k; j++) {
            if ((typeof(arr[i - j]) != "undefined")) {
                sum += arr[i - j];
            }
        }

        arr.push(sum);
    }

    return arr;
}