import React, { useState, useEffect } from "react";
import gql from "graphql-tag";
import { useLazyQuery } from "@apollo/react-hooks";

import { Link } from "react-router-dom";
import LookupGroup from "../../components/appcomponents/LookupGroup";
import LookupValues from "../../components/appcomponents/LookupValues";

import {
  Breadcrumb,
  BreadcrumbItem,
  Card,
  CardBody,
  CardHeader,
  CardTitle,
  Container,
  Button,
  Input,
} from "reactstrap";

import Header from "../../components/themecomponents/Header";
import HeaderTitle from "../../components/themecomponents/HeaderTitle";

const getLookupValuesQuery = gql`
  query lookupValues($groupId: ID!) {
    lookupValues(groupId: $groupId) {
      id
      groupId
      code
      description
      name
    }
  }
`;

const LookupValuesList = ({ history }) => {
  const [getLookupValues, { data }] = useLazyQuery(
    getLookupValuesQuery
  );

  const handleChange = (event) => {
    getLookupValues({ variables: { groupId: event } });
  };
  return (
    <Container fluid>
      <Header>
        <HeaderTitle>Lookup Values</HeaderTitle>
        <Breadcrumb>
          <BreadcrumbItem>
            <Link to="/dashboard">Dashboard</Link>
          </BreadcrumbItem>
          <BreadcrumbItem active>Lookup Values</BreadcrumbItem>
        </Breadcrumb>
      </Header>
      <Card>
        <CardHeader>
          <CardTitle tag="h5">Lookup Values</CardTitle>
        </CardHeader>
        <CardBody>
          <LookupGroup
            onChange={handleChange}
            defaultOptionText="Select Lookup Group"
          />
          <LookupValues lookupValues={data} />
        </CardBody>
      </Card>
    </Container>
  );
};

export default LookupValuesList;
