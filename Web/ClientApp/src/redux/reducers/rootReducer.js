import { combineReducers } from 'redux';
import authReducer from './authReducer';
import cursos from './cursosReducers';


export default combineReducers({
    auth: authReducer,
    cursos
});