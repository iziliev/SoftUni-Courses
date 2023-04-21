function attachEvents(){

    const BASE_URL = 'http://localhost:3030/jsonstore/grocery/'

    const inputDomSelectors = {
        product: document.getElementById('product'),
        count: document.getElementById('count'),
        price: document.getElementById('price')
    } 

    const otherDomSelectors = {
        body: document.getElementById('tbody'),
        addBtn : document.getElementById('add-product'),
        updateBtn : document.getElementById('update-product'),
        loadBtn : document.getElementById('load-product')
    }

    let allProducts = []
    let currentProduct = {}

    otherDomSelectors.loadBtn.addEventListener('click',loadProductsHandler)
    otherDomSelectors.addBtn.addEventListener('click',addProductHandler)
    otherDomSelectors.updateBtn.addEventListener('click',updateProductHandler)

    function updateProductHandler(){
      event.preventDefault();
      const {product,count,price} = inputDomSelectors

      const body = {
        product:product.value,
        price:price.value,
        count:count.value
      }

      const htmlHeader = {
        method:'PATCH',
        body:JSON.stringify(body)
      }

      fetch(`${BASE_URL}${currentProduct._id}`,htmlHeader)
        .then(()=>{
          loadProductsHandler()
          for (const key in inputDomSelectors) {
            inputDomSelectors[key].value=''
          }
        })

        otherDomSelectors.addBtn.removeAttribute('disabled',)
        otherDomSelectors.updateBtn.setAttribute('disabled',true)
    }

    function addProductHandler(event){
      event.preventDefault();
      let body = {
        product:inputDomSelectors.product.value,
        count:inputDomSelectors.count.value,
        price:inputDomSelectors.price.value
      }

      const htmlHeader = {
        method:'POST',
        body:JSON.stringify(body)
      }

      fetch(BASE_URL,htmlHeader)
        .then(()=>{
          loadProductsHandler()
          for (const key in inputDomSelectors) {
            inputDomSelectors[key].value = ''
          }
        })

    }

    function loadProductsHandler(event){

        if(event){
            event.preventDefault()
        }

        otherDomSelectors.body.innerHTML=''

        fetch(BASE_URL)
            .then((res=>res.json()))
            .then((productInfo)=>{
                allProducts = Object.values(productInfo)
                for (const { product, count, price, _id } of allProducts) {
                    const tr = createElement('tr',null,otherDomSelectors.body,null,_id)
                    createElement('td',product,tr,['name'])
                    createElement('td',count,tr,['count-product'])
                    createElement('td',price,tr,['product-price'])

                    const td = createElement('td',null,tr,['btn'])
                    const btnUpdate = createElement('button','Update',td,['update'])
                    const btnDelete = createElement('button','Delete',td,['delete'])


                    btnDelete.addEventListener('click',deleteProductHandler)
                    btnUpdate.addEventListener('click',updateFormProductHandler)

                }
            })
    }

    function updateFormProductHandler(event){
      event.preventDefault()
      const id = this.parentNode.parentNode.id
      currentProduct = allProducts.find(x=>x._id === id)

      for (const key in inputDomSelectors) {
        inputDomSelectors[key].value = currentProduct[key]
      }

      otherDomSelectors.addBtn.setAttribute('disabled',true)
      otherDomSelectors.updateBtn.removeAttribute('disabled')

    }

    function deleteProductHandler(){
      const id = this.parentNode.parentNode.id
      
      const htmlHeaders = {
        method:'DELETE'
      }

      fetch(`${BASE_URL}${id}`,htmlHeaders)
        .then(()=>loadProductsHandler())
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

attachEvents()