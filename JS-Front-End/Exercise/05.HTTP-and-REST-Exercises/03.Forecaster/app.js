function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/forecaster/';
    const submitBtn = document.getElementById('submit');
    const locationInput = document.getElementById('location')
    const divCurrent = document.getElementById('current')
    const divForecast = document.getElementById('forecast')
    const divUpcoming = document.getElementById('upcoming')

    const icon = {
        Sunny:'&#x2600',
        'Partly sunny':'&#x26C5',
        Overcast:'&#x2601',
	    Rain:'&#x2614',
        Degrees:'&#176'
    }    

    submitBtn.addEventListener('click', getForecast)
    let codeLocation = '';

    function getForecast(){
        divCurrent.innerHTML=''
        divUpcoming.innerHTML=''
        createElement('div','Current conditions',divCurrent,'',['label'])
        createElement('div','Three-day forecast',divUpcoming,'',['label'])
        
        fetch(`${BASE_URL}locations`)
            .then((res)=>res.json())
            .then((info)=>{
                for (const loc of info) {
                    if(loc.name === locationInput.value){
                        codeLocation = loc.code
                        break;
                    }
                }
                
                divForecast.style.display = 'block'

                fetch(`${BASE_URL}today/${codeLocation}`)
                    .then((res)=>res.json())
                    .then((data)=>{

                        let {name,forecast} = data
                        let {low,high,condition} = forecast

                        let divForecasts = createElement('div','',divForecast,'',['forecasts'])
                        let spanSymbol = createElement('span','',divForecasts,'',['condition', 'symbol'])
                        spanSymbol.innerHTML = icon[condition]
                        let spanCondition = createElement('span','',divForecasts,'',['condition'])
                        createElement('span',name,spanCondition,'',['forecast-data'])

                        let spanDegree = createElement('span','',spanCondition,'',['forecast-data'])
                        spanDegree.innerHTML=`${low}${icon['Degrees']}/${high}${icon['Degrees']}`
                        createElement('span',condition,spanCondition,'',['forecast-data'])

                        divCurrent.appendChild(divForecasts)

                })
                .catch((er)=>{console.error(er)})

                fetch(`${BASE_URL}upcoming/${codeLocation}`)
                    .then((res)=>res.json())
                    .then((upData)=>{

                        let {name,forecast} = upData

                        for (const cast of forecast) {
                            let {low,high,condition} = cast

                            let divForecastsInfo = createElement('div','',divUpcoming,'',['forecast-info'])
                            let spanUpcoming = createElement('span','',divForecastsInfo,'',['upcoming'])
                            let spanSymbol = createElement('span','',spanUpcoming,'',['symbol'])
                            spanSymbol.innerHTML=icon[condition]

                            let spanDegree = createElement('span','',spanUpcoming,'',['forecast-data'])
                            spanDegree.innerHTML=`${low}${icon['Degrees']}/${high}${icon['Degrees']}`
                            createElement('span',condition,spanUpcoming,'',['forecast-data'])

                            divUpcoming.appendChild(divForecastsInfo)

                        }

                        

                        

                })
                .catch((er)=>{console.error(er)})

            })
            .catch((er)=>{console.error(er)});

        

        
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