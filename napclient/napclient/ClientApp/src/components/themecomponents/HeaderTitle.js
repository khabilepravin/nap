import React from "react";
import classNames from "classnames";

const defaultProps = {
  tag: "h1"
};

const HeaderTitle = ({ children, className, tag: Tag, ...rest }) => (
  <Tag className={classNames("header-title", className)} {...rest}>
    {children}
  </Tag>
);

HeaderTitle.defaultProps = defaultProps;

export default HeaderTitle;
