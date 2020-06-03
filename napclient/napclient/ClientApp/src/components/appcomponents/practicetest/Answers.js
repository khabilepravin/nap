import React, { useState, useEffect } from "react";
import { CustomInput } from "reactstrap";

const Answers = (props) => {
  let answersList = props.answers.map((answer) => {
    return (<div key={answer.id}>
      <CustomInput      
        type="radio"
        id={answer.id}
        label={answer.text}
        className="mb-2 h4"
        onChange={() => props.onAnswerSelected(answer.id, answer.isCorrect)}
        value={props.answerId}     
        checked={props.selectedAnswer === answer.id}
      />
    </div>);
  });

  return <>{answersList}</>;
};

export default Answers;
