import React from "react";
import { Container, Row, Col } from "reactstrap";

import BarChart from "./BarChart";
import Calendar from "./Calendar";
import LineChart from "./LineChart";
import PieChart from "./PieChart";
import Statistics from "./Statistics";
import Table from "./Table";
import WorldMap from "./WorldMap";
import { useAuth0 } from "@auth0/auth0-react";

import Header from "../../../components/themecomponents/Header";
import HeaderTitle from "../../../components/themecomponents/HeaderTitle";
import HeaderSubtitle from "../../../components/themecomponents/HeaderSubtitle";

const Default = () => {
const {user, isAuthenticated } = useAuth0();
 return (<Container fluid>
    <Header>

      <HeaderTitle>Welcome back, {user ? user.name : ''}!</HeaderTitle>
      <HeaderSubtitle>
        You have 24 new messages and 5 new notifications.
      </HeaderSubtitle>
    </Header>

    <Row>
      <Col xl="6" className="d-flex col-xxl-7">
        <LineChart />
      </Col>
      <Col xl="6" className="d-flex col-xxl-5">
        <Statistics />
      </Col>
    </Row>
    <Row>
      <Col md="6" className="col-xxl-3 d-flex order-1 order-xxl-1">
        <Calendar />
      </Col>
      <Col md="12" className="col-xxl-6  d-flex order-3 order-xxl-2">
        <WorldMap />
      </Col>
      <Col md="6" className="col-xxl-3  d-flex order-2 order-xxl-3">
        <PieChart />
      </Col>
    </Row>
    <Row>
      <Col lg="8" className="col-xxl-9 d-flex">
        <Table />
      </Col>
      <Col lg="4" className="col-xxl-3  d-flex">
        <BarChart />
      </Col>
    </Row>
  </Container>)
};

export default Default;
