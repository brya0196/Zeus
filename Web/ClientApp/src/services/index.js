//import { createBrowserHistory } from "history";
import {getIdToken, getTokenInfo} from './auth'; //isLoggedIn
//import {PouchDB_GetCliente,PouchDB_AddCliente} from './localDB'
import Swal from 'sweetalert2';
const axios = require('axios');
//var online = window.navigator.onLine;

const base_url = "/";
export const API = axios.create({
    baseURL: base_url,
   // timeout: 1000,
    headers: {
        'contentType': 'application/json; charset=utf-8',
        'Authorization': 'Bearer '+ getIdToken()
    }
});
API.interceptors.response.use(function (response) {
    return response;
}, function (error) {
    if(error.response){
        if(error.response.status === 401){
          // window.location.href = "/entrar";
        }else if(error.response.status === 403){
            Swal.fire( "Oops" ,  "Acceso denegado");
        } else if (error.response.status === 404) {
       //     window.location.href = "/404";

        }
    }
    return Promise.reject(error);
});


//cursos
export function getCursos() {
    const user = JSON.parse( localStorage.getItem("_user"));
    return API.get('api/pensum/' + user.careerId);
}
export function addCurso(obj) {
    return API.post('cursos', obj);
}
export function editCurso(obj) {
    return API.put('cursos', obj);
}
export function delCurso(id) {
    return API.delete(`cursos/${id}`);
} 
//user
export function getUserInfo() {
    return API.get('api/user');
}
//Seleccion
export function getSelection() {
    const user = JSON.parse( localStorage.getItem("_user"));

    return API.get(`api/selection/${user.id}`);
}
export function getSelectionCar() {
    const user = JSON.parse( localStorage.getItem("_user"));

    return API.get(`api/selection/${user.id}`);
}




