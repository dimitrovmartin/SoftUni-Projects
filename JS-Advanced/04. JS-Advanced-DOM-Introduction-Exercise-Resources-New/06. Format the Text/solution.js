function solve() {
  const text = document.getElementById('input').value.split('.').filter(e => e);
  const output = document.getElementById('output');

  generateParagraphs(text);
  function generateParagraphs(input) {
    const paragraph = [];

    while (input.length > 0){
      paragraph.push(input.splice(0, 3).join('.') + '.');
    }

    paragraph.forEach(p => (output.innerHTML += `<p>${p}</p>`));
  }
}