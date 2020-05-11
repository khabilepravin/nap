import React from "react";
import { Link } from "react-router-dom";

import {
  Breadcrumb,
  BreadcrumbItem,
  Button,
  Card,
  CardBody,
  CardHeader,
  CardTitle,
  Col,
  Container,
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Row
} from "reactstrap";

import Header from "../../components/themecomponents/Header";
import HeaderTitle from "../../components/themecomponents/HeaderTitle";

const colors = [
  {
    name: "Primary",
    value: "primary"
  },
  {
    name: "Success",
    value: "success"
  },
  {
    name: "Danger",
    value: "danger"
  },
  {
    name: "Warning",
    value: "warning"
  }
];

const sizes = [
  {
    name: "Small",
    value: "sm"
  },
  {
    name: "Medium",
    value: "md"
  },
  {
    name: "Large",
    value: "lg"
  }
];

class DefaultModal extends React.Component {
  constructor(props) {
    super(props);

    this.state = {};
  }

  toggle = index => {
    this.setState(state => ({
      [index]: !state[index]
    }));
  };

  componentWillMount() {
    colors.forEach((color, index) => {
      this.setState(() => ({
        [index]: false
      }));
    });
  }

  render() {
    return (
      <Card>
        <CardHeader>
          <CardTitle tag="h5">Default modal</CardTitle>
          <h6 className="card-subtitle text-muted">Default Bootstrap modal.</h6>
        </CardHeader>
        <CardBody className="text-center">
          <p>
            Use Bootstrap’s JavaScript modal plugin to add dialogs to your site
            for lightboxes, user notifications, or completely custom content.
          </p>

          {colors.map((color, index) => (
            <React.Fragment key={index}>
              <Button
                color={color.value}
                onClick={() => this.toggle(index)}
                className="mr-1"
              >
                {color.name}
              </Button>
              <Modal
                isOpen={this.state[index]}
                toggle={() => this.toggle(index)}
              >
                <ModalHeader toggle={() => this.toggle(index)}>
                  Default modal
                </ModalHeader>
                <ModalBody className="text-center m-3">
                  <p className="mb-0">
                    Use Bootstrap’s JavaScript modal plugin to add dialogs to
                    your site for lightboxes, user notifications, or completely
                    custom content.
                  </p>
                </ModalBody>
                <ModalFooter>
                  <Button color="secondary" onClick={() => this.toggle(index)}>
                    Close
                  </Button>{" "}
                  <Button
                    color={color.value}
                    onClick={() => this.toggle(index)}
                  >
                    Save changes
                  </Button>
                </ModalFooter>
              </Modal>
            </React.Fragment>
          ))}
        </CardBody>
      </Card>
    );
  }
}

class ColoredModal extends React.Component {
  constructor(props) {
    super(props);

    this.state = {};
  }

  toggle = index => {
    this.setState(state => ({
      [index]: !state[index]
    }));
  };

  componentWillMount() {
    colors.forEach((color, index) => {
      this.setState(() => ({
        [index]: false
      }));
    });
  }

  render() {
    return (
      <Card>
        <CardHeader>
          <CardTitle tag="h5">Colored modal</CardTitle>
          <h6 className="card-subtitle text-muted">Colored Bootstrap modal.</h6>
        </CardHeader>
        <CardBody className="text-center">
          <p>
            Use Bootstrap’s JavaScript modal plugin to add dialogs to your site
            for lightboxes, user notifications, or completely custom content.
          </p>

          {colors.map((color, index) => (
            <React.Fragment key={index}>
              <Button
                color={color.value}
                onClick={() => this.toggle(index)}
                className="mr-1"
              >
                {color.name}
              </Button>
              <Modal
                isOpen={this.state[index]}
                toggle={() => this.toggle(index)}
                className={"modal-colored modal-" + color.value}
              >
                <ModalHeader toggle={() => this.toggle(index)}>
                  Colored modal
                </ModalHeader>
                <ModalBody className="text-center m-3">
                  <p className="mb-0">
                    Use Bootstrap’s JavaScript modal plugin to add dialogs to
                    your site for lightboxes, user notifications, or completely
                    custom content.
                  </p>
                </ModalBody>
                <ModalFooter>
                  <Button color="light" onClick={() => this.toggle(index)}>
                    Close
                  </Button>{" "}
                  <Button color="light" onClick={() => this.toggle(index)}>
                    Save changes
                  </Button>
                </ModalFooter>
              </Modal>
            </React.Fragment>
          ))}
        </CardBody>
      </Card>
    );
  }
}

