function solve() {
  let generateBtn = document.getElementsByTagName('button')[0];
  generateBtn.addEventListener('click',onClickGenerate);

  let buyBtn = document.getElementsByTagName('button')[1];
  buyBtn.addEventListener('click',onClickBuy);

  function onClickGenerate(event) {
    let input = document.getElementsByTagName('textarea')[0].value;
    let arr = JSON.parse(input);
    let table = document.querySelector('.table tbody');

    for (const obj of arr) {
      let newTr = document.createElement('tr');
      table.appendChild(newTr);

      let img = document.createElement('td');
      img.innerHTML = '<img src ="' + obj.img + '"/>';
      newTr.appendChild(img);

      let name = document.createElement('td');
      name.textContent = `${obj.name}`;
      newTr.appendChild(name);

      let price = document.createElement('td');
      price.textContent = `${obj.price}`;
      newTr.appendChild(price);
      
      let decFactor = document.createElement('td');
      decFactor.textContent = `${obj.decFactor}`;
      newTr.appendChild(decFactor);

      let mark = document.createElement('td');
      mark.innerHTML = '<input type="checkbox" />';
      newTr.appendChild(mark);
    }
  }

  function onClickBuy(event) {
    let checkboxes = Array.from(document.querySelectorAll('input[type="checkbox"]'));

    let names = [];
    let totalPrice = 0;
    let avgDecFactor = 0;

    for (const box of checkboxes) {
      let parent = box.parentNode.parentNode.getElementsByTagName('td');

      if (box.checked === true) {
        let name = parent[1].textContent;
        let price = Number(parent[2].textContent);
        let decFactor = Number(parent[3].textContent);

        names.push(name);
        totalPrice += price;
        avgDecFactor += decFactor;
      }
    }

    let result = `Bought furniture: ${names.join(', ')}\n`;

    result += `Total price: ${totalPrice.toFixed(2)}\n`;

    avgDecFactor /= names.length;

    result += `Average decoration factor: ${avgDecFactor}`;

    let ouput = document.getElementsByTagName('textarea')[1];

    ouput.textContent = result;

  }
}