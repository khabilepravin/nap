import React from "react";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import * as Yup from 'yup';
import {ADD_TEST} from "../../apiproxy/mutations";
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
import { faSave, faCross, faWindowClose } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const schema = Yup.object().shape({
  text: Yup.string().required('Name is required'),
  description: Yup.string().required('Description is required'),
  subject: Yup.string().required('Subject is required'),
  durationMinutes: Yup.number().required('Duration minutes'),
  year: Yup.string().required('Year is required'),
});


const TestAdd = ({history}) => {
  const [addTest] = useMutation(ADD_TEST, {
    onCompleted(){
      reset();
      history.push('/testpages/testlist');
    }
  });
  const { register, handleSubmit, reset, errors } = useForm({
    validationSchema: schema
  });
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
            <Link to="/testpages/testlist">Tests</Link>
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
                      {errors.text && <p className="text-danger">{errors.text.message}</p>}
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
                       {errors.description && <p className="text-danger">{errors.description.message}</p>}
                    </FormGroup>
                    <FormGroup>
                      <Label>Duration Minutes</Label>
                      <Input
                        type="number"
                        name="durationMinutes"
                        placeholder="Duration Minutes"
                        innerRef={register}
                      />
                       {errors.durationMinutes && <p className="text-danger">{errors.durationMinutes.message}</p>}
                    </FormGroup>
                    <FormGroup>
                      <Label>Subject</Label>
                      <Input
                        type="select"
                        id="exampleCustomSelect"
                        name="subject"
                        className="mb-3"
                        innerRef={register}>
                        <option value="">Select Subject</option>
                        <option>Math</option>
                        <option>English</option>
                        <option>Geo</option>
                      </Input>
                      {errors.subject && <p className="text-danger">{errors.subject.message}</p>}
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
                      {errors.year && <p className="text-danger">{errors.year.message}</p>}
                    </FormGroup>
                    <Button type="submit" color="primary" className="mr-1 mb-1">
                    <FontAwesomeIcon icon={faSave} /> Save</Button>
                    <Button type="button" color="warning" className="mr-1 mb-1" 
                    onClick={() => history.push("/testpages/testlist") }>
                      <FontAwesomeIcon icon={faWindowClose} /> Cancel</Button>
                  </Form>                    
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};

export default TestAdd;
