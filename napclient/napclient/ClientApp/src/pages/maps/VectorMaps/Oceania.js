import React from "react";

import { Card, CardBody, CardHeader, CardTitle } from "reactstrap";

const jQuery = require("jquery");
const $ = jQuery;
window.jQuery = jQuery;

require("jvectormap-next");
require("../../../vendor/jquery-jvectormap-oceania-mill");

class Oceania extends React.Component {
  drawMap() {
    this.map = $("#oceania_map").vectorMap({
      map: "oceania_mill",
      backgroundColor: "transparent",
      regionStyle: {
        initial: {
          fill: "#f44336"
        }
      }
    });
  }
  componentDidMount() {
    this.drawMap();
  }
  componentWillUnmount() {
    const mapInstance = $("#oceania_map").vectorMap('get','mapObject');
    mapInstance.remove();
  }
  render = () => (
    <Card>
      <CardHeader>
        <CardTitle tag="h5" className="mb-0">
          Oceania Map
        </CardTitle>
      </CardHeader>
      <CardBody>
        <div className="map-container">
          <div id="oceania_map" style={{ height: 300, width: "100%" }} />
        </div>
      </CardBody>
    </Card>
  );
}

export default Oceania;
