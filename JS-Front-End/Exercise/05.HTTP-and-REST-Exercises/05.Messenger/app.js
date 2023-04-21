function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/messenger'
    
    const submitBtn = document.getElementById('submit')
    const refreshBtn = document.getElementById('refresh')
    const textArea = document.getElementById('messages')
    
    refreshBtn.addEventListener('click', refresh)
    submitBtn.addEventListener('click',postMessage)

    function refresh(){
        textArea.value = ''
        fetch(BASE_URL)
            .then((res)=>res.json())
            .then((infoMessage)=>{
                for (const key in infoMessage) {
                    let {author,content} = infoMessage[key]
                    textArea.value = textArea.value + author +': ' + content + '\n'
                }
            })
            .catch((er)=>{
                console.error(er)
            })
    }

    function postMessage(){
        const inputs = document.getElementsByTagName('input')
        const author = inputs[0].value
        const content = inputs[1].value

        const httpHeaders = {
            method: 'POST',
            body: JSON.stringify({author,content})
        }

        if(author !=='' && content !== ''){
            fetch(BASE_URL,httpHeaders)
            .then(()=>{
                refresh()
                inputs[0].value=''
                inputs[1].value=''
                
            })
        }
    }


}

attachEvents();