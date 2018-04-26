import React from 'react';
import axios from 'axios';
import { withRouter } from 'react-router-dom'
import {BASE_URL} from '../constants';

class NewEvent extends React.Component {
    constructor()
    {
        super();
        this.state = {
            eventName: '',
            eventStartDate: '',
            eventEndDate: '',
            eventParticipantNumber:0,
            eventDescription: '',
        };
    }

    onChangeName = (event) =>{
        this.setState({eventName: event.target.value})
    }

    onChangeParticipantNumber = (event) =>{
        this.setState({eventParticipantNumber: event.target.value})
    }

    onChangeStartDate = (event) =>{
        this.setState({eventStartDate: event.target.value})
    }

    onChangeEndDate = (event) =>{
        this.setState({eventEndDate: event.target.value})
    }

    addEvent = () => {
       // axios.post('/event', {ownerId: 1, name: "nazwaKonfyFonrty", participantNumber: 77700, startDate: "2019-03-09T16:05:07", endDate: "2019-03-10T16:05:07", description: "opisevent3FRONTedit", lectures: [],
       //     eventUsers: [] })
        axios.post('/event', {ownerId: 1, name: this.state.eventName, participantNumber: this.state.eventParticipantNumber, startDate: this.state.eventStartDate, endDate: this.state.eventEndDate })
            .then(()=>{
                //this.props.history.push('/');
            })
            .catch((err)=>{
                console.log(err);
            });
    }




    render() {
        return (
            <div>
                <div>
                    <h1>Dodawanie konferencji</h1>
                    <input onChange={this.onChangeName} value={this.state.eventName} placeholder="Podaj nazwę konferencji" className="form-control"/>
                    <input onChange={this.onChangeParticipantNumber} value={this.state.participantNumber} placeholder="Podaj liczbę uczestników" className="form-control"/>
                    <input onChange={this.onChangeStartDate} value={this.state.eventStartDate} placeholder="Podaj startDAtae" className="form-control"/>
                    <input onChange={this.onChangeEndDate} value={this.state.eventEndDate} placeholder="Podaj endDate" className="form-control"/>
                    <button onClick={this.addEvent} className="btn btn-info">Dodaj konferencje!</button>
                </div>
                <div className="container-fluid">
                </div>
            </div>
        );
    }
}

export default withRouter(NewEvent);
