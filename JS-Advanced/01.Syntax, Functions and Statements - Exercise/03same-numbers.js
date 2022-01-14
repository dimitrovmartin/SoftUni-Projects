function solve(number){
    numberAsString = number.toString();
    digitToCompare = numberAsString[0];

    isSame = true;
    result = Number(digitToCompare);


    for (let i = 1; i < numberAsString.length; i++) {
        currentDigit = numberAsString[i];
        
        if (digitToCompare !== currentDigit) {
            isSame = false;
        }

        result += Number(currentDigit);
    }

    console.log(isSame);
    console.log(result);
}