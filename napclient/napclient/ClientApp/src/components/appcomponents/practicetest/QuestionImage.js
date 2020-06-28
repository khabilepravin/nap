import React from 'react';

const QuestionImage = (props) => {
    if(props.image && props.image.length > 0){
        return <img src={props.image}/>
    }
    else{
        return <></>
    }
};

export default QuestionImage;