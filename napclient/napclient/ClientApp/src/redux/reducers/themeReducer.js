import * as types from "../constants";

const themes = {
  modern: {
    primary: "#3B7DDD",
    secondary: "#6f42c1",
    tertiary: "#669ae5",
    success: "#28a745",
    info: "#20c997",
    warning: "#fd7e14",
    danger: "#dc3545",
    dark: "#153d77"
  },
  classic: {
    primary: "#38C485",
    secondary: "#5C59ED",
    tertiary: "#41D492",
    success: "#a877b5",
    info: "#00bcd4",
    warning: "#F2B51D",
    danger: "#F26666",
    dark: "#203A45"
  },
  dark: {
    primary: "#687ae8",
    secondary: "#95aac9",
    tertiary: "#95aac9",
    success: "#0c9",
    info: "#19b5fe",
    warning: "#f7bc06",
    danger: "#f2545b",
    dark: "#28304e"
  },
  light: {
    primary: "#3B7DDD",
    secondary: "#6f42c1",
    tertiary: "#669ae5",
    success: "#28a745",
    info: "#20c997",
    warning: "#fd7e14",
    danger: "#dc3545",
    dark: "#153d77"
  }
};

const initialState = {
  currentTheme: themes.modern,
  themes: themes
};

export default function reducer(state = initialState, actions) {
  switch (actions.type) {
    case types.THEME_TOGGLE:
      return {
        ...state,
        currentTheme: state.themes[actions.payload]
      };

    default:
      return state;
  }
}
