function extractText() {
    let listElements = document.querySelectorAll('#items li')
    let textAreaElement = document.getElementById('result');
    let result = '';

    for (const listElement of listElements) {
        result += listElement.textContent + '\n';
    }

    textAreaElement.value = result;
}