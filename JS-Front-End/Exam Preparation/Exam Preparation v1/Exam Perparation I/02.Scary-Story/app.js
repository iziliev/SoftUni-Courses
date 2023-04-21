window.addEventListener("load", solve);

function solve() {
  
  let button = document.getElementById('form-btn')

  button.addEventListener('click',publish)
  
    const firstName = document.getElementById('first-name')
    const lastName = document.getElementById('last-name')
    const age = document.getElementById('age')
    const storyTitle = document.getElementById('story-title')
    const genre  = document.getElementById('genre')
    const story = document.getElementById('story')
    const preview = document.getElementById('preview-list')


  function publish(e){
    
    if (firstName.value === ''
      || lastName.value === ''
      || age.value === ''
      || storyTitle.value === ''
      || story.value === '') {
      return
    }

    let li = createElement('li','',preview,'',['story-info'])
    let article = createElement('article','',li)
    createElement('h4',`Name: ${firstName.value} ${lastName.value}`,article)
    createElement('p',`Age: ${age.value}`,article)
    createElement('p',`Title: ${storyTitle.value}`,article)
    createElement('p',`Genre: ${genre.value}`,article)
    createElement('p',`${story.value}`,article)

    let saveBtn = createElement('button','Save Story',li,'',['save-btn'])
    let editBtn = createElement('button','Edit Story',li,'',['edit-btn'])
    let deleteBtn = createElement('button','Delete Story',li,'',['delete-btn'])

    preview.appendChild(li)

    button.disabled = true

    firstName.value=''
    lastName.value=''
    age.value=''
    storyTitle.value=''
    story.value=''

    editBtn.addEventListener('click',edit)
    deleteBtn.addEventListener('click',deleteItem)
    saveBtn.addEventListener('click',saveItem)

    function edit(){
      let article = preview.querySelector('article')
      let children = Array.from(article.children)
      let [_name,firstName,lastName] = children[0].textContent.split(' ')
      let [_number,age] = children[1].textContent.split(' ')
      let [_titleN,title] = children[2].textContent.split(' ')
      let [_titleG,genre] = children[3].textContent.split(' ')
      let content = children[4].textContent

      let firstNameEl = document.getElementById('first-name')
      let lastNameEl = document.getElementById('last-name')
      let ageEl = document.getElementById('age')
      let storyTitle = document.getElementById('story-title')
      let genreEl  = document.getElementById('genre')
      let story = document.getElementById('story')

      editBtn.disabled = true
      saveBtn.disabled = true
      deleteBtn.disabled = true

      button.disabled = false

      li.remove()

      firstNameEl.value = firstName
      lastNameEl.value = lastName
      ageEl.value = age
      storyTitle.value = title
      story.value = content
      genreEl.value = genre

    }

    function deleteItem(){
      let li = preview.querySelector('.story-info')
      
      li.remove()

      button.disabled = false

    }

    function saveItem(){
      let div = document.getElementById('main')

      while (div.firstChild) {
        div.removeChild(div.firstChild);
    }

      let h1 = createElement('h1',`Your scary story is saved!`,div)
      div.appendChild(h1)
    }

    function createElement(type, content, parentNode, id, classes, attributes){

      const htmlElement = document.createElement(type)
  
      if(content && type !== 'input'){
        htmlElement.textContent = content
      }

      if(content && type === 'input' || type === 'textarea'){
        htmlElement.value = content
      }
  
      if(id){
        htmlElement.id = id
      }
  
      if(parentNode){
        parentNode.appendChild(htmlElement)
      }
  
      if(classes){
        htmlElement.classList.add(...classes)
      }
  
      if(attributes){
        for (const key in attributes) {
          htmlElement.setAttribute(key,attributes[key])
        }
      }
  
      return htmlElement
  }

  }

}
