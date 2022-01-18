function solve(n, k) {
    resultArr = []

    for (let i = 0; i < n; i++) {
        if (resultArr.length === 0) {
            resultArr.push(1);
            continue;
        }

        result = 0;

        for (let j = 0; j < k; j++) {
            if (resultArr[i - j - 1] === undefined) {
                break;
            }

            result += resultArr[i - j - 1];
        }

        resultArr.push(result);
    }

    return resultArr
}

console.log(solve(8, 2));