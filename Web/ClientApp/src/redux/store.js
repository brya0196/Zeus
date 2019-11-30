import { createStore, applyMiddleware,compose } from 'redux';
import thunk from 'redux-thunk';
import rootReducer from './reducers/rootReducer';
import promise from "redux-promise-middleware";


const inititalState = {};

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const store = createStore(rootReducer, inititalState, composeEnhancers(
  applyMiddleware(promise, thunk)
  ));

export default store;
