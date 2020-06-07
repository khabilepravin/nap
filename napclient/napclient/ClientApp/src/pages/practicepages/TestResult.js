import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Pie } from "react-chartjs-2";
import axios from "axios";

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

const TestResult = ({ history, match, theme }) => {
  const [chartData, setChartData] = useState({});
  const [resultText, setResultText] = useState();

  const options = {
    maintainAspectRatio: false,
    legend: {
      display: false
    }
  };

  const { userTestId } = match.params;
    useEffect(() => {
      axios.get( `${process.env.REACT_APP_REST_API_ENDPOINT}/testresult/${userTestId}`)
      .then(res => {
        //console.log(res.data);
        const data = {
          labels: res.data.labels,
          datasets: [
            {
              data: res.data.dataPoints,
              backgroundColor: [
                "#2F910C",
                "#E81F12"
              ],
              borderColor: "transparent"
            }
          ]
        };
        setResultText(res.data.resultText);
        setChartData(data);
      });
    }, []);

    return (
      <Container fluid>
        <Header>
          <HeaderTitle>Results</HeaderTitle>
          <Breadcrumb>
            <BreadcrumbItem>
              <Link to="/dashboard">Dashboard</Link>
            </BreadcrumbItem>
            <BreadcrumbItem active>Test Results</BreadcrumbItem>
          </Breadcrumb>
        </Header>
        <Card>
          <CardHeader>
            <CardTitle tag="h2">Results</CardTitle>
          </CardHeader>
          <CardBody>
            <h3>{resultText}</h3>
            <div className="chart chart-xs">
              <Pie data={chartData} options={options} />
            </div>
          </CardBody>
        </Card>
      </Container>
    );
};

export default TestResult;
