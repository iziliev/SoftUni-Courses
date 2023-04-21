function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/collections/books/';
    const tbody = document.querySelector('table > tbody');
    const loadBtn = document.getElementById('loadBooks');
    const submitBtn = document.querySelector('#form > button')
    const h3 = document.querySelector('#form > h3')
    const inputs = document.querySelectorAll('#form > input')
    let bookId = ''
    loadBtn.addEventListener('click',loadBooks);
    submitBtn.addEventListener('click',submitBook);

    function loadBooks(){
      tbody.innerHTML=''
        fetch(BASE_URL)
          .then((res)=>res.json())
          .then((bookInfo)=>{
              for (const key in bookInfo) {
                let tr = createElement('tr','',tbody);
                let {author,title} = bookInfo[key]
                createElement('td',title,tr)
                createElement('td',author,tr)
                let td = createElement('td','',tr)
                let editBtn = createElement('button','Edit',td,key)
                let deleteBtn = createElement('button','Delete',td,key)

                editBtn.addEventListener('click',()=>{
                  bookId = key
                  h3.textContent = 'Edit FORM'
                  submitBtn.textContent = 'Save'
                  inputs[1].value = author
                  inputs[0].value = title
                })

                deleteBtn.addEventListener('click',deleteBook)
              }
          })
          .catch((er)=>{
            console.error(er)
          })
    }

    // function editBook(){
    //   bookId = this.id
    //   h3.textContent = 'Edit FORM'
    //   submitBtn.textContent = 'Save'
      
    //   const inputs = document.querySelectorAll('#form > input')

    //   fetch(`${BASE_URL}${bookId}`)
    //     .then((res)=>res.json())
    //     .then((bookInfoToEdit)=>{
    //       let {author,title} = bookInfoToEdit
    //       inputs[1].value = author
    //       inputs[0].value = title
    //     })
    //     .catch((er)=>{
    //       console.error(er)
    //     })     
    // }

    function deleteBook(e){
      const htmlHeader = {
        method:'DELETE'
      }

      const bookId = this.id

      fetch(`${BASE_URL}${bookId}`,htmlHeader)
        .then((res)=>res.json())
        .then(()=>{
            loadBooks()
        })
        .catch((er)=>{
          console.error(er)
        })
    }

    function submitBook(){
      const inputs = document.querySelectorAll('#form > input')
      const author = inputs[1].value
      const title = inputs[0].value
      const htmlHeader = {
        method:'POST',
        body:JSON.stringify({author,title})
      }

      let url = BASE_URL

      if(h3.textContent === 'Edit FORM'){
        htmlHeader.method = 'PUT'
        url += bookId
      }

      fetch(url,htmlHeader)
      .then((res)=>res.json())
      .then(()=>{
        if(h3.textContent === 'Edit FORM'){
          h3.textContent = 'FORM'
          submitBtn.textContent = 'Submit'
        }

        inputs[0].value = ''
        inputs[1].value = ''
        loadBooks()
      })
      .catch((er)=>{
        console.error(er)
      })
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