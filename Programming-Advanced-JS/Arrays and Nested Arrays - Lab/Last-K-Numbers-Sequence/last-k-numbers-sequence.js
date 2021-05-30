function solve(n, k) {
    let arr = []
    arr.push(1);

    while (arr.length != n) {
        let sum = 0;

        for (let index = arr.length - 1; index >= arr.length - k; index--) {
            if (index < 0) {
                break;
            }

            sum += arr[index]
        }

        arr.push(sum);
    }

    return arr;
}

solve(8, 2);