function solve() {
   const buttons = Array.from(document.querySelectorAll('button.add-product'))
   const result = document.getElementsByTagName('textarea')[0]
   let products = []
   let sum = 0

   const buyButton = document.getElementsByClassName('checkout')[0]

   buttons.forEach(x=>x.addEventListener('click',addProduct))
   buyButton.addEventListener('click',checkout)

   function addProduct(e){
      const parent = e.currentTarget.parentElement.parentElement
      const array = Array.from(parent.children)
      const productDetails = Array.from(array[1].children)
      const name = productDetails[0].textContent
      const price = array[3].textContent
      if(!products.includes(name)){
         products.push(name)
      }
      sum += Number(price)
      result.value+=`Added ${name} for ${Number(price).toFixed(2)} to the cart.\n`
   }

   function checkout(e){
      result.value+=`You bought ${products.join(', ')} for ${sum.toFixed(2)}.`

      buttons.forEach((x)=>{
         x.disabled = true
         return x
      })
      e.target.disabled = true
   }
}