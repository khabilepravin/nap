import React from "react";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import * as Yup from 'yup';
import gql from "graphql-tag";
import { useMutation } from "@apollo/react-hooks";
import ReactQuill from "react-quill";
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
import { toastr } from "react-redux-toastr";

const ADD_QUESTION = gql`mutation($question:QuestionInput!){
    addQuestion(question: $question){
      testId
      text
      sequence
      questionType
      description    
    }
  }
`;

const schema = Yup.object().shape({
  testId: Yup.string().required('TestId is required'),
  text: Yup.string().required('Name is required'),
  description: Yup.string().required('Description is required'),
  sequence: Yup.string().required('Sequence is required'),
  questionType: Yup.string().required('Question Type is required'),
});


const QuestionAdd = ({history, match}) => {
  let {testId} = match.params;
  const [addQuestion] = useMutation(ADD_QUESTION,{
    onCompleted({ question }){
      reset();
      showToastr('Success', 'Question added successful');
    }
  });
  const { register, handleSubmit, reset, errors } = useForm({
    validationSchema: schema
  });
  const onSubmit = (data) => {   
    addQuestion({variables: { question: data } });
};  

const showToastr =(title, message) => {
  const options = {
    timeOut: parseInt(3000),
    showCloseButton: false,
    progressBar: true,
    position: 'top-right'
  };

  const toastrInstance =toastr.success;
  toastrInstance(
    title,
    message,
    options
  );
};

  return (
    <Container fluid>
      <Header>
        <HeaderTitle>Add Question</HeaderTitle>
        <Breadcrumb>
          <BreadcrumbItem>
            <Link to="/dashboard">Dashboard</Link>
          </BreadcrumbItem>
          <BreadcrumbItem>
            <Link to="/testpages/testlist/">Test</Link>
          </BreadcrumbItem>
          <BreadcrumbItem active>Add Question</BreadcrumbItem>
        </Breadcrumb>
      </Header>
      <Row>
        <Col>
          <Card>
            <CardHeader>
              <CardTitle tag="h5" className="mb-0">
                Add New Question
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
                      <Label>Sequence</Label>
                      <Input
                        type="number"
                        name="sequence"
                        placeholder="Sequence"
                        rows="1"
                        innerRef={register}
                      />
                       {errors.sequence && <p className="text-danger">{errors.sequence.message}</p>}
                    </FormGroup>
                    <FormGroup>
                      <Label>Question Type</Label>
                       <Input
                        type="select"
                        id="questionTypeSelect"
                        name="questionType"
                        className="mb-3"
                        innerRef={register}>
                        <option value="">Question Type</option>
                        <option value="multi">Multi Select</option>
                        <option value="single">Single Select</option>
                        <option value="text">Text</option>
                        <option value="image">Image</option>
                      </Input>
                      {errors.questionType && <p className="text-danger">{errors.questionType.message}</p>}
                    </FormGroup>
                    <FormGroup>
                      <Label>Description</Label>
                      <Input
                        type="textarea"
                        id="description"
                        name="description"
                        className="mb-3"
                        innerRef={register}>
                      </Input>
                      {/* <ReactQuill placeholder="Description"
                      id="description"
                      name="description"
                      innerRef={register}
                      value={}
                       /> */}
                      {errors.description && <p className="text-danger">{errors.description.message}</p>}
                    </FormGroup>
                    <Input type="hidden"
                           id="testId"
                           name="testId"
                           value={testId}
                           innerRef={register}
                    ></Input>
                    <Button type="submit" color="primary" className="mr-1 mb-1">
                    <FontAwesomeIcon icon={faSave} /> Save</Button>
                    <Button type="button" color="warning" className="mr-1 mb-1" 
                    onClick={() => history.push(`/testpages/questionslist/${testId}`) }>
                      <FontAwesomeIcon icon={faWindowClose} /> Cancel</Button>
                  </Form>                    
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};

export default QuestionAdd;
