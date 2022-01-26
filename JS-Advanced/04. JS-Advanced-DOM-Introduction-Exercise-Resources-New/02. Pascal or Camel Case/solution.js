function solve() {
  let textElement = document.getElementById('text');
  let convetionElement = document.getElementById('naming-convention');
  let resultElement = document.getElementById('result');

  let convention = convetionElement.value;

  let lowerCaseText = textElement.value.toLowerCase();
  let pascalCaseText = lowerCaseText.split(' ').map(x => x[0].toUpperCase() + x.slice(1)).join('');
  let camelCaseText = pascalCaseText[0].toLowerCase() + pascalCaseText.slice(1);

  if (convention === 'Camel Case') {
    resultElement.textContent = camelCaseText;
  } else if (convention == 'Pascal Case'){
    resultElement.textContent = pascalCaseText;
  } else{
    resultElement.textContent = 'Error!';
  }
}