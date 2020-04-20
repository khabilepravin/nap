import React from "react";
import { Link } from "react-router-dom";

import {
  Breadcrumb,
  BreadcrumbItem,
  Card,
  CardBody,
  CardHeader,
  CardTitle,
  Col,
  Container,
  Row
} from "reactstrap";

import Header from "../../components/Header";
import HeaderTitle from "../../components/HeaderTitle";

const Blank = () => (
  <Container fluid>
    <Header>
      <HeaderTitle>Blank Page</HeaderTitle>

      <Breadcrumb>
        <BreadcrumbItem>
          <Link to="/dashboard">Dashboard</Link>
        </BreadcrumbItem>
        <BreadcrumbItem>
          <Link to="/dashboard">Blank</Link>
        </BreadcrumbItem>
        <BreadcrumbItem active>Blank Page</BreadcrumbItem>
      </Breadcrumb>
    </Header>

    <Row>
      <Col>
        <Card>
          <CardHeader>
            <CardTitle tag="h5" className="mb-0">
              Empty card
            </CardTitle>
          </CardHeader>
          <CardBody>
            <div className="my-5">&nbsp;</div>
          </CardBody>
        </Card>
      </Col>
    </Row>
  </Container>
);

export default Blank;
