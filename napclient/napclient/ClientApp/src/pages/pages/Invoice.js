import React from "react";
import { Link } from "react-router-dom";

import {
  Breadcrumb,
  BreadcrumbItem,
  Button,
  Container,
  Row,
  Col,
  Card,
  CardBody,
  Table
} from "reactstrap";

import Header from "../../components/Header";
import HeaderTitle from "../../components/HeaderTitle";

const Invoice = () => (
  <Container fluid>
    <Header>
      <HeaderTitle>Invoice</HeaderTitle>

      <Breadcrumb>
        <BreadcrumbItem>
          <Link to="/dashboard">Dashboard</Link>
        </BreadcrumbItem>
        <BreadcrumbItem>
          <Link to="/dashboard">Pages</Link>
        </BreadcrumbItem>
        <BreadcrumbItem active>Invoice</BreadcrumbItem>
      </Breadcrumb>
    </Header>

    <Card>
      <CardBody className="m-sm-3 m-md-5">
        <div className="mb-4">
          Hello <strong>Linda Miller</strong>,
          <br /> This is the receipt for a payment of <strong>
            $268.00
          </strong>{" "}
          (USD) you made to Spark.
        </div>

        <Row>
          <Col md="6">
            <div className="text-muted">Payment No.</div>
            <strong>741037024</strong>
          </Col>
          <Col md="6" className="text-md-right">
            <div className="text-muted">Payment Date</div>
            <strong>October 2, 2018 - 03:45 pm</strong>
          </Col>
        </Row>

        <hr className="my-4" />

        <Row className="mb-4">
          <Col md="6">
            <div className="text-muted">Client</div>
            <strong>Linda Miller</strong>
            <p>
              4183 Forest Avenue <br /> New York City <br /> 10011 <br /> USA{" "}
              <br />
              <a href="mailto:linda.miller@gmail.com">linda.miller@gmail.com</a>
            </p>
          </Col>
          <Col md="6" className="text-md-right">
            <div className="text-muted">Payment To</div>
            <strong>Spark LLC</strong>
            <p>
              354 Roy Alley <br /> Denver <br /> 80202 <br /> USA <br />
              <a href="mailto:info@spark.com">info@spark.com</a>
            </p>
          </Col>
        </Row>

        <Table size="sm">
          <thead>
            <tr>
              <th>Description</th>
              <th>Quantity</th>
              <th className="text-right">Amount</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>Spark Theme Customization</td>
              <td>2</td>
              <td className="text-right">$150.00</td>
            </tr>
            <tr>
              <td>Monthly Subscription </td>
              <td>3</td>
              <td className="text-right">$25.00</td>
            </tr>
            <tr>
              <td>Additional Service</td>
              <td>1</td>
              <td className="text-right">$100.00</td>
            </tr>
            <tr>
              <th>&nbsp;</th>
              <th>Subtotal </th>
              <th className="text-right">$275.00</th>
            </tr>
            <tr>
              <th>&nbsp;</th>
              <th>Shipping </th>
              <th className="text-right">$8.00</th>
            </tr>
            <tr>
              <th>&nbsp;</th>
              <th>Discount </th>
              <th className="text-right">5%</th>
            </tr>
            <tr>
              <th>&nbsp;</th>
              <th>Total </th>
              <th className="text-right">$268.85</th>
            </tr>
          </tbody>
        </Table>

        <div className="text-center">
          <p className="text-sm">
            <strong>Extra note:</strong> Please send all items at the same time
            to the shipping address. Thanks in advance.
          </p>

          <Button color="primary">Print this receipt</Button>
        </div>
      </CardBody>
    </Card>
  </Container>
);

export default Invoice;
