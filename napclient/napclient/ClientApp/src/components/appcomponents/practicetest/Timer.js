import React,{useState, useEffect} from 'react';

const Timer = (props) => {
    const [timer, setState] = useState(props.minutes);

    // useEffect(() => {
    //     const timer = setTimeout(() => {
    //      setState(timer-1);
    //     }, 1000);
    //     return () => clearTimeout(timer);
    //   }, []);
      
      return <div>{timer}</div>
};

export default Timer;