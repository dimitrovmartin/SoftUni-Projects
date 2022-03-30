import { html } from "../../node_modules/lit-html/lit-html.js";
import * as booksService from "../api/books.js";
import * as likesService from "../api/likes.js";

const detailsTemplate = (user, isLiked, book, onDelete, onLike, allLikes) => html`<section
  id="details-page"
  class="details"
>
  <div class="book-information">
    <h3>${book.title}</h3>
    <p class="type">Type: ${book.type}</p>
    <p class="img"><img src="${book.imageUrl}" /></p>
    <div class="actions">
      <!-- Edit/Delete buttons ( Only for creator of this book )  -->
      ${user && user._id == book._ownerId
        ? html`<a class="button" href="/edit/${book._id}">Edit</a>
            <a class="button" @click=${onDelete} href="javascript:void(0)"
              >Delete</a
            >`
        : null}

      <!-- Bonus -->
      <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
      ${user && !isLiked
        ? html`<a class="button like-button" @click=${onLike} href="javascript:void(0)"
            >Like</a
          >`
        : null}

      <!-- ( for Guests and Users )  -->
      <div class="likes">
        <img class="hearts" src="/images/heart.png" />
        <span id="total-likes">Likes: ${allLikes}</span>
      </div>
      <!-- Bonus -->
    </div>
  </div>
  <div class="book-description">
    <h3>Description:</h3>
    <p>${book.description}</p>
  </div>
</section> `;

export async function detailsPage(ctx) {
  const bookId = ctx.params.id;
  const book = await booksService.getById(bookId);
  const allLikes = await likesService.getLikesByBookId(bookId);
  let isLiked = undefined;

  if (ctx.user) {
    isLiked = await likesService.isLiked(bookId, ctx.user._id);
  }

 

  ctx.render(detailsTemplate(ctx.user, isLiked, book, onDelete, onLike, allLikes));
  async function onDelete() {
    const choice = confirm("Are you sure you want to delete this book?");

    if (choice) {
      await booksService.deleteById(bookId);
      ctx.page.redirect("/");
    }
  }

  async function onLike() {
    await likesService.like(bookId);
    ctx.page.redirect(`/details/${bookId}`);
  }
}
