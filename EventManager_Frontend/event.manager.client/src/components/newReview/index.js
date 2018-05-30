import React from 'react';
import axios from 'axios';
import { withRouter } from 'react-router-dom'
import {Row ,Button, Form, FormControl, ControlLabel, Col, PageHeader} from 'react-bootstrap';
import NumericInput from 'react-numeric-input';

class NewReview extends React.Component {
    constructor()
    {
        super();
        this.state = {
            nickname: '',
            rate:null,
            comment: '',
            lectureId:null,
            reviewerId: 1
        };
    }

    onChangeName = (review) =>{
        this.setState({nickname: review.target.value})
    }

    onChangeRate = (review) =>{
        this.setState({rate: review.target.value})
    }

    onChangeComment = (review) =>{
        this.setState({comment: review.target.value})
    }

    onChangeLectureId = (review) =>{
        this.setState({lectureId: review.target.value})
    }

    onChangeReviewerId = (review) =>{
        this.setState({reviewerId: review.target.value})
    }


    addReview = () => {
        axios.post('/review', {nickname: this.state.nickname, rate: this.state.rate, comment: this.state.comment, lectureId: this.state.lectureId, reviewerId: this.state.reviewerId})
            .then(()=>{
            })
            .catch((err)=>{
                console.log(err);
            });
    }

    componentDidMount()
    {
        this.setState({lectureId: this.props.match.params.id});
    }

    render() {
        return (
            <Form horizontal>
                <Row>
                    <Col sm={2}> </Col>
                    <Col sm={9}> 
                        <PageHeader>Dodawanie opinii</PageHeader>
                    </Col>
                </Row>
                <Row>
                    <Col componentClass={ControlLabel} sm={2}> Nazwa </Col>
                    <Col sm={9}>
                        <FormControl onBlur={this.onChangeName} placeholder="Podaj nick"/>
                    </Col>
                </Row>
                <Row>
                    <Col componentClass={ControlLabel} sm={2}> Ocena (1-10): </Col>
                    <Col sm={9}>
                        <NumericInput className="form-control" onBlur={this.onChangeRate} 
                        placeholder="Podaj ocene" step={ 1 } max={10} min={0}/>
                    </Col>
                </Row>
                <Row>
                    <Col componentClass={ControlLabel} sm={2}> Komenatrz </Col>
                    <Col sm={9}>
                        <FormControl componentClass="textarea" onBlur={this.onChangeComment}
                                     placeholder="Wpisz komentarz"/>
                    </Col>
                </Row>
                <Row>
                    <br></br>
                    <Col sm={2}></Col>
                    <Col sm={4}>
                    <Button onClick={this.addReview} className="btn btn-primary">Dodaj</Button>
                    </Col>
                    <Col sm={1}></Col>
                </Row>
            </Form>
        );
    }
}

export default withRouter(NewReview);