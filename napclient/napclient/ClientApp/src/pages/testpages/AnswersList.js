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
  Button,
} from "reactstrap";

import Header from "../../components/themecomponents/Header";
import HeaderTitle from "../../components/themecomponents/HeaderTitle";

import BootstrapTable from "react-bootstrap-table-next";
import paginationFactory from "react-bootstrap-table2-paginator";
import { faPlus } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const getAnswers = gql`query answers($questionId: ID!){
    answers(questionId: $questionId){
      id
      text
      description
      sequence
      isCorrect
    }
  }
`;

const AnswersList = ({ history, match }) => {
  let {questionId} = match.params;
  const { loading, error, data } = useQuery(getAnswers, { variables: { questionId:questionId  }});

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
      dataField: "isCorrect",
      text: "Is Correct",
      sort: true,
    },
    {
      text: "Actions",
      dataField: "",
      formatter: (cell, row, rowIndex) => (
        <Button
          onClick={() => history.push(`/testpages/answeradd/${row.id}`)}
        >
          Add
        </Button>
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
          <HeaderTitle>Answers List</HeaderTitle>
          <Breadcrumb>
            <BreadcrumbItem>
              <Link to="/dashboard">Dashboard</Link>
            </BreadcrumbItem>
            <BreadcrumbItem active>Answers List</BreadcrumbItem>
          </Breadcrumb>
        </Header>
        <Card>
          <CardHeader>
            <CardTitle tag="h5">Answers List</CardTitle>
          </CardHeader>
          <CardBody>
            <Button
              color="secondary"
              className="mr-1 mb-1"
              onClick={() => history.push(`/testpages/answeradd/${questionId}`)}
            >
              <FontAwesomeIcon icon={faPlus} /> Add New
            </Button>
            <BootstrapTable
              keyField="id"
              data={data.answers}
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

export default AnswersList;
