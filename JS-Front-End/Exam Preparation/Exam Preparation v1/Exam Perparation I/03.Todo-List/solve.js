function attachEvents() {
  const BASE_URL = 'http://localhost:3030/jsonstore/tasks/';
  const loadBtn = document.getElementById('load-button');
  const addBtn = document.getElementById('add-button');
  const toDoList = document.getElementById('todo-list');
  const titleInput = document.getElementById('title');

  loadBtn.addEventListener('click',loadTotoList);
  addBtn.addEventListener('click',addNewTask);

  function loadTotoList(e){
      if(e){
          e.preventDefault();
      }       

      toDoList.innerHTML='';

      fetch(BASE_URL)
          .then((res)=>res.json())
          .then((dataInfo) =>{
              for (const key in dataInfo) {
                  let {name,_id} = dataInfo[key];

                  const li = createElement('li','',toDoList,_id);
                  createElement('span',name,li);
                  const removeBtn = createElement('button','Remove',li);
                  const editBtn = createElement('button','Edit',li,);

                  removeBtn.addEventListener('click',deleteItem);
                  editBtn.addEventListener('click',()=>{
                      let itemId = '';
                      let name = '';
                      const span = editBtn.parentNode.firstChild

                      if(editBtn.textContent === 'Edit'){

                          editBtn.textContent = 'Submit'
                          itemId = editBtn.parentNode.id
                          const span = editBtn.parentNode.firstChild
                          name = span.textContent;
                          span.textContent = '';
                          let input = createElement('input',name,span)

                          name = input.value


                      } else {
                          let input = span.querySelector('input')
                          let name = input.value;
                          //itemId = editBtn.parentNode.id
                          const htmlHeader = {
                              method:'PUT',
                              body:JSON.stringify({name,_id})
                          }

                          fetch(BASE_URL+_id,htmlHeader)
                              .then((res)=>res.json())
                              .then(()=>{
                                  editBtn.textContent = 'Edit';
                                  loadTotoList();
                                  input.remove();
                                  span.textContent = name;
                              })
                      }
                      
                  })
              }

          })
          .catch((er)=>console.error(er))                    
  }

  function deleteItem(e){
      let itemId = e.currentTarget.parentNode.id;

      const htmlHeader = {
          method:'DELETE'
      }

      fetch(`${BASE_URL}${itemId}`,htmlHeader)
          .then((res)=>res.json())
          .then(()=>{
              loadTotoList();
          })
          .catch((er)=>{
              console.error(er);
          })
  }

  function addNewTask(e){
      if(e){
          e.preventDefault();
      }

      let name = titleInput.value;

      const htmlHeader = {
          method:'POST',
          body:JSON.stringify({name})
      }

      fetch(BASE_URL,htmlHeader)
          .then((res)=>res.json())
          .then(()=>{
              titleInput.value = '';
              loadTotoList();
          })
          .catch((er)=>{
              console.error(er);
          })
  }

  function createElement(type, content, parentNode, id, classes, attributes){

      const htmlElement = document.createElement(type)
  
      if(content && type !== 'input'){
        htmlElement.textContent = content
      }
  
      if(content && type !== 'textarea'){
          htmlElement.value = content
      }
  
      if(content && type === 'input'){
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
