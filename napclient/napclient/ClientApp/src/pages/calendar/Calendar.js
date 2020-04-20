import React from "react";
import { Link } from "react-router-dom";

import {
  Breadcrumb,
  BreadcrumbItem,
  Card,
  CardBody,
  CardHeader,
  CardTitle,
  Container
} from "reactstrap";

import Header from "../../components/Header";
import HeaderTitle from "../../components/HeaderTitle";

require("fullcalendar");
const $ = require("jquery");

class Calendar extends React.Component {
  componentDidMount() {
    $("#fullcalendar").fullCalendar({
      header: {
        left: "prev,next today",
        center: "title",
        right: "month,agendaWeek,agendaDay,listMonth"
      },
      weekNumbers: true,
      eventLimit: true,
      editable: true,
      events: "https://fullcalendar.io/demo-events.json"
    });
  }

  render() {
    return (
      <Container fluid>
        <Header>
          <HeaderTitle>Calendar</HeaderTitle>

          <Breadcrumb>
            <BreadcrumbItem>
              <Link to="/dashboard">Dashboard</Link>
            </BreadcrumbItem>
            <BreadcrumbItem active>Calendar</BreadcrumbItem>
          </Breadcrumb>
        </Header>

        <Card>
          <CardHeader>
            <CardTitle tag="h5">FullCalendar</CardTitle>
            <h6 className="card-subtitle text-muted">
              Open source JavaScript jQuery plugin for a full-sized, drag & drop
              event calendar.
            </h6>
          </CardHeader>
          <CardBody>
            <div id="fullcalendar" />
          </CardBody>
        </Card>
      </Container>
    );
  }
}

export default Calendar;
