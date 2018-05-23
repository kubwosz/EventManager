import React from "react";
import {withRouter} from "react-router-dom";
import pageNotFoundImage from '../data/pageNotFound.png';
import {Image} from 'react-bootstrap';

class PageNotFound extends React.Component {
    constructor() {
        super();
        this.state = {

        };
    }


    render() {
        return (
            <div >
                <Image
                    src={pageNotFoundImage}
                    height={"100%"}
                    width={"100%"}
                />
            </div>
        );
    }
}
export default withRouter(PageNotFound)