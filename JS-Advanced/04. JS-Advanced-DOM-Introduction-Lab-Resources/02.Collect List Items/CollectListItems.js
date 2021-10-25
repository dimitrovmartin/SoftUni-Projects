function extractText() {
    let listElements = document.getElementsByTagName('li');
    let arrayElements = Array.from(listElements);
    let textareaElement = document.getElementById('result');
    
    let result = ''

    for (const element of arrayElements) {
        result += element.textContent + '\n';
    }

    textareaElement.textContent = result.trim();
}