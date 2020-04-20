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

const GridText = ({ children }) => (
  <Card className="bg-light py-2 text-center">
    <CardBody>{children}</CardBody>
  </Card>
);

const Grid = () => (
  <Container fluid>
    <Header>
      <HeaderTitle>Grid</HeaderTitle>

      <Breadcrumb>
        <BreadcrumbItem>
          <Link to="/dashboard">Dashboard</Link>
        </BreadcrumbItem>
        <BreadcrumbItem>
          <Link to="/dashboard">UI Elements</Link>
        </BreadcrumbItem>
        <BreadcrumbItem active>Grid</BreadcrumbItem>
      </Breadcrumb>
    </Header>

    <Card>
      <CardHeader>
        <CardTitle tag="h5">Grid system</CardTitle>
        <h6 className="card-subtitle text-muted">
          Powerful mobile-first flexbox grid
        </h6>
      </CardHeader>
      <CardBody>
        <Row>
          <Col md="12">
            <GridText>.col-md-12</GridText>
          </Col>
        </Row>
        <Row>
          <Col md="6">
            <GridText>.col-md-6</GridText>
          </Col>
          <Col md="6">
            <GridText>.col-md-6</GridText>
          </Col>
        </Row>
        <Row>
          <Col md="4">
            <GridText>.col-md-4</GridText>
          </Col>
          <Col md="4">
            <GridText>.col-md-4</GridText>
          </Col>
          <Col md="4">
            <GridText>.col-md-4</GridText>
          </Col>
        </Row>
        <Row>
          <Col md="3">
            <GridText>.col-md-3</GridText>
          </Col>
          <Col md="3">
            <GridText>.col-md-3</GridText>
          </Col>
          <Col md="3">
            <GridText>.col-md-3</GridText>
          </Col>
          <Col md="3">
            <GridText>.col-md-3</GridText>
          </Col>
        </Row>
        <Row>
          <Col md="2">
            <GridText>.col-md-2</GridText>
          </Col>
          <Col md="2">
            <GridText>.col-md-2</GridText>
          </Col>
          <Col md="2">
            <GridText>.col-md-2</GridText>
          </Col>
          <Col md="2">
            <GridText>.col-md-2</GridText>
          </Col>
          <Col md="2">
            <GridText>.col-md-2</GridText>
          </Col>
          <Col md="2">
            <GridText>.col-md-2</GridText>
          </Col>
        </Row>
        <Row>
          <Col md="1">
            <GridText>.col-md-1</GridText>
          </Col>
          <Col md="1">
            <GridText>.col-md-1</GridText>
          </Col>
          <Col md="1">
            <GridText>.col-md-1</GridText>
          </Col>
          <Col md="1">
            <GridText>.col-md-1</GridText>
          </Col>
          <Col md="1">
            <GridText>.col-md-1</GridText>
          </Col>
          <Col md="1">
            <GridText>.col-md-1</GridText>
          </Col>
          <Col md="1">
            <GridText>.col-md-1</GridText>
          </Col>
          <Col md="1">
            <GridText>.col-md-1</GridText>
          </Col>
          <Col md="1">
            <GridText>.col-md-1</GridText>
          </Col>
          <Col md="1">
            <GridText>.col-md-1</GridText>
          </Col>
          <Col md="1">
            <GridText>.col-md-1</GridText>
          </Col>
          <Col md="1">
            <GridText>.col-md-1</GridText>
          </Col>
        </Row>
        <Row>
          <Col md="8">
            <GridText>.col-md-8</GridText>
          </Col>
          <Col md="4">
            <GridText>.col-md-4</GridText>
          </Col>
        </Row>
        <Row>
          <Col md="3">
            <GridText>.col-md-3</GridText>
          </Col>
          <Col md="6">
            <GridText>.col-md-6</GridText>
          </Col>
          <Col md="3">
            <GridText>.col-md-3</GridText>
          </Col>
        </Row>
      </CardBody>
    </Card>
  </Container>
);

export default Grid;
