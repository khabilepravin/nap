import React from "react";

import { Card, CardBody, CardHeader, CardTitle } from "reactstrap";

const jQuery = require("jquery");
const $ = jQuery;
window.jQuery = jQuery;

require("jvectormap-next");
require("../../../vendor/jquery-jvectormap-asia-mill");

class Asia extends React.Component {
  drawMap() {
    this.map = $("#asia_map").vectorMap({
      map: "asia_mill",
      backgroundColor: "transparent",
      regionStyle: {
        initial: {
          fill: "#9c27b0"
        }
      }
    });
  }
  componentDidMount() {
    this.drawMap();
  }
  componentWillUnmount() {
    const mapInstance = $("#asia_map").vectorMap('get','mapObject');
    mapInstance.remove();
  }
  render = () => (
    <Card>
      <CardHeader>
        <CardTitle tag="h5" className="mb-0">
          Asia Map
        </CardTitle>
      </CardHeader>
      <CardBody>
        <div className="map-container">
          <div id="asia_map" style={{ height: 300, width: "100%" }} />
        </div>
      </CardBody>
    </Card>
  );
}

export default Asia;
