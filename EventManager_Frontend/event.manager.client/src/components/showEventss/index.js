import React from 'react';
import axios from 'axios';
import {ListGroup,ListGroupItem} from 'react-bootstrap';
import { withRouter } from 'react-router-dom'
import _ from 'lodash';
import myImage from '../data/cross.png';
import {Image,Col} from 'react-bootstrap';

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

      //  console.log(this.state.event);
    }

    getAllEvents() {
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

    deleteEvent = (eventId) => {
        if (window.confirm('Na pewno chcesz usunąć konferencję?'))
            axios.delete(`/event/${eventId}`)
                .then(() => {
                    console.log("usunieto");
                })
                .catch(err => {
                    console.log("errDelete");
                    console.log(err);
                });
    }


    renderItem(event, index) {
        console.log('renderitem:');
        return (
            <div>
                <Image
                    onClick = {() => this.deleteEvent(event.id)}
                    src={myImage}
                    height={15}
                    width={15}
                />

                    <ListGroupItem href= {"/NewLecture/" + event.id}  key={index} header={event.name}>
                        {event.description}
                    </ListGroupItem>

            </div>
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
