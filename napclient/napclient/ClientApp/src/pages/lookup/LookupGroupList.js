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



const getLookupGroups = gql`
    query{
        lookupGroups{
        id
        name
        code
        }
    }`;

const LookupGroupList = ({history}) => {
  const { loading, error, data } = useQuery(getLookupGroups);

  const tableColumns = [
    {
      dataField: "id",
      text: "Id",
      hidden: true,
    },
    {
      dataField: "name",
      text: "Name",
      sort: true,
    },
    {
      dataField: "code",
      text: "Code",
      sort: true,
    },
    {
      text: "Actions",
      dataField: "",
      formatter: (cell, row, rowIndex) => (
        <>
            <Button  onClick={
            () => history.push(`/lookup/lookupgroupadd/${row.id}`)
            }>Edit</Button>
            <Button onClick={
            () => history.push('/lookup/lookupvalueslist/:lookupGroupId')     
            }>Add Values</Button>
        </>
      )
    }
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
          <HeaderTitle>Lookup Groups</HeaderTitle>
          <Breadcrumb>
            <BreadcrumbItem>
              <Link to="/dashboard">Dashboard</Link>
            </BreadcrumbItem>
            <BreadcrumbItem active>Lookup Groups</BreadcrumbItem>
          </Breadcrumb>
        </Header>
        <Card>
          <CardHeader>
            <CardTitle tag="h5">Lookup Groups</CardTitle>
          </CardHeader>
          <CardBody>
             <Button color="secondary" className="mr-1 mb-1" onClick={
              () => history.push('/lookup/lookgroupadd')
            }>
          <FontAwesomeIcon icon={faPlus} /> Add Test
        </Button>
            <BootstrapTable
              keyField="id"
              data={data.lookupGroups}
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

export default LookupGroupList;
