import React from 'react';
import axios from 'axios';
import moment from 'moment';
import {ListGroup,ListGroupItem} from 'react-bootstrap';
import {withRouter, Link} from 'react-router-dom'
import {Form, FormGroup, FormControl, ControlLabel, Col, PageHeader, Badge, Row
, Grid, Table, Button} from 'react-bootstrap';

const pathEvent = '/event/';
const pathLecture = '/lecture/';

class ShowEvent extends React.Component {
    constructor()
    {
        super();
        this.state = {
            event: [],
            lectures: []
        };
    }

    componentDidMount() {
        this.getEvent();
    }

    getEvent() {
        axios.get(pathEvent + this.props.match.params.id)
            .then((response) => {
                console.log(response);
                this.setState({
                    event: response.data
                });
            })
            .catch(function (error) {
                console.log("err2");
                console.log(error);
            });
    }

    getAllLectures() {
        axios.get(pathLecture)
            .then((response) => {
                console.log(response);
                this.setState({
                    lectures: response.data,
                    total: response.data.length
                });
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    renderTable() {
        this.getAllLectures();                
        if(this.state.lectures !== 0) {
            return this.state.lectures.map( (option) => (
                <tr key={option.id}> <td>{option.name}</td> <td>{option.description}</td> <td>{this.parseDate(option.startDate)}</td> 
                   <td width="10%"> <Link to={"/NewReview/" + option.id} style={{color: 'black'}}>
                     <Button className="btn btn-primary center-block" > Zapisz </Button>
                        </Link></td>
                   <td width="10%"> <Button className="btn btn-primary center-block" > Oceń </Button>  </td>
                   </tr>
            ));
        }
        else
        {
            return (
                <tr>" "</tr>
            );
        }
    }

    parseDate(date)
    {
        return (
            moment(date).format("DD.MM.YYYY") + "  " + moment(date).format("HH:mm")
        )
    }

    render() {
        return (
        <Col>
            <Col>
                <Col sm={1}></Col>
                <Col sm={10}> 
                    <PageHeader > {this.state.event.name} </PageHeader> 
                </Col>
            </Col>
            <Grid sm={10}>
                <Col sm={4}>
                    <Row>
                    <br></br>
                    <Col componentClass={ControlLabel} sm={5}> Liczba uczestników </Col>
                    <Col componentClass={Badge} sm={5}>{this.state.event.participantNumber} </Col>
                    </Row>

                    <Row>                    
                    <Col componentClass={ControlLabel} sm={5}> Data rozpoczęcia </Col>
                    <Col componentClass={Badge} sm={5}>{this.parseDate(this.state.event.startDate)} </Col>
                    </Row>

                    <Row>
                    <Col componentClass={ControlLabel} sm={5}> Data zakończenia </Col>
                    <Col componentClass={Badge} sm={5}>{this.parseDate(this.state.event.endDate)} </Col>
                    </Row>

                    <Row>
                    <Col componentClass={ControlLabel} sm={5}> Opis </Col>
                    <Col componentClass={Badge} sm={5}>{this.state.event.description} </Col>
                    </Row>

                    <Row>
                    <br></br>
                    <Col sm={5}>
                    <Link to={"/NewLecture/" + this.state.eventID} style={{color: 'black'}}>
                    <Button className="btn btn-primary"> Dodaj wykład do wydarzenia </Button>
                    </Link>
                    </Col>
                    </Row>
                </Col>
                <Col sm={8}>
                <Table>
                    <thead>
                        <tr>
                        <th width="30%">Nazwa</th>
                        <th width="40%">Opis</th>
                        <th width="30%">Data rozpoczęcia</th>
                        <th width="10%"></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.renderTable()}
                    </tbody>
                </Table>
                </Col>
            </Grid>
        </Col>
        );
    }
}

export default withRouter(ShowEvent);
