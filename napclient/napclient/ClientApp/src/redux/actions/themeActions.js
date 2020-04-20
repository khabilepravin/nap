import * as types from "../constants";

import { toggleTheme } from "../../services/themeService";

export function enableModernTheme() {
  return enableTheme("modern");
}

export function enableClassicTheme() {
  return enableTheme("classic");
}

export function enableDarkTheme() {
  return enableTheme("dark");
}

export function enableLightTheme() {
  return enableTheme("light");
}

function enableTheme(name) {
  toggleTheme(name);

  return {
    type: types.THEME_TOGGLE,
    payload: name
  };
}
