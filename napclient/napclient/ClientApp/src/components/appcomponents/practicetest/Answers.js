import React from 'react';
import {
    CustomInput
} from "reactstrap";
import {
    AvRadioGroup,
    AvRadio,
  } from "availity-reactstrap-validation";
  
const Answers = (props) => {
    let answersList = props.answers.map((answer, index) => (
      <div key={answer.text}>
        <CustomInput
        type="radio"
        id={index}
        
        name="answers"
        label={answer.text}
        className="mb-2 h4"
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