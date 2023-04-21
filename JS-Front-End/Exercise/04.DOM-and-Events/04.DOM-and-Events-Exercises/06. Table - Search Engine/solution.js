function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const allTr = Array.from(document.querySelectorAll('tr'))
      const searchInput = document.getElementById('searchField')
      let searchText = searchInput.value.toLowerCase()

      for (const tr of allTr) {
         const allTd = Array.from(tr.getElementsByTagName('td'))
         for (const td of allTd) {
            td.parentNode.classList.remove('select')
         }
      }

      for (const tr of allTr) {
         const allTd = Array.from(tr.getElementsByTagName('td'))
         for (const td of allTd) {
            if (td.textContent.toLowerCase().includes(searchText)) {
               td.parentNode.classList.add('select')
               break
            }
         }

         searchInput.value=''
      }
   }
}