function toggle() {
    const divShow = document.getElementById('extra')
    const spanElement = document.getElementsByClassName('button')[0]
    if(spanElement.textContent === 'More'){
        divShow.style.display='block'
        spanElement.textContent = 'Less'
    } else {
        divShow.style.display='none'
        spanElement.textContent = 'More'
    }
}