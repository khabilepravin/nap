import React, { useState, useEffect } from "react";
import { Progress } from "reactstrap";

const TestProgress = (props) => {
    return (
    <Progress striped value={props.percentage} className="mb-3">
        Test Progress
    </Progress>
    );
};

export default TestProgress;