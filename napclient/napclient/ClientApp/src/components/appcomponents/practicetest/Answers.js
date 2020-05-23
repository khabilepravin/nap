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
        <CustomInput
        type="radio"
        id={index}
        key={answer.text}
        name="answers"
        label={answer.text}
        className="mb-2"
      />
      ));

      return (
        <>
            {answersList}
        </>
      );

    };

export default Answers;