import React from "react";

import { Card, CardBody, CardHeader, CardTitle } from "reactstrap";

const jQuery = require("jquery");
const $ = jQuery;
window.jQuery = jQuery;

require("jvectormap-next");
require("../../../vendor/jquery-jvectormap-us-aea");

class USA extends React.Component {
  drawMap() {
    this.map = $("#usa_map").vectorMap({
      map: "us_aea",
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
    const mapInstance = $("#usa_map").vectorMap('get','mapObject');
    mapInstance.remove();
  }
  render = () => (
    <Card>
      <CardHeader>
        <CardTitle tag="h5" className="mb-0">
          USA Map
        </CardTitle>
      </CardHeader>
      <CardBody>
        <div className="map-container">
          <div id="usa_map" style={{ height: 300, width: "100%" }} />
        </div>
      </CardBody>
    </Card>
  );
}

export default USA;
