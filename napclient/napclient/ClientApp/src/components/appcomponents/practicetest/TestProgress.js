import React, { useState, useEffect } from "react";
import { Progress } from "reactstrap";

const TestProgress = (props) => {
    // const [currentQuestionIndex, setCurrentQuestionIndex] = useState(props.currentQuestionIndex);
    // const [currentPercentage, setCurrentPercentage] = useState(0);
    
    // useEffect(() => {
    //     console.log('side effect ')
    //     calculatePercentage();
    //   }, [currentQuestionIndex]);

    // const calculatePercentage = () => {
    //     setCurrentPercentage(
    //       (100 * (currentQuestionIndex + 1)) /
    //         props.totalQuestions
    //     );
    // };
    

    return (
    <Progress striped value={props.percentage} className="mb-3">
        Test Progress
    </Progress>
    );
};

export default TestProgress;