function solve(arr = []) {
    let solveArr = [];

    for (let index = 0; index < 2; index++) {
        
    let minValue = Number.MAX_SAFE_INTEGER;
    let minIndex = 0;
    
        for (const el of arr) {
            if (el < minValue) {
                minValue = el;
                minIndex = arr.indexOf(el);
            }
        }
    
        solveArr.push(minValue);
        arr.splice(minIndex, 1);
    }
    
    console.log(solveArr.join(' '));
}

solve([30, 15, 50, 5])