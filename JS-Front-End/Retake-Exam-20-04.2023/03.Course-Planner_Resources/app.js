function solve(){
    const BASE_URL = 'http://localhost:3030/jsonstore/tasks/'

    let tasks = []
    let id = 0

    const inputDomElements = {
        title:document.getElementById('course-name'),
        type:document.getElementById('course-type'),
        description:document.getElementById('description'),
        teacher:document.getElementById('teacher-name')
    }

    const otherDomElements = {
        addBtn:document.getElementById('add-course'),
        editBtn:document.getElementById('edit-course'),
        loadBtn:document.getElementById('load-course'),
        list:document.getElementById('list')
    }

    otherDomElements.loadBtn.addEventListener('click',loadTaskHandler)
    otherDomElements.addBtn.addEventListener('click',addTaskHandler)
    otherDomElements.editBtn.addEventListener('click',editTaskHandler)

    function addTaskHandler(event){
        if(event){
            event.preventDefault()
        }

        let isEmpty = Object.values(inputDomElements).find(x=>x.value === '')

        if(isEmpty){
            return
        }

        let htmlHeader = {
            method:'POST',
            body:JSON.stringify({
                title:inputDomElements.title.value,
                type:inputDomElements.type.value,
                description:inputDomElements.description.value,
                teacher:inputDomElements.teacher.value
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

        otherDomElements.list.innerHTML = ''

        fetch(BASE_URL)
        .then((res)=>res.json())
        .then((info)=>{
            tasks = Object.values(info)

            for (const task of tasks) {
                let {title,type,description,teacher,_id} = task

                let div = createElement('div',otherDomElements.list,'',['container'],_id)
                createElement('h2',div,title)
                createElement('h3',div,teacher)
                createElement('h3',div,type)
                createElement('h4',div,description)

                let editCourseBtn = createElement('button',div,'Edit Course',['edit-btn'])
                let finishCourseBtn = createElement('button',div,'Finish Course',['finish-btn'])

                editCourseBtn.addEventListener('click',loadCurrentTaskHandler)
                finishCourseBtn.addEventListener('click',finishTaskHandler)
            }
        })


    }

    function finishTaskHandler(event){
        if(event){
            event.preventDefault()
        }

        id = this.parentNode.id

        const htmlHeader = {
            method:'DELETE'
        }

        fetch(`${BASE_URL}${id}`,htmlHeader)
        .then(()=>loadTaskHandler())
    }

    function loadCurrentTaskHandler(event){
        if(event){
            event.preventDefault()
        }

        id = this.parentNode.id
        let currentTask = tasks.find(x=>x._id === id)

        for (const key in inputDomElements) {
            inputDomElements[key].value = currentTask[key]
        }

        otherDomElements.addBtn.setAttribute('disabled',true)
        otherDomElements.editBtn.removeAttribute('disabled')
    }

    function editTaskHandler(event){
        if(event){
            event.preventDefault()
        }

        const htmlHeader = {
            method:'PATCH',
            body:JSON.stringify({
                title:inputDomElements.title.value,
                type:inputDomElements.type.value,
                description:inputDomElements.description.value,
                teacher:inputDomElements.teacher.value
            })
        }

        fetch(`${BASE_URL}${id}`,htmlHeader)
        .then(()=>{
            for (const key in inputDomElements) {
                inputDomElements[key].value = ''
            }
            loadTaskHandler()

            otherDomElements.addBtn.removeAttribute('disabled')
            otherDomElements.editBtn.setAttribute('disabled',true)
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

solve()