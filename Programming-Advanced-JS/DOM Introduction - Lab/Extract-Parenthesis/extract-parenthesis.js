function extract(content) {
    let elementToExtractFrom = document.querySelector(`#${content}`);

    let text = elementToExtractFrom.textContent;
    let regexp = new RegExp('\\(([A-Za-z ]+)\\)', 'g')
    let words = text.match(regexp);
    let result = '';

    for (const word of words) {
        result += word.substring(1, word.length - 1) + '; ';
    }

    return result;
}   