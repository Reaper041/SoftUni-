function search() {
   let townsElements = document.querySelectorAll('#towns li');
   let text = document.querySelector('#searchText').value;
   let matches = 0;

   for (let index = 0; index < townsElements.length; index++) {
      if (townsElements[index].textContent.includes(text)) {
         townsElements[index].style.fontWeight = "bold";
         townsElements[index].style.textDecoration = "underline";
         matches++;
      }      
   }

   let resultElement = document.getElementById('result');

   resultElement.textContent = `${matches} matches found`;
}
