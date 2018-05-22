import React from "react";
import {withRouter} from "react-router-dom";
import {Carousel} from "react-bootstrap";
import myImage from '../data/tlo.jpg';
import ShowEvents from '../ShowEvents';

class Home extends React.Component {
    constructor() {
        super();
        this.state = {

        };
    }


    render() {
        return (
            <div>
               <ShowEvents/>
            </div>
        );
    }
}
export default withRouter(Home)