import React from 'react';
import { withRouter } from 'react-router-dom';
import axios from 'axios';
import {Link} from 'react-router-dom';
import {Form, FormGroup, FormControl, ControlLabel, Col, PageHeader} from 'react-bootstrap';


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
        window.confirm('Name changed');
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
            <Form horizontal>

                <FormGroup>
                <Col sm={2}> </Col>
                <Col sm={9}> 
                <PageHeader > Edytuj wydarzenie</PageHeader> 
                </Col>
                </FormGroup>

                <FormGroup>
                <Col componentClass={ControlLabel} sm={2}> Nazwa </Col>
                <Col sm={9}>
                <FormControl onBlur={this.onChangeName} defaultValue={this.state.eventName} placeholder={this.state.eventName}/>
                </Col>

                <Col componentClass={ControlLabel} sm={2}> Liczba uczestników </Col>
                <Col sm={9}>
                <FormControl onBlur={this.onChangeParticipantNumber} 
                defaultValue={this.state.eventParticipantNumber === null ? "" : this.state.eventParticipantNumber}
                placeholder={this.state.eventParticipantNumber} />
                </Col>

                <Col componentClass={ControlLabel} sm={2}> Data rozpoczęcia </Col>
                <Col sm={9}>
                <FormControl onBlur={this.onChangeStartDate} 
                defaultValue={this.state.eventStartDate === null ? "" : this.state.eventStartDate} 
                placeholder={this.state.eventStartDate} />
                </Col>

                <Col componentClass={ControlLabel} sm={2}> Data zakończenia </Col>
                <Col sm={9}>
                <FormControl onBlur={this.onChangeStartDate} 
                defaultValue={this.state.eventEndDate === null ? "" : this.state.eventEndDate}
                placeholder={this.state.eventEndDate} />
                </Col>

                <Col componentClass={ControlLabel} sm={2}> Opis </Col>
                <Col sm={9}>
                <FormControl onBlur={this.onChangeDescription} 
                defaultValue={this.state.eventDescription === null ? "" : this.onChangeDescription}
                placeholder={this.state.eventDescription} />
                </Col>
                </FormGroup>


                <FormGroup>
                    <Col sm={2}></Col>                    
                    <Col sm={4}>
                    <button onClick={this.editEvent} className="btn btn-primary">Edytuj</button>
                    <Link to={"/NewLecture/" + this.state.eventID} style={{color: 'black'}}>
                    <button className="btn btn-primary"> Dodaj wykład do wydarzenia </button>
                    </Link>
                    </Col>
                    <Col sm={1}></Col>                    
                </FormGroup>

            </Form>
        );
    }
}

export default withRouter(EditEvent);