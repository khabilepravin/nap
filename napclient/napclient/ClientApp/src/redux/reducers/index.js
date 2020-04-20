import { combineReducers } from "redux";

import sidebar from "./sidebarReducers";
import theme from "./themeReducer";

import { reducer as toastr } from "react-redux-toastr";

export default combineReducers({
  sidebar,
  theme,
  toastr
});
