import React from "react";
import { Link } from "react-router-dom";

import {
  Badge,
  Breadcrumb,
  BreadcrumbItem,
  Card,
  CardBody,
  CardHeader,
  CardTitle,
  Col,
  Container,
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  Row,
  Table,
  UncontrolledDropdown
} from "reactstrap";

import Header from "../../components/Header";
import HeaderTitle from "../../components/HeaderTitle";

import { MoreVertical, RefreshCw } from "react-feather";

import avatar1 from "../../assets/img/avatars/avatar.jpg";
import avatar2 from "../../assets/img/avatars/avatar-2.jpg";
import avatar3 from "../../assets/img/avatars/avatar-3.jpg";
import avatar4 from "../../assets/img/avatars/avatar-4.jpg";
import avatar5 from "../../assets/img/avatars/avatar-5.jpg";

const ClientsList = () => (
  <Card>
    <CardHeader>
      <div className="card-actions float-right">
        <span className="cursor-pointer mr-1">
          <RefreshCw />
        </span>{" "}
        <UncontrolledDropdown className="d-inline-block">
          <DropdownToggle tag="a">
            <MoreVertical />
          </DropdownToggle>
          <DropdownMenu right>
            <DropdownItem>Action</DropdownItem>
            <DropdownItem>Another Action</DropdownItem>
            <DropdownItem>Something else here</DropdownItem>
          </DropdownMenu>
        </UncontrolledDropdown>
      </div>
      <CardTitle tag="h5" className="mb-0">
        Clients
      </CardTitle>
    </CardHeader>
    <CardBody>
      <Table className="mb-0">
        <thead>
          <tr>
            <th>#</th>
            <th>Name</th>
            <th>Company</th>
            <th>Email</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>
              <img
                src={avatar3}
                width="32"
                height="32"
                className="rounded-circle my-n1"
                alt="Avatar"
              />
            </td>
            <td>Angelica Ramos</td>
            <td>The Wiz</td>
            <td>angelica@ramos.com</td>
            <td>
              <Badge color="success">Active</Badge>
            </td>
          </tr>
          <tr>
            <td>
              <img
                src={avatar1}
                width="32"
                height="32"
                className="rounded-circle my-n1"
                alt="Avatar"
              />
            </td>
            <td>Ashton Cox</td>
            <td>Levitz Furniture</td>
            <td>ashton@cox.com</td>
            <td>
              <Badge color="success">Active</Badge>
            </td>
          </tr>
          <tr>
            <td>
              <img
                src={avatar4}
                width="32"
                height="32"
                className="rounded-circle my-n1"
                alt="Avatar"
              />
            </td>
            <td>Brenden Wagner</td>
            <td>The Wiz</td>
            <td>brenden@wagner.com</td>
            <td>
              <Badge color="warning">Inactive</Badge>
            </td>
          </tr>
          <tr>
            <td>
              <img
                src={avatar2}
                width="32"
                height="32"
                className="rounded-circle my-n1"
                alt="Avatar"
              />
            </td>
            <td>Charde Marshall</td>
            <td>Price Savers</td>
            <td>charde@marshall.com</td>
            <td>
              <Badge color="success">Active</Badge>
            </td>
          </tr>
          <tr>
            <td>
              <img
                src={avatar3}
                width="32"
                height="32"
                className="rounded-circle my-n1"
                alt="Avatar"
              />
            </td>
            <td>Doris Wilder</td>
            <td>Red Robin Stores</td>
            <td>doris@wilder.com</td>
            <td>
              <Badge color="warning">Inactive</Badge>
            </td>
          </tr>
          <tr>
            <td>
              <img
                src={avatar4}
                width="32"
                height="32"
                className="rounded-circle my-n1"
                alt="Avatar"
              />
            </td>
            <td>Fiona Green</td>
            <td>The Sample</td>
            <td>fiona@green.com</td>
            <td>
              <Badge color="warning">Inactive</Badge>
            </td>
          </tr>
          <tr>
            <td>
              <img
                src={avatar1}
                width="32"
                height="32"
                className="rounded-circle my-n1"
                alt="Avatar"
              />
            </td>
            <td>Garrett Winters</td>
            <td>Good Guys</td>
            <td>garrett@winters.com</td>
            <td>
              <Badge color="success">Active</Badge>
            </td>
          </tr>
          <tr>
            <td>
              <img
                src={avatar5}
                width="32"
                height="32"
                className="rounded-circle my-n1"
                alt="Avatar"
              />
            </td>
            <td>Gavin Cortez</td>
            <td>Red Robin Stores</td>
            <td>gavin@cortez.com</td>
            <td>
              <Badge color="success">Active</Badge>
            </td>
          </tr>
          <tr>
            <td>
              <img
                src={avatar2}
                width="32"
                height="32"
                className="rounded-circle my-n1"
                alt="Avatar"
              />
            </td>
            <td>Haley Kennedy</td>
            <td>Helping Hand</td>
            <td>haley@kennedy.com</td>
            <td>
              <Badge color="danger">Deleted</Badge>
            </td>
          </tr>
          <tr>
            <td>
              <img
                src={avatar5}
                width="32"
                height="32"
                className="rounded-circle my-n1"
                alt="Avatar"
              />
            </td>
            <td>Howard Hatfield</td>
            <td>Price Savers</td>
            <td>howard@hatfield.com</td>
            <td>
              <Badge color="warning">Inactive</Badge>
            </td>
          </tr>
          <tr>
            <td>
              <img
                src={avatar1}
                width="32"
                height="32"
                className="rounded-circle my-n1"
                alt="Avatar"
              />
            </td>
            <td>Jena Gaines</td>
            <td>Helping Hand</td>
            <td>jena@gaines.com</td>
            <td>
              <Badge color="success">Active</Badge>
            </td>
          </tr>
          <tr>
            <td>
              <img
                src={avatar4}
                width="32"
                height="32"
                className="rounded-circle my-n1"
                alt="Avatar"
              />
            </td>
            <td>Jennifer Chang</td>
            <td>Helping Hand</td>
            <td>jennifer@chang.com</td>
            <td>
              <Badge color="warning">Inactive</Badge>
            </td>
          </tr>
        </tbody>
      </Table>
    </CardBody>
  </Card>
);

