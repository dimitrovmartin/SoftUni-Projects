function search() {
   let liElements = document.querySelectorAll('#towns > li');
   let searchedText = document.querySelector('#searchText').value;
   let resultElement = document.querySelector('#result');

   let counter = 0;

   for (const li of liElements) {
      if (li.textContent.includes(searchedText)){
         counter++;

         li.style.textDecoration = 'underline';
         li.style.fontWeight = 'bold';
      }
      else{
         li.style.textDecoration = 'none';
         li.style.fontWeight = 'none';
      }
   }

   resultElement.textContent = `${counter} matches found`
}
