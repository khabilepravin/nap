import React,{useState, useEffect} from "react";
import gql from "graphql-tag";
import { useQuery } from "@apollo/react-hooks";

import { Link } from "react-router-dom";
import Question from "../../components/appcomponents/practicetest/Question";
import TestProgress from "../../components/appcomponents/practicetest/TestProgress";
import Timer from "../../components/appcomponents/practicetest/Timer";

import { faArrowRight, faArrowLeft } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

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

const GET_TEST = gql`query($userTestId: ID!){
  testByUserTestId(userTestId:$userTestId){
    id
    text
    description
    durationMinutes
    questions{
      id
      text
      description
      questionType
    	answers{
        id
        text
        isCorrect
        description
      }
    }
  }
}`;

const PracticeTest = ({ history, match }) => {
  let {userTestId} = match.params;
  const [currentQuestionIndex, setcurrentQuestionIndex] = useState(0);
  const [percentage, setPercentage] = useState(1);
  const { loading, error, data } = useQuery(GET_TEST, { variables: { userTestId:userTestId  }});
  
  const incrementQuestionIndex = () =>{
    setcurrentQuestionIndex(currentQuestionIndex+1);
  }

  const decrementQuestionIndex = () => {
    setcurrentQuestionIndex(currentQuestionIndex-1); 
  }

  useEffect(() => {
    if(data){
    // Update the document title using the browser API
      calculatePercentage();
    }
  });

  const calculatePercentage = () => {
    setPercentage((100 * (currentQuestionIndex+1)) / data.testByUserTestId.questions.length);
  }

  if (loading) {
    return (
      <div>
        <p>Loading</p>
      </div>
    );
  }

  if (error) {
    return (
      <div>
        <p>There was an error</p>
      </div>
    );
  }

  if (data) { 
    return (
      <Container fluid>
        <Header>
          <HeaderTitle>Practice</HeaderTitle>
          <Breadcrumb>
            <BreadcrumbItem>
              <Link to="/dashboard">Dashboard</Link>
            </BreadcrumbItem>
            <BreadcrumbItem active>Practice Test</BreadcrumbItem>
          </Breadcrumb>
        </Header>
        <Card>
          <CardHeader>
            <CardTitle tag="h5">{data.testByUserTestId.text} <Timer minutes={data.testByUserTestId.durationMinutes}/></CardTitle>
          </CardHeader>
          <CardBody>
              <TestProgress percentage={percentage} />             
              <Question question={data.testByUserTestId.questions[currentQuestionIndex]} />
              <Button type="submit" color="primary" className="mr-1 mb-1 float-right" onClick={incrementQuestionIndex}>
                Next <FontAwesomeIcon icon={faArrowRight} />
              </Button>
              {
                currentQuestionIndex == 0 ? null :
                <Button type="button" color="warning" className="mr-1 mb-1 float-right" onClick={decrementQuestionIndex}>
                      <FontAwesomeIcon icon={faArrowLeft} /> Previous
                </Button>
              }              
          </CardBody>
        </Card>
      </Container>
    );
  }
};

export default PracticeTest;
