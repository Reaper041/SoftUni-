window.addEventListener('load', solution);

function solution() {
  let fullNameElement = document.querySelector('#fname');
  let emailElement = document.querySelector('#email');
  let phoneNumberElement = document.querySelector('#phone');
  let addressElement = document.querySelector('#address');
  let postCodeElement = document.querySelector('#code');

  let submitButtonElement = document.querySelector('#submitBTN');
  let editButtonElement = document.querySelector('#editBTN');
  let continueButtonElement = document.querySelector('#continueBTN');
  let liFullNameElement;
  let liEmailElement;
  let liPhoneNumElement;
  let liAddressElement;
  let liPostCodeElement;

  let ulElement = document.querySelector('#infoPreview')

  submitButtonElement.addEventListener('click', (e) => {
    e.preventDefault();

    if (fullNameElement.value && emailElement.value) {
      liFullNameElement = document.createElement('li');
      liEmailElement = document.createElement('li');
      liPhoneNumElement = document.createElement('li');
      liAddressElement = document.createElement('li');
      liPostCodeElement = document.createElement('li');


      liFullNameElement.textContent = `Full Name: ${fullNameElement.value}`;
      ulElement.appendChild(liFullNameElement);
      fullNameElement.value = '';

      liEmailElement.textContent = `Email: ${emailElement.value}`;
      ulElement.appendChild(liEmailElement);
      emailElement.value = '';

      liPhoneNumElement.textContent = `Phone Number: ${phoneNumberElement.value}`;
      ulElement.appendChild(liPhoneNumElement);
      phoneNumberElement.value = '';

      liAddressElement.textContent = `Address: ${addressElement.value}`;
      ulElement.appendChild(liAddressElement);
      addressElement.value = '';

      liPostCodeElement.textContent = `Postal Code: ${postCodeElement.value}`;;
      ulElement.appendChild(liPostCodeElement);
      postCodeElement.value = '';

      submitButtonElement.disabled = true;
      editButtonElement.disabled = false;
      continueButtonElement.disabled = false;
    }
  })


  editButtonElement.addEventListener('click', (e) => {
    e.preventDefault();

    fullNameElement.value = liFullNameElement.textContent.split(': ')[1].trim();
    emailElement.value = liEmailElement.textContent.split(': ')[1].trim();
    phoneNumberElement.value = liPhoneNumElement.textContent.split(': ')[1].trim();
    addressElement.value = liAddressElement.textContent.split(': ')[1].trim();
    postCodeElement.value = liPostCodeElement.textContent.split(': ')[1].trim();

    ulElement.removeChild(liFullNameElement);
    ulElement.removeChild(liEmailElement);
    ulElement.removeChild(liPhoneNumElement);
    ulElement.removeChild(liAddressElement);
    ulElement.removeChild(liPostCodeElement);


    submitButtonElement.disabled = false;
    editButtonElement.disabled = true;
    continueButtonElement.disabled = true;
  })


  continueButtonElement.addEventListener('click', (e) => {
    let blockDiv = document.querySelector('#block');
    blockDiv.innerHTML = '';
 
    let h3 = document.createElement('h3');
    h3.textContent = 'Thank you for your reservation!';
    blockDiv.appendChild(h3);
  })
}