import { html } from "../../node_modules/lit-html/lit-html.js";

const guestLinks = html`
  <li><a href="#">Login</a></li>
  <li><a href="#">Register</a></li>
`;

const userLinks = html`
  <li><a href="#">Create Album</a></li>
  <li><a href="#">Logout</a></li>
`;

const navigationTemplate = (isAuthenticated) => html`
  <nav>
    <img src="./images/headphones.png" />
    <a href="#">Home</a>
    <ul>
      <!--All user-->
      <li><a href="#">Catalog</a></li>
      <li><a href="#">Search</a></li>
      ${isAuthenticated ? userLinks : guestLinks}
    </ul>
  </nav>
`;

export const navigationView = (ctx) => {
  return navigationTemplate();
};
