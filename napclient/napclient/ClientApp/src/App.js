import React from "react";
import { Provider } from "react-redux";
import ReduxToastr from "react-redux-toastr";

import store from "./redux/store/index";
import Routes from "./routes/Routes";

class App extends React.Component {
  componentDidMount() {
    // Remove `active` className from `.splash` element in `public/index.html`
    !document.querySelector(".splash") ||
      document.querySelector(".splash").classList.remove("active");
  }

  render() {
    return (
      <Provider store={store}>
        <Routes />
        <ReduxToastr
          timeOut={5000}
          newestOnTop={true}
          position="top-right"
          transitionIn="fadeIn"
          transitionOut="fadeOut"
          progressBar
          closeOnToastrClick
        />
      </Provider>
    );
  }
}

export default App;
