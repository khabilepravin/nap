import React from "react";
import classNames from "classnames";

const defaultProps = {
  tag: "div"
};

const Header = ({ children, className, tag: Tag, ...rest }) => (
  <Tag className={classNames("header", className)} {...rest}>
    {children}
  </Tag>
);

Header.defaultProps = defaultProps;

export default Header;
