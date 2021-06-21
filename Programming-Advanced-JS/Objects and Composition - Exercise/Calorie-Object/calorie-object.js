function solve(arr = []) {
    let result = {};

    for (let index = 0; index < arr.length - 1; index++) {
        if (index % 2 == 0) {
            result[arr[index]] = Number(arr[index + 1]);
        }        
    }

    console.log(result);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);