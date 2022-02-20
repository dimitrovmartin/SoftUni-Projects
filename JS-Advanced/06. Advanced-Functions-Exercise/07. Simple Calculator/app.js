function calculator() {
    let firstNum;
    let secondNum;
    let resultToAdd;

    return {
        init: (selector1,selector2,result) => {
            firstNum = document.querySelector(selector1);
            secondNum = document.querySelector(selector2);
            resultToAdd = document.querySelector(result);

        },
        add: () => {
            resultToAdd.value = Number(firstNum.value) + Number(secondNum.value);
            firstNum.value = '';
            secondNum.value = '';
        },
        subtract: () => {
            resultToAdd.value = Number(firstNum.value) - Number(secondNum.value);
            firstNum.value = '';
            secondNum.value = '';
        }
    }
}