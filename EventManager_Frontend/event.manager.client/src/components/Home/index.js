import React from "react";
import {withRouter} from "react-router-dom";
import ShowEvents from '../listEvents';


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