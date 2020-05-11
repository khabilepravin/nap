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
  Row,
  Form,
  FormGroup,
  Input,
  Label,
  Button,
  CustomInput,
} from "reactstrap";

import Header from "../../components/themecomponents/Header";
import HeaderTitle from "../../components/themecomponents/HeaderTitle";

const TestAdd = () => (
  <Container fluid>
    <Header>
      <HeaderTitle>Add Test</HeaderTitle>

      <Breadcrumb>
        <BreadcrumbItem>
          <Link to="/dashboard">Dashboard</Link>
        </BreadcrumbItem>
        <BreadcrumbItem>
          <Link to="/contribtest/testadd">Tests</Link>
        </BreadcrumbItem>
        <BreadcrumbItem active>Add</BreadcrumbItem>
      </Breadcrumb>
    </Header>

    <Row>
      <Col>
        <Card>
          <CardHeader>
            <CardTitle tag="h5" className="mb-0">
              Add New Test
            </CardTitle>
          </CardHeader>
          <CardBody>
            <Form>
              <FormGroup>
                <Label>Name</Label>
                <Input type="text" name="email" placeholder="Name" />
              </FormGroup>
              <FormGroup>
                <Label>Description</Label>
                <Input
                  type="textarea"
                  name="textarea"
                  placeholder="Textarea"
                  rows="1"
                />
              </FormGroup>
              <FormGroup>
                <Label>Subject</Label>
                <Input
                  type="select"
                  id="exampleCustomSelect"
                  name="customSelect"
                  className="mb-3"
                >
                  <option value="">Select Subject</option>
                  <option>Math</option>
                  <option>English</option>
                  <option>Geo</option>
                </Input>
              </FormGroup>

              <Button color="primary">Submit</Button>
            </Form>
          </CardBody>
        </Card>
      </Col>
    </Row>
  </Container>
);

export default TestAdd;
