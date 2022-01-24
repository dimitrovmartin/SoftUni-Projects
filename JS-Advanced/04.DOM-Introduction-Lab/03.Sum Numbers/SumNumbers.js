function calc() {
    let firstNum = document.getElementById('num1');
    let secondNum = document.getElementById('num2');
    let sum = document.getElementById('sum');

    sum.value = Number(firstNum.value) + Number(secondNum.value);
}
