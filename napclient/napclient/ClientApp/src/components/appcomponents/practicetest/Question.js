import React, { useState } from "react";
import Answers from "./Answers";
import { GET_USERTEST_RECORD } from "../../../apiproxy/queries";
import { useQuery } from "@apollo/react-hooks";

const Question = (props) => {
  // const { loading, error, data } = useQuery(GET_USERTEST_RECORD, {
  //   variables: { userTestId: props.userTestId, questionId: props.question.id },
  //   fetchPolicy: "network-only",
  // });

   
  //const[selectedAnswer, setSelectedAnswer]= useState();

  const answerSelected = (answerId, isCorrect) => {
      //setSelectedAnswer(answerId);
      props.onAnswered(answerId, isCorrect);
  }

  // if(data){
  //       setSelectedAnswer(data.userTestRecord ? data.userTestRecord.answerId : "");
  // }

  //console.log(props.userTestRecord);
  return (
     <>
      <h3>{props.question.text}</h3>

      <Answers
        answers={props.question.answers}
        selectedAnswer={props.selectedAnswer}
        onAnswerSelected={answerSelected}
      />
    </>
  );
};

export default Question;
