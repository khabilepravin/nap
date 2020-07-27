import React, { useState } from "react";
import { CustomInput } from "reactstrap";
import Image from "./Image";
import {
  Input
} from "reactstrap";

const Answers = React.memo((props) => {
  //const[userAnswerText, setUserAnswerText] = useState(props.selectedAnswerText);
  // Returns a function, that, as long as it continues to be invoked, will not
  // be triggered. The function will be called after it stops being called for
  // `wait` milliseconds.
  const debounce = (func, wait) => {
    let timeout;

    return function executedFunction(...args) {
      const later = () => {
        timeout = null;
        func(...args);
      };

      clearTimeout(timeout);
      timeout = setTimeout(later, wait);
    };
  };


  const answerEnteredDebounce = debounce((e) =>{
    props.onAnswerSelected({ answerText:e });
  }, 1000);

  const handleInputEntered = (e) => {    
    //setUserAnswerText(e.target.value);
    answerEnteredDebounce(e.target.value);    
  }  

  if (props.answerContext.questionType === "single") {
    
    let answersList = props.answerContext.answers.map((answer) => {
      return (
        <div key={answer.id}>
          <CustomInput
            type="radio"
            id={answer.id}
            label={answer.text}
            className="mb-2 h4"
            onChange={() => props.onAnswerSelected({ answerId: answer.id, isCorrect: answer.isCorrect })}
            value={props.answerContext.answerId}
            checked={props.selectedAnswer === answer.id}
          />
        </div>
      );
    });

    return <>{answersList}</>;
  } else if (props.answerContext.questionType === "text") {
    return <Input type="text" placeholder="Answer here" onKeyUp={handleInputEntered} defaultValue={props.selectedAnswerText}/>;
  }
});

export default Answers; 
