import React from "react";
import {withRouter} from "react-router-dom";
import {Carousel} from "react-bootstrap";
import myImage from '../tlo.jpg';

class Home extends React.Component {
    constructor() {
        super();
        this.state = {

        };
    }


    render() {
        return (
            <div>
                <Carousel>
                    <Carousel.Item>
                        <img width={1300} height={200} alt="900x500" src={myImage} />
                        <Carousel.Caption>
                            <h3>First slide label</h3>
                            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img width={1300} height={200} alt="900x500" src={myImage} />
                        <Carousel.Caption>
                            <h3>Second slide label</h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img width={1300} height={200} alt="900x500" src={myImage} />
                        <Carousel.Caption>
                            <h3>Third slide label</h3>
                            <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                </Carousel>
            </div>
        );
    }
}
export default withRouter(Home)