function solve(arr = []) {
    let resultArr = [];

    for (let index = 1; index <= arr.length; index += 2) {
        resultArr.push(arr[index]);
    }

    resultArr= resultArr.map(x => x * 2);

    resultArr = resultArr.reverse();

    console.log(resultArr.join(' '));
}

solve([10, 15, 20, 25]);