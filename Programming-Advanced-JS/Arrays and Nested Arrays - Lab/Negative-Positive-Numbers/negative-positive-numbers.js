function solve(arr = []) {
    let newArr = [];

    for (const el of arr) {
        if (el < 0) {
            newArr.unshift(el);
        }
    }

    for (const el of arr) {
        if (el >= 0) {
        newArr.push(el)
        }
    }


    for (const el of newArr) {
        console.log(el);
    }
}


solve([7, -2, 8, 9]);