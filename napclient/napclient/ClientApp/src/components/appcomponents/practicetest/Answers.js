import React from "react";
import { CustomInput } from "reactstrap";
import Image from "./Image";

const Answers = React.memo((props) => {
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
      <Image imageSource={props.answerImage}/>
    </div>);
  });

  return <>{answersList}</>;
});

export default Answers;
