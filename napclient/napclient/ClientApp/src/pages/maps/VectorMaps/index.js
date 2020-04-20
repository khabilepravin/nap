import React from "react";
import { Link } from "react-router-dom";

import { Breadcrumb, BreadcrumbItem, Col, Container, Row } from "reactstrap";

import Header from "../../../components/Header";
import HeaderTitle from "../../../components/HeaderTitle";

import World from "./World";
import Africa from "./Africa";
import Asia from "./Asia";
import Europe from "./Europe";
import NorthAmerica from "./NorthAmerica";
import Oceania from "./Oceania";
import SouthAmerica from "./SouthAmerica";
import USA from "./USA";
import UK from "./UK";
import China from "./China";
import India from "./India";

const VectorMaps = () => (
  <Container fluid>
    <Header>
      <HeaderTitle>Vector Maps</HeaderTitle>

      <Breadcrumb>
        <BreadcrumbItem>
          <Link to="/dashboard">Dashboard</Link>
        </BreadcrumbItem>
        <BreadcrumbItem>
          <Link to="/dashboard">Maps</Link>
        </BreadcrumbItem>
        <BreadcrumbItem active>Vector Maps</BreadcrumbItem>
      </Breadcrumb>
    </Header>

    <World />
    <Row>
      <Col lg="6">
        <Africa />
      </Col>
      <Col lg="6">
        <Asia />
      </Col>
      <Col lg="6">
        <Europe />
      </Col>
      <Col lg="6">
        <NorthAmerica />
      </Col>
      <Col lg="6">
        <Oceania />
      </Col>
      <Col lg="6">
        <SouthAmerica />
      </Col>
      <Col lg="6">
        <USA />
      </Col>
      <Col lg="6">
        <UK />
      </Col>
      <Col lg="6">
        <China />
      </Col>
      <Col lg="6">
        <India />
      </Col>
    </Row>
  </Container>
);

export default VectorMaps;
