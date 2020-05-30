import React from 'react';
import {
    CustomInput
} from "reactstrap";

const Answers = (props) => {
    let answersList =  props.answers.map((answer, index) => (
      <div key={answer.id}>
        <CustomInput
        type="radio"
        id={answer.id}
        name="answers"
        label={answer.text}
        className="mb-2 h4"
        onChange={() => props.onAnswerSelected(answer.id, answer.isCorrect)}
      />      
      </div>
      ));

      return (
        <>
            {answersList}
        </>
      );

    };

export default Answers;