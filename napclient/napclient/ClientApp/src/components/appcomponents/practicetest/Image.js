import React from 'react';

const Image = React.memo((props) => {
    if(props.imageSource && props.imageSource.length > 0){
        return <img src={props.imageSource} className="img-thumbnail rounded mr-2 mb-2"/>
    }
    else{
        return <></>
    }
});

export default Image;