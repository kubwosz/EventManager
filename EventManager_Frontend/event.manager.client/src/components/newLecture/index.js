import React from 'react';
import { withRouter, Link } from 'react-router-dom';
import addLecture from '../../apiCalls/lectureApiCall';
import { DateRangePicker} from 'react-dates';
import NumericInput from 'react-numeric-input';
import {Row ,Button, Form, FormControl, ControlLabel, Col, PageHeader} from 'react-bootstrap';
import { TimePicker } from 'antd';
import moment from "moment/moment";

class NewLecture extends React.Component {
    constructor()
    {
        super();
        this.state = {
            name: '',
            startDate: undefined,
            endDate: undefined,
            startTime: '',
            endTime: '',
            participantNumber:null,
            description: '',
            eventId: null
        };
    }

    componentDidMount() {
                this.setState({
                    eventId: this.props.match.params.id,
                });
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


    render() {
        return (
            <Form horizontal>
                <Row>
                    <Col sm={2}> </Col>
                    <Col sm={9}> 
                        <PageHeader>Dodawanie wykładu</PageHeader>
                    </Col>
                </Row>
                <Row>
                    <Col componentClass={ControlLabel} sm={2}> Nazwa </Col>
                    <Col sm={9}>
                        <FormControl onBlur={this.onChangeName}  placeholder="Podaj nazwę wykładu"/>
                    </Col>
                </Row>
                <Row>
                    <Col componentClass={ControlLabel} sm={2}> Liczba uczestników </Col>
                    <Col sm={9}>
                        <NumericInput className="form-control" onBlur={this.onChangeParticipantNumber} 
                        placeholder="Podaj liczbę uczestników" step={ 1 }
                        value={this.state.participantNumber===null ? "" : this.state.participantNumber} />
                    </Col>
                </Row>
                <Row>
                    <Col componentClass={ControlLabel} sm={2}> Opis </Col>
                    <Col sm={9}>
                        <FormControl componentClass="textarea" onBlur={this.onChangeDescription}
                                     placeholder="Podaj opis"/>
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
                                startDateId = "1"
                                endDateId = "1"
                                startDate={this.state.startDate}
                                startDateId="your_unique_start_date_id"
                                endDate={this.state.endDate}
                                endDateId="your_unique_end_date_id"
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
                    <Link to={"/showEvent/" + this.state.eventId}>
                    <Button onClick={() => addLecture(this.state,this.props)} className="btn btnprimary">Dodaj wykład</Button>
                    </Link>
                    </Col>
                    <Col sm={1}></Col>
                </Row>
            </Form>
        );
    }
}

export default withRouter(NewLecture);