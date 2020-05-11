import React from "react";
import gql from "graphql-tag";
import { useQuery } from "@apollo/react-hooks";

import { Link } from "react-router-dom";

import {
  Breadcrumb,
  BreadcrumbItem,
  Card,
  CardBody,
  CardHeader,
  CardTitle,
  Container,
} from "reactstrap";

import Header from "../../components/themecomponents/Header";
import HeaderTitle from "../../components/themecomponents/HeaderTitle";

import BootstrapTable from "react-bootstrap-table-next";
import ToolkitProvider from "react-bootstrap-table2-toolkit";
import paginationFactory from "react-bootstrap-table2-paginator";

import { MinusCircle, PlusCircle } from "react-feather";

const getTests = gql`
  query {
    tests {
      id
      text
      description
      subject
      year
    }
  }
`;

const tableColumns = [
  {
    dataField: "text",
    text: "Text",
    sort: true,
  },
  {
    dataField: "description",
    text: "Description",
    sort: true,
  },
  {
    dataField: "subject",
    text: "Subject",
    sort: true,
  },
  {
    dataField: "year",
    text: "Year",
    sort: true,
  },
];

const TestList = () => {
  const { loading, error, data } = useQuery(getTests);

  if (loading) {
    return (
      <div>
        <p>Loading</p>
      </div>
    );
  }

  if (error) {
    return (
      <div>
        <p>There was an error</p>
      </div>
    );
  }

  if (data) {
    return (
      <Container fluid>
        <Header>
          <HeaderTitle>Test List</HeaderTitle>

          <Breadcrumb>
            <BreadcrumbItem>
              <Link to="/dashboard">Dashboard</Link>
            </BreadcrumbItem>
            <BreadcrumbItem active>Test List</BreadcrumbItem>
          </Breadcrumb>
        </Header>
        <Card>
          <CardHeader>
            <CardTitle tag="h5">Test List</CardTitle>
          </CardHeader>
          <CardBody>
            <BootstrapTable
              keyField="name"
              data={data.tests}
              columns={tableColumns}
              bootstrap4
              bordered={false}
              pagination={paginationFactory({
                sizePerPage: 5,
                sizePerPageList: [5, 10, 25, 50],
              })}
            />
          </CardBody>
        </Card>
      </Container>
    );
  }
};

export default TestList;
