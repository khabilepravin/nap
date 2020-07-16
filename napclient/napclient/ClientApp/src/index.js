import "react-app-polyfill/ie11";
import "react-app-polyfill/stable";

import React from "react";
import ReactDOM from "react-dom";

import App from "./App";
import { Auth0Provider } from "@auth0/auth0-react";

// Render app in `#root` element
ReactDOM.render(
  <Auth0Provider domain="practest.au.auth0.com" clientId="KGFKtqPKW79uBzOdkOOuW0emU0fonWMl" redirectUri={window.location.origin}>
    <App />
  </Auth0Provider>,
  document.getElementById("root")
);
