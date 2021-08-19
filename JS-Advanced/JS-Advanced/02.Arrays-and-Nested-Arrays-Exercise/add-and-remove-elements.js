function solve(commands){
    let initialNumber = 1;
    let arr = [];

    for (const command of commands) {
        if (command === 'add') {
            arr.push(initialNumber);
        }else if (command === 'remove'){
            if (arr.length > 0) {
                arr.pop();
            }
        }

        initialNumber++;
    }

    if (arr.length > 0) {
        for (const number of arr) {
            console.log(number);
        }
    }else{
        console.log('Empty');
    }
}