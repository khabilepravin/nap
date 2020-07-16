import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { Button } from "reactstrap";

const LogoutButton = () => {
  const { logout, isAuthenticated } = useAuth0();

  if (isAuthenticated) {
    return (
      <Button
        color="warning"
        target="_blank"
        rel="noreferrer noopener"
        className="my-2 ml-2 btn-pill"
        onClick={() => logout()}
      >
        Log Out
      </Button>
    );
  } else {
    return <></>;
  }
};

export default LogoutButton;
