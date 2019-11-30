import React from 'react';
import { compose } from 'redux';
import { connect } from 'react-redux';

import { logoutUser } from '../redux/actions/authentication';
import { withRouter } from 'react-router-dom';


function TopBar(props){
    return (
        <nav className="navbar">
            <div className="container-fluid">
                <div className="navbar-holder d-flex align-items-center justify-content-between">
                    <div className="navbar-header">
                        <span id="toggle-btn" className="menu-btn active" onClick={props.onToggle}><span></span><span></span><span></span></span>
                    </div>
                </div>
            </div>
        </nav>
    );
}
const mapStateToprops = (state) => ({
    auth: state.auth
  });
export default compose( connect(mapStateToprops, { logoutUser })(withRouter(TopBar)));
  
  