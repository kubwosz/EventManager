import React from 'react';
import { withRouter } from 'react-router-dom';
import axios from 'axios';
import addEvent from '../../ApiCalls/Event';

class EditLecture extends React.Component {
    constructor(){
        super();
        this.state = {
            lectureId: null,
            name: '',
            lectureStartDate: '',
            lectureEndDate: '',
            participantNumber:null,
            lectureDescription: '',
            eventId: null,
        };
    }

    onChangeId = (lecture) =>{
        this.setState({lectureId: lecture.target.value})
    }
    
    onChangeName = (lecture) =>{
        this.setState({name: lecture.target.value})
    }

    onChangeParticipantNumber = (lecture) =>{
        this.setState({participantNumber: lecture.target.value})
    }

    onChangeStartDate = (lecture) =>{
        this.setState({lectureStartDate: lecture.target.value})
    }

    onChangeEndDate = (lecture) =>{
        this.setState({lectureEndDate: lecture.target.value})
    }

    onChangeDescription = (lecture) =>{
        this.setState({lectureDescription: lecture.target.value})
    }

    onChangeEventId = (lecture) =>{
        this.setState({eventId: lecture.target.value})
    }

    editLecture = (e) => {
        axios.put('/lecture', {id: this.state.lectureId, name: this.state.name, participantNumber: this.state.participantNumber, lecturestartDate: this.state.lectureStartDate, lectureendDate: this.state.lectureEndDate, lectureDescription: this.state.lectureDescription, eventId: this.state.eventId })
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
                    <input onChange={this.onChangeId} defaultValue={this.state.lectureId} placeholder="Id" className="form-control"/>                    
                    <input onChange={this.onChangeName} defaultValue={this.state.lectureName} placeholder="Nazwa" className="form-control"/>
                    <input onChange={this.onChangeParticipantNumber} defaultValue={this.state.participantNumber} placeholder="Liczba uczestników" className="form-control"/>
                    <input onChange={this.onChangeStartDate} defaultValue={this.state.lectureStartDate} placeholder="Data rozpoczęcia" className="form-control"/>
                    <input onChange={this.onChangeEndDate} defaultValue={this.state.lectureEndDate} placeholder="Data zakończenia" className="form-control" />
                    <input onChange={this.onChangeDescription} defaultValue={this.state.lectureDescription} placeholder="Opis" className="form-control"/>
                    <input onChange={this.onChangeEventId} defaultValue={this.state.eventId} placeholder="Id" className="form-control"/>
                    <button onClick={this.editLecture} className="btn btn-info">Edytuj</button>                                    
                 </div> 
                 <div className="container">
                 </div>
        </div>
       );
    }
}

export default withRouter(EditLecture);