function loadRepos() {
   let reposElement = document.querySelector('#res');

   fetch('https://api.github.com/users/testnakov/repos')
      .then(res => res.json())
      .then(repos => reposElement.textContent = repos);


}