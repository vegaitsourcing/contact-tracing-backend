import axios from 'axios';
import { URL } from '../../common/common';
import { Action } from '../models/Action';

export function login(email, password) {
  return (dispatch) => {
    return axios
      .post(`${URL}/login`, {
        email,
        password,
      })
      .then((response) => {
        if (response.data.token) {
          localStorage.setItem('loggedUser', response.data.email);
          localStorage.setItem('token', response.data.token);
          dispatch(Action('USER_LOGIN_SUCCESS', response.data.token));
        } else {
          dispatch(Action('USER_LOGIN_FAIL', response.data.message));
        }
      })
      .catch((e) => {
        console.log(e);
        dispatch(Action('USER_LOGIN_FAIL', 'Bad login!'));
      });
  };
}

export function logout() {
  return Action('USER_LOGOUT');
}
