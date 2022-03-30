import { html } from "../../node_modules/lit-html/lit-html.js";
import * as albumsService from "../api/albums.js";

const detailsTemplate = (album, onDelete) => html`<section id="detailsPage">
<div class="wrapper">
    <div class="albumCover">
        <img src="${album.imgUrl}">
    </div>
    <div class="albumInfo">
        <div class="albumText">

            <h1>Name: ${album.name}</h1>
            <h3>Artist: ${album.artist}</h3>
            <h4>Genre: ${album.genre}</h4>
            <h4>Price: $${album.price}</h4>
            <h4>Date: ${album.releaseDate}</h4>
            <p>Description: ${album.description}</p>
        </div>

        <!-- Only for registered user and creator of the album-->
        <div class="actionBtn">
            ${album.isOwner ? html`<a href="/edit/${album._id}" class="edit">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)"class="remove">Delete</a>`: null}
        </div>
    </div>
</div>
</section> `;

export async function detailsPage(ctx) {
  const albumId = ctx.params.id;
  const album = await albumsService.getById(albumId);

  if (ctx.user) {
    album.isOwner = ctx.user._id == album._ownerId;
  }

  ctx.render(detailsTemplate(album, onDelete));

  async function onDelete() {
    const choice = confirm("Are you sure you want to delete this album?");

    if (choice) {
      await albumsService.deleteById(albumId);
      ctx.page.redirect("/");
    }
  }
}
