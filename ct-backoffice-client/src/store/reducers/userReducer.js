import { User } from '../models/User';

export const initState = {
  loggedUser: User,
  token: null,
  error: false,
  success: false,
  loggedIn: false,
};

export const userReducer = (state = initState, action) => {
  switch (action.type) {
    case 'USER_LOGIN_SUCCESS': {
      return { ...state, token: action.payload, error: false };
    }
    case 'USER_LOGIN_FAIL': {
      return { ...state, token: null, error: true };
    }
    case 'USER_LOGOUT': {
      return { ...state, token: null, error: false };
    }
    default:
      return state;
  }
};
