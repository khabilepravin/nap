import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { Button } from "reactstrap";

const LoginButton = () => {
  const { loginWithRedirect, isAuthenticated } = useAuth0();

  if (isAuthenticated) {
    return <></>;
  } else {
    return (
      <Button
        color="success"
        target="_blank"
        rel="noreferrer noopener"
        className="my-2 ml-2 btn-pill"
        onClick={() => loginWithRedirect()}
      >
        Login
      </Button>
    );
  }
};

export default LoginButton;
