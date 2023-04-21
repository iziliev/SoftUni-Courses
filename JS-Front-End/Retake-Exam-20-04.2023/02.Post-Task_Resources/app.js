window.addEventListener("load", solve);

function solve() {
    let task = {}

    const inputDomElements = {
        title:document.getElementById('task-title'),
        category:document.getElementById('task-category'),
        content:document.getElementById('task-content')
    }

    const otherDomElements = {
        publishBtn:document.getElementById('publish-btn'),
        review:document.getElementById('review-list'),
        post:document.getElementById('published-list')
    }

    otherDomElements.publishBtn.addEventListener('click',publishTaskHandler)

    function publishTaskHandler(){
        let isEmpty = Object.values(inputDomElements).find(x=>x.value === '')

        if(isEmpty){
            return
        }
        let li = createElement('li',otherDomElements.review,'',['rpost'])
        let article = createElement('article',li)
        createElement('h4',article,inputDomElements.title.value)
        createElement('p',article,`Category: ${inputDomElements.category.value}`)
        createElement('p',article,`Content: ${inputDomElements.content.value}`)

        let editBtn = createElement('button',li,'Edit',['action-btn', 'edit'])
        let postBtn = createElement('button',li,'Post',['action-btn', 'post'])

        task = {
            title:inputDomElements.title.value,
            category:inputDomElements.category.value,
            content:inputDomElements.content.value
        }

        for (const key in inputDomElements) {
            inputDomElements[key].value = ''
        }

        editBtn.addEventListener('click',editTaskHandler)
        postBtn.addEventListener('click',postTaskHandler)
    }

    function postTaskHandler(){
        let ref = this.parentNode

        let btnEdit = ref.querySelector('.action-btn.edit')
        let btnPost = ref.querySelector('.action-btn.post')

        this.parentNode.remove()
        btnEdit.remove()
        btnPost.remove()

        otherDomElements.post.appendChild(ref)
    }

    function editTaskHandler(){
        this.parentNode.remove()

        for (const key in inputDomElements) {
            inputDomElements[key].value = task[key]
        }
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