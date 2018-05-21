import React from 'react';
import { withRouter } from 'react-router-dom';
import axios from 'axios';

class EditEvent extends React.Component {
    constructor(){
        super();
        this.state = {
            eventID: null,
            eventName: '',
            eventStartDate: '',
            eventEndDate: '',
            eventParticipantNumber:null,
            eventDescription: '',
            events: 0
        };
    }

    onChangeID = (event) =>{
        console.log(event.target);
        this.setState({eventID: event.target.options[event.target.selectedIndex].getAttribute('data-key')})
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

    getAllEvents(path) {
        axios.get('/event')
            .then((response) => {
                this.setState({
                    events: response.data,
                    total: response.data.length
                });                
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    renderLists()
    {
        this.getAllEvents('/event');                
        if(this.state.events !== 0) {
            return this.state.events.map( (option) => (
                <option key={option.id} value={option.name} data-key={option.id}>{option.name}</option>
            ));
        }
    }

    render() {
        return( 
        <div>
            <h1> Edytuj wydarzenie</h1>
                <div className="container">
                    <label>Wybierz nazwę wydarzenia do edycji i wprowadź zmiany: </label> <br/>
                    <select className="form-control" onChange={this.onChangeID} >
                        {this.renderLists()}
                    </select>                
                    <input onChange={this.onChangeName} value={this.state.eventName} placeholder="Nazwa" className="form-control"/>
                    <input onChange={this.onChangeParticipantNumber} value={this.state.participantNumber === 0 ? "" : this.state.rate} placeholder="Liczba uczestników" className="form-control"/>
                    <input onChange={this.onChangeStartDate} value={this.state.eventStartDate} placeholder="Data rozpoczęcia" className="form-control"/>
                    <input onChange={this.onChangeEndDate} value={this.state.eventEndDate} placeholder="Data zakończenia" className="form-control" />
                    <input onChange={this.onChangeDescription} value={this.state.eventDescription} placeholder="Opis" className="form-control"/>
                    <button onClick={this.editEvent}>Edytuj</button>                                    
                 </div> 
                 <div className="container">
                 </div>
        </div>
       );
    }
}

export default withRouter(EditEvent);