import { html } from "../../node_modules/lit-html/lit-html.js";
import { createSubmitHandler } from "../util.js";
import * as commentsService from '../api/comments.js';

const commentsTemplate = (comments) => html`
<!-- Bonus ( for Guests and Users ) -->
<div class="details-comments">
      <h2>Comments:</h2>
      ${comments.length > 0 ? html`<ul>${comments.map(commentCard)}</ul>` : html`<p class="no-comment">No comments.</p>`}
      <!-- Display paragraph: If there are no games in the database -->
    </div>
`

const commentCard = (comment) => html`<li class="comment">
<p>Content: ${comment.comment}</p>
</li>`

export async function commentsView(gameId){
    const comments = await commentsService.getByGameId(gameId);
    return commentsTemplate(comments);
}