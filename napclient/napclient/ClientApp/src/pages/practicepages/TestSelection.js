import React from "react";
import gql from "graphql-tag";
import { useQuery } from "@apollo/react-hooks";

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

const getAnswers = gql`query($questionId:ID!){
  question(questionId:$questionId){
    id
    text
    description
    answers{
      id
      text
      description
      sequence
      isCorrect
    }
  }
}
`;

const TestSelection = ({ history, match }) => {
  let {questionId} = match.params;
//  const { loading, error, data } = useQuery(getAnswers, { variables: { questionId:questionId  }});

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
    }
  ];

//   if (loading) {
//     return (
//       <div>
//         <p>Loading</p>
//       </div>
//     );
//   }

//   if (error) {
//     return (
//       <div>
//         <p>There was an error</p>
//       </div>
//     );
//   }

  //if (data) {
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
            <TestFilter/> 
          </CardBody>
        </Card>
      </Container>
    );
 // }
};

export default TestSelection;