class CenteredModal extends React.Component {
  constructor(props) {
    super(props);

    this.state = {};
  }

  toggle = index => {
    this.setState(state => ({
      [index]: !state[index]
    }));
  };

  componentWillMount() {
    colors.forEach((color, index) => {
      this.setState(() => ({
        [index]: false
      }));
    });
  }

  render() {
    return (
      <Card>
        <CardHeader>
          <CardTitle tag="h5">Centered modal</CardTitle>
          <h6 className="card-subtitle text-muted">
            Vertically centered modal.
          </h6>
        </CardHeader>
        <CardBody className="text-center">
          <p>
            Use Bootstrap’s JavaScript modal plugin to add dialogs to your site
            for lightboxes, user notifications, or completely custom content.
          </p>

          {colors.map((color, index) => (
            <React.Fragment key={index}>
              <Button
                color={color.value}
                onClick={() => this.toggle(index)}
                className="mr-1"
              >
                {color.name}
              </Button>
              <Modal
                isOpen={this.state[index]}
                toggle={() => this.toggle(index)}
                centered
              >
                <ModalHeader toggle={() => this.toggle(index)}>
                  Centered modal
                </ModalHeader>
                <ModalBody className="text-center m-3">
                  <p className="mb-0">
                    Use Bootstrap’s JavaScript modal plugin to add dialogs to
                    your site for lightboxes, user notifications, or completely
                    custom content.
                  </p>
                </ModalBody>
                <ModalFooter>
                  <Button color="secondary" onClick={() => this.toggle(index)}>
                    Close
                  </Button>{" "}
                  <Button
                    color={color.value}
                    onClick={() => this.toggle(index)}
                  >
                    Save changes
                  </Button>
                </ModalFooter>
              </Modal>
            </React.Fragment>
          ))}
        </CardBody>
      </Card>
    );
  }
}

class ModalSizes extends React.Component {
  constructor(props) {
    super(props);

    this.state = {};
  }

  toggle = index => {
    this.setState(state => ({
      [index]: !state[index]
    }));
  };

  componentWillMount() {
    colors.forEach((color, index) => {
      this.setState(() => ({
        [index]: false
      }));
    });
  }

  render() {
    return (
      <Card>
        <CardHeader>
          <CardTitle tag="h5">Modal sizes</CardTitle>
          <h6 className="card-subtitle text-muted">
            These sizes kick in at certain breakpoints to avoid scrollbars on
            smaller viewports.
          </h6>
        </CardHeader>
        <CardBody className="text-center">
          <p>
            Use Bootstrap’s JavaScript modal plugin to add dialogs to your site
            for lightboxes, user notifications, or completely custom content.
          </p>

          {sizes.map((size, index) => (
            <React.Fragment key={index}>
              <Button
                color="primary"
                onClick={() => this.toggle(index)}
                className="mr-1"
              >
                {size.name}
              </Button>
              <Modal
                isOpen={this.state[index]}
                toggle={() => this.toggle(index)}
                size={size.value}
              >
                <ModalHeader toggle={() => this.toggle(index)}>
                  {size.name} modal
                </ModalHeader>
                <ModalBody className="text-center m-3">
                  <p className="mb-0">
                    Use Bootstrap’s JavaScript modal plugin to add dialogs to
                    your site for lightboxes, user notifications, or completely
                    custom content.
                  </p>
                </ModalBody>
                <ModalFooter>
                  <Button color="secondary" onClick={() => this.toggle(index)}>
                    Close
                  </Button>{" "}
                  <Button color="primary" onClick={() => this.toggle(index)}>
                    Save changes
                  </Button>
                </ModalFooter>
              </Modal>
            </React.Fragment>
          ))}
        </CardBody>
      </Card>
    );
  }
}

const Modals = () => (
  <Container fluid>
    <Header>
      <HeaderTitle>Modals</HeaderTitle>

      <Breadcrumb>
        <BreadcrumbItem>
          <Link to="/dashboard">Dashboard</Link>
        </BreadcrumbItem>
        <BreadcrumbItem>
          <Link to="/dashboard">UI Elements</Link>
        </BreadcrumbItem>
        <BreadcrumbItem active>Modals</BreadcrumbItem>
      </Breadcrumb>
    </Header>

    <Row>
      <Col lg="6">
        <DefaultModal />
      </Col>
      <Col lg="6">
        <ColoredModal />
      </Col>
      <Col lg="6">
        <CenteredModal />
      </Col>
      <Col lg="6">
        <ModalSizes />
      </Col>
    </Row>
  </Container>
);

export default Modals;
