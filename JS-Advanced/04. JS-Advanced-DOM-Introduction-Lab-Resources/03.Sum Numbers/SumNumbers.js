function calc() {
    num1Element = document.getElementById('num1');
    num2Element = document.getElementById('num2');
    resultElement = document.getElementById('sum');

    num1 = Number(num1Element.value);
    num2 = Number(num2Element.value);

    resultElement.value = num1 + num2;
}
