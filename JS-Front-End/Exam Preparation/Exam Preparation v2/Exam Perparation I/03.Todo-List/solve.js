function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/tasks/'

    let items = []

    const inputDomSelectors = {
        name:document.getElementById('title')
    }

    const otherDomSelectors = {
        addBtn:document.getElementById('add-button'),
        loadBtn:document.getElementById('load-button'),
        list:document.getElementById('todo-list')
    }

    otherDomSelectors.loadBtn.addEventListener('click',loadItemHandler)
    otherDomSelectors.addBtn.addEventListener('click',addItemHandler)
    
    function addItemHandler(event){
        if(event){
            event.preventDefault()
        }
        let name = inputDomSelectors.name.value
        const htmlHeader = {
            method:'POST',
            body: JSON.stringify({name})
        }

        fetch(BASE_URL,htmlHeader)
        .then((res)=>res.json())
        .then(()=>{
            loadItemHandler()})

        inputDomSelectors.name.value=''
    }

    function loadItemHandler(event){
        if (event){
            event.preventDefault()
        }

        otherDomSelectors.list.innerHTML=''

        fetch(BASE_URL)
        .then((res)=>res.json())
        .then((info)=>{
            items = Object.values(info)
            for (const {name,_id} of items) {
                const li = createElement('li',null,otherDomSelectors.list,null,_id)
                createElement('span',name,li)
                const removeBtn = createElement('button','Remove',li)
                const editBtn = createElement('button','Edit',li)

                removeBtn.addEventListener('click', removeItemHandler)
                editBtn.addEventListener('click', editItemHandler)
            }
        })
    }

    function editItemHandler(){
        const parent = this.parentNode
        const span = parent.querySelector('span')
        const removeAndSubmitBtn = parent.querySelectorAll('button')
        
        const currentItem = items.find(x=>x._id ===parent.id)
        span.remove()
        removeAndSubmitBtn[0].remove()
        removeAndSubmitBtn[1].remove()
        const input = createElement('input',currentItem.name, parent)
        
        const remBtn = createElement('button','Remove', parent)
        const submitBtn = createElement('button','Submit', parent)

        remBtn.addEventListener('click',removeItemHandler)
        submitBtn.addEventListener('click',()=>{
            
            const name = input.value
            const htmlHeader = {
                method:'PATCH',
                body:JSON.stringify({name})
            }

            fetch(`${BASE_URL}${parent.id}`,htmlHeader)
                .then(()=>loadItemHandler())
        })
    }

    function removeItemHandler(){
        const id = this.parentNode.id

        const htmlHeader = {
            method:'DELETE'
        }

        fetch(`${BASE_URL}${id}`,htmlHeader)
        .then(()=>loadItemHandler())
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
