import React from "react";
import { Provider } from "react-redux";
import ReduxToastr from "react-redux-toastr";

import store from "./redux/store/index";
import Routes from "./routes/Routes";

import { ApolloProvider } from '@apollo/react-hooks';
import ApolloClient from 'apollo-boost';

const client = new ApolloClient({
    uri: 'https://localhost:44331/graphql'
});


class App extends React.Component {
  componentDidMount() {
    // Remove `active` className from `.splash` element in `public/index.html`
    !document.querySelector(".splash") ||
      document.querySelector(".splash").classList.remove("active");
  }

  render() {
    return (
      <ApolloProvider client={client}>
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
      </ApolloProvider>
    );
  }
}

export default App;
