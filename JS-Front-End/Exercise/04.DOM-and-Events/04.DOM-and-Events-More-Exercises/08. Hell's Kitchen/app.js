function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   const bestRest = document.querySelector('#bestRestaurant > p')
   const bestWorkers = document.querySelector('#workers > p')

   function onClick () {

      bestRest.textContent = ''
      bestWorkers.textContent=''

      const textArea = document.getElementsByTagName('textArea')[0]
      const text = JSON.parse(textArea.value)
      
      let restaurants = [{}]

      for (const input of text) {
         let data = input.split(' - ')
         let restaurantName = data[0]
         
         let currentRestaurant = restaurants.find(x=>x.Name === restaurantName)
         let info = data[1].split(', ')
         
         for (const workerInfo of info) {

            let [name,salary]=workerInfo.split(' ')
            
            if(currentRestaurant === undefined){
               restaurants.push({
                  Name: restaurantName,
                  workers:[{}]
               })
               currentRestaurant = restaurants.find(x=>x.Name === restaurantName)
               
            }
            currentRestaurant.workers.push({
               Name:name,
               'With Salary': salary
            })
         }
         
         let bestSalary = 0
         let sumSalary = 0
         currentRestaurant.workers.shift()
         for (const worker of currentRestaurant.workers) {
            let salary = Number(worker["With Salary"])
            if(bestSalary < salary){
               bestSalary = salary
            }
            sumSalary += salary
         }
         currentRestaurant["Best Salary"] = bestSalary.toFixed(2)
         currentRestaurant["Average Salary"] = (sumSalary / currentRestaurant.workers.length).toFixed(2)
      }
      
      restaurants.forEach((el, idx) => {
         el.inputOrder = idx;
      })
      
      let bestRestaurant = restaurants.sort(
         (p1, p2) => (Number(p2["Average Salary"]) - Number(p1["Average Salary"])) || p1.inputOrder - p2.inputOrder)[1]
      
      bestRest.textContent = `Name: ${bestRestaurant.Name} Average Salary: ${bestRestaurant["Average Salary"]} Best Salary: ${bestRestaurant["Best Salary"]}`
      
      let workers = Object.entries(bestRestaurant.workers.sort((x,y)=>Number(y["With Salary"]) - Number(x["With Salary"])))

      for (let i = 0; i < workers.length; i++) {
         let worker = workers[i][1]
         bestWorkers.textContent += `Name: ${worker.Name} With Salary: ${worker["With Salary"]} `
      }

      textArea.value = ''
   }
}
