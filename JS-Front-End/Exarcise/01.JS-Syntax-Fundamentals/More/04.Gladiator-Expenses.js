function gladiator(lostFight,helmetPrice,swordPrice,ShieldPrice,armorPrice){
    
    let countHelmet = 0
    let countSword = 0
    let countShield = 0
    let countArmor = 0
    for (let i = 1; i <= lostFight; i++) {
        if (i % 2 === 0) {
            countHelmet++
        } 

        if(i % 3 === 0){
            countSword++
        } 

        if(i % 2 === 0 && i % 3 === 0){
            countShield++
        }
    }

    for (let i = 1; i <= countShield; i++) {
        if(i%2==0){
            countArmor++
        }
    }


    let expenses = countHelmet*helmetPrice + countSword*swordPrice + countShield*ShieldPrice + countArmor*armorPrice
    console.log(`Gladiator expenses: ${expenses.toFixed(2)} aureus`)
}

gladiator(7, 2, 3, 4, 5)
gladiator(23, 12.50, 21.50, 40, 200)