import React from "react";
import {withRouter} from "react-router-dom";
import ShowEvents from '../showEvents';


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