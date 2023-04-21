function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/collections/students'
    const tbody = document.getElementsByTagName('tbody')[0]
    const submitBtn = document.getElementById('submit')

    submitBtn.addEventListener('click',createStudent)

    onload()

      function onload(){
          tbody.innerHTML=''
          fetch(BASE_URL)
          .then((res)=>res.json())
          .then((data)=>{
              for (const key in data) {
                let {firstName,lastName,facultyNumber,grade,_id} = data[key]
                let tr = createElement('tr','',tbody)
                createElement('td',firstName,tr)
                createElement('td',lastName,tr)
                createElement('td',facultyNumber,tr)
                createElement('td',grade,tr)
              }
          })
      }


      function createStudent(){
        const inputs = document.querySelectorAll('input')
        const firstName = inputs[0].value
        const lastName = inputs[1].value
        const facultyNumber = inputs[2].value
        const grade = inputs[3].value

        const htmlHeader={
          method:'POST',
          body:JSON.stringify({firstName,lastName,facultyNumber,grade})
        }

        fetch(BASE_URL,htmlHeader)
          .then((res)=>res.json())
          .then(()=>{
            inputs[0].value = ''
            inputs[1].value = ''
            inputs[2].value = ''
            inputs[3].value = ''
            onload()
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