import page from '../node_modules/page/page.mjs';
import { logout } from './api/user.js';
import { addRender } from './middlewares/render.js';
import { addSession } from './middlewares/session.js';
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';

import * as api from './api/comments.js';

window.api = api;

page(addSession);
page(addRender);

page('/', homePage);
page('/catalog', catalogPage);
page('/login', loginPage);
page('/register', registerPage);
page('/create', createPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/logout', onLogout);

page.start();

function onLogout(ctx){
    logout();
    ctx.page.redirect('/');
}