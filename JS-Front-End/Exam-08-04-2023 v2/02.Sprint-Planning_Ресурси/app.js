window.addEventListener('load', solve);

function solve() {
    let count = 0
    let totalPoints = 0

    let articles = []

    const inputDomElements = {
        id:document.getElementById('task-id'),
        title:document.getElementById('title'),
        description:document.getElementById('description'),
        label:document.getElementById('label'),
        points:document.getElementById('points'),
        assignee:document.getElementById('assignee'),
    }

    const otherDomElements = {
        createBtn:document.getElementById('create-task-btn'),
        deleteTbt:document.getElementById('delete-task-btn'),
        section:document.getElementById('tasks-section'),
        totalPoints:document.getElementById('total-sprint-points'),
    }

    otherDomElements.deleteTbt.setAttribute('disabled',true)
    otherDomElements.createBtn.addEventListener('click',createTaskHandler)
    otherDomElements.deleteTbt.addEventListener('click',deleteTaskHandler)

    function deleteTaskHandler(){
        let id = inputDomElements.id.value
        let currentItem = document.getElementById(`${id}`)
        currentItem.remove()

        totalPoints -= Number(inputDomElements.points.value)

        otherDomElements.totalPoints.textContent = `Total Points ${totalPoints}pts`

        for (const key in inputDomElements) {
            inputDomElements[key].value = ''
            inputDomElements[key].removeAttribute('disabled')
        }

        otherDomElements.deleteTbt.setAttribute('disabled',true)
        otherDomElements.createBtn.removeAttribute('disabled')
    }

    function createTaskHandler(){
        let oldCount = count
        let id = `task-${++count}`

        inputDomElements.id.value = id
        
        let isHasEmptyField = Object.values(inputDomElements)
        .every(x=> x.value !== '')

        if(!isHasEmptyField){
            count = oldCount
            return
        }

        let article = createElement('article',otherDomElements.section,'',['task-card'],`${id}`)
        let divLabel = createElement('div',article,'',['task-card-label'])
        switch (inputDomElements.label.value) {
            case 'Feature':
                divLabel.innerHTML = `${article,inputDomElements.label.value} &#8865`
                divLabel.classList.add('feature')
                break;
            case 'Low Priority Bug':
                divLabel.innerHTML = `${article,inputDomElements.label.value} &#9737`
                divLabel.classList.add('low-priority')
                break;
            case 'High Priority Bug':
                divLabel.innerHTML = `${article,inputDomElements.label.value} &#9888`
                divLabel.classList.add('high-priority')
                break;
        }

        createElement('h3',article,inputDomElements.title.value,['task-card-title'])
        createElement('p',article,inputDomElements.description.value,['task-card-description'])
        createElement('div',article,`Estimated at ${article,inputDomElements.points.value} pts`,['task-card-points'])
        createElement('div',article,`Assigned to: ${article,inputDomElements.assignee.value}`,['task-card-assignee'])

        const divBtn = createElement('div',article,'',['task-card-actions'])
        const deleteTaskBtn = createElement('button',divBtn,'Delete',)

        totalPoints += Number(inputDomElements.points.value)

        otherDomElements.totalPoints.textContent = `Total Points ${totalPoints}pts`

        articles[id] = {
            id:inputDomElements.id.value,
            title:inputDomElements.title.value,
            description:inputDomElements.description.value,
            label:inputDomElements.label.value,
            points:inputDomElements.points.value,
            assignee:inputDomElements.assignee.value,
        }

        for (const key in inputDomElements) {
            inputDomElements[key].value = ''
        }

        deleteTaskBtn.addEventListener('click',fillTaskHandler)   
    }

    function fillTaskHandler(){
        let currentId = this.parentNode.parentNode.id

        let currentIdem = articles[currentId]
        for (const key in currentIdem) {
            inputDomElements[key].value = currentIdem[key]
            inputDomElements[key].setAttribute('disabled',true)
        }

        otherDomElements.deleteTbt.removeAttribute('disabled')
        otherDomElements.createBtn.setAttribute('disabled',true)
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