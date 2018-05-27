import React from 'react';
import axios from 'axios';
import {ListGroup,ListGroupItem} from 'react-bootstrap';
import {withRouter, Link} from 'react-router-dom'
import {Form, FormGroup, FormControl, ControlLabel, Col, PageHeader, Badge, Row
, Grid, Table} from 'react-bootstrap';

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
                <tr key={option.id}> <td>{option.name}</td> <td>{option.description}</td> <td>{option.startDate}</td> </tr>
            ));
        }
        else
        {
            return (
                <option>" "</option>
            );
        }
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
                    <Col componentClass={Badge} sm={5}>{this.state.event.startDate} </Col>
                    </Row>

                    <Row>
                    <Col componentClass={ControlLabel} sm={5}> Data zakończenia </Col>
                    <Col componentClass={Badge} sm={5}>{this.state.event.endDate} </Col>
                    </Row>

                    <Row>
                    <Col componentClass={ControlLabel} sm={5}> Opis </Col>
                    <Col componentClass={Badge} sm={5}>{this.state.event.description} </Col>
                    </Row>

                    <Row>
                    <br></br>
                    <Col sm={5}>
                    <Link to={"/NewLecture/" + this.state.eventID} style={{color: 'black'}}>
                    <button type="button" className="btn btn-primary"> Dodaj wykład do wydarzenia </button>
                    </Link>
                    </Col>
                    </Row>
                </Col>
                <Col sm={8}>
                <Table>
                    <thead>
                        <tr>
                        <th>Nazwa</th>
                        <th>Opis</th>
                        <th>Data rozpoczęcia</th>
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
