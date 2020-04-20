import React from "react";
import { Link } from "react-router-dom";
import ReactQuill from "react-quill";

import {
  Breadcrumb,
  BreadcrumbItem,
  Card,
  CardBody,
  CardHeader,
  CardTitle,
  Container
} from "reactstrap";

import Header from "../../components/Header";
import HeaderTitle from "../../components/HeaderTitle";

const Quill = () => (
  <Card>
    <CardHeader>
      <CardTitle tag="h5">Quill</CardTitle>
      <h6 className="card-subtitle text-muted">
        Modern WYSIWYG editor built for compatibility and extensibility.
      </h6>
    </CardHeader>
    <CardBody>
      <ReactQuill placeholder="Type something" />
    </CardBody>
  </Card>
);

const Bubble = () => (
  <Card>
    <CardHeader>
      <CardTitle tag="h5">Bubble</CardTitle>
      <h6 className="card-subtitle text-muted">
        Bubble is a simple tooltip based theme for Quill.
      </h6>
    </CardHeader>
    <CardBody>
      <ReactQuill theme="bubble" placeholder="Compase an epic..." />
    </CardBody>
  </Card>
);

const Editors = () => (
  <Container fluid>
    <Header>
      <HeaderTitle>Editors</HeaderTitle>

      <Breadcrumb>
        <BreadcrumbItem>
          <Link to="/dashboard">Dashboard</Link>
        </BreadcrumbItem>
        <BreadcrumbItem>
          <Link to="/dashboard">Forms</Link>
        </BreadcrumbItem>
        <BreadcrumbItem active>Editors</BreadcrumbItem>
      </Breadcrumb>
    </Header>

    <Quill />
    <Bubble />
  </Container>
);

export default Editors;
