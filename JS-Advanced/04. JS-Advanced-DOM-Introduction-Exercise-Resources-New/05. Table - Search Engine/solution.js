function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   const rows = document.querySelectorAll('tbody tr');

   function onClick() {
      let input = document.querySelector('#searchField').value.toLowerCase();

      for (const row of rows) {
         if (row.textContent.toLowerCase().includes(input)) {
            row.setAttribute('class', 'select');
         }
         else
         {
            row.removeAttribute('class');
         }
      }
   }
}