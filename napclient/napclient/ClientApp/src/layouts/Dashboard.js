import React from "react";
import { connect } from "react-redux";

import Wrapper from "../components/Wrapper";
import Sidebar from "../components/Sidebar";
import Main from "../components/Main";
import Navbar from "../components/Navbar";
import Content from "../components/Content";
import Footer from "../components/Footer";

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
