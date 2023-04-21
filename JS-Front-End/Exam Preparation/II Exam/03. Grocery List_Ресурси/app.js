function solve(){
    const BASE_URL = 'http://localhost:3030/jsonstore/grocery/'

    let products = []
    let currentProduct = {}

    const inputDomElements = {
        product:document.getElementById('product'),
        count:document.getElementById('count'),
        price:document.getElementById('price')
    }

    const otherDomElements = {
        addProduct:document.getElementById('add-product'),
        updateProduct:document.getElementById('update-product'),
        loadProduct:document.getElementById('load-product'),
        tbody:document.getElementById('tbody')
    }

    otherDomElements.loadProduct.addEventListener('click',loadProductHandler)
    otherDomElements.addProduct.addEventListener('click',addProductHandler)
    otherDomElements.updateProduct.addEventListener('click',updateProductHandler)

    function updateProductHandler(){
        let id = currentProduct._id
        
        const htmHeader = {
            method:'PATCH',
            body:JSON.stringify({
                product:inputDomElements.product.value,
                count:inputDomElements.count.value,
                price:inputDomElements.price.value
            })
        }

        fetch(`${BASE_URL}${id}`,htmHeader)
        .then(()=>{
            for (const key in inputDomElements) {
                inputDomElements[key].value = ''
            }

            otherDomElements.updateProduct.setAttribute('disabled',true)
            otherDomElements.addProduct.removeAttribute('disabled')
            loadProductHandler()
        })
    }

    function addProductHandler(event){
        if(event){
            event.preventDefault()
        }

        let isEmptyField = Object.values(inputDomElements).find(x=>x.value==='')

        if(isEmptyField){
            return
        }

        const htmlHeader = {
            method:'POST',
            body:JSON.stringify({
                product:inputDomElements.product.value,
                count:inputDomElements.count.value,
                price:inputDomElements.price.value
            })
        }

        fetch(BASE_URL,htmlHeader)
        .then(()=>{
            for (const key in inputDomElements) {
                inputDomElements[key].value=''
            }
            loadProductHandler()
        })

    }

    function loadProductHandler(event){
        if(event){
            event.preventDefault()
        }

        otherDomElements.tbody.innerHTML=''

        fetch(BASE_URL)
        .then((res)=>res.json())
        .then((info)=>{
            products = Object.values(info)

            for (const currentProduct of products) {
                let {product,count,price,_id} = currentProduct

                let tr = createElement('tr','',otherDomElements.tbody,'',_id)
                createElement('td',product,tr,['name'])
                createElement('td',count,tr,['count-product'])
                createElement('td',price,tr,['product-price'])
                let td = createElement('td','',tr,['btn'])
                let updateBtn = createElement('button','Update',td,['update'])
                let deleteBtn = createElement('button','Delete',td,['delete'])

                updateBtn.addEventListener('click',editProductHandler)
                deleteBtn.addEventListener('click',deleteProductHandler)

            }
        })
    }

    function editProductHandler(){

        otherDomElements.addProduct.setAttribute('disabled',true)
        otherDomElements.updateProduct.removeAttribute('disabled')

        let id = this.parentNode.parentNode.id

        currentProduct = products.find(x=>x._id === id)

        for (const key in inputDomElements) {
            inputDomElements[key].value = currentProduct[key]
        }       
    }

    function deleteProductHandler(){
        let id = this.parentNode.parentNode.id

        const htmHeader = {
            method:'DELETE'
        }

        fetch(`${BASE_URL}${id}`,htmHeader)
        .then(()=>loadProductHandler())
    }

    function createElement(type, content, parentNode, classes, id, attributes, useInnerHtml) {
        const htmlElement = document.createElement(type);
      
        if (content && useInnerHtml) {
          htmlElement.innerHTML = content;
        } else {
          if (content && type !== 'input') {
            htmlElement.textContent = content;
          }
      
          if (content && type === 'input') {
            htmlElement.value = content;
          }
        }
      
        if (classes && classes.length > 0) {
          htmlElement.classList.add(...classes);
        }
      
        if (id) {
          htmlElement.id = id;
        }
      
        // { src: 'link', href: 'http' }
        if (attributes) {
          for (const key in attributes) {
            htmlElement.setAttribute(key, attributes[key])
          }
        }
      
        if (parentNode) {
          parentNode.appendChild(htmlElement);
        }
      
        return htmlElement;
    }
}

solve()