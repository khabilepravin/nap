import React from "react";

import { Card, CardBody, CardHeader, CardTitle } from "reactstrap";

const jQuery = require("jquery");
const $ = jQuery;
window.jQuery = jQuery;

require("jvectormap-next");
require("../../../vendor/jquery-jvectormap-north_america-mill");

class NorthAmerica extends React.Component {
  drawMap() {
    this.map = $("#north_america_map").vectorMap({
      map: "north_america_mill",
      backgroundColor: "transparent",
      regionStyle: {
        initial: {
          fill: "#ff9800"
        }
      }
    });
  }
  componentDidMount() {
    this.drawMap();
  }
  componentWillUnmount() {
    const mapInstance = $("#north_america_map").vectorMap('get','mapObject');
    mapInstance.remove();
  }
  render = () => (
    <Card>
      <CardHeader>
        <CardTitle tag="h5" className="mb-0">
          North America Map
        </CardTitle>
      </CardHeader>
      <CardBody>
        <div className="map-container">
          <div id="north_america_map" style={{ height: 300, width: "100%" }} />
        </div>
      </CardBody>
    </Card>
  );
}

export default NorthAmerica;
