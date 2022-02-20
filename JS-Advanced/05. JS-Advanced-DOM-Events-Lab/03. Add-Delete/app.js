function addItem() {
    let newItemTextElementElement = document.getElementById('newItemText');
    let itemsElement = document.getElementById('items');

    let lilItemElement = document.createElement('li');
    lilItemElement.textContent = newItemTextElementElement.value;

    let deleteButton = document.createElement('a');
    deleteButton.setAttribute('href', '#');
    deleteButton.textContent = '[Delete]';

    deleteButton.addEventListener('click', (e) => {
        console.log('delete clicked');
        e.currentTarget.parentNode.remove();
    });

    lilItemElement.appendChild(deleteButton);
    itemsElement.appendChild(lilItemElement);
    newItemTextElementElement.value = '';
}