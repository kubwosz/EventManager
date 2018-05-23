import React from 'react';
import { withRouter } from 'react-router-dom';
import axios from 'axios';
import {Link} from 'react-router-dom'

class EditLecture extends React.Component {
    constructor(){
        super();
        this.state = {
            lectureId: null,
            lectureName: '',
            lectureStartDate: '',
            lectureEndDate: '',
            lectureParticipantNumber:null,
            lectureDescription: '',
            eventId: null,
        };
    }


    
    onChangeName = (event) =>{
        this.setState({lectureName: event.target.value})
    }

    onChangeParticipantNumber = (event) =>{
        this.setState({lectureParticipantNumber: event.target.value})
    }

    onChangeStartDate = (event) =>{
        this.setState({lectureStartDate: event.target.value})
    }

    onChangeEndDate = (event) =>{
        this.setState({lectureEndDate: event.target.value})
    }

    onChangeDescription = (event) =>{
        this.setState({lectureDescription: event.target.value})
    }

    onChangeEventId = (event) =>{
        this.setState({eventId: event.target.value})
    }

    onChangeLectureId = (event) =>{
        this.setState({lectureId: event.target.value})
    }

    editLecture = () => {
        axios.put('/lecture', {ownerId: 1, id: this.state.lectureId, name: this.state.lectureName, participantNumber: this.state.lectureParticipantNumber, startDate: this.state.lectureStartDate, endDate: this.state.lectureEndDate, description: this.state.lectureDescription, eventId: this.state.eventId })
            .then(()=>{
                window.confirm('Edycja wykładu przeszła pomyślnie!');
            })
            .catch((err)=>{
                console.log(err);
            });
    }



    render() {
        return( 
        <div>
            <h1>Edytuj wykład</h1>
                <div className="container">
                    <label>Podaj dane do zmiany: </label>
                                     
                    <input onChange={this.onChangeName} defaultValue={this.state.lectureName} placeholder="Nazwa" className="form-control"/>
                    <input onChange={this.onChangeParticipantNumber} defaultValue={this.state.participantNumber} placeholder="Liczba uczestników" className="form-control"/>
                    <input onChange={this.onChangeStartDate} defaultValue={this.state.lectureStartDate} placeholder="Data rozpoczęcia" className="form-control"/>
                    <input onChange={this.onChangeEndDate} defaultValue={this.state.lectureEndDate} placeholder="Data zakończenia" className="form-control" />
                    <input onChange={this.onChangeDescription} defaultValue={this.state.lectureDescription} placeholder="Opis" className="form-control"/>
                    <input onChange={this.onChangeEventId} defaultValue={this.state.eventId} placeholder="Podaj id wydarzenia" className="form-control"/>
                    <input onChange={this.onChangeLectureId} defaultValue={this.state.lectureId} placeholder="Id wykładu" className="form-control"/>

                    <button onClick={this.editLecture} className="btn btn-info">Edytuj</button>                                    
                 </div> 
                 <div className="container">
                 </div>
        </div>
       );
    }
}

export default withRouter(EditLecture);