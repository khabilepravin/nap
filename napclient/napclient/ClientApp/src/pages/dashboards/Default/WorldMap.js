import React from "react";
import { connect } from "react-redux";

import {
  Card,
  CardBody,
  CardHeader,
  CardTitle,
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  UncontrolledDropdown
} from "reactstrap";

import { MoreVertical, RefreshCw } from "react-feather";

const jQuery = require("jquery");
const $ = jQuery;
window.jQuery = jQuery;

require("jvectormap-next");
require("../../../vendor/jquery-jvectormap-world-mill");

class World extends React.Component {
  drawMap(theme) {
    this.map = $("#world_map").vectorMap({
      map: "world_mill",
      backgroundColor: "transparent",
      zoomOnScroll: false,
      regionStyle: {
        initial: {
          fill: "#e4e4e4",
          "fill-opacity": 0.9,
          stroke: "none",
          "stroke-width": 0,
          "stroke-opacity": 0
        }
      },
      series: {
        regions: [
          {
            values: {
              US: 298,
              SA: 200,
              DE: 220,
              FR: 540,
              CN: 120,
              AU: 760,
              BR: 550,
              IN: 200,
              GB: 120
            },
            scale: [theme.primary],
            normalizeFunction: "polynomial"
          }
        ]
      }
    });
  }
  componentDidMount() {
    this.drawMap(this.props.theme);
    // Trigger resize to make sure vector map is painted properly
    setTimeout(() => {
      window.dispatchEvent(new Event("resize"));
    }, 1000);
  }
  componentWillUnmount() {
    const mapInstance = $("#world_map").vectorMap("get", "mapObject");
    mapInstance.remove();
  }
  render = () => (
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
          Current Visitors
        </CardTitle>
      </CardHeader>
      <CardBody className="px-4">
        <div className="map-container">
          <div id="world_map" style={{ height: 350, width: "100%" }} />
        </div>
      </CardBody>
    </Card>
  );
}

export default connect(store => ({
  theme: store.theme.currentTheme
}))(World);
