function attachEvents() {
    const loadBtn = document.getElementById('btnLoadPosts');
    const viewPostBtn = document.getElementById('btnViewPost')
    const BASE_URL = 'http://localhost:3030/jsonstore/blog/'
    const postSelect = document.getElementById('posts')
    const postComments = document.getElementById('post-comments')
    const h1 = document.getElementById('post-title')
    const p = document.getElementById('post-body')

    loadBtn.addEventListener('click', loadPosts)
    viewPostBtn.addEventListener('click',viewPost)
    
    function loadPosts(){
        postSelect.innerHTML=''
        postComments.innerHTML=''
        h1.textContent = 'Post Details'
        p.textContent = ''
        fetch(`${BASE_URL}posts`)
            .then((res)=>res.json())
            .then((info)=>{
                for (const key in info) {
                    let{body,id,title} = info[key]
                    createElement('option',title,postSelect,id,'',{value:id})
                }
            })
            .catch((er)=>{
                console.error(er)
            })
    }

    function viewPost(){
      postComments.innerHTML=''
      let postIdOption = postSelect.value

      fetch(`${BASE_URL}posts/${postIdOption}`)
        .then((res)=>res.json())
        .then((postInfo)=>{
          let {body,id,title} = postInfo
          
          h1.textContent = title
          
          p.textContent = body
        })
      
      fetch(`${BASE_URL}comments`)
          .then((res)=>res.json())
          .then((data)=>{
            for (const key in data) {
              let{id,postId,text} = data[key]
              if (postIdOption === postId) {
                createElement('li',text,postComments,id)
              }
            }

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