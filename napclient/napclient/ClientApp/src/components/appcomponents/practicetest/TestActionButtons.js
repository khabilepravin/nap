import React from "react";
import { faArrowRight, faCheckSquare, faArrowLeft } from "@fortawesome/free-solid-svg-icons";
import {  Button } from "reactstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const TestActionButtons = (props) => {
  let questionText = props.currentQuestionIndex === (props.totalQuestions-1) ? "Done" : "Next";
  let nextQuestionIcon = questionText === "Next" ? faArrowRight : faCheckSquare;
  let nextQuestionClass = questionText === "Next" ? "primary" : "success";
  return (
    <>
      <Button
        type="submit"
        color={nextQuestionClass}
        className="mr-1 mb-1 float-right"
        onClick={props.onNextClick}
      >
        {questionText}{"  "}
        <FontAwesomeIcon
          icon={nextQuestionIcon}
        />
      </Button>
      {props.currentQuestionIndex == 0 ? null : (
        <Button
          type="button"
          color="warning"
          className="mr-1 mb-1 float-right"
          onClick={props.onPreviousClick}
        >
          <FontAwesomeIcon icon={faArrowLeft} />  Previous
        </Button>
      )}
    </>
  );
};

export default TestActionButtons;