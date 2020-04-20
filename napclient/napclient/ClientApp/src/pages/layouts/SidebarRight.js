import React from "react";
import { connect } from "react-redux";
import {
  enableRightSidebar,
  disableRightSidebar
} from "../../redux/actions/sidebarActions";

import Dashboard from "../dashboards/Default";

class SidebarRight extends React.Component {
  componentWillMount() {
    const { dispatch } = this.props;

    dispatch(enableRightSidebar());
  }

  componentWillUnmount() {
    const { dispatch } = this.props;

    dispatch(disableRightSidebar());
  }

  render() {
    return <Dashboard />;
  }
}

export default connect()(SidebarRight);