const Single = () => (
  <Card>
    <CardHeader>
      <div className="card-actions float-right">
        <span className="cursor-pointer mr-1">
          <RefreshCw />
        </span>{" "}
        <UncontrolledDropdown className="d-inline-block">
          <DropdownToggle tag="a">
            <MoreVertical />
          </DropdownToggle>
          <DropdownMenu right>
            <DropdownItem>Action</DropdownItem>
            <DropdownItem>Another Action</DropdownItem>
            <DropdownItem>Something else here</DropdownItem>
          </DropdownMenu>
        </UncontrolledDropdown>
      </div>
      <CardTitle tag="h5" className="mb-0">
        Charissa Hilt
      </CardTitle>
    </CardHeader>
    <CardBody>
      <Row noGutters>
        <Col sm="3" xl="12" className="col-xxl-4 text-center">
          <img
            src={avatar3}
            width="64"
            height="64"
            className="rounded-circle mt-2"
            alt="Charissa Hilt"
          />
        </Col>
        <Col sm="9" xl="12" className="col-xxl-8">
          <strong>About me</strong>
          <p>
            Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean
            commodo ligula eget dolor. Aenean massa. Cum sociis natoque
            penatibus et magnis dis parturient montes, nascetur ridiculus mus.
          </p>
        </Col>
      </Row>

      <Table size="sm" className="my-2">
        <tbody>
          <tr>
            <th>Name</th>
            <td>Charissa Hilt</td>
          </tr>
          <tr>
            <th>Company</th>
            <td>Matrix Interior Design</td>
          </tr>
          <tr>
            <th>Occupation</th>
            <td>Desktop publisher</td>
          </tr>
          <tr>
            <th>Email</th>
            <td>charissahilt@rhyta.com</td>
          </tr>
          <tr>
            <th>Phone</th>
            <td>+1234123123123</td>
          </tr>
          <tr>
            <th>Website</th>
            <td>hispanomarketer.com</td>
          </tr>
          <tr>
            <th>Status</th>
            <td>
              <span className="badge badge-success">Active</span>
            </td>
          </tr>
        </tbody>
      </Table>
    </CardBody>
  </Card>
);

const Clients = () => (
  <Container fluid>
    <Header>
      <HeaderTitle>Clients</HeaderTitle>

      <Breadcrumb>
        <BreadcrumbItem>
          <Link to="/dashboard">Dashboard</Link>
        </BreadcrumbItem>
        <BreadcrumbItem>
          <Link to="/dashboard">Pages</Link>
        </BreadcrumbItem>
        <BreadcrumbItem active>Clients</BreadcrumbItem>
      </Breadcrumb>
    </Header>

    <Row>
      <Col xs="12" className="col-xxl-9">
        <ClientsList />
      </Col>
      <Col xs="12" className="col-xxl-3">
        <Single />
      </Col>
    </Row>
  </Container>
);

export default Clients;
