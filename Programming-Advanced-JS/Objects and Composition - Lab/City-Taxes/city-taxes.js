function solve(name, population, treasury) {
    const cityRecord = {
        name: name,
        population: population,
        treasury: treasury,
        taxRate: 10,
        collectTaxes: function () { treasury += population * taxRate },
        applyGrowth: function (percentage) { population += Math.floor(population * percentage / 100) },
        applyRecession: function (percentage) { treasury -= Math.floor(treasury * percentage / 100) }
    }

    return cityRecord;
}

console.log(solve('Tortuga',
7000,
15000));

solve('Tortuga',
7000,
15000
)