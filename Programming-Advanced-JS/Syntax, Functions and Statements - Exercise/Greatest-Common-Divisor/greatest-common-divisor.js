function solve(num1, num2) {
    let divider = Math.max(num1, num2);

    while (!(num1 % divider === 0 && num2 % divider === 0)) {
        divider--;
    }

    console.log(divider)
}

solve(2154, 458);