function bitCoin(...shift) {
    let shifts = shift[0]
    let bitcoinPrice = 11949.16
    let gramGoldPrice = 67.51
    
    let amountSum = 0
    let countDay = 0
    let firstDay = 0
    
    for (let i = 0; i < shifts.length; i++) {
        countDay++
        if (countDay % 3 === 0) {
            amountSum += ((gramGoldPrice * shifts[i])*0.7)
        } else {
            
            amountSum += (gramGoldPrice * shifts[i])
        }

        if(firstDay === 0 && Math.floor(amountSum/bitcoinPrice) > 0){
            firstDay =countDay
        }
    }

    let boughtBitCoin = Math.floor(amountSum/bitcoinPrice)

    console.log(`Bought bitcoins: ${boughtBitCoin}`)
    if (firstDay!==0) {
        console.log(`Day of the first purchased bitcoin: ${firstDay}`)
    }
    console.log(`Left money: ${(amountSum -(boughtBitCoin*bitcoinPrice)).toFixed(2)} lv.`)
}

bitCoin([100, 200, 300])
bitCoin([50, 100])
bitCoin([3124.15, 504.212, 2511.124])
