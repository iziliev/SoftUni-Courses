window.addEventListener("load", solve);

function solve() {
  const storyState={
    firstNameInput:null,
    lastNameInput:null,
    ageInput:null,
    titleInput:null,
    genreInput:null,
    textInput:null
  }


  const inputDomSelectors={
    firstNameInput:document.getElementById('first-name'),
    lastNameInput:document.getElementById('last-name'),
    ageInput:document.getElementById('age'),
    titleInput:document.getElementById('story-title'),
    genreInput:document.getElementById('genre'),
    textInput:document.getElementById('story')
  }

  const otherDomSelectors = {
    publishBtn:document.getElementById('form-btn'),
    ul:document.getElementById('preview-list'),
    container:document.getElementById('side-wrapper'),
    main:document.getElementById('main'),
    body:document.getElementsByClassName('body')[0]
  }

  otherDomSelectors.publishBtn.addEventListener('click',publishItemHandler)

  function publishItemHandler(){

    const li = createElement('li',null,otherDomSelectors.ul,['story-info'])
    const article = createElement('article',null,li)
    createElement('h4',`Name: ${inputDomSelectors.firstNameInput.value} ${inputDomSelectors.lastNameInput.value}`,article)
    createElement('p',`Age: ${inputDomSelectors.ageInput.value}`,article)
    createElement('p',`Title: ${inputDomSelectors.titleInput.value}`,article)
    createElement('p',`Genre: ${inputDomSelectors.genreInput.value}`,article)
    createElement('p',`${inputDomSelectors.textInput.value}`,article)

    const saveBtn = createElement('button','Save Story',article,['save-btn'])
    const editBtn = createElement('button','Edit Story',article,['edit-btn'])
    const deleteBtn = createElement('button','Delete Story',article,['delete-btn'])

    for (const key in inputDomSelectors) {
      storyState[key] = inputDomSelectors[key].value
      inputDomSelectors[key].value=''
    }

    otherDomSelectors.publishBtn.setAttribute('disabled',true)

    editBtn.addEventListener('click',editItemHandler)
    deleteBtn.addEventListener('click',deleteItemHandler)
    saveBtn.addEventListener('click',saveItemHandler)

    function saveItemHandler(){
      otherDomSelectors.main.remove()
      const div = createElement('div',null,otherDomSelectors.body,null,['main'])
      createElement('h1',`Your scary story is saved!`,div)
    }

    function deleteItemHandler(){
      const parent = this.parentNode
      parent.remove()

      otherDomSelectors.publishBtn.removeAttribute('disabled')
    }

    function editItemHandler(){
      const parent = this.parentNode
      parent.remove()

      otherDomSelectors.publishBtn.removeAttribute('disabled')

      for (const key in storyState) {
        inputDomSelectors[key].value = storyState[key]
      }


    }




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
