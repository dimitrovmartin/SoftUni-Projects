function extractText() {
    let liElements = document.querySelectorAll('li');
    let textAreaElement = document.getElementById('result');
    
    Array.from(liElements).forEach(element => {
        textAreaElement.textContent += element.textContent + '\n';    
    });

    textAreaElement.textContent.trim();
}