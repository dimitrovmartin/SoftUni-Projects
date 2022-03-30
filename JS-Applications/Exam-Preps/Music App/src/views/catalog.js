import { html } from "../../node_modules/lit-html/lit-html.js";

import * as albumsService from "../api/albums.js";

const catalogTemplate = (albums, user) => html`<section id="catalogPage">
<h1>All Albums</h1>
${albums.length > 0 ? albums.map(x => cardTemplate(x, user)) : html`<p>No Albums in Catalog!</p>
`}
<!--No albums in catalog-->

</section>
`;

const cardTemplate = (album, user) => html`<div class="card-box">
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
        ${user? html`<a href="/details/${album._id}" id="details">Details</a>`: null}
    </div>
</div>
</div>`;

export async function catalogPage(ctx) {
  const albums = await albumsService.getAll();
  ctx.render(catalogTemplate(albums, ctx.user));
}
