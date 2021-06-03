function solve(arr = []) {
    arr.sort((a, b) => a - b)

    let biggerHalf = arr.slice(arr.length / 2);

    return biggerHalf;
}

solve([3, 19, 14, 7, 2, 19, 6]);