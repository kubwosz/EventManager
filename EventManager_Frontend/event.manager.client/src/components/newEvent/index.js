import "react-dates/initialize";
import React from 'react';
import axios from 'axios';
import { withRouter } from 'react-router-dom';
import { DateRangePicker, SingleDatePicker, DayPickerRangeController } from 'react-dates';
import {Button} from 'react-bootstrap';
import 'react-dates/lib/css/_datepicker.css';
import moment from 'moment';
import { TimePicker } from 'antd';
import 'antd/dist/antd.css';

class NewEvent extends React.Component {
    constructor()
    {
        super();
        this.state = {
            name: '',
            startDate: '',
            endDate: '',
            startTime: '',
            endTime: '',
            participantNumber: null,
            description: '',
            focusedInput: null
        };
    }


    onChangeName = (event) =>{
        this.setState({name: event.target.value})
    }

    onChangeParticipantNumber = (event) =>{
        this.setState({participantNumber: event.target.value})
    }

    onChangeStartTime = (event) =>{
        this.setState({startTime: moment(event).format("HH:mm:ss").toString()});
    }

    onChangeEndTime = (event) =>{
        this.setState({endTime: moment(event).format("HH:mm:ss").toString()});
    }

    onChangeDescription = (event) =>{
        this.setState({description: event.target.value})
    }


    addEvent = () => {
        if( this.state.startTime==="" || this.state.startDate==="" || this.state.endTime===""|| this.state.endDate===""){
            window.confirm("Należy wypełnić wszystkie pola!");
        }

        let startTmp = (moment(this.state.startDate).format("YYYY-MM-DD").toString() + "T" + this.state.startTime);
        let endTmp =  (moment(this.state.endDate).format("YYYY-MM-DD").toString() + "T" + this.state.endTime);

        axios.post('/event', {ownerId: 1, name: this.state.name, participantNumber: this.state.participantNumber, startDate: startTmp, endDate: endTmp, description: this.state.description })
            .then(()=>{
                window.confirm('Wydarzenie zostało utworzone poprawnie!');
            })
            .catch((err)=>{
                console.log(err);
            });
    }

    render() {
        return (
            <div>
                <div>
                    <h1>Dodawanie wydarzenia:</h1>
                    <input onChange={this.onChangeName} value={this.state.name} placeholder="Podaj nazwę konferencji" className="form-control"/>
                    <input onChange={this.onChangeParticipantNumber} value={this.state.participantNumber === null ? "" : this.state.participantNumber } placeholder="Podaj liczbę uczestników" className="form-control"/>
                    <input onChange={this.onChangeDescription} value={this.state.description} placeholder="Podaj opis" className="form-control"/>
                    <DateRangePicker
                        startDate={this.state.startDate}
                        endDate={this.state.endDate}
                        onDatesChange={({ startDate, endDate }) => this.setState({startDate, endDate})}
                        focusedInput={this.state.focusedInput}
                        onFocusChange={focusedInput => this.setState({ focusedInput })}
                    />
<br/>
                    <TimePicker onChange={this.onChangeStartTime} defaultValue={moment('12:08', "HH:mm")} format={"HH:mm"} />
                    <TimePicker onChange={this.onChangeEndTime} defaultValue={moment('12:08', "HH:mm")} format={"HH:mm"} />
                    <br/>
                    <Button onClick={this.addEvent} className="btn btn-info center-block">Dodaj wydarzenie!</Button>
                </div>
                <div className="container-fluid">
                </div>
            </div>
        );
    }
}

export default withRouter(NewEvent);
