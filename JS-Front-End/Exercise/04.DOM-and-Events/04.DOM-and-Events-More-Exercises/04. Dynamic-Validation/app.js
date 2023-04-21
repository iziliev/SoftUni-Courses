function validate() {
    const inputText = document.getElementById('email')
    const pattern = new RegExp(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/,'g')
    
    inputText.addEventListener('change',validate)
    

    function validate (e){
        const email = inputText.value
        if(!pattern.test(email)){
            inputText.classList.add('error')
        } else{
            inputText.classList.remove('error')
        }
    }
}