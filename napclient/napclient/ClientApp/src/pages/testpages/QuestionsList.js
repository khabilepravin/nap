import React from "react";
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
  Button,
} from "reactstrap";

import Header from "../../components/themecomponents/Header";
import HeaderTitle from "../../components/themecomponents/HeaderTitle";

import BootstrapTable from "react-bootstrap-table-next";
import paginationFactory from "react-bootstrap-table2-paginator";
import { GET_QUESTIONS } from "../../apiproxy/queries";
import QuestionAdd from "../../components/appcomponents/QuestionAdd";

const QuestionsList = ({ history, match }) => {
  let { testId } = match.params;
  const { loading, error, data } = useQuery(GET_QUESTIONS, {
    variables: { testId: testId },
  });

  const tableColumns = [
    {
      dataField: "id",
      text: "Id",
      hidden: true,
    },
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
      dataField: "sequence",
      text: "Sequence",
      sort: true,
    },
    {
      text: "Actions",
      dataField: "",
      formatter: (cell, row, rowIndex) => (
        <>
          <Button
            onClick={() => history.push(`/testpages/questionadd/${row.id}`)}
          >
            Edit
          </Button>
          <Button
            onClick={() => history.push(`/testpages/answerslist/${row.id}`)}
          >
            Answers
          </Button>
        </>
      ),
    },
  ];

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
          <HeaderTitle>Questions</HeaderTitle>
          <Breadcrumb>
            <BreadcrumbItem>
              <Link to="/dashboard">Dashboard</Link>
            </BreadcrumbItem>
            <BreadcrumbItem active>Questions</BreadcrumbItem>
          </Breadcrumb>
        </Header>
        <Card>
          <CardHeader>
            <CardTitle tag="h5">Add/Edit Question</CardTitle>
          </CardHeader>
          <CardBody>
            <QuestionAdd testId={testId} />
            <h5>Questions List</h5>
            <BootstrapTable
              keyField="id"
              data={data.questions}
              columns={tableColumns}
              bootstrap4
              bordered={false}
              pagination={paginationFactory({
                sizePerPage: 10,
                sizePerPageList: [5, 10, 25, 50],
              })}
            />
          </CardBody>
        </Card>
      </Container>
    );
  }
};

export default QuestionsList;
