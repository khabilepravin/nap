import React from "react";

import { Card, CardBody, CardHeader, CardTitle } from "reactstrap";

const jQuery = require("jquery");
const $ = jQuery;
window.jQuery = jQuery;

require("jvectormap-next");
require("../../../vendor/jquery-jvectormap-uk_countries-mill");

class UK extends React.Component {
  drawMap() {
    this.map = $("#uk_map").vectorMap({
      map: "uk_countries_mill",
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
    const mapInstance = $("#uk_map").vectorMap('get','mapObject');
    mapInstance.remove();
  }
  render = () => (
    <Card>
      <CardHeader>
        <CardTitle tag="h5" className="mb-0">
          UK Map
        </CardTitle>
      </CardHeader>
      <CardBody>
        <div className="map-container">
          <div id="uk_map" style={{ height: 300, width: "100%" }} />
        </div>
      </CardBody>
    </Card>
  );
}

export default UK;
