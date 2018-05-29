import React from 'react';
import HomeNavbar from './components/navbar';
import NewLecture from './components/newLecture';
import Home from './components/home';
import NewEvent from './components/newEvent';
import ListEvents from './components/listEvents';
import ShowEvent from './components/showEvent';
import PageNotFound from './components/pageNotFound';
import NewReview from './components/newReview';
import {BrowserRouter as Router,Route, Switch } from 'react-router-dom';
import EditEvent from './components/editEvent';
import 'react-dates/initialize';

class App extends React.Component {
  render() {
    return (
      <div className="App">
          <HomeNavbar/>
          <Router>
                  <Switch>
                      <Route exact path="/" component={Home}/>
                      <Route exact path="/home" component={Home}/>
                      <Route exact path="/NewEvent" component={NewEvent}/>
                      <Route exact path="/NewLecture/:id" component={NewLecture}/>
                      <Route exact path="/ShowEvents" component={ListEvents}/>
                      <Route exact path="/ShowEvent/:id" component={ShowEvent}/>
                      <Route exact path="/EditEvent/:id" component={EditEvent}/>
                      <Route exact path="/newReview/:id" component={NewReview}/>
                      <Route exact path="/*" component={PageNotFound}/>
                  </Switch>
          </Router>
      </div>
    );
  }
}

export default App;
