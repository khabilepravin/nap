import React from "react";
import { connect } from "react-redux";
import { enableLightTheme } from "../../redux/actions/themeActions";

import Dashboard from "../dashboards/Default";

class ThemeLight extends React.Component {
  componentWillMount() {
    const { dispatch } = this.props;
    dispatch(enableLightTheme());
  }

  render() {
    return <Dashboard />;
  }
}

export default connect()(ThemeLight);
