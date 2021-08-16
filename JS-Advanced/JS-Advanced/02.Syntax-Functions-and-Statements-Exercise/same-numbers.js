function solve(number){
    let numberToString = String(number);
    let sum = Number(numberToString[0]);
    let isSame = true;

    for (let index = 0; index < numberToString.length - 1; index++) {
        const element = numberToString[index];
        const nextElement = numberToString[index + 1];

        if (element !== nextElement) {
            isSame = false;
        }

        sum += Number(nextElement);
    }

    console.log(isSame);
    console.log(sum);
}

solve(1234);