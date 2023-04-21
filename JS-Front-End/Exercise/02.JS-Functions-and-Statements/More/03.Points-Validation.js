function points(numbers){

    const isValid = (x1, y1, x2, y2) => Number.isInteger(Math.sqrt((x2 - x1)**2 + (y2 - y1)**2))

    console.log(isValid(numbers[0], numbers[1], 0, 0) ? `{${numbers[0]}, ${numbers[1]}} to {0, 0} is valid` : `{${numbers[0]}, ${numbers[1]}} to {0, 0} is invalid`)
    console.log(isValid(0, 0, numbers[2], numbers[3]) ? `{${numbers[2]}, ${numbers[3]}} to {0, 0} is valid` : `{${numbers[2]}, ${numbers[3]}} to {0, 0} is invalid`)
    console.log(isValid(numbers[0], numbers[1], numbers[2], numbers[3]) ? `{${numbers[0]}, ${numbers[1]}} to {${numbers[2]}, ${numbers[3]}} is valid` : `{${numbers[0]}, ${numbers[1]}} to {${numbers[2]}, ${numbers[3]}} is invalid`)
}   

points([2,1,1,1])