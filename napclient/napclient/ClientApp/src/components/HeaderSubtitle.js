import React from "react";
import classNames from "classnames";

const defaultProps = {
  tag: "p"
};

const HeaderSubtitle = ({ children, className, tag: Tag, ...rest }) => (
  <Tag className={classNames("header-subtitle", className)} {...rest}>
    {children}
  </Tag>
);

HeaderSubtitle.defaultProps = defaultProps;

export default HeaderSubtitle;
