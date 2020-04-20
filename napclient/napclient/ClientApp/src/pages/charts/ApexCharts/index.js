import React from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";

import { Breadcrumb, BreadcrumbItem, Col, Container, Row } from "reactstrap";

import Header from "../../../components/Header";
import HeaderTitle from "../../../components/HeaderTitle";

import Line from "./Line";
import Area from "./Area";
import Bar from "./Bar";
import Column from "./Column";
import Pie from "./Pie";
import Heatmap from "./Heatmap";
import Mixed from "./Mixed";
import Candlestick from "./Candlestick";

class ApexCharts extends React.Component {
  componentDidUpdate() {
    setTimeout(() => {
      window.dispatchEvent(new Event("resize"));
    }, 100);
  }

  render() {
    return (
      <Container fluid>
        <Header>
          <HeaderTitle>ApexCharts</HeaderTitle>

          <Breadcrumb>
            <BreadcrumbItem>
              <Link to="/dashboard">Dashboard</Link>
            </BreadcrumbItem>
            <BreadcrumbItem>
              <Link to="/dashboard">Charts</Link>
            </BreadcrumbItem>
            <BreadcrumbItem active>ApexCharts</BreadcrumbItem>
          </Breadcrumb>
        </Header>

        <Row>
          <Col lg="6">
            <Line />
          </Col>
          <Col lg="6">
            <Area />
          </Col>
          <Col lg="6">
            <Bar />
          </Col>
          <Col lg="6">
            <Column />
          </Col>
          <Col lg="6">
            <Pie />
          </Col>
          <Col lg="6">
            <Heatmap />
          </Col>
          <Col lg="6">
            <Mixed />
          </Col>
          <Col lg="6">
            <Candlestick />
          </Col>
        </Row>
      </Container>
    );
  }
}

export default connect(store => ({
  theme: store.theme.currentTheme
}))(ApexCharts);
