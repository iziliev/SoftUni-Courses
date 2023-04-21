function create(words) {
   const parentDiv = document.getElementById('content')
   for (const word of words) {
      const div = document.createElement('div')
      const p = document.createElement('p')
      p.textContent = word
      p.style.display = 'none'
      div.appendChild(p)
      parentDiv.appendChild(div)
   }

   const divs = Array.from(parentDiv.children)

   for (const div of divs) {
      div.addEventListener('click',function(){
         div.firstChild.style = ''
      })
   }
}