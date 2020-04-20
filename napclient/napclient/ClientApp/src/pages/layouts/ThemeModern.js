import React from "react";
import { connect } from "react-redux";
import { enableModernTheme } from "../../redux/actions/themeActions";

import Dashboard from "../dashboards/Default";

class ThemeModern extends React.Component {
  componentWillMount() {
    const { dispatch } = this.props;
    dispatch(enableModernTheme());
  }

  render() {
    return <Dashboard />;
  }
}

export default connect()(ThemeModern);
