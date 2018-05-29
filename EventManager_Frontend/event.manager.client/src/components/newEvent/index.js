import "react-dates/initialize";
import React from 'react';
import { withRouter } from 'react-router-dom';
import { DateRangePicker } from 'react-dates';
import {Form, FormControl, ControlLabel, Col, PageHeader, Row} from 'react-bootstrap';
import NumericInput from 'react-numeric-input';
import {Button} from 'react-bootstrap';
import 'react-dates/lib/css/_datepicker.css';
import moment from 'moment';
import { TimePicker } from 'antd';
import 'antd/dist/antd.css';
import {addEvent} from '../../apiCalls/eventApiCall';


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
        this.setState({name: event.target.value});
        console.log(this.state.name);
    }

    onChangeUserName = (event) =>{
        this.setState({userName: event.target.value})
    }

    onChangeUserSurname = (event) =>{
        this.setState({userSurname: event.target.value})
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
    
    render() {
        return (
            <Row>
                <Form horizontal>
                    <Row>
                        <Col sm={2}> </Col>
                        <Col sm={9}>
                            <PageHeader > Dodawanie wydarzenia </PageHeader>
                        </Col>
                    </Row>

                    <Row>
                        <Col componentClass={ControlLabel} sm={2}> Nazwa </Col>
                        <Col sm={9}>
                            <FormControl onBlur={this.onChangeName}  placeholder="Podaj nazwę wydarzenia"/>
                        </Col>
                    </Row>
                    <Row>
                        <Col componentClass={ControlLabel} sm={2}> Imię </Col>
                        <Col sm={9}>
                            <FormControl onBlur={this.onChangeUserName}  placeholder="Podaj imię"/>
                        </Col>
                    </Row>
                    <Row>
                        <Col componentClass={ControlLabel} sm={2}> Nazwisko </Col>
                        <Col sm={9}>
                            <FormControl onBlur={this.onChangeUserSurname}  placeholder="Podaj nazwisko"/>
                        </Col>
                    </Row>
                    <Row>
                        <Col  componentClass={ControlLabel} sm={2}> Liczba uczestników </Col>
                        <Col sm={9}>
                            <NumericInput
                                className="form-control"
                                value={ this.state.participantNumber }
                                min={ 0 }
                                max={ 100000 }
                                step={ 1 }
                                onBlur={this.onChangeParticipantNumber}
                                placeholder="Podaj liczbę uczestników"
                            />
                        </Col>
                    </Row>
                    <Row>
                        <Col componentClass={ControlLabel} sm={2}> Opis </Col>
                        <Col sm={9}>
                            <FormControl componentClass="textarea"
                                         placeholder={this.state.description}
                                         onBlur={this.onChangeDescription}
                                         placeholder="Podaj opis"
                            />
                        </Col>
                    </Row>
                    <Row>
                        <Col componentClass={ControlLabel} sm={2}> Czas rozpoczęcia  </Col>
                        <Col sm={9}>
                                <TimePicker onChange={this.onChangeStartTime} placeholder={"HH:MM"} format={"HH:mm"} minuteStep={5} />
                        </Col>
                    </Row>
                    <Row>                    
                        <Col componentClass={ControlLabel} sm={2}> Czas zakończenia </Col>
                        <Col sm={9}>
                                <TimePicker onChange={this.onChangeEndTime} placeholder={"HH:MM"} format={"HH:mm"} minuteStep={5} />
                        </Col>
                    </Row>
                    <Row>
                        <Col componentClass={ControlLabel} sm={2}> Data rozpoczęcia oraz zakończenia </Col>
                        <Col sm={9}>
                            <DateRangePicker
                                startDate={this.state.startDate}
                                endDate={this.state.endDate}
                                endDatePlaceholderText={"Start"}
                                startDatePlaceholderText={"Koniec"}
                                onDatesChange={({ startDate, endDate }) => this.setState({startDate, endDate})}
                                focusedInput={this.state.focusedInput}
                                onFocusChange={focusedInput => this.setState({ focusedInput })}
                            />
                        </Col>
                    </Row>

                    <Row>
                        <br></br>
                        <Col sm={2}></Col>
                        <Col sm={4}>
                            <Button onClick={() => addEvent(this.state)} className="btn btn-info">Dodaj wydarzenie</Button>
                        </Col>
                        <Col sm={1}></Col>
                    </Row>
                </Form>
            </Row>
        );
    }
}

export default withRouter(NewEvent);
