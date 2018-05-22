import React from 'react';
import { withRouter } from 'react-router-dom';
import axios from 'axios';
import {Link} from 'react-router-dom'


class EditEvent extends React.Component {
    constructor(){
        super();
        this.state = {
            eventID: null,
            eventName: '',
            eventStartDate: '',
            eventEndDate: '',
            eventParticipantNumber: null,
            eventDescription: ''
        };
    }
    componentDidMount() {
        this.getEvent();
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

    editEvent = () => {
        axios.put('/event', {ownerId: 1, id: this.state.eventID, name: this.state.eventName, participantNumber: this.state.eventParticipantNumber, startDate: this.state.eventStartDate, endDate: this.state.eventEndDate, description: this.state.eventDescription })
            .then(()=>{
                window.confirm('Wydarzenie zostało zedytowane poprawnie!');
            })
            .catch((err)=>{
                console.log(err);
            });
    }

    getEvent() {
        axios.get('/event/' + this.props.match.params.id)
            .then((response) => {
                this.setState({
                    eventID: this.props.match.params.id,
                    eventName: response.data.name,
                    eventStartDate: response.data.startDate,
                    eventEndDate: response.data.endDate,
                    eventParticipantNumber: response.data.participantNumber,
                    eventDescription: response.data.description,
                });

            })
            .catch(function (error) {
                console.log(error);
            });
    }

    render() {
        return(
            <div>
                <h1> Edytuj wydarzenie</h1>
                <div className="container">
                    <input onChange={this.onChangeName} value={this.state.eventName} placeholder="Nazwa" className="form-control"/>
                    <input onChange={this.onChangeParticipantNumber} value={this.state.eventParticipantNumber === null ? "" : this.state.eventParticipantNumber } placeholder="Liczba uczestników" className="form-control"/>
                    <input onChange={this.onChangeStartDate} value={this.state.eventStartDate} placeholder="Data rozpoczęcia" className="form-control"/>
                    <input onChange={this.onChangeEndDate} value={this.state.eventEndDate} placeholder="Data zakończenia" className="form-control" />
                    <input onChange={this.onChangeDescription} value={this.state.eventDescription} placeholder="Opis" className="form-control"/>
                    <button onClick={this.editEvent}>Edytuj</button>
                </div>
                <div className="container">
                    <Link to={"/NewLecture/" + this.state.eventID} style={{color: 'black'}} ><button >Dodaj wykład w ramach tego wydarzenia</button></Link>
                </div>
            </div>
        );
    }
}

export default withRouter(EditEvent);