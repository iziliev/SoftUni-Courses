// TODO
function attachEvents() {
  const BASE_URL = 'http://localhost:3030/jsonstore/tasks/'

  let products = []

  const inputDomElements = {
    title:document.getElementById('title')
  }

  const otherDomElements = {
    addBtn:document.getElementById('add-button'),
    loadBtn:document.getElementById('load-button'),
    todoList:document.getElementById('todo-list')
  }

  otherDomElements.loadBtn.addEventListener('click',loadItems)
  otherDomElements.addBtn.addEventListener('click',addItem)

  function addItem(event){
    if(event){
        event.preventDefault()
    }

    if(inputDomElements.title.value === ''){
        return
    }

    const htmlHeader = {
        method:'POST',
        body:JSON.stringify({name:inputDomElements.title.value})
    }

    fetch(BASE_URL,htmlHeader)
    .then(()=>{
        inputDomElements.title.value=''
        loadItems()
    })
  }

  function loadItems(event){
    
    if(event){
        event.preventDefault()
    }

    otherDomElements.todoList.innerHTML=''
    
    fetch(BASE_URL)
    .then((res)=>res.json())
    .then((info)=>{
        products = Object.values(info)
        for (const product of products) {
            let {name,_id} = product

            let li = createElement('li','',otherDomElements.todoList,'',_id)
            createElement('span',name,li)
            let removeBtn = createElement('button','Remove',li)
            let editBtn = createElement('button','Edit',li)

            editBtn.addEventListener('click',editItem)
            removeBtn.addEventListener('click',removeItem)
        }
    })

  }

  function editItem(){
    let id = this.parentNode.id
    let li = document.getElementById(id)

    li.innerHTML=''

    let product = products.find(x=>x._id === id)

    let input = createElement('input',product.name,li)
    let removeBtn = createElement('button','Remove',li)
    let submitBtn = createElement('button','Submit',li)

    removeBtn.addEventListener('click',removeItem)
    submitBtn.addEventListener('click',()=>{
        const htmlHeaders = {
            method:'PATCH',
            body:JSON.stringify({name:input.value})
        }

        fetch(`${BASE_URL}${id}`,htmlHeaders)
        .then(()=>loadItems())
    })
  }

  function removeItem(){
    let id = this.parentNode.id
    const htmlHeader = {
        method:'DELETE'
    }

    fetch(`${BASE_URL}${id}`,htmlHeader)
    .then(()=>loadItems())

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

attachEvents();
