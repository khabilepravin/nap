import React from "react";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import { enableLightTheme } from "../../redux/actions/themeActions";

import {
  Button,
  Card,
  CardBody,
  Col,
  Container,
  Row,
  Navbar,
  NavbarBrand
} from "reactstrap";

import brandBootstrapB from "../../assets/img/brands/b.svg";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faStar } from "@fortawesome/free-solid-svg-icons";
import AppLogo from "../../components/appcomponents/AppLogo";

const Header = () => (
  <Navbar dark expand="xs" className="absolute-top w-100 py-2">
    <Container>
      <NavbarBrand className="font-weight-bold" href="/">
      <AppLogo/> Prac Test
      </NavbarBrand>      
    </Container>
  </Navbar>
);

const Intro = () => (
  <section className="pt-7 pb-5 landing-bg text-white overflow-hidden">
    <Container className="py-4">
      <Row>
        <Col xl={11} className="mx-auto">
          <Row>
            <Col md={12} xl={8} className="mx-auto text-center">
              <div className="d-block my-4">
                <h1 className="display-4 font-weight-bold mb-3 text-white">
                  Ever increasing comprehensive set of tests for year 3, 6 students
                </h1>
                <p className="lead font-weight-light mb-3 landing-text">
                                    A professional package that comes with hunderds of tests with score tracking and automatic shuffling of questions and answers.
                                    Makes re-taking test less repetitive and more challanging
                                    </p>
                
              </div>
            </Col>
          </Row>
        </Col>
      </Row>
    </Container>
  </section>
);

const Navigation = () => (
  <div className="py-3 bg-white landing-nav">
    <Container className="text-center">
      <Button
        tag={Link}
        to="/dashboard"
        color="primary"
        size="lg"
        target="_blank"
        className="btn-pill"
      >
        Preview
      </Button>
      <Button
        tag={Link}
        to="/documentation"
        color="link"
        size="lg"
        target="_blank"
        className="btn-pill text-dark"
      >
        Documentation
      </Button>
      <Button
        tag={Link}
        to="/documentation"
        color="link"
        size="lg"
        target="_blank"
        className="btn-pill text-dark"
      >
        Changelog
      </Button>
      <Button
        href="mailto:support@bootlab.io"
        color="link"
        size="lg"
        target="_blank"
        className="btn-pill text-dark"
      >
        Support
      </Button>
    </Container>
  </div>
);

const Styles = () => (
  <section className="py-6">
    <Container>
      <div className="mb-4 text-center">
        <h2>Quick links to try the samples</h2>
        <p className="text-muted">
          Multiple numeracy tests to try from.
        </p>
      </div>

      
    </Container>
  </section>
);

