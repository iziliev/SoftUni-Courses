window.addEventListener('load', solve);

function solve() {
    let allLikes = 0

    const inputDomElements = {
        genre:document.getElementById('genre'),
        name:document.getElementById('name'),
        author:document.getElementById('author'),
        date:document.getElementById('date')
    }

    const othetDomElements ={
        addBtn:document.getElementById('add-btn'),
        divCont:document.querySelector('#all-hits .all-hits-container'),
        totalLikes:document.querySelector('#total-likes .likes > p'),
        saveCont:document.querySelector('#saved-hits .saved-container')
    }

    othetDomElements.addBtn.addEventListener('click',addSong)

    function addSong(event){

        if(event){
            event.preventDefault()
        }

        let hasEmptyField = Object.values(inputDomElements).find(x=>x.value === '')

        if(hasEmptyField){
            return
        }

        let divHit = createElement('div','',othetDomElements.divCont,['hits-info'])
        createElement('img','',divHit,'','',{src:'./static/img/img.png'})
        createElement('h2',`Genre: ${inputDomElements.genre.value}`,divHit)
        createElement('h2',`Name: ${inputDomElements.name.value}`,divHit)
        createElement('h2',`Author: ${inputDomElements.author.value}`,divHit)
        createElement('h3',`Date: ${inputDomElements.date.value}`,divHit)
        let saveBtn = createElement('button','Save song',divHit,['save-btn'])
        let likeBtn = createElement('button','Like song',divHit,['like-btn'])
        let deleteBtn = createElement('button','Delete',divHit,['delete-btn'])

        for (const key in inputDomElements) {
            inputDomElements[key].value = ''
        }

        likeBtn.addEventListener('click',likeSong)
        saveBtn.addEventListener('click',saveSong)
        deleteBtn.addEventListener('click',deleteSong)
    }

    function saveSong(){
        let ref = this.parentNode
        let saveBtn = ref.querySelector('.save-btn')
        let likeBtn = ref.querySelector('.like-btn')
        let deleteBtn = ref.querySelector('.delete-btn')
        saveBtn.remove()
        likeBtn.remove()

        othetDomElements.saveCont.appendChild(ref)

        this.parentNode.remove()

        deleteBtn.addEventListener('click',deleteSong)
    }

    function deleteSong(){
        this.parentNode.remove()
    }

    function likeSong(){
        allLikes++
        this.setAttribute('disabled',true)
        othetDomElements.totalLikes.textContent = `Total Likes: ${allLikes}`
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