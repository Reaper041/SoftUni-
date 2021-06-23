function calc() {
    let firstNumElement = document.querySelector('#num1');
    let secondNumElement = document.querySelector('#num2');
    let resultElement = document.querySelector('#sum');

    let firstNum = Number(firstNumElement.value);
    let secondNum = Number(secondNumElement.value);
    let sum = firstNum + secondNum;

    console.log(firstNum);
    console.log(secondNum);
    console.log(sum);
    
    resultElement.value = sum;
}
