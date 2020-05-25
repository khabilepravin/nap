import React from "react";
import Answers from "./Answers";

const Question = (props) => (
    <>
        <h3>{props.question.text}</h3>
        <Answers answers={props.question.answers}/>
    </>
);

export default Question;