import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import HomeNavbar from './components/Navbar';
import {Label, FormControl, Button, ButtonToolbar} from 'react-bootstrap';

class App extends Component {
  render() {
    return (
      <div className="App">
       <HomeNavbar/>
       <h1>
     <Label>Proszę wpisać nazwę:</Label>
  </h1>
  <FormControl
            type="text"
            placeholder="Enter text"
            onChange={this.handleChange}
          />
          
<div style={{display: 'flex', justifyContent: 'center'}}>
    <ButtonToolbar >
  <Button bsSize="large" bsStyle="primary">GET</Button>

  <Button bsSize="large" bsStyle="success">POST</Button>

  <Button bsSize="large" bsStyle="warning">PUT</Button>

  <Button bsSize="large" bsStyle="danger">DELETE</Button>
  </ButtonToolbar>
</div>

      </div>
    );
  }
}

export default App;
