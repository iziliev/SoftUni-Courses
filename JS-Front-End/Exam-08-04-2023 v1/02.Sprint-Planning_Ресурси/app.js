window.addEventListener('load', solve);

function solve() {
    let articles = {}

    let id = 0
    let points = 0
    let currentId = ''

    const inputDomSelectors = {
        id:document.getElementById('task-id'),
        title: document.getElementById('title'),
        description: document.getElementById('description'),
        label: document.getElementById('label'),
        points:document.getElementById('points'),
        assignee:document.getElementById('assignee')
    }

    const otherDomSelectors ={
        createBtn: document.getElementById('create-task-btn'),
        deleteBtn: document.getElementById('delete-task-btn'),
        section: document.getElementById('tasks-section'),
        totalPoints:document.getElementById('total-sprint-points')
    }

    otherDomSelectors.deleteBtn.setAttribute('disabled',true)
    otherDomSelectors.createBtn.addEventListener('click',createHandler)

    function createHandler(){

        if(inputDomSelectors.title.value === ''
        || inputDomSelectors.description.value === ''
        || inputDomSelectors.label.value === ''
        || inputDomSelectors.points.value === ''
        || inputDomSelectors.assignee.value === ''){
            return
        }
        
        id++
        const article = createElement('article','',otherDomSelectors.section,['task-card'],`task-${id}`)
        const divLabel = createElement('div','',article,['task-card-label'])
        if(inputDomSelectors.label.value === 'Feature'){
            divLabel.innerHTML = 'Feature &#8865'
            divLabel.classList.add('feature')
        } else if(inputDomSelectors.label.value === 'Low Priority Bug'){
            divLabel.innerHTML = 'Low Priority Bug &#9737'
            divLabel.classList.add('low-priority')
            
        } else if(inputDomSelectors.label.value === 'High Priority Bug'){
            divLabel.innerHTML = 'High Priority Bug &#9888'
            divLabel.classList.add('high-priority')
        }

        createElement('h3', inputDomSelectors.title.value,article,['task-card-title'])
        createElement('p', inputDomSelectors.description.value,article,['task-card-description'])
        createElement('div', `Estimated at ${inputDomSelectors.points.value} pts`,article,['task-card-points'])
        createElement('div', `Assigned to: ${inputDomSelectors.assignee.value}`,article,['task-card-assignee'])

        const divBtn = createElement('div','',article,['task-card-actions'])
        const deleteArticleBtn = createElement('button','Delete',divBtn,['task-card-actions'])

        points+=Number(inputDomSelectors.points.value)

        articles[`task-${id}`] = {
            id:`task-${id}`,
            title:inputDomSelectors.title.value,
            description:inputDomSelectors.description.value,
            label:inputDomSelectors.label.value,
            points:inputDomSelectors.points.value,
            assignee:inputDomSelectors.assignee.value,
        }

        for (const key in inputDomSelectors) {
            inputDomSelectors[key].value=''
        }

        otherDomSelectors.totalPoints.textContent=`Total Points ${points}pts`
        deleteArticleBtn.addEventListener('click',deleteArticleHandler)

        function deleteArticleHandler(){
            let parent = this.parentNode.parentNode
            currentId = parent.id
            let currentArticle = articles[currentId]
            for (const key in currentArticle) {
                inputDomSelectors[key].value = currentArticle[key]
				inputDomSelectors[key].setAttribute('disabled',true)
            }

            otherDomSelectors.createBtn.setAttribute('disabled',true)
            otherDomSelectors.deleteBtn.removeAttribute('disabled')

            otherDomSelectors.deleteBtn.addEventListener('click',deleteArticleItem)
        }

        function deleteArticleItem(){
            const currentArticleTask = document.getElementById(currentId)
            currentArticleTask.remove()

            for (const key in inputDomSelectors) {

                if(key === 'points'){
                    points-=Number(inputDomSelectors[key].value)
                }

                inputDomSelectors[key].value=''
				inputDomSelectors[key].removeAttribute('disabled')
            }

            otherDomSelectors.createBtn.removeAttribute('disabled')
            otherDomSelectors.deleteBtn.setAttribute('disabled',true)
            otherDomSelectors.totalPoints.textContent=`Total Points ${points}pts`
        }
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