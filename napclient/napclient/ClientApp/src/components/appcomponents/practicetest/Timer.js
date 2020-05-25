import React,{useState, useEffect} from 'react';

const Timer = (props) => {
  const [timeLeft, setMinutes] = useState(props.minutes);

  useEffect(() => {
    const interval = setInterval(() => {
      setMinutes(timeLeft => timeLeft - 1);
    }, 1000);
    return () => clearInterval(interval);
  }, []);
      
      return <div>{timeLeft}</div>
};

export default Timer;