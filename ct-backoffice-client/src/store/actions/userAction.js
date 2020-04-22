import axios from 'axios';
import { URL } from '../../common/common';
import { Action } from '../models/Action';

export function login(email, password) {
  return (dispatch) => {
    dispatch(Action('USER_LOGIN_SUCCESS', 'somerandomtoken'));
  };
  //   return axios
  //     .post(`${URL}/authentication`, {
  //       email,
  //       password,
  //       strategy: 'local',
  //     })
  //     .then((response) => {
  //       if (response.data) {
  //         localStorage.setItem('loggedUser', response.data.user);
  //         localStorage.setItem('token', response.data.accessToken);
  //         dispatch(Action('USER_LOGIN_SUCCESS', response.data.accessToken));
  //       } else {
  //         dispatch(Action('USER_LOGIN_FAIL'));
  //       }
  //     })
  //     .catch((e) => {
  //       console.log(e);
  //       dispatch(Action('USER_LOGIN_FAIL'));
  //     });
  // };
}

export function logout() {
  return Action('USER_LOGOUT');
}
