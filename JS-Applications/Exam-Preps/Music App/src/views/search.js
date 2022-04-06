import { html, render } from "../../node_modules/lit-html/lit-html.js";
import * as albumsService from "../api/albums.js";

const searchTemplate = (onClick) => html`<section id="searchPage">
<h1>Search by Name</h1>

<div class="search">
    <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
    <button @click=${onClick} class="button-list">Search</button>
</div>

<h2>Results:</h2>

<!--Show after click Search button-->
<div class="search-result">
    <!--If have matches-->
    

    <!--If there are no matches-->
</div>
</section>`;

const cardTemplate = (album, user) => html`
<div class="card-box">
        <img src="${album.imgUrl}">
        <div>
            <div class="text-center">
                <p class="name">Name: ${album.name}</p>
                <p class="artist">Artist: ${album.artist}</p>
                <p class="genre">Genre: ${album.genre}</p>
                <p class="price">Price: $${album.price}</p>
                <p class="date">Release Date: ${album.releaseDate}</p>
            </div>
            <div class="btn-group">
             ${user? html`<a href="/details/${album._id}" id="details">Details</a>`:null}
        </div>
        </div>
    </div>`

export function searchPage(ctx) {
  ctx.render(searchTemplate(() => onClick(ctx.user)));
}   

async function onClick(user){
    const albumName = document.getElementById('search-input').value;
    const albums = await albumsService.search(albumName);

    const list = document.querySelector('.search-result');

    if(albums.length > 0) {
        render(albums.map(x => cardTemplate(x, user)), list);
    } else{
    
    render(html`<p class="no-result">No result.</p>`, list);
    }
}
