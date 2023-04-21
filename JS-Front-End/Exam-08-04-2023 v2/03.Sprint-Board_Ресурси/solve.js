// TODO:
function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/tasks/'

    let articles = {}

    const btnName = {
        'ToDo':'Move to In Progress',
        'In Progress': 'Move to Code Review',
        'Code Review': 'Move to Done',
        'Done': 'Close'
    }

    const nextUl = {
        'ToDo':'In Progress',
        'In Progress': 'Code Review',
        'Code Review': 'Done',
    }

    const ul ={
        'ToDo':document.querySelector('#todo-section .task-list'),
        'In Progress':document.querySelector('#in-progress-section .task-list'),
        'Code Review':document.querySelector('#code-review-section .task-list'),
        'Done':document.querySelector('#done-section .task-list')
    }

    const inputDomElements ={
        title:document.getElementById('title'),
        description:document.getElementById('description'),
    }

    const otherDomElements = {
        loadBtn:document.getElementById('load-board-btn'),
        createBtn:document.getElementById('create-task-btn'),
    }

    otherDomElements.loadBtn.addEventListener('click',loadTaskHandler)
    otherDomElements.createBtn.addEventListener('click',createTaskHandler)

    function createTaskHandler(){

        const htmlHeaders = {
            method:'POST',
            body:JSON.stringify({
                title:inputDomElements.title.value,
                description:inputDomElements.description.value,
                status:'ToDo'
            })
        }

        fetch(BASE_URL,htmlHeaders)
        .then(()=>{
            for (const key in inputDomElements) {
                inputDomElements[key].value = ''
            }
            loadTaskHandler()
        })

    }

    function loadTaskHandler(){

        for (const key in ul) {
            ul[key].innerHTML = ''
        }

        fetch(BASE_URL)
        .then((res)=>res.json())
        .then((info)=>{
            let infoData = Object.values(info)
            for (const {title,description,status,_id} of infoData) {
                const li = createElement('li',ul[status],'',['task'],_id)
                createElement('h3',li,title)
                createElement('p',li,description)
                const moveBtn = createElement('button',li,btnName[status])
                moveBtn.addEventListener('click',moveItemHandler)

                articles[_id] = {title,description,status,_id}
            }
        })
    }

    function moveItemHandler(event){
        let id = event.currentTarget.parentNode.id
        let currentElement = articles[id]
        let currentStatus = currentElement.status
        let status = nextUl[currentStatus]
        let htmlHeaders = {}
        if(currentStatus !== 'Done'){
            htmlHeaders = {
                method:'PATCH',
                body: JSON.stringify({status})
            }
        } else {
            htmlHeaders = {
                method:'DELETE',
            }
        }

        fetch(`${BASE_URL}${id}`,htmlHeaders)
        .then(()=>loadTaskHandler())


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