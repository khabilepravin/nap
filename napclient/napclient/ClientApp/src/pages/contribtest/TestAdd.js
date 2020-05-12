import React from "react";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import * as Yup from 'yup';

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

const ADD_TEST = gql`
  mutation($test: TestInput!) {
    createTest(test: $test) {
      text
      description
      year
      subject
    }
  }
`;

const TestAdd = () => {
  const [addTest] = useMutation(ADD_TEST);
  const { register, handleSubmit } = useForm(); // initialise the hook  
  const onSubmit = (data) => {   
    addTest({variables: { test: data } });
  };  

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
              <Form onSubmit={handleSubmit(onSubmit)}>
                    <FormGroup>
                      <Label>Name</Label>
                      <Input
                        type="text"
                        name="text"
                        placeholder="Name"
                        innerRef={register}
                      />
                    </FormGroup>
                    <FormGroup>
                      <Label>Description</Label>
                      <Input
                        type="textarea"
                        name="description"
                        placeholder="Description"
                        rows="1"
                        innerRef={register}
                      />
                    </FormGroup>
                    <FormGroup>
                      <Label>Subject</Label>
                      <Input
                        type="select"
                        id="exampleCustomSelect"
                        name="subject"
                        className="mb-3"
                        innerRef={register}
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
                        name="year"
                        className="mb-3"
                        innerRef={register}
                      >
                        <option value="">Select Year</option>
                        <option>3</option>
                        <option>4</option>
                        <option>5</option>
                      </Input>
                    </FormGroup>
                    <Button type="submit" color="primary">Add</Button>
                  </Form>                    
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};

export default TestAdd;
