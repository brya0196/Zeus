import { cursosTypes, _FULFILLED, _PENDING, _REJECTED } from '../actions/types';
const initialState = {
    list: [],
    byId: {},
    isFetching: false,
    isPending: false,
    error: null,
    showModal: false
};

export default (state = initialState, action={}) => {

    switch (action.type) {
        case cursosTypes.MOSTRAR_CURSOS + _PENDING: {
            return {
                ...state,
                isFetching: true,
                error: {}
            }
        }
        case cursosTypes.MOSTRAR_CURSOS + _FULFILLED: {
            return {
                ...state,
                list: action.payload.data,
                isFetching: false,
                error: {}
            }
        }
        case cursosTypes.MOSTRAR_CURSOS + _REJECTED: {
            const { data, status } = action.payload.response || { data:"Error no definido",};
            return {
                ...state,
                isPending: false,
                isFetching: false,
                error: { data, status }
            }
        }
        //agregar  o editar
        
        case cursosTypes.AGREGAR_EDITAR_CURSOS + _PENDING: {
            return {
                ...state,
                isPending: true,
                error: {}
            }
        }
        case cursosTypes.AGREGAR_EDITAR_CURSOS + _FULFILLED: {
            const { data } = action.payload;
            const list = state.list.filter(e => e.id !== data.id);
            list.unshift(data);
            return {
                ...state,
                list,
                isPending: false,
                showModal: false,
                error: {}
            }
        }
        case cursosTypes.AGREGAR_EDITAR_CURSOS + _REJECTED: {
            const { data, status } = action.payload.response || { data:"Error no definido"};
            return {
                ...state,
                isPending: false,
                isFetching: false,
                error: { data, status }
            }
        }
        //Eliminar

        case cursosTypes.ELIMINAR_CURSOS + _FULFILLED: {
            const { data: id  } = action.payload;
            let list = state.list.filter(e => e.id !== id); //eliminar el registro
            return {
                ...state,
                list,
                isPending: false,
                showModal: false,
                error: {}
            }
        }
        case cursosTypes.ABRIR_MODAL_CURSOS: {
            return {
                ...state,
                showModal: true,
                byId: action.payload
            }
        }
        case cursosTypes.CERRAR_MODAL_CURSOS: {
            return {
                ...state,
                showModal: false,
                byId: {}
            }
        }
        
    default:
      return state;
  }
}
