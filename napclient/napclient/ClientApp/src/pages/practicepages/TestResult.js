import React from "react";
import { Link } from "react-router-dom";

import {
  Breadcrumb,
  BreadcrumbItem,
  Card,
  CardBody,
  CardHeader,
  CardTitle,
  Container,
  Button,
} from "reactstrap";

import Header from "../../components/themecomponents/Header";
import HeaderTitle from "../../components/themecomponents/HeaderTitle";

const TestResult = ({ history, match }) => {
    return (
      <Container fluid>
        <Header>
          <HeaderTitle>Results</HeaderTitle>
          <Breadcrumb>
            <BreadcrumbItem>
              <Link to="/dashboard">Dashboard</Link>
            </BreadcrumbItem>
            <BreadcrumbItem active>Test Results</BreadcrumbItem>
          </Breadcrumb>
        </Header>
        <Card>
          <CardHeader>
            <CardTitle tag="h2">Results</CardTitle>
          </CardHeader>
          <CardBody>
            <h1> results...</h1>
          </CardBody>
        </Card>
      </Container>
    );
};

export default TestResult;
