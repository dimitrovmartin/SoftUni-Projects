import { html } from "../../node_modules/lit-html/lit-html.js";
import { createSubmitHandler } from "../util.js";
import * as userService from '../api/user.js';

const loginTemplate = (onSubmit) => html`<section id="loginPage">
<form @submit=${onSubmit}>
    <fieldset>
        <legend>Login</legend>

        <label for="email" class="vhide">Email</label>
        <input id="email" class="email" name="email" type="text" placeholder="Email">

        <label for="password" class="vhide">Password</label>
        <input id="password" class="password" name="password" type="password" placeholder="Password">

        <button type="submit" class="login">Login</button>

        <p class="field">
            <span>If you don't have profile click <a href="#">here</a></span>
        </p>
    </fieldset>
</form>
</section>
`;

export function loginPage(ctx) {
  ctx.render(loginTemplate(createSubmitHandler(ctx, onSubmit)));
}

async function onSubmit(ctx, data, event){
    await  userService.login(data.email, data.password);
    event.target.reset();
    ctx.page.redirect('/');
}