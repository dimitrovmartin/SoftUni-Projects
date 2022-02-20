function solve() {
   const output = document.querySelector('textarea');
   const cart = [];
 
   document.querySelector('.shopping-cart').addEventListener('click', (e) =>{
    if (e.target.tagName === 'BUTTON' && e.target.className === 'add-product') {
       const product = e.target.parentNode.parentNode;
       const title = product.querySelector('.product-title').textContent;
       const price = Number(product.querySelector('.product-line-price').textContent);
 
       cart.push({ title, price });
 
       output.value += `Added ${title} for ${price.toFixed(2)} to the cart.\n`;
    }
   });
 
   document.querySelector('.checkout').addEventListener('click', () => {
    const result = cart.reduce((acc,p) => {
 
       if (!acc.items.includes(p.title)) {
          acc.items.push(p.title);
       };
       acc.totalPrice += p.price;
 
       return acc;
    }, { items: [],totalPrice: 0});
 
    output.value += `You bought ${result.items.join(', ')} for ${result.totalPrice.toFixed(2)}.`
 
    disableAllButtons();
   });
 
    function disableAllButtons() {
       Array.from(document.getElementsByTagName('button')).forEach(b => b.disabled = true);
   }
 }