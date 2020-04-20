import React from "react";
import { connect } from "react-redux";
import { disableRightSidebar } from "../../redux/actions/sidebarActions";

import Dashboard from "../dashboards/Default";

class SidebarLeft extends React.Component {
  componentWillMount() {
    const { dispatch } = this.props;

    dispatch(disableRightSidebar());
  }

  render() {
    return <Dashboard />;
  }
}

export default connect()(SidebarLeft);
