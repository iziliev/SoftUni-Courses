window.addEventListener('load', solve);

function solve() {
    
    let allHitsContainer = document.querySelector('div .all-hits-container')

    let allLikes = document.querySelector('div.likes > p')

    const buttonAdd = document.getElementById('add-btn')


    buttonAdd.addEventListener('click',addSong)

    function addSong(e){
        e.preventDefault()
        const inputs = Array.from(document.querySelectorAll('input'))
        const genreInput = inputs[0]
        const songInput = inputs[1]
        const authorInput = inputs[2]
        const dateInput = inputs[3]
        
        if(genreInput.value === '' || 
            songInput.value === '' || 
            authorInput.value === '' || 
            dateInput.value === ''){
            return
        }

        let createDivHitsInfo = createElement('div','',allHitsContainer,'',['hits-info'])
        createElement('img','',createDivHitsInfo,'','',{src:'./static/img/img.png'})
        createElement('h2',`Genre: ${genreInput.value}`,createDivHitsInfo)
        createElement('h2',`Name: ${songInput.value}`,createDivHitsInfo)
        createElement('h2',`Author: ${authorInput.value}`,createDivHitsInfo)
        createElement('h3',`Date: ${dateInput.value}`,createDivHitsInfo)

        let saveBtn = createElement('button','Save song',createDivHitsInfo,'',['save-btn'])
        let likeBtn = createElement('button','Like song',createDivHitsInfo,'',['like-btn'])
        let deleteBtn = createElement('button','Delete',createDivHitsInfo,'',['delete-btn'])

        likeBtn.addEventListener('click',likes)
        saveBtn.addEventListener('click',saves)
        deleteBtn.addEventListener('click',deleteEl)

        allHitsContainer.appendChild(createDivHitsInfo)

        genreInput.value = ''
        songInput.value = ''
        authorInput.value = ''
        dateInput.value = ''

        function deleteEl(e){
            let parent = e.target.parentNode
            parent.remove()
        }
        
        function likes(){
            let [total,count] = allLikes.textContent.split(': ')
            let likes = Number(count) + 1
            allLikes.textContent = total + ': ' + likes
            likeBtn.disabled = true
            likeBtn.style.color = 'grey'
        }
    
        function saves(){
            let newDiv = createDivHitsInfo
            createDivHitsInfo.remove()
            let saveContainer = document.querySelector('.saved-container')
            saveContainer.appendChild(newDiv)
            let saveBtnSave = newDiv.querySelector('.save-btn') 
            let likeBtnSave = newDiv.querySelector('.like-btn') 
            saveBtnSave.remove()
            likeBtnSave.remove()
        }

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