import React, { Component, PureComponent } from "react";

export default class Timer extends PureComponent {
  constructor(props) {
    super(props);

  }
  state = {
      minutes: this.props.minutes,
      seconds: 0,
  }

  componentDidMount() {
      this.myInterval = setInterval(() => {
          const { seconds, minutes } = this.state

          if (seconds > 0) {
              this.setState(({ seconds }) => ({
                  seconds: seconds - 1
              }))
          }
          if (seconds === 0) {
              if (minutes === 0) {
                  clearInterval(this.myInterval)
              } else {
                  this.setState(({ minutes }) => ({
                      minutes: minutes - 1,
                      seconds: 59
                  }))
              }
          } 
      }, 1000)
  }

  componentWillUnmount() {
      clearInterval(this.myInterval)
  }

  render() {
      const { minutes, seconds } = this.state
      return (
          <div className="float-right">
              { minutes === 0 && seconds === 0
                  ? <h4>Times up!</h4>
                  : <h4>Time Remaining: {minutes}:{seconds < 10 ? `0${seconds}` : seconds}</h4>
              }
          </div>
      )
  }
}
