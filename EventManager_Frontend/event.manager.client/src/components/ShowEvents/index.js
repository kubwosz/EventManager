import React from 'react';
import axios from 'axios';
import {ListGroup,ListGroupItem} from 'react-bootstrap';
import { withRouter } from 'react-router-dom'
import _ from 'lodash';
import {Link} from 'react-router-dom'

class ShowEvents extends React.Component {
    constructor()
    {
        super();
        this.state = {
            events: []
        };
    }

    componentDidMount() {
        this.getAllEvents('/event');
        console.log('too');
    }

    getAllEvents(path) {
        axios.get('/event')
            .then((response) => {
                console.log(response);
                this.setState({
                    events: response.data,
                    total: response.data.length
                });
            })
            .catch(function (error) {
                console.log("err2");
                console.log(error);
            });
    }

    renderItem(event, index) {
        console.log('renderitem:');
        return (
                    <ListGroupItem key={index} header={event.name}>{event.description}</ListGroupItem>
        )
    }

    render() {
        const events = _.map(this.state.events, (event, k) => {
            return this.renderItem(event, k);
        });

        return (
            <ListGroup>
                {events}
                </ListGroup>
        );
    }
}

export default withRouter(ShowEvents);
