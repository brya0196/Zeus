import React from "react";
import { connect } from 'react-redux';
import {
    BrowserRouter as Router,
    Route,
    Switch
} from 'react-router-dom'

import "./App.scss"

import Login  from './views/cuenta/login';
import Layout from './components/Layout';

function App() {
      return (
          <Router>
              <Switch>
                  <Route exact path='/entrar' component={Login} />
                  <Route path="/" component={Layout} />
              </Switch>
          </Router> 
    );
}
const mapStateToProps = state => ({
  ...state
});

export default connect(mapStateToProps)(App);