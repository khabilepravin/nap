import React from "react";
import { Link } from "react-router-dom";
import { useFormik } from "formik";

import gql from "graphql-tag";
import { useMutation } from "@apollo/react-hooks";
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
} from "reactstrap";

import Header from "../../components/themecomponents/Header";
import HeaderTitle from "../../components/themecomponents/HeaderTitle";

const ADD_TODO = gql`
  mutation($test: TestInput!) {
    createTest(test: $test) {
      text
      description
      year
      subject
    }
  }
`;

const onAddFormSubmit = (event) => {
  event.preventDefault();
  console.log("comes here");
};

const TestAdd = () => {
  const formik = useFormik({
    initialValues: {
      text: '',
      description: '',
      subject: '',
      year: 0,
    },
    onSubmit: (values) => {
     // alert(JSON.stringify(values));
     
    },
  });

  return (
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
              <Form onSubmit={formik.handleSubmit}>
                <FormGroup>
                  <Label>Name</Label>
                  <Input
                    type="text"
                    name="text"
                    placeholder="Name"
                    onChange={formik.handleChange}
                    value={formik.values.text}
                  />
                </FormGroup>
                <FormGroup>
                  <Label>Description</Label>
                  <Input
                    type="textarea"
                    name="textarea"
                    placeholder="Description"
                    rows="1"
                    onChange={formik.handleChange}
                    value={formik.values.description}
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
                <FormGroup>
                  <Label>Year</Label>
                  <Input
                    type="select"
                    id="exampleCustomSelect"
                    name="customSelect"
                    className="mb-3"
                  >
                    <option value="">Select Year</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
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
};

export default TestAdd;
