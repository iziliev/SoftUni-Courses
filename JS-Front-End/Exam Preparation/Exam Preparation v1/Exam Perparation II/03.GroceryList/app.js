function attachEvents(){
    const addProductBtn = document.getElementById('add-product');
    const updateProductBtn = document.getElementById('update-product');
    const loadProductsBtn = document.getElementById('load-product');
    const tbody = document.getElementById('tbody')
    const BASE_URL = 'http://localhost:3030/jsonstore/grocery/'

    let id = ''

    loadProductsBtn.addEventListener('click',loadAllProducts);
    addProductBtn.addEventListener('click',createNewProduct);
    updateProductBtn.addEventListener('click',updateInfo);

    function updateInfo(e){
            
            let productNameInput = document.getElementById('product');
            let productCountInput = document.getElementById('count');
            let productPriceInput = document.getElementById('price');

            
            product = productNameInput.value
            count = productCountInput.value
            price = productPriceInput.value
            
            const htmlHeader = {
                method:'PATCH',
                body:JSON.stringify({product,count,price})
            }

            fetch(BASE_URL+id,htmlHeader)
                .then((res)=>res.json())
                .then(()=>{
                    productNameInput.value = ''
                    productCountInput.value = ''
                    productPriceInput.value = ''
                    updateProductBtn.disabled = true
                    addProductBtn.disabled = false
                    loadAllProducts()
                })
                .catch((er)=>console.error(er))
    }

    function loadAllProducts(e){
        if(e){
            e.preventDefault();
        }       

        tbody.innerHTML='';

        fetch(BASE_URL)
            .then((res)=>res.json())
            .then((productInfo)=>{
                for (const key in productInfo) {
                    let {product,count,price,_id} = productInfo[key]
                    let tr = createElement('tr','',tbody,_id)
                    createElement('td',product,tr,'',['name'])
                    createElement('td',count,tr,'',['count-product'])
                    createElement('td',price,tr,'',['product-price'])
                    let td = createElement('td','',tr,'',['btn'])
                    const upBtn = createElement('button','Update',td,'',['update'])
                    const delBtn = createElement('button','Delete',td,'',['delete'])

                    delBtn.addEventListener('click',deleteItem)

                    upBtn.addEventListener('click',()=>{
                        id = _id
                        addProductBtn.disabled = true
                        updateProductBtn.disabled = false

                        let productNameInput = document.getElementById('product');
                        let productCountInput = document.getElementById('count');
                        let productPriceInput = document.getElementById('price');

                        productNameInput.value = product
                        productCountInput.value = count
                        productPriceInput.value = price
                    })
                }
            })
            .catch((er)=>console.error(er))
    }

    function deleteItem(e){
        let itemId = e.currentTarget.parentNode.parentNode.id

        const htmlHeader = {
            method:'DELETE'
        }
        
        fetch(BASE_URL+itemId,htmlHeader)
            .then((res)=>res.json())
            .then(()=>loadAllProducts())
            .catch((er)=>console.error(er))
    }

    function createNewProduct(e){

        if(e){
            e.preventDefault();
        }  

        const productNameInput = document.getElementById('product');
        const productCountInput = document.getElementById('count');
        const productPriceInput = document.getElementById('price');

        let product = productNameInput.value;
        let count = productCountInput.value;
        let price = productPriceInput.value;

        const htmlHeader = {
            method:'POST',
            body: JSON.stringify({product,count,price})
        }

        fetch(BASE_URL,htmlHeader)
            .then((res)=>res.json())
            .then(()=>{
                productNameInput.value=''
                productCountInput.value=''
                productPriceInput.value=''

                loadAllProducts()
            })
            .catch((er)=>console.error(er))
    }

    function createElement(type, content, parentNode, id, classes, attributes){

        const htmlElement = document.createElement(type)
    
        if(content && type !== 'input'){
          htmlElement.textContent = content
        }
    
        if(content && type !== 'textarea'){
            htmlElement.value = content
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

attachEvents()