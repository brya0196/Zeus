import {SET_CURRENT_USER } from './types';
import jwt_decode from 'jwt-decode';

export const setCurrentUserInfo = (token) => dispatch => {
    const decoded = jwt_decode(token);
    dispatch(setCurrentUser(decoded));
};
export const logoutUser = () => dispatch => {
    localStorage.removeItem('_token');
    localStorage.removeItem('_user');
    //setAuthToken(false);
    dispatch(setCurrentUser({}));

    window.location.href = '/entrar';
};
export const setCurrentUser = decoded => {
    return {
        type: SET_CURRENT_USER,
        payload: decoded
    }

};