const Testimonials = () => (
  <section className="py-6 bg-white">
    <Container>
      <div className="mb-4 text-center">
        <h2>Testimonials</h2>
        <p className="text-muted">
          Here's what some of our 2,500 customers have to say about working with
          our products.
        </p>
      </div>

      <Row>
        <Col md={6} lg={4}>
          <Card tag="blockquote" className="border">
            <CardBody className="p-4">
              <div className="d-flex align-items-center mb-3">
                <div>
                  <img
                    src={brandBootstrapB}
                    width="48"
                    height="48"
                    alt="Bootstrap"
                  />
                </div>
                <div className="pl-3">
                  <h5 className="mb-1 mt-2">Nikita</h5>
                  <small className="d-block text-muted h5 font-weight-normal">
                    Bootstrap Themes
                  </small>
                </div>
              </div>
              <p className="lead mb-2">
                “We are totally amazed with a simplicity and the design of the
                template. Probably saved us hundreds of hours of development. We
                are absolutely amazed with the support Bootlab has provided us.”
              </p>

              <div className="landing-stars">
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />
              </div>
            </CardBody>
          </Card>
        </Col>
        <Col md={6} lg={4}>
          <Card tag="blockquote" className="border">
            <CardBody className="p-4">
              <div className="d-flex align-items-center mb-3">
                <div>
                  <img
                    src={brandBootstrapB}
                    width="48"
                    height="48"
                    alt="Bootstrap"
                  />
                </div>
                <div className="pl-3">
                  <h5 className="mb-1 mt-2">Alejandro</h5>
                  <small className="d-block text-muted h5 font-weight-normal">
                    Bootstrap Themes
                  </small>
                </div>
              </div>
              <p className="lead mb-2">
                “Everything is so properly set up that any new additions I'd
                make would feel like a native extension of the theme versus a
                simple hack. I definitely feel like this will save me hundredths
                of hours I'd otherwise spend on designing.”
              </p>

              <div className="landing-stars">
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />
              </div>
            </CardBody>
          </Card>
        </Col>
        <Col md={6} lg={4}>
          <Card tag="blockquote" className="border">
            <CardBody className="p-4">
              <div className="d-flex align-items-center mb-3">
                <div>
                  <img
                    src={brandBootstrapB}
                    width="48"
                    height="48"
                    alt="Bootstrap"
                  />
                </div>
                <div className="pl-3">
                  <h5 className="mb-1 mt-2">Jordi</h5>
                  <small className="d-block text-muted h5 font-weight-normal">
                    Bootstrap Themes
                  </small>
                </div>
              </div>
              <p className="lead mb-2">
                “I ran into a problem and contacted support. Within 24 hours, I
                not only received a response but even an updated version that
                solved my problem and works like a charm. Fantastic customer
                service!”
              </p>

              <div className="landing-stars">
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />
              </div>
            </CardBody>
          </Card>
        </Col>
        <Col md={6} lg={4}>
          <Card tag="blockquote" className="border">
            <CardBody className="p-4">
              <div className="d-flex align-items-center mb-3">
                <div>
                  <img
                    src={brandBootstrapB}
                    width="48"
                    height="48"
                    alt="Bootstrap"
                  />
                </div>
                <div className="pl-3">
                  <h5 className="mb-1 mt-2">Jason</h5>
                  <small className="d-block text-muted h5 font-weight-normal">
                    Bootstrap Themes
                  </small>
                </div>
              </div>
              <p className="lead mb-2">
                “As a DB guy, this template has made my life easy porting over
                an old website to a new responsive version. I can focus more on
                the data and less on the layout.”
              </p>

              <div className="landing-stars">
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />
              </div>
            </CardBody>
          </Card>
        </Col>
        <Col md={6} lg={4}>
          <Card tag="blockquote" className="border">
            <CardBody className="p-4">
              <div className="d-flex align-items-center mb-3">
                <div>
                  <img
                    src={brandBootstrapB}
                    width="48"
                    height="48"
                    alt="Bootstrap"
                  />
                </div>
                <div className="pl-3">
                  <h5 className="mb-1 mt-2">Richard</h5>
                  <small className="d-block text-muted h5 font-weight-normal">
                    Bootstrap Themes
                  </small>
                </div>
              </div>
              <p className="lead mb-2">
                “This template was just what we were after; its modern, works
                perfectly and is visually beautiful , we couldn't be happier.
                The support really is excellent, I look forward to working with
                these guys for a long time to come!”
              </p>

              <div className="landing-stars">
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />
              </div>
            </CardBody>
          </Card>
        </Col>
        <Col md={6} lg={4}>
          <Card tag="blockquote" className="border">
            <CardBody className="p-4">
              <div className="d-flex align-items-center mb-3">
                <div>
                  <img
                    src={brandBootstrapB}
                    width="48"
                    height="48"
                    alt="Bootstrap"
                  />
                </div>
                <div className="pl-3">
                  <h5 className="mb-1 mt-2">Martin</h5>
                  <small className="d-block text-muted h5 font-weight-normal">
                    Bootstrap Themes
                  </small>
                </div>
              </div>
              <p className="lead mb-2">
                “I just began to test and use this theme and I can find that it
                cover my expectatives. Good support from the developer.”
              </p>

              <div className="landing-stars">
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />{" "}
                <FontAwesomeIcon icon={faStar} />
              </div>
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Container>
  </section>
);

const Footer = () => (
  <section className="py-5">
    <Container className="text-center">
      <Row>
        <Col lg={6} className="mx-auto">
          <h2 className="mb-3">
            Join thousands of students who are already mastering with our practice tests
          </h2>          
        </Col>
      </Row>
    </Container>
  </section>
);

class Landing extends React.Component {
  componentWillMount() {
    const { dispatch } = this.props;
    dispatch(enableLightTheme());
  }

  render() {
    return (
      <React.Fragment>
        <Header />
        <Intro />
        <Navigation />
        <Styles />
        <Testimonials />
        <Footer />
      </React.Fragment>
    );
  }
}

export default connect()(Landing);
