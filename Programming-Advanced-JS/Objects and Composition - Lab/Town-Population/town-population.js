function solve(towns = []) {
    const objectTowns = {};

    for (let index = 0; index < towns.length; index++) {
        const [name, population] = towns[index].split(' <-> ');

        if (objectTowns[name]) {
            objectTowns[name] += Number(population);
        } else {
            objectTowns[name] = Number(population);
        }
    
    }

    for (const town in objectTowns) {
        console.log(`${town} : ${objectTowns[town]}`);
    }
}

solve(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
);