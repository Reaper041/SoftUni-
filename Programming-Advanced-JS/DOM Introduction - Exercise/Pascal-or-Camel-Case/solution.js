function solve() {
  let text = document.querySelector('#text').value.toLowerCase();
  let convention = document.querySelector('#naming-convention').value;
  let result = '';

  let words = text.split(' ');

  for (let index = 1; index < words.length; index++) {
    words[index] = words[index][0].toUpperCase() + words[index].slice(1);
  }

  if (convention == 'Camel Case') {
    result = words.join('');
  } else if (convention == 'Pascal Case') {
    words[0] = words[0][0].toUpperCase() + words[0].slice(1);
    result = words.join('');
  } else {
    result = 'Error!';
  }

  let resultElement = document.querySelector('#result');

  resultElement.textContent = result;
}