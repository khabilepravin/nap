import React from "react";
import Answers from "./Answers";
import Image from "./Image";

const Question = React.memo((props) => {
  const answerSelected = (answerId, isCorrect) => {
      props.onAnswered(answerId, isCorrect);
  }

  return (
     <>
      <h3 dangerouslySetInnerHTML={{__html: props.question.text}}></h3>
      <Image imageSource={props.questionImage}/>
      <Answers
        answers={props.question.answers}
        selectedAnswer={props.selectedAnswer}
        onAnswerSelected={answerSelected}
      />
    </>
  );
});

export default Question;
