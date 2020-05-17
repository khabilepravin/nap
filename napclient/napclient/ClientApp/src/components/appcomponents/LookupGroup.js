import React, { useState, useEffect } from "react";
import gql from "graphql-tag";
import { useQuery, useLazyQuery } from "@apollo/react-hooks";

import { Input } from "reactstrap";

const getLookupGroups = gql`
  query {
    lookupGroups {
      id
      name
      code
    }
  }
`;

const LookupGroup = (props) => {
  const { loading, error, data } = useQuery(getLookupGroups);
  const handleSelectionChange = (event) => {
    props.onChange(event.target.value);
  };

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
    let options = data.lookupGroups.map((group) => (
      <option name={group.id} key={group.id} value={group.id}>
        {group.name}
      </option>
    ));
    return (
      <Input
        type="select"
        id="exampleCustomSelect"
        name="lookupGroup"
        className="mb-3"
        onChange={handleSelectionChange}>
        <option key="0" value="">
          {props.defaultOptionText}
        </option>
        {options}
      </Input>
    );
  }
};

export default LookupGroup;
