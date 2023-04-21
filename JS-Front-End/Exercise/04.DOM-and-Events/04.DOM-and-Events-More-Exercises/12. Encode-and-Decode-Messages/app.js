function encodeAndDecodeMessages() {
    const buttons = Array.from(document.querySelectorAll('button'))
    const buttonEncode = buttons[0]
    const buttonDecode = buttons[1]
    
    const textArea = Array.from(document.querySelectorAll('textarea'))
    const areaDecode = textArea[1]
    let encodeText=''
    let decodeText = ''
    let text = ''
    buttonEncode.addEventListener('click',encode)
    buttonDecode.addEventListener('click',decode)

    function encode(){
        const areaEncode = textArea[0]
        text = areaEncode.value
        if(text !==''){
            for (let i = 0; i < text.length; i++) {
                let letter = text[i]
                encodeText += nextChar(letter)
            }
        }
        
        areaEncode.value = ''
        areaDecode.value = encodeText
        text = ''
        encodeText=''
    }

    function nextChar(c) {
        return String.fromCharCode(c.charCodeAt(0) + 1);
    }

    function decode(){
        const textArea = Array.from(document.querySelectorAll('textarea'))
        text = textArea[1].value
        if(text !==''){
            for (let i = 0; i < text.length; i++) {
                let letter = text[i]
                decodeText += prevChar(letter)
            }
        }
        areaDecode.value = decodeText
        text=''
        decodeText=''
    }

    function prevChar(c) {
        return String.fromCharCode(c.charCodeAt(0) - 1);
    }
}