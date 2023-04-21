function solve() {
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    const span = document.querySelector('#info > span');
    const BASE_URL = 'http://localhost:3030/jsonstore/bus/schedule/';
    let nextStopId = 'depot';
    let nextStopName = 'depot';

    function depart() {

        arriveBtn.disabled = false;
        departBtn.disabled = true;

        fetch(`${BASE_URL}${nextStopId}`)
            .then((res)=>res.json())
            .then((stopId)=>{
                const {name,next} = stopId;
                span.textContent = `Next stop ${name}`
                nextStopId = next;
                nextStopName = name
            })
            .catch((er)=>{
                span.textContent = 'Error';
                arriveBtn.disabled = true;
                departBtn.disabled = true;
            })
    }

    function arrive() {
        arriveBtn.disabled = true;
        departBtn.disabled = false;
        span.textContent = `Arriving at ${nextStopName}`
    }

    return {
        depart,
        arrive
    };
}

let result = solve();