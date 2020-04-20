import React from "react";

import { Card, CardBody, CardHeader, CardTitle } from "reactstrap";

const jQuery = require("jquery");
const $ = jQuery;
window.jQuery = jQuery;

require("jvectormap-next");
require("../../../vendor/jquery-jvectormap-europe-mill");

class Europe extends React.Component {
  drawMap() {
    this.map = $("#europe_map").vectorMap({
      map: "europe_mill",
      backgroundColor: "transparent",
      regionStyle: {
        initial: {
          fill: "#4caf50"
        }
      }
    });
  }
  componentDidMount() {
    this.drawMap();
  }
  componentWillUnmount() {
    const mapInstance = $("#europe_map").vectorMap('get','mapObject');
    mapInstance.remove();
  }
  render = () => (
    <Card>
      <CardHeader>
        <CardTitle tag="h5" className="mb-0">
          Europe Map
        </CardTitle>
      </CardHeader>
      <CardBody>
        <div className="map-container">
          <div id="europe_map" style={{ height: 300, width: "100%" }} />
        </div>
      </CardBody>
    </Card>
  );
}

export default Europe;
