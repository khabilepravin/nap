import React from "react";
import { Pie } from "react-chartjs-2";
import { connect } from "react-redux";

import {
  CardBody,
  Card,
  CardHeader,
  CardTitle,
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  Table,
  UncontrolledDropdown
} from "reactstrap";

import { MoreVertical, RefreshCw } from "react-feather";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCircle } from "@fortawesome/free-solid-svg-icons";

const PieChart = ({ theme }) => {
  const data = {
    labels: ["Chrome", "Firefox", "IE", "Other"],
    datasets: [
      {
        data: [4401, 4003, 1589],
        backgroundColor: [
          theme.primary,
          theme.warning,
          theme.danger,
          "#E8EAED"
        ],
        borderColor: "transparent"
      }
    ]
  };

  const options = {
    responsive: !window.MSInputMethodContext,
    maintainAspectRatio: false,
    legend: {
      display: false
    },
    cutoutPercentage: 75
  };

  return (
    <Card className="flex-fill w-100">
      <CardHeader>
        <div className="card-actions float-right">
          <span className="cursor-pointer mr-1">
            <RefreshCw />
          </span>{" "}
          <UncontrolledDropdown className="d-inline-block">
            <DropdownToggle tag="a">
              <MoreVertical />
            </DropdownToggle>
            <DropdownMenu right>
              <DropdownItem>Action</DropdownItem>
              <DropdownItem>Another Action</DropdownItem>
              <DropdownItem>Something else here</DropdownItem>
            </DropdownMenu>
          </UncontrolledDropdown>
        </div>
        <CardTitle tag="h5" className="mb-0">
          Browser Usage
        </CardTitle>
      </CardHeader>
      <CardBody className="d-flex">
        <div className="align-self-center w-100">
          <div className="py-3">
            <div className="chart chart-xs">
              <Pie data={data} options={options} />
            </div>
          </div>

          <Table className="mb-0">
            <tbody>
              <tr>
                <td>
                  <FontAwesomeIcon icon={faCircle} className="text-primary" />{" "}
                  Chrome
                </td>
                <td className="text-right">4401</td>
              </tr>
              <tr>
                <td>
                  <FontAwesomeIcon icon={faCircle} className="text-warning" />{" "}
                  Firefox
                </td>
                <td className="text-right">4003</td>
              </tr>
              <tr>
                <td>
                  <FontAwesomeIcon icon={faCircle} className="text-danger" /> IE
                </td>
                <td className="text-right">1589</td>
              </tr>
            </tbody>
          </Table>
        </div>
      </CardBody>
    </Card>
  );
};

export default connect(store => ({
  theme: store.theme.currentTheme
}))(PieChart);
