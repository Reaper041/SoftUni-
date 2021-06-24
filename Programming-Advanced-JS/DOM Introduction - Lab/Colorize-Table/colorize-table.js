function colorize() {
    let evenTableRowElements = document.querySelectorAll('table tr');

    for (let index = 1; index < evenTableRowElements.length; index += 2) {
        evenTableRowElements[index].style.backgroundColor = 'Teal';        
    }
}