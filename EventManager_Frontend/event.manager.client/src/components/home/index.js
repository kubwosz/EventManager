import React from "react";
import {withRouter} from "react-router-dom";
import ListEvents from '../listEvents';

class Home extends React.Component {
    constructor() {
        super();
        this.state = {

        };
    }


    render() {
        return (
            <div>
               <ListEvents/>
            </div>
        );
    }
}
export default withRouter(Home)