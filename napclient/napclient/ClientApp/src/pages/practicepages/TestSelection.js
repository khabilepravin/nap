import React from "react";
import gql from "graphql-tag";
import { useQuery, useMutation } from "@apollo/react-hooks";
import { v4 as uuidv4 } from 'uuid';
import TestFilter from "../../components/appcomponents/practicetest/TestFilter";
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
import { faPlus } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

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

const CREATE_TEST = gql`mutation($userTest: UserTestInput!){
  addUserTest(userTest: $userTest){
    id
    testId
    userId
    mode
  }
}`;

const TestSelection = ({ history, match }) => {
  let { questionId } = match.params;
  const { loading, error, data } = useQuery(getTests);

  const [createUserTestInstance] = useMutation(CREATE_TEST,{
    onCompleted({ addUserTest }){
      //reset();
      //showToastr('Success', 'Answer added successfully');
      //console.log(addUserTest);
      history.push(`/practicepages/practicetest/${addUserTest.id}`);
    }
  });

  const createTestInstance = (testId, mode) => {
    const userId = uuidv4();
    createUserTestInstance({variables: { userTest: { testId: testId, userId: userId, mode: mode } } });
  }

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
      dataField: "subject",
      text: "Subject",
      sort: true,
    },
    {
      dataField: "year",
      text: "Year",
      sort: true,
    },
    {
      text: "Actions",
      dataField: "",
      formatter: (cell, row, rowIndex) => (
        <>
          <Button
            onClick={() => createTestInstance(row.id, 'practice')}
          >
            Practice
          </Button>
          <span> </span>
          <Button
            onClick={() => createTestInstance(row.id, 'exam')}
          >
            Exam
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
          <HeaderTitle>Practice Tests</HeaderTitle>
          <Breadcrumb>
            <BreadcrumbItem>
              <Link to="/dashboard">Dashboard</Link>
            </BreadcrumbItem>
            <BreadcrumbItem active>Practice Tests</BreadcrumbItem>
          </Breadcrumb>
        </Header>
        <Card>
          <CardHeader>
            <CardTitle tag="h2">Select Tests</CardTitle>
          </CardHeader>
          <CardBody>
            <TestFilter />
            <BootstrapTable
              keyField="id"
              data={data.tests}
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

export default TestSelection;