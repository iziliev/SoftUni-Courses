function lockedProfile() {
    const allButtons = Array.from(document.getElementsByTagName('button'))
    .forEach(x=>x.addEventListener('click',showHide))

    function showHide(e){
        const button = e.target
        const profile = button.parentNode
        const moreInfo = profile.getElementsByTagName('div')[0]
        const isItChecked = profile.querySelector('input[type="radio"]:checked').value
        if(isItChecked === 'unlock'){
            if (button.textContent === 'Show more') {
                moreInfo.style.display = 'inline-block'
                button.textContent = 'Hide it'
            } else {
                moreInfo.style.display = 'none'
                button.textContent = 'Show more'
            }
        }   
    }
}