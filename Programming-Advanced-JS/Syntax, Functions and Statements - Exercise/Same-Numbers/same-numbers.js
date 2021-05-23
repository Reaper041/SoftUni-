function solve(number) {

    let stringNumber = number.toString();
    let firstDigit = stringNumber[0];
    let flag = true;
    let sum = 0

    for (let index = 0; index < stringNumber.length; index++) {
        if (!(firstDigit === stringNumber[index])) {
            flag = false;
        }

        sum += Number(stringNumber[index]);
    }

    console.log(flag);
    console.log(sum)
}

solve(1234);