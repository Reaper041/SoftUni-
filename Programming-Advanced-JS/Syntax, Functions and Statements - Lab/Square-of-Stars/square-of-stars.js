function solve(size) {
    if (typeof size === 'undefined') {
        for (let row = 0; row < 5; row++) {
            console.log('* '.repeat(5))
        }
    }
    else {
        for (let row = 0; row < size; row++) {
            console.log('* '.repeat(size))
        }
    }
    
}

solve();