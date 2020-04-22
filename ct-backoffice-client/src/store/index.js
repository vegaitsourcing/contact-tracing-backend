import { createStore, combineReducers, applyMiddleware } from 'redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import {
  userReducer,
  initState as userInitState,
} from './reducers/userReducer';

import thunk from 'redux-thunk';

const allReducers = combineReducers({
  user: userReducer,
});

const initState = {
  user: userInitState,
};

const store = createStore(
  allReducers,
  initState,
  composeWithDevTools(applyMiddleware(thunk))
);

export default store;
