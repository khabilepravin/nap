import React from "react";
import { connect } from "react-redux";

import Wrapper from "../components/themecomponents/Wrapper";
import Sidebar from "../components/themecomponents/Sidebar";
import Main from "../components/themecomponents/Main";
import Navbar from "../components/themecomponents/Navbar";
import Content from "../components/themecomponents/Content";
import Footer from "../components/themecomponents/Footer";

const Dashboard = ({ sidebar, children }) => (
  <React.Fragment>
    <Wrapper>
      {!sidebar.isOnRight && <Sidebar />}
      <Main>
        <Navbar />
        <Content>{children}</Content>
        <Footer />
      </Main>
      {sidebar.isOnRight && <Sidebar />}
    </Wrapper>
  </React.Fragment>
);

export default connect(store => ({
  sidebar: store.sidebar
}))(Dashboard);
