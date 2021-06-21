function solve(obj = {}) {
    const smallEngine = { power: 90, volume: 1800 };
    const normalEngine = { power: 120, volume: 2400 };
    const monsterEngine = { power: 200, volume: 3500 };
    const hatchback = { type: 'hatchback', color: '' };
    const coupe = { type: 'coupe', color: '' };

    result = {};
    result.model = obj.model;

    if (obj.power <= 90) {
        result.engine = smallEngine;
    } else if (obj.power <= 120) {
        result.engine == normalEngine;
    } else if (obj.power <= 200) {
        result.engine = monsterEngine;
    }

    if (obj.carriage == 'hatchback') {
        result.carriage = hatchback;
    }
    else {
        result.carriage = coupe;
    }

    result.carriage.color = obj.color;

    if (obj.wheelsize % 2 == 0) {
        obj.wheelsize -= 1;
    }

    result.wheels = [obj.wheelsize, obj.wheelsize, obj.wheelsize, obj.wheelsize];

    return result;
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));


