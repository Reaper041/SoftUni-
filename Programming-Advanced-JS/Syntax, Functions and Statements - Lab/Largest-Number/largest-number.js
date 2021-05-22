function solve(num1, num2, num3) {
    let largest;
    if (num1 < num2) {
        if (num2 < num3) {
            largest = num3
        }
        else {
            largest = num2;
        }
    }
    else {
        if (num3 < num1) {
            largest = num1;   
        }
        else {
            largest = num3;
        }
    }

    console.log(`The largest number is ${largest}.`);
}

solve(5, -3, 16)