import React from 'react';
import { withRouter, Link } from 'react-router-dom';
import addLecture from '../../apiCalls/lectureApiCall';
import { DateRangePicker} from 'react-dates';
import NumericInput from 'react-numeric-input';
import {Row ,Button, Form, FormControl, ControlLabel, Col, PageHeader,Label} from 'react-bootstrap';
import { TimePicker } from 'antd';
import moment from "moment/moment";
import axios from "axios/index";
const pathEvent = '/event/';


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
            eventId: null,
            eventStartTime: '',
            eventEndTime:'',
            eventName: ''
        };
    }

    componentDidMount() {
        this.getEvent();

        this.setState({
            eventId: this.props.match.params.id,
        });
    }

    getEvent() {
        axios.get(pathEvent + this.props.match.params.id)
            .then((response) => {
                console.log(response.data);
                this.setState({
                    eventStartTime: response.data.startDate,
                    eventEndTime: response.data.endDate,
                    eventName: response.data.name
                });
            })
            .catch(function (error) {
                console.log("err2");
                console.log(error);
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
                        <Row>
                            <h4>Informacje o wydarzeniu:</h4>
                        </Row>
                        <Row>
                            <h4>
                                <Label > Nazwa </Label> {this.state.eventName}
                            </h4>
                        </Row>
                        <Row>
                            <h4>
                                <Label > Czas rozpoczęcia </Label> {moment(this.state.eventStartTime).format("DD-MM-YYYY")}
                            </h4>
                        </Row>
                        <Row>
                            <h4>
                                <Label > Czas zakończenia </Label> {moment(this.state.eventEndTime).format("DD-MM-YYYY")}
                            </h4>
                        </Row>
                    </Col>
                </Row>
                <Row>

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
                    <Button onClick={() => addLecture(this.state,this.props)} className="btn btn-primary">Dodaj wykład</Button>
                    </Link>
                    </Col>
                    <Col sm={1}></Col>
                </Row>
            </Form>
        );
    }
}

export default withRouter(NewLecture);