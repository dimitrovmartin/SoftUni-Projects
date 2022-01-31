function getArticleGenerator(articles) {
    let div = document.getElementById('content');

    return function showNext() {
        if (articles.length) {
            let article = document.createElement('article');
            article.textContent = articles.shift();
            div.appendChild(article);
        }
    }
}