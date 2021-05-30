function solve(arr = []) {
    let evenElementsArr = []

    for (let index = 0; index < arr.length; index += 2) {
        evenElementsArr.push(arr[index])       
    }

    console.log(evenElementsArr.join(' '))
}

solve(['20', '30', '40', '50', '60']);