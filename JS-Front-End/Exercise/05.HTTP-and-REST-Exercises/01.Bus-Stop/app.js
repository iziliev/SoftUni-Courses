function getInfo() {
    const stopId = document.getElementById('stopId');
    const stopName = document.getElementById('stopName');
    const busesUl = document.getElementById('buses');
    
    const BASE_URL = 'http://localhost:3030/jsonstore/bus/businfo/';
    
    const id = stopId.value

    busesUl.innerHTML = ''

    fetch(`${BASE_URL}${id}`)
        .then((res)=>res.json())
        .then((busInfo)=>{
            const {name,buses} = busInfo;
            stopName.textContent = name;
            for (const busId in buses) {
                const li = document.createElement('li');
                li.textContent = `Bus ${busId} arrives in ${buses[busId]} minutes`;
                busesUl.appendChild(li);
            }
        })
        .catch(()=>{
            stopName.textContent = 'Error';
        })
}