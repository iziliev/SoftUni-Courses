window.addEventListener("load", solve);

function solve() {
    let stories = {}

    const inputDomElements = {
      firstName:document.getElementById('first-name'),
      lastName:document.getElementById('last-name'),
      age:document.getElementById('age'),
      title:document.getElementById('story-title'),
      genre:document.getElementById('genre'),
      story:document.getElementById('story')
    }

    const otherDomElements = {
      publishBtn:document.getElementById('form-btn'),
      previewList:document.getElementById('preview-list'),
      main:document.getElementById('main'),
      body:document.querySelector('.body')
    }

    otherDomElements.publishBtn.addEventListener('click', publishStory)

    function publishStory(){       
      let isEmpty = Object.values(inputDomElements).find(x=>x.value === '')

      if(isEmpty){
        return
      }

      let li = createElement('li','',otherDomElements.previewList,['story-info'])
      let article = createElement('article','',li)
      createElement('h4',`Name: ${inputDomElements.firstName.value} ${inputDomElements.lastName.value}`,article)
      createElement('p',`Age: ${inputDomElements.age.value}`,article)
      createElement('p',`Title: ${inputDomElements.title.value}`,article)
      createElement('p',`Genre: ${inputDomElements.genre.value}`,article)
      createElement('p',`${inputDomElements.story.value}`,article)
      let saveBtn = createElement('button','Save Story',li,['save-btn'])
      let editBtn = createElement('button','Edit Story',li,['edit-btn'])
      let deleteBtn = createElement('button','Delete Story',li,['delete-btn'])

      otherDomElements.publishBtn.setAttribute('disabled',true)

      stories = {
          firstName:inputDomElements.firstName.value,
          lastName:inputDomElements.lastName.value,
          age:inputDomElements.age.value,
          title:inputDomElements.title.value,
          genre:inputDomElements.genre.value,
          story:inputDomElements.story.value
        }

      for (const key in inputDomElements) {
        inputDomElements[key].value=''
      }

      editBtn.addEventListener('click', editStory)
      deleteBtn.addEventListener('click', deleteStory)
      saveBtn.addEventListener('click', saveStory)
    }

    function saveStory(){
      otherDomElements.main.remove()
      let div = createElement('div','',otherDomElements.body,'','main')
      createElement('h1','Your scary story is saved!',div)
    }

    function editStory(){

      for (const key in stories) {
        inputDomElements[key].value = stories[key]
      }

      this.parentNode.remove()

      otherDomElements.publishBtn.removeAttribute('disabled')
    }

    function deleteStory(){

      this.parentNode.remove()

      otherDomElements.publishBtn.removeAttribute('disabled')
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
