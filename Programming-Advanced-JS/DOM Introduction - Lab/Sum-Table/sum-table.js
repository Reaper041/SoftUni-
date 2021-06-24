function sumTable() {
    let tableDataElements = document.querySelectorAll('tr td:nth-child(2)');
    let sum = 0;

    for (let index = 0; index < tableDataElements.length - 1; index++) {
        sum += Number(tableDataElements[index].textContent);
    }

    tableDataElements[tableDataElements.length - 1].textContent = sum;
}