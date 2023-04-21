function solve() {
	  const [ generatedTextArea, buyTextArea] = Array.from(document.getElementsByTagName('textarea'))
    const [ generateBtn, buyBtn] = Array.from(document.getElementsByTagName('button'))
    const tbody = document.querySelector('.table > tbody')
	
	  generateBtn.addEventListener('click',generateHandler)
    buyBtn.addEventListener('click',buyHandler)
	
	  function generateHandler(){
		const data = JSON.parse(generatedTextArea.value)
		for(const {img,name,price,decFactor} of data){
			const tableRow = createElement('tr','',tbody)

			const firstColumnTd = createElement('td','',tableRow)
			createElement('img','',firstColumnTd,'','',{src:img})

      const secondColumnTd = createElement('td','',tableRow)
			createElement('p',name,secondColumnTd)

      const thirdColumnTd = createElement('td','',tableRow)
			createElement('p',price,thirdColumnTd)

      const fourthColumnTd = createElement('td','',tableRow)
			createElement('p',decFactor,fourthColumnTd)

      const fifthColumnTd = createElement('td','',tableRow)
			createElement('input','',fifthColumnTd,'','',{type:'checkbox'})
		}
	  }

    function buyHandler(){
    const allCheckedBox = Array.from(document.querySelectorAll('tbody tr input:checked'))
    let products = []
    let allSum = 0
    let decFactorSum = 0

    for (const box of allCheckedBox) {
        const tableRow = box.parentElement.parentElement
        const [_firstCol,secondCol,thirdCol,fourCol] = Array.from(tableRow.children)
        products.push(secondCol.children[0].textContent)
        allSum += Number(thirdCol.children[0].textContent)
        decFactorSum += Number(fourCol.children[0].textContent)
    }

    buyTextArea.value += `Bought furniture: ${products.join(', ')}\n`
    buyTextArea.value += `Total price: ${allSum.toFixed(2)}\n`
    buyTextArea.value += `Average decoration factor: ${(decFactorSum/products.length)}`
    }
		
    function createElement(type, content, parentNode, id, classes, attributes){
  const htmlElement = document.createElement(type)

  if(content && type !== 'input'){
    htmlElement.textContent = content
  }

  if(content && type === 'input'){
    htmlElement.value = content
  }

  if(id){
    htmlElement.id = id
  }

  if(parentNode){
    parentNode.appendChild(htmlElement)
  }

  if(classes){
    htmlElement.classList.add(...classes)
  }

  if(attributes){
    for (const key in attributes) {
      htmlElement.setAttribute(key,attributes[key])
    }
  }

  return htmlElement
    }
}