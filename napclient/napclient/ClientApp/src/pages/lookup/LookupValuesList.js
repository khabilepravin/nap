import React, { useState } from "react";
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
  Input,
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

const LookupValuesList = ({history}) => {
  const { loading, error, data } = useQuery(getLookupGroups);
  const [selectedGroup, setGroup] = useState('');

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
            () => history.push('/lookup/lookupvalueadd/:lookupGroupId')     
            }>Add Values</Button>
        </>
      )
    }
  ];

  const handleChange = (event) =>{
    setGroup(event.target.value);
    console.log(selectedGroup);
  }

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
      
    let options =   data.lookupGroups.map((group) => 
    <option name={group.id} key={group.id} value={group.id}>
        {group.name}
    </option>
        );
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
          <Input type="select"
                        id="exampleCustomSelect"
                        name="subject"
                        className="mb-3"
                        onChange={handleChange}>
                          <option key="0" value="">Select Group</option>
                        {options}
                      </Input>
          </CardBody>

          <span>{selectedGroup}</span>
        </Card>
      </Container>
    );
  }
};

export default LookupValuesList;
