function solve(arr = []) {
    let result = [];

    for (let index = 0; index < arr.length; index++) {

        let objArr = arr[index].split(' / ');

        let items = objArr[2] !== undefined ? objArr[2].split(', ') : [];

        let obj = {
            name: objArr[0],
            level: Number(objArr[1]),
            items: items
        }

        result.push(obj);
    }

    return JSON.stringify(result);
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
));

