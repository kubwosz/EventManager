import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import HomeNavbar from './components/Navbar';
import Event from './components/Event';
import {Label, FormControl, Button, ButtonToolbar} from 'react-bootstrap';
import NewEvent from './components/NewEvent';
import { BrowserRouter, Route } from 'react-router-dom';

class App extends Component {
render() {
  return (
      <div className="App">
        <BrowserRouter>
          <div>
              <Route path='/new' component={NewEvent}/>
              <Route exact path='/' component={Event}/>
          </div>
        </BrowserRouter>
      </div>
  );
}
}



/*
class App extends Component {
  render() {
    return (
      <div className="App">
       <HomeNavbar/>
       <h1>
     <Label>Obsługa konferencji</Label>
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

     <h1>
     <Label>Dodaj konferencje</Label>
  </h1>

<textarea class="form-control" rows="1">Nazwa konferencji</textarea>



 <ButtonToolbar >
<Button bsSize="large" bsStyle="primary">Dodaj konferencje</Button>
</ButtonToolbar>
      </div>
    );
  }
}
*/
export default App;
