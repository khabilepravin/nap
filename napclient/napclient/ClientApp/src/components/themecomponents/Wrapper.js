import React from "react";
import classNames from "classnames";

const Wrapper = ({ className, children }) => (
  <div className={classNames("wrapper", className)}>{children}</div>
);

export default Wrapper;
