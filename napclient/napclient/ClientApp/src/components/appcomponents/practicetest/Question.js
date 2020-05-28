import React from "react";
import Answers from "./Answers";
import gql from "graphql-tag";
import { useQuery } from "@apollo/react-hooks";

const GET_USERTEST_RECORD = gql`query($userTestId:ID!, $questionId:ID!){
    userTestRecord(userTestId: $userTestId, questionId: $questionId){
        questionId
        userTestId
        answerId
        isCorrect
    }
}`;

const Question = (props) => {
    const { loading, error, data } = useQuery(GET_USERTEST_RECORD,        
        {
            variables: { userTestId: props.userTestId, questionId: props.question.id },
            fetchPolicy: "network-only"
        });
    
    return <>
        <h3>{props.question.text}</h3>
        <Answers answers={props.question.answers}/>
    </>
};

export default Question;