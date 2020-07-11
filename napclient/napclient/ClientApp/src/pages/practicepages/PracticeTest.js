import React, { useState, useEffect } from "react";
import { useQuery, useMutation, useLazyQuery } from "@apollo/react-hooks";
import { GET_TEST, GET_USERTEST_RECORD } from "../../apiproxy/queries";
import { ADD_USER_TEST_RECORD } from "../../apiproxy/mutations";
import { Link } from "react-router-dom";
import Question from "../../components/appcomponents/practicetest/Question";
import TestProgress from "../../components/appcomponents/practicetest/TestProgress";
import Timer from "../../components/appcomponents/practicetest/Timer";
import TestActionButtons from "../../components/appcomponents/practicetest/TestActionButtons";
import PracticeTestService from "../../apiproxy/practiceTestService";

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
import QuestionService from "../../apiproxy/questionService";

const PracticeTest = ({ history, match }) => {
  const { userTestId } = match.params;
  const [currentQuestionIndex, setcurrentQuestionIndex] = useState(0);
  const [percentage, setPercentage] = useState(1);
  const [canProcced, setCanProcced] = useState(false);
  const [userAnswer, setUserAnswer] = useState(null);
  const [questionImage, setQuestionImage] = useState();
  const { loading, error, data } = useQuery(GET_TEST, {
    variables: { userTestId: userTestId },
  });

  const [getUserTestRecord] = useLazyQuery(GET_USERTEST_RECORD, {
    fetchPolicy: "network-only",
    onCompleted: (data) => {
      if(data.userTestRecord){
        setCanProcced(true);
        setUserAnswer(data.userTestRecord.answerId);
      }
    },
  });

  const [addUserTestRecord] = useMutation(ADD_USER_TEST_RECORD, {
    onCompleted({ addUserTestRecord }) {},
  });

  const incrementQuestionIndex = () => {
    if(currentQuestionIndex === (data.testByUserTestId.questions.length -1)) {
      history.push(`/practicepages/testresult/${userTestId}`);
    }
    else {
      setcurrentQuestionIndex(currentQuestionIndex + 1);
      setCanProcced(false);
    }
  };

  const decrementQuestionIndex = () => {
    setcurrentQuestionIndex(currentQuestionIndex - 1);
  };

  useEffect(() => {
    if (data) {
      calculatePercentage();
      getUserTestRecord({
        variables: {
          userTestId: userTestId,
          questionId: data.testByUserTestId.questions[currentQuestionIndex].id,
        },
      });
      loadQuestionImage(data.testByUserTestId.questions[currentQuestionIndex].id);
    }
  }, [currentQuestionIndex]);

  useEffect(() => {
    if (data) {
      calculatePercentage();
      loadQuestionImage(data.testByUserTestId.questions[0].id);
    }
  }, [data]);

  const calculatePercentage = () => {
    setPercentage(
      (100 * (currentQuestionIndex + 1)) /
        data.testByUserTestId.questions.length
    );
  };

  const loadQuestionImage = (questionId) => {
    QuestionService.getQuestionImage(questionId).then((res) => {
      if (res.data) {
        setQuestionImage(
          `data:${res.data.imageFileType};base64, ${res.data.base64ImageData}`
        );
      } else {
        setQuestionImage(null);
      }
    });
  };

  const handleOnAnswered = (answer) => {
    if(answer.answerId)
    {
      setUserAnswer(answer.answerId);
      addUserTestRecord({
        variables: {
          userTestRecord: {
            userTestId: userTestId,
            questionId: data.testByUserTestId.questions[currentQuestionIndex].id,
            answerId: answer.answerId,
            isCorrect: answer.isCorrect,
          },
        },
      });   
      setCanProcced(true); 
    }
    else if(answer.answerText){
      PracticeTestService.postUserTestTextRecord(
        {
          "userTestId":userTestId,
          "questionId":data.testByUserTestId.questions[currentQuestionIndex].id,
          "userAnswerText":answer.answerText
        }
      ).then((result) => {

      });
      setCanProcced(true); 
    }
    else{
      setCanProcced(false); 
    }    
  };

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
        <p>Error loading test: {error}</p>
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
              selectedAnswer={userAnswer}
              onAnswered={handleOnAnswered}
              questionImage={questionImage}
            />
            <TestActionButtons
              currentQuestionIndex={currentQuestionIndex}
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
