//import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux'
import store from './redux/store';
//import { BrowserRouter } from 'react-router-dom';
import App from './App';
//import registerServiceWorker from './registerServiceWorker';

//auth -----------------------
//////---import jwt_decode from 'jwt-decode';
//import setAuthToken from './setAuthToken';
//////---import { setCurrentUser, logoutUser } from './redux/actions/authentication';
//import { mostrarUsosMultiples } from './redux/actions/usosMultiplesActions';
//end auth -----------------------

/*if(localStorage._token) {
    //setAuthToken(localStorage.jwtToken);
    const decoded = jwt_decode(localStorage._token);
    store.dispatch(setCurrentUser(decoded));
    //store.dispatch(mostrarUsosMultiples());
    
    const currentTime = Date.now() / 1000;
    if(decoded.exp < currentTime) {
      store.dispatch(logoutUser());
      window.location.href = '/entrar'
    }
}*/

//const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
    <Provider store={store}>
    <App />
   </Provider>,
  rootElement);

//registerServiceWorker();

