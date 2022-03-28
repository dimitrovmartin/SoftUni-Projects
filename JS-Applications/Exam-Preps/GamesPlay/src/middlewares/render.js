import { render, html } from "../../node_modules/lit-html/lit-html.js";

const navTemplate = (user) => html`
    <!-- Navigation -->
    <h1><a class="home" href="/">GamesPlay</a></h1>
    <nav>
      <a href="/catalog">All games</a>
      ${user
        ? html`<div id="user">
            <a href="/create">Create Game</a>
            <a href="/logout">Logout</a>
          </div>`
        : html`<div id="guest">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
          </div>`}
    </nav>
`;

const header = document.querySelector('.my-header');
const root = document.getElementById("main-content");

function ctxRender(content) {
  render(content, root);
}

export function addRender(ctx, next) {
  render(navTemplate(ctx.user), header);
  ctx.render = ctxRender;
  next();
}
