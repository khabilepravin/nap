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
  Row
} from "reactstrap";

import Header from "../../components/Header";
import HeaderTitle from "../../components/HeaderTitle";

const Introduction = () => (
  <Card>
    <CardHeader>
      <CardTitle tag="h5" className="mb-0">
        Introduction
      </CardTitle>
    </CardHeader>
    <CardBody>
      <div id="introduction">
        <p className="lead">
          Hello, I hope you find this template useful. Spark React has been
          crafted on top of Bootstrap 4 and React. The included docs don't
          replace the official ones, but provide a clear view of all extended
          styles and new components that this template provides on top of
          Bootstrap 4.
        </p>

        <p>
          The docs includes information to understand how the theme is
          organized, how to make changes to the source code, and how to compile
          and extend it to fit your needs.
        </p>
        <p>Thanks, and good luck!</p>
      </div>
    </CardBody>
  </Card>
);

const QuickStart = () => (
  <Card>
    <CardHeader>
      <CardTitle tag="h5" className="mb-0">
        Quick start
      </CardTitle>
    </CardHeader>
    <CardBody>
      <div id="quick-start">
        <p>
          This project was bootstrapped with{" "}
          <a href="https://github.com/facebook/create-react-app">
            Create React App
          </a>
          . You'll need to install <a href="https://nodejs.org/en/">Node.js</a>{" "}
          before using Spark React.
        </p>

        <p className="mb-2">
          Once Node.js is installed, run <code>npm install</code> to install the
          rest of Spark React's dependencies. All dependencies will be
          downloaded to the <code>node_modules</code> directory.
        </p>
        <pre className="snippet">npm install</pre>

        <p className="mb-2">
          Now you're ready to modify the source files and generate new{" "}
          <code>build/</code> files. Spark is using webpack and webpack-serve to
          automatically detect file changes and start a local webserver at{" "}
          <code>http://localhost:3000</code>.
        </p>
        <pre className="snippet">npm start</pre>
      </div>
    </CardBody>
  </Card>
);

const BuildTools = () => (
  <Card>
    <CardHeader>
      <CardTitle tag="h5" className="mb-0">
        Build tools
      </CardTitle>
    </CardHeader>
    <CardBody>
      <div id="build-tools">
        <p className="mb-2">
          Start a local webserver at <code>http://localhost:3000</code> and
          detect file changes:
        </p>
        <pre className="snippet">npm start</pre>

        <p className="mb-2">
          Compile, optimize, minify and uglify all source files to{" "}
          <code>build/</code>:
        </p>
        <pre className="snippet">npm run build</pre>
      </div>
    </CardBody>
  </Card>
);

const Changelog = () => (
  <Card>
    <CardHeader>
      <CardTitle tag="h5" className="mb-0">
        Changelog
      </CardTitle>
    </CardHeader>
    <CardBody>
      <div id="changelog">
        <h4 className="d-inline-block mr-1">
          <Badge color="primary">v3.3.0</Badge>
        </h4>
        <h5 className="d-inline-block">– 3 November, 2019</h5>
        <ul>
          <li>Swapped fonts with Jost and Hind Vadodara</li>
          <li>Various visual changes</li>
          <li>Upgraded various dependencies to LTS version</li>
        </ul>
        <h4 className="d-inline-block mr-1">
          <Badge color="primary">v3.2.1</Badge>
        </h4>
        <h5 className="d-inline-block">– 8 August, 2019</h5>
        <ul>
          <li>Fixes issues with router in IE11</li>
          <li>Fixes issues with card height in IE11</li>
          <li>Added navbar indicator</li>
          <li>Added pricing page (/pages/pricing)</li>
          <li>Added settings page (/pages/settings)</li>
          <li>Added clients page (/pages/clients)</li>
        </ul>
      </div>
    </CardBody>
  </Card>
);

const Contents = () => (
  <Card>
    <CardHeader>
      <CardTitle tag="h5" className="mb-0">
        Contents
      </CardTitle>
    </CardHeader>
    <CardBody>
      <div id="contents">
        <p>
          Inside the zip-file you'll find the following directories and files.
          Both compiled and minified distrubution files, as well as the source
          files are included in the package.
        </p>

        <pre className="snippet">{`theme/
  ├── .gitignore
  ├── package.json
  ├── package-lock.json
  ├── README.md
  ├── build/
  ├── public/
  │   ├── index.html
  │   └── manifest.json
  └── src/
      ├── assets/
      │   ├── img/
      │   └── scss/
      ├── components/
      ├── layouts/
      ├── pages/
      ├── redux/
      ├── routes/
      ├── vendor/
      ├── App.js
      └── index.js
      `}</pre>
      </div>
    </CardBody>
  </Card>
);

const Documentation = () => (
  <Container fluid>
    <Header>
      <HeaderTitle>Getting Started</HeaderTitle>

      <Breadcrumb>
        <BreadcrumbItem>
          <Link to="/dashboard">Dashboard</Link>
        </BreadcrumbItem>
        <BreadcrumbItem active>Getting Started</BreadcrumbItem>
      </Breadcrumb>
    </Header>

    <Row>
      <Col lg="6">
        <Introduction />
        <BuildTools />
        <QuickStart />
      </Col>
      <Col lg="6">
        <Changelog />
        <Contents />
      </Col>
    </Row>
  </Container>
);

export default Documentation;
