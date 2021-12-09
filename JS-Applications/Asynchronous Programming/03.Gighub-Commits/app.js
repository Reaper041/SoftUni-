function loadCommits() {
    let repoElement = document.querySelector('#repo');
    let usernameInputElement = document.querySelector('#username');
    let commitsListElement = document.querySelector('#commits');

    fetch(`https://api.github.com/repos/${usernameInputElement.value}/${repoElement.value}/commits`)
        .then(res => res.json())
        .then(res => res.forEach(commit => {
            let listItemElement = document.createElement('li');

            listItemElement.textContent = `${commit.commit.author.name}: ${commit.commit.message}`

            commitsListElement.appendChild(listItemElement)
        }))
        .catch(error => {
            let listItemElement = document.createElement('li');

            listItemElement.textContent = `${error}`
            
            commitsListElement.appendChild(listItemElement)
        });

}   