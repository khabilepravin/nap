import React from "react";
import { faArrowRight, faCheckSquare, faArrowLeft } from "@fortawesome/free-solid-svg-icons";
import {  Button, Row, Col } from "reactstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const TestActionButtons = React.memo((props) => {
  let questionText = props.currentQuestionIndex === (props.totalQuestions-1) ? "Done" : "Next";
  let nextQuestionIcon = questionText === "Next" ? faArrowRight : faCheckSquare;
  let nextQuestionClass = questionText === "Next" ? "primary" : "success";
  return (
    <>
    <br/>
    <Row>
      <Col md="12">
      <Button
        type="submit"
        color={nextQuestionClass}
        className="mr-1 mb-1 float-right"
        onClick={props.onNextClick}
        disabled={props.canProcced ? false : true}
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
      </Col>
    </Row>
    </>
  );
});

export default TestActionButtons;