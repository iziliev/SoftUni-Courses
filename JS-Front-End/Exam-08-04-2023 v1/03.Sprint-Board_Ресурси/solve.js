// TODO:
function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/tasks/'

    const inputDomSelectors ={
        title:document.getElementById('title'),
        description:document.getElementById('description')
    }

    const otherDomSelectors = {
        loadBtn:document.getElementById('load-board-btn'),
        createBtn:document.getElementById('create-task-btn'),
        todoSec:document.getElementById('todo-section'),
        inProgSec:document.getElementById('in-progress-section'),
        codeRewSec:document.getElementById('code-review-section'),
        doneSec:document.getElementById('done-section'),
        lists:document.getElementsByClassName('task-list')
    }

    otherDomSelectors.loadBtn.addEventListener('click',loadItems)
    otherDomSelectors.createBtn.addEventListener('click',createHandler)

    function createHandler(){
        let title = inputDomSelectors.title.value
        let description = inputDomSelectors.description.value
        let status = 'ToDo'

        const headerHtml = {
            method:'POST',
            body:JSON.stringify({title,description,status})
        }

        fetch(BASE_URL,headerHtml)
        .then(()=>{
            loadItems()
            for (const key in inputDomSelectors) {
                inputDomSelectors[key].value = ''
            }
        })
    }

    function loadItems(){

        for (const iterator of otherDomSelectors.lists) {
            iterator.innerHTML = ''
        }

        fetch(BASE_URL)
        .then((res)=>res.json())
        .then((info) =>{
            let allItems = Object.values(info)
            
            for (let {title,description,status,_id} of allItems) {
                
                if(status === 'ToDo'){
                    const currentUl = otherDomSelectors.todoSec.querySelector('.task-list')
                    const li = createElement('li',currentUl,'',['task'],_id)
                    createElement('h3',li,title)
                    createElement('p',li,description)
                    const btnMove = createElement('button',li,'Move to In Progress')

                    btnMove.addEventListener('click', ()=>{
                        status = 'In Progress'

                        const htmlHeaders ={
                            method:'PATCH',
                            body:JSON.stringify({status})
                        }
        
                        fetch(`${BASE_URL}${_id}`,htmlHeaders)
                        .then(()=>{
                            loadItems()
                        })
                    })

                } else if(status === 'In Progress'){
                    const currentUl = otherDomSelectors.inProgSec.querySelector('.task-list')

                    const li = createElement('li',currentUl,'',['task'],_id)
                    createElement('h3',li,title)
                    createElement('p',li,description)
                    const btnMove = createElement('button',li,'Move to Code Review')

                    btnMove.addEventListener('click', ()=>{
                        status = 'Code Review'
                        
                        const htmlHeaders ={
                            method:'PATCH',
                            body:JSON.stringify({status})
                        }
        
                        fetch(`${BASE_URL}${_id}`,htmlHeaders)
                        .then(()=>{
                            loadItems()
                        })
                    })

                } else if(status === 'Code Review'){
                    const currentUl = otherDomSelectors.codeRewSec.querySelector('.task-list')

                    const li = createElement('li',currentUl,'',['task'],_id)
                    createElement('h3',li,title)
                    createElement('p',li,description)
                    const btnMove = createElement('button',li,'Move to Done')

                    btnMove.addEventListener('click', ()=>{
                        status = 'Done'
                        
                        const htmlHeaders ={
                            method:'PATCH',
                            body:JSON.stringify({status})
                        }
        
                        fetch(`${BASE_URL}${_id}`,htmlHeaders)
                        .then(()=>{
                            loadItems()
                        })
                    })

                } else if(status === 'Done'){
                    const currentUl = otherDomSelectors.doneSec.querySelector('.task-list')

                    const li = createElement('li',currentUl,'',['task'],_id)
                    createElement('h3',li,title)
                    createElement('p',li,description)
                    const btnMove = createElement('button',li,'Close')

                    btnMove.addEventListener('click', ()=>{
                        const htmlHeaders ={
                            method:'DELETE',
                        }
        
                        fetch(`${BASE_URL}${_id}`,htmlHeaders)
                        .then(()=>{
                            loadItems()
                        })
                    })
                }

                
            }
        })

        

    }

    function createElement(type, parentNode, content, classes, id, attributes, useInnerHtml) {
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