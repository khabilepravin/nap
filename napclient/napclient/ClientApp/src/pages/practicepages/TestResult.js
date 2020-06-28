import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import Chart from "react-apexcharts";
import {connect} from "react-redux";
import QuestionService from "../../apiproxy/questionService";

import {
  Breadcrumb,
  BreadcrumbItem,
  Card,
  CardBody,
  CardHeader,
  CardTitle,
  Container
} from "reactstrap";

import Header from "../../components/themecomponents/Header";
import HeaderTitle from "../../components/themecomponents/HeaderTitle";

const TestResult = ({ match, theme }) => {
  const [chartData, setChartData] = useState([]);
  const [resultText, setResultText] = useState();
 
  const options = {
    dataLabels: {
      enabled: true
    },
    labels: ['Right', 'Wrong'],
    colors: [
      theme.success,
      theme.danger
    ]
  };

  const { userTestId } = match.params;
    useEffect(() => {
      QuestionService.getTestResult(userTestId).then(res =>{
          const data = res.data.dataPoints;
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
            <Chart options={options} 
              series={chartData}
              type="donut" 
              height="350" />
            </div>
          </CardBody>
        </Card>
      </Container>
    );
};

export default connect(store => ({
  theme: store.theme.currentTheme
}))(TestResult);