function toggle() {
    let extraTextElement = document.querySelector('#extra');
    let buttonElement = document.querySelector('span.button')

    if (buttonElement.textContent == 'More') {
        extraTextElement.style.display = 'block';
        buttonElement.textContent = 'Less';
    }
    else {
        extraTextElement.style.display = 'none';
        buttonElement.textContent = 'More';
    }
}