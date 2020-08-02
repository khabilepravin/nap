import React from "react";
import Answers from "./Answers";
import Image from "./Image";
import Audio from "./Audio";

const Question = React.memo((props) => {
  const answerSelected = (answer) => {
    props.onAnswered(answer);
  };

  return (
    <>
      <h3 dangerouslySetInnerHTML={{ __html: props.question.text }}></h3>
      <Image imageSource={props.questionImage} />
      <Audio audioSource={props.questionAudio}/>
      <Answers
        answerContext={props.question}
        selectedAnswer={props.selectedAnswer}
        selectedAnswerText={props.selectedAnswerText}
        onAnswerSelected={answerSelected}
      />      
    </>
  );
});

export default Question;
