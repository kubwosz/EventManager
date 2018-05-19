import React from 'react';
import './Event.css';
import { BASE_URL } from "../constants";
import { withRouter } from 'react-router-dom';
import axios from 'axios';


class Event extends React.Component {
    constructor() {
        super();
        this.state = {
            eventName: '',
            eventId: 0,
            eventownerId: 0,
            eventUserData: [],
            lectureUserData: [],
            eventstartDate: '',
            eventendDate: '',
            eventparticipantNumber:0,
            descriptionevent: '',
            newEventName: '',
        };
    }

    componentDidMount() {
        axios.get(BASE_URL).then(result => {
            console.log(result);
            this.setState({
                eventUserData: result.data.eventusers, 
                lectureUserData: result.data.lectures,
                eventName: result.data.name, 
                eventId: result.data.id,
                eventownerId: result.data.ownerid,
                eventstartDate: result.data.startdate,
                eventendDate: result.data.enddate,
                eventparticipantNumber: result.data.participantnumber,
                descriptionevent: result.data.description,

            })
        }).catch((err) => {
            console.log(err);
        });
    }

    render() {
        return (
            <div>
                <div>
                    <h1>{this.state.eventName}</h1>
                    <button className="btn btn-info">Dodaj konferencje!</button>
                </div>
            <div className="container-fluid">
            </div>
            </div>
        );
      }
} 
export default withRouter(Event)