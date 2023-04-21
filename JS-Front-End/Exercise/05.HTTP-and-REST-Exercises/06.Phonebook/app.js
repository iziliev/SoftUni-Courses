function attachEvents() {
    const ulPhonebook = document.getElementById('phonebook')
    const loadBtn = document.getElementById('btnLoad')
    const createBtn = document.getElementById('btnCreate')
    const BASE_URL = 'http://localhost:3030/jsonstore/phonebook'

    loadBtn.addEventListener('click',loadPhone)
    createBtn.addEventListener('click',createPhone)

    function loadPhone(){
        ulPhonebook.innerHTML=''
        fetch(BASE_URL)
            .then((res)=>res.json())
            .then((data)=>{
                for (const key in data) {
                    let{person,phone,_id} = data[key]
                    let li = createElement('li',`${person}: ${phone}`,ulPhonebook)
                    let btnDelete = createElement('button','Delete',li,_id)

                    btnDelete.addEventListener('click',deletePhone)
                    ulPhonebook.appendChild(li)
                }
            })
            .catch((er)=>{
                console.error(er)
            })

            
    }

    function deletePhone(e){

        const httpHeaders = {
            method: 'DELETE',
        }
        fetch(`${BASE_URL}/${e.currentTarget.id}`,httpHeaders)
       
        .then((res)=>res.json())
        .then(loadPhone)
    }
    

    function createPhone(){
        const personIn = document.getElementById('person')
        const phoneIn = document.getElementById('phone')

        let person = personIn.value
        let phone = phoneIn.value

        const header = {
            method:'POST',
            body: JSON.stringify({person,phone})
        }

        fetch(BASE_URL,header)
            .then((res)=>res.json())
            .then(loadPhone)
        
            personIn.value = ''
            phoneIn.value=''
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

attachEvents();