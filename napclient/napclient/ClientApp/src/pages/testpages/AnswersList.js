import React, { useState, useEffect } from "react";
import { GET_ANSWERS } from "../../apiproxy/queries";
import { DELETE_ANSWER } from "../../apiproxy/mutations";
import AnswerAdd from "../../components/appcomponents/AnswerAdd";

import { useLazyQuery, useMutation } from "@apollo/react-hooks";

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

const AnswersList = ({ history, match }) => {
  const { questionId } = match.params;
  const [question, setQuestion] = useState();

  const [getAnswers, { called, loading }] = useLazyQuery(GET_ANSWERS, {
    onCompleted: (data) => {
      setQuestion(data.question);
    },
    fetchPolicy: "no-cache",
  });

  useEffect(() => {
    getAnswers({ variables: { questionId: questionId } });
  }, []);

  const [deleteAnswer] = useMutation(DELETE_ANSWER);

  const deleteAnswerHandler = (id) => {
    deleteAnswer({ variables: { id: id } });
  };

  const handleAnswerAdded = () => {
    getAnswers({ variables: { questionId: questionId } });
  };

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
        <>
          <Button onClick={() => deleteAnswerHandler(row.id)}>Delete</Button>
        </>
      ),
    },
  ];

  if (!called) {
    return (
      <div>
        <p>Was never called</p>
      </div>
    );
  }

  if (loading) {
    return <h3>Loading...</h3>;
  }

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
          <CardTitle tag="h2">Answers</CardTitle>
        </CardHeader>
        <CardBody>
          <h4>Add/Edit answers for: {question && question.text}</h4>
          <AnswerAdd
            questionId={questionId}
            onAnswerAdded={handleAnswerAdded}
          />
          <BootstrapTable
            keyField="id"
            data={question ? question.answers : []}
            columns={tableColumns}
            bootstrap4
            bordered={false}
          />
        </CardBody>
      </Card>
    </Container>
  );
};

export default AnswersList;
