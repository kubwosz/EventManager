import React from 'react';
import axios from 'axios';
import {ListGroupItem} from 'react-bootstrap';
import { withRouter } from 'react-router-dom'
import _ from 'lodash';
import crossImage from '../data/cross.png';
import pencilImage from '../data/pencil.png';
import addImage from '../data/add.png';
import {Image,Col,Row,Grid} from 'react-bootstrap';

class ListEvents extends React.Component {
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
                <Row key={index} className="show-grid" style={{border: "2px ridge #000000", background: "#FFFFFF",padding: "10px"}}>
                    <div style={{height:"50px"}}>
                    <Col sm={6} md={4}>
                        <ListGroupItem header={event.name} href={"/ShowEvent/" + event.id}>
                            {event.description}
                            </ListGroupItem>
                    </Col>
                    <Col sm={12} md={2} style={{padding: "20px"}}>
                        <Image
                            onClick = {() => this.deleteEvent(event.id)}
                            src={crossImage}
                            height={25}
                            width={25}
                           // style={styleImg.image}
                        />
                        <Image
                            onClick = {() => {this.props.history.push("/EditEvent/" + event.id)}}
                            src={pencilImage}
                            height={25}
                            width={25}
                            style={{ marginLeft: '20px'}}
                        />
                        <Image
                            onClick = {() => {}}
                            src={addImage}
                            height={25}
                            width={25}
                            style={{ marginLeft: '20px'}}
                        />
                    </Col>
                    <Col sm={12} md={2}>

                    </Col>
                    </div>
                </Row>
            </div>
        )
    }

    render() {
        const events = _.map(this.state.events, (event, k) => {
            return this.renderItem(event, k);
        });

        return (
        <Grid>
        {events}
    </Grid>
        );
    }
}

export default withRouter(ListEvents);
