import React from 'react';
import axios from 'axios';
import { withRouter } from 'react-router-dom';
import { DateRangePicker, SingleDatePicker, DayPickerRangeController } from 'react-dates';
import 'react-dates/lib/css/_datepicker.css';
import moment from 'moment';

class NewEvent extends React.Component {
    constructor()
    {
        super();
        this.state = {
            name: '',
            startDate: '',
            endDate: '',
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

    onChangeStartDate = (event) =>{
        this.setState({startDate: event.target.value})
    }

    onChangeEndDate = (event) =>{
        this.setState({endDate: event.target.value})
    }

    onChangeDescription = (event) =>{
        this.setState({description: event.target.value})
    }


    addEvent = () => {
        axios.post('/event', {ownerId: 1, name: this.state.name, participantNumber: this.state.participantNumber, startDate: this.state.startDate, endDate: this.state.endDate, description: this.state.description })
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
                    <input onChange={this.onChangeStartDate} value={moment(this.state.startDate).format("YYYY-MM-DD")} placeholder="Podaj datę startu" className="form-control"/>
                    <input onChange={this.onChangeEndDate} value={moment(this.state.endDate).format("YYYY-MM-DD")} placeholder="Podaj endDate" className="form-control"/>
                    <input onChange={this.onChangeDescription} value={this.state.description} placeholder="Podaj opis" className="form-control"/>

                    <DateRangePicker
                        startDate={this.state.startDate} // momentPropTypes.momentObj or null,
                        endDate={this.state.endDate} // momentPropTypes.momentObj or null,
                        onDatesChange={({ startDate, endDate }) => this.setState(
                            {
                                startDate,
                                endDate
                            }
                            )}
                        focusedInput={this.state.focusedInput} // PropTypes.oneOf([START_DATE, END_DATE]) or null,
                        onFocusChange={focusedInput => this.setState({ focusedInput })} // PropTypes.func.isRequired,
                    />
<br/>

                    <button onClick={this.addEvent} className="btn btn-info">Dodaj wydarzenie!</button>
                </div>
                <div className="container-fluid">
                </div>
            </div>
        );
    }
}

export default withRouter(NewEvent);
