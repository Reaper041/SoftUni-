function subtract() {
    let firstNum = Number(document.querySelector('#firstNumber').value);
    let secondNum = Number(document.querySelector('#secondNumber').value);
    let subtractValue = firstNum - secondNum;

    let resultElement = document.querySelector('div #result');
    resultElement.textContent = subtractValue;

}