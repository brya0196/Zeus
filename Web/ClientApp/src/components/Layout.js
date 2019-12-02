import React, { Component } from 'react';
import { Switch, Redirect, Route } from "react-router-dom";
import Routes from "../routes";
import {isLoggedIn} from '../services/auth';
import { connect } from 'react-redux';

import TopBar from './TopBar';
import NavMenu  from './NavMenu';

class Layout extends Component {
    drawerToggle = () => {
        document.getElementById("toggle-btn").classList.toggle("active");
        document.querySelector(".side-navbar").classList.toggle('shrinked');
        document.querySelector(".content-inner").classList.toggle('active');
        document.querySelector(".underSidebar").classList.toggle('active');
      if (window.outerWidth < 1200) {
            document.querySelector(".side-navbar").classList.toggle('phone');
        }
    };
    componentDidUpdate(prevProps) {
      if (this.props.location !== prevProps.location && window.outerWidth <= 1200) {
        const active = document.getElementById("toggle-btn").classList.value.includes("active");
        if(!active)
          this.drawerToggle();
      }
    }
    render() {
      

      //ver si esta loggeado
      const {auth} = this.props;
      if (!isLoggedIn() || !auth.isAuthenticated) {
        this.props.history.push('/entrar');
        return false
      }

      const switchRoutes = (
          <Switch>
            {Routes.map((prop, key) => {
                if(prop.redirect){
                  return <Redirect from={prop.path} to={prop.to} key={key}/>;
                }else{
                  return <Route path={prop.path} render={(props) => <prop.component {...props} title={prop.title} />} key={key} exact={true} />
                }
            })}
          </Switch>
        );
      return (
        <>
          <div className="page">
              <div className="page-content d-flex align-items-stretch">
                  <NavMenu onToggle={this.drawerToggle} />
                  <div className="content-inner">
                          <header className="header">
			                  <TopBar onToggle={this.drawerToggle} />
			              </header>
                      {switchRoutes}
                  </div>
              </div>
          </div>
        </>
      );
  }
}

const mapStateToProps = (state) => ({
  auth: state.auth,
});
export default connect(mapStateToProps)(Layout);

