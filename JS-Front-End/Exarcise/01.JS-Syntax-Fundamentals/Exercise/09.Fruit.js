function calculate(fruit,grams,price){
    console.log(`I need $${((grams/1000)*price).toFixed(2)} to buy ${(grams/1000).toFixed(2)} kilograms ${fruit}.`)
}

calculate('orange', 2500, 1.80)
calculate('apple', 1563, 2.35)