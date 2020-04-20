import React from "react";
import { Link } from "react-router-dom";

import { Breadcrumb, BreadcrumbItem, Col, Container, Row } from "reactstrap";

import Header from "../../../components/Header";
import HeaderTitle from "../../../components/HeaderTitle";

import Default from "./Default";
import Hybrid from "./Hybrid";
import LightStyle from "./LightStyle";
import DarkStyle from "./DarkStyle";
import Streetview from "./Streetview";
import Markers from "./Markers";

const GoogleMaps = () => (
  <Container fluid>
    <Header>
      <HeaderTitle>Google Maps</HeaderTitle>

      <Breadcrumb>
        <BreadcrumbItem>
          <Link to="/dashboard">Dashboard</Link>
        </BreadcrumbItem>
        <BreadcrumbItem>
          <Link to="/dashboard">Maps</Link>
        </BreadcrumbItem>
        <BreadcrumbItem active>Google Maps</BreadcrumbItem>
      </Breadcrumb>
    </Header>

    <Row>
      <Col lg="6">
        <Default />
      </Col>
      <Col lg="6">
        <Hybrid />
      </Col>
      <Col lg="6">
        <LightStyle />
      </Col>
      <Col lg="6">
        <DarkStyle />
      </Col>
      <Col lg="6">
        <Streetview />
      </Col>
      <Col lg="6">
        <Markers />
      </Col>
    </Row>
  </Container>
);

export default GoogleMaps;
