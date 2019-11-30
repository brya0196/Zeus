import React, { useContext } from 'react';
import {Redirect, Route } from "react-router-dom";
import { contextUserInfo } from "../contexts/contextUserInfo";


const PrivateRoute = ({ component: RouteComponent, title, ...rest }) => {
    const userInfo = useContext(contextUserInfo);

    return (
        <Route
            render={
                routeProps =>
                    userInfo.isAuth
                        ? <RouteComponent {...routeProps} title={title} />
                        : <Redirect to="/entrar" />
            }
            {...rest}
        />
    );

};

export default PrivateRoute
