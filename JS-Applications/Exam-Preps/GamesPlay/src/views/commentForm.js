import { html } from "../../node_modules/lit-html/lit-html.js";
import { createSubmitHandler } from "../util.js";
import * as commentsService from '../api/comments.js';


const formTemplate = (onSubmit) => html`
<!-- Bonus -->
  <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
  <article class="create-comment">
    <label>Add new comment:</label>
    <form @submit=${onSubmit}class="form">
      <textarea name="comment" placeholder="Comment......"></textarea>
      <input class="btn submit" type="submit" value="Add Comment" />
    </form>
  </article>
`

export function commentFormView(ctx, gameId){
    if (ctx.user){
        return formTemplate(createSubmitHandler(ctx, onSubmit));
    }
}

async function onSubmit(ctx, data, event){
    const gameId = ctx.params.id;
    data.gameId = gameId;
    await commentsService.postComment(data);
    event.target.reset();
    ctx.page.redirect(`/details/${gameId}`)
}