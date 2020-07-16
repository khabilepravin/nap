import React, { useEffect } from "react";
import { Provider } from "react-redux";
import ReduxToastr from "react-redux-toastr";

import store from "./redux/store/index";
import Routes from "./routes/Routes";
//import { useAuth0 } from "./react-auth0-spa";

import { ApolloProvider } from '@apollo/react-hooks';
import ApolloClient from 'apollo-boost';

const client = new ApolloClient({
    uri: process.env.REACT_APP_GRAPHQL_ENDPOINT
});


const App = () => {
  //const { loading } =  useAuth0();

  useEffect(()=>{
    !document.querySelector(".splash") ||
    document.querySelector(".splash").classList.remove("active");
  },[]);
  // componentDidMount() {
  //   // Remove `active` className from `.splash` element in `public/index.html`
  //   !document.querySelector(".splash") ||
  //     document.querySelector(".splash").classList.remove("active");
  // }

  
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
  
};

export default App;
