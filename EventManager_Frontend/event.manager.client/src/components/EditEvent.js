import React from 'react';
import { withRouter } from 'react-router-dom';
import axios from 'axios';
import {BASE_URL} from '../constants';

class EditEvent extends React.Component {
    constructor(){
        super();
        this.state = {
            eventID: 0,
            eventName: '',
            eventStartDate: '',
            eventEndDate: '',
            eventParticipantNumber:0,
            eventDescription: '',
        };
    }

    onChangeID = (event) =>{
        this.setState({eventID: event.target.value})
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

    onChangeDescription = (event) =>{
        this.setState({eventDescription: event.target.value})
    }

    editEvent = (e) => {
        axios.put('/event', {ownerId: 1, id: this.state.eventID, name: this.state.eventName, participantNumber: this.state.eventParticipantNumber, startDate: this.state.eventStartDate, endDate: this.state.eventEndDate, description: this.state.eventDescription })
            .then(()=>{
            })
            .catch((err)=>{
                console.log(err);
            });
    }

    render() {
        return( 
        <div>
            <h1>Edytuj wydarzenie</h1>
                <div className="container">
                    <label>Podaj dane do zmiany: </label>
                    <input onChange={this.onChangeID} defaultValue={this.state.eventID} placeholder="ID" className="form-control"/>                    
                    <input onChange={this.onChangeName} defaultValue={this.state.eventName} placeholder="Nazwa" className="form-control"/>
                    <input onChange={this.onChangeParticipantNumber} defaultValue={this.state.eventParticipantNumber} placeholder="Liczba uczestników" className="form-control"/>
                    <input onChange={this.onChangeStartDate} defaultValue={this.state.eventStartDate} placeholder="Data rozpoczęcia" className="form-control"/>
                    <input onChange={this.onChangeEndDate} defaultValue={this.state.eventEndDate} placeholder="Data zakończenia" className="form-control" />
                    <input onChange={this.onChangeDescription} defaultValue={this.state.eventDescription} placeholder="Opis" className="form-control"/>
                    <button onClick={this.editEvent}>Edytuj</button>                                    
                 </div> 
                 <div className="container">
                 </div>
        </div>
       );
    }
}

export default withRouter(EditEvent);