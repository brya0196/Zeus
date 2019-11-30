import { cursosTypes } from './types';
import { getCursos, addCurso, editCurso, delCurso } from '../../services';
import _ from 'lodash';

export function mostrarCursos() {
    return dispatch => {
        dispatch({
            type: cursosTypes.MOSTRAR_CURSOS,
            payload: getCursos()
        })
    }
}
export function toggleModal(id) {
    return (dispatch, getState) => {
        if (getState().cursos.showModal){
            dispatch({ type: cursosTypes.CERRAR_MODAL_CURSOS})
        }else{
            if (id > 0) {
                let itemToEdit = getState().cursos.list.find(e => e.id === id);
                dispatch({ type: cursosTypes.ABRIR_MODAL_CURSOS, payload: itemToEdit })
            } else {
                dispatch({ type: cursosTypes.ABRIR_MODAL_CURSOS, payload: {} })
            }
        }
    }
}
export function eliminarCurso(id) {
    return dispatch => {
        dispatch({
            type: cursosTypes.ELIMINAR_CURSOS,
            payload: delCurso(id)
        })
    }
}
export function agregarEditarCurso(obj) {
    let cleanObj = _.omitBy(obj, (v) => !v);

    return dispatch => {
        dispatch({
            type: cursosTypes.AGREGAR_EDITAR_CURSOS,
            payload: cleanObj.id ? editCurso(cleanObj) : addCurso(cleanObj) 
        })
    }
}
