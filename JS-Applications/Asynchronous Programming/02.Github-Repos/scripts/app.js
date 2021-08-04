function loadRepos() {
	let reposListElement = document.querySelector('#repos');
	let usernameInputElement = document.querySelector('#username');

	reposListElement.innerHTML = '';

	fetch(`https://api.github.com/users/${usernameInputElement.value}/repos`)
		.then(res => res.json())
		.then(res => res.forEach(repo => {
			let listItemElement = document.createElement('li');
			let linkElement = document.createElement('a');

			linkElement.setAttribute('href', repo['html_url']);
			linkElement.textContent = repo['full_name'];

			listItemElement.appendChild(linkElement);
			reposListElement.appendChild(listItemElement)
		}));


}