window.addEventListener('load', solve);

function solve() {

  let totalLikes = 0

  const inputDOMSelectors = {
    genre: document.getElementById('genre'),
    name: document.getElementById('name'),
    author: document.getElementById('author'),
    date: document.getElementById('date'),
  }

  const otherDOMSelectors = {
    submitBtn: document.getElementById('add-btn'),
    allHitsContainer: document.querySelector('.all-hits-container'),
    savedHits: document.querySelector('.saved-container'),
    totalLikes: document.querySelector('.likes > p'),
  }

  otherDOMSelectors.submitBtn.addEventListener('click',addSongHandler)

  function addSongHandler(event){

    if(event){
      event.preventDefault()
    }

    let allInputsAreNonEmpty = Object.values(inputDOMSelectors)
      .every(x=>x.value !== '')

    if (!allInputsAreNonEmpty) {
      return
    }

    const div = createElement('div',null,otherDOMSelectors.allHitsContainer,['hits-info'])
    createElement('img',null,div,null,null,{src:'./static/img/img.png'})
    createElement('h2',`Genre: ${inputDOMSelectors.genre.value}`,div)
    createElement('h2',`Name: ${inputDOMSelectors.name.value}`,div)
    createElement('h2',`Author: ${inputDOMSelectors.author.value}`,div)
    createElement('h3',`Date: ${inputDOMSelectors.date.value}`,div)

    const saveBtn = createElement('button','Save song',div,['save-btn'])
    const likeBtn = createElement('button','Like song',div,['like-btn'])
    const deleteBtn = createElement('button','Delete',div,['delete-btn'])

    likeBtn.addEventListener('click',likeSongHandler)
    deleteBtn.addEventListener('click',deleteSongHandler)
    saveBtn.addEventListener('click',saveSongHandler)
  }


  function saveSongHandler(){
    const songRef = this.parentNode
    otherDOMSelectors.savedHits.appendChild(songRef)

    const saveBtn = songRef.querySelector('.save-btn')
    const deleteBtn = songRef.querySelector('.like-btn')

    saveBtn.remove()
    deleteBtn.remove()

  }

  function deleteSongHandler(){
    this.parentNode.remove()
  }

  function likeSongHandler(){
    this.setAttribute('disabled',true)
    totalLikes++
    otherDOMSelectors.totalLikes.textContent = `Total Likes: ${totalLikes}`
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