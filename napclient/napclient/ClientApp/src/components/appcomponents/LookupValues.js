import React from "react";

import BootstrapTable from "react-bootstrap-table-next";
import paginationFactory from "react-bootstrap-table2-paginator";

const LookupValues = (data) => {
  let values = [{ id: "", name: "", code: "", description:"" }];

  if (data != undefined) {
    if(data.lookupValues != undefined){        
        values = data.lookupValues.lookupValues;
    }
  }

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
      dataField: "description",
      text: "Description",
      sort: false,
    },
  ];

  return (
    <BootstrapTable
      keyField="id"
      data={values}
      columns={tableColumns}
      bootstrap4
      bordered={false}
      pagination={paginationFactory({
        sizePerPage: 10,
        sizePerPageList: [5, 10, 25, 50],
      })}
    />
  );
};

export default LookupValues;