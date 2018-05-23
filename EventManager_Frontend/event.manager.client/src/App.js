import React from 'react';
import HomeNavbar from './components/Navbar/index';
import NewLecture from './components/NewLecture/index';
import Home from './components/Home/index';
import NewEvent from './components/NewEvent/index';
import ShowEvents from './components/ShowEvents/index';
import NewReview from './components/NewReview/index';
import EditEvent from './components/EditEvent/index';
import EditLecture from './components/EditLecture/index';
import {BrowserRouter as Router,Route, Switch } from 'react-router-dom';
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
                      <Route exact path="/ShowEvents" component={ShowEvents}/>
                      <Route exact path="/EditEvent/:id" component={EditEvent}/>
                      <Route exact path="/EditLecture" component={EditLecture}/>
                  </Switch>
          </Router>


      </div>
    );
  }
}

export default App;
