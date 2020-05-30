import React, { useState, useEffect } from "react";
import { useQuery } from "@apollo/react-hooks";
import { GET_TEST } from "../../apiproxy/queries";
import { Link } from "react-router-dom";
import Question from "../../components/appcomponents/practicetest/Question";
import TestProgress from "../../components/appcomponents/practicetest/TestProgress";
import Timer from "../../components/appcomponents/practicetest/Timer";
import TestActionButtons from "../../components/appcomponents/practicetest/TestActionButtons";

import {
  Breadcrumb,
  BreadcrumbItem,
  Card,
  CardBody,
  CardHeader,
  CardTitle,
  Container,
} from "reactstrap";

import Header from "../../components/themecomponents/Header";
import HeaderTitle from "../../components/themecomponents/HeaderTitle";

const PracticeTest = ({ history, match }) => {
  let { userTestId } = match.params;
  const [currentQuestionIndex, setcurrentQuestionIndex] = useState(0);
  const [percentage, setPercentage] = useState(1);
  const [canProcced, setCanProcced] = useState(false);
  const { loading, error, data } = useQuery(GET_TEST, {
    variables: { userTestId: userTestId },
  });

  const incrementQuestionIndex = () => {
    setcurrentQuestionIndex(currentQuestionIndex + 1);
    setCanProcced(false);
  };

  const decrementQuestionIndex = () => {
    setcurrentQuestionIndex(currentQuestionIndex - 1);
  };

  useEffect(() => {
    if (data) {
      // Update the document title using the browser API
      calculatePercentage();
    }
  });

  const calculatePercentage = () => {
    setPercentage(
      (100 * (currentQuestionIndex + 1)) /
        data.testByUserTestId.questions.length
    );
  };

  const handleOnAnswered = () => {
    setCanProcced(true);
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
            <CardTitle tag="h5">
              {data.testByUserTestId.text}{" "}
              <Timer minutes={data.testByUserTestId.durationMinutes} />
            </CardTitle>
          </CardHeader>
          <CardBody>
            <TestProgress percentage={percentage} />
            <Question
              question={data.testByUserTestId.questions[currentQuestionIndex]}
              userTestId={userTestId}
              onAnswered={handleOnAnswered}
            />
            <TestActionButtons currentQuestionIndex={currentQuestionIndex} 
                    totalQuestions={data.testByUserTestId.questions.length}
                    onNextClick={incrementQuestionIndex}
                    onPreviousClick={decrementQuestionIndex}
                    canProcced={canProcced}
            />
          </CardBody>
        </Card>
      </Container>
    );
  }
};

export default PracticeTest;
