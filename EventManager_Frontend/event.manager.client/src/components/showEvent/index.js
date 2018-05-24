import React from 'react';
import axios from 'axios';
import { withRouter } from 'react-router-dom'
import {Label} from 'react-bootstrap';

const path = '/event/';

class ShowEvent extends React.Component {
    constructor()
    {
        super();
        this.state = {
            event: []
        };
    }


    componentDidMount() {
        this.getEvent();
    }

    getEvent() {
        axios.get(path + this.props.match.params.id)
            .then((response) => {
                console.log(response);
                this.setState({
                    event: response.data
                });
            })
            .catch(function (error) {
                console.log("err2");
                console.log(error);
            });
    }

    render() {


        return (
            <div>
                <h1>Wydarzenie:  {this.state.event.name}</h1>
                <div className="container">
                    <h4>
                        Liczba uczestników <Label>{this.state.event.participantNumber}</Label>
                    </h4>
                    <h4>
                        Data rozpoczęcia <Label>{this.state.event.startDate}</Label>
                    </h4>
                    <h4>
                        Data zakończenia <Label>{this.state.event.endDate}</Label>
                    </h4>
                    <h4>
                        Opis: <Label>{this.state.event.description}</Label>
                    </h4>
                </div>
            </div>
        );
    }
}

export default withRouter(ShowEvent);
