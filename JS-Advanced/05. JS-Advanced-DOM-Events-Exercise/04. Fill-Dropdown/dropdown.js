function addItem() {
    let newItemText = document.getElementById('newItemText');
    let newItemValue = document.getElementById('newItemValue');


    let newOptionElement = document.createElement('option');
    newOptionElement.textContent = newItemText.value;
    newOptionElement.value = newItemValue.value;

    document.getElementById('menu').appendChild(newOptionElement);

    newItemText.value = '';
    newItemValue.value = '';
}