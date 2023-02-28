function vacantion(people,type,day){
    let totalPrice=0
    if (type === 'Students') {
        if(people>=30){
            if(day==='Friday') {
                totalPrice=(people*8.45)*0.85
            } else if(day==='Saturday') {
                totalPrice=(people*9.80)*0.85
            } else if(day==='Sunday') {
                totalPrice=(people*10.46)*0.85
            }
        }
        else{
            if(day==='Friday') {
                totalPrice =(people*8.45)
            } else if(day==='Saturday') {
                totalPrice=(people*9.80)
            } else if(day==='Sunday') {
                totalPrice=(people*10.46)
            }
        }
    } else if (type === 'Business') {
        if(people>=100){
            let free = Math.floor(people/10)
            if(day==='Friday') {
                totalPrice=((people-free)*10.90)
            } else if(day==='Saturday') {
                totalPrice=((people-free)*15.60)
            } else if(day==='Sunday') {
                totalPrice=((people-free)*16.00)
            }
        }
        else{
            if(day==='Friday') {
                totalPrice=(people*10.90)
            } else if(day==='Saturday') {
                totalPrice=(people*15.60)
            } else if(day==='Sunday') {
                totalPrice=(people*16.00)
            }
        }
    } else if (type === 'Regular') {
        if(people>=10 && people<=20){
            if(day==='Friday') {
                totalPrice=((people*15)*0.95)
            } else if(day==='Saturday') {
                totalPrice=((people*20)*0.95)
            } else if(day==='Sunday') {
                totalPrice=((people*22.50)*0.95)
            }
        }
        else{
            if(day==='Friday') {
                totalPrice=(people*15)
            } else if(day==='Saturday') {
                totalPrice=(people*20)
            } else if(day==='Sunday') {
                totalPrice=(people*22.50)
            }
        }
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`)
}

vacantion(30,"Students","Sunday")
vacantion(40,"Regular","Saturday")