import React from "react";

import { Card, CardBody, CardTitle, Col, Row } from "reactstrap";

import { Truck, Users, DollarSign, ShoppingCart } from "react-feather";

const Statistics = () => (
  <div className="w-100">
    <Row>
      <Col sm="6">
        <Card>
          <CardBody>
            <Row>
              <Col className="mt-0">
                <CardTitle tag="h5">Sales Today</CardTitle>
              </Col>

              <Col className="col-auto">
                <div className="avatar">
                  <div className="avatar-title rounded-circle bg-primary-dark">
                    <Truck className="feather align-middle" />
                  </div>
                </div>
              </Col>
            </Row>
            <h1 className="display-5 mt-1 mb-3">2.562</h1>
            <div className="mb-0">
              <span className="text-danger">
                <i className="mdi mdi-arrow-bottom-right"></i> -2.65%
              </span>{" "}
              Less sales than usual
            </div>
          </CardBody>
        </Card>
        <Card>
          <CardBody>
            <Row>
              <Col className="mt-0">
                <CardTitle tag="h5">Visitors Today</CardTitle>
              </Col>

              <Col className="col-auto">
                <div className="avatar">
                  <div className="avatar-title rounded-circle bg-primary-dark">
                    <Users className="feather align-middle" />
                  </div>
                </div>
              </Col>
            </Row>
            <h1 className="display-5 mt-1 mb-3">17.212</h1>
            <div className="mb-0">
              <span className="text-success">
                <i className="mdi mdi-arrow-bottom-right"></i> 5.50%
              </span>{" "}
              More visitors than usual
            </div>
          </CardBody>
        </Card>
      </Col>
      <Col sm="6">
        <Card>
          <CardBody>
            <Row>
              <Col className="mt-0">
                <CardTitle tag="h5">Total Earnings</CardTitle>
              </Col>

              <Col className="col-auto">
                <div className="avatar">
                  <div className="avatar-title rounded-circle bg-primary-dark">
                    <DollarSign className="feather align-middle" />
                  </div>
                </div>
              </Col>
            </Row>
            <h1 className="display-5 mt-1 mb-3">$24.300</h1>
            <div className="mb-0">
              <span className="text-success">
                <i className="mdi mdi-arrow-bottom-right"></i> 8.35%
              </span>{" "}
              More earnings than usual
            </div>
          </CardBody>
        </Card>
        <Card>
          <CardBody>
            <Row>
              <Col className="mt-0">
                <CardTitle tag="h5">Pending Orders</CardTitle>
              </Col>

              <Col className="col-auto">
                <div className="avatar">
                  <div className="avatar-title rounded-circle bg-primary-dark">
                    <ShoppingCart className="feather align-middle" />
                  </div>
                </div>
              </Col>
            </Row>
            <h1 className="display-5 mt-1 mb-3">43</h1>
            <div className="mb-0">
              <span className="text-danger">
                <i className="mdi mdi-arrow-bottom-right"></i> -4.25%
              </span>{" "}
              Less orders than usual
            </div>
          </CardBody>
        </Card>
      </Col>
    </Row>
  </div>
);

export default Statistics;
