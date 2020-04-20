import React from "react";

import { Col, Container, Row } from "reactstrap";

import Main from "../components/Main";

const Auth = ({ children }) => (
  <React.Fragment>
    <Main className="h-100 w-100">
      <Container className="h-100">
        <Row className="h-100">
          <Col sm="10" md="8" lg="6" className="mx-auto d-table h-100">
            <div className="d-table-cell align-middle">{children}</div>
          </Col>
        </Row>
      </Container>
    </Main>
  </React.Fragment>
);

export default Auth;
