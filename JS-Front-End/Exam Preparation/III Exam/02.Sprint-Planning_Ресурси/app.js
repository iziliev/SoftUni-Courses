window.addEventListener('load', solve);

function solve() {
    let count = 1
    let totalPoints = 0

    let tasks = []


    const label = {
        Feature: '&#8865',
        'Low Priority Bug': '&#9737',
        'High Priority Bug': '&#9888'
    }

    const labelClass = {
        Feature: 'feature',
        'Low Priority Bug': 'low-priority',
        'High Priority Bug': 'high-priority'
    }


    const inputDomElements = {
        id:document.getElementById('task-id'),
        title:document.getElementById('title'),
        description:document.getElementById('description'),
        label:document.getElementById('label'),
        points:document.getElementById('points'),
        assignee:document.getElementById('assignee')
    }

    const otherDomElements = {
        createBtn:document.getElementById('create-task-btn'),
        deleteBtn:document.getElementById('delete-task-btn'),
        section:document.getElementById('tasks-section'),
        totalPoints:document.getElementById('total-sprint-points')
    }

    otherDomElements.createBtn.addEventListener('click',createTaskHandler)
    otherDomElements.deleteBtn.addEventListener('click',deleteTaskHandler)

    function createTaskHandler(){
        inputDomElements.id.value=' '
        let isEmpty = Object.values(inputDomElements).find(x=>x.value === '')

        if(isEmpty){
            return
        }

        let article = createElement('article','',otherDomElements.section,['task-card'],`task-${count}`)
        createElement('div',`${inputDomElements.label.value} ${label[inputDomElements.label.value]}`,article,['task-card-label',`${labelClass[inputDomElements.label.value]}`],'','',`${inputDomElements.label.value} ${label[inputDomElements.label.value]}`)
        createElement('h3',inputDomElements.title.value,article,['task-card-title'])
        createElement('p',inputDomElements.description.value,article,['task-card-description'])
        createElement('div',`Estimated at ${inputDomElements.points.value} pts`,article,['task-card-points'])
        createElement('div',`Assigned to ${inputDomElements.title.value} pts`,article,['task-card-assignee'])
        let div = createElement('div','',article,['task-card-actions'])
        let deleteBtn = createElement('button','Delete', div)

        totalPoints += Number(inputDomElements.points.value)

        otherDomElements.totalPoints.textContent = `Total Points ${totalPoints}pts`

        tasks.push({
            id:`task-${count}`,
            title:inputDomElements.title.value,
            description:inputDomElements.description.value,
            label:inputDomElements.label.value,
            points:inputDomElements.points.value,
            assignee:inputDomElements.assignee.value
        })

        for (const key in inputDomElements) {
            inputDomElements[key].value = ''
        }

        count++

        deleteBtn.addEventListener('click',loadItemHandler)
    }

    function loadItemHandler(){
        let id = this.parentNode.parentNode.id
        let currentItem = tasks.find(x=>x.id === id)

        for (const key in inputDomElements) {
            inputDomElements[key].value = currentItem[key]
            inputDomElements[key].setAttribute('disabled',true)
        }

        otherDomElements.createBtn.setAttribute('disabled',true)
        otherDomElements.deleteBtn.removeAttribute('disabled')
    }

    function deleteTaskHandler(){
        let id = inputDomElements.id.value

        let article = document.getElementById(id)

        article.remove()
        
        totalPoints -= Number(inputDomElements.points.value)

        for (const key in inputDomElements) {
            inputDomElements[key].value=''
            inputDomElements[key].removeAttribute('disabled')
        }      
        
        otherDomElements.totalPoints.textContent = `Total Points ${totalPoints}pts`

        otherDomElements.deleteBtn.setAttribute('disabled',true)
        otherDomElements.createBtn.removeAttribute('disabled')
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