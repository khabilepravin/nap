import React from "react";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import * as Yup from 'yup';
import { ADD_ANSWER } from "../../apiproxy/mutations";
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
  CustomInput
} from "reactstrap";

import Header from "../../components/themecomponents/Header";
import HeaderTitle from "../../components/themecomponents/HeaderTitle";
import { faSave, faCross, faWindowClose } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { toastr } from "react-redux-toastr";

const schema = Yup.object().shape({
  questionId: Yup.string().required('QuestionId is required'),
  text: Yup.string().required('Name is required'),
  description: Yup.string().required('Description is required'),
  sequence: Yup.string().required('Sequence is required'),
  type: Yup.string().required('Answer Type is required'),
});


const AnswerAdd = ({history, match}) => {
  let {questionId} = match.params;
  const [addAnswer] = useMutation(ADD_ANSWER,{
    onCompleted({ answer }){
      reset();
      showToastr('Success', 'Answer added successfully');
    }
  });
  const { register, handleSubmit, reset, errors } = useForm({
    validationSchema: schema
  });
  const onSubmit = (data) => {   
    addAnswer({variables: { answer: data } });
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
        <HeaderTitle>Add Answer</HeaderTitle>
        <Breadcrumb>
          <BreadcrumbItem>
            <Link to="/dashboard">Dashboard</Link>
          </BreadcrumbItem>
          <BreadcrumbItem>
            <Link to="/testpages/testlist/">Answer</Link>
          </BreadcrumbItem>
          <BreadcrumbItem active>Add Answer</BreadcrumbItem>
        </Breadcrumb>
      </Header>
      <Row>
        <Col>
          <Card>
            <CardHeader>
              <CardTitle tag="h5" className="mb-0">
                Add New Answer
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
                      <Label>Answer Type</Label>
                       <Input
                        type="select"
                        id="type"
                        name="type"
                        className="mb-3"
                        innerRef={register}>
                        <option value="">Answer Type</option>
                        <option value="image">Image</option>
                        <option value="single">Single</option>
                        <option value="multi">Multi</option>
                        <option value="text">Text</option>
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
                      {errors.description && <p className="text-danger">{errors.description.message}</p>}
                    </FormGroup>
                    <FormGroup>
                    <CustomInput
                            type="checkbox"
                            id="isCorrect"
                            name="isCorrect"
                            label="Is The Right Answer"
                            innerRef={register}
                            className="mb-2"
                        />   
                    </FormGroup>
                    <Input type="hidden"
                           id="questionId"
                           name="questionId"
                           value={questionId}
                           innerRef={register}
                    ></Input>
                    <Button type="submit" color="primary" className="mr-1 mb-1">
                    <FontAwesomeIcon icon={faSave} /> Save</Button>
                    <Button type="button" color="warning" className="mr-1 mb-1" 
                    onClick={() => history.push(`/testpages/answerslist/${questionId}`) }>
                      <FontAwesomeIcon icon={faWindowClose} /> Cancel</Button>
                  </Form>                    
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};

export default AnswerAdd;
