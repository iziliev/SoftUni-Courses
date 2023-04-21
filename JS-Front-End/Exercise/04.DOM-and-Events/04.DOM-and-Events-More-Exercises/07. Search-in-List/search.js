function search() {
   const searchTextInput = document.getElementById('searchText')
   const searchText = searchTextInput.value
   const searchParent = Array.from(document.getElementById('towns').children)

   searchParent.forEach((x)=>
      x.style = 'font-weight: none; text-decoration: none;'
   )

   let countFoundItems = searchParent.filter(x=>x.textContent.includes(searchText))
   
   if(countFoundItems.length>0){
      for (const item of countFoundItems) {
         item.style = 'font-weight: bold; text-decoration: underline;'
      }
   }

   const result = document.getElementById('result')
   result.textContent = `${countFoundItems.length} matches found`

   searchTextInput.value = ''
}
