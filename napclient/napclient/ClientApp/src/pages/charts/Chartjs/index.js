import React from "react";
import { Link } from "react-router-dom";

import { Breadcrumb, BreadcrumbItem, Col, Container, Row } from "reactstrap";

import Header from "../../../components/Header";
import HeaderTitle from "../../../components/HeaderTitle";

import Line from "./Line";
import Bar from "./Bar";
import Doughnut from "./Doughnut";
import Pie from "./Pie";
import Radar from "./Radar";
import Polar from "./Polar";

const Chartjs = () => (
  <Container fluid>
    <Header>
      <HeaderTitle>Chart.js</HeaderTitle>

      <Breadcrumb>
        <BreadcrumbItem>
          <Link to="/dashboard">Dashboard</Link>
        </BreadcrumbItem>
        <BreadcrumbItem>
          <Link to="/dashboard">Charts</Link>
        </BreadcrumbItem>
        <BreadcrumbItem active>Chart.js</BreadcrumbItem>
      </Breadcrumb>
    </Header>

    <Row>
      <Col lg="6">
        <Line />
      </Col>
      <Col lg="6">
        <Bar />
      </Col>
      <Col lg="6">
        <Doughnut />
      </Col>
      <Col lg="6">
        <Pie />
      </Col>
      <Col lg="6">
        <Radar />
      </Col>
      <Col lg="6">
        <Polar />
      </Col>
    </Row>
  </Container>
);

export default Chartjs;
