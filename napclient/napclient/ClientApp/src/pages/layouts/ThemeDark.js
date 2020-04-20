import React from "react";
import { connect } from "react-redux";
import { enableDarkTheme } from "../../redux/actions/themeActions";

import Dashboard from "../dashboards/Default";

class ThemeDark extends React.Component {
  componentWillMount() {
    const { dispatch } = this.props;
    dispatch(enableDarkTheme());
  }

  render() {
    return <Dashboard />;
  }
}

export default connect()(ThemeDark);
