// TODO:
function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/tasks/'

    let tasks = []

    const inputDomElements = {
        title:document.getElementById('title'),
        description:document.getElementById('description')
    }

    const sections = {
        ToDo:{
            section:document.querySelector('#todo-section .task-list'),
            btnName:'Move to In Progress',
            nextStatus:'In Progress'
        },
        'In Progress':{
            section:document.querySelector('#in-progress-section .task-list'),
            btnName:'Move to Code Review',
            nextStatus:'Code Review'
        },
        'Code Review':{
            section:document.querySelector('#code-review-section .task-list'),
            btnName:'Move to Done',
            nextStatus:'Done'
        },
        Done:{
            section:document.querySelector('#done-section .task-list'),
            btnName:'Close',
        }
    }

    const otherDomElements = {
        loadBtn:document.getElementById('load-board-btn'),
        createBtn:document.getElementById('create-task-btn')
    }

    otherDomElements.loadBtn.addEventListener('click',loadTaskHandler)

    otherDomElements.createBtn.addEventListener('click',createTaskHandler)

    function createTaskHandler(event){
        if(event){
            event.preventDefault()
        }

        let isEmpty = Object.values(inputDomElements).find(x=>x.value === '')

        if(isEmpty){
            return
        }

        const htmlHeader = {
            method:'POST',
            body:JSON.stringify({
                title:inputDomElements.title.value,
                description:inputDomElements.description.value,
                status:'ToDo'
            })
        }

        fetch(BASE_URL,htmlHeader)
        .then(()=>{
            for (const key in inputDomElements) {
                inputDomElements[key].value = ''
            }
            loadTaskHandler()
        })
    }

    function loadTaskHandler(event){

        if(event){
            event.preventDefault()
        }

        for (const key in sections) {
            for (const sectKey in sections[key]) {
                if (sectKey === 'section'){
                    sections[key].section.innerHTML = ''
                }
            }
        }

        fetch(BASE_URL)
        .then((res)=>res.json())
        .then((info)=>{
            tasks = Object.values(info)

            for (const task of tasks) {
                let {title,description,status,_id} = task

                let li = createElement('li','',sections[status].section,['task'],_id)
                createElement('h3',title,li)
                createElement('p',description,li)
                let btn = createElement('button',sections[status].btnName,li)

                btn.addEventListener('click',moveToNextOrDelete)
            }
        })
    }

    function moveToNextOrDelete(event){
        if(event){
            event.preventDefault()
        }

        let id = this.parentNode.id

        let currentTask = tasks.find(x=>x._id === id)

        let htmlHeader = {}

        if(this.textContent === 'Close'){
            htmlHeader = {
                method:'DELETE'
            }
        } else {
            htmlHeader = {
                method:'PATCH',
                body:JSON.stringify({
                    status:sections[currentTask.status].nextStatus
                })
            }
        }

        fetch(`${BASE_URL}${id}`,htmlHeader)
        .then(()=>loadTaskHandler())
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