function solve(num1, num2, operator){
    operations = {
        '+': (a,b) => a + b,
        '-': (a,b) => a - b,
        '*': (a,b) => a * b,
        '/': (a,b) => a / b,
        '%': (a,b) => a % b,
        '**': (a,b) => a ** b,
    };

    console.log(operations[operator](num1, num2));
}