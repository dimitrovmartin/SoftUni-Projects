function create(words) {
   for (const word of words) {
      let div = document.createElement('div');

      let paragraph = document.createElement('p');

      paragraph.style.display = 'none';
      paragraph.textContent = word;

      div.appendChild(paragraph);
      div.addEventListener('click', onClick);

      document.getElementById('content').appendChild(div);

   }

   function onClick(e) {
      e.target.getElementsByTagName('p')[0].style.display = '';
   }
